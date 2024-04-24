using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects.Options;
using BingX.Net.Clients;
using BingX.Net.Interfaces.Clients;
using BingX.Net.Objects.Options;
using Bitfinex.Net.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitfinex.Net.Objects.Options;
using Bitget.Net.Clients;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using CoinEx.Net.Clients;
using CoinEx.Net.Interfaces.Clients;
using CoinEx.Net.Objects.Options;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.Interfaces.CommonClients;
using Huobi.Net.Clients;
using Huobi.Net.Interfaces.Clients;
using Huobi.Net.Objects.Options;
using Kraken.Net.Clients;
using Kraken.Net.Interfaces.Clients;
using Kraken.Net.Objects.Options;
using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces.Clients;
using Kucoin.Net.Objects.Options;
using Mexc.Net.Clients;
using Mexc.Net.Interfaces.Clients;
using Mexc.Net.Objects.Options;
using OKX.Net.Clients;
using OKX.Net.Interfaces.Clients;
using OKX.Net.Objects.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public class ExchangeRestClient : IExchangeRestClient
    {
        private IEnumerable<ISpotClient> _spotClients = Array.Empty<ISpotClient>();

        private readonly Dictionary<Exchange, string> _exchangeMapping = new()
        {
            { Exchange.Binance, "Binance" },
            { Exchange.BingX, "BingX" },
            { Exchange.Bitfinex, "Bitfinex" },
            { Exchange.Bitget, "Bitget" },
            { Exchange.Bybit, "Bybit" },
            { Exchange.CoinEx, "CoinEx" },
            { Exchange.Huobi, "Huobi" },
            { Exchange.Kraken, "Kraken" },
            { Exchange.Kucoin, "Kucoin" },
            { Exchange.Mexc, "Mexc" },
            { Exchange.OKX, "OKX" },
        };

        /// <inheritdoc />
        public IBinanceRestClient Binance { get; }
        /// <inheritdoc />
        public IBingXRestClient BingX { get; }
        /// <inheritdoc />
        public IBitfinexRestClient Bitfinex { get; }
        /// <inheritdoc />
        public IBitgetRestClient Bitget { get; }
        /// <inheritdoc />
        public IBybitRestClient Bybit { get; }
        /// <inheritdoc />
        public ICoinExRestClient CoinEx { get; }
        /// <inheritdoc />
        public IHuobiRestClient Huobi { get; }
        /// <inheritdoc />
        public IKrakenRestClient Kraken { get; }
        /// <inheritdoc />
        public IKucoinRestClient Kucoin { get; }
        /// <inheritdoc />
        public IMexcRestClient Mexc { get; }
        /// <inheritdoc />
        public IOKXRestClient OKX { get; }

        /// <summary>
        /// Create a new ExchangeRestClient instance. Client instances will be created with default options.
        /// </summary>
        public ExchangeRestClient()
        {
            Binance = new BinanceRestClient();
            BingX = new BingXRestClient();
            Bitfinex = new BitfinexRestClient();
            Bitget = new BitgetRestClient();
            Bybit = new BybitRestClient();
            CoinEx = new CoinExRestClient();
            Huobi = new HuobiRestClient();
            Kraken = new KrakenRestClient();
            Kucoin = new KucoinRestClient();
            Mexc = new MexcRestClient();
            OKX = new OKXRestClient();

            InitSpotClients();
        }

        /// <summary>
        /// Create a new ExchangeRestClient instance
        /// </summary>
        public ExchangeRestClient(
            Action<BinanceRestOptions>? binanceRestOptions = null,
            Action<BingXRestOptions>? bingxRestOptions = null,
            Action<BitfinexRestOptions>? bitfinexRestOptions = null,
            Action<BitgetRestOptions>? bitgetRestOptions = null,
            Action<BybitRestOptions>? bybitRestOptions = null,
            Action<CoinExRestOptions>? coinExRestOptions = null,
            Action<HuobiRestOptions>? huobiRestOptions = null,
            Action<KrakenRestOptions>? krakenRestOptions = null,
            Action<KucoinRestOptions>? kucoinRestOptions = null,
            Action<MexcRestOptions>? mexcRestOptions = null,
            Action<OKXRestOptions>? okxRestOptions = null)
        {
            Binance = new BinanceRestClient(binanceRestOptions);
            BingX = new BingXRestClient(bingxRestOptions);
            Bitfinex = new BitfinexRestClient(bitfinexRestOptions);
            Bitget = new BitgetRestClient(bitgetRestOptions);
            Bybit = new BybitRestClient(bybitRestOptions);
            CoinEx = new CoinExRestClient(coinExRestOptions);
            Huobi = new HuobiRestClient(huobiRestOptions);
            Kraken = new KrakenRestClient(krakenRestOptions);
            Kucoin = new KucoinRestClient(kucoinRestOptions);
            Mexc = new MexcRestClient(mexcRestOptions);
            OKX = new OKXRestClient(okxRestOptions);

            InitSpotClients();
        }

        private void InitSpotClients()
        {
            _spotClients = new[]
            {
                Binance.SpotApi.CommonSpotClient,
                BingX.SpotApi.CommonSpotClient,
                Bitfinex.SpotApi.CommonSpotClient,
                Bitget.SpotApi.CommonSpotClient,
                Bybit.V5Api.CommonSpotClient,
                CoinEx.SpotApiV2.CommonSpotClient,
                Huobi.SpotApi.CommonSpotClient,
                Kraken.SpotApi.CommonSpotClient,
                Kucoin.SpotApi.CommonSpotClient,
                Mexc.SpotApi.CommonSpotClient,
                OKX.UnifiedApi.CommonSpotClient,
            };
        }

        /// <summary>
        /// DI constructor
        /// </summary>
        public ExchangeRestClient(
            IBinanceRestClient binance,
            IBingXRestClient bingx,
            IBitfinexRestClient bitfinex,
            IBitgetRestClient bitget,
            IBybitRestClient bybit,
            ICoinExRestClient coinEx,
            IHuobiRestClient huobi,
            IKrakenRestClient kraken,
            IKucoinRestClient kucoin,
            IMexcRestClient mexc,
            IOKXRestClient okx,
            IEnumerable<ISpotClient> spotClients)
        {
            _spotClients = spotClients;

            Binance = binance;
            BingX = bingx;
            Bitfinex = bitfinex;
            Bitget = bitget;
            Bybit = bybit;
            CoinEx = coinEx;
            Huobi = huobi;
            Kraken = kraken;
            Kucoin = kucoin;
            Mexc = mexc;
            OKX = okx;
        }

        /// <inheritdoc />
        public ISpotClient GetUnifiedSpotClient(Exchange name)
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
