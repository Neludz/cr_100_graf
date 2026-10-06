namespace cr_100.ModbusCore;

public class ModbusCommand
{
    public string Name { get; init; } = string.Empty; // Текст для выпадающего списка
    public ushort Address { get; init; }              // Адрес регистра записи
    public ushort Value { get; init; }                // Константа (для обычной записи)
    public int? BitPosition { get; init; }            // Номер бита (0-15), если управляем битом
    public bool? BitValue { get; init; }              // true = 1, false = 0
    public string? ConfirmText { get; set; }
}
