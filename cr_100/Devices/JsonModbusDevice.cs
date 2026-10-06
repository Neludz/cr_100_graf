using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace cr_100.Devices;

public class JsonModbusDevice : ModbusDevice
{
    public override byte SlaveId { get; init; }
    public override string DeviceName { get; init; } = string.Empty;

    public static JsonModbusDevice LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Файл конфигурации не найден: {filePath}");

        string jsonString = File.ReadAllText(filePath);

        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };

        var device = JsonSerializer.Deserialize<JsonModbusDevice>(jsonString, options);
        return device ?? throw new Exception("Ошибка десериализации JSON.");
    }
}
