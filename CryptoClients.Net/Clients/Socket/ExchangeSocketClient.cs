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
using CoinEx.Net.Objects.Options;
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
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.Objects.Sockets;
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
using Pionex.Net;
using Pionex.Net.Clients;
using Pionex.Net.Interfaces.Clients;
using Pionex.Net.Objects.Options;
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
using CryptoExchange.Net.Interfaces.Clients;
using Polymarket.Net.Interfaces.Clients;
using Polymarket.Net.Clients;
using Polymarket.Net.Objects.Options;
using Polymarket.Net;
using Bitstamp.Net.Objects.Options;
using Bitstamp.Net.Clients;
using Bitstamp.Net.Interfaces.Clients;
using Bitstamp.Net;
using Weex.Net.Objects.Options;
using Weex.Net.Clients;
using Weex.Net.Interfaces.Clients;
using Weex.Net;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public partial class ExchangeSocketClient : IExchangeSocketClient
    {
        /// <inheritdoc />
        public double IncomingKbps => _clientRegistrations.Values.Where(x => x.IsValueCreated).Sum(x => x.Client.IncomingKbps);
        /// <inheritdoc />
        public int CurrentConnections => _clientRegistrations.Values.Where(x => x.IsValueCreated).Sum(x => x.Client.CurrentConnections);
        /// <inheritdoc />
        public int CurrentSubscriptions => _clientRegistrations.Values.Where(x => x.IsValueCreated).Sum(x => x.Client.CurrentSubscriptions);

        /// <inheritdoc />
        public IAsterSocketClient Aster => GetClient(Exchange.Aster, _aster);
        /// <inheritdoc />
        public IBinanceSocketClient Binance => GetClient(Exchange.Binance, _binance);
        /// <inheritdoc />
        public IBingXSocketClient BingX => GetClient(Exchange.BingX, _bingX);
        /// <inheritdoc />
        public IBitfinexSocketClient Bitfinex => GetClient(Exchange.Bitfinex, _bitfinex);
        /// <inheritdoc />
        public IBitgetSocketClient Bitget => GetClient(Exchange.Bitget, _bitget);
        /// <inheritdoc />
        public IBitMartSocketClient BitMart => GetClient(Exchange.BitMart, _bitMart);
        /// <inheritdoc />
        public IBitMEXSocketClient BitMEX => GetClient(Exchange.BitMEX, _bitMEX);
        /// <inheritdoc />
        public IBitstampSocketClient Bitstamp => GetClient(Exchange.Bitstamp, _bitstamp);
        /// <inheritdoc />
        public IBloFinSocketClient BloFin => GetClient(Exchange.BloFin, _bloFin);
        /// <inheritdoc />
        public IBybitSocketClient Bybit => GetClient(Exchange.Bybit, _bybit);
        /// <inheritdoc />
        public ICoinbaseSocketClient Coinbase => GetClient(Exchange.Coinbase, _coinbase);
        /// <inheritdoc />
        public ICoinExSocketClient CoinEx => GetClient(Exchange.CoinEx, _coinEx);
        /// <inheritdoc />
        public ICoinWSocketClient CoinW => GetClient(Exchange.CoinW, _coinW);
        /// <inheritdoc />
        public ICryptoComSocketClient CryptoCom => GetClient(Exchange.CryptoCom, _cryptoCom);
        /// <inheritdoc />
        public IDeepCoinSocketClient DeepCoin => GetClient(Exchange.DeepCoin, _deepCoin);
        /// <inheritdoc />
        public IGateIoSocketClient GateIo => GetClient(Exchange.GateIo, _gateIo);
        /// <inheritdoc />
        public IHTXSocketClient HTX => GetClient(Exchange.HTX, _htx);
        /// <inheritdoc />
        public IHyperLiquidSocketClient HyperLiquid => GetClient(Exchange.HyperLiquid, _hyperLiquid);
        /// <inheritdoc />
        public IKrakenSocketClient Kraken => GetClient(Exchange.Kraken, _kraken);
        /// <inheritdoc />
        public IKucoinSocketClient Kucoin => GetClient(Exchange.Kucoin, _kucoin);
        /// <inheritdoc />
        public ILBankSocketClient LBank => GetClient(Exchange.LBank, _lBank);
        /// <inheritdoc />
        public ILighterSocketClient Lighter => GetClient(Exchange.Lighter, _lighter);
        /// <inheritdoc />
        public IMexcSocketClient Mexc => GetClient(Exchange.Mexc, _mexc);
        /// <inheritdoc />
        public IOKXSocketClient OKX => GetClient(Exchange.OKX, _okx);
        /// <inheritdoc />
        public IPionexSocketClient Pionex => GetClient(Exchange.Pionex, _pionex);
        /// <inheritdoc />
        public IPolymarketSocketClient Polymarket => GetClient(Platform.Polymarket, _polymarket);
        /// <inheritdoc />
        public IToobitSocketClient Toobit => GetClient(Exchange.Toobit, _toobit);
        /// <inheritdoc />
        public IUpbitSocketClient Upbit => GetClient(Exchange.Upbit, _upbit);
        /// <inheritdoc />
        public IWeexSocketClient Weex => GetClient(Exchange.Weex, _weex);
        /// <inheritdoc />
        public IWhiteBitSocketClient WhiteBit => GetClient(Exchange.WhiteBit, _whiteBit);
        /// <inheritdoc />
        public IXTSocketClient XT => GetClient(Exchange.XT, _xt);

        private readonly Dictionary<string, ISocketClientRegistration> _clientRegistrations = new(StringComparer.OrdinalIgnoreCase);
        private HashSet<string>? _enabledExchanges;
        private IEnumerable<ISharedClient> _sharedClients => _clientRegistrations.Where(x => IsEnabled(x.Key)).SelectMany(x => x.Value.SharedClients);
        private SocketClientRegistration<IAsterSocketClient> _aster = null!;
        private SocketClientRegistration<IBinanceSocketClient> _binance = null!;
        private SocketClientRegistration<IBingXSocketClient> _bingX = null!;
        private SocketClientRegistration<IBitfinexSocketClient> _bitfinex = null!;
        private SocketClientRegistration<IBitgetSocketClient> _bitget = null!;
        private SocketClientRegistration<IBitMartSocketClient> _bitMart = null!;
        private SocketClientRegistration<IBitMEXSocketClient> _bitMEX = null!;
        private SocketClientRegistration<IBitstampSocketClient> _bitstamp = null!;
        private SocketClientRegistration<IBloFinSocketClient> _bloFin = null!;
        private SocketClientRegistration<IBybitSocketClient> _bybit = null!;
        private SocketClientRegistration<ICoinbaseSocketClient> _coinbase = null!;
        private SocketClientRegistration<ICoinExSocketClient> _coinEx = null!;
        private SocketClientRegistration<ICoinWSocketClient> _coinW = null!;
        private SocketClientRegistration<ICryptoComSocketClient> _cryptoCom = null!;
        private SocketClientRegistration<IDeepCoinSocketClient> _deepCoin = null!;
        private SocketClientRegistration<IGateIoSocketClient> _gateIo = null!;
        private SocketClientRegistration<IHTXSocketClient> _htx = null!;
        private SocketClientRegistration<IHyperLiquidSocketClient> _hyperLiquid = null!;
        private SocketClientRegistration<IKrakenSocketClient> _kraken = null!;
        private SocketClientRegistration<IKucoinSocketClient> _kucoin = null!;
        private SocketClientRegistration<ILBankSocketClient> _lBank = null!;
        private SocketClientRegistration<ILighterSocketClient> _lighter = null!;
        private SocketClientRegistration<IMexcSocketClient> _mexc = null!;
        private SocketClientRegistration<IOKXSocketClient> _okx = null!;
        private SocketClientRegistration<IPionexSocketClient> _pionex = null!;
        private SocketClientRegistration<IPolymarketSocketClient> _polymarket = null!;
        private SocketClientRegistration<IToobitSocketClient> _toobit = null!;
        private SocketClientRegistration<IUpbitSocketClient> _upbit = null!;
        private SocketClientRegistration<IWeexSocketClient> _weex = null!;
        private SocketClientRegistration<IWhiteBitSocketClient> _whiteBit = null!;
        private SocketClientRegistration<IXTSocketClient> _xt = null!;

        /// <summary>
        /// Create a new ExchangeSocketClient instance. Client instances will be created with default options.
        /// </summary>
        public ExchangeSocketClient()
        {
            InitializeClients(null,
                () => new AsterSocketClient(), () => new BinanceSocketClient(), () => new BingXSocketClient(), () => new BitfinexSocketClient(),
                () => new BitgetSocketClient(), () => new BitMartSocketClient(), () => new BitMEXSocketClient(), () => new BitstampSocketClient(),
                () => new BloFinSocketClient(), () => new BybitSocketClient(), () => new CoinbaseSocketClient(), () => new CoinExSocketClient(),
                () => new CoinWSocketClient(), () => new CryptoComSocketClient(), () => new DeepCoinSocketClient(), () => new GateIoSocketClient(),
                () => new HTXSocketClient(), () => new HyperLiquidSocketClient(), () => new KrakenSocketClient(), () => new KucoinSocketClient(),
                () => new LBankSocketClient(), () => new LighterSocketClient(), () => new MexcSocketClient(), () => new OKXSocketClient(),
                () => new PionexSocketClient(), () => new PolymarketSocketClient(), () => new ToobitSocketClient(), () => new UpbitSocketClient(),
                () => new WeexSocketClient(), () => new WhiteBitSocketClient(), () => new XTSocketClient());
        }

        /// <summary>
        /// Create a new ExchangeSocketClient instance
        /// </summary>
        public ExchangeSocketClient(
            Action<GlobalExchangeOptions>? globalOptions = null,
            Action<AsterSocketOptions>? asterSocketOptions = null,
            Action<BinanceSocketOptions>? binanceSocketOptions = null,
            Action<BingXSocketOptions>? bingxSocketOptions = null,
            Action<BitfinexSocketOptions>? bitfinexSocketOptions = null,
            Action<BitgetSocketOptions>? bitgetSocketOptions = null,
            Action<BitMartSocketOptions>? bitMartSocketOptions = null,
            Action<BitMEXSocketOptions>? bitMEXSocketOptions = null,
            Action<BloFinSocketOptions>? bloFinSocketOptions = null,
            Action<BitstampSocketOptions>? bitstampSocketOptions = null,
            Action<BybitSocketOptions>? bybitSocketOptions = null,
            Action<CoinExSocketOptions>? coinExSocketOptions = null,
            Action<CoinWSocketOptions>? coinWSocketOptions = null,
            Action<CoinbaseSocketOptions>? coinbaseSocketOptions = null,
            Action<CryptoComSocketOptions>? cryptoComSocketOptions = null,
            Action<DeepCoinSocketOptions>? deepCoinSocketOptions = null,
            Action<GateIoSocketOptions>? gateIoSocketOptions = null,
            Action<HTXSocketOptions>? htxSocketOptions = null,
            Action<HyperLiquidSocketOptions>? hyperLiquidSocketOptions = null,
            Action<KrakenSocketOptions>? krakenSocketOptions = null,
            Action<KucoinSocketOptions>? kucoinSocketOptions = null,
            Action<LBankSocketOptions>? lBankSocketOptions = null,
            Action<LighterSocketOptions>? lighterSocketOptions = null,
            Action<MexcSocketOptions>? mexcSocketOptions = null,
            Action<OKXSocketOptions>? okxSocketOptions = null,
            Action<PionexSocketOptions>? pionexSocketOptions = null,
            Action<PolymarketSocketOptions>? polymarketSocketOptions = null,
            Action<ToobitSocketOptions>? toobitSocketOptions = null,
            Action<UpbitSocketOptions>? upbitSocketOptions = null,
            Action<WeexSocketOptions>? weexSocketOptions = null,
            Action<WhiteBitSocketOptions>? whiteBitSocketOptions = null,
            Action<XTSocketOptions>? xtSocketOptions = null) :
            this(
                null,
                Options.Create(ApplyOptionsDelegate(globalOptions)),
                Options.Create(ApplyOptionsDelegate(asterSocketOptions)),
                Options.Create(ApplyOptionsDelegate(binanceSocketOptions)),
                Options.Create(ApplyOptionsDelegate(bingxSocketOptions)),
                Options.Create(ApplyOptionsDelegate(bitfinexSocketOptions)),
                Options.Create(ApplyOptionsDelegate(bitgetSocketOptions)),
                Options.Create(ApplyOptionsDelegate(bitMartSocketOptions)),
                Options.Create(ApplyOptionsDelegate(bitMEXSocketOptions)),
                Options.Create(ApplyOptionsDelegate(bloFinSocketOptions)),
                Options.Create(ApplyOptionsDelegate(bitstampSocketOptions)),
                Options.Create(ApplyOptionsDelegate(bybitSocketOptions)),
                Options.Create(ApplyOptionsDelegate(coinExSocketOptions)),
                Options.Create(ApplyOptionsDelegate(coinWSocketOptions)),
                Options.Create(ApplyOptionsDelegate(coinbaseSocketOptions)),
                Options.Create(ApplyOptionsDelegate(cryptoComSocketOptions)),
                Options.Create(ApplyOptionsDelegate(deepCoinSocketOptions)),
                Options.Create(ApplyOptionsDelegate(gateIoSocketOptions)),
                Options.Create(ApplyOptionsDelegate(htxSocketOptions)),
                Options.Create(ApplyOptionsDelegate(hyperLiquidSocketOptions)),
                Options.Create(ApplyOptionsDelegate(krakenSocketOptions)),
                Options.Create(ApplyOptionsDelegate(kucoinSocketOptions)),
                Options.Create(ApplyOptionsDelegate(lBankSocketOptions)),
                Options.Create(ApplyOptionsDelegate(lighterSocketOptions)),
                Options.Create(ApplyOptionsDelegate(mexcSocketOptions)),
                Options.Create(ApplyOptionsDelegate(okxSocketOptions)),
                Options.Create(ApplyOptionsDelegate(pionexSocketOptions)),
                Options.Create(ApplyOptionsDelegate(polymarketSocketOptions)),
                Options.Create(ApplyOptionsDelegate(toobitSocketOptions)),
                Options.Create(ApplyOptionsDelegate(upbitSocketOptions)),
                Options.Create(ApplyOptionsDelegate(weexSocketOptions)),
                Options.Create(ApplyOptionsDelegate(whiteBitSocketOptions)),
                Options.Create(ApplyOptionsDelegate(xtSocketOptions))
                )
        {
        }

        /// <summary>
        /// Create a new ExchangeSocketClient instance
        /// </summary>
        public ExchangeSocketClient(
            ILoggerFactory? loggerFactory = null,
            IOptions<GlobalExchangeOptions>? globalOptions = null,
            IOptions<AsterSocketOptions>? asterSocketOptions = null,
            IOptions<BinanceSocketOptions>? binanceSocketOptions = null,
            IOptions<BingXSocketOptions>? bingxSocketOptions = null,
            IOptions<BitfinexSocketOptions>? bitfinexSocketOptions = null,
            IOptions<BitgetSocketOptions>? bitgetSocketOptions = null,
            IOptions<BitMartSocketOptions>? bitMartSocketOptions = null,
            IOptions<BitMEXSocketOptions>? bitMEXSocketOptions = null,
            IOptions<BloFinSocketOptions>? bloFinSocketOptions = null,
            IOptions<BitstampSocketOptions>? bitstampSocketOptions = null,
            IOptions<BybitSocketOptions>? bybitSocketOptions = null,
            IOptions<CoinExSocketOptions>? coinExSocketOptions = null,
            IOptions<CoinWSocketOptions>? coinWSocketOptions = null,
            IOptions<CoinbaseSocketOptions>? coinbaseSocketOptions = null,
            IOptions<CryptoComSocketOptions>? cryptoComSocketOptions = null,
            IOptions<DeepCoinSocketOptions>? deepCoinSocketOptions = null,
            IOptions<GateIoSocketOptions>? gateIoSocketOptions = null,
            IOptions<HTXSocketOptions>? htxSocketOptions = null,
            IOptions<HyperLiquidSocketOptions>? hyperLiquidSocketOptions = null,
            IOptions<KrakenSocketOptions>? krakenSocketOptions = null,
            IOptions<KucoinSocketOptions>? kucoinSocketOptions = null,
            IOptions<LBankSocketOptions>? lBankSocketOptions = null,
            IOptions<LighterSocketOptions>? lighterSocketOptions = null,
            IOptions<MexcSocketOptions>? mexcSocketOptions = null,
            IOptions<OKXSocketOptions>? okxSocketOptions = null,
            IOptions<PionexSocketOptions>? pionexSocketOptions = null,
            IOptions<PolymarketSocketOptions>? polymarketSocketOptions = null,
            IOptions<ToobitSocketOptions>? toobitSocketOptions = null,
            IOptions<UpbitSocketOptions>? upbitSocketOptions = null,
            IOptions<WeexSocketOptions>? weexSocketOptions = null,
            IOptions<WhiteBitSocketOptions>? whiteBitSocketOptions = null,
            IOptions<XTSocketOptions>? xtSocketOptions = null)
        {
            TOptions SetGlobalSocketOptionsBase<TOptions, TEnvironment>(GlobalExchangeOptions globalOptions, TOptions? socketOptions, TEnvironment environment)
                where TOptions : SocketExchangeOptions<TEnvironment>, new()
                where TEnvironment : TradeEnvironment
            {
                socketOptions ??= new();
                socketOptions.Proxy = globalOptions.Proxy;
                socketOptions.Environment = environment;
                socketOptions.OutputOriginalData = globalOptions.OutputOriginalData ?? socketOptions.OutputOriginalData;
                socketOptions.RequestTimeout = globalOptions.RequestTimeout ?? socketOptions.RequestTimeout;
                socketOptions.RateLimiterEnabled = globalOptions.RateLimiterEnabled ?? socketOptions.RateLimiterEnabled;
                socketOptions.RateLimitingBehaviour = globalOptions.RateLimitingBehaviour ?? socketOptions.RateLimitingBehaviour;
                socketOptions.ReconnectPolicy = globalOptions.ReconnectPolicy ?? socketOptions.ReconnectPolicy;
                socketOptions.ReconnectInterval = globalOptions.ReconnectInterval ?? socketOptions.ReconnectInterval;
                   
                return socketOptions;
            }


            IOptions<TOptions> SetGlobalSocketOptions<TOptions, TCredentials, TEnvironment>(GlobalExchangeOptions globalOptions, TOptions? socketOptions, TCredentials? credentials, TEnvironment environment)
                where TOptions : SocketExchangeOptions<TEnvironment, TCredentials>, new()
                where TCredentials : ApiCredentials
                where TEnvironment : TradeEnvironment
            {
                SetGlobalSocketOptionsBase(globalOptions, socketOptions, environment);
                socketOptions!.ApiCredentials = credentials;
                return Options.Create(socketOptions);
            }

            if (globalOptions != null)
            {
                var global = globalOptions.Value;

                ExchangeCredentials? credentials = global.ApiCredentials;
                Dictionary<string, string?>? environments = global.ApiEnvironments;
                asterSocketOptions = SetGlobalSocketOptions(global, asterSocketOptions?.Value, credentials?.Aster, environments?.TryGetValue(Exchange.Aster, out var asterEnvName) == true ? AsterEnvironment.GetEnvironmentByName(asterEnvName)! : asterSocketOptions?.Value.Environment ?? AsterEnvironment.Live);
                binanceSocketOptions = SetGlobalSocketOptions(global, binanceSocketOptions?.Value, credentials?.Binance, environments?.TryGetValue(Exchange.Binance, out var binanceEnvName) == true ? BinanceEnvironment.GetEnvironmentByName(binanceEnvName)! : binanceSocketOptions?.Value.Environment ?? BinanceEnvironment.Live);
                bingxSocketOptions = SetGlobalSocketOptions(global, bingxSocketOptions?.Value, credentials?.BingX, environments?.TryGetValue(Exchange.BingX, out var bingXEnvName) == true ? BingXEnvironment.GetEnvironmentByName(bingXEnvName)! : bingxSocketOptions?.Value.Environment ?? BingXEnvironment.Live);
                bitfinexSocketOptions = SetGlobalSocketOptions(global, bitfinexSocketOptions?.Value, credentials?.Bitfinex, environments?.TryGetValue(Exchange.Bitfinex, out var bitfinexEnvName) == true ? BitfinexEnvironment.GetEnvironmentByName(bitfinexEnvName)! : bitfinexSocketOptions?.Value.Environment ?? BitfinexEnvironment.Live);
                bitgetSocketOptions = SetGlobalSocketOptions(global, bitgetSocketOptions?.Value, credentials?.Bitget, environments?.TryGetValue(Exchange.Bitget, out var bitgetEnvName) == true ? BitgetEnvironment.GetEnvironmentByName(bitgetEnvName)! : bitgetSocketOptions?.Value.Environment ?? BitgetEnvironment.Live);
                bitMartSocketOptions = SetGlobalSocketOptions(global, bitMartSocketOptions?.Value, credentials?.BitMart, environments?.TryGetValue(Exchange.BitMart, out var bitMartEnvName) == true ? BitMartEnvironment.GetEnvironmentByName(bitMartEnvName)! : bitMartSocketOptions?.Value.Environment ?? BitMartEnvironment.Live);
                bitMEXSocketOptions = SetGlobalSocketOptions(global, bitMEXSocketOptions?.Value, credentials?.BitMEX, environments?.TryGetValue(Exchange.BitMEX, out var bitMEXEnvName) == true ? BitMEXEnvironment.GetEnvironmentByName(bitMEXEnvName)! : bitMEXSocketOptions?.Value.Environment ?? BitMEXEnvironment.Live);
                bitstampSocketOptions = SetGlobalSocketOptions(global, bitstampSocketOptions?.Value, credentials?.Bitstamp, environments?.TryGetValue(Exchange.Bitstamp, out var bitstampEnvName) == true ? BitstampEnvironment.GetEnvironmentByName(bitstampEnvName)! : bitstampSocketOptions?.Value.Environment ?? BitstampEnvironment.Live);
                bloFinSocketOptions = SetGlobalSocketOptions(global, bloFinSocketOptions?.Value, credentials?.BloFin, environments?.TryGetValue(Exchange.BloFin, out var bloFinEnvName) == true ? BloFinEnvironment.GetEnvironmentByName(bloFinEnvName)! : bloFinSocketOptions?.Value.Environment ?? BloFinEnvironment.Live);
                bybitSocketOptions = SetGlobalSocketOptions(global, bybitSocketOptions?.Value, credentials?.Bybit, environments?.TryGetValue(Exchange.Bybit, out var bybitEnvName) == true ? BybitEnvironment.GetEnvironmentByName(bybitEnvName)! : bybitSocketOptions?.Value.Environment ?? BybitEnvironment.Live);
                coinbaseSocketOptions = SetGlobalSocketOptions(global, coinbaseSocketOptions?.Value, credentials?.Coinbase, environments?.TryGetValue(Exchange.Coinbase, out var coinbaseEnvName) == true ? CoinbaseEnvironment.GetEnvironmentByName(coinbaseEnvName)! : coinbaseSocketOptions?.Value.Environment ?? CoinbaseEnvironment.Live);
                coinExSocketOptions = SetGlobalSocketOptions(global, coinExSocketOptions?.Value, credentials?.CoinEx, environments?.TryGetValue(Exchange.CoinEx, out var coinExEnvName) == true ? CoinExEnvironment.GetEnvironmentByName(coinExEnvName)! : coinExSocketOptions?.Value.Environment ?? CoinExEnvironment.Live);
                coinWSocketOptions = SetGlobalSocketOptions(global, coinWSocketOptions?.Value, credentials?.CoinW, environments?.TryGetValue(Exchange.CoinW, out var coinWEnvName) == true ? CoinWEnvironment.GetEnvironmentByName(coinWEnvName)! : coinWSocketOptions?.Value.Environment ?? CoinWEnvironment.Live);
                cryptoComSocketOptions = SetGlobalSocketOptions(global, cryptoComSocketOptions?.Value, credentials?.CryptoCom, environments?.TryGetValue(Exchange.CryptoCom, out var cryptoComEnvName) == true ? CryptoComEnvironment.GetEnvironmentByName(cryptoComEnvName)! : cryptoComSocketOptions?.Value.Environment ?? CryptoComEnvironment.Live);
                deepCoinSocketOptions = SetGlobalSocketOptions(global, deepCoinSocketOptions?.Value, credentials?.DeepCoin, environments?.TryGetValue(Exchange.DeepCoin, out var deepCoinEnvName) == true ? DeepCoinEnvironment.GetEnvironmentByName(deepCoinEnvName)! : deepCoinSocketOptions?.Value.Environment ?? DeepCoinEnvironment.Live);
                gateIoSocketOptions = SetGlobalSocketOptions(global, gateIoSocketOptions?.Value, credentials?.GateIo, environments?.TryGetValue(Exchange.GateIo, out var gateIoEnvName) == true ? GateIoEnvironment.GetEnvironmentByName(gateIoEnvName)! : gateIoSocketOptions?.Value.Environment ?? GateIoEnvironment.Live);
                htxSocketOptions = SetGlobalSocketOptions(global, htxSocketOptions?.Value, credentials?.HTX, environments?.TryGetValue(Exchange.HTX, out var htxEnvName) == true ? HTXEnvironment.GetEnvironmentByName(htxEnvName)! : htxSocketOptions?.Value.Environment ?? HTXEnvironment.Live);
                hyperLiquidSocketOptions = SetGlobalSocketOptions(global, hyperLiquidSocketOptions?.Value, credentials?.HyperLiquid, environments?.TryGetValue(Exchange.HyperLiquid, out var hyperLiquidEnvName) == true ? HyperLiquidEnvironment.GetEnvironmentByName(hyperLiquidEnvName)! : hyperLiquidSocketOptions?.Value.Environment ?? HyperLiquidEnvironment.Live);
                krakenSocketOptions = SetGlobalSocketOptions(global, krakenSocketOptions?.Value, credentials?.Kraken, environments?.TryGetValue(Exchange.Kraken, out var krakenEnvName) == true ? KrakenEnvironment.GetEnvironmentByName(krakenEnvName)! : krakenSocketOptions?.Value.Environment ?? KrakenEnvironment.Live);
                kucoinSocketOptions = SetGlobalSocketOptions(global, kucoinSocketOptions?.Value, credentials?.Kucoin, environments?.TryGetValue(Exchange.Kucoin, out var kucoinEnvName) == true ? KucoinEnvironment.GetEnvironmentByName(kucoinEnvName)! : kucoinSocketOptions?.Value.Environment ?? KucoinEnvironment.Live);
                lBankSocketOptions = SetGlobalSocketOptions(global, lBankSocketOptions?.Value, credentials?.LBank, environments?.TryGetValue(Exchange.LBank, out var lBankEnvName) == true ? LBankEnvironment.GetEnvironmentByName(lBankEnvName)! : lBankSocketOptions?.Value.Environment ?? LBankEnvironment.Live);
                lighterSocketOptions = SetGlobalSocketOptions(global, lighterSocketOptions?.Value, credentials?.Lighter, environments?.TryGetValue(Exchange.Lighter, out var lighterEnvName) == true ? LighterEnvironment.GetEnvironmentByName(lighterEnvName)! : lighterSocketOptions?.Value.Environment ?? LighterEnvironment.Live);
                mexcSocketOptions = SetGlobalSocketOptions(global, mexcSocketOptions?.Value, credentials?.Mexc, environments?.TryGetValue(Exchange.Mexc, out var mexcEnvName) == true ? MexcEnvironment.GetEnvironmentByName(mexcEnvName)! : mexcSocketOptions?.Value.Environment ?? MexcEnvironment.Live);
                okxSocketOptions = SetGlobalSocketOptions(global, okxSocketOptions?.Value, credentials?.OKX, environments?.TryGetValue(Exchange.OKX, out var okxEnvName) == true ? OKXEnvironment.GetEnvironmentByName(okxEnvName)! : okxSocketOptions?.Value.Environment ?? OKXEnvironment.Live);
                pionexSocketOptions = SetGlobalSocketOptions(global, pionexSocketOptions?.Value, credentials?.Pionex, environments?.TryGetValue(Exchange.Pionex, out var pionexEnvName) == true ? PionexEnvironment.GetEnvironmentByName(pionexEnvName)! : pionexSocketOptions?.Value.Environment ?? PionexEnvironment.Live);
                polymarketSocketOptions = SetGlobalSocketOptions(global, polymarketSocketOptions?.Value, credentials?.Polymarket, environments?.TryGetValue(Platform.Polymarket, out var polymarketEnvName) == true ? PolymarketEnvironment.GetEnvironmentByName(polymarketEnvName)! : polymarketSocketOptions?.Value.Environment ?? PolymarketEnvironment.Live);
                toobitSocketOptions = SetGlobalSocketOptions(global, toobitSocketOptions?.Value, credentials?.Toobit, environments?.TryGetValue(Exchange.Toobit, out var toobitEnvName) == true ? ToobitEnvironment.GetEnvironmentByName(toobitEnvName)! : toobitSocketOptions?.Value.Environment ?? ToobitEnvironment.Live);
                upbitSocketOptions = Options.Create(SetGlobalSocketOptionsBase(global, upbitSocketOptions?.Value, environments?.TryGetValue(Exchange.Upbit, out var upbitEnvName) == true ? UpbitEnvironment.GetEnvironmentByName(upbitEnvName)! : upbitSocketOptions?.Value.Environment ?? UpbitEnvironment.Live) ?? new UpbitSocketOptions());
                weexSocketOptions = SetGlobalSocketOptions(global, weexSocketOptions?.Value, credentials?.Weex, environments?.TryGetValue(Exchange.Weex, out var weexEnvName) == true ? WeexEnvironment.GetEnvironmentByName(weexEnvName)! : weexSocketOptions?.Value.Environment ?? WeexEnvironment.Live);
                whiteBitSocketOptions = SetGlobalSocketOptions(global, whiteBitSocketOptions?.Value, credentials?.WhiteBit, environments?.TryGetValue(Exchange.WhiteBit, out var whiteBitEnvName) == true ? WhiteBitEnvironment.GetEnvironmentByName(whiteBitEnvName)! : whiteBitSocketOptions?.Value.Environment ?? WhiteBitEnvironment.Live);
                xtSocketOptions = SetGlobalSocketOptions(global, xtSocketOptions?.Value, credentials?.XT, environments?.TryGetValue(Exchange.XT, out var xtEnvName) == true ? XTEnvironment.GetEnvironmentByName(xtEnvName)! : xtSocketOptions?.Value.Environment ?? XTEnvironment.Live);
            }

            InitializeClients(globalOptions?.Value.EnabledExchanges,
                () => new AsterSocketClient(asterSocketOptions ?? Options.Create(new AsterSocketOptions()), loggerFactory),
                () => new BinanceSocketClient(binanceSocketOptions ?? Options.Create(new BinanceSocketOptions()), loggerFactory),
                () => new BingXSocketClient(bingxSocketOptions ?? Options.Create(new BingXSocketOptions()), loggerFactory),
                () => new BitfinexSocketClient(bitfinexSocketOptions ?? Options.Create(new BitfinexSocketOptions()), loggerFactory),
                () => new BitgetSocketClient(bitgetSocketOptions ?? Options.Create(new BitgetSocketOptions()), loggerFactory),
                () => new BitMartSocketClient(bitMartSocketOptions ?? Options.Create(new BitMartSocketOptions()), loggerFactory),
                () => new BitMEXSocketClient(bitMEXSocketOptions ?? Options.Create(new BitMEXSocketOptions()), loggerFactory),
                () => new BitstampSocketClient(bitstampSocketOptions ?? Options.Create(new BitstampSocketOptions()), loggerFactory),
                () => new BloFinSocketClient(bloFinSocketOptions ?? Options.Create(new BloFinSocketOptions()), loggerFactory),
                () => new BybitSocketClient(bybitSocketOptions ?? Options.Create(new BybitSocketOptions()), loggerFactory),
                () => new CoinbaseSocketClient(coinbaseSocketOptions ?? Options.Create(new CoinbaseSocketOptions()), loggerFactory),
                () => new CoinExSocketClient(coinExSocketOptions ?? Options.Create(new CoinExSocketOptions()), loggerFactory),
                () => new CoinWSocketClient(coinWSocketOptions ?? Options.Create(new CoinWSocketOptions()), loggerFactory),
                () => new CryptoComSocketClient(cryptoComSocketOptions ?? Options.Create(new CryptoComSocketOptions()), loggerFactory),
                () => new DeepCoinSocketClient(deepCoinSocketOptions ?? Options.Create(new DeepCoinSocketOptions()), loggerFactory),
                () => new GateIoSocketClient(gateIoSocketOptions ?? Options.Create(new GateIoSocketOptions()), loggerFactory),
                () => new HTXSocketClient(htxSocketOptions ?? Options.Create(new HTXSocketOptions()), loggerFactory),
                () => new HyperLiquidSocketClient(hyperLiquidSocketOptions ?? Options.Create(new HyperLiquidSocketOptions()), loggerFactory),
                () => new KrakenSocketClient(krakenSocketOptions ?? Options.Create(new KrakenSocketOptions()), loggerFactory),
                () => new KucoinSocketClient(kucoinSocketOptions ?? Options.Create(new KucoinSocketOptions()), loggerFactory),
                () => new LBankSocketClient(lBankSocketOptions ?? Options.Create(new LBankSocketOptions()), loggerFactory),
                () => new LighterSocketClient(lighterSocketOptions ?? Options.Create(new LighterSocketOptions()), loggerFactory),
                () => new MexcSocketClient(mexcSocketOptions ?? Options.Create(new MexcSocketOptions()), loggerFactory),
                () => new OKXSocketClient(okxSocketOptions ?? Options.Create(new OKXSocketOptions()), loggerFactory),
                () => new PionexSocketClient(pionexSocketOptions ?? Options.Create(new PionexSocketOptions()), loggerFactory),
                () => new PolymarketSocketClient(polymarketSocketOptions ?? Options.Create(new PolymarketSocketOptions()), loggerFactory),
                () => new ToobitSocketClient(toobitSocketOptions ?? Options.Create(new ToobitSocketOptions()), loggerFactory),
                () => new UpbitSocketClient(upbitSocketOptions ?? Options.Create(new UpbitSocketOptions()), loggerFactory),
                () => new WeexSocketClient(weexSocketOptions ?? Options.Create(new WeexSocketOptions()), loggerFactory),
                () => new WhiteBitSocketClient(whiteBitSocketOptions ?? Options.Create(new WhiteBitSocketOptions()), loggerFactory),
                () => new XTSocketClient(xtSocketOptions ?? Options.Create(new XTSocketOptions()), loggerFactory));
        }

        /// <summary>
        /// DI constructor
        /// </summary>
        public ExchangeSocketClient(
            IAsterSocketClient aster,
            IBinanceSocketClient binance,
            IBingXSocketClient bingx,
            IBitfinexSocketClient bitfinex,
            IBitgetSocketClient bitget,
            IBitMartSocketClient bitMart,
            IBitMEXSocketClient bitMEX,
            IBitstampSocketClient bitstamp,
            IBloFinSocketClient bloFin,
            IBybitSocketClient bybit,
            ICoinbaseSocketClient coinbase,
            ICoinExSocketClient coinEx,
            ICoinWSocketClient coinW,
            ICryptoComSocketClient cryptoCom,
            IDeepCoinSocketClient deepCoin,
            IGateIoSocketClient gateIo,
            IHTXSocketClient htx,
            IHyperLiquidSocketClient hyperLiquid,
            IKrakenSocketClient kraken,
            IKucoinSocketClient kucoin,
            ILBankSocketClient lBank,
            ILighterSocketClient lighter,
            IMexcSocketClient mexc,
            IOKXSocketClient okx,
            IPionexSocketClient pionex,
            IPolymarketSocketClient polymarket,
            IToobitSocketClient toobit,
            IUpbitSocketClient upbit,
            IWeexSocketClient weex,
            IWhiteBitSocketClient whiteBit,
            IXTSocketClient xt)
        {
            InitializeClients(null,
                () => aster, () => binance, () => bingx, () => bitfinex, () => bitget, () => bitMart, () => bitMEX, () => bitstamp,
                () => bloFin, () => bybit, () => coinbase, () => coinEx, () => coinW, () => cryptoCom, () => deepCoin, () => gateIo,
                () => htx, () => hyperLiquid, () => kraken, () => kucoin, () => lBank, () => lighter, () => mexc, () => okx,
                () => pionex, () => polymarket, () => toobit, () => upbit, () => weex, () => whiteBit, () => xt);
        }

        internal ExchangeSocketClient(IEnumerable<string>? enabledExchanges, IServiceProvider serviceProvider)
        {
            InitializeClients(enabledExchanges,
                () => serviceProvider.GetRequiredService<IAsterSocketClient>(), () => serviceProvider.GetRequiredService<IBinanceSocketClient>(),
                () => serviceProvider.GetRequiredService<IBingXSocketClient>(), () => serviceProvider.GetRequiredService<IBitfinexSocketClient>(),
                () => serviceProvider.GetRequiredService<IBitgetSocketClient>(), () => serviceProvider.GetRequiredService<IBitMartSocketClient>(),
                () => serviceProvider.GetRequiredService<IBitMEXSocketClient>(), () => serviceProvider.GetRequiredService<IBitstampSocketClient>(),
                () => serviceProvider.GetRequiredService<IBloFinSocketClient>(), () => serviceProvider.GetRequiredService<IBybitSocketClient>(),
                () => serviceProvider.GetRequiredService<ICoinbaseSocketClient>(), () => serviceProvider.GetRequiredService<ICoinExSocketClient>(),
                () => serviceProvider.GetRequiredService<ICoinWSocketClient>(), () => serviceProvider.GetRequiredService<ICryptoComSocketClient>(),
                () => serviceProvider.GetRequiredService<IDeepCoinSocketClient>(), () => serviceProvider.GetRequiredService<IGateIoSocketClient>(),
                () => serviceProvider.GetRequiredService<IHTXSocketClient>(), () => serviceProvider.GetRequiredService<IHyperLiquidSocketClient>(),
                () => serviceProvider.GetRequiredService<IKrakenSocketClient>(), () => serviceProvider.GetRequiredService<IKucoinSocketClient>(),
                () => serviceProvider.GetRequiredService<ILBankSocketClient>(), () => serviceProvider.GetRequiredService<ILighterSocketClient>(),
                () => serviceProvider.GetRequiredService<IMexcSocketClient>(), () => serviceProvider.GetRequiredService<IOKXSocketClient>(),
                () => serviceProvider.GetRequiredService<IPionexSocketClient>(), () => serviceProvider.GetRequiredService<IPolymarketSocketClient>(),
                () => serviceProvider.GetRequiredService<IToobitSocketClient>(), () => serviceProvider.GetRequiredService<IUpbitSocketClient>(),
                () => serviceProvider.GetRequiredService<IWeexSocketClient>(), () => serviceProvider.GetRequiredService<IWhiteBitSocketClient>(),
                () => serviceProvider.GetRequiredService<IXTSocketClient>());
        }

        internal ExchangeSocketClient(
            IEnumerable<string>? enabledExchanges,
            Func<IAsterSocketClient> aster, Func<IBinanceSocketClient> binance, Func<IBingXSocketClient> bingX, Func<IBitfinexSocketClient> bitfinex,
            Func<IBitgetSocketClient> bitget, Func<IBitMartSocketClient> bitMart, Func<IBitMEXSocketClient> bitMEX, Func<IBitstampSocketClient> bitstamp,
            Func<IBloFinSocketClient> bloFin, Func<IBybitSocketClient> bybit, Func<ICoinbaseSocketClient> coinbase, Func<ICoinExSocketClient> coinEx,
            Func<ICoinWSocketClient> coinW, Func<ICryptoComSocketClient> cryptoCom, Func<IDeepCoinSocketClient> deepCoin, Func<IGateIoSocketClient> gateIo,
            Func<IHTXSocketClient> htx, Func<IHyperLiquidSocketClient> hyperLiquid, Func<IKrakenSocketClient> kraken, Func<IKucoinSocketClient> kucoin,
            Func<ILBankSocketClient> lBank, Func<ILighterSocketClient> lighter, Func<IMexcSocketClient> mexc, Func<IOKXSocketClient> okx,
            Func<IPionexSocketClient> pionex, Func<IPolymarketSocketClient> polymarket, Func<IToobitSocketClient> toobit, Func<IUpbitSocketClient> upbit,
            Func<IWeexSocketClient> weex, Func<IWhiteBitSocketClient> whiteBit, Func<IXTSocketClient> xt)
        {
            InitializeClients(enabledExchanges,
                aster, binance, bingX, bitfinex, bitget, bitMart, bitMEX, bitstamp, bloFin, bybit, coinbase, coinEx,
                coinW, cryptoCom, deepCoin, gateIo, htx, hyperLiquid, kraken, kucoin, lBank, lighter, mexc, okx,
                pionex, polymarket, toobit, upbit, weex, whiteBit, xt);
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
        public async Task UnsubscribeAllAsync()
        {
            var tasks = _clientRegistrations.Values
                .Where(x => x.IsValueCreated)
                .Select(x => x.Client.UnsubscribeAllAsync());
            await Task.WhenAll(tasks).ConfigureAwait(false);
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
            Func<IAsterSocketClient> aster, Func<IBinanceSocketClient> binance, Func<IBingXSocketClient> bingX, Func<IBitfinexSocketClient> bitfinex,
            Func<IBitgetSocketClient> bitget, Func<IBitMartSocketClient> bitMart, Func<IBitMEXSocketClient> bitMEX, Func<IBitstampSocketClient> bitstamp,
            Func<IBloFinSocketClient> bloFin, Func<IBybitSocketClient> bybit, Func<ICoinbaseSocketClient> coinbase, Func<ICoinExSocketClient> coinEx,
            Func<ICoinWSocketClient> coinW, Func<ICryptoComSocketClient> cryptoCom, Func<IDeepCoinSocketClient> deepCoin, Func<IGateIoSocketClient> gateIo,
            Func<IHTXSocketClient> htx, Func<IHyperLiquidSocketClient> hyperLiquid, Func<IKrakenSocketClient> kraken, Func<IKucoinSocketClient> kucoin,
            Func<ILBankSocketClient> lBank, Func<ILighterSocketClient> lighter, Func<IMexcSocketClient> mexc, Func<IOKXSocketClient> okx,
            Func<IPionexSocketClient> pionex, Func<IPolymarketSocketClient> polymarket, Func<IToobitSocketClient> toobit, Func<IUpbitSocketClient> upbit,
            Func<IWeexSocketClient> weex, Func<IWhiteBitSocketClient> whiteBit, Func<IXTSocketClient> xt)
        {
            _enabledExchanges = enabledExchanges == null ? null : new HashSet<string>(enabledExchanges, StringComparer.OrdinalIgnoreCase);

            SocketClientRegistration<T> Register<T>(string name, Func<T> clientFactory, Func<T, ISharedClient[]> sharedClientFactory) where T : ISocketClient
            {
                var registration = new SocketClientRegistration<T>(clientFactory, sharedClientFactory);
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
            _bloFin = Register(Exchange.BloFin, bloFin, x => [x.FuturesApi.SharedClient]);
            _bybit = Register(Exchange.Bybit, bybit, x => [x.V5InverseApi.SharedClient, x.V5LinearApi.SharedClient, x.V5PrivateApi.SharedClient, x.V5SpotApi.SharedClient]);
            _coinbase = Register(Exchange.Coinbase, coinbase, x => [x.AdvancedTradeApi.SharedClient]);
            _coinEx = Register(Exchange.CoinEx, coinEx, x => [x.SpotApiV2.SharedClient, x.FuturesApi.SharedClient]);
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
            _xt = Register(Exchange.XT, xt, x => [x.SpotApi.SharedClient, x.FuturesApi.SharedClient]);
        }

        private bool IsEnabled(string name) => _enabledExchanges == null || _enabledExchanges.Contains(name);

        private IEnumerable<ISharedClient> GetSharedClients(string name)
            => IsEnabled(name) && _clientRegistrations.TryGetValue(name, out var registration) ? registration.SharedClients : [];

#pragma warning disable IL2091
        private T GetClient<T>(string name, SocketClientRegistration<T> registration) where T : ISocketClient
        {
            if (!IsEnabled(name))
                throw new InvalidOperationException($"The {name} client is disabled. Add it to {nameof(GlobalExchangeOptions.EnabledExchanges)} before accessing it.");

            return registration.TypedClient;
        }

        private interface ISocketClientRegistration
        {
            bool IsValueCreated { get; }
            ISocketClient Client { get; }
            IEnumerable<ISharedClient> SharedClients { get; }
        }

        private sealed class SocketClientRegistration<T> : ISocketClientRegistration where T : ISocketClient
        {
            public bool IsValueCreated => _value.IsValueCreated;
            public T TypedClient => _value.Value.Client;
            public ISocketClient Client => _value.Value.Client;
            public IEnumerable<ISharedClient> SharedClients => _value.Value.SharedClients;

            private readonly Lazy<(T Client, ISharedClient[] SharedClients)> _value;

            public SocketClientRegistration(Func<T> clientFactory, Func<T, ISharedClient[]> sharedClientFactory)
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
