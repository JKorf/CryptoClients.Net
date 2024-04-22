using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoTradeKit.Net.Enums;
using CryptoTradeKit.Net.Interfaces;
using Kucoin.Net.Interfaces.Clients;
using System.Collections.Generic;
using System.Linq;

namespace CryptoTradeKit.Net
{
    /// <inheritdoc />
    public class ExchangeRestClient : IExchangeRestClient
    {
        private readonly IEnumerable<ISpotClient> _spotClients;

        private readonly Dictionary<ExchangeName, string> _exchangeMapping = new()
        {
            { ExchangeName.Binance, "Binance" },
            { ExchangeName.BingX, "BingX" },
            { ExchangeName.Kucoin, "Kucoin" },
        };

        /// <inheritdoc />
        public IBinanceRestClient Binance { get; }
        /// <inheritdoc />
        public IBingXRestClient BingX { get; }
        /// <inheritdoc />
        public IKucoinRestClient Kucoin { get; }


        /// <summary>
        /// ctor
        /// </summary>
        public ExchangeRestClient(
            IBinanceRestClient binance,
            IBingXRestClient bingx,
            IKucoinRestClient kucoin,
            IEnumerable<ISpotClient> spotClients)
        {
            _spotClients = spotClients;

            Binance = binance;
            BingX = bingx;
            Kucoin = kucoin;
        }

        /// <inheritdoc />
        public ISpotClient GetUnifiedSpotClient(ExchangeName name)
        {
            return _spotClients.Single(s => s.ExchangeName == _exchangeMapping[name]);
        }

        /// <inheritdoc />
        public IEnumerable<ISpotClient> GetUnifiedSpotClients()
        {
            return _spotClients.ToList();
        }
    }
}
