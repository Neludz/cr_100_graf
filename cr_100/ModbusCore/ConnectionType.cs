using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cr_100.ModbusCore;

public enum ConnectionType
{
    Rtu, // COM-порт / RS-485 / RS-232
    Tcp  // Ethernet / Wi-Fi
}