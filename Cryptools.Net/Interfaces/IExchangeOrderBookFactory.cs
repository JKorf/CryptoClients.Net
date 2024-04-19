using Binance.Net.Interfaces;
using BingX.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptools.Net.Interfaces
{
    public interface IExchangeOrderBookFactory
    {
        IBinanceOrderBookFactory Binance { get; }
        IBingXOrderBookFactory BingX { get; }
    }
}
