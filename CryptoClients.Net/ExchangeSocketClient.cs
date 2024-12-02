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
using Bitget.Net.Objects;
using Bitget.Net.Objects.Options;
using BitMart.Net.Clients;
using BitMart.Net.Interfaces.Clients;
using BitMart.Net.Objects;
using BitMart.Net.Objects.Options;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using Coinbase.Net.Clients;
using Coinbase.Net.Interfaces.Clients;
using Coinbase.Net.Objects.Options;
using CoinEx.Net.Clients;
using CoinEx.Net.Interfaces.Clients;
using CoinEx.Net.Objects.Options;
using CryptoClients.Net.Interfaces;
using CryptoClients.Net.Models;
using CryptoCom.Net.Clients;
using CryptoCom.Net.Interfaces.Clients;
using CryptoCom.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using GateIo.Net.Clients;
using GateIo.Net.Interfaces.Clients;
using GateIo.Net.Objects.Options;
using HTX.Net.Clients;
using HTX.Net.Interfaces.Clients;
using HTX.Net.Objects.Options;
using Kraken.Net.Clients;
using Kraken.Net.Interfaces.Clients;
using Kraken.Net.Objects.Options;
using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces.Clients;
using Kucoin.Net.Objects;
using Kucoin.Net.Objects.Options;
using Mexc.Net.Clients;
using Mexc.Net.Interfaces.Clients;
using Mexc.Net.Objects.Options;
using OKX.Net.Clients;
using OKX.Net.Interfaces.Clients;
using OKX.Net.Objects;
using OKX.Net.Objects.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WhiteBit.Net.Clients;
using WhiteBit.Net.Interfaces.Clients;
using WhiteBit.Net.Objects.Options;
using XT.Net.Clients;
using XT.Net.Interfaces.Clients;
using XT.Net.Objects.Options;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public class ExchangeSocketClient : IExchangeSocketClient
    {
        private IEnumerable<ISharedClient> _sharedClients = Array.Empty<ISharedClient>();

        /// <inheritdoc />
        public IBinanceSocketClient Binance { get; }
        /// <inheritdoc />
        public IBingXSocketClient BingX { get; }
        /// <inheritdoc />
        public IBitfinexSocketClient Bitfinex { get; }
        /// <inheritdoc />
        public IBitgetSocketClient Bitget { get; }
        /// <inheritdoc />
        public IBitMartSocketClient BitMart { get; }
        /// <inheritdoc />
        public IBybitSocketClient Bybit { get; }
        /// <inheritdoc />
        public ICoinbaseSocketClient Coinbase { get; }
        /// <inheritdoc />
        public ICoinExSocketClient CoinEx { get; }
        /// <inheritdoc />
        public ICryptoComSocketClient CryptoCom { get; }
        /// <inheritdoc />
        public IGateIoSocketClient GateIo { get; }
        /// <inheritdoc />
        public IHTXSocketClient HTX { get; }
        /// <inheritdoc />
        public IKrakenSocketClient Kraken { get; }
        /// <inheritdoc />
        public IKucoinSocketClient Kucoin { get; }
        /// <inheritdoc />
        public IMexcSocketClient Mexc { get; }
        /// <inheritdoc />
        public IOKXSocketClient OKX { get; }
        /// <inheritdoc />
        public IWhiteBitSocketClient WhiteBit { get; }
        /// <inheritdoc />
        public IXTSocketClient XT { get; }

        /// <inheritdoc />
        public IEnumerable<ITickerSocketClient> GetTickerClients() => _sharedClients.OfType<ITickerSocketClient>();
        /// <inheritdoc />
        public IEnumerable<ITickerSocketClient> GetTickerClients(TradingMode api) => _sharedClients.OfType<ITickerSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public ITickerSocketClient? GetTickerClient(TradingMode api, string exchange) => _sharedClients.OfType<ITickerSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ITickersSocketClient> GetTickersClients() => _sharedClients.OfType<ITickersSocketClient>();
        /// <inheritdoc />
        public IEnumerable<ITickersSocketClient> GetTickersClients(TradingMode api) => _sharedClients.OfType<ITickersSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public ITickersSocketClient? GetTickersClient(TradingMode api, string exchange) => _sharedClients.OfType<ITickersSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ITradeSocketClient> GetTradeClients() => _sharedClients.OfType<ITradeSocketClient>();
        /// <inheritdoc />
        public IEnumerable<ITradeSocketClient> GetTradeClients(TradingMode api) => _sharedClients.OfType<ITradeSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public ITradeSocketClient? GetTradeClient(TradingMode api, string exchange) => _sharedClients.OfType<ITradeSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IKlineSocketClient> GetKlineClients() => _sharedClients.OfType<IKlineSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IKlineSocketClient> GetKlineClients(TradingMode api) => _sharedClients.OfType<IKlineSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IKlineSocketClient? GetKlineClient(TradingMode api, string exchange) => _sharedClients.OfType<IKlineSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IOrderBookSocketClient> GetOrderBookClients() => _sharedClients.OfType<IOrderBookSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IOrderBookSocketClient> GetOrderBookClients(TradingMode api) => _sharedClients.OfType<IOrderBookSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IOrderBookSocketClient? GetOrderBookClient(TradingMode api, string exchange) => _sharedClients.OfType<IOrderBookSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IBalanceSocketClient> GetBalanceClients() => _sharedClients.OfType<IBalanceSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IBalanceSocketClient> GetBalanceClients(TradingMode api) => _sharedClients.OfType<IBalanceSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IBalanceSocketClient? GetBalanceClient(TradingMode api, string exchange) => _sharedClients.OfType<IBalanceSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IBookTickerSocketClient> GetBookTickerClients() => _sharedClients.OfType<IBookTickerSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IBookTickerSocketClient> GetBookTickerClients(TradingMode api) => _sharedClients.OfType<IBookTickerSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IBookTickerSocketClient? GetBookTickerClient(TradingMode api, string exchange) => _sharedClients.OfType<IBookTickerSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ISpotOrderSocketClient> GetSpotOrderClients() => _sharedClients.OfType<ISpotOrderSocketClient>();
        /// <inheritdoc />
        public ISpotOrderSocketClient? GetSpotOrderClient(string exchange) => _sharedClients.OfType<ISpotOrderSocketClient>().SingleOrDefault(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFuturesOrderSocketClient> GetFuturesOrderClients() => _sharedClients.OfType<IFuturesOrderSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesOrderSocketClient> GetFuturesOrderClients(TradingMode api) => _sharedClients.OfType<IFuturesOrderSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesOrderSocketClient? GetFuturesOrderClient(TradingMode api, string exchange) => _sharedClients.OfType<IFuturesOrderSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IUserTradeSocketClient> GetUserTradeClients() => _sharedClients.OfType<IUserTradeSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IUserTradeSocketClient> GetUserTradeClients(TradingMode api) => _sharedClients.OfType<IUserTradeSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IUserTradeSocketClient? GetUserTradeClient(TradingMode api, string exchange) => _sharedClients.OfType<IUserTradeSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IPositionSocketClient> GetPositionClients() => _sharedClients.OfType<IPositionSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IPositionSocketClient> GetPositionClients(TradingMode api) => _sharedClients.OfType<IPositionSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IPositionSocketClient? GetPositionClient(TradingMode api, string exchange) => _sharedClients.OfType<IPositionSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <summary>
        /// Create a new ExchangeSocketClient instance. Client instances will be created with default options.
        /// </summary>
        public ExchangeSocketClient()
        {
            Binance = new BinanceSocketClient();
            BingX = new BingXSocketClient();
            Bitfinex = new BitfinexSocketClient();
            Bitget = new BitgetSocketClient();
            BitMart = new BitMartSocketClient();
            Bybit = new BybitSocketClient();
            Coinbase = new CoinbaseSocketClient();
            CoinEx = new CoinExSocketClient();
            CryptoCom = new CryptoComSocketClient();
            GateIo = new GateIoSocketClient();
            HTX = new HTXSocketClient();
            Kraken = new KrakenSocketClient();
            Kucoin = new KucoinSocketClient();
            Mexc = new MexcSocketClient();
            OKX = new OKXSocketClient();
            WhiteBit = new WhiteBitSocketClient();
            XT = new XTSocketClient();

            InitSharedClients();
        }

        /// <summary>
        /// Create a new ExchangeSocketClient instance
        /// </summary>
        public ExchangeSocketClient(
            Action<GlobalExchangeOptions>? globalOptions = null,
            Action<BinanceSocketOptions>? binanceSocketOptions = null,
            Action<BingXSocketOptions>? bingxSocketOptions = null,
            Action<BitfinexSocketOptions>? bitfinexSocketOptions = null,
            Action<BitgetSocketOptions>? bitgetSocketOptions = null,
            Action<BitMartSocketOptions>? bitMartSocketOptions = null,
            Action<BybitSocketOptions>? bybitSocketOptions = null,
            Action<CoinExSocketOptions>? coinExSocketOptions = null,
            Action<CoinbaseSocketOptions>? coinbaseSocketOptions = null,
            Action<CryptoComSocketOptions>? cryptoComSocketOptions = null,
            Action<GateIoSocketOptions>? gateIoSocketOptions = null,
            Action<HTXSocketOptions>? htxSocketOptions = null,
            Action<KrakenSocketOptions>? krakenSocketOptions = null,
            Action<KucoinSocketOptions>? kucoinSocketOptions = null,
            Action<MexcSocketOptions>? mexcSocketOptions = null,
            Action<OKXSocketOptions>? okxSocketOptions = null,
            Action<WhiteBitSocketOptions>? whiteBitSocketOptions = null,
            Action<XTSocketOptions>? xtSocketOptions = null)
        {
            Action<TOptions> SetGlobalSocketOptions<TOptions, TCredentials>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TCredentials? credentials) where TOptions : SocketExchangeOptions where TCredentials : ApiCredentials
            {
                var socketDelegate = (TOptions socketOptions) =>
                {
                    socketOptions.Proxy = globalOptions.Proxy;
                    socketOptions.ApiCredentials = credentials;
                    socketOptions.OutputOriginalData = globalOptions.OutputOriginalData;
                    socketOptions.RequestTimeout = globalOptions.RequestTimeout;
                    socketOptions.RateLimiterEnabled = globalOptions.RateLimiterEnabled;
                    socketOptions.RateLimitingBehaviour = globalOptions.RateLimitingBehaviour;
                    socketOptions.ReconnectPolicy = globalOptions.ReconnectPolicy;
                    socketOptions.ReconnectInterval = globalOptions.ReconnectInterval;
                    exchangeDelegate?.Invoke(socketOptions);
                };

                return socketDelegate;
            }

            if (globalOptions != null)
            {
                var global = GlobalExchangeOptions.Default;
                globalOptions.Invoke(global);

                ExchangeCredentials? credentials = global.ApiCredentials;
                binanceSocketOptions = SetGlobalSocketOptions(global, binanceSocketOptions, credentials?.Binance);
                bingxSocketOptions = SetGlobalSocketOptions(global, bingxSocketOptions, credentials?.BingX);
                bitfinexSocketOptions = SetGlobalSocketOptions(global, bitfinexSocketOptions, credentials?.Bitfinex);
                bitgetSocketOptions = SetGlobalSocketOptions(global, bitgetSocketOptions, credentials?.Bitget);
                bitMartSocketOptions = SetGlobalSocketOptions(global, bitMartSocketOptions, credentials?.BitMart);
                bybitSocketOptions = SetGlobalSocketOptions(global, bybitSocketOptions, credentials?.Bybit);
                coinbaseSocketOptions = SetGlobalSocketOptions(global, coinbaseSocketOptions, credentials?.Coinbase);
                coinExSocketOptions = SetGlobalSocketOptions(global, coinExSocketOptions, credentials?.CoinEx);
                cryptoComSocketOptions = SetGlobalSocketOptions(global, cryptoComSocketOptions, credentials?.CryptoCom);
                gateIoSocketOptions = SetGlobalSocketOptions(global, gateIoSocketOptions, credentials?.GateIo);
                htxSocketOptions = SetGlobalSocketOptions(global, htxSocketOptions, credentials?.HTX);
                krakenSocketOptions = SetGlobalSocketOptions(global, krakenSocketOptions, credentials?.Kraken);
                kucoinSocketOptions = SetGlobalSocketOptions(global, kucoinSocketOptions, credentials?.Kucoin);
                mexcSocketOptions = SetGlobalSocketOptions(global, mexcSocketOptions, credentials?.Mexc);
                okxSocketOptions = SetGlobalSocketOptions(global, okxSocketOptions, credentials?.OKX);
                whiteBitSocketOptions = SetGlobalSocketOptions(global, whiteBitSocketOptions, credentials?.WhiteBit);
                xtSocketOptions = SetGlobalSocketOptions(global, xtSocketOptions, credentials?.XT);
            }

            Binance = new BinanceSocketClient(binanceSocketOptions ?? new Action<BinanceSocketOptions>((x) => { }));
            BingX = new BingXSocketClient(bingxSocketOptions ?? new Action<BingXSocketOptions>((x) => { }));
            Bitfinex = new BitfinexSocketClient(bitfinexSocketOptions ?? new Action<BitfinexSocketOptions>((x) => { }));
            Bitget = new BitgetSocketClient(bitgetSocketOptions ?? new Action<BitgetSocketOptions>((x) => { }));
            BitMart = new BitMartSocketClient(bitMartSocketOptions ?? new Action<BitMartSocketOptions>((x) => { }));
            Bybit = new BybitSocketClient(bybitSocketOptions ?? new Action<BybitSocketOptions>((x) => { }));
            Coinbase = new CoinbaseSocketClient(coinbaseSocketOptions ?? new Action<CoinbaseSocketOptions>((x) => { }));
            CoinEx = new CoinExSocketClient(coinExSocketOptions ?? new Action<CoinExSocketOptions>((x) => { }));
            HTX = new HTXSocketClient(htxSocketOptions ?? new Action<HTXSocketOptions>((x) => { }));
            CryptoCom = new CryptoComSocketClient(cryptoComSocketOptions ?? new Action<CryptoComSocketOptions>((x) => { }));
            GateIo = new GateIoSocketClient(gateIoSocketOptions ?? new Action<GateIoSocketOptions>((x) => { }));
            Kraken = new KrakenSocketClient(krakenSocketOptions ?? new Action<KrakenSocketOptions>((x) => { }));
            Kucoin = new KucoinSocketClient(kucoinSocketOptions ?? new Action<KucoinSocketOptions>((x) => { }));
            Mexc = new MexcSocketClient(mexcSocketOptions ?? new Action<MexcSocketOptions>((x) => { }));
            OKX = new OKXSocketClient(okxSocketOptions ?? new Action<OKXSocketOptions>((x) => { }));
            WhiteBit = new WhiteBitSocketClient(whiteBitSocketOptions ?? new Action<WhiteBitSocketOptions>((x) => { }));
            XT = new XTSocketClient(xtSocketOptions ?? new Action<XTSocketOptions>((x) => { }));

            InitSharedClients();
        }

        /// <summary>
        /// DI constructor
        /// </summary>
        public ExchangeSocketClient(
            IBinanceSocketClient binance,
            IBingXSocketClient bingx,
            IBitfinexSocketClient bitfinex,
            IBitgetSocketClient bitget,
            IBitMartSocketClient bitMart,
            IBybitSocketClient bybit,
            ICoinbaseSocketClient coinbase,
            ICoinExSocketClient coinEx,
            ICryptoComSocketClient cryptoCom,
            IGateIoSocketClient gateIo,
            IHTXSocketClient htx,
            IKrakenSocketClient kraken,
            IKucoinSocketClient kucoin,
            IMexcSocketClient mexc,
            IOKXSocketClient okx,
            IWhiteBitSocketClient whiteBit,
            IXTSocketClient xt)
        {
            Binance = binance;
            BingX = bingx;
            Bitfinex = bitfinex;
            Bitget = bitget;
            BitMart = bitMart;
            Bybit = bybit;
            Coinbase = coinbase;
            CoinEx = coinEx;
            CryptoCom = cryptoCom;
            GateIo = gateIo;
            HTX = htx;
            Kraken = kraken;
            Kucoin = kucoin;
            Mexc = mexc;
            OKX = okx;
            WhiteBit = whiteBit;
            XT = xt;

            InitSharedClients();
        }

        private void InitSharedClients()
        {
            _sharedClients = new ISharedClient[]
            {
                Binance.SpotApi.SharedClient,
                Binance.UsdFuturesApi.SharedClient,
                Binance.CoinFuturesApi.SharedClient,
                BingX.SpotApi.SharedClient,
                BingX.PerpetualFuturesApi.SharedClient,
                Bitfinex.SpotApi.SharedClient,
                Bitget.SpotApiV2.SharedClient,
                Bitget.FuturesApiV2.SharedClient,
                BitMart.SpotApi.SharedClient,
                BitMart.UsdFuturesApi.SharedClient,
                Bybit.V5InverseApi.SharedClient,
                Bybit.V5LinearApi.SharedClient,
                Bybit.V5PrivateApi.SharedClient,
                Bybit.V5SpotApi.SharedClient,
                Coinbase.AdvancedTradeApi.SharedClient,
                CoinEx.SpotApiV2.SharedClient,
                CoinEx.FuturesApi.SharedClient,
                CryptoCom.ExchangeApi.SharedClient,
                GateIo.SpotApi.SharedClient,
                GateIo.PerpetualFuturesApi.SharedClient,
                HTX.SpotApi.SharedClient,
                HTX.UsdtFuturesApi.SharedClient,
                Kraken.SpotApi.SharedClient,
                Kraken.FuturesApi.SharedClient,
                Kucoin.SpotApi.SharedClient,
                Kucoin.FuturesApi.SharedClient,
                Mexc.SpotApi.SharedClient,
                OKX.UnifiedApi.SharedClient,
                WhiteBit.V4Api.SharedClient,
                XT.SpotApi.SharedClient,
                XT.FuturesApi.SharedClient
            };
        }

        /// <inheritdoc />
        public IEnumerable<ISharedClient> GetExchangeSharedClients(string name, TradingMode? tradingMode = null)
        {
            var result = _sharedClients.Where(s => s.Exchange == name);
            if (tradingMode.HasValue)
                result = result.Where(x => x.SupportedTradingModes.Contains(tradingMode.Value));
            return result.ToList();
        }

        /// <inheritdoc />
        public void SetApiCredentials(string exchange, string apiKey, string apiSecret, string? apiPass = null)
        {
            switch (exchange)
            {
                case "Binance": Binance.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "BingX": BingX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Bitfinex": Bitfinex.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Bitget": Bitget.SetApiCredentials(new BitgetApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for Bitget credentials", nameof(apiPass)))); break;
                case "BitMart": BitMart.SetApiCredentials(new BitMartApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for BitMart credentials", nameof(apiPass)))); break;
                case "Bybit": Bybit.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Coinbase": Coinbase.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "CoinEx": CoinEx.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "CryptoCom": CryptoCom.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "GateIo": GateIo.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "HTX": HTX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Kraken": Kraken.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Kucoin": Kucoin.SetApiCredentials(new KucoinApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for Kucoin credentials", nameof(apiPass)))); break;
                case "Mexc": Mexc.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "OKX": OKX.SetApiCredentials(new OKXApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for OKX credentials", nameof(apiPass)))); break;
                case "WhiteBit": WhiteBit.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "XT": XT.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                default: throw new ArgumentException("Exchange not recognized", nameof(exchange));
            }
        }

        #region Subscribe All Ticker

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToAllTickerUpdatesAsync(SubscribeAllTickersRequest request, Action<ExchangeEvent<IEnumerable<SharedSpotTicker>>> handler, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetTickersClients().Where(x => request.TradingMode == null ? true: x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToAllTickersUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

        #region Subscribe Ticker

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetTickerClients(request.Symbol.TradingMode);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToTickerUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

        #region Subscribe Trade

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToTradeUpdatesAsync(SubscribeTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetTradeClients(request.Symbol.TradingMode);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToTradeUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

        #region Subscribe Book Ticker

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetBookTickerClients(request.Symbol.TradingMode);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToBookTickerUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

        #region Subscribe Kline

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToKlineUpdatesAsync(SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetKlineClients(request.Symbol.TradingMode);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToKlineUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

        #region Subscribe Order Book

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToOrderBookUpdatesAsync(SubscribeOrderBookRequest request, Action<ExchangeEvent<SharedOrderBook>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetOrderBookClients(request.Symbol.TradingMode);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToOrderBookUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

        #region Subscribe Balance

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToBalanceUpdatesAsync(SubscribeBalancesRequest request, Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetBalanceClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                var exchangeRequest = request with { ListenKey = ExchangeParameters.GetValue<string>(request.ExchangeParameters, x.Exchange, nameof(SubscribeBalancesRequest.ListenKey)) ?? request.ListenKey };
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToBalanceUpdatesAsync(exchangeRequest, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

        #region Subscribe Spot Order

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToSpotOrderUpdatesAsync(SubscribeSpotOrderRequest request, Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                var exchangeRequest = request with { ListenKey = ExchangeParameters.GetValue<string>(request.ExchangeParameters, x.Exchange, nameof(SubscribeSpotOrderRequest.ListenKey)) ?? request.ListenKey };
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToSpotOrderUpdatesAsync(exchangeRequest, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

        #region Subscribe Futures Order

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToFuturesOrderUpdatesAsync(SubscribeFuturesOrderRequest request, Action<ExchangeEvent<IEnumerable<SharedFuturesOrder>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetFuturesOrderClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                var exchangeRequest = request with { ListenKey = ExchangeParameters.GetValue<string>(request.ExchangeParameters, x.Exchange, nameof(SubscribeFuturesOrderRequest.ListenKey)) ?? request.ListenKey };
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToFuturesOrderUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

        #region Subscribe User Trade

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToUserTradeUpdatesAsync(SubscribeUserTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetUserTradeClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                var exchangeRequest = request with { ListenKey = ExchangeParameters.GetValue<string>(request.ExchangeParameters, x.Exchange, nameof(SubscribeUserTradeRequest.ListenKey)) ?? request.ListenKey };
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToUserTradeUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

        /// <inheritdoc />
        public async Task UnsubscribeAllAsync()
        {
            var tasks = new[]
            {
                Binance.UnsubscribeAllAsync(),
                BingX.UnsubscribeAllAsync(),
                Bitfinex.UnsubscribeAllAsync(),
                Bitget.UnsubscribeAllAsync(),
                BitMart.UnsubscribeAllAsync(),
                Bybit.UnsubscribeAllAsync(),
                Coinbase.UnsubscribeAllAsync(),
                CoinEx.UnsubscribeAllAsync(),
                CryptoCom.UnsubscribeAllAsync(),
                GateIo.UnsubscribeAllAsync(),
                HTX.UnsubscribeAllAsync(),
                Kraken.UnsubscribeAllAsync(),
                Kucoin.UnsubscribeAllAsync(),
                Mexc.UnsubscribeAllAsync(),
                OKX.UnsubscribeAllAsync(),
                WhiteBit.UnsubscribeAllAsync(),
                XT.UnsubscribeAllAsync()
            };
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
