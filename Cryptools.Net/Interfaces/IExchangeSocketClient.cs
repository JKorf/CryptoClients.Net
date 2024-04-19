using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptools.Net.Interfaces
{
    public interface IExchangeSocketClient
    {
        IBinanceSocketClient Binance { get; }
        IBingXSocketClient BingX { get; }
    }
}
