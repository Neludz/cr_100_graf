using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace cr_100.Devices;

public class JsonModbusDevice : ModbusDevice
{
    public override byte SlaveId { get; set; } // Менавіта set;

    public override string DeviceName { get; init; } = string.Empty;

    public static JsonModbusDevice LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Файл конфігурацыі не знойдзены: {filePath}");

        string jsonString = File.ReadAllText(filePath);

        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };

        var device = JsonSerializer.Deserialize<JsonModbusDevice>(jsonString, options);
        return device ?? throw new Exception("Памылка JSON.");
    }
}
