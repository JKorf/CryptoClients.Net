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
using Bitstamp.Net;
using Bitstamp.Net.Clients;
using Bitstamp.Net.Interfaces.Clients;
using Bitstamp.Net.Objects.Options;
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
using CoinEx.Net.Objects.Options;
using CoinGecko.Net;
using CoinGecko.Net.Clients;
using CoinGecko.Net.Interfaces;
using CoinGecko.Net.Objects.Options;
using CoinW.Net;
using CoinW.Net.Clients;
using CoinW.Net.Interfaces.Clients;
using CoinW.Net.Objects.Options;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoClients.Net.Models;
using CryptoCom.Net;
using CryptoCom.Net.Clients;
using CryptoCom.Net.Interfaces.Clients;
using CryptoCom.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.Clients;
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
using Lighter.Net;
using Lighter.Net.Clients;
using Lighter.Net.Interfaces.Clients;
using Lighter.Net.Objects.Options;
using Mexc.Net;
using Mexc.Net.Clients;
using Mexc.Net.Interfaces.Clients;
using Mexc.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OKX.Net;
using OKX.Net.Clients;
using OKX.Net.Interfaces.Clients;
using OKX.Net.Objects.Options;
using Pionex.Net;
using Pionex.Net.Clients;
using Pionex.Net.Interfaces.Clients;
using Pionex.Net.Objects.Options;
using Polymarket.Net;
using Polymarket.Net.Clients;
using Polymarket.Net.Interfaces.Clients;
using Polymarket.Net.Objects.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Toobit.Net;
using Toobit.Net.Clients;
using Toobit.Net.Interfaces.Clients;
using Toobit.Net.Objects.Options;
using Upbit.Net;
using Upbit.Net.Clients;
using Upbit.Net.Interfaces.Clients;
using Upbit.Net.Objects.Options;
using Weex.Net;
using Weex.Net.Clients;
using Weex.Net.Interfaces.Clients;
using Weex.Net.Objects.Options;
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
        public IBitstampRestClient Bitstamp { get; }
        /// <inheritdoc />
        public IBloFinRestClient BloFin { get; }
        /// <inheritdoc />
        public IBybitRestClient Bybit { get; }
        /// <inheritdoc />
        public ICoinbaseRestClient Coinbase { get; }
        /// <inheritdoc />
        public ICoinExRestClient CoinEx { get; }
        /// <inheritdoc />
        public ICoinGeckoRestClient CoinGecko { get; }
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
        public ILighterRestClient Lighter { get; }
        /// <inheritdoc />
        public IMexcRestClient Mexc { get; }
        /// <inheritdoc />
        public IOKXRestClient OKX { get; }
        /// <inheritdoc />
        public IPionexRestClient Pionex { get; }
        /// <inheritdoc />
        public IPolymarketRestClient Polymarket { get; }
        /// <inheritdoc />
        public IToobitRestClient Toobit { get; }
        /// <inheritdoc />
        public IUpbitRestClient Upbit { get; }
        /// <inheritdoc />
        public IWeexRestClient Weex { get; }
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
            Bitstamp = new BitstampRestClient();
            BloFin = new BloFinRestClient();
            Bybit = new BybitRestClient();
            Coinbase = new CoinbaseRestClient();
            CoinEx = new CoinExRestClient();
            CoinGecko = new CoinGeckoRestClient();
            CoinW = new CoinWRestClient();
            CryptoCom = new CryptoComRestClient();
            DeepCoin = new DeepCoinRestClient();
            GateIo = new GateIoRestClient();
            HTX = new HTXRestClient();
            HyperLiquid = new HyperLiquidRestClient();
            Kraken = new KrakenRestClient();
            Kucoin = new KucoinRestClient();
            Lighter = new LighterRestClient();
            Mexc = new MexcRestClient();
            OKX = new OKXRestClient();
            Pionex = new PionexRestClient();
            Polymarket = new PolymarketRestClient();
            Toobit = new ToobitRestClient();
            Upbit = new UpbitRestClient();
            Weex = new WeexRestClient();
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
            Action<BitstampRestOptions>? bitstampRestOptions = null,
            Action<BloFinRestOptions>? bloFinRestOptions = null,
            Action<BybitRestOptions>? bybitRestOptions = null,
            Action<CoinbaseRestOptions>? coinbaseRestOptions = null,
            Action<CoinExRestOptions>? coinExRestOptions = null,
            Action<CoinGeckoRestOptions>? coinGeckoRestOptions = null,
            Action<CoinWRestOptions>? coinWRestOptions = null,
            Action<CryptoComRestOptions>? cryptoComRestOptions = null,
            Action<DeepCoinRestOptions>? deepCoinRestOptions = null,
            Action<GateIoRestOptions>? gateIoRestOptions = null,
            Action<HTXRestOptions>? htxRestOptions = null,
            Action<HyperLiquidRestOptions>? hyperLiquidRestOptions = null,
            Action<KrakenRestOptions>? krakenRestOptions = null,
            Action<KucoinRestOptions>? kucoinRestOptions = null,
            Action<LighterRestOptions>? lighterRestOptions = null,
            Action<MexcRestOptions>? mexcRestOptions = null,
            Action<OKXRestOptions>? okxRestOptions = null,
            Action<PionexRestOptions>? pionexRestOptions = null,
            Action<PolymarketRestOptions>? polymarketRestOptions = null,
            Action<ToobitRestOptions>? toobitRestOptions = null,
            Action<UpbitRestOptions>? upbitRestOptions = null,
            Action<WeexRestOptions>? weexRestOptions = null,
            Action<WhiteBitRestOptions>? whiteBitRestOptions = null,
            Action<XTRestOptions>? xtRestOptions = null) :
            this(null,
                null,
                Options.Create(ApplyOptionsDelegate(globalOptions)),
                Options.Create(ApplyOptionsDelegate(asterRestOptions)),
                Options.Create(ApplyOptionsDelegate(binanceRestOptions)),
                Options.Create(ApplyOptionsDelegate(bingxRestOptions)),
                Options.Create(ApplyOptionsDelegate(bitfinexRestOptions)),
                Options.Create(ApplyOptionsDelegate(bitgetRestOptions)),
                Options.Create(ApplyOptionsDelegate(bitMartRestOptions)),
                Options.Create(ApplyOptionsDelegate(bitMEXRestOptions)),
                Options.Create(ApplyOptionsDelegate(bitstampRestOptions)),
                Options.Create(ApplyOptionsDelegate(bloFinRestOptions)),
                Options.Create(ApplyOptionsDelegate(bybitRestOptions)),
                Options.Create(ApplyOptionsDelegate(coinbaseRestOptions)),
                Options.Create(ApplyOptionsDelegate(coinExRestOptions)),
                Options.Create(ApplyOptionsDelegate(coinGeckoRestOptions)),
                Options.Create(ApplyOptionsDelegate(coinWRestOptions)),
                Options.Create(ApplyOptionsDelegate(cryptoComRestOptions)),
                Options.Create(ApplyOptionsDelegate(deepCoinRestOptions)),
                Options.Create(ApplyOptionsDelegate(gateIoRestOptions)),
                Options.Create(ApplyOptionsDelegate(htxRestOptions)),
                Options.Create(ApplyOptionsDelegate(hyperLiquidRestOptions)),
                Options.Create(ApplyOptionsDelegate(krakenRestOptions)),
                Options.Create(ApplyOptionsDelegate(kucoinRestOptions)),
                Options.Create(ApplyOptionsDelegate(lighterRestOptions)),
                Options.Create(ApplyOptionsDelegate(mexcRestOptions)),
                Options.Create(ApplyOptionsDelegate(okxRestOptions)),
                Options.Create(ApplyOptionsDelegate(pionexRestOptions)),
                Options.Create(ApplyOptionsDelegate(polymarketRestOptions)),
                Options.Create(ApplyOptionsDelegate(toobitRestOptions)),
                Options.Create(ApplyOptionsDelegate(upbitRestOptions)),
                Options.Create(ApplyOptionsDelegate(weexRestOptions)),
                Options.Create(ApplyOptionsDelegate(whiteBitRestOptions)),
                Options.Create(ApplyOptionsDelegate(xtRestOptions))
                )
        {
        }

        /// <summary>
        /// Create a new ExchangeRestClient instance
        /// </summary>
        public ExchangeRestClient(
            HttpClient? httpClient = null,
            ILoggerFactory? loggerFactory = null,
            IOptions<GlobalExchangeOptions>? globalOptions = null,
            IOptions<AsterRestOptions>? asterRestOptions = null,
            IOptions<BinanceRestOptions>? binanceRestOptions = null,
            IOptions<BingXRestOptions>? bingxRestOptions = null,
            IOptions<BitfinexRestOptions>? bitfinexRestOptions = null,
            IOptions<BitgetRestOptions>? bitgetRestOptions = null,
            IOptions<BitMartRestOptions>? bitMartRestOptions = null,
            IOptions<BitMEXRestOptions>? bitMEXRestOptions = null,
            IOptions<BitstampRestOptions>? bitstampRestOptions = null,
            IOptions<BloFinRestOptions>? bloFinRestOptions = null,
            IOptions<BybitRestOptions>? bybitRestOptions = null,
            IOptions<CoinbaseRestOptions>? coinbaseRestOptions = null,
            IOptions<CoinExRestOptions>? coinExRestOptions = null,
            IOptions<CoinGeckoRestOptions>? coinGeckoRestOptions = null,
            IOptions<CoinWRestOptions>? coinWRestOptions = null,
            IOptions<CryptoComRestOptions>? cryptoComRestOptions = null,
            IOptions<DeepCoinRestOptions>? deepCoinRestOptions = null,
            IOptions<GateIoRestOptions>? gateIoRestOptions = null,
            IOptions<HTXRestOptions>? htxRestOptions = null,
            IOptions<HyperLiquidRestOptions>? hyperLiquidRestOptions = null,
            IOptions<KrakenRestOptions>? krakenRestOptions = null,
            IOptions<KucoinRestOptions>? kucoinRestOptions = null,
            IOptions<LighterRestOptions>? lighterRestOptions = null,
            IOptions<MexcRestOptions>? mexcRestOptions = null,
            IOptions<OKXRestOptions>? okxRestOptions = null,
            IOptions<PionexRestOptions>? pionexRestOptions = null,
            IOptions<PolymarketRestOptions>? polymarketRestOptions = null,
            IOptions<ToobitRestOptions>? toobitRestOptions = null,
            IOptions<UpbitRestOptions>? upbitRestOptions = null,
            IOptions<WeexRestOptions>? weexRestOptions = null,
            IOptions<WhiteBitRestOptions>? whiteBitRestOptions = null,
            IOptions<XTRestOptions>? xtRestOptions = null)
        {
            TOptions SetGlobalRestOptionsBase<TOptions, TEnvironment>(GlobalExchangeOptions globalOptions, TOptions? restOptions, TEnvironment environment)
                where TOptions : RestExchangeOptions<TEnvironment>, new()
                where TEnvironment : TradeEnvironment
            {
                // Create API options if not already provided
                // Set global options on API options
                // Set exchange options on API options
                restOptions ??= new();
                restOptions.Proxy = restOptions.Proxy ?? globalOptions.Proxy;
                restOptions.OutputOriginalData = globalOptions.OutputOriginalData ?? restOptions.OutputOriginalData;
                restOptions.RequestTimeout = globalOptions.RequestTimeout ?? restOptions.RequestTimeout;
                restOptions.RateLimiterEnabled = globalOptions.RateLimiterEnabled ?? restOptions.RateLimiterEnabled;
                restOptions.RateLimitingBehaviour = globalOptions.RateLimitingBehaviour ?? restOptions.RateLimitingBehaviour;
                restOptions.CachingEnabled = globalOptions.CachingEnabled ?? restOptions.CachingEnabled;
                restOptions.Environment = environment;                

                return restOptions;
            }

            IOptions<TOptions> SetGlobalRestOptions<TOptions, TCredentials, TEnvironment>(GlobalExchangeOptions globalOptions, TOptions? restOptions, TCredentials? credentials, TEnvironment environment) 
                where TOptions : RestExchangeOptions<TEnvironment, TCredentials>, new()
                where TCredentials : ApiCredentials 
                where TEnvironment : TradeEnvironment
            {

                SetGlobalRestOptionsBase<TOptions, TEnvironment>(globalOptions, restOptions, environment);
                restOptions!.ApiCredentials = credentials;
                return Options.Create<TOptions>(restOptions);
            }

            if (globalOptions != null)
            {
                var global = globalOptions.Value;

                ExchangeCredentials? credentials = global.ApiCredentials;
                Dictionary<string, string?>? environments = global.ApiEnvironments;
                asterRestOptions = SetGlobalRestOptions(global, asterRestOptions?.Value, credentials?.Aster, environments?.TryGetValue(Exchange.Aster, out var asterEnvName) == true ? AsterEnvironment.GetEnvironmentByName(asterEnvName)!: asterRestOptions?.Value.Environment ?? AsterEnvironment.Live);
                binanceRestOptions = SetGlobalRestOptions(global, binanceRestOptions?.Value, credentials?.Binance, environments?.TryGetValue(Exchange.Binance, out var binanceEnvName) == true ? BinanceEnvironment.GetEnvironmentByName(binanceEnvName)!: binanceRestOptions?.Value.Environment ?? BinanceEnvironment.Live);
                bingxRestOptions = SetGlobalRestOptions(global, bingxRestOptions?.Value, credentials?.BingX, environments?.TryGetValue(Exchange.BingX, out var bingXEnvName) == true ? BingXEnvironment.GetEnvironmentByName(bingXEnvName)! : bingxRestOptions?.Value.Environment ?? BingXEnvironment.Live);
                bitfinexRestOptions = SetGlobalRestOptions(global, bitfinexRestOptions?.Value, credentials?.Bitfinex, environments?.TryGetValue(Exchange.Bitfinex, out var bitfinexEnvName) == true ? BitfinexEnvironment.GetEnvironmentByName(bitfinexEnvName)! : bitfinexRestOptions?.Value.Environment ?? BitfinexEnvironment.Live);
                bitgetRestOptions = SetGlobalRestOptions(global, bitgetRestOptions?.Value, credentials?.Bitget, environments?.TryGetValue(Exchange.Bitget, out var bitgetEnvName) == true ? BitgetEnvironment.GetEnvironmentByName(bitgetEnvName)! : bitgetRestOptions?.Value.Environment ?? BitgetEnvironment.Live);
                bitMartRestOptions = SetGlobalRestOptions(global, bitMartRestOptions?.Value, credentials?.BitMart, environments?.TryGetValue(Exchange.BitMart, out var bitMartEnvName) == true ? BitMartEnvironment.GetEnvironmentByName(bitMartEnvName)! : bitMartRestOptions?.Value.Environment ?? BitMartEnvironment.Live);
                bitMEXRestOptions = SetGlobalRestOptions(global, bitMEXRestOptions?.Value, credentials?.BitMEX, environments?.TryGetValue(Exchange.BitMEX, out var bitMEXEnvName) == true ? BitMEXEnvironment.GetEnvironmentByName(bitMEXEnvName)! : bitMEXRestOptions?.Value.Environment ?? BitMEXEnvironment.Live);
                bitstampRestOptions = SetGlobalRestOptions(global, bitstampRestOptions?.Value, credentials?.Bitstamp, environments?.TryGetValue(Exchange.Bitstamp, out var bitstampEnvName) == true ? BitstampEnvironment.GetEnvironmentByName(bitstampEnvName)! : bitstampRestOptions?.Value.Environment ?? BitstampEnvironment.Live);
                bloFinRestOptions = SetGlobalRestOptions(global, bloFinRestOptions?.Value, credentials?.BloFin, environments?.TryGetValue(Exchange.BloFin, out var bloFinEnvName) == true ? BloFinEnvironment.GetEnvironmentByName(bloFinEnvName)! : bloFinRestOptions?.Value.Environment ?? BloFinEnvironment.Live);
                bybitRestOptions = SetGlobalRestOptions(global, bybitRestOptions?.Value, credentials?.Bybit, environments?.TryGetValue(Exchange.Bybit, out var bybitEnvName) == true ? BybitEnvironment.GetEnvironmentByName(bybitEnvName)! : bybitRestOptions?.Value.Environment ?? BybitEnvironment.Live);
                coinbaseRestOptions = SetGlobalRestOptions(global, coinbaseRestOptions?.Value, credentials?.Coinbase, environments?.TryGetValue(Exchange.Coinbase, out var coinbaseEnvName) == true ? CoinbaseEnvironment.GetEnvironmentByName(coinbaseEnvName)! : coinbaseRestOptions?.Value.Environment ?? CoinbaseEnvironment.Live);
                coinGeckoRestOptions = SetGlobalRestOptions(global, coinGeckoRestOptions?.Value, credentials?.CoinGecko, environments?.TryGetValue(Platform.CoinGecko, out var coinGeckoEnvName) == true ? CoinGeckoEnvironment.GetEnvironmentByName(coinGeckoEnvName)! : coinGeckoRestOptions?.Value.Environment ?? CoinGeckoEnvironment.Live);
                coinExRestOptions = SetGlobalRestOptions(global, coinExRestOptions?.Value, credentials?.CoinEx, environments?.TryGetValue(Exchange.CoinEx, out var coinExEnvName) == true ? CoinExEnvironment.GetEnvironmentByName(coinExEnvName)! : coinExRestOptions?.Value.Environment ?? CoinExEnvironment.Live);
                coinWRestOptions = SetGlobalRestOptions(global, coinWRestOptions?.Value, credentials?.CoinW, environments?.TryGetValue(Exchange.CoinW, out var coinWEnvName) == true ? CoinWEnvironment.GetEnvironmentByName(coinWEnvName)! : coinWRestOptions?.Value.Environment ?? CoinWEnvironment.Live);
                cryptoComRestOptions = SetGlobalRestOptions(global, cryptoComRestOptions?.Value, credentials?.CryptoCom, environments?.TryGetValue(Exchange.CryptoCom, out var cryptoComEnvName) == true ? CryptoComEnvironment.GetEnvironmentByName(cryptoComEnvName)! : cryptoComRestOptions?.Value.Environment ?? CryptoComEnvironment.Live);
                deepCoinRestOptions = SetGlobalRestOptions(global, deepCoinRestOptions?.Value, credentials?.DeepCoin, environments?.TryGetValue(Exchange.DeepCoin, out var deepCoinEnvName) == true ? DeepCoinEnvironment.GetEnvironmentByName(deepCoinEnvName)! : deepCoinRestOptions?.Value.Environment ?? DeepCoinEnvironment.Live);
                gateIoRestOptions = SetGlobalRestOptions(global, gateIoRestOptions?.Value, credentials?.GateIo, environments?.TryGetValue(Exchange.GateIo, out var gateIoEnvName) == true ? GateIoEnvironment.GetEnvironmentByName(gateIoEnvName)! : gateIoRestOptions?.Value.Environment ?? GateIoEnvironment.Live);
                htxRestOptions = SetGlobalRestOptions(global, htxRestOptions?.Value, credentials?.HTX, environments?.TryGetValue(Exchange.HTX, out var htxEnvName) == true ? HTXEnvironment.GetEnvironmentByName(htxEnvName)! : htxRestOptions?.Value.Environment ?? HTXEnvironment.Live);
                hyperLiquidRestOptions = SetGlobalRestOptions(global, hyperLiquidRestOptions?.Value, credentials?.HyperLiquid, environments?.TryGetValue(Exchange.HyperLiquid, out var hyperLiquidEnvName) == true ? HyperLiquidEnvironment.GetEnvironmentByName(hyperLiquidEnvName)! : hyperLiquidRestOptions?.Value.Environment ?? HyperLiquidEnvironment.Live);
                krakenRestOptions = SetGlobalRestOptions(global, krakenRestOptions?.Value, credentials?.Kraken, environments?.TryGetValue(Exchange.Kraken, out var krakenEnvName) == true ? KrakenEnvironment.GetEnvironmentByName(krakenEnvName)! : krakenRestOptions?.Value.Environment ?? KrakenEnvironment.Live);
                kucoinRestOptions = SetGlobalRestOptions(global, kucoinRestOptions?.Value, credentials?.Kucoin, environments?.TryGetValue(Exchange.Kucoin, out var kucoinEnvName) == true ? KucoinEnvironment.GetEnvironmentByName(kucoinEnvName)! : kucoinRestOptions?.Value.Environment ?? KucoinEnvironment.Live);
                lighterRestOptions = SetGlobalRestOptions(global, lighterRestOptions?.Value, credentials?.Lighter, environments?.TryGetValue(Exchange.Lighter, out var lighterEnvName) == true ? LighterEnvironment.GetEnvironmentByName(lighterEnvName)! : lighterRestOptions?.Value.Environment ?? LighterEnvironment.Live);
                mexcRestOptions = SetGlobalRestOptions(global, mexcRestOptions?.Value, credentials?.Mexc, environments?.TryGetValue(Exchange.Mexc, out var mexcEnvName) == true ? MexcEnvironment.GetEnvironmentByName(mexcEnvName)! : mexcRestOptions?.Value.Environment ?? MexcEnvironment.Live);
                okxRestOptions = SetGlobalRestOptions(global, okxRestOptions?.Value, credentials?.OKX, environments?.TryGetValue(Exchange.OKX, out var okxEnvName) == true ? OKXEnvironment.GetEnvironmentByName(okxEnvName)! : okxRestOptions?.Value.Environment ?? OKXEnvironment.Live);
                pionexRestOptions = SetGlobalRestOptions(global, pionexRestOptions?.Value, credentials?.Pionex, environments?.TryGetValue(Exchange.Pionex, out var pionexEnvName) == true ? PionexEnvironment.GetEnvironmentByName(pionexEnvName)! : pionexRestOptions?.Value.Environment ?? PionexEnvironment.Live);
                polymarketRestOptions = SetGlobalRestOptions(global, polymarketRestOptions?.Value, credentials?.Polymarket, environments?.TryGetValue(Platform.Polymarket, out var polymarketEnvName) == true ? PolymarketEnvironment.GetEnvironmentByName(polymarketEnvName)! : polymarketRestOptions?.Value.Environment ?? PolymarketEnvironment.Live);
                toobitRestOptions = SetGlobalRestOptions(global, toobitRestOptions?.Value, credentials?.Toobit, environments?.TryGetValue(Exchange.Toobit, out var toobitEnvName) == true ? ToobitEnvironment.GetEnvironmentByName(toobitEnvName)! : toobitRestOptions?.Value.Environment ?? ToobitEnvironment.Live);
                upbitRestOptions = Options.Create(SetGlobalRestOptionsBase(global, upbitRestOptions?.Value, environments?.TryGetValue(Exchange.Upbit, out var upbitEnvName) == true ? UpbitEnvironment.GetEnvironmentByName(upbitEnvName)! : upbitRestOptions?.Value.Environment ?? UpbitEnvironment.Live) ?? new UpbitRestOptions());
                weexRestOptions = SetGlobalRestOptions(global, weexRestOptions?.Value, credentials?.Weex, environments?.TryGetValue(Exchange.Weex, out var weexEnvName) == true ? WeexEnvironment.GetEnvironmentByName(weexEnvName)! : weexRestOptions?.Value.Environment ?? WeexEnvironment.Live);
                whiteBitRestOptions = SetGlobalRestOptions(global, whiteBitRestOptions?.Value, credentials?.WhiteBit, environments?.TryGetValue(Exchange.WhiteBit, out var whiteBitEnvName) == true ? WhiteBitEnvironment.GetEnvironmentByName(whiteBitEnvName)! : whiteBitRestOptions?.Value.Environment ?? WhiteBitEnvironment.Live);
                xtRestOptions = SetGlobalRestOptions(global, xtRestOptions?.Value, credentials?.XT, environments?.TryGetValue(Exchange.XT, out var xtEnvName) == true ? XTEnvironment.GetEnvironmentByName(xtEnvName)! : xtRestOptions?.Value.Environment ?? XTEnvironment.Live);
            }

            Aster = new AsterRestClient(httpClient, loggerFactory, asterRestOptions ?? Options.Create(new AsterRestOptions()));
            Binance = new BinanceRestClient(httpClient, loggerFactory, binanceRestOptions ?? Options.Create(new BinanceRestOptions()));
            BingX = new BingXRestClient(httpClient, loggerFactory, bingxRestOptions ?? Options.Create(new BingXRestOptions()));
            Bitfinex = new BitfinexRestClient(httpClient, loggerFactory, bitfinexRestOptions ?? Options.Create(new BitfinexRestOptions()));
            Bitget = new BitgetRestClient(httpClient, loggerFactory, bitgetRestOptions ?? Options.Create(new BitgetRestOptions()));
            BitMart = new BitMartRestClient(httpClient, loggerFactory, bitMartRestOptions ?? Options.Create(new BitMartRestOptions()));
            BitMEX = new BitMEXRestClient(httpClient, loggerFactory, bitMEXRestOptions ?? Options.Create(new BitMEXRestOptions()));
            Bitstamp = new BitstampRestClient(httpClient, loggerFactory, bitstampRestOptions ?? Options.Create(new BitstampRestOptions()));
            BloFin = new BloFinRestClient(httpClient, loggerFactory, bloFinRestOptions ?? Options.Create(new BloFinRestOptions()));
            Bybit = new BybitRestClient(httpClient, loggerFactory, bybitRestOptions ?? Options.Create(new BybitRestOptions()));
            Coinbase = new CoinbaseRestClient(httpClient, loggerFactory, coinbaseRestOptions ?? Options.Create(new CoinbaseRestOptions()));
            CoinEx = new CoinExRestClient(httpClient, loggerFactory, coinExRestOptions ?? Options.Create(new CoinExRestOptions()));
            CoinGecko = new CoinGeckoRestClient(httpClient, loggerFactory, coinGeckoRestOptions ?? Options.Create(new CoinGeckoRestOptions()));
            CoinW = new CoinWRestClient(httpClient, loggerFactory, coinWRestOptions ?? Options.Create(new CoinWRestOptions()));
            CryptoCom = new CryptoComRestClient(httpClient, loggerFactory, cryptoComRestOptions ?? Options.Create(new CryptoComRestOptions()));
            DeepCoin = new DeepCoinRestClient(httpClient, loggerFactory, deepCoinRestOptions ?? Options.Create(new DeepCoinRestOptions()));
            GateIo = new GateIoRestClient(httpClient, loggerFactory, gateIoRestOptions ?? Options.Create(new GateIoRestOptions()));
            HTX = new HTXRestClient(httpClient, loggerFactory, htxRestOptions ?? Options.Create(new HTXRestOptions()));
            HyperLiquid = new HyperLiquidRestClient(httpClient, loggerFactory, hyperLiquidRestOptions ?? Options.Create(new HyperLiquidRestOptions()));
            Kraken = new KrakenRestClient(httpClient, loggerFactory, krakenRestOptions ?? Options.Create(new KrakenRestOptions()));
            Kucoin = new KucoinRestClient(httpClient, loggerFactory, kucoinRestOptions ?? Options.Create(new KucoinRestOptions()));
            Lighter = new LighterRestClient(httpClient, loggerFactory, lighterRestOptions ?? Options.Create(new LighterRestOptions()));
            Mexc = new MexcRestClient(httpClient, loggerFactory, mexcRestOptions ?? Options.Create(new MexcRestOptions()));
            OKX = new OKXRestClient(httpClient, loggerFactory, okxRestOptions ?? Options.Create(new OKXRestOptions()));
            Pionex = new PionexRestClient(httpClient, loggerFactory, pionexRestOptions ?? Options.Create(new PionexRestOptions()));
            Polymarket = new PolymarketRestClient(httpClient, loggerFactory, polymarketRestOptions ?? Options.Create(new PolymarketRestOptions()));
            Toobit = new ToobitRestClient(httpClient, loggerFactory, toobitRestOptions ?? Options.Create(new ToobitRestOptions()));
            Upbit = new UpbitRestClient(httpClient, loggerFactory, upbitRestOptions ?? Options.Create(new UpbitRestOptions()));
            Weex = new WeexRestClient(httpClient, loggerFactory, weexRestOptions ?? Options.Create(new WeexRestOptions()));
            WhiteBit = new WhiteBitRestClient(httpClient, loggerFactory, whiteBitRestOptions ?? Options.Create(new WhiteBitRestOptions()));
            XT = new XTRestClient(httpClient, loggerFactory, xtRestOptions ?? Options.Create(new XTRestOptions()));

            InitSharedClients();
        }

        private void InitSharedClients()
        {
            _restClients = [Aster, Binance, BingX, Bitfinex, Bitget, BitMart, BitMEX, Bitstamp, BloFin, Bybit, Coinbase, CoinEx, CoinW, CryptoCom,
                DeepCoin, GateIo, HTX, HyperLiquid, Kraken, Kucoin, Lighter, Mexc, OKX, Pionex, Toobit, Upbit, Weex, WhiteBit, XT];

            var v3Spot = Aster.SpotV3Api.ApiCredentials?.V3 != null;
            var v3Futures = Aster.FuturesV3Api.ApiCredentials?.V3 != null;
            ISharedClient asterSpot = v3Spot ? Aster.SpotV3Api.SharedClient : Aster.SpotApi.SharedClient;
            ISharedClient asterFutures = v3Futures ? Aster.FuturesV3Api.SharedClient : Aster.FuturesApi.SharedClient;

            _sharedClients = new ISharedClient[]
            {
                asterSpot,
                asterFutures,
                Binance.SpotApi.SharedClient,
                Binance.UsdFuturesApi.SharedClient,
                Binance.CoinFuturesApi.SharedClient,
                BingX.SpotApi.SharedClient,
                BingX.PerpetualFuturesApi.SharedClient,
                Bitfinex.ExchangeApi.SharedClient,
                Bitget.SpotApiV2.SharedClient,
                Bitget.FuturesApiV2.SharedClient,
                BitMart.SpotApi.SharedClient,
                BitMart.UsdFuturesApi.SharedClient,
                BitMEX.ExchangeApi.SharedClient,
                Bitstamp.ExchangeApi.SharedClient,
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
                Lighter.ExchangeApi.SharedClient,
                Mexc.SpotApi.SharedClient,
                Mexc.FuturesApi.SharedClient,
                OKX.UnifiedApi.SharedClient,
                Pionex.SpotApi.SharedClient,
                Toobit.SpotApi.SharedClient,
                Toobit.UsdtFuturesApi.SharedClient,
                Upbit.SpotApi.SharedClient,
                Weex.SpotApi.SharedClient,
                Weex.FuturesApi.SharedClient,
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
            IBitstampRestClient bitstamp,
            IBloFinRestClient bloFin,
            IBybitRestClient bybit,
            ICoinbaseRestClient coinbase,
            ICoinExRestClient coinEx,
            ICoinGeckoRestClient coinGecko,
            ICoinWRestClient coinW,
            ICryptoComRestClient cryptoCom,
            IDeepCoinRestClient deepCoin,
            IGateIoRestClient gateIo,
            IHTXRestClient htx,
            IHyperLiquidRestClient hyperLiquid,
            IKrakenRestClient kraken,
            IKucoinRestClient kucoin,
            ILighterRestClient lighter,
            IMexcRestClient mexc,
            IOKXRestClient okx,
            IPionexRestClient pionex,
            IPolymarketRestClient polymarket,
            IToobitRestClient toobit,
            IUpbitRestClient upbit,
            IWeexRestClient weex,
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
            Bitstamp = bitstamp;
            BloFin = bloFin;
            Bybit = bybit;
            Coinbase = coinbase;
            CoinEx = coinEx;
            CoinGecko = coinGecko;
            CoinW = coinW;
            CryptoCom = cryptoCom;
            DeepCoin = deepCoin;
            GateIo = gateIo;
            HTX = htx;
            HyperLiquid = hyperLiquid;
            Kraken = kraken;
            Kucoin = kucoin;
            Lighter = lighter;
            Mexc = mexc;
            OKX = okx;
            Pionex = pionex;
            Polymarket = polymarket;
            Toobit = toobit;
            Upbit = upbit;
            Weex = weex;
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
        public void SetApiCredentials(string exchange, DynamicCredentials credentials)
        {
            SetApiCredentials(
                ExchangeCredentials.CreateFrom(exchange,
                    ExchangeCredentials.CreateCredentialsForExchange(exchange, credentials)));
        }

        /// <inheritdoc />
        public void SetApiCredentials(ExchangeCredentials credentials)
        {
            void SetCredentialsIfNotNull(string exchange, ApiCredentials? credentials, Action setter)
            {
                if (credentials == null)
                    return;

                setter();
            }

            SetCredentialsIfNotNull(Exchange.Aster, credentials.Aster, () => Aster.SetApiCredentials(credentials.Aster!));
            SetCredentialsIfNotNull(Exchange.Binance, credentials.Binance, () => Binance.SetApiCredentials(credentials.Binance!));
            SetCredentialsIfNotNull(Exchange.BingX, credentials.BingX, () => BingX.SetApiCredentials(credentials.BingX!));
            SetCredentialsIfNotNull(Exchange.Bitfinex, credentials.Bitfinex, () => Bitfinex.SetApiCredentials(credentials.Bitfinex!));
            SetCredentialsIfNotNull(Exchange.Bitget, credentials.Bitget, () => Bitget.SetApiCredentials(credentials.Bitget!));
            SetCredentialsIfNotNull(Exchange.BitMart, credentials.BitMart, () => BitMart.SetApiCredentials(credentials.BitMart!));
            SetCredentialsIfNotNull(Exchange.BitMEX, credentials.BitMEX, () => BitMEX.SetApiCredentials(credentials.BitMEX!));
            SetCredentialsIfNotNull(Exchange.BloFin, credentials.BloFin, () => BloFin.SetApiCredentials(credentials.BloFin!));
            SetCredentialsIfNotNull(Exchange.Bitstamp, credentials.Bitstamp, () => Bitstamp.SetApiCredentials(credentials.Bitstamp!));
            SetCredentialsIfNotNull(Exchange.Bybit, credentials.Bybit, () => Bybit.SetApiCredentials(credentials.Bybit!));
            SetCredentialsIfNotNull(Exchange.Coinbase, credentials.Coinbase, () => Coinbase.SetApiCredentials(credentials.Coinbase!));
            SetCredentialsIfNotNull(Exchange.CoinEx, credentials.CoinEx, () => CoinEx.SetApiCredentials(credentials.CoinEx!));
            SetCredentialsIfNotNull(Platform.CoinGecko, credentials.CoinGecko, () => CoinGecko.SetApiCredentials(credentials.CoinGecko!));
            SetCredentialsIfNotNull(Exchange.CoinW, credentials.CoinW, () => CoinW.SetApiCredentials(credentials.CoinW!));
            SetCredentialsIfNotNull(Exchange.CryptoCom, credentials.CryptoCom, () => CryptoCom.SetApiCredentials(credentials.CryptoCom!));
            SetCredentialsIfNotNull(Exchange.DeepCoin, credentials.DeepCoin, () => DeepCoin.SetApiCredentials(credentials.DeepCoin!));
            SetCredentialsIfNotNull(Exchange.GateIo, credentials.GateIo, () => GateIo.SetApiCredentials(credentials.GateIo!));
            SetCredentialsIfNotNull(Exchange.HTX, credentials.HTX, () => HTX.SetApiCredentials(credentials.HTX!));
            SetCredentialsIfNotNull(Exchange.HyperLiquid, credentials.HyperLiquid, () => HyperLiquid.SetApiCredentials(credentials.HyperLiquid!));
            SetCredentialsIfNotNull(Exchange.Kraken, credentials.Kraken, () => Kraken.SetApiCredentials(credentials.Kraken!));
            SetCredentialsIfNotNull(Exchange.Kucoin, credentials.Kucoin, () => Kucoin.SetApiCredentials(credentials.Kucoin!));
            SetCredentialsIfNotNull(Exchange.Lighter, credentials.Lighter, () => Lighter.SetApiCredentials(credentials.Lighter!));
            SetCredentialsIfNotNull(Exchange.Mexc, credentials.Mexc, () => Mexc.SetApiCredentials(credentials.Mexc!));
            SetCredentialsIfNotNull(Exchange.OKX, credentials.OKX, () => OKX.SetApiCredentials(credentials.OKX!));
            SetCredentialsIfNotNull(Exchange.Pionex, credentials.Pionex, () => Pionex.SetApiCredentials(credentials.Pionex!));
            SetCredentialsIfNotNull(Platform.Polymarket, credentials.Polymarket, () => Polymarket.SetApiCredentials(credentials.Polymarket!));
            SetCredentialsIfNotNull(Exchange.Toobit, credentials.Toobit, () => Toobit.SetApiCredentials(credentials.Toobit!));
            SetCredentialsIfNotNull(Exchange.Weex, credentials.Weex, () => Weex.SetApiCredentials(credentials.Weex!));
            SetCredentialsIfNotNull(Exchange.WhiteBit, credentials.WhiteBit, () => WhiteBit.SetApiCredentials(credentials.WhiteBit!));
            SetCredentialsIfNotNull(Exchange.XT, credentials.XT, () => XT.SetApiCredentials(credentials.XT!));
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

        /// <summary>
        /// Apply the options delegate to a new options instance
        /// </summary>
        protected static T ApplyOptionsDelegate<T>(Action<T>? del) where T : new()
        {
            var opts = new T();
            del?.Invoke(opts);
            return opts;
        }
    }
}
