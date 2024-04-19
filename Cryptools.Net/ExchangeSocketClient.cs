using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using Cryptools.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptools.Net
{
    public class ExchangeSocketClient : IExchangeSocketClient
    {
        public IBinanceSocketClient Binance { get; }
        public IBingXSocketClient BingX { get; }

        public ExchangeSocketClient(IBinanceSocketClient binance, IBingXSocketClient bingXRestClient)
        {
            Binance = binance;
            BingX = bingXRestClient;
        }

    }
}
