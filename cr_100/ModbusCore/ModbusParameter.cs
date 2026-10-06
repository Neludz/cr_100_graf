using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NModbus.Utility;

namespace cr_100.ModbusCore;

// Class representation for individual mode mapping objects
public class ModbusEnumItem
{
    public int Key { get; init; }
    public string Value { get; init; } = string.Empty;
}
// Описание кастомных текстов и цветов для лампы бита
public class ModbusBitLabels
{
    public string OnText { get; init; } = "ВКЛ";
    public string OnColor { get; init; } = "LightGreen";
    public string OffText { get; init; } = "ОТКЛ";
    public string OffColor { get; init; } = "LightCoral";
}
public class ModbusParameter
{
    public string Name { get; init; } = string.Empty;
    public ushort StartAddress { get; init; }
    public ModbusDataType DataType { get; init; }
    public int? BitPosition { get; init; } // Позиция бита (0-15), если тип DataType = Bit
    public string Unit { get; init; } = string.Empty;
    public double Scale { get; init; } = 1.0;
    public object Value { get; set; } = 0;
    public List<ModbusEnumItem> EnumValues { get; init; } = new();
    public ModbusBitLabels? BitLabels { get; init; }

    public void Decode(ushort[] rawRegisters)
    {
        Value = DataType switch
        {
            ModbusDataType.UInt16 => rawRegisters[0],
            ModbusDataType.Int16 => (short)rawRegisters[0],
            ModbusDataType.Float32 => ModbusUtility.GetSingle(rawRegisters[0], rawRegisters[1]),
            ModbusDataType.Bit => DecodeBit(rawRegisters[0]),
            _ => rawRegisters[0]
        };
    }

    private bool DecodeBit(ushort registerValue)
    {
        if (!BitPosition.HasValue) return false;
        int mask = 1 << BitPosition.Value;
        return (registerValue & mask) != 0; // Побитовое И (как в Си)
    }

    public ushort RegisterCount => DataType == ModbusDataType.Float32 ? (ushort)2 : (ushort)1;
}
