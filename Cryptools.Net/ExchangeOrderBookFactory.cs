using Binance.Net.Interfaces;
using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces;
using BingX.Net.Interfaces.Clients;
using Cryptools.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptools.Net
{
    public class ExchangeOrderBookFactory : IExchangeOrderBookFactory
    {
        public IBinanceOrderBookFactory Binance { get; }
        public IBingXOrderBookFactory BingX { get; }

        public ExchangeOrderBookFactory(IBinanceOrderBookFactory binance, IBingXOrderBookFactory bingXRestClient)
        {
            Binance = binance;
            BingX = bingXRestClient;
        }

    }
}
