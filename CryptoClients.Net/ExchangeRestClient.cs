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
using BitMEX.Net.Clients;
using BitMEX.Net.Interfaces.Clients;
using BitMEX.Net.Objects.Options;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using Coinbase.Net.Clients;
using Coinbase.Net.Interfaces.Clients;
using Coinbase.Net.Objects.Options;
using CoinEx.Net.Clients;
using CoinEx.Net.Interfaces.Clients;
using CoinEx.Net.Objects.Options;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoClients.Net.Models;
using CryptoCom.Net.Clients;
using CryptoCom.Net.Interfaces.Clients;
using CryptoCom.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.SharedApis;
using DeepCoin.Net.Clients;
using DeepCoin.Net.Interfaces.Clients;
using DeepCoin.Net.Objects;
using DeepCoin.Net.Objects.Options;
using GateIo.Net.Clients;
using GateIo.Net.Interfaces.Clients;
using GateIo.Net.Objects.Options;
using HTX.Net.Clients;
using HTX.Net.Interfaces.Clients;
using HTX.Net.Objects.Options;
using HyperLiquid.Net.Clients;
using HyperLiquid.Net.Interfaces.Clients;
using HyperLiquid.Net.Objects.Options;
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
            Action<TOptions> SetGlobalRestOptions<TOptions, TCredentials>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TCredentials? credentials) where TOptions : RestExchangeOptions where TCredentials : ApiCredentials
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
                    exchangeDelegate?.Invoke(restOptions);
                };

                return restDelegate;
            }

            if (globalOptions != null)
            {
                var global = new GlobalExchangeOptions();
                globalOptions.Invoke(global);

                ExchangeCredentials? credentials = global.ApiCredentials;
                binanceRestOptions = SetGlobalRestOptions(global, binanceRestOptions, credentials?.Binance);
                bingxRestOptions = SetGlobalRestOptions(global, bingxRestOptions, credentials?.BingX);
                bitfinexRestOptions = SetGlobalRestOptions(global, bitfinexRestOptions, credentials?.Bitfinex);
                bitgetRestOptions = SetGlobalRestOptions(global, bitgetRestOptions, credentials?.Bitget);
                bitMartRestOptions = SetGlobalRestOptions(global, bitMartRestOptions, credentials?.BitMart);
                bitMEXRestOptions = SetGlobalRestOptions(global, bitMEXRestOptions, credentials?.BitMEX);
                bybitRestOptions = SetGlobalRestOptions(global, bybitRestOptions, credentials?.Bybit);
                coinbaseRestOptions = SetGlobalRestOptions(global, coinbaseRestOptions, credentials?.Coinbase);
                coinExRestOptions = SetGlobalRestOptions(global, coinExRestOptions, credentials?.CoinEx);
                cryptoComRestOptions = SetGlobalRestOptions(global, cryptoComRestOptions, credentials?.CryptoCom);
                deepCoinRestOptions = SetGlobalRestOptions(global, deepCoinRestOptions, credentials?.DeepCoin);
                gateIoRestOptions = SetGlobalRestOptions(global, gateIoRestOptions, credentials?.GateIo);
                htxRestOptions = SetGlobalRestOptions(global, htxRestOptions, credentials?.HTX);
                hyperLiquidRestOptions = SetGlobalRestOptions(global, hyperLiquidRestOptions, credentials?.HyperLiquid);
                krakenRestOptions = SetGlobalRestOptions(global, krakenRestOptions, credentials?.Kraken);
                kucoinRestOptions = SetGlobalRestOptions(global, kucoinRestOptions, credentials?.Kucoin);
                mexcRestOptions = SetGlobalRestOptions(global, mexcRestOptions, credentials?.Mexc);
                okxRestOptions = SetGlobalRestOptions(global, okxRestOptions, credentials?.OKX);
                whiteBitRestOptions = SetGlobalRestOptions(global, whiteBitRestOptions, credentials?.WhiteBit);
                xtRestOptions = SetGlobalRestOptions(global, xtRestOptions, credentials?.XT);
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
        public async Task<IEnumerable<ExchangeWebResult<SharedSpotTicker[]>>> GetSpotTickersAsync(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetSpotTickersAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Ticker

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedSpotTicker>>> GetSpotTickerAsync(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetSpotTickerAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Symbols

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedSpotSymbol[]>>> GetSpotSymbolsAsync(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetSpotSymbolsAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Open Orders

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedSpotOrder[]>>> GetSpotOpenOrdersAsync(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetOpenSpotOrdersAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Closed Orders

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedSpotOrder[]>>> GetSpotClosedOrdersAsync(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetClosedSpotOrdersAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Spot User Trades

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedUserTrade[]>>> GetSpotUserTradesAsync(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetSpotUserTradesAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Tickers

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedFuturesTicker[]>>> GetFuturesTickersAsync(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetFuturesTickersAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Ticker

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedFuturesTicker>>> GetFuturesTickerAsync(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetFuturesTickerAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Klines
        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedKline[]>>> GetKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetKlinesAsync(request, null, ct));
            return tasks;
        }


        #endregion

        #region Get Mark Price Klines
        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedFuturesKline[]>>> GetMarkPriceKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetMarkPriceKlinesAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Index Price Klines
        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedFuturesKline[]>>> GetIndexPriceKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetIndexPriceKlinesAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Recent Trades

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedTrade[]>>> GetRecentTradesAsync(GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetRecentTradesAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Trade History

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedTrade[]>>> GetTradeHistoryAsync(GetTradeHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetTradeHistoryAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Order Book

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedOrderBook>>> GetOrderBookAsync(GetOrderBookRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetOrderBookAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Assets

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedAsset[]>>> GetAssetsAsync(GetAssetsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetAssetsAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Asset

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedAsset>>> GetAssetAsync(GetAssetRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetAssetAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Open Orders

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedFuturesOrder[]>>> GetFuturesOpenOrdersAsync(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetOpenFuturesOrdersAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Closed Orders

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedFuturesOrder[]>>> GetFuturesClosedOrdersAsync(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetClosedFuturesOrdersAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Futures User Trades

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedUserTrade[]>>> GetFuturesUserTradesAsync(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetFuturesUserTradesAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Balances

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedBalance[]>>> GetBalancesAsync(GetBalancesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetBalancesAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Deposits

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedDeposit[]>>> GetDepositsAsync(GetDepositsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetDepositsAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Withdrawals

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedWithdrawal[]>>> GetWithdrawalsAsync(GetWithdrawalsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetWithdrawalsAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Funding Rate History

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedFundingRate[]>>> GetFundingRateHistoryAsync(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetFundingRateHistoryAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Open Interest

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedOpenInterest>>> GetOpenInterestAsync(GetOpenInterestRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetOpenInterestAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Symbols

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedFuturesSymbol[]>>> GetFuturesSymbolsAsync(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetFuturesSymbolsAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Position History

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedPositionHistory[]>>> GetPositionHistoryAsync(GetPositionHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetPositionHistoryAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Fees 

        /// <inheritdoc />
        public async Task<IEnumerable<ExchangeWebResult<SharedFee>>> GetFeesAsync(GetFeeRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
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
                clients = clients.Where(c => exchanges.Contains(c.Exchange));

            var tasks = clients.Select(x => x.GetFeesAsync(request, ct));
            return tasks;
        }

        #endregion
    }
}
