using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using CryptoExchange.Net.Interfaces.CommonClients;
using Cryptools.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptools.Net
{
    public class ExchangeRestClient : IExchangeRestClient
    {
        private IEnumerable<ISpotClient> _spotClients;

        public IBinanceRestClient Binance { get; }
        public IBingXRestClient BingX { get; }

        public ExchangeRestClient(
            IBinanceRestClient binance,
            IBingXRestClient bingx,
            IEnumerable<ISpotClient> spotClients)
        {
            _spotClients = spotClients;

            Binance = binance;
            BingX = bingx;
        }

        public ISpotClient? GetUnifiedSpotClient(string name)
        {
            return _spotClients.SingleOrDefault(s => s.ExchangeName == name);
        }

        public IEnumerable<ISpotClient> GetUnifiedSpotClients()
        {
            return _spotClients.ToList();
        }
    }
}
