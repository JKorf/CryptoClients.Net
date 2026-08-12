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
using LBank.Net;
using LBank.Net.Clients;
using LBank.Net.Interfaces.Clients;
using LBank.Net.Objects.Options;
using Lighter.Net;
using Lighter.Net.Clients;
using Lighter.Net.Interfaces.Clients;
using Lighter.Net.Objects.Options;
using Mexc.Net;
using Mexc.Net.Clients;
using Mexc.Net.Interfaces.Clients;
using Mexc.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
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
using System.Net.Http;
using System.Threading;
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
        /// <inheritdoc />
        public int TotalRequestsMade => _clientRegistrations.Values.Where(x => x.IsValueCreated).Sum(x => x.Client.TotalRequestsMade);

        /// <inheritdoc />
        public IAsterRestClient Aster => GetClient(Exchange.Aster, _aster);
        /// <inheritdoc />
        public IBinanceRestClient Binance => GetClient(Exchange.Binance, _binance);
        /// <inheritdoc />
        public IBingXRestClient BingX => GetClient(Exchange.BingX, _bingX);
        /// <inheritdoc />
        public IBitfinexRestClient Bitfinex => GetClient(Exchange.Bitfinex, _bitfinex);
        /// <inheritdoc />
        public IBitgetRestClient Bitget => GetClient(Exchange.Bitget, _bitget);
        /// <inheritdoc />
        public IBitMartRestClient BitMart => GetClient(Exchange.BitMart, _bitMart);
        /// <inheritdoc />
        public IBitMEXRestClient BitMEX => GetClient(Exchange.BitMEX, _bitMEX);
        /// <inheritdoc />
        public IBitstampRestClient Bitstamp => GetClient(Exchange.Bitstamp, _bitstamp);
        /// <inheritdoc />
        public IBloFinRestClient BloFin => GetClient(Exchange.BloFin, _bloFin);
        /// <inheritdoc />
        public IBybitRestClient Bybit => GetClient(Exchange.Bybit, _bybit);
        /// <inheritdoc />
        public ICoinbaseRestClient Coinbase => GetClient(Exchange.Coinbase, _coinbase);
        /// <inheritdoc />
        public ICoinExRestClient CoinEx => GetClient(Exchange.CoinEx, _coinEx);
        /// <inheritdoc />
        public ICoinGeckoRestClient CoinGecko => GetClient(Platform.CoinGecko, _coinGecko);
        /// <inheritdoc />
        public ICoinWRestClient CoinW => GetClient(Exchange.CoinW, _coinW);
        /// <inheritdoc />
        public ICryptoComRestClient CryptoCom => GetClient(Exchange.CryptoCom, _cryptoCom);
        /// <inheritdoc />
        public IDeepCoinRestClient DeepCoin => GetClient(Exchange.DeepCoin, _deepCoin);
        /// <inheritdoc />
        public IGateIoRestClient GateIo => GetClient(Exchange.GateIo, _gateIo);
        /// <inheritdoc />
        public IHTXRestClient HTX => GetClient(Exchange.HTX, _htx);
        /// <inheritdoc />
        public IHyperLiquidRestClient HyperLiquid => GetClient(Exchange.HyperLiquid, _hyperLiquid);
        /// <inheritdoc />
        public IKrakenRestClient Kraken => GetClient(Exchange.Kraken, _kraken);
        /// <inheritdoc />
        public IKucoinRestClient Kucoin => GetClient(Exchange.Kucoin, _kucoin);
        /// <inheritdoc />
        public ILBankRestClient LBank => GetClient(Exchange.LBank, _lBank);
        /// <inheritdoc />
        public ILighterRestClient Lighter => GetClient(Exchange.Lighter, _lighter);
        /// <inheritdoc />
        public IMexcRestClient Mexc => GetClient(Exchange.Mexc, _mexc);
        /// <inheritdoc />
        public IOKXRestClient OKX => GetClient(Exchange.OKX, _okx);
        /// <inheritdoc />
        public IPionexRestClient Pionex => GetClient(Exchange.Pionex, _pionex);
        /// <inheritdoc />
        public IPolymarketRestClient Polymarket => GetClient(Platform.Polymarket, _polymarket);
        /// <inheritdoc />
        public IToobitRestClient Toobit => GetClient(Exchange.Toobit, _toobit);
        /// <inheritdoc />
        public IUpbitRestClient Upbit => GetClient(Exchange.Upbit, _upbit);
        /// <inheritdoc />
        public IWeexRestClient Weex => GetClient(Exchange.Weex, _weex);
        /// <inheritdoc />
        public IWhiteBitRestClient WhiteBit => GetClient(Exchange.WhiteBit, _whiteBit);
        /// <inheritdoc />
        public IXTRestClient XT => GetClient(Exchange.XT, _xt);

        private readonly Dictionary<string, IRestClientRegistration> _clientRegistrations = new(StringComparer.OrdinalIgnoreCase);
        private HashSet<string>? _enabledExchanges;
        private IEnumerable<ISharedClient> _sharedClients => _clientRegistrations.Where(x => IsEnabled(x.Key)).SelectMany(x => x.Value.SharedClients);
        private RestClientRegistration<IAsterRestClient> _aster = null!;
        private RestClientRegistration<IBinanceRestClient> _binance = null!;
        private RestClientRegistration<IBingXRestClient> _bingX = null!;
        private RestClientRegistration<IBitfinexRestClient> _bitfinex = null!;
        private RestClientRegistration<IBitgetRestClient> _bitget = null!;
        private RestClientRegistration<IBitMartRestClient> _bitMart = null!;
        private RestClientRegistration<IBitMEXRestClient> _bitMEX = null!;
        private RestClientRegistration<IBitstampRestClient> _bitstamp = null!;
        private RestClientRegistration<IBloFinRestClient> _bloFin = null!;
        private RestClientRegistration<IBybitRestClient> _bybit = null!;
        private RestClientRegistration<ICoinbaseRestClient> _coinbase = null!;
        private RestClientRegistration<ICoinExRestClient> _coinEx = null!;
        private RestClientRegistration<ICoinGeckoRestClient> _coinGecko = null!;
        private RestClientRegistration<ICoinWRestClient> _coinW = null!;
        private RestClientRegistration<ICryptoComRestClient> _cryptoCom = null!;
        private RestClientRegistration<IDeepCoinRestClient> _deepCoin = null!;
        private RestClientRegistration<IGateIoRestClient> _gateIo = null!;
        private RestClientRegistration<IHTXRestClient> _htx = null!;
        private RestClientRegistration<IHyperLiquidRestClient> _hyperLiquid = null!;
        private RestClientRegistration<IKrakenRestClient> _kraken = null!;
        private RestClientRegistration<IKucoinRestClient> _kucoin = null!;
        private RestClientRegistration<ILBankRestClient> _lBank = null!;
        private RestClientRegistration<ILighterRestClient> _lighter = null!;
        private RestClientRegistration<IMexcRestClient> _mexc = null!;
        private RestClientRegistration<IOKXRestClient> _okx = null!;
        private RestClientRegistration<IPionexRestClient> _pionex = null!;
        private RestClientRegistration<IPolymarketRestClient> _polymarket = null!;
        private RestClientRegistration<IToobitRestClient> _toobit = null!;
        private RestClientRegistration<IUpbitRestClient> _upbit = null!;
        private RestClientRegistration<IWeexRestClient> _weex = null!;
        private RestClientRegistration<IWhiteBitRestClient> _whiteBit = null!;
        private RestClientRegistration<IXTRestClient> _xt = null!;

        /// <summary>
        /// Create a new ExchangeRestClient instance. Client instances will be created with default options.
        /// </summary>
        public ExchangeRestClient()
        {
            InitializeClients(null,
                () => new AsterRestClient(), () => new BinanceRestClient(), () => new BingXRestClient(), () => new BitfinexRestClient(),
                () => new BitgetRestClient(), () => new BitMartRestClient(), () => new BitMEXRestClient(), () => new BitstampRestClient(),
                () => new BloFinRestClient(), () => new BybitRestClient(), () => new CoinbaseRestClient(), () => new CoinExRestClient(),
                () => new CoinGeckoRestClient(), () => new CoinWRestClient(), () => new CryptoComRestClient(), () => new DeepCoinRestClient(),
                () => new GateIoRestClient(), () => new HTXRestClient(), () => new HyperLiquidRestClient(), () => new KrakenRestClient(),
                () => new KucoinRestClient(), () => new LBankRestClient(), () => new LighterRestClient(), () => new MexcRestClient(),
                () => new OKXRestClient(), () => new PionexRestClient(), () => new PolymarketRestClient(), () => new ToobitRestClient(),
                () => new UpbitRestClient(), () => new WeexRestClient(), () => new WhiteBitRestClient(), () => new XTRestClient());
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
            Action<LBankRestOptions>? lBankRestOptions = null,
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
                Options.Create(ApplyOptionsDelegate(lBankRestOptions)),
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
            IOptions<LBankRestOptions>? lBankRestOptions = null,
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
                lBankRestOptions = SetGlobalRestOptions(global, lBankRestOptions?.Value, credentials?.LBank, environments?.TryGetValue(Exchange.LBank, out var lBankEnvName) == true ? LBankEnvironment.GetEnvironmentByName(lBankEnvName)! : lBankRestOptions?.Value.Environment ?? LBankEnvironment.Live);
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

            InitializeClients(globalOptions?.Value.EnabledExchanges,
                () => new AsterRestClient(httpClient, loggerFactory, asterRestOptions ?? Options.Create(new AsterRestOptions())),
                () => new BinanceRestClient(httpClient, loggerFactory, binanceRestOptions ?? Options.Create(new BinanceRestOptions())),
                () => new BingXRestClient(httpClient, loggerFactory, bingxRestOptions ?? Options.Create(new BingXRestOptions())),
                () => new BitfinexRestClient(httpClient, loggerFactory, bitfinexRestOptions ?? Options.Create(new BitfinexRestOptions())),
                () => new BitgetRestClient(httpClient, loggerFactory, bitgetRestOptions ?? Options.Create(new BitgetRestOptions())),
                () => new BitMartRestClient(httpClient, loggerFactory, bitMartRestOptions ?? Options.Create(new BitMartRestOptions())),
                () => new BitMEXRestClient(httpClient, loggerFactory, bitMEXRestOptions ?? Options.Create(new BitMEXRestOptions())),
                () => new BitstampRestClient(httpClient, loggerFactory, bitstampRestOptions ?? Options.Create(new BitstampRestOptions())),
                () => new BloFinRestClient(httpClient, loggerFactory, bloFinRestOptions ?? Options.Create(new BloFinRestOptions())),
                () => new BybitRestClient(httpClient, loggerFactory, bybitRestOptions ?? Options.Create(new BybitRestOptions())),
                () => new CoinbaseRestClient(httpClient, loggerFactory, coinbaseRestOptions ?? Options.Create(new CoinbaseRestOptions())),
                () => new CoinExRestClient(httpClient, loggerFactory, coinExRestOptions ?? Options.Create(new CoinExRestOptions())),
                () => new CoinGeckoRestClient(httpClient, loggerFactory, coinGeckoRestOptions ?? Options.Create(new CoinGeckoRestOptions())),
                () => new CoinWRestClient(httpClient, loggerFactory, coinWRestOptions ?? Options.Create(new CoinWRestOptions())),
                () => new CryptoComRestClient(httpClient, loggerFactory, cryptoComRestOptions ?? Options.Create(new CryptoComRestOptions())),
                () => new DeepCoinRestClient(httpClient, loggerFactory, deepCoinRestOptions ?? Options.Create(new DeepCoinRestOptions())),
                () => new GateIoRestClient(httpClient, loggerFactory, gateIoRestOptions ?? Options.Create(new GateIoRestOptions())),
                () => new HTXRestClient(httpClient, loggerFactory, htxRestOptions ?? Options.Create(new HTXRestOptions())),
                () => new HyperLiquidRestClient(httpClient, loggerFactory, hyperLiquidRestOptions ?? Options.Create(new HyperLiquidRestOptions())),
                () => new KrakenRestClient(httpClient, loggerFactory, krakenRestOptions ?? Options.Create(new KrakenRestOptions())),
                () => new KucoinRestClient(httpClient, loggerFactory, kucoinRestOptions ?? Options.Create(new KucoinRestOptions())),
                () => new LBankRestClient(httpClient, loggerFactory, lBankRestOptions ?? Options.Create(new LBankRestOptions())),
                () => new LighterRestClient(httpClient, loggerFactory, lighterRestOptions ?? Options.Create(new LighterRestOptions())),
                () => new MexcRestClient(httpClient, loggerFactory, mexcRestOptions ?? Options.Create(new MexcRestOptions())),
                () => new OKXRestClient(httpClient, loggerFactory, okxRestOptions ?? Options.Create(new OKXRestOptions())),
                () => new PionexRestClient(httpClient, loggerFactory, pionexRestOptions ?? Options.Create(new PionexRestOptions())),
                () => new PolymarketRestClient(httpClient, loggerFactory, polymarketRestOptions ?? Options.Create(new PolymarketRestOptions())),
                () => new ToobitRestClient(httpClient, loggerFactory, toobitRestOptions ?? Options.Create(new ToobitRestOptions())),
                () => new UpbitRestClient(httpClient, loggerFactory, upbitRestOptions ?? Options.Create(new UpbitRestOptions())),
                () => new WeexRestClient(httpClient, loggerFactory, weexRestOptions ?? Options.Create(new WeexRestOptions())),
                () => new WhiteBitRestClient(httpClient, loggerFactory, whiteBitRestOptions ?? Options.Create(new WhiteBitRestOptions())),
                () => new XTRestClient(httpClient, loggerFactory, xtRestOptions ?? Options.Create(new XTRestOptions())));
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
            ILBankRestClient lBank,
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
            InitializeClients(null,
                () => aster, () => binance, () => bingx, () => bitfinex, () => bitget, () => bitMart, () => bitMEX, () => bitstamp,
                () => bloFin, () => bybit, () => coinbase, () => coinEx, () => coinGecko, () => coinW, () => cryptoCom, () => deepCoin,
                () => gateIo, () => htx, () => hyperLiquid, () => kraken, () => kucoin, () => lBank, () => lighter, () => mexc,
                () => okx, () => pionex, () => polymarket, () => toobit, () => upbit, () => weex, () => whiteBit, () => xt);
        }

        internal ExchangeRestClient(IEnumerable<string>? enabledExchanges, IServiceProvider serviceProvider)
        {
            InitializeClients(enabledExchanges,
                () => serviceProvider.GetRequiredService<IAsterRestClient>(), () => serviceProvider.GetRequiredService<IBinanceRestClient>(),
                () => serviceProvider.GetRequiredService<IBingXRestClient>(), () => serviceProvider.GetRequiredService<IBitfinexRestClient>(),
                () => serviceProvider.GetRequiredService<IBitgetRestClient>(), () => serviceProvider.GetRequiredService<IBitMartRestClient>(),
                () => serviceProvider.GetRequiredService<IBitMEXRestClient>(), () => serviceProvider.GetRequiredService<IBitstampRestClient>(),
                () => serviceProvider.GetRequiredService<IBloFinRestClient>(), () => serviceProvider.GetRequiredService<IBybitRestClient>(),
                () => serviceProvider.GetRequiredService<ICoinbaseRestClient>(), () => serviceProvider.GetRequiredService<ICoinExRestClient>(),
                () => serviceProvider.GetRequiredService<ICoinGeckoRestClient>(), () => serviceProvider.GetRequiredService<ICoinWRestClient>(),
                () => serviceProvider.GetRequiredService<ICryptoComRestClient>(), () => serviceProvider.GetRequiredService<IDeepCoinRestClient>(),
                () => serviceProvider.GetRequiredService<IGateIoRestClient>(), () => serviceProvider.GetRequiredService<IHTXRestClient>(),
                () => serviceProvider.GetRequiredService<IHyperLiquidRestClient>(), () => serviceProvider.GetRequiredService<IKrakenRestClient>(),
                () => serviceProvider.GetRequiredService<IKucoinRestClient>(), () => serviceProvider.GetRequiredService<ILBankRestClient>(),
                () => serviceProvider.GetRequiredService<ILighterRestClient>(), () => serviceProvider.GetRequiredService<IMexcRestClient>(),
                () => serviceProvider.GetRequiredService<IOKXRestClient>(), () => serviceProvider.GetRequiredService<IPionexRestClient>(),
                () => serviceProvider.GetRequiredService<IPolymarketRestClient>(), () => serviceProvider.GetRequiredService<IToobitRestClient>(),
                () => serviceProvider.GetRequiredService<IUpbitRestClient>(), () => serviceProvider.GetRequiredService<IWeexRestClient>(),
                () => serviceProvider.GetRequiredService<IWhiteBitRestClient>(), () => serviceProvider.GetRequiredService<IXTRestClient>());
        }

        internal ExchangeRestClient(
            IEnumerable<string>? enabledExchanges,
            Func<IAsterRestClient> aster, Func<IBinanceRestClient> binance, Func<IBingXRestClient> bingX, Func<IBitfinexRestClient> bitfinex,
            Func<IBitgetRestClient> bitget, Func<IBitMartRestClient> bitMart, Func<IBitMEXRestClient> bitMEX, Func<IBitstampRestClient> bitstamp,
            Func<IBloFinRestClient> bloFin, Func<IBybitRestClient> bybit, Func<ICoinbaseRestClient> coinbase, Func<ICoinExRestClient> coinEx,
            Func<ICoinGeckoRestClient> coinGecko, Func<ICoinWRestClient> coinW, Func<ICryptoComRestClient> cryptoCom, Func<IDeepCoinRestClient> deepCoin,
            Func<IGateIoRestClient> gateIo, Func<IHTXRestClient> htx, Func<IHyperLiquidRestClient> hyperLiquid, Func<IKrakenRestClient> kraken,
            Func<IKucoinRestClient> kucoin, Func<ILBankRestClient> lBank, Func<ILighterRestClient> lighter, Func<IMexcRestClient> mexc,
            Func<IOKXRestClient> okx, Func<IPionexRestClient> pionex, Func<IPolymarketRestClient> polymarket, Func<IToobitRestClient> toobit,
            Func<IUpbitRestClient> upbit, Func<IWeexRestClient> weex, Func<IWhiteBitRestClient> whiteBit, Func<IXTRestClient> xt)
        {
            InitializeClients(enabledExchanges,
                aster, binance, bingX, bitfinex, bitget, bitMart, bitMEX, bitstamp, bloFin, bybit, coinbase, coinEx,
                coinGecko, coinW, cryptoCom, deepCoin, gateIo, htx, hyperLiquid, kraken, kucoin, lBank, lighter, mexc,
                okx, pionex, polymarket, toobit, upbit, weex, whiteBit, xt);
        }

        /// <inheritdoc />
        public IEnumerable<ISharedClient> GetExchangeSharedClients(string name, TradingMode? tradingMode = null)
        {
            var result = GetSharedClients(name);
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
                if (credentials == null || !IsEnabled(exchange))
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
            SetCredentialsIfNotNull(Exchange.LBank, credentials.LBank, () => LBank.SetApiCredentials(credentials.LBank!));
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
            var client = GetSharedClients(exchange).FirstOrDefault(x => x.SupportedTradingModes.Contains(symbol.TradingMode));
            if (client == null)
                return null;

            return symbol.GetSymbol(client.FormatSymbol);
        }

        /// <inheritdoc />
        public string? GenerateClientOrderId(TradingMode tradingMode, string exchange)
        {
            if (tradingMode == TradingMode.Spot)
            {
                var spotClient = GetSharedClients(exchange).SpotOrderRestClient();
                return spotClient?.GenerateClientOrderId();
            }

            var futuresClient = GetSharedClients(exchange).FuturesOrderRestClient(tradingMode);
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

        private void InitializeClients(
            IEnumerable<string>? enabledExchanges,
            Func<IAsterRestClient> aster, Func<IBinanceRestClient> binance, Func<IBingXRestClient> bingX, Func<IBitfinexRestClient> bitfinex,
            Func<IBitgetRestClient> bitget, Func<IBitMartRestClient> bitMart, Func<IBitMEXRestClient> bitMEX, Func<IBitstampRestClient> bitstamp,
            Func<IBloFinRestClient> bloFin, Func<IBybitRestClient> bybit, Func<ICoinbaseRestClient> coinbase, Func<ICoinExRestClient> coinEx,
            Func<ICoinGeckoRestClient> coinGecko, Func<ICoinWRestClient> coinW, Func<ICryptoComRestClient> cryptoCom, Func<IDeepCoinRestClient> deepCoin,
            Func<IGateIoRestClient> gateIo, Func<IHTXRestClient> htx, Func<IHyperLiquidRestClient> hyperLiquid, Func<IKrakenRestClient> kraken,
            Func<IKucoinRestClient> kucoin, Func<ILBankRestClient> lBank, Func<ILighterRestClient> lighter, Func<IMexcRestClient> mexc,
            Func<IOKXRestClient> okx, Func<IPionexRestClient> pionex, Func<IPolymarketRestClient> polymarket, Func<IToobitRestClient> toobit,
            Func<IUpbitRestClient> upbit, Func<IWeexRestClient> weex, Func<IWhiteBitRestClient> whiteBit, Func<IXTRestClient> xt)
        {
            _enabledExchanges = enabledExchanges == null ? null : new HashSet<string>(enabledExchanges, StringComparer.OrdinalIgnoreCase);

            RestClientRegistration<T> Register<T>(string name, Func<T> clientFactory, Func<T, ISharedClient[]> sharedClientFactory) where T : IRestClient
            {
                var registration = new RestClientRegistration<T>(clientFactory, sharedClientFactory);
                _clientRegistrations[name] = registration;
                return registration;
            }

            _aster = Register(Exchange.Aster, aster, x =>
            {
                ISharedClient spot = x.SpotV3Api.ApiCredentials?.V3 != null ? x.SpotV3Api.SharedClient : x.SpotApi.SharedClient;
                ISharedClient futures = x.FuturesV3Api.ApiCredentials?.V3 != null ? x.FuturesV3Api.SharedClient : x.FuturesApi.SharedClient;
                return [spot, futures];
            });
            _binance = Register(Exchange.Binance, binance, x => [x.SpotApi.SharedClient, x.UsdFuturesApi.SharedClient, x.CoinFuturesApi.SharedClient]);
            _bingX = Register(Exchange.BingX, bingX, x => [x.SpotApi.SharedClient, x.PerpetualFuturesApi.SharedClient]);
            _bitfinex = Register(Exchange.Bitfinex, bitfinex, x => [x.ExchangeApi.SharedClient]);
            _bitget = Register(Exchange.Bitget, bitget, x => [x.SpotApiV2.SharedClient, x.FuturesApiV2.SharedClient]);
            _bitMart = Register(Exchange.BitMart, bitMart, x => [x.SpotApi.SharedClient, x.UsdFuturesApi.SharedClient]);
            _bitMEX = Register(Exchange.BitMEX, bitMEX, x => [x.ExchangeApi.SharedClient]);
            _bitstamp = Register(Exchange.Bitstamp, bitstamp, x => [x.ExchangeApi.SharedClient]);
            _bloFin = Register(Exchange.BloFin, bloFin, x => [x.FuturesApi.SharedClient, x.AccountApi.SharedClient]);
            _bybit = Register(Exchange.Bybit, bybit, x => [x.V5Api.SharedClient]);
            _coinbase = Register(Exchange.Coinbase, coinbase, x => [x.AdvancedTradeApi.SharedClient]);
            _coinEx = Register(Exchange.CoinEx, coinEx, x => [x.SpotApiV2.SharedClient, x.FuturesApi.SharedClient]);
            _coinGecko = Register(Platform.CoinGecko, coinGecko, client => []);
            _coinW = Register(Exchange.CoinW, coinW, x => [x.SpotApi.SharedClient, x.FuturesApi.SharedClient]);
            _cryptoCom = Register(Exchange.CryptoCom, cryptoCom, x => [x.ExchangeApi.SharedClient]);
            _deepCoin = Register(Exchange.DeepCoin, deepCoin, x => [x.ExchangeApi.SharedClient]);
            _gateIo = Register(Exchange.GateIo, gateIo, x => [x.SpotApi.SharedClient, x.PerpetualFuturesApi.SharedClient]);
            _htx = Register(Exchange.HTX, htx, x => [x.SpotApi.SharedClient, x.UsdtFuturesApi.SharedClient]);
            _hyperLiquid = Register(Exchange.HyperLiquid, hyperLiquid, x => [x.SpotApi.SharedClient, x.FuturesApi.SharedClient]);
            _kraken = Register(Exchange.Kraken, kraken, x => [x.SpotApi.SharedClient, x.FuturesApi.SharedClient]);
            _kucoin = Register(Exchange.Kucoin, kucoin, x => [x.SpotApi.SharedClient, x.FuturesApi.SharedClient]);
            _lBank = Register(Exchange.LBank, lBank, x => [x.SpotApi.SharedClient]);
            _lighter = Register(Exchange.Lighter, lighter, x => [x.ExchangeApi.SharedClient]);
            _mexc = Register(Exchange.Mexc, mexc, x => [x.SpotApi.SharedClient, x.FuturesApi.SharedClient]);
            _okx = Register(Exchange.OKX, okx, x => [x.UnifiedApi.SharedClient]);
            _pionex = Register(Exchange.Pionex, pionex, x => [x.SpotApi.SharedClient]);
            _polymarket = Register(Platform.Polymarket, polymarket, client => []);
            _toobit = Register(Exchange.Toobit, toobit, x => [x.SpotApi.SharedClient, x.UsdtFuturesApi.SharedClient]);
            _upbit = Register(Exchange.Upbit, upbit, x => [x.SpotApi.SharedClient]);
            _weex = Register(Exchange.Weex, weex, x => [x.SpotApi.SharedClient, x.FuturesApi.SharedClient]);
            _whiteBit = Register(Exchange.WhiteBit, whiteBit, x => [x.V4Api.SharedClient]);
            _xt = Register(Exchange.XT, xt, x => [x.SpotApi.SharedClient, x.CoinFuturesApi.SharedClient, x.UsdtFuturesApi.SharedClient]);
        }

        private bool IsEnabled(string name) => _enabledExchanges == null || _enabledExchanges.Contains(name);

        private IEnumerable<ISharedClient> GetSharedClients(string name)
            => IsEnabled(name) && _clientRegistrations.TryGetValue(name, out var registration) ? registration.SharedClients : [];

        private IEnumerable<T> GetSharedClients<T>(IEnumerable<string>? exchanges) where T : ISharedClient
        {
            if (exchanges == null)
                return _sharedClients.OfType<T>();

            var requestedExchanges = new HashSet<string>(exchanges, StringComparer.OrdinalIgnoreCase);
            return _clientRegistrations
                .Where(x => IsEnabled(x.Key) && requestedExchanges.Contains(x.Key))
                .SelectMany(x => x.Value.SharedClients)
                .OfType<T>();
        }

#pragma warning disable IL2091
        private T GetClient<T>(string name, RestClientRegistration<T> registration) where T : IRestClient
        {
            if (!IsEnabled(name))
                throw new InvalidOperationException($"The {name} client is disabled. Add it to {nameof(GlobalExchangeOptions.EnabledExchanges)} before accessing it.");

            return registration.TypedClient;
        }

        private interface IRestClientRegistration
        {
            bool IsValueCreated { get; }
            IRestClient Client { get; }
            IEnumerable<ISharedClient> SharedClients { get; }
        }

        private class RestClientRegistration<T> : IRestClientRegistration where T : IRestClient
        {
            public bool IsValueCreated => _value.IsValueCreated;
            public T TypedClient => _value.Value.Client;
            public IRestClient Client => _value.Value.Client;
            public IEnumerable<ISharedClient> SharedClients => _value.Value.SharedClients;

            private readonly Lazy<(T Client, ISharedClient[] SharedClients)> _value;

            public RestClientRegistration(Func<T> clientFactory, Func<T, ISharedClient[]> sharedClientFactory)
            {
                _value = new Lazy<(T Client, ISharedClient[] SharedClients)>(() =>
                {
                    var client = clientFactory();
                    return (client, sharedClientFactory(client));
                }, LazyThreadSafetyMode.ExecutionAndPublication);
            }
        }
#pragma warning restore IL2091
    }
}
