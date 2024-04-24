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

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public class ExchangeSocketClient : IExchangeSocketClient
    {
        /// <inheritdoc />
        public IBinanceSocketClient Binance { get; }
        /// <inheritdoc />
        public IBingXSocketClient BingX { get; }
        /// <inheritdoc />
        public IBitfinexSocketClient Bitfinex { get; }
        /// <inheritdoc />
        public IBitgetSocketClient Bitget { get; }
        /// <inheritdoc />
        public IBybitSocketClient Bybit { get; }
        /// <inheritdoc />
        public ICoinExSocketClient CoinEx { get; }
        /// <inheritdoc />
        public IHuobiSocketClient Huobi { get; }
        /// <inheritdoc />
        public IKrakenSocketClient Kraken { get; }
        /// <inheritdoc />
        public IKucoinSocketClient Kucoin { get; }
        /// <inheritdoc />
        public IMexcSocketClient Mexc { get; }
        /// <inheritdoc />
        public IOKXSocketClient OKX { get; }

        /// <summary>
        /// Create a new ExchangeSocketClient instance. Client instances will be created with default options.
        /// </summary>
        public ExchangeSocketClient()
        {
            Binance = new BinanceSocketClient();
            BingX = new BingXSocketClient();
            Bitfinex = new BitfinexSocketClient();
            Bitget = new BitgetSocketClient();
            Bybit = new BybitSocketClient();
            CoinEx = new CoinExSocketClient();
            Huobi = new HuobiSocketClient();
            Kraken = new KrakenSocketClient();
            Kucoin = new KucoinSocketClient();
            Mexc = new MexcSocketClient();
            OKX = new OKXSocketClient();
        }

        /// <summary>
        /// Create a new ExchangeSocketClient instance
        /// </summary>
        public ExchangeSocketClient(
            Action<BinanceSocketOptions>? binanceRestOptions = null,
            Action<BingXSocketOptions>? bingxRestOptions = null,
            Action<BitfinexSocketOptions>? bitfinexRestOptions = null,
            Action<BitgetSocketOptions>? bitgetRestOptions = null,
            Action<BybitSocketOptions>? bybitRestOptions = null,
            Action<CoinExSocketOptions>? coinexRestOptions = null,
            Action<HuobiSocketOptions>? huobiRestOptions = null,
            Action<KrakenSocketOptions>? krakenRestOptions = null,
            Action<KucoinSocketOptions>? kucoinRestOptions = null,
            Action<MexcSocketOptions>? mexcRestOptions = null,
            Action<OKXSocketOptions>? okxRestOptions = null)
        {
            Binance = new BinanceSocketClient(binanceRestOptions ?? new Action<BinanceSocketOptions>((x) => { }));
            BingX = new BingXSocketClient(bingxRestOptions ?? new Action<BingXSocketOptions>((x) => { }));
            Bitfinex = new BitfinexSocketClient(bitfinexRestOptions ?? new Action<BitfinexSocketOptions>((x) => { }));
            Bitget = new BitgetSocketClient(bitgetRestOptions ?? new Action<BitgetSocketOptions>((x) => { }));
            Bybit = new BybitSocketClient(bybitRestOptions ?? new Action<BybitSocketOptions>((x) => { }));
            CoinEx = new CoinExSocketClient(coinexRestOptions ?? new Action<CoinExSocketOptions>((x) => { }));
            Huobi = new HuobiSocketClient(huobiRestOptions ?? new Action<HuobiSocketOptions>((x) => { }));
            Kraken = new KrakenSocketClient(krakenRestOptions ?? new Action<KrakenSocketOptions>((x) => { }));
            Kucoin = new KucoinSocketClient(kucoinRestOptions ?? new Action<KucoinSocketOptions>((x) => { }));
            Mexc = new MexcSocketClient(mexcRestOptions ?? new Action<MexcSocketOptions>((x) => { }));
            OKX = new OKXSocketClient(okxRestOptions ?? new Action<OKXSocketOptions>((x) => { }));
        }

        /// <summary>
        /// DI constructor
        /// </summary>
        public ExchangeSocketClient(
            IBinanceSocketClient binance,
            IBingXSocketClient bingx,
            IBitfinexSocketClient bitfinex,
            IBitgetSocketClient bitget,
            IBybitSocketClient bybit,
            ICoinExSocketClient coinEx,
            IHuobiSocketClient huobi,
            IKrakenSocketClient kraken,
            IKucoinSocketClient kucoin,
            IMexcSocketClient mexc,
            IOKXSocketClient okx)
        {
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

    }
}
