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
using BitMart.Net.Clients;
using BitMart.Net.Interfaces.Clients;
using BitMart.Net.Objects.Options;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using CoinEx.Net.Clients;
using CoinEx.Net.Interfaces.Clients;
using CoinEx.Net.Objects.Options;
using CryptoClients.Net.Enums;
using CryptoClients.Net.ExtensionMethods;
using CryptoClients.Net.Interfaces;
using CryptoClients.Net.Models;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis.Interfaces;
using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using CryptoExchange.Net.SharedApis.Models;
using CryptoExchange.Net.SharedApis.Models.Socket;
using CryptoExchange.Net.SharedApis.RequestModels;
using CryptoExchange.Net.SharedApis.ResponseModels;
using CryptoExchange.Net.SharedApis.SubscribeModels;
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
using System.Threading;
using System.Threading.Tasks;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public class ExchangeSocketClient : IExchangeSocketClient
    {
        private Dictionary<ApiType, ISharedClient[]> _sharedClients = new Dictionary<ApiType, ISharedClient[]>();

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
        public ICoinExSocketClient CoinEx { get; }
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
        public IEnumerable<ITickerSocketClient> GetTickerClients(ApiType apiType) => _sharedClients[apiType].OfType<ITickerSocketClient>();
        /// <inheritdoc />
        public ITickerSocketClient TickerClient(ApiType api, string exchange) => _sharedClients[api].OfType<ITickerSocketClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ITickersSocketClient> GetTickersClients(ApiType apiType) => _sharedClients[apiType].OfType<ITickersSocketClient>();
        /// <inheritdoc />
        public ITickersSocketClient TickersClient(ApiType api, string exchange) => _sharedClients[api].OfType<ITickersSocketClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ITradeSocketClient> GetTradeClients(ApiType apiType) => _sharedClients[apiType].OfType<ITradeSocketClient>();
        /// <inheritdoc />
        public ITradeSocketClient TradeClient(ApiType api, string exchange) => _sharedClients[api].OfType<ITradeSocketClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IKlineSocketClient> GetKlineClients(ApiType apiType) => _sharedClients[apiType].OfType<IKlineSocketClient>();
        /// <inheritdoc />
        public IKlineSocketClient KlineClient(ApiType api, string exchange) => _sharedClients[api].OfType<IKlineSocketClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IOrderBookSocketClient> GetOrderBookClients(ApiType apiType) => _sharedClients[apiType].OfType<IOrderBookSocketClient>();
        /// <inheritdoc />
        public IOrderBookSocketClient OrderBookClient(ApiType api, string exchange) => _sharedClients[api].OfType<IOrderBookSocketClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IBalanceSocketClient> GetBalanceClients(ApiType apiType) => _sharedClients[apiType].OfType<IBalanceSocketClient>();
        /// <inheritdoc />
        public IBalanceSocketClient BalanceClient(ApiType api, string exchange) => _sharedClients[api].OfType<IBalanceSocketClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IBookTickerSocketClient> GetBookTickerClients(ApiType apiType) => _sharedClients[apiType].OfType<IBookTickerSocketClient>();
        /// <inheritdoc />
        public IBookTickerSocketClient BookTickerClient(ApiType api, string exchange) => _sharedClients[api].OfType<IBookTickerSocketClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ISpotOrderSocketClient> GetSpotOrderClients() => _sharedClients[ApiType.Spot].OfType<ISpotOrderSocketClient>();
        /// <inheritdoc />
        public ISpotOrderSocketClient SpotOrderClient(string exchange) => _sharedClients[ApiType.Spot].OfType<ISpotOrderSocketClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFuturesOrderSocketClient> GetFuturesOrderClients(ApiType apiType) => _sharedClients[apiType].OfType<IFuturesOrderSocketClient>();
        /// <inheritdoc />
        public IFuturesOrderSocketClient FuturesOrderClient(ApiType apiType, string exchange) => _sharedClients[apiType].OfType<IFuturesOrderSocketClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IUserTradeSocketClient> GetUserTradeClients(ApiType apiType) => _sharedClients[apiType].OfType<IUserTradeSocketClient>();
        /// <inheritdoc />
        public IUserTradeSocketClient UserTradeClient(ApiType apiType, string exchange) => _sharedClients[apiType].OfType<IUserTradeSocketClient>().Single(s => s.Exchange == exchange);

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
            CoinEx = new CoinExSocketClient();
            GateIo = new GateIoSocketClient();
            HTX = new HTXSocketClient();
            Kraken = new KrakenSocketClient();
            Kucoin = new KucoinSocketClient();
            Mexc = new MexcSocketClient();
            OKX = new OKXSocketClient();

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
            Action<GateIoSocketOptions>? gateIoSocketOptions = null,
            Action<HTXSocketOptions>? htxSocketOptions = null,
            Action<KrakenSocketOptions>? krakenSocketOptions = null,
            Action<KucoinSocketOptions>? kucoinSocketOptions = null,
            Action<MexcSocketOptions>? mexcSocketOptions = null,
            Action<OKXSocketOptions>? okxSocketOptions = null)
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
                coinExSocketOptions = SetGlobalSocketOptions(global, coinExSocketOptions, credentials?.CoinEx);
                gateIoSocketOptions = SetGlobalSocketOptions(global, gateIoSocketOptions, credentials?.GateIo);
                htxSocketOptions = SetGlobalSocketOptions(global, htxSocketOptions, credentials?.HTX);
                krakenSocketOptions = SetGlobalSocketOptions(global, krakenSocketOptions, credentials?.Kraken);
                kucoinSocketOptions = SetGlobalSocketOptions(global, kucoinSocketOptions, credentials?.Kucoin);
                mexcSocketOptions = SetGlobalSocketOptions(global, mexcSocketOptions, credentials?.Mexc);
                okxSocketOptions = SetGlobalSocketOptions(global, okxSocketOptions, credentials?.OKX);
            }

            Binance = new BinanceSocketClient(binanceSocketOptions ?? new Action<BinanceSocketOptions>((x) => { }));
            BingX = new BingXSocketClient(bingxSocketOptions ?? new Action<BingXSocketOptions>((x) => { }));
            Bitfinex = new BitfinexSocketClient(bitfinexSocketOptions ?? new Action<BitfinexSocketOptions>((x) => { }));
            Bitget = new BitgetSocketClient(bitgetSocketOptions ?? new Action<BitgetSocketOptions>((x) => { }));
            BitMart = new BitMartSocketClient(bitMartSocketOptions ?? new Action<BitMartSocketOptions>((x) => { }));
            Bybit = new BybitSocketClient(bybitSocketOptions ?? new Action<BybitSocketOptions>((x) => { }));
            CoinEx = new CoinExSocketClient(coinExSocketOptions ?? new Action<CoinExSocketOptions>((x) => { }));
            HTX = new HTXSocketClient(htxSocketOptions ?? new Action<HTXSocketOptions>((x) => { }));
            GateIo = new GateIoSocketClient(gateIoSocketOptions ?? new Action<GateIoSocketOptions>((x) => { }));
            Kraken = new KrakenSocketClient(krakenSocketOptions ?? new Action<KrakenSocketOptions>((x) => { }));
            Kucoin = new KucoinSocketClient(kucoinSocketOptions ?? new Action<KucoinSocketOptions>((x) => { }));
            Mexc = new MexcSocketClient(mexcSocketOptions ?? new Action<MexcSocketOptions>((x) => { }));
            OKX = new OKXSocketClient(okxSocketOptions ?? new Action<OKXSocketOptions>((x) => { }));

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
            ICoinExSocketClient coinEx,
            IGateIoSocketClient gateIo,
            IHTXSocketClient htx,
            IKrakenSocketClient kraken,
            IKucoinSocketClient kucoin,
            IMexcSocketClient mexc,
            IOKXSocketClient okx)
        {
            Binance = binance;
            BingX = bingx;
            Bitfinex = bitfinex;
            Bitget = bitget;
            BitMart = bitMart;
            Bybit = bybit;
            CoinEx = coinEx;
            GateIo = gateIo;
            HTX = htx;
            Kraken = kraken;
            Kucoin = kucoin;
            Mexc = mexc;
            OKX = okx;

            InitSharedClients();
        }

        private void InitSharedClients()
        {
            _sharedClients[ApiType.Spot] = new ISharedClient[]
            {
                Binance.SpotApi.SharedClient,
                BingX.SpotApi.SharedClient,
                Bitfinex.SpotApi.SharedClient,
                Bitget.SpotApiV2.SharedClient,
                BitMart.SpotApi.SharedClient,
                Bybit.V5SpotApi.SharedClient,
                Bybit.V5PrivateApi.SharedClient,
                CoinEx.SpotApiV2.SharedClient,
                GateIo.SpotApi.SharedClient,
                HTX.SpotApi.SharedClient,
                Kraken.SpotApi.SharedClient,
                Kucoin.SpotApi.SharedClient,
                Mexc.SpotApi.SharedClient,
                OKX.UnifiedApi.SharedClient
            };
            _sharedClients[ApiType.PerpetualLinear] = new ISharedClient[]
            {
                Binance.UsdFuturesApi.SharedClient,
                BingX.PerpetualFuturesApi.SharedClient,
                Bitget.FuturesApiV2.SharedClient,
                BitMart.UsdFuturesApi.SharedClient,
                Bybit.V5LinearApi.SharedClient,
                CoinEx.FuturesApi.SharedClient,
                GateIo.PerpetualFuturesApi.SharedClient,
                HTX.UsdtFuturesApi.SharedClient,
                Kucoin.FuturesApi.SharedClient,
                OKX.UnifiedApi.SharedClient
            };
            _sharedClients[ApiType.DeliveryLinear] = new ISharedClient[]
            {
                Binance.UsdFuturesApi.SharedClient,
                Bitget.FuturesApiV2.SharedClient,
                BitMart.UsdFuturesApi.SharedClient,
                Bybit.V5LinearApi.SharedClient,
                HTX.UsdtFuturesApi.SharedClient,
                Kucoin.FuturesApi.SharedClient,
                OKX.UnifiedApi.SharedClient
            };
            _sharedClients[ApiType.PerpetualInverse] = new ISharedClient[]
            {
                Binance.CoinFuturesApi.SharedClient,
                BingX.PerpetualFuturesApi.SharedClient,
                Bitget.FuturesApiV2.SharedClient,
                Bybit.V5InverseApi.SharedClient,
                CoinEx.FuturesApi.SharedClient,
                GateIo.PerpetualFuturesApi.SharedClient,
                Kucoin.FuturesApi.SharedClient,
                OKX.UnifiedApi.SharedClient
            };
            _sharedClients[ApiType.DeliveryInverse] = new ISharedClient[]
            {
                Binance.CoinFuturesApi.SharedClient,
                Bitget.FuturesApiV2.SharedClient,
                Bybit.V5InverseApi.SharedClient,
                Kucoin.FuturesApi.SharedClient,
                OKX.UnifiedApi.SharedClient
            };
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToAllTickerUpdatesAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedSpotTicker>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToAllTickerUpdatesInt(apiType, handler, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToAllTickerUpdatesAsyncEnumerable(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedSpotTicker>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToAllTickerUpdatesInt(apiType, handler, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToAllTickerUpdatesInt(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedSpotTicker>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetTickersClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToAllTickersUpdatesAsync(apiType, handler, exchangeParameters, ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToTickerUpdatesAsync(ApiType apiType, SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToTickerUpdatesInt(apiType, request, handler, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToTickerUpdatesAsyncEnumerable(ApiType apiType, SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToTickerUpdatesInt(apiType, request, handler, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToTickerUpdatesInt(ApiType apiType, SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetTickerClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = apiType;
            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToTickerUpdatesAsync(request, handler, exchangeParameters, ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToTradeUpdatesAsync(ApiType apiType, SubscribeTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToTradeUpdatesInt(apiType, request, handler, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToTradeUpdatesAsyncEnumerable(ApiType apiType, SubscribeTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToTradeUpdatesInt(apiType, request, handler, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToTradeUpdatesInt(ApiType apiType, SubscribeTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetTradeClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = apiType;
            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToTradeUpdatesAsync(request, handler, exchangeParameters, ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToBookTickerUpdatesAsync(ApiType apiType, SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToBookTickerUpdatesInt(apiType, request, handler, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsyncEnumerable(ApiType apiType, SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToBookTickerUpdatesInt(apiType, request, handler, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToBookTickerUpdatesInt(ApiType apiType, SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetBookTickerClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = apiType;
            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToBookTickerUpdatesAsync(request, handler, exchangeParameters, ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToKlineUpdatesAsync(ApiType apiType, SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToKlineUpdatesInt(apiType, request, handler, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToKlineUpdatesAsyncEnumerable(ApiType apiType, SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToKlineUpdatesInt(apiType, request, handler, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToKlineUpdatesInt(ApiType apiType, SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetKlineClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = apiType;
            var tasks = clients.Select(x => Task.Run(async () =>
            {

                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToKlineUpdatesAsync(request, handler, exchangeParameters, ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToOrderBookUpdatesAsync(ApiType apiType, SubscribeOrderBookRequest request, Action<ExchangeEvent<SharedOrderBook>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToOrderBookUpdatesInt(apiType, request, handler, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsyncEnumerable(ApiType apiType, SubscribeOrderBookRequest request, Action<ExchangeEvent<SharedOrderBook>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToOrderBookUpdatesInt(apiType, request, handler, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToOrderBookUpdatesInt(ApiType apiType, SubscribeOrderBookRequest request, Action<ExchangeEvent<SharedOrderBook>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetOrderBookClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = apiType;
            var tasks = clients.Select(x => Task.Run(async () =>
            {

                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToOrderBookUpdatesAsync(request, handler, exchangeParameters, ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToBalanceUpdatesAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToBalanceUpdatesInt(apiType, handler, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsyncEnumerable(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToBalanceUpdatesInt(apiType, handler, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToBalanceUpdatesInt(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetBalanceClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToBalanceUpdatesAsync(apiType, handler, exchangeParameters, ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToSpotOrderUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToSpotOrderUpdatesInt(handler, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToSpotOrderUpdatesAsyncEnumerable(Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToSpotOrderUpdatesInt(handler, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToSpotOrderUpdatesInt(Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToSpotOrderUpdatesAsync(handler, exchangeParameters, ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToFuturesOrderUpdatesAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedFuturesOrder>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToFuturesOrderUpdatesInt(apiType, handler, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToFuturesOrderUpdatesAsyncEnumerable(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedFuturesOrder>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToFuturesOrderUpdatesInt(apiType, handler, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToFuturesOrderUpdatesInt(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedFuturesOrder>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetFuturesOrderClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {

                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToFuturesOrderUpdatesAsync(apiType, handler, exchangeParameters, ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToUserTradeUpdatesAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToUserTradeUpdatesInt(apiType, handler, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsyncEnumerable(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToUserTradeUpdatesInt(apiType, handler, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToUserTradeUpdatesInt(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetUserTradeClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToUserTradeUpdatesAsync(apiType, handler, exchangeParameters, ct));
            }));
            return tasks;
        }

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
                CoinEx.UnsubscribeAllAsync(),
                GateIo.UnsubscribeAllAsync(),
                HTX.UnsubscribeAllAsync(),
                Kraken.UnsubscribeAllAsync(),
                Kucoin.UnsubscribeAllAsync(),
                Mexc.UnsubscribeAllAsync(),
                OKX.UnsubscribeAllAsync()
            };
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
