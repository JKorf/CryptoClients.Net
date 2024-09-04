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
        public IEnumerable<ITickerSocketClient> GetSpotTickerClients(ApiType apiType) => _sharedClients[apiType].OfType<ITickerSocketClient>();
        /// <inheritdoc />
        public ITickerSocketClient SpotTickerClient(ApiType api, string exchange) => _sharedClients[api].OfType<ITickerSocketClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ITickersSocketClient> GetSpotTickersClients(ApiType apiType) => _sharedClients[apiType].OfType<ITickersSocketClient>();
        /// <inheritdoc />
        public ITickersSocketClient TickersSpotClient(ApiType api, string exchange) => _sharedClients[api].OfType<ITickersSocketClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ITradeSocketClient> GetTradeClients(ApiType apiType) => _sharedClients[apiType].OfType<ITradeSocketClient>();
        /// <inheritdoc />
        public ITradeSocketClient TradeClient(ApiType api, string exchange) => _sharedClients[api].OfType<ITradeSocketClient>().Single(s => s.Exchange == exchange);

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
        public IEnumerable<ISpotUserTradeSocketClient> GetSpotUserTradeClients() => _sharedClients[ApiType.Spot].OfType<ISpotUserTradeSocketClient>();
        /// <inheritdoc />
        public ISpotUserTradeSocketClient SpotUserTradeClient(string exchange) => _sharedClients[ApiType.Spot].OfType<ISpotUserTradeSocketClient>().Single(s => s.Exchange == exchange);

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
                OKX.UnifiedApi.SharedClient,
            };
            _sharedClients[ApiType.LinearFutures] = new ISharedClient[]
            {
            };
            _sharedClients[ApiType.InverseFutures] = new ISharedClient[]
            {
            };
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToAllTickerUpdatesAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedSpotTicker>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToAllTickerUpdatesInt(apiType, handler, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToAllTickerUpdatesEnumerateAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedSpotTicker>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToAllTickerUpdatesInt(apiType, handler, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToAllTickerUpdatesInt(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedSpotTicker>>> handler, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetSpotTickersClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToAllTickerUpdatesAsync(apiType, y => handler(new ExchangeEvent<IEnumerable<SharedSpotTicker>>(x.Exchange, y)), ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToTickerUpdatesAsync(ApiType apiType, TickerSubscribeRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToTickerUpdatesInt(apiType, request, handler, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToTickerUpdatesEnumerateAsync(ApiType apiType, TickerSubscribeRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToTickerUpdatesInt(apiType, request, handler, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToTickerUpdatesInt(ApiType apiType, TickerSubscribeRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetSpotTickerClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = apiType;
            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToTickerUpdatesAsync(request, y => handler(new ExchangeEvent<SharedSpotTicker>(x.Exchange, y)), ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToTradeUpdatesAsync(ApiType apiType, TradeSubscribeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToTradeUpdatesInt(apiType, request, handler, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToTradeUpdatesEnumerateAsync(ApiType apiType, TradeSubscribeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToTradeUpdatesInt(apiType, request, handler, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToTradeUpdatesInt(ApiType apiType, TradeSubscribeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetTradeClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = apiType;
            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToTradeUpdatesAsync(request, y => handler(new ExchangeEvent<IEnumerable<SharedTrade>>(x.Exchange, y)), ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToBookTickerUpdatesAsync(ApiType apiType, BookTickerSubscribeRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToBookTickerUpdatesInt(apiType, request, handler, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToBookTickerUpdatesEnumerateAsync(ApiType apiType, BookTickerSubscribeRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToBookTickerUpdatesInt(apiType, request, handler, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToBookTickerUpdatesInt(ApiType apiType, BookTickerSubscribeRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetBookTickerClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = apiType;
            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToBookTickerUpdatesAsync(request, y => handler(new ExchangeEvent<SharedBookTicker>(x.Exchange, y)), ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToBalanceUpdatesAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToBalanceUpdatesInt(apiType, handler, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToBalanceUpdatesEnumerateAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToBalanceUpdatesInt(apiType, handler, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToBalanceUpdatesInt(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetBalanceClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToBalanceUpdatesAsync(apiType, y => handler(new ExchangeEvent<IEnumerable<SharedBalance>>(x.Exchange, y)), ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToSpotOrderUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToSpotOrderUpdatesInt(handler, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToSpotOrderUpdatesEnumerateAsync(Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToSpotOrderUpdatesInt(handler, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToSpotOrderUpdatesInt(Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToSpotOrderUpdatesAsync(y => handler(new ExchangeEvent<IEnumerable<SharedSpotOrder>>(x.Exchange, y)), ct));
            }));
            return tasks;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToUserTradeUpdatesAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(SubscribeToUserTradeUpdatesInt(apiType, handler, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToUserTradeUpdatesEnumerateAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return SubscribeToUserTradeUpdatesInt(apiType, handler, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeResult<UpdateSubscription>>> SubscribeToUserTradeUpdatesInt(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetSpotUserTradeClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => Task.Run(async () =>
            {
                
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToUserTradeUpdatesAsync(apiType, y => handler(new ExchangeEvent<IEnumerable<SharedUserTrade>>(x.Exchange, y)), ct));
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
