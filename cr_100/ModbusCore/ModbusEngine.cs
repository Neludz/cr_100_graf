using System;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading.Tasks;
using NModbus;
using cr_100.Devices;

namespace cr_100.ModbusCore;

public class ModbusEngine
{
    private SerialPort? _serialPort;
    private TcpClient? _tcpClient;
    private IModbusMaster? _master;

    public void ConnectRtu(string portName, int baudRate, Parity parity, StopBits stopBits, int timeout)
    {
        Disconnect();
        _serialPort = new SerialPort(portName, baudRate, parity, 8, stopBits)
        {
            ReadTimeout = timeout,
            WriteTimeout = timeout
        };
        _serialPort.Open();

        var adapter = new CustomStreamAdapter(_serialPort);
        var factory = new ModbusFactory();
        _master = factory.CreateRtuMaster(adapter);
    }

    public void ConnectTcp(string ipAddress, int port, int timeout)
    {
        Disconnect();
        _tcpClient = new TcpClient();
        var result = _tcpClient.BeginConnect(ipAddress, port, null, null);
        var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2));

        if (!success)
        {
            _tcpClient.Close();
            throw new TimeoutException($"Таймаут подключения к TCP {ipAddress}:{port}");
        }

        _tcpClient.EndConnect(result);
        _tcpClient.ReceiveTimeout = timeout;
        _tcpClient.SendTimeout = timeout;

        var factory = new ModbusFactory();
        _master = factory.CreateMaster(_tcpClient);
    }

    public void Disconnect()
    {
        _master = null;
        try { if (_serialPort != null && _serialPort.IsOpen) _serialPort.Close(); } catch { } finally { _serialPort = null; }
        try { if (_tcpClient != null) _tcpClient.Close(); } catch { } finally { _tcpClient = null; }
    }

    public async Task PollDeviceAsync(ModbusDevice device)
    {
        if (_master == null) throw new InvalidOperationException("Движок Modbus не подключен.");
        ushort start = device.GetPollStartAddress();
        ushort count = device.GetPollRegisterCount();

        ushort[] rawData = await _master.ReadHoldingRegistersAsync(device.SlaveId, start, count);

        foreach (var param in device.Parameters)
        {
            int offset = param.StartAddress - start;
            ushort[] paramBuffer = new ushort[param.RegisterCount];
            Array.Copy(rawData, offset, paramBuffer, 0, param.RegisterCount);
            param.Decode(paramBuffer);
        }
    }

    public async Task WriteConstantOrVariableAsync(byte slaveId, ushort address, ushort value)
    {
        if (_master == null) throw new InvalidOperationException("Движок Modbus не подключен.");
        await _master.WriteSingleRegisterAsync(slaveId, address, value);
    }

    // Метод побитовой записи (Чтение -> Битовая маска -> Функция 06 Запись)
    public async Task WriteBitInRegisterAsync(byte slaveId, ushort address, int bitPosition, bool bitValue)
    {
        if (_master == null) throw new InvalidOperationException("Движок Modbus не подключен.");

        // 1. Читаем текущее 16-битное значение регистра (Функция 03)
        ushort[] currentReg = await _master.ReadHoldingRegistersAsync(slaveId, address, 1);
        if (currentReg == null || currentReg.Length == 0) throw new System.IO.IOException("Ошибка чтения регистра.");

        ushort regValue = currentReg[0];

        // 2. Модифицируем конкретный бит строго по правилам Си/C#
        if (bitValue)
        {
            regValue |= (ushort)(1 << bitPosition); // Устанавливаем бит в 1
        }
        else
        {
            regValue &= (ushort)~(1 << bitPosition); // Сбрасываем бит в 0
        }

        // 3. Отправляем измененное значение обратно в устройство по функции 06
        await _master.WriteSingleRegisterAsync(slaveId, address, regValue);
    }
}





// ПАСТИТЬ СЮДА: Класс адаптера потока для предотвращения зависания при отладке
public class CustomStreamAdapter : NModbus.IO.IStreamResource
{
    private readonly SerialPort _port;
    public CustomStreamAdapter(SerialPort port) => _port = port;

    public int InfiniteTimeout => SerialPort.InfiniteTimeout;
    public int ReadTimeout { get => _port.ReadTimeout; set => _port.ReadTimeout = value; }
    public int WriteTimeout { get => _port.WriteTimeout; set => _port.WriteTimeout = value; }

    public void DiscardInBuffer() => _port.DiscardInBuffer();
    public void Write(byte[] buffer, int offset, int count) => _port.Write(buffer, offset, count);
    public void Dispose() => _port.Dispose();

    public int Read(byte[] buffer, int offset, int count)
    {
        var startTime = DateTime.Now;
        while (_port.BytesToRead == 0)
        {
            if (_port.ReadTimeout != SerialPort.InfiniteTimeout && (DateTime.Now - startTime).TotalMilliseconds > _port.ReadTimeout)
                throw new InvalidOperationException("Устройство не ответило (Таймаут).");
            System.Threading.Thread.Sleep(10);
        }
        return _port.Read(buffer, offset, count);
    }
}
