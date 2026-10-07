using System.Collections.Generic;
using System.Linq;
using cr_100.ModbusCore;

namespace cr_100.Devices;

public abstract class ModbusDevice
{
    public abstract byte SlaveId { get; set; } // Менавіта set;, а не init;
    public abstract string DeviceName { get; init; }
    public List<ModbusParameter> Parameters { get; set; } = new();
    public List<ModbusCommand> Commands { get; set; } = new(); // Список констант/команд из JSON

    public ushort GetPollStartAddress() => Parameters.Min(p => p.StartAddress);

    public ushort GetPollRegisterCount()
    {
        if (Parameters.Count == 0) return 0;
        var maxParam = Parameters.OrderByDescending(p => p.StartAddress).First();
        return (ushort)((maxParam.StartAddress - GetPollStartAddress()) + maxParam.RegisterCount);
    }
}
