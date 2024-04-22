using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using BingX.Net.Clients;
using BingX.Net.Interfaces.Clients;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoTradeKit.Net.Enums;
using CryptoTradeKit.Net.Interfaces;
using Kucoin.Net.Clients;
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
        /// Create a new ExchangeRestClient instance. Client instances will be created with default options.
        /// </summary>
        public ExchangeRestClient()
        {
            Binance = new BinanceRestClient();
            BingX = new BingXRestClient();
            Kucoin = new KucoinRestClient();

            _spotClients = new[] { Binance.SpotApi.CommonSpotClient, BingX.SpotApi.CommonSpotClient, Kucoin.SpotApi.CommonSpotClient };
        }

        /// <summary>
        /// DI constructor
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
