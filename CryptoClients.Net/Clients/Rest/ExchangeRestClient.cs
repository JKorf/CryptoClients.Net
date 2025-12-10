using Aster.Net;
using Aster.Net.Clients;
using Aster.Net.Interfaces.Clients;
using Aster.Net.Objects.Options;
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
using BloFin.Net;
using BloFin.Net.Clients;
using BloFin.Net.Interfaces.Clients;
using BloFin.Net.Objects.Options;
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
using CoinW.Net;
using CoinW.Net.Clients;
using CoinW.Net.Interfaces.Clients;
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
using Toobit.Net;
using Toobit.Net.Clients;
using Toobit.Net.Interfaces.Clients;
using Toobit.Net.Objects.Options;
using Upbit.Net;
using Upbit.Net.Clients;
using Upbit.Net.Interfaces.Clients;
using Upbit.Net.Objects.Options;
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
using CryptoExchange.Net.Interfaces;
using CoinW.Net.Objects.Options;
using CryptoExchange.Net.Interfaces.Clients;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public partial class ExchangeRestClient : IExchangeRestClient
    {
        private IEnumerable<ISharedClient> _sharedClients = Array.Empty<ISharedClient>();
        private IRestClient[] _restClients = [];

        /// <inheritdoc />
        public int TotalRequestsMade => _restClients.Sum(x => x.TotalRequestsMade);

        /// <inheritdoc />
        public IAsterRestClient Aster { get; }
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
        public IBloFinRestClient BloFin { get; }
        /// <inheritdoc />
        public IBybitRestClient Bybit { get; }
        /// <inheritdoc />
        public ICoinbaseRestClient Coinbase { get; }
        /// <inheritdoc />
        public ICoinExRestClient CoinEx { get; }
        /// <inheritdoc />
        public ICoinWRestClient CoinW { get; }
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
        public IToobitRestClient Toobit { get; }
        /// <inheritdoc />
        public IUpbitRestClient Upbit { get; }
        /// <inheritdoc />
        public IWhiteBitRestClient WhiteBit { get; }
        /// <inheritdoc />
        public IXTRestClient XT { get; }

        /// <summary>
        /// Create a new ExchangeRestClient instance. Client instances will be created with default options.
        /// </summary>
        public ExchangeRestClient()
        {
            Aster = new AsterRestClient();
            Binance = new BinanceRestClient();
            BingX = new BingXRestClient();
            Bitfinex = new BitfinexRestClient();
            Bitget = new BitgetRestClient();
            BitMart = new BitMartRestClient();
            BitMEX = new BitMEXRestClient();
            BloFin = new BloFinRestClient();
            Bybit = new BybitRestClient();
            Coinbase = new CoinbaseRestClient();
            CoinEx = new CoinExRestClient();
            CoinW = new CoinWRestClient();
            CryptoCom = new CryptoComRestClient();
            DeepCoin = new DeepCoinRestClient();
            GateIo = new GateIoRestClient();
            HTX = new HTXRestClient();
            HyperLiquid = new HyperLiquidRestClient();
            Kraken = new KrakenRestClient();
            Kucoin = new KucoinRestClient();
            Mexc = new MexcRestClient();
            OKX = new OKXRestClient();
            Toobit = new ToobitRestClient();
            Upbit = new UpbitRestClient();
            WhiteBit = new WhiteBitRestClient();
            XT = new XTRestClient();

            InitSharedClients();
        }

        /// <summary>
        /// Create a new ExchangeRestClient instance
        /// </summary>
        public ExchangeRestClient(
            Action<GlobalExchangeOptions>? globalOptions = null,
            Action<AsterRestOptions>? asterRestOptions = null,
            Action<BinanceRestOptions>? binanceRestOptions = null,
            Action<BingXRestOptions>? bingxRestOptions = null,
            Action<BitfinexRestOptions>? bitfinexRestOptions = null,
            Action<BitgetRestOptions>? bitgetRestOptions = null,
            Action<BitMartRestOptions>? bitMartRestOptions = null,
            Action<BitMEXRestOptions>? bitMEXRestOptions = null,
            Action<BloFinRestOptions>? bloFinRestOptions = null,
            Action<BybitRestOptions>? bybitRestOptions = null,
            Action<CoinbaseRestOptions>? coinbaseRestOptions = null,
            Action<CoinExRestOptions>? coinExRestOptions = null,
            Action<CoinWRestOptions>? coinWRestOptions = null,
            Action<CryptoComRestOptions>? cryptoComRestOptions = null,
            Action<DeepCoinRestOptions>? deepCoinRestOptions = null,
            Action<GateIoRestOptions>? gateIoRestOptions = null,
            Action<HTXRestOptions>? htxRestOptions = null,
            Action<HyperLiquidRestOptions>? hyperLiquidRestOptions = null,
            Action<KrakenRestOptions>? krakenRestOptions = null,
            Action<KucoinRestOptions>? kucoinRestOptions = null,
            Action<MexcRestOptions>? mexcRestOptions = null,
            Action<OKXRestOptions>? okxRestOptions = null,
            Action<ToobitRestOptions>? toobitRestOptions = null,
            Action<UpbitRestOptions>? upbitRestOptions = null,
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
                    restOptions.Proxy = restOptions.Proxy ?? globalOptions.Proxy;
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
                asterRestOptions = SetGlobalRestOptions(global, asterRestOptions, credentials?.Aster, environments?.TryGetValue(Exchange.Aster, out var asterEnvName) == true ? AsterEnvironment.GetEnvironmentByName(asterEnvName)!: AsterEnvironment.Live);
                binanceRestOptions = SetGlobalRestOptions(global, binanceRestOptions, credentials?.Binance, environments?.TryGetValue(Exchange.Binance, out var binanceEnvName) == true ? BinanceEnvironment.GetEnvironmentByName(binanceEnvName)!: BinanceEnvironment.Live);
                bingxRestOptions = SetGlobalRestOptions(global, bingxRestOptions, credentials?.BingX, environments?.TryGetValue(Exchange.BingX, out var bingXEnvName) == true ? BingXEnvironment.GetEnvironmentByName(bingXEnvName)! : BingXEnvironment.Live);
                bitfinexRestOptions = SetGlobalRestOptions(global, bitfinexRestOptions, credentials?.Bitfinex, environments?.TryGetValue(Exchange.Bitfinex, out var bitfinexEnvName) == true ? BitfinexEnvironment.GetEnvironmentByName(bitfinexEnvName)! : BitfinexEnvironment.Live);
                bitgetRestOptions = SetGlobalRestOptions(global, bitgetRestOptions, credentials?.Bitget, environments?.TryGetValue(Exchange.Bitget, out var bitgetEnvName) == true ? BitgetEnvironment.GetEnvironmentByName(bitgetEnvName)! : BitgetEnvironment.Live);
                bitMartRestOptions = SetGlobalRestOptions(global, bitMartRestOptions, credentials?.BitMart, environments?.TryGetValue(Exchange.BitMart, out var bitMartEnvName) == true ? BitMartEnvironment.GetEnvironmentByName(bitMartEnvName)! : BitMartEnvironment.Live);
                bitMEXRestOptions = SetGlobalRestOptions(global, bitMEXRestOptions, credentials?.BitMEX, environments?.TryGetValue(Exchange.BitMEX, out var bitMEXEnvName) == true ? BitMEXEnvironment.GetEnvironmentByName(bitMEXEnvName)! : BitMEXEnvironment.Live);
                bloFinRestOptions = SetGlobalRestOptions(global, bloFinRestOptions, credentials?.BloFin, environments?.TryGetValue(Exchange.BloFin, out var bloFinEnvName) == true ? BloFinEnvironment.GetEnvironmentByName(bloFinEnvName)! : BloFinEnvironment.Live);
                bybitRestOptions = SetGlobalRestOptions(global, bybitRestOptions, credentials?.Bybit, environments?.TryGetValue(Exchange.Bybit, out var bybitEnvName) == true ? BybitEnvironment.GetEnvironmentByName(bybitEnvName)! : BybitEnvironment.Live);
                coinbaseRestOptions = SetGlobalRestOptions(global, coinbaseRestOptions, credentials?.Coinbase, environments?.TryGetValue(Exchange.Coinbase, out var coinbaseEnvName) == true ? CoinbaseEnvironment.GetEnvironmentByName(coinbaseEnvName)! : CoinbaseEnvironment.Live);
                coinExRestOptions = SetGlobalRestOptions(global, coinExRestOptions, credentials?.CoinEx, environments?.TryGetValue(Exchange.CoinEx, out var coinExEnvName) == true ? CoinExEnvironment.GetEnvironmentByName(coinExEnvName)! : CoinExEnvironment.Live);
                coinWRestOptions = SetGlobalRestOptions(global, coinWRestOptions, credentials?.CoinW, environments?.TryGetValue(Exchange.CoinW, out var coinWEnvName) == true ? CoinWEnvironment.GetEnvironmentByName(coinWEnvName)! : CoinWEnvironment.Live);
                cryptoComRestOptions = SetGlobalRestOptions(global, cryptoComRestOptions, credentials?.CryptoCom, environments?.TryGetValue(Exchange.CryptoCom, out var cryptoComEnvName) == true ? CryptoComEnvironment.GetEnvironmentByName(cryptoComEnvName)! : CryptoComEnvironment.Live);
                deepCoinRestOptions = SetGlobalRestOptions(global, deepCoinRestOptions, credentials?.DeepCoin, environments?.TryGetValue(Exchange.DeepCoin, out var deepCoinEnvName) == true ? DeepCoinEnvironment.GetEnvironmentByName(deepCoinEnvName)! : DeepCoinEnvironment.Live);
                gateIoRestOptions = SetGlobalRestOptions(global, gateIoRestOptions, credentials?.GateIo, environments?.TryGetValue(Exchange.GateIo, out var gateIoEnvName) == true ? GateIoEnvironment.GetEnvironmentByName(gateIoEnvName)! : GateIoEnvironment.Live);
                htxRestOptions = SetGlobalRestOptions(global, htxRestOptions, credentials?.HTX, environments?.TryGetValue(Exchange.HTX, out var htxEnvName) == true ? HTXEnvironment.GetEnvironmentByName(htxEnvName)! : HTXEnvironment.Live);
                hyperLiquidRestOptions = SetGlobalRestOptions(global, hyperLiquidRestOptions, credentials?.HyperLiquid, environments?.TryGetValue(Exchange.HyperLiquid, out var hyperLiquidEnvName) == true ? HyperLiquidEnvironment.GetEnvironmentByName(hyperLiquidEnvName)! : HyperLiquidEnvironment.Live);
                krakenRestOptions = SetGlobalRestOptions(global, krakenRestOptions, credentials?.Kraken, environments?.TryGetValue(Exchange.Kraken, out var krakenEnvName) == true ? KrakenEnvironment.GetEnvironmentByName(krakenEnvName)! : KrakenEnvironment.Live);
                kucoinRestOptions = SetGlobalRestOptions(global, kucoinRestOptions, credentials?.Kucoin, environments?.TryGetValue(Exchange.Kucoin, out var kucoinEnvName) == true ? KucoinEnvironment.GetEnvironmentByName(kucoinEnvName)! : KucoinEnvironment.Live);
                mexcRestOptions = SetGlobalRestOptions(global, mexcRestOptions, credentials?.Mexc, environments?.TryGetValue(Exchange.Mexc, out var mexcEnvName) == true ? MexcEnvironment.GetEnvironmentByName(mexcEnvName)! : MexcEnvironment.Live);
                okxRestOptions = SetGlobalRestOptions(global, okxRestOptions, credentials?.OKX, environments?.TryGetValue(Exchange.OKX, out var okxEnvName) == true ? OKXEnvironment.GetEnvironmentByName(okxEnvName)! : OKXEnvironment.Live);
                toobitRestOptions = SetGlobalRestOptions(global, toobitRestOptions, credentials?.Toobit, environments?.TryGetValue(Exchange.Toobit, out var toobitEnvName) == true ? ToobitEnvironment.GetEnvironmentByName(toobitEnvName)! : ToobitEnvironment.Live);
                upbitRestOptions = SetGlobalRestOptions(global, upbitRestOptions, credentials?.Upbit, environments?.TryGetValue(Exchange.Upbit, out var upbitEnvName) == true ? UpbitEnvironment.GetEnvironmentByName(upbitEnvName)! : UpbitEnvironment.Live);
                whiteBitRestOptions = SetGlobalRestOptions(global, whiteBitRestOptions, credentials?.WhiteBit, environments?.TryGetValue(Exchange.WhiteBit, out var whiteBitEnvName) == true ? WhiteBitEnvironment.GetEnvironmentByName(whiteBitEnvName)! : WhiteBitEnvironment.Live);
                xtRestOptions = SetGlobalRestOptions(global, xtRestOptions, credentials?.XT, environments?.TryGetValue(Exchange.XT, out var xtEnvName) == true ? XTEnvironment.GetEnvironmentByName(xtEnvName)! : XTEnvironment.Live);
            }

            Aster = new AsterRestClient(asterRestOptions);
            Binance = new BinanceRestClient(binanceRestOptions);
            BingX = new BingXRestClient(bingxRestOptions);
            Bitfinex = new BitfinexRestClient(bitfinexRestOptions);
            Bitget = new BitgetRestClient(bitgetRestOptions);
            BitMart = new BitMartRestClient(bitMartRestOptions);
            BitMEX = new BitMEXRestClient(bitMEXRestOptions);
            BloFin = new BloFinRestClient(bloFinRestOptions);
            Bybit = new BybitRestClient(bybitRestOptions);
            Coinbase = new CoinbaseRestClient(coinbaseRestOptions);
            CoinEx = new CoinExRestClient(coinExRestOptions);
            CoinW = new CoinWRestClient(coinWRestOptions);
            CryptoCom = new CryptoComRestClient(cryptoComRestOptions);
            DeepCoin = new DeepCoinRestClient(deepCoinRestOptions);
            GateIo = new GateIoRestClient(gateIoRestOptions);
            HTX = new HTXRestClient(htxRestOptions);
            HyperLiquid = new HyperLiquidRestClient(hyperLiquidRestOptions);
            Kraken = new KrakenRestClient(krakenRestOptions);
            Kucoin = new KucoinRestClient(kucoinRestOptions);
            Mexc = new MexcRestClient(mexcRestOptions);
            OKX = new OKXRestClient(okxRestOptions);
            Toobit = new ToobitRestClient(toobitRestOptions);
            Upbit = new UpbitRestClient(upbitRestOptions);
            WhiteBit = new WhiteBitRestClient(whiteBitRestOptions);
            XT = new XTRestClient(xtRestOptions);

            InitSharedClients();
        }

        private void InitSharedClients()
        {
            _restClients = [Aster, Binance, BingX, Bitfinex, Bitget, BitMart, BitMEX, BloFin, Bybit, Coinbase, CoinEx, CoinW, CryptoCom,
                DeepCoin, GateIo, HTX, HyperLiquid, Kraken, Kucoin, Mexc, OKX, Toobit, Upbit, WhiteBit, XT];

            _sharedClients = new ISharedClient[]
            {
                Aster.SpotApi.SharedClient,
                Aster.FuturesApi.SharedClient,
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
                BloFin.FuturesApi.SharedClient,
                BloFin.AccountApi.SharedClient,
                Bybit.V5Api.SharedClient,
                Coinbase.AdvancedTradeApi.SharedClient,
                CoinEx.SpotApiV2.SharedClient,
                CoinEx.FuturesApi.SharedClient,
                CoinW.SpotApi.SharedClient,
                CoinW.FuturesApi.SharedClient,
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
                Mexc.FuturesApi.SharedClient,
                OKX.UnifiedApi.SharedClient,
                Toobit.SpotApi.SharedClient,
                Toobit.UsdtFuturesApi.SharedClient,
                Upbit.SpotApi.SharedClient,
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
            IAsterRestClient aster,
            IBinanceRestClient binance,
            IBingXRestClient bingx,
            IBitfinexRestClient bitfinex,
            IBitgetRestClient bitget,
            IBitMartRestClient bitMart,
            IBitMEXRestClient bitMEX,
            IBloFinRestClient bloFin,
            IBybitRestClient bybit,
            ICoinbaseRestClient coinbase,
            ICoinExRestClient coinEx,
            ICoinWRestClient coinW,
            ICryptoComRestClient cryptoCom,
            IDeepCoinRestClient deepCoin,
            IGateIoRestClient gateIo,
            IHTXRestClient htx,
            IHyperLiquidRestClient hyperLiquid,
            IKrakenRestClient kraken,
            IKucoinRestClient kucoin,
            IMexcRestClient mexc,
            IOKXRestClient okx,
            IToobitRestClient toobit,
            IUpbitRestClient upbit,
            IWhiteBitRestClient whiteBit,
            IXTRestClient xt)
        {
            Aster = aster;
            Binance = binance;
            BingX = bingx;
            Bitfinex = bitfinex;
            Bitget = bitget;
            BitMart = bitMart;
            BitMEX = bitMEX;
            BloFin = bloFin;
            Bybit = bybit;
            Coinbase = coinbase;
            CoinEx = coinEx;
            CoinW = coinW;
            CryptoCom = cryptoCom;
            DeepCoin = deepCoin;
            GateIo = gateIo;
            HTX = htx;
            HyperLiquid = hyperLiquid;
            Kraken = kraken;
            Kucoin = kucoin;
            Mexc = mexc;
            OKX = okx;
            Toobit = toobit;
            Upbit = upbit;
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
        public void SetApiCredentials(ExchangeCredentials credentials)
        {
            void SetCredentialsIfNotNull(string exchange, ApiCredentials? credentials)
            {
                if (credentials == null)
                    return;

                SetApiCredentials(exchange, credentials.Key, credentials.Secret, credentials.Pass);
            }

            SetCredentialsIfNotNull(Exchange.Aster, credentials.Aster);
            SetCredentialsIfNotNull(Exchange.Binance, credentials.Binance);
            SetCredentialsIfNotNull(Exchange.BingX, credentials.BingX);
            SetCredentialsIfNotNull(Exchange.Bitfinex, credentials.Bitfinex);
            SetCredentialsIfNotNull(Exchange.Bitget, credentials.Bitget);
            SetCredentialsIfNotNull(Exchange.BitMart, credentials.BitMart);
            SetCredentialsIfNotNull(Exchange.BitMEX, credentials.BitMEX);
            SetCredentialsIfNotNull(Exchange.BloFin, credentials.BloFin);
            SetCredentialsIfNotNull(Exchange.Bybit, credentials.Bybit);
            SetCredentialsIfNotNull(Exchange.Coinbase, credentials.Coinbase);
            SetCredentialsIfNotNull(Exchange.CoinEx, credentials.CoinEx);
            SetCredentialsIfNotNull(Exchange.CoinW, credentials.CoinW);
            SetCredentialsIfNotNull(Exchange.CryptoCom, credentials.CryptoCom);
            SetCredentialsIfNotNull(Exchange.DeepCoin, credentials.DeepCoin);
            SetCredentialsIfNotNull(Exchange.GateIo, credentials.GateIo);
            SetCredentialsIfNotNull(Exchange.HTX, credentials.HTX);
            SetCredentialsIfNotNull(Exchange.HyperLiquid, credentials.HyperLiquid);
            SetCredentialsIfNotNull(Exchange.Kraken, credentials.Kraken);
            SetCredentialsIfNotNull(Exchange.Kucoin, credentials.Kucoin);
            SetCredentialsIfNotNull(Exchange.Mexc, credentials.Mexc);
            SetCredentialsIfNotNull(Exchange.OKX, credentials.OKX);
            SetCredentialsIfNotNull(Exchange.Toobit, credentials.Toobit);
            SetCredentialsIfNotNull(Exchange.Upbit, credentials.Upbit);
            SetCredentialsIfNotNull(Exchange.WhiteBit, credentials.WhiteBit);
            SetCredentialsIfNotNull(Exchange.XT, credentials.XT);
        }

        /// <inheritdoc />
        public void SetApiCredentials(string exchange, string apiKey, string apiSecret, string? apiPass = null)
        {
            switch (exchange)
            {
                case "Aster": Aster.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Binance": Binance.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "BingX": BingX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Bitfinex": Bitfinex.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Bitget": Bitget.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for Bitget credentials", nameof(apiPass)))); break;
                case "BitMart": BitMart.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for BitMart credentials", nameof(apiPass)))); break;
                case "BitMEX": BitMEX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "BloFin": BloFin.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Bybit": Bybit.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Coinbase": Coinbase.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "CoinEx": CoinEx.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "CoinW": CoinW.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "CryptoCom": CryptoCom.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "DeepCoin": DeepCoin.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for DeepCoin credentials", nameof(apiPass)))); break;
                case "GateIo": GateIo.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "HTX": HTX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "HyperLiquid": HyperLiquid.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Kraken": Kraken.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Kucoin": Kucoin.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for Kucoin credentials", nameof(apiPass)))); break;
                case "Mexc": Mexc.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "OKX": OKX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for OKX credentials", nameof(apiPass)))); break;
                case "Toobit": Toobit.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Upbit": Upbit.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
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

        /// <inheritdoc />
        public string? GenerateClientOrderId(TradingMode tradingMode, string exchange)
        {
            if (tradingMode == TradingMode.Spot)
            {
                var spotClient = _sharedClients.Where(x => x.Exchange == exchange).SpotOrderRestClient();
                return spotClient?.GenerateClientOrderId();
            }

            var futuresClient = _sharedClients.Where(x => x.Exchange == exchange).FuturesOrderRestClient(tradingMode);
            return futuresClient?.GenerateClientOrderId();            
        }
    }
}
