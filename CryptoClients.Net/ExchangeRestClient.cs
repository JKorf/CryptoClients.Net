﻿using Binance.Net.Clients;
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
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.SharedApis.Interfaces;
using CryptoExchange.Net.SharedApis.Interfaces.Rest.Futures;
using CryptoExchange.Net.SharedApis.Interfaces.Rest.Spot;
using CryptoExchange.Net.SharedApis.Models;
using CryptoExchange.Net.SharedApis.Models.Rest;
using CryptoExchange.Net.SharedApis.RequestModels;
using CryptoExchange.Net.SharedApis.ResponseModels;
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
using System.Xml.Linq;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public class ExchangeRestClient : IExchangeRestClient
    {
        private IEnumerable<ISpotClient> _spotClients = Array.Empty<ISpotClient>();
        private Dictionary<ApiType, ISharedClient[]> _sharedClients = new Dictionary<ApiType, ISharedClient[]>();

        /// <inheritdoc />
        public IBinanceRestClient Binance { get; }
        /// <inheritdoc />
        public IBingXRestClient BingX { get; }
        /// <inheritdoc />
        public IBitfinexRestClient Bitfinex { get; }
        /// <inheritdoc />
        public IBitgetRestClient Bitget { get; }
        /// <inheritdoc />
        public IBitMartRestClient BitMart { get; }
        /// <inheritdoc />
        public IBybitRestClient Bybit { get; }
        /// <inheritdoc />
        public ICoinExRestClient CoinEx { get; }
        /// <inheritdoc />
        public IGateIoRestClient GateIo { get; }
        /// <inheritdoc />
        public IHTXRestClient HTX { get; }
        /// <inheritdoc />
        public IKrakenRestClient Kraken { get; }
        /// <inheritdoc />
        public IKucoinRestClient Kucoin { get; }
        /// <inheritdoc />
        public IMexcRestClient Mexc { get; }
        /// <inheritdoc />
        public IOKXRestClient OKX { get; }


        /// <inheritdoc />
        public IEnumerable<IAssetsRestClient> GetAssetClients() => _sharedClients[ApiType.Spot].OfType<IAssetsRestClient>();
        /// <inheritdoc />
        public IAssetsRestClient AssetClient(string exchange) => GetAssetClients().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IBalanceRestClient> GetBalanceClients(ApiType api) => _sharedClients[api].OfType<IBalanceRestClient>();
        /// <inheritdoc />
        public IBalanceRestClient BalanceClient(ApiType api, string exchange) => GetBalanceClients(api).Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IDepositRestClient> GetDepositClients() => _sharedClients[ApiType.Spot].OfType<IDepositRestClient>();
        /// <inheritdoc />
        public IDepositRestClient DepositClient(string exchange) => GetDepositClients().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IKlineRestClient> GetKlineClients(ApiType api) => _sharedClients[api].OfType<IKlineRestClient>();
        /// <inheritdoc />
        public IKlineRestClient KlineClient(ApiType api, string exchange) => _sharedClients[api].OfType<IKlineRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IOrderBookRestClient> GetOrderBookClients(ApiType api) => _sharedClients[api].OfType<IOrderBookRestClient>();
        /// <inheritdoc />
        public IOrderBookRestClient OrderBookClient(ApiType api, string exchange) => _sharedClients[api].OfType<IOrderBookRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IRecentTradeRestClient> GetRecentTradesClients(ApiType api) => _sharedClients[api].OfType<IRecentTradeRestClient>();
        /// <inheritdoc />
        public IRecentTradeRestClient RecentTradesClient(ApiType api, string exchange) => _sharedClients[api].OfType<IRecentTradeRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ITradeHistoryRestClient> GetTradeHistoryClients(ApiType api) => _sharedClients[api].OfType<ITradeHistoryRestClient>();
        /// <inheritdoc />
        public ITradeHistoryRestClient TradeHistoryClient(ApiType api, string exchange) => _sharedClients[api].OfType<ITradeHistoryRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IWithdrawalRestClient> GetWithdrawalClients() => _sharedClients[ApiType.Spot].OfType<IWithdrawalRestClient>();
        /// <inheritdoc />
        public IWithdrawalRestClient WithdrawalClient(string exchange) => _sharedClients[ApiType.Spot].OfType<IWithdrawalRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IWithdrawRestClient> GetWithdrawClients() => _sharedClients[ApiType.Spot].OfType<IWithdrawRestClient>();
        /// <inheritdoc />
        public IWithdrawRestClient WithdrawClient(string exchange) => _sharedClients[ApiType.Spot].OfType<IWithdrawRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ISpotOrderRestClient> GetSpotOrderClients() => _sharedClients[ApiType.Spot].OfType<ISpotOrderRestClient>();
        /// <inheritdoc />
        public ISpotOrderRestClient SpotOrderClient(string exchange) => GetSpotOrderClients().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ISpotSymbolRestClient> GetSpotSymbolClients() => _sharedClients[ApiType.Spot].OfType<ISpotSymbolRestClient>();
        /// <inheritdoc />
        public ISpotSymbolRestClient SpotSymbolClient(string exchange) => GetSpotSymbolClients().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ISpotTickerRestClient> GetSpotTickerClients() => _sharedClients[ApiType.Spot].OfType<ISpotTickerRestClient>();
        /// <inheritdoc />
        public ISpotTickerRestClient SpotTickerClient(string exchange) => _sharedClients[ApiType.Spot].OfType<ISpotTickerRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFundingRateRestClient> GetFundingRateClients(ApiType api) => _sharedClients[api].OfType<IFundingRateRestClient>();
        /// <inheritdoc />
        public IFundingRateRestClient FundingRateClient(ApiType api, string exchange) => _sharedClients[api].OfType<IFundingRateRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFuturesOrderRestClient> GetFuturesOrderClients(ApiType api) => _sharedClients[api].OfType<IFuturesOrderRestClient>();
        /// <inheritdoc />
        public IFuturesOrderRestClient FuturesOrderClient(ApiType api, string exchange) => _sharedClients[api].OfType<IFuturesOrderRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFuturesSymbolRestClient> GetFuturesSymbolClients(ApiType api) => _sharedClients[api].OfType<IFuturesSymbolRestClient>();
        /// <inheritdoc />
        public IFuturesSymbolRestClient FuturesSymbolClient(ApiType api, string exchange) => _sharedClients[api].OfType<IFuturesSymbolRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFuturesTickerRestClient> GetFuturesTickerClients(ApiType api) => _sharedClients[api].OfType<IFuturesTickerRestClient>();
        /// <inheritdoc />
        public IFuturesTickerRestClient FuturesTickerClient(ApiType api, string exchange) => _sharedClients[api].OfType<IFuturesTickerRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IIndexPriceKlineRestClient> GetIndexPriceKlineClients(ApiType api) => _sharedClients[api].OfType<IIndexPriceKlineRestClient>();
        /// <inheritdoc />
        public IIndexPriceKlineRestClient IndexPriceKlineClient(ApiType api, string exchange) => _sharedClients[api].OfType<IIndexPriceKlineRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ILeverageRestClient> GetLeverageClients(ApiType api) => _sharedClients[api].OfType<ILeverageRestClient>();
        /// <inheritdoc />
        public ILeverageRestClient LeverageClient(ApiType api, string exchange) => _sharedClients[api].OfType<ILeverageRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IMarkPriceKlineRestClient> GetMarkPriceKlineClients(ApiType api) => _sharedClients[api].OfType<IMarkPriceKlineRestClient>();
        /// <inheritdoc />
        public IMarkPriceKlineRestClient MarkPriceKlineClient(ApiType api, string exchange) => _sharedClients[api].OfType<IMarkPriceKlineRestClient>().Single(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IOpenInterestRestClient> GetOpenInterestClients(ApiType api) => _sharedClients[api].OfType<IOpenInterestRestClient>();
        /// <inheritdoc />
        public IOpenInterestRestClient OpenInterestClient(ApiType api, string exchange) => _sharedClients[api].OfType<IOpenInterestRestClient>().Single(s => s.Exchange == exchange);

        /// <summary>
        /// Create a new ExchangeRestClient instance. Client instances will be created with default options.
        /// </summary>
        public ExchangeRestClient()
        {
            Binance = new BinanceRestClient();
            BingX = new BingXRestClient();
            Bitfinex = new BitfinexRestClient();
            Bitget = new BitgetRestClient();
            BitMart = new BitMartRestClient();
            Bybit = new BybitRestClient();
            CoinEx = new CoinExRestClient();
            GateIo = new GateIoRestClient();
            HTX = new HTXRestClient();
            Kraken = new KrakenRestClient();
            Kucoin = new KucoinRestClient();
            Mexc = new MexcRestClient();
            OKX = new OKXRestClient();

            InitSpotClients();
            InitSharedClients();
        }

        /// <summary>
        /// Create a new ExchangeRestClient instance
        /// </summary>
        public ExchangeRestClient(
            Action<GlobalExchangeOptions>? globalOptions = null,
            Action<BinanceRestOptions>? binanceRestOptions = null,
            Action<BingXRestOptions>? bingxRestOptions = null,
            Action<BitfinexRestOptions>? bitfinexRestOptions = null,
            Action<BitgetRestOptions>? bitgetRestOptions = null,
            Action<BitMartRestOptions>? bitMartRestOptions = null,
            Action<BybitRestOptions>? bybitRestOptions = null,
            Action<CoinExRestOptions>? coinExRestOptions = null,
            Action<GateIoRestOptions>? gateIoRestOptions = null,
            Action<HTXRestOptions>? htxRestOptions = null,
            Action<KrakenRestOptions>? krakenRestOptions = null,
            Action<KucoinRestOptions>? kucoinRestOptions = null,
            Action<MexcRestOptions>? mexcRestOptions = null,
            Action<OKXRestOptions>? okxRestOptions = null)
        {
            Action<TOptions> SetGlobalRestOptions<TOptions, TCredentials>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TCredentials? credentials) where TOptions : RestExchangeOptions where TCredentials : ApiCredentials
            {
                var restDelegate = (TOptions restOptions) =>
                {
                    restOptions.Proxy = globalOptions.Proxy;
                    restOptions.ApiCredentials = credentials;
                    restOptions.OutputOriginalData = globalOptions.OutputOriginalData;
                    restOptions.RequestTimeout = globalOptions.RequestTimeout;
                    restOptions.RateLimiterEnabled = globalOptions.RateLimiterEnabled;
                    restOptions.RateLimitingBehaviour = globalOptions.RateLimitingBehaviour;
                    restOptions.CachingEnabled = globalOptions.CachingEnabled;
                    exchangeDelegate?.Invoke(restOptions);
                };

                return restDelegate;
            }

            if (globalOptions != null)
            {
                var global = GlobalExchangeOptions.Default;
                globalOptions.Invoke(global);

                ExchangeCredentials? credentials = global.ApiCredentials;
                binanceRestOptions = SetGlobalRestOptions(global, binanceRestOptions, credentials?.Binance);
                bingxRestOptions = SetGlobalRestOptions(global, bingxRestOptions, credentials?.BingX);
                bitfinexRestOptions = SetGlobalRestOptions(global, bitfinexRestOptions, credentials?.Bitfinex);
                bitgetRestOptions = SetGlobalRestOptions(global, bitgetRestOptions, credentials?.Bitget);
                bitMartRestOptions = SetGlobalRestOptions(global, bitMartRestOptions, credentials?.BitMart);
                bybitRestOptions = SetGlobalRestOptions(global, bybitRestOptions, credentials?.Bybit);
                coinExRestOptions = SetGlobalRestOptions(global, coinExRestOptions, credentials?.CoinEx);
                gateIoRestOptions = SetGlobalRestOptions(global, gateIoRestOptions, credentials?.GateIo);
                htxRestOptions = SetGlobalRestOptions(global, htxRestOptions, credentials?.HTX);
                krakenRestOptions = SetGlobalRestOptions(global, krakenRestOptions, credentials?.Kraken);
                kucoinRestOptions = SetGlobalRestOptions(global, kucoinRestOptions, credentials?.Kucoin);
                mexcRestOptions = SetGlobalRestOptions(global, mexcRestOptions, credentials?.Mexc);
                okxRestOptions = SetGlobalRestOptions(global, okxRestOptions, credentials?.OKX);
            }

            Binance = new BinanceRestClient(binanceRestOptions);
            BingX = new BingXRestClient(bingxRestOptions);
            Bitfinex = new BitfinexRestClient(bitfinexRestOptions);
            Bitget = new BitgetRestClient(bitgetRestOptions);
            BitMart = new BitMartRestClient(bitMartRestOptions);
            Bybit = new BybitRestClient(bybitRestOptions);
            CoinEx = new CoinExRestClient(coinExRestOptions);
            GateIo = new GateIoRestClient(gateIoRestOptions);
            HTX = new HTXRestClient(htxRestOptions);
            Kraken = new KrakenRestClient(krakenRestOptions);
            Kucoin = new KucoinRestClient(kucoinRestOptions);
            Mexc = new MexcRestClient(mexcRestOptions);
            OKX = new OKXRestClient(okxRestOptions);

            InitSpotClients();
            InitSharedClients();
        }

        private void InitSpotClients()
        {
            _spotClients = new[]
            {
                Binance.SpotApi.CommonSpotClient,
                BingX.SpotApi.CommonSpotClient,
                Bitfinex.SpotApi.CommonSpotClient,
                Bitget.SpotApi.CommonSpotClient,
                BitMart.SpotApi.CommonSpotClient,
                Bybit.V5Api.CommonSpotClient,
                CoinEx.SpotApiV2.CommonSpotClient,
                GateIo.SpotApi.CommonSpotClient,
                HTX.SpotApi.CommonSpotClient,
                Kraken.SpotApi.CommonSpotClient,
                Kucoin.SpotApi.CommonSpotClient,
                Mexc.SpotApi.CommonSpotClient,
                OKX.UnifiedApi.CommonSpotClient,
            };
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
                Bybit.V5Api.SharedClient,
                CoinEx.SpotApiV2.SharedClient,
                GateIo.SpotApi.SharedClient,
                HTX.SpotApi.SharedClient,
                Kraken.SpotApi.SharedClient,
                Kucoin.SpotApi.SharedClient,
                Mexc.SpotApi.SharedClient,
                OKX.UnifiedApi.SharedClient
            };
            _sharedClients[ApiType.LinearFutures] = new ISharedClient[]
            {
                Binance.UsdFuturesApi.SharedClient,
                BingX.PerpetualFuturesApi.SharedClient,
                Bitget.FuturesApiV2.SharedClient,
                BitMart.UsdFuturesApi.SharedClient,
                Bybit.V5Api.SharedClient,
                CoinEx.FuturesApi.SharedClient,
                GateIo.PerpetualFuturesApi.SharedClient,
                HTX.UsdtFuturesApi.SharedClient,
                Kraken.FuturesApi.SharedClient,
                Kucoin.FuturesApi.SharedClient,
                OKX.UnifiedApi.SharedClient
            };
            _sharedClients[ApiType.InverseFutures] = new ISharedClient[]
            {
                Binance.CoinFuturesApi.SharedClient,
                BingX.PerpetualFuturesApi.SharedClient,
                Bitget.FuturesApiV2.SharedClient,
                Bybit.V5Api.SharedClient,
                GateIo.PerpetualFuturesApi.SharedClient,
                Kucoin.FuturesApi.SharedClient,
                OKX.UnifiedApi.SharedClient
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
            IBitMartRestClient bitMart,
            IBybitRestClient bybit,
            ICoinExRestClient coinEx,
            IGateIoRestClient gateIo,
            IHTXRestClient htx,
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

        /// <inheritdoc />
        public ISpotClient GetUnifiedSpotClient(string name)
        {
            return _spotClients.Single(s => s.ExchangeName == name);
        }

        /// <inheritdoc />
        public IEnumerable<ISpotClient> GetUnifiedSpotClients()
        {
            return _spotClients.ToList();
        }

        #region Get Spot Tickers

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotTicker>>>> GetSpotTickersAsync(GetTickerRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotTickersInt(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotTicker>>> GetSpotTickersAsyncEnumerable(GetTickerRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotTickersInt(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedSpotTicker>>>> GetSpotTickersInt(GetTickerRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotTickerClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetSpotTickersAsync(exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Ticker

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedSpotTicker>>> GetSpotTickerAsync(GetTickerRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotTickerInt(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedSpotTicker>> GetSpotTickerAsyncEnumerable(GetTickerRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotTickerInt(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedSpotTicker>>> GetSpotTickerInt(GetTickerRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotTickerClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = ApiType.Spot;
            var tasks = clients.Select(x => x.GetSpotTickerAsync(request, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Symbols

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotSymbol>>>> GetSpotSymbolsAsync(ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotSymbolsInt(exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotSymbol>>> GetSpotSymbolsAsyncEnumerable(ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotSymbolsInt(exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedSpotSymbol>>>> GetSpotSymbolsInt(ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotSymbolClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetSpotSymbolsAsync(exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Place Spot Order

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedId>>> PlaceSpotOrderAsync(PlaceSpotOrderRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(PlaceSpotOrderInt(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedId>> PlaceSpotOrderAsyncEnumerable(PlaceSpotOrderRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return PlaceSpotOrderInt(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedId>>> PlaceSpotOrderInt(PlaceSpotOrderRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = ApiType.Spot;
            var tasks = clients.Select(x => x.PlaceSpotOrderAsync(request, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Open Orders

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>>> GetSpotOpenOrdersAsync(GetOpenOrdersRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotOpenOrdersInt(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> GetSpotOpenOrdersAsyncEnumerable(GetOpenOrdersRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotOpenOrdersInt(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedSpotOrder>>>> GetSpotOpenOrdersInt(GetOpenOrdersRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = ApiType.Spot;
            var tasks = clients.Select(x => x.GetOpenSpotOrdersAsync(request, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Closed Orders

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>>> GetSpotClosedOrdersAsync(GetClosedOrdersRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotClosedOrdersInt(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> GetSpotClosedOrdersAsyncEnumerable(GetClosedOrdersRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotClosedOrdersInt(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedSpotOrder>>>> GetSpotClosedOrdersInt(GetClosedOrdersRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = ApiType.Spot;
            var tasks = clients.Select(x => x.GetClosedSpotOrdersAsync(request, null, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Spot User Trades

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedUserTrade>>>> GetSpotUserTradesAsync(GetUserTradesRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotUserTradesInt(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedUserTrade>>> GetSpotUserTradesAsyncEnumerable(GetUserTradesRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotUserTradesInt(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedUserTrade>>>> GetSpotUserTradesInt(GetUserTradesRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType = ApiType.Spot;
            var tasks = clients.Select(x => x.GetSpotUserTradesAsync(request, null, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Tickers

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesTicker>>>> GetFuturesTickersAsync(ApiType? apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesTickersInt(apiType, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesTicker>>> GetFuturesTickersAsyncEnumerable(ApiType? apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesTickersInt(apiType, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedFuturesTicker>>>> GetFuturesTickersInt(ApiType? apiType, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesTickerClients(apiType ?? ApiType.LinearFutures);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetFuturesTickersAsync(apiType, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Ticker

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedFuturesTicker>>> GetFuturesTickerAsync(GetTickerRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesTickerInt(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesTicker>> GetFuturesTickerAsyncEnumerable(GetTickerRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesTickerInt(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesTicker>>> GetFuturesTickerInt(GetTickerRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesTickerClients(request.ApiType ?? ApiType.LinearFutures);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType ??= ApiType.LinearFutures;
            var tasks = clients.Select(x => x.GetFuturesTickerAsync(request, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Klines
        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedKline>>>> GetKlinesAsync(GetKlinesRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetKlinesIntAsync(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedKline>>> GetKlinesAsyncEnumerable(GetKlinesRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetKlinesIntAsync(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedKline>>>> GetKlinesIntAsync(GetKlinesRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetKlineClients(request.ApiType ?? ApiType.Spot);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType ??= ApiType.Spot;
            var tasks = clients.Select(x => x.GetKlinesAsync(request, null, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Mark Price Klines
        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedMarkKline>>>> GetMarkPriceKlinesAsync(GetKlinesRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetMarkPriceKlinesIntAsync(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedMarkKline>>> GetMarkPriceKlinesAsyncEnumerable(GetKlinesRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetMarkPriceKlinesIntAsync(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedMarkKline>>>> GetMarkPriceKlinesIntAsync(GetKlinesRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetMarkPriceKlineClients(request.ApiType ?? ApiType.LinearFutures);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType ??= ApiType.LinearFutures;
            var tasks = clients.Select(x => x.GetMarkPriceKlinesAsync(request, null, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Index Price Klines
        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedMarkKline>>>> GetIndexPriceKlinesAsync(GetKlinesRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetIndexPriceKlinesIntAsync(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedMarkKline>>> GetIndexPriceKlinesAsyncEnumerable(GetKlinesRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetIndexPriceKlinesIntAsync(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedMarkKline>>>> GetIndexPriceKlinesIntAsync(GetKlinesRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetIndexPriceKlineClients(request.ApiType ?? ApiType.LinearFutures);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType ??= ApiType.LinearFutures;
            var tasks = clients.Select(x => x.GetIndexPriceKlinesAsync(request, null, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Recent Trades

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>>> GetRecentTradesAsync(GetRecentTradesRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetRecentTradesIntAsync(request, exchangeParameters, exchanges, nextPageTokens, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>> GetRecentTradesAsyncEnumerable(GetRecentTradesRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default)
        {
            return GetRecentTradesIntAsync(request, exchangeParameters, exchanges, nextPageTokens, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedTrade>>>> GetRecentTradesIntAsync(GetRecentTradesRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, IEnumerable<INextPageToken>? nextPageTokens, CancellationToken ct)
        {
            var clients = GetRecentTradesClients(request.ApiType ?? ApiType.Spot);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType ??= ApiType.Spot;
            var tasks = clients.Select(x => x.GetRecentTradesAsync(request, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Trade History

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>>> GetTradeHistoryAsync(GetTradeHistoryRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetTradeHistoryInt(request, exchangeParameters, exchanges, nextPageTokens, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>> GetTradeHistoryAsyncEnumerable(GetTradeHistoryRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default)
        {
            return GetTradeHistoryInt(request, exchangeParameters, exchanges, nextPageTokens, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedTrade>>>> GetTradeHistoryInt(GetTradeHistoryRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, IEnumerable<INextPageToken>? nextPageTokens, CancellationToken ct)
        {
            var clients = GetTradeHistoryClients(request.ApiType ?? ApiType.Spot);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType ??= ApiType.Spot;
            var tasks = clients.Select(x => x.GetTradeHistoryAsync(request, null, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Order Book

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedOrderBook>>> GetOrderBookAsync(GetOrderBookRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetOrderBookInt(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedOrderBook>> GetOrderBookAsyncEnumerable(GetOrderBookRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetOrderBookInt(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedOrderBook>>> GetOrderBookInt(GetOrderBookRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetOrderBookClients(request.ApiType ?? ApiType.Spot);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType ??= ApiType.Spot;
            var tasks = clients.Select(x => x.GetOrderBookAsync(request, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Assets

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedAsset>>>> GetAssetsAsync(ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetAssetsIntAsync(exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedAsset>>> GetAssetsAsyncEnumerable(ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetAssetsIntAsync(exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedAsset>>>> GetAssetsIntAsync(ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetAssetClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetAssetsAsync(exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Asset

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedAsset>>> GetAssetAsync(GetAssetRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetAssetIntAsync(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedAsset>> GetAssetAsyncEnumerable(GetAssetRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetAssetIntAsync(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedAsset>>> GetAssetIntAsync(GetAssetRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetAssetClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetAssetAsync(request, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Balances

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedBalance>>>> GetBalancesAsync(ApiType apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetBalancesIntAsync(apiType, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedBalance>>> GetBalancesAsyncEnumerable(ApiType apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetBalancesIntAsync(apiType, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedBalance>>>> GetBalancesIntAsync(ApiType apiType, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetBalanceClients(apiType);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetBalancesAsync(apiType, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Deposits

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedDeposit>>>> GetDepositsAsync(GetDepositsRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetDepositsInt(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedDeposit>>> GetDepositsAsyncEnumerable(GetDepositsRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetDepositsInt(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedDeposit>>>> GetDepositsInt(GetDepositsRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetDepositClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetDepositsAsync(request, null, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Withdrawals

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedWithdrawal>>>> GetWithdrawalsAsync(GetWithdrawalsRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetWithdrawalsInt(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedWithdrawal>>> GetWithdrawalsAsyncEnumerable(GetWithdrawalsRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetWithdrawalsInt(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedWithdrawal>>>> GetWithdrawalsInt(GetWithdrawalsRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetWithdrawalClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetWithdrawalsAsync(request, null, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Funding Rate History

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFundingRate>>>> GetFundingRateHistoryAsync(GetFundingRateHistoryRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFundingRateHistoryInt(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFundingRate>>> GetFundingRateHistoryAsyncEnumerable(GetFundingRateHistoryRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFundingRateHistoryInt(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedFundingRate>>>> GetFundingRateHistoryInt(GetFundingRateHistoryRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFundingRateClients(request.ApiType ?? ApiType.LinearFutures);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType ??= ApiType.LinearFutures;
            var tasks = clients.Select(x => x.GetFundingRateHistoryAsync(request, null, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Open Interest

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedOpenInterest>>> GetOpenInterestAsync(GetOpenInterestRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetOpenInterestInt(request, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedOpenInterest>> GetOpenInterestAsyncEnumerable(GetOpenInterestRequest request, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetOpenInterestInt(request, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedOpenInterest>>> GetOpenInterestInt(GetOpenInterestRequest request, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetOpenInterestClients(request.ApiType ?? ApiType.LinearFutures);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            request.ApiType ??= ApiType.LinearFutures;
            var tasks = clients.Select(x => x.GetOpenInterestAsync(request, exchangeParameters, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Symbols

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesSymbol>>>> GetFuturesSymbolsAsync(ApiType? apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesSymbolsInt(apiType, exchangeParameters, exchanges, ct));
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesSymbol>>> GetFuturesSymbolsAsyncEnumerable(ApiType? apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesSymbolsInt(apiType, exchangeParameters, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<IEnumerable<SharedFuturesSymbol>>>> GetFuturesSymbolsInt(ApiType? apiType, ExchangeParameters? exchangeParameters, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesSymbolClients(apiType ?? ApiType.LinearFutures);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetFuturesSymbolsAsync(apiType, exchangeParameters, ct));
            return tasks;
        }

        #endregion
    }
}
