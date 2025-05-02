using Binance.Net;
using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects.Options;
using BingX.Net;
using BingX.Net.Clients;
using BingX.Net.Interfaces.Clients;
using BingX.Net.Objects.Options;
using Bitfinex.Net;
using Bitfinex.Net.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitfinex.Net.Objects.Options;
using Bitget.Net;
using Bitget.Net.Clients;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using BitMart.Net;
using BitMart.Net.Clients;
using BitMart.Net.Interfaces.Clients;
using BitMart.Net.Objects.Options;
using BitMEX.Net;
using BitMEX.Net.Clients;
using BitMEX.Net.Interfaces.Clients;
using BitMEX.Net.Objects.Options;
using Bybit.Net;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using Coinbase.Net;
using Coinbase.Net.Clients;
using Coinbase.Net.Interfaces.Clients;
using Coinbase.Net.Objects.Options;
using CoinEx.Net;
using CoinEx.Net.Clients;
using CoinEx.Net.Interfaces.Clients;
using CoinEx.Net.Objects.Options;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoClients.Net.Models;
using CryptoCom.Net;
using CryptoCom.Net.Clients;
using CryptoCom.Net.Interfaces.Clients;
using CryptoCom.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.SharedApis;
using DeepCoin.Net;
using DeepCoin.Net.Clients;
using DeepCoin.Net.Interfaces.Clients;
using DeepCoin.Net.Objects.Options;
using GateIo.Net;
using GateIo.Net.Clients;
using GateIo.Net.Interfaces.Clients;
using GateIo.Net.Objects.Options;
using HTX.Net;
using HTX.Net.Clients;
using HTX.Net.Interfaces.Clients;
using HTX.Net.Objects.Options;
using HyperLiquid.Net;
using HyperLiquid.Net.Clients;
using HyperLiquid.Net.Interfaces.Clients;
using HyperLiquid.Net.Objects.Options;
using Kraken.Net;
using Kraken.Net.Clients;
using Kraken.Net.Interfaces.Clients;
using Kraken.Net.Objects.Options;
using Kucoin.Net;
using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces.Clients;
using Kucoin.Net.Objects.Options;
using Mexc.Net;
using Mexc.Net.Clients;
using Mexc.Net.Interfaces.Clients;
using Mexc.Net.Objects.Options;
using OKX.Net;
using OKX.Net.Clients;
using OKX.Net.Interfaces.Clients;
using OKX.Net.Objects.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WhiteBit.Net;
using WhiteBit.Net.Clients;
using WhiteBit.Net.Interfaces.Clients;
using WhiteBit.Net.Objects.Options;
using XT.Net;
using XT.Net.Clients;
using XT.Net.Interfaces.Clients;
using XT.Net.Objects.Options;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public class ExchangeRestClient : IExchangeRestClient
    {
        private IEnumerable<ISharedClient> _sharedClients = Array.Empty<ISharedClient>();

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
        public IBitMEXRestClient BitMEX { get; }
        /// <inheritdoc />
        public IBybitRestClient Bybit { get; }
        /// <inheritdoc />
        public ICoinbaseRestClient Coinbase { get; }
        /// <inheritdoc />
        public ICoinExRestClient CoinEx { get; }
        /// <inheritdoc />
        public ICryptoComRestClient CryptoCom { get; }
        /// <inheritdoc />
        public IDeepCoinRestClient DeepCoin { get; }
        /// <inheritdoc />
        public IGateIoRestClient GateIo { get; }
        /// <inheritdoc />
        public IHTXRestClient HTX { get; }
        /// <inheritdoc />
        public IHyperLiquidRestClient HyperLiquid { get; }
        /// <inheritdoc />
        public IKrakenRestClient Kraken { get; }
        /// <inheritdoc />
        public IKucoinRestClient Kucoin { get; }
        /// <inheritdoc />
        public IMexcRestClient Mexc { get; }
        /// <inheritdoc />
        public IOKXRestClient OKX { get; }
        /// <inheritdoc />
        public IWhiteBitRestClient WhiteBit { get; }
        /// <inheritdoc />
        public IXTRestClient XT { get; }


        /// <inheritdoc />
        public IEnumerable<IAssetsRestClient> GetAssetsClients() => _sharedClients.OfType<IAssetsRestClient>();
        /// <inheritdoc />
        public IAssetsRestClient? GetAssetClient(string exchange) => GetAssetsClients().SingleOrDefault(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IBalanceRestClient> GetBalancesClients() => _sharedClients.OfType<IBalanceRestClient>();
        /// <inheritdoc />
        public IEnumerable<IBalanceRestClient> GetBalancesClients(TradingMode api) => _sharedClients.OfType<IBalanceRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IBalanceRestClient? GetBalancesClient(TradingMode api, string exchange) => _sharedClients.OfType<IBalanceRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IDepositRestClient> GetDepositsClients() => _sharedClients.OfType<IDepositRestClient>();
        /// <inheritdoc />
        public IDepositRestClient? GetDepositsClient(string exchange) => GetDepositsClients().SingleOrDefault(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IKlineRestClient> GetKlineClients() => _sharedClients.OfType<IKlineRestClient>();
        /// <inheritdoc />
        public IEnumerable<IKlineRestClient> GetKlineClients(TradingMode api) => _sharedClients.OfType<IKlineRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IKlineRestClient? GetKlineClient(TradingMode api, string exchange) => _sharedClients.OfType<IKlineRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IOrderBookRestClient> GetOrderBookClients() => _sharedClients.OfType<IOrderBookRestClient>();
        /// <inheritdoc />
        public IEnumerable<IOrderBookRestClient> GetOrderBookClients(TradingMode api) => _sharedClients.OfType<IOrderBookRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IOrderBookRestClient? GetOrderBookClient(TradingMode api, string exchange) => _sharedClients.OfType<IOrderBookRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IRecentTradeRestClient> GetRecentTradesClients() => _sharedClients.OfType<IRecentTradeRestClient>();
        /// <inheritdoc />
        public IEnumerable<IRecentTradeRestClient> GetRecentTradesClients(TradingMode api) => _sharedClients.OfType<IRecentTradeRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IRecentTradeRestClient? GetRecentTradesClient(TradingMode api, string exchange) => _sharedClients.OfType<IRecentTradeRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ITradeHistoryRestClient> GetTradeHistoryClients() => _sharedClients.OfType<ITradeHistoryRestClient>();
        /// <inheritdoc />
        public IEnumerable<ITradeHistoryRestClient> GetTradeHistoryClients(TradingMode api) => _sharedClients.OfType<ITradeHistoryRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public ITradeHistoryRestClient? GetTradeHistoryClient(TradingMode api, string exchange) => _sharedClients.OfType<ITradeHistoryRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IWithdrawalRestClient> GetWithdrawalsClients() => _sharedClients.OfType<IWithdrawalRestClient>();
        /// <inheritdoc />
        public IWithdrawalRestClient? GetWithdrawalsClient(string exchange) => _sharedClients.OfType<IWithdrawalRestClient>().SingleOrDefault(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IWithdrawRestClient> GetWithdrawClients() => _sharedClients.OfType<IWithdrawRestClient>();
        /// <inheritdoc />
        public IWithdrawRestClient? GetWithdrawClient(string exchange) => _sharedClients.OfType<IWithdrawRestClient>().SingleOrDefault(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ISpotOrderRestClient> GetSpotOrderClients() => _sharedClients.OfType<ISpotOrderRestClient>();
        /// <inheritdoc />
        public ISpotOrderRestClient? GetSpotOrderClient(string exchange) => GetSpotOrderClients().SingleOrDefault(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ISpotOrderClientIdRestClient> GetSpotOrderClientIdClients() => _sharedClients.OfType<ISpotOrderClientIdRestClient>();
        /// <inheritdoc />
        public ISpotOrderClientIdRestClient? GetSpotOrderClientIdClient(string exchange) => GetSpotOrderClientIdClients().SingleOrDefault(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ISpotTriggerOrderRestClient> GetSpotTriggerOrderClients() => _sharedClients.OfType<ISpotTriggerOrderRestClient>();
        /// <inheritdoc />
        public ISpotTriggerOrderRestClient? GetSpotTriggerOrderClient(string exchange) => GetSpotTriggerOrderClients().SingleOrDefault(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ISpotSymbolRestClient> GetSpotSymbolClients() => _sharedClients.OfType<ISpotSymbolRestClient>();
        /// <inheritdoc />
        public ISpotSymbolRestClient? GetSpotSymbolClient(string exchange) => GetSpotSymbolClients().SingleOrDefault(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ISpotTickerRestClient> GetSpotTickerClients() => _sharedClients.OfType<ISpotTickerRestClient>();
        /// <inheritdoc />
        public ISpotTickerRestClient? GetSpotTickerClient(string exchange) => _sharedClients.OfType<ISpotTickerRestClient>().SingleOrDefault(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFundingRateRestClient> GetFundingRateClients() => _sharedClients.OfType<IFundingRateRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFundingRateRestClient> GetFundingRateClients(TradingMode api) => _sharedClients.OfType<IFundingRateRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFundingRateRestClient? GetFundingRateClient(TradingMode api, string exchange) => _sharedClients.OfType<IFundingRateRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFuturesOrderRestClient> GetFuturesOrderClients() => _sharedClients.OfType<IFuturesOrderRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesOrderRestClient> GetFuturesOrderClients(TradingMode api) => _sharedClients.OfType<IFuturesOrderRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesOrderRestClient? GetFuturesOrderClient(TradingMode api, string exchange) => _sharedClients.OfType<IFuturesOrderRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFuturesOrderClientIdRestClient> GetFuturesOrderClientIdClients() => _sharedClients.OfType<IFuturesOrderClientIdRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesOrderClientIdRestClient> GetFuturesOrderClientIdClients(TradingMode api) => _sharedClients.OfType<IFuturesOrderClientIdRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesOrderClientIdRestClient? GetFuturesOrderClientIdClient(TradingMode tradingMode, string exchange) => GetFuturesOrderClientIdClients(tradingMode).SingleOrDefault(s => s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFuturesTriggerOrderRestClient> GetFuturesTriggerOrderClients() => _sharedClients.OfType<IFuturesTriggerOrderRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesTriggerOrderRestClient> GetFuturesTriggerOrderClients(TradingMode api) => _sharedClients.OfType<IFuturesTriggerOrderRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesTriggerOrderRestClient? GetFuturesTriggerOrderClient(TradingMode api, string exchange) => _sharedClients.OfType<IFuturesTriggerOrderRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFuturesSymbolRestClient> GetFuturesSymbolClients() => _sharedClients.OfType<IFuturesSymbolRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesSymbolRestClient> GetFuturesSymbolClients(TradingMode api) => _sharedClients.OfType<IFuturesSymbolRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesSymbolRestClient? GetFuturesSymbolClient(TradingMode api, string exchange) => _sharedClients.OfType<IFuturesSymbolRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFuturesTickerRestClient> GetFuturesTickerClients() => _sharedClients.OfType<IFuturesTickerRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesTickerRestClient> GetFuturesTickerClients(TradingMode api) => _sharedClients.OfType<IFuturesTickerRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesTickerRestClient? GetFuturesTickerClient(TradingMode api, string exchange) => _sharedClients.OfType<IFuturesTickerRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IIndexPriceKlineRestClient> GetIndexPriceKlineClients() => _sharedClients.OfType<IIndexPriceKlineRestClient>();
        /// <inheritdoc />
        public IEnumerable<IIndexPriceKlineRestClient> GetIndexPriceKlineClients(TradingMode api) => _sharedClients.OfType<IIndexPriceKlineRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IIndexPriceKlineRestClient? GetIndexPriceKlineClient(TradingMode api, string exchange) => _sharedClients.OfType<IIndexPriceKlineRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<ILeverageRestClient> GetLeverageClients() => _sharedClients.OfType<ILeverageRestClient>();
        /// <inheritdoc />
        public IEnumerable<ILeverageRestClient> GetLeverageClients(TradingMode api) => _sharedClients.OfType<ILeverageRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public ILeverageRestClient? GetLeverageClient(TradingMode api, string exchange) => _sharedClients.OfType<ILeverageRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IMarkPriceKlineRestClient> GetMarkPriceKlineClients() => _sharedClients.OfType<IMarkPriceKlineRestClient>();
        /// <inheritdoc />
        public IEnumerable<IMarkPriceKlineRestClient> GetMarkPriceKlineClients(TradingMode api) => _sharedClients.OfType<IMarkPriceKlineRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IMarkPriceKlineRestClient? GetMarkPriceKlineClient(TradingMode api, string exchange) => _sharedClients.OfType<IMarkPriceKlineRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IOpenInterestRestClient> GetOpenInterestClients() => _sharedClients.OfType<IOpenInterestRestClient>();
        /// <inheritdoc />
        public IEnumerable<IOpenInterestRestClient> GetOpenInterestClients(TradingMode api) => _sharedClients.OfType<IOpenInterestRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IOpenInterestRestClient? GetOpenInterestClient(TradingMode api, string exchange) => _sharedClients.OfType<IOpenInterestRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IPositionModeRestClient> GetPositionModeClients() => _sharedClients.OfType<IPositionModeRestClient>();
        /// <inheritdoc />
        public IEnumerable<IPositionModeRestClient> GetPositionModeClients(TradingMode api) => _sharedClients.OfType<IPositionModeRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IPositionModeRestClient? GetPositionModeClient(TradingMode api, string exchange) => _sharedClients.OfType<IPositionModeRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IPositionHistoryRestClient> GetPositionHistoryClients() => _sharedClients.OfType<IPositionHistoryRestClient>();
        /// <inheritdoc />
        public IEnumerable<IPositionHistoryRestClient> GetPositionHistoryClients(TradingMode api) => _sharedClients.OfType<IPositionHistoryRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IPositionHistoryRestClient? GetPositionHistoryClient(TradingMode api, string exchange) => _sharedClients.OfType<IPositionHistoryRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IListenKeyRestClient> GetListenKeyClients() => _sharedClients.OfType<IListenKeyRestClient>();
        /// <inheritdoc />
        public IEnumerable<IListenKeyRestClient> GetListenKeyClients(TradingMode api) => _sharedClients.OfType<IListenKeyRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IListenKeyRestClient? GetListenKeyClient(TradingMode api, string exchange) => _sharedClients.OfType<IListenKeyRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFeeRestClient> GetFeeClients() => _sharedClients.OfType<IFeeRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFeeRestClient> GetFeeClients(TradingMode api) => _sharedClients.OfType<IFeeRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFeeRestClient? GetFeeClient(TradingMode api, string exchange) => _sharedClients.OfType<IFeeRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IBookTickerRestClient> GetBookTickerClients() => _sharedClients.OfType<IBookTickerRestClient>();
        /// <inheritdoc />
        public IEnumerable<IBookTickerRestClient> GetBookTickerClients(TradingMode api) => _sharedClients.OfType<IBookTickerRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IBookTickerRestClient? GetBookTickerClient(TradingMode api, string exchange) => _sharedClients.OfType<IBookTickerRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        /// <inheritdoc />
        public IEnumerable<IFuturesTpSlRestClient> GetFuturesTpSlClients() => _sharedClients.OfType<IFuturesTpSlRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesTpSlRestClient> GetFuturesTpSlClients(TradingMode api) => _sharedClients.OfType<IFuturesTpSlRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesTpSlRestClient? GetFuturesTpSlClient(TradingMode api, string exchange) => _sharedClients.OfType<IFuturesTpSlRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

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
            BitMEX = new BitMEXRestClient();
            Bybit = new BybitRestClient();
            Coinbase = new CoinbaseRestClient();
            CoinEx = new CoinExRestClient();
            CryptoCom = new CryptoComRestClient();
            DeepCoin = new DeepCoinRestClient();
            GateIo = new GateIoRestClient();
            HTX = new HTXRestClient();
            HyperLiquid = new HyperLiquidRestClient();
            Kraken = new KrakenRestClient();
            Kucoin = new KucoinRestClient();
            Mexc = new MexcRestClient();
            OKX = new OKXRestClient();
            WhiteBit = new WhiteBitRestClient();
            XT = new XTRestClient();

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
            Action<BitMEXRestOptions>? bitMEXRestOptions = null,
            Action<BybitRestOptions>? bybitRestOptions = null,
            Action<CoinbaseRestOptions>? coinbaseRestOptions = null,
            Action<CoinExRestOptions>? coinExRestOptions = null,
            Action<CryptoComRestOptions>? cryptoComRestOptions = null,
            Action<DeepCoinRestOptions>? deepCoinRestOptions = null,
            Action<GateIoRestOptions>? gateIoRestOptions = null,
            Action<HTXRestOptions>? htxRestOptions = null,
            Action<HyperLiquidRestOptions>? hyperLiquidRestOptions = null,
            Action<KrakenRestOptions>? krakenRestOptions = null,
            Action<KucoinRestOptions>? kucoinRestOptions = null,
            Action<MexcRestOptions>? mexcRestOptions = null,
            Action<OKXRestOptions>? okxRestOptions = null,
            Action<WhiteBitRestOptions>? whiteBitRestOptions = null,
            Action<XTRestOptions>? xtRestOptions = null)
        {
            Action<TOptions> SetGlobalRestOptions<TOptions, TCredentials, TEnvironment>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TCredentials? credentials, TEnvironment environment) 
                where TOptions : RestExchangeOptions<TEnvironment> 
                where TCredentials : ApiCredentials 
                where TEnvironment : TradeEnvironment
            {
                var restDelegate = (TOptions restOptions) =>
                {
                    restOptions.Proxy = globalOptions.Proxy;
                    restOptions.ApiCredentials = credentials;
                    restOptions.OutputOriginalData = globalOptions.OutputOriginalData ?? restOptions.OutputOriginalData;
                    restOptions.RequestTimeout = globalOptions.RequestTimeout ?? restOptions.RequestTimeout;
                    restOptions.RateLimiterEnabled = globalOptions.RateLimiterEnabled ?? restOptions.RateLimiterEnabled;
                    restOptions.RateLimitingBehaviour = globalOptions.RateLimitingBehaviour ?? restOptions.RateLimitingBehaviour;
                    restOptions.CachingEnabled = globalOptions.CachingEnabled ?? restOptions.CachingEnabled;
                    restOptions.Environment = environment;
                    exchangeDelegate?.Invoke(restOptions);
                };

                return restDelegate;
            }

            if (globalOptions != null)
            {
                var global = new GlobalExchangeOptions();
                globalOptions.Invoke(global);

                ExchangeCredentials? credentials = global.ApiCredentials;
                Dictionary<string, string?>? environments = global.ApiEnvironments;
                binanceRestOptions = SetGlobalRestOptions(global, binanceRestOptions, credentials?.Binance, environments?.TryGetValue(Exchange.Binance, out var binanceEnvName) == true ? BinanceEnvironment.GetEnvironmentByName(binanceEnvName)!: BinanceEnvironment.Live);
                bingxRestOptions = SetGlobalRestOptions(global, bingxRestOptions, credentials?.BingX, environments?.TryGetValue(Exchange.BingX, out var bingXEnvName) == true ? BingXEnvironment.GetEnvironmentByName(bingXEnvName)! : BingXEnvironment.Live);
                bitfinexRestOptions = SetGlobalRestOptions(global, bitfinexRestOptions, credentials?.Bitfinex, environments?.TryGetValue(Exchange.Bitfinex, out var bitfinexEnvName) == true ? BitfinexEnvironment.GetEnvironmentByName(bitfinexEnvName)! : BitfinexEnvironment.Live);
                bitgetRestOptions = SetGlobalRestOptions(global, bitgetRestOptions, credentials?.Bitget, environments?.TryGetValue(Exchange.Bitget, out var bitgetEnvName) == true ? BitgetEnvironment.GetEnvironmentByName(bitgetEnvName)! : BitgetEnvironment.Live);
                bitMartRestOptions = SetGlobalRestOptions(global, bitMartRestOptions, credentials?.BitMart, environments?.TryGetValue(Exchange.BitMart, out var bitMartEnvName) == true ? BitMartEnvironment.GetEnvironmentByName(bitMartEnvName)! : BitMartEnvironment.Live);
                bitMEXRestOptions = SetGlobalRestOptions(global, bitMEXRestOptions, credentials?.BitMEX, environments?.TryGetValue(Exchange.BitMEX, out var bitMEXEnvName) == true ? BitMEXEnvironment.GetEnvironmentByName(bitMEXEnvName)! : BitMEXEnvironment.Live);
                bybitRestOptions = SetGlobalRestOptions(global, bybitRestOptions, credentials?.Bybit, environments?.TryGetValue(Exchange.Bybit, out var bybitEnvName) == true ? BybitEnvironment.GetEnvironmentByName(bybitEnvName)! : BybitEnvironment.Live);
                coinbaseRestOptions = SetGlobalRestOptions(global, coinbaseRestOptions, credentials?.Coinbase, environments?.TryGetValue(Exchange.Coinbase, out var coinbaseEnvName) == true ? CoinbaseEnvironment.GetEnvironmentByName(coinbaseEnvName)! : CoinbaseEnvironment.Live);
                coinExRestOptions = SetGlobalRestOptions(global, coinExRestOptions, credentials?.CoinEx, environments?.TryGetValue(Exchange.CoinEx, out var coinExEnvName) == true ? CoinExEnvironment.GetEnvironmentByName(coinExEnvName)! : CoinExEnvironment.Live);
                cryptoComRestOptions = SetGlobalRestOptions(global, cryptoComRestOptions, credentials?.CryptoCom, environments?.TryGetValue(Exchange.CryptoCom, out var cryptoComEnvName) == true ? CryptoComEnvironment.GetEnvironmentByName(cryptoComEnvName)! : CryptoComEnvironment.Live);
                deepCoinRestOptions = SetGlobalRestOptions(global, deepCoinRestOptions, credentials?.DeepCoin, environments?.TryGetValue(Exchange.DeepCoin, out var deepCoinEnvName) == true ? DeepCoinEnvironment.GetEnvironmentByName(deepCoinEnvName)! : DeepCoinEnvironment.Live);
                gateIoRestOptions = SetGlobalRestOptions(global, gateIoRestOptions, credentials?.GateIo, environments?.TryGetValue(Exchange.GateIo, out var gateIoEnvName) == true ? GateIoEnvironment.GetEnvironmentByName(gateIoEnvName)! : GateIoEnvironment.Live);
                htxRestOptions = SetGlobalRestOptions(global, htxRestOptions, credentials?.HTX, environments?.TryGetValue(Exchange.HTX, out var htxEnvName) == true ? HTXEnvironment.GetEnvironmentByName(htxEnvName)! : HTXEnvironment.Live);
                hyperLiquidRestOptions = SetGlobalRestOptions(global, hyperLiquidRestOptions, credentials?.HyperLiquid, environments?.TryGetValue(Exchange.HyperLiquid, out var hyperLiquidEnvName) == true ? HyperLiquidEnvironment.GetEnvironmentByName(hyperLiquidEnvName)! : HyperLiquidEnvironment.Live);
                krakenRestOptions = SetGlobalRestOptions(global, krakenRestOptions, credentials?.Kraken, environments?.TryGetValue(Exchange.Kraken, out var krakenEnvName) == true ? KrakenEnvironment.GetEnvironmentByName(krakenEnvName)! : KrakenEnvironment.Live);
                kucoinRestOptions = SetGlobalRestOptions(global, kucoinRestOptions, credentials?.Kucoin, environments?.TryGetValue(Exchange.Kucoin, out var kucoinEnvName) == true ? KucoinEnvironment.GetEnvironmentByName(kucoinEnvName)! : KucoinEnvironment.Live);
                mexcRestOptions = SetGlobalRestOptions(global, mexcRestOptions, credentials?.Mexc, environments?.TryGetValue(Exchange.Mexc, out var mexcEnvName) == true ? MexcEnvironment.GetEnvironmentByName(mexcEnvName)! : MexcEnvironment.Live);
                okxRestOptions = SetGlobalRestOptions(global, okxRestOptions, credentials?.OKX, environments?.TryGetValue(Exchange.OKX, out var okxEnvName) == true ? OKXEnvironment.GetEnvironmentByName(okxEnvName)! : OKXEnvironment.Live);
                whiteBitRestOptions = SetGlobalRestOptions(global, whiteBitRestOptions, credentials?.WhiteBit, environments?.TryGetValue(Exchange.WhiteBit, out var whiteBitEnvName) == true ? WhiteBitEnvironment.GetEnvironmentByName(whiteBitEnvName)! : WhiteBitEnvironment.Live);
                xtRestOptions = SetGlobalRestOptions(global, xtRestOptions, credentials?.XT, environments?.TryGetValue(Exchange.XT, out var xtEnvName) == true ? XTEnvironment.GetEnvironmentByName(xtEnvName)! : XTEnvironment.Live);
            }

            Binance = new BinanceRestClient(binanceRestOptions);
            BingX = new BingXRestClient(bingxRestOptions);
            Bitfinex = new BitfinexRestClient(bitfinexRestOptions);
            Bitget = new BitgetRestClient(bitgetRestOptions);
            BitMart = new BitMartRestClient(bitMartRestOptions);
            BitMEX = new BitMEXRestClient(bitMEXRestOptions);
            Bybit = new BybitRestClient(bybitRestOptions);
            Coinbase = new CoinbaseRestClient(coinbaseRestOptions);
            CoinEx = new CoinExRestClient(coinExRestOptions);
            CryptoCom = new CryptoComRestClient(cryptoComRestOptions);
            DeepCoin = new DeepCoinRestClient(deepCoinRestOptions);
            GateIo = new GateIoRestClient(gateIoRestOptions);
            HTX = new HTXRestClient(htxRestOptions);
            HyperLiquid = new HyperLiquidRestClient(hyperLiquidRestOptions);
            Kraken = new KrakenRestClient(krakenRestOptions);
            Kucoin = new KucoinRestClient(kucoinRestOptions);
            Mexc = new MexcRestClient(mexcRestOptions);
            OKX = new OKXRestClient(okxRestOptions);
            WhiteBit = new WhiteBitRestClient(whiteBitRestOptions);
            XT = new XTRestClient(xtRestOptions);

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
                BitMEX.ExchangeApi.SharedClient,
                Bybit.V5Api.SharedClient,
                Coinbase.AdvancedTradeApi.SharedClient,
                CoinEx.SpotApiV2.SharedClient,
                CoinEx.FuturesApi.SharedClient,
                CryptoCom.ExchangeApi.SharedClient,
                DeepCoin.ExchangeApi.SharedClient,
                GateIo.SpotApi.SharedClient,
                GateIo.PerpetualFuturesApi.SharedClient,
                HTX.SpotApi.SharedClient,
                HTX.UsdtFuturesApi.SharedClient,
                HyperLiquid.SpotApi.SharedClient,
                HyperLiquid.FuturesApi.SharedClient,
                Kraken.SpotApi.SharedClient,
                Kraken.FuturesApi.SharedClient,
                Kucoin.SpotApi.SharedClient,
                Kucoin.FuturesApi.SharedClient,
                Mexc.SpotApi.SharedClient,
                OKX.UnifiedApi.SharedClient,
                WhiteBit.V4Api.SharedClient,
                XT.SpotApi.SharedClient,
                XT.CoinFuturesApi.SharedClient,
                XT.UsdtFuturesApi.SharedClient
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
            IBitMEXRestClient bitMEX,
            IBybitRestClient bybit,
            ICoinbaseRestClient coinbase,
            ICoinExRestClient coinEx,
            ICryptoComRestClient cryptoCom,
            IDeepCoinRestClient deepCoin,
            IGateIoRestClient gateIo,
            IHTXRestClient htx,
            IHyperLiquidRestClient hyperLiquid,
            IKrakenRestClient kraken,
            IKucoinRestClient kucoin,
            IMexcRestClient mexc,
            IOKXRestClient okx,
            IWhiteBitRestClient whiteBit,
            IXTRestClient xt)
        {
            Binance = binance;
            BingX = bingx;
            Bitfinex = bitfinex;
            Bitget = bitget;
            BitMart = bitMart;
            BitMEX = bitMEX;
            Bybit = bybit;
            Coinbase = coinbase;
            CoinEx = coinEx;
            CryptoCom = cryptoCom;
            DeepCoin = deepCoin;
            GateIo = gateIo;
            HTX = htx;
            HyperLiquid = hyperLiquid;
            Kraken = kraken;
            Kucoin = kucoin;
            Mexc = mexc;
            OKX = okx;
            WhiteBit = whiteBit;
            XT = xt;

            InitSharedClients();
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
                case "Bitget": Bitget.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for Bitget credentials", nameof(apiPass)))); break;
                case "BitMart": BitMart.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for BitMart credentials", nameof(apiPass)))); break;
                case "BitMEX": BitMEX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Bybit": Bybit.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Coinbase": Coinbase.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "CoinEx": CoinEx.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "CryptoCom": CryptoCom.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "DeepCoin": DeepCoin.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for DeepCoin credentials", nameof(apiPass)))); break;
                case "GateIo": GateIo.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "HTX": HTX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "HyperLiquid": HyperLiquid.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Kraken": Kraken.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Kucoin": Kucoin.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for Kucoin credentials", nameof(apiPass)))); break;
                case "Mexc": Mexc.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "OKX": OKX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for OKX credentials", nameof(apiPass)))); break;
                case "WhiteBit": WhiteBit.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "XT": XT.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                default: throw new ArgumentException("Exchange not recognized", nameof(exchange));
            }
        }

        /// <inheritdoc />
        public string? GetSymbolName(string exchange, SharedSymbol symbol)
        {
            var client = _sharedClients.FirstOrDefault(x => x.Exchange == exchange && x.SupportedTradingModes.Contains(symbol.TradingMode));
            if (client == null)
                return null;

            return symbol.GetSymbol(client.FormatSymbol);
        }

        #region Get Spot Tickers
        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotTicker[]>> GetSpotTickerAsync(string exchange, GetTickersRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetSpotTickersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedSpotTicker[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotTicker[]>[]> GetSpotTickersAsync(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotTickersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedSpotTicker[]>> GetSpotTickersAsyncEnumerable(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotTickersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedSpotTicker[]>>> GetSpotTickersInt(GetTickersRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotTickerClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetSpotTickersOptions.Supported).Select(x => x.GetSpotTickersAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Ticker
        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotTicker>> GetSpotTickerAsync(string exchange, GetTickerRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetSpotTickerInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedSpotTicker>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotTicker>[]> GetSpotTickerAsync(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotTickerInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedSpotTicker>> GetSpotTickerAsyncEnumerable(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotTickerInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedSpotTicker>>> GetSpotTickerInt(GetTickerRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotTickerClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetSpotTickerOptions.Supported).Select(x => x.GetSpotTickerAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Symbols
        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotSymbol[]>> GetSpotSymbolsAsync(string exchange, GetSymbolsRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetSpotSymbolsInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedSpotSymbol[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotSymbol[]>[]> GetSpotSymbolsAsync(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotSymbolsInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedSpotSymbol[]>> GetSpotSymbolsAsyncEnumerable(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotSymbolsInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedSpotSymbol[]>>> GetSpotSymbolsInt(GetSymbolsRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotSymbolClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetSpotSymbolsOptions.Supported).Select(x => x.GetSpotSymbolsAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Open Orders

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotOrder[]>> GetSpotOpenOrdersAsync(string exchange, GetOpenOrdersRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetSpotOpenOrdersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedSpotOrder[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotOrder[]>[]> GetSpotOpenOrdersAsync(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotOpenOrdersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedSpotOrder[]>> GetSpotOpenOrdersAsyncEnumerable(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotOpenOrdersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedSpotOrder[]>>> GetSpotOpenOrdersInt(GetOpenOrdersRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetOpenSpotOrdersOptions.Supported).Select(x => x.GetOpenSpotOrdersAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Closed Orders

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotOrder[]>> GetSpotClosedOrdersAsync(string exchange, GetClosedOrdersRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetSpotClosedOrdersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedSpotOrder[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotOrder[]>[]> GetSpotClosedOrdersAsync(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotClosedOrdersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedSpotOrder[]>> GetSpotClosedOrdersAsyncEnumerable(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotClosedOrdersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedSpotOrder[]>>> GetSpotClosedOrdersInt(GetClosedOrdersRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetClosedSpotOrdersOptions.Supported).Select(x => x.GetClosedSpotOrdersAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Spot User Trades

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedUserTrade[]>> GetSpotUserTradesAsync(string exchange, GetUserTradesRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetSpotUserTradesInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedUserTrade[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedUserTrade[]>[]> GetSpotUserTradesAsync(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotUserTradesInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedUserTrade[]>> GetSpotUserTradesAsyncEnumerable(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotUserTradesInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedUserTrade[]>>> GetSpotUserTradesInt(GetUserTradesRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetSpotUserTradesOptions.Supported).Select(x => x.GetSpotUserTradesAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Tickers

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesTicker[]>> GetFuturesTickersAsync(string exchange, GetTickersRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesTickersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesTicker[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesTicker[]>[]> GetFuturesTickersAsync(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesTickersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesTicker[]>> GetFuturesTickersAsyncEnumerable(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesTickersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesTicker[]>>> GetFuturesTickersInt(GetTickersRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesTickerClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetFuturesTickersOptions.Supported).Select(x => x.GetFuturesTickersAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Ticker

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesTicker>> GetFuturesTickerAsync(string exchange, GetTickerRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesTickerInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesTicker>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesTicker>[]> GetFuturesTickerAsync(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesTickerInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesTicker>> GetFuturesTickerAsyncEnumerable(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesTickerInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesTicker>>> GetFuturesTickerInt(GetTickerRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesTickerClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetFuturesTickerOptions.Supported).Select(x => x.GetFuturesTickerAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Klines

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedKline[]>> GetKlinesAsync(string exchange, GetKlinesRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetKlinesIntAsync(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedKline[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedKline[]>[]> GetKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetKlinesIntAsync(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedKline[]>> GetKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetKlinesIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedKline[]>>> GetKlinesIntAsync(GetKlinesRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetKlineClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetKlinesOptions.Supported).Select(x => x.GetKlinesAsync(request, null, ct));
            return tasks;
        }


        #endregion

        #region Get Mark Price Klines

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesKline[]>> GetMarkPriceKlinesAsync(string exchange, GetKlinesRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetMarkPriceKlinesIntAsync(request, new[] { exchange } , ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesKline[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesKline[]>[]> GetMarkPriceKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetMarkPriceKlinesIntAsync(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesKline[]>> GetMarkPriceKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetMarkPriceKlinesIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesKline[]>>> GetMarkPriceKlinesIntAsync(GetKlinesRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetMarkPriceKlineClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetMarkPriceKlinesOptions.Supported).Select(x => x.GetMarkPriceKlinesAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Index Price Klines

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesKline[]>> GetIndexPriceKlinesAsync(string exchange, GetKlinesRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetIndexPriceKlinesIntAsync(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesKline[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesKline[]>[]> GetIndexPriceKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetIndexPriceKlinesIntAsync(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesKline[]>> GetIndexPriceKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetIndexPriceKlinesIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesKline[]>>> GetIndexPriceKlinesIntAsync(GetKlinesRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetIndexPriceKlineClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetIndexPriceKlinesOptions.Supported).Select(x => x.GetIndexPriceKlinesAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Recent Trades

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedTrade[]>> GetRecentTradesAsync(string exchange, GetRecentTradesRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetRecentTradesIntAsync(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedTrade[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedTrade[]>[]> GetRecentTradesAsync(GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetRecentTradesIntAsync(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedTrade[]>> GetRecentTradesAsyncEnumerable(GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetRecentTradesIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedTrade[]>>> GetRecentTradesIntAsync(GetRecentTradesRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetRecentTradesClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetRecentTradesOptions.Supported).Select(x => x.GetRecentTradesAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Trade History

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedTrade[]>> GetTradeHistoryAsync(string exchange, GetTradeHistoryRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetTradeHistoryInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedTrade[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedTrade[]>[]> GetTradeHistoryAsync(GetTradeHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetTradeHistoryInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedTrade[]>> GetTradeHistoryAsyncEnumerable(GetTradeHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetTradeHistoryInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedTrade[]>>> GetTradeHistoryInt(GetTradeHistoryRequest request, IEnumerable<string>? exchanges,CancellationToken ct)
        {
            var clients = GetTradeHistoryClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetTradeHistoryOptions.Supported).Select(x => x.GetTradeHistoryAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Order Book

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedOrderBook>> GetOrderBookAsync(string exchange, GetOrderBookRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetOrderBookInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedOrderBook>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedOrderBook>[]> GetOrderBookAsync(GetOrderBookRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetOrderBookInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedOrderBook>> GetOrderBookAsyncEnumerable(GetOrderBookRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetOrderBookInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedOrderBook>>> GetOrderBookInt(GetOrderBookRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetOrderBookClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetOrderBookOptions.Supported).Select(x => x.GetOrderBookAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Assets

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedAsset[]>> GetAssetsAsync(string exchange, GetAssetsRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetAssetsIntAsync(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedAsset[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedAsset[]>[]> GetAssetsAsync(GetAssetsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetAssetsIntAsync(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedAsset[]>> GetAssetsAsyncEnumerable(GetAssetsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetAssetsIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedAsset[]>>> GetAssetsIntAsync(GetAssetsRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetAssetsClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetAssetsOptions.Supported).Select(x => x.GetAssetsAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Asset

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedAsset>> GetAssetAsync(string exchange, GetAssetRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetAssetIntAsync(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedAsset>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedAsset>[]> GetAssetAsync(GetAssetRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetAssetIntAsync(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedAsset>> GetAssetAsyncEnumerable(GetAssetRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetAssetIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedAsset>>> GetAssetIntAsync(GetAssetRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetAssetsClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetAssetOptions.Supported).Select(x => x.GetAssetAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Open Orders

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesOrder[]>> GetFuturesOpenOrdersAsync(string exchange, GetOpenOrdersRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesOpenOrdersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesOrder[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesOrder[]>[]> GetFuturesOpenOrdersAsync(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesOpenOrdersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesOrder[]>> GetFuturesOpenOrdersAsyncEnumerable(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesOpenOrdersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesOrder[]>>> GetFuturesOpenOrdersInt(GetOpenOrdersRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetOpenFuturesOrdersOptions.Supported).Select(x => x.GetOpenFuturesOrdersAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Closed Orders

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesOrder[]>> GetFuturesOpenOrdersAsync(string exchange, GetClosedOrdersRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesClosedOrdersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesOrder[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesOrder[]>[]> GetFuturesClosedOrdersAsync(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesClosedOrdersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesOrder[]>> GetFuturesClosedOrdersAsyncEnumerable(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesClosedOrdersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesOrder[]>>> GetFuturesClosedOrdersInt(GetClosedOrdersRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetClosedFuturesOrdersOptions.Supported).Select(x => x.GetClosedFuturesOrdersAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Futures User Trades

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedUserTrade[]>> GetFuturesUserTradesAsync(string exchange, GetUserTradesRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesUserTradesInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedUserTrade[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedUserTrade[]>[]> GetFuturesUserTradesAsync(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesUserTradesInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedUserTrade[]>> GetFuturesUserTradesAsyncEnumerable(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesUserTradesInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedUserTrade[]>>> GetFuturesUserTradesInt(GetUserTradesRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetFuturesUserTradesOptions.Supported).Select(x => x.GetFuturesUserTradesAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Balances

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedBalance[]>> GetBalancesAsync(string exchange, GetBalancesRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetBalancesIntAsync(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedBalance[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedBalance[]>[]> GetBalancesAsync(GetBalancesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetBalancesIntAsync(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedBalance[]>> GetBalancesAsyncEnumerable(GetBalancesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetBalancesIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedBalance[]>>> GetBalancesIntAsync(GetBalancesRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetBalancesClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetBalancesOptions.Supported).Select(x => x.GetBalancesAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Deposits

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedDeposit[]>> GetDepositsAsync(string exchange, GetDepositsRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetDepositsInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedDeposit[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedDeposit[]>[]> GetDepositsAsync(GetDepositsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetDepositsInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedDeposit[]>> GetDepositsAsyncEnumerable(GetDepositsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetDepositsInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedDeposit[]>>> GetDepositsInt(GetDepositsRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetDepositsClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetDepositsOptions.Supported).Select(x => x.GetDepositsAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Withdrawals

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedWithdrawal[]>> GetWithdrawalsAsync(string exchange, GetWithdrawalsRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetWithdrawalsInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedWithdrawal[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedWithdrawal[]>[]> GetWithdrawalsAsync(GetWithdrawalsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetWithdrawalsInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedWithdrawal[]>> GetWithdrawalsAsyncEnumerable(GetWithdrawalsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetWithdrawalsInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedWithdrawal[]>>> GetWithdrawalsInt(GetWithdrawalsRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetWithdrawalsClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetWithdrawalsOptions.Supported).Select(x => x.GetWithdrawalsAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Funding Rate History

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFundingRate[]>> GetFundingRateHistoryAsync(string exchange, GetFundingRateHistoryRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFundingRateHistoryInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFundingRate[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFundingRate[]>[]> GetFundingRateHistoryAsync(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFundingRateHistoryInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFundingRate[]>> GetFundingRateHistoryAsyncEnumerable(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFundingRateHistoryInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFundingRate[]>>> GetFundingRateHistoryInt(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFundingRateClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetFundingRateHistoryOptions.Supported).Select(x => x.GetFundingRateHistoryAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Open Interest

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedOpenInterest>> GetOpenInterestAsync(string exchange, GetOpenInterestRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetOpenInterestInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedOpenInterest>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedOpenInterest>[]> GetOpenInterestAsync(GetOpenInterestRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetOpenInterestInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedOpenInterest>> GetOpenInterestAsyncEnumerable(GetOpenInterestRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetOpenInterestInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedOpenInterest>>> GetOpenInterestInt(GetOpenInterestRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetOpenInterestClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetOpenInterestOptions.Supported).Select(x => x.GetOpenInterestAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Symbols

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesSymbol[]>> GetFuturesSymbolsAsync(string exchange, GetSymbolsRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesSymbolsInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesSymbol[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesSymbol[]>[]> GetFuturesSymbolsAsync(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesSymbolsInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesSymbol[]>> GetFuturesSymbolsAsyncEnumerable(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesSymbolsInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesSymbol[]>>> GetFuturesSymbolsInt(GetSymbolsRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesSymbolClients().Where(x => request.TradingMode == null ? true: x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetFuturesSymbolsOptions.Supported).Select(x => x.GetFuturesSymbolsAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Position History

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedPositionHistory[]>> GetPositionHistoryAsync(string exchange, GetPositionHistoryRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetPositionHistoryInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedPositionHistory[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedPositionHistory[]>[]> GetPositionHistoryAsync(GetPositionHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetPositionHistoryInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedPositionHistory[]>> GetPositionHistoryAsyncEnumerable(GetPositionHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetPositionHistoryInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedPositionHistory[]>>> GetPositionHistoryInt(GetPositionHistoryRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetPositionHistoryClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetPositionHistoryOptions.Supported).Select(x => x.GetPositionHistoryAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Fees 

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFee>> GetFeesAsync(string exchange, GetFeeRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFeesInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFee>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFee>[]> GetFeesAsync(GetFeeRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFeesInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFee>> GetFeesAsyncEnumerable(GetFeeRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFeesInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFee>>> GetFeesInt(GetFeeRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFeeClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetFeeOptions.Supported).Select(x => x.GetFeesAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Book Tickers 

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedBookTicker>> GetBookTickerAsync(string exchange, GetBookTickerRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetBookTickersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedBookTicker>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedBookTicker>[]> GetBookTickersAsync(GetBookTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetBookTickersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedBookTicker>> GetBookTickersAsyncEnumerable(GetBookTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetBookTickersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedBookTicker>>> GetBookTickersInt(GetBookTickerRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetBookTickerClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetBookTickerOptions.Supported).Select(x => x.GetBookTickerAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Start Listen Key

        /// <inheritdoc />
        public async Task<ExchangeWebResult<string>> StartListenKeyAsync(string exchange, StartListenKeyRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(StartListenKeysInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<string>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<string>[]> StartListenKeysAsync(StartListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(StartListenKeysInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<string>> StartListenKeysAsyncEnumerable(StartListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return StartListenKeysInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<string>>> StartListenKeysInt(StartListenKeyRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetListenKeyClients().Where(x => request.TradingMode.HasValue ? x.SupportedTradingModes.Contains(request.TradingMode.Value) : true);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.StartOptions.Supported).Select(x => x.StartListenKeyAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Keep Alive Listen Key

        /// <inheritdoc />
        public async Task<ExchangeWebResult<string>> KeepAliveListenKeyAsync(string exchange, KeepAliveListenKeyRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(KeepAliveListenKeysInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<string>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<string>[]> KeepAliveListenKeysAsync(KeepAliveListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(KeepAliveListenKeysInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<string>> KeepAliveListenKeysAsyncEnumerable(KeepAliveListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return KeepAliveListenKeysInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<string>>> KeepAliveListenKeysInt(KeepAliveListenKeyRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetListenKeyClients().Where(x => request.TradingMode.HasValue ? x.SupportedTradingModes.Contains(request.TradingMode.Value) : true);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.KeepAliveOptions.Supported).Select(x => x.KeepAliveListenKeyAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Stop Listen Key

        /// <inheritdoc />
        public async Task<ExchangeWebResult<string>> StopListenKeyAsync(string exchange, StopListenKeyRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(StopListenKeysAsyncInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<string>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<string>[]> StopListenKeysAsync(StopListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(StopListenKeysAsyncInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<string>> StopListenKeysAsyncEnumerable(StopListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return StopListenKeysAsyncInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<string>>> StopListenKeysAsyncInt(StopListenKeyRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetListenKeyClients().Where(x => request.TradingMode.HasValue ? x.SupportedTradingModes.Contains(request.TradingMode.Value) : true);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.StopOptions.Supported).Select(x => x.StopListenKeyAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Place Spot Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> PlaceSpotOrderAsync(string exchange, PlaceSpotOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.PlaceSpotOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotOrder>> GetSpotOrderAsync(string exchange, GetOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedSpotOrder>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetSpotOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Order By Client Order Id

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotOrder>> GetSpotOrderByClientOrderIdAsync(string exchange, GetOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderClientIdClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedSpotOrder>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetSpotOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Order Trades

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedUserTrade[]>> GetSpotOrderTradesAsync(string exchange, GetOrderTradesRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedUserTrade[]>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetSpotOrderTradesAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Spot Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> CancelSpotOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelSpotOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Spot Order By Client Order Id

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> CancelSpotOrderByClientOrderIdAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderClientIdClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelSpotOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Place Futures Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> PlaceFuturesOrderAsync(string exchange, PlaceFuturesOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.PlaceFuturesOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Futures Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesOrder>> GetFuturesOrderAsync(string exchange, GetOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedFuturesOrder>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetFuturesOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Futures Order By Client Order Id

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesOrder>> GetFuturesOrderByClientOrderIdAsync(string exchange, GetOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClientIdClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedFuturesOrder>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetFuturesOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Futures Order Trades

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedUserTrade[]>> GetFuturesOrderTradesAsync(string exchange, GetOrderTradesRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedUserTrade[]>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetFuturesOrderTradesAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Futures Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> CancelFuturesOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelFuturesOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Futures Order By Client Order Id

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> CancelFuturesOrderByClientOrderIdAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClientIdClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelFuturesOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Close Position

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> ClosePositionAsync(string exchange, ClosePositionRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.ClosePositionAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Place Spot Trigger Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> PlaceSpotTriggerOrderAsync(string exchange, PlaceSpotTriggerOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotTriggerOrderClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.PlaceSpotTriggerOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Spot Trigger Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> CancelSpotTriggerOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotTriggerOrderClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelSpotTriggerOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Place Futures Trigger Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> PlaceFuturesTriggerOrderAsync(string exchange, PlaceFuturesTriggerOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesTriggerOrderClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.PlaceFuturesTriggerOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Futures Trigger Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> CancelFuturesTriggerOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesTriggerOrderClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelFuturesTriggerOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Futures TpSl

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> SetFuturesTpSlAsync(string exchange, SetTpSlRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesTpSlClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.SetFuturesTpSlAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel TpSl

        /// <inheritdoc />
        public async Task<ExchangeWebResult<bool>> CancelFuturesTpSlAsync(string exchange, CancelTpSlRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesTpSlClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<bool>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelFuturesTpSlAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        // TODO
        // Leverage client
        // PositionMode client
    }
}
