using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cr_100.ModbusCore;

public enum ModbusDataType
{
    Int16,      // 1 регистр со знаком (от -32768 до 32767)
    UInt16,     // 1 регистр без знака (от 0 до 65535)
    Float32,    // 2 регистра (число с плавающей точкой)
    Bit         // 1 конкретный бит внутри 16-битного регистра
}

