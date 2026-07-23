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

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public partial class ExchangeSocketClient : IExchangeSocketClient
    {
        private IEnumerable<ISharedClient> _sharedClients = Array.Empty<ISharedClient>();
        private ISocketClient[] _socketClients = [];

        /// <inheritdoc />
        public double IncomingKbps => _socketClients.Sum(x => x.IncomingKbps);
        /// <inheritdoc />
        public int CurrentConnections => _socketClients.Sum(x => x.CurrentConnections);
        /// <inheritdoc />
        public int CurrentSubscriptions => _socketClients.Sum(x => x.CurrentSubscriptions);

        /// <inheritdoc />
        public IAsterSocketClient Aster { get; }
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
        public IBitMEXSocketClient BitMEX { get; }
        /// <inheritdoc />
        public IBitstampSocketClient Bitstamp { get; }
        /// <inheritdoc />
        public IBloFinSocketClient BloFin { get; }
        /// <inheritdoc />
        public IBybitSocketClient Bybit { get; }
        /// <inheritdoc />
        public ICoinbaseSocketClient Coinbase { get; }
        /// <inheritdoc />
        public ICoinExSocketClient CoinEx { get; }
        /// <inheritdoc />
        public ICoinWSocketClient CoinW { get; }
        /// <inheritdoc />
        public ICryptoComSocketClient CryptoCom { get; }
        /// <inheritdoc />
        public IDeepCoinSocketClient DeepCoin { get; }
        /// <inheritdoc />
        public IGateIoSocketClient GateIo { get; }
        /// <inheritdoc />
        public IHTXSocketClient HTX { get; }
        /// <inheritdoc />
        public IHyperLiquidSocketClient HyperLiquid { get; }
        /// <inheritdoc />
        public IKrakenSocketClient Kraken { get; }
        /// <inheritdoc />
        public IKucoinSocketClient Kucoin { get; }
        /// <inheritdoc />
        public ILighterSocketClient Lighter { get; }
        /// <inheritdoc />
        public IMexcSocketClient Mexc { get; }
        /// <inheritdoc />
        public IOKXSocketClient OKX { get; }
        /// <inheritdoc />
        public IPionexSocketClient Pionex { get; }
        /// <inheritdoc />
        public IPolymarketSocketClient Polymarket { get; }
        /// <inheritdoc />
        public IToobitSocketClient Toobit { get; }
        /// <inheritdoc />
        public IUpbitSocketClient Upbit { get; }
        /// <inheritdoc />
        public IWeexSocketClient Weex { get; }
        /// <inheritdoc />
        public IWhiteBitSocketClient WhiteBit { get; }
        /// <inheritdoc />
        public IXTSocketClient XT { get; }

        /// <summary>
        /// Create a new ExchangeSocketClient instance. Client instances will be created with default options.
        /// </summary>
        public ExchangeSocketClient()
        {
            Aster = new AsterSocketClient();
            Binance = new BinanceSocketClient();
            BingX = new BingXSocketClient();
            Bitfinex = new BitfinexSocketClient();
            Bitget = new BitgetSocketClient();
            BitMart = new BitMartSocketClient();
            BitMEX = new BitMEXSocketClient();
            Bitstamp = new BitstampSocketClient();
            BloFin = new BloFinSocketClient();
            Bybit = new BybitSocketClient();
            Coinbase = new CoinbaseSocketClient();
            CoinEx = new CoinExSocketClient();
            CoinW = new CoinWSocketClient();
            CryptoCom = new CryptoComSocketClient();
            DeepCoin = new DeepCoinSocketClient();
            GateIo = new GateIoSocketClient();
            HTX = new HTXSocketClient();
            HyperLiquid = new HyperLiquidSocketClient();
            Kraken = new KrakenSocketClient();
            Kucoin = new KucoinSocketClient();
            Lighter = new LighterSocketClient();
            Mexc = new MexcSocketClient();
            OKX = new OKXSocketClient();
            Pionex = new PionexSocketClient();
            Polymarket = new PolymarketSocketClient();
            Toobit = new ToobitSocketClient();
            Upbit = new UpbitSocketClient();
            Weex = new WeexSocketClient();
            WhiteBit = new WhiteBitSocketClient();
            XT = new XTSocketClient();

            InitSharedClients();
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

            Aster = new AsterSocketClient(asterSocketOptions ?? Options.Create(new AsterSocketOptions()), loggerFactory);
            Binance = new BinanceSocketClient(binanceSocketOptions ?? Options.Create(new BinanceSocketOptions()), loggerFactory);
            BingX = new BingXSocketClient(bingxSocketOptions ?? Options.Create(new BingXSocketOptions()), loggerFactory);
            Bitfinex = new BitfinexSocketClient(bitfinexSocketOptions ?? Options.Create(new BitfinexSocketOptions()), loggerFactory);
            Bitget = new BitgetSocketClient(bitgetSocketOptions ?? Options.Create(new BitgetSocketOptions()), loggerFactory);
            BitMart = new BitMartSocketClient(bitMartSocketOptions ?? Options.Create(new BitMartSocketOptions()), loggerFactory);
            BitMEX = new BitMEXSocketClient(bitMEXSocketOptions ?? Options.Create(new BitMEXSocketOptions()), loggerFactory);
            Bitstamp = new BitstampSocketClient(bitstampSocketOptions ?? Options.Create(new BitstampSocketOptions()), loggerFactory);
            BloFin = new BloFinSocketClient(bloFinSocketOptions ?? Options.Create(new BloFinSocketOptions()), loggerFactory);
            Bybit = new BybitSocketClient(bybitSocketOptions ?? Options.Create(new BybitSocketOptions()), loggerFactory);
            Coinbase = new CoinbaseSocketClient(coinbaseSocketOptions ?? Options.Create(new CoinbaseSocketOptions()), loggerFactory);
            CoinEx = new CoinExSocketClient(coinExSocketOptions ?? Options.Create(new CoinExSocketOptions()), loggerFactory);
            CoinW = new CoinWSocketClient(coinWSocketOptions ?? Options.Create(new CoinWSocketOptions()), loggerFactory);
            HTX = new HTXSocketClient(htxSocketOptions  ?? Options.Create(new HTXSocketOptions()), loggerFactory);
            HyperLiquid = new HyperLiquidSocketClient(hyperLiquidSocketOptions ?? Options.Create(new HyperLiquidSocketOptions()), loggerFactory);
            CryptoCom = new CryptoComSocketClient(cryptoComSocketOptions ?? Options.Create(new CryptoComSocketOptions()), loggerFactory);
            DeepCoin = new DeepCoinSocketClient(deepCoinSocketOptions ?? Options.Create(new DeepCoinSocketOptions()), loggerFactory);
            GateIo = new GateIoSocketClient(gateIoSocketOptions ?? Options.Create(new GateIoSocketOptions()), loggerFactory);
            Kraken = new KrakenSocketClient(krakenSocketOptions ?? Options.Create(new KrakenSocketOptions()), loggerFactory);
            Kucoin = new KucoinSocketClient(kucoinSocketOptions ?? Options.Create(new KucoinSocketOptions()), loggerFactory);
            Lighter = new LighterSocketClient(lighterSocketOptions ?? Options.Create(new LighterSocketOptions()), loggerFactory);
            Mexc = new MexcSocketClient(mexcSocketOptions ?? Options.Create(new MexcSocketOptions()), loggerFactory);
            OKX = new OKXSocketClient(okxSocketOptions ?? Options.Create(new OKXSocketOptions()), loggerFactory);
            Pionex = new PionexSocketClient(pionexSocketOptions ?? Options.Create(new PionexSocketOptions()), loggerFactory);
            Polymarket = new PolymarketSocketClient(polymarketSocketOptions ?? Options.Create(new PolymarketSocketOptions()), loggerFactory);
            Toobit = new ToobitSocketClient(toobitSocketOptions ?? Options.Create(new ToobitSocketOptions()), loggerFactory);
            Upbit = new UpbitSocketClient(upbitSocketOptions ?? Options.Create(new UpbitSocketOptions()), loggerFactory);
            Weex = new WeexSocketClient(weexSocketOptions ?? Options.Create(new WeexSocketOptions()), loggerFactory);
            WhiteBit = new WhiteBitSocketClient(whiteBitSocketOptions ?? Options.Create(new WhiteBitSocketOptions()), loggerFactory);
            XT = new XTSocketClient(xtSocketOptions ?? Options.Create(new XTSocketOptions()), loggerFactory);

            InitSharedClients();
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

        private void InitSharedClients()
        {
            _socketClients = [Aster, Binance, BingX, Bitfinex, Bitget, BitMart, BitMEX, Bitstamp, BloFin, Bybit, Coinbase, CoinEx, CoinW, CryptoCom,
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
                Bybit.V5InverseApi.SharedClient,
                Bybit.V5LinearApi.SharedClient,
                Bybit.V5PrivateApi.SharedClient,
                Bybit.V5SpotApi.SharedClient,
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
                Upbit.SpotApi.SharedClient,
                Toobit.SpotApi.SharedClient,
                Toobit.UsdtFuturesApi.SharedClient,
                Weex.SpotApi.SharedClient,
                Weex.FuturesApi.SharedClient,
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
        public async Task UnsubscribeAllAsync()
        {
            var tasks = new[]
            {
                Aster.UnsubscribeAllAsync(),
                Binance.UnsubscribeAllAsync(),
                BingX.UnsubscribeAllAsync(),
                Bitfinex.UnsubscribeAllAsync(),
                Bitget.UnsubscribeAllAsync(),
                BitMart.UnsubscribeAllAsync(),
                BitMEX.UnsubscribeAllAsync(),
                Bitstamp.UnsubscribeAllAsync(),
                BloFin.UnsubscribeAllAsync(),
                Bybit.UnsubscribeAllAsync(),
                Coinbase.UnsubscribeAllAsync(),
                CoinEx.UnsubscribeAllAsync(),
                CoinW.UnsubscribeAllAsync(),
                CryptoCom.UnsubscribeAllAsync(),
                DeepCoin.UnsubscribeAllAsync(),
                GateIo.UnsubscribeAllAsync(),
                HTX.UnsubscribeAllAsync(),
                HyperLiquid.UnsubscribeAllAsync(),
                Kraken.UnsubscribeAllAsync(),
                Kucoin.UnsubscribeAllAsync(),
                Lighter.UnsubscribeAllAsync(),
                Mexc.UnsubscribeAllAsync(),
                OKX.UnsubscribeAllAsync(),
                Pionex.UnsubscribeAllAsync(),
                Polymarket.UnsubscribeAllAsync(),
                Toobit.UnsubscribeAllAsync(),
                Upbit.UnsubscribeAllAsync(),
                Weex.UnsubscribeAllAsync(),
                WhiteBit.UnsubscribeAllAsync(),
                XT.UnsubscribeAllAsync()
            };
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
    }
}
