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
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
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
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;
using Toobit.Net;
using Toobit.Net.Clients;
using Toobit.Net.Interfaces.Clients;
using Toobit.Net.Objects.Options;
using Upbit.Net.Clients;
using Upbit.Net.Interfaces.Clients;
using Upbit.Net.Objects.Options;
using WhiteBit.Net;
using WhiteBit.Net.Clients;
using WhiteBit.Net.Interfaces.Clients;
using WhiteBit.Net.Objects.Options;
using XT.Net;
using XT.Net.Clients;
using XT.Net.Interfaces.Clients;
using XT.Net.Objects.Options;
using Weex.Net;
using Weex.Net.Clients;
using Weex.Net.Interfaces.Clients;
using Weex.Net.Objects.Options;

namespace CryptoClients.Net.Clients
{
    /// <inheritdoc />
    public class ExchangeUserClientProvider : IExchangeUserClientProvider
    {
        private HashSet<string>? _enabledExchanges;
        private Lazy<IAsterUserClientProvider> _asterProvider = null!;
        private Lazy<IBinanceUserClientProvider> _binanceProvider = null!;
        private Lazy<IBingXUserClientProvider> _bingXProvider = null!;
        private Lazy<IBitfinexUserClientProvider> _bitfinexProvider = null!;
        private Lazy<IBitgetUserClientProvider> _bitgetProvider = null!;
        private Lazy<IBitMartUserClientProvider> _bitMartProvider = null!;
        private Lazy<IBitMEXUserClientProvider> _bitMEXProvider = null!;
        private Lazy<IBitstampUserClientProvider> _bitstampProvider = null!;
        private Lazy<IBloFinUserClientProvider> _bloFinProvider = null!;
        private Lazy<IBybitUserClientProvider> _bybitProvider = null!;
        private Lazy<ICoinbaseUserClientProvider> _coinbaseProvider = null!;
        private Lazy<ICoinExUserClientProvider> _coinExProvider = null!;
        private Lazy<ICoinGeckoRestClient> _coinGeckoRestClient = null!;
        private Lazy<ICoinWUserClientProvider> _coinWProvider = null!;
        private Lazy<ICryptoComUserClientProvider> _cryptoComProvider = null!;
        private Lazy<IDeepCoinUserClientProvider> _deepCoinProvider = null!;
        private Lazy<IGateIoUserClientProvider> _gateIoProvider = null!;
        private Lazy<IHTXUserClientProvider> _htxProvider = null!;
        private Lazy<IHyperLiquidUserClientProvider> _hyperLiquidProvider = null!;
        private Lazy<IKrakenUserClientProvider> _krakenProvider = null!;
        private Lazy<IKucoinUserClientProvider> _kucoinProvider = null!;
        private Lazy<ILBankUserClientProvider> _lBankProvider = null!;
        private Lazy<ILighterUserClientProvider> _lighterProvider = null!;
        private Lazy<IMexcUserClientProvider> _mexcProvider = null!;
        private Lazy<IOKXUserClientProvider> _okxProvider = null!;
        private Lazy<IPionexUserClientProvider> _pionexProvider = null!;
        private Lazy<IPolymarketUserClientProvider> _polymarketProvider = null!;
        private Lazy<IToobitUserClientProvider> _toobitProvider = null!;
        private Lazy<IUpbitRestClient> _upbitRestClient = null!;
        private Lazy<IUpbitSocketClient> _upbitSocketClient = null!;
        private Lazy<IWeexUserClientProvider> _weexProvider = null!;
        private Lazy<IWhiteBitUserClientProvider> _whiteBitProvider = null!;
        private Lazy<IXTUserClientProvider> _xtProvider = null!;

        /// <summary>
        /// Create a new ExchangeUserProvider using the specified options
        /// </summary>
        public ExchangeUserClientProvider(Action<GlobalExchangeOptions>? globalOptions = null,
            Action<AsterOptions>? asterOptions = null,
            Action<BinanceOptions>? binanceOptions = null,
            Action<BingXOptions>? bingxOptions = null,
            Action<BitfinexOptions>? bitfinexOptions = null,
            Action<BitgetOptions>? bitgetOptions = null,
            Action<BitMartOptions>? bitMartOptions = null,
            Action<BitMEXOptions>? bitMEXOptions = null,
            Action<BitstampOptions>? bitstampOptions = null,
            Action<BloFinOptions>? bloFinOptions = null,
            Action<BybitOptions>? bybitOptions = null,
            Action<CoinbaseOptions>? coinbaseOptions = null,
            Action<CoinExOptions>? coinExOptions = null,
            Action<CoinGeckoRestOptions>? coinGeckoRestOptions = null,
            Action<CoinWOptions>? coinWOptions = null,
            Action<CryptoComOptions>? cryptoComOptions = null,
            Action<DeepCoinOptions>? deepCoinOptions = null,
            Action<GateIoOptions>? gateIoOptions = null,
            Action<HTXOptions>? htxOptions = null,
            Action<HyperLiquidOptions>? hyperLiquidOptions = null,
            Action<KrakenOptions>? krakenOptions = null,
            Action<KucoinOptions>? kucoinOptions = null,
            Action<LBankOptions>? lBankOptions = null,
            Action<LighterOptions>? lighterOptions = null,
            Action<MexcOptions>? mexcOptions = null,
            Action<OKXOptions>? okxOptions = null,
            Action<PionexOptions>? pionexOptions = null,
            Action<PolymarketOptions>? polymarketOptions = null,
            Action<ToobitOptions>? toobitOptions = null,
            Action<UpbitRestOptions>? upbitRestOptions = null,
            Action<UpbitSocketOptions>? upbitSocketOptions = null,
            Action<WeexOptions>? weexOptions = null,
            Action<WhiteBitOptions>? whiteBitOptions = null,
            Action<XTOptions>? xtOptions = null)
        {
            IEnumerable<string>? enabledExchanges = null;

            Action<TOptions> SetGlobalOptionsBase<TOptions, TRestOptions, TSocketOptions, TEnvironment>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TEnvironment environment)
                where TOptions : LibraryOptions<TRestOptions, TSocketOptions, TEnvironment>
                where TRestOptions : RestExchangeOptions<TEnvironment>, new()
                where TSocketOptions : SocketExchangeOptions<TEnvironment>, new()
                where TEnvironment : TradeEnvironment
            {
                var restDelegate = (TOptions options) =>
                {
                    options.Environment = environment;
                    options.Rest.Proxy = globalOptions.Proxy;
                    options.Socket.Proxy = globalOptions.Proxy;
                    options.Rest.OutputOriginalData = globalOptions.OutputOriginalData ?? options.Rest.OutputOriginalData;
                    options.Socket.OutputOriginalData = globalOptions.OutputOriginalData ?? options.Socket.OutputOriginalData;
                    options.Rest.RequestTimeout = globalOptions.RequestTimeout ?? options.Rest.RequestTimeout;
                    options.Socket.RequestTimeout = globalOptions.RequestTimeout ?? options.Socket.RequestTimeout;
                    options.Rest.RateLimiterEnabled = globalOptions.RateLimiterEnabled ?? options.Rest.RateLimiterEnabled;
                    options.Socket.RateLimiterEnabled = globalOptions.RateLimiterEnabled ?? options.Socket.RateLimiterEnabled;
                    options.Rest.RateLimitingBehaviour = globalOptions.RateLimitingBehaviour ?? options.Rest.RateLimitingBehaviour;
                    options.Socket.RateLimitingBehaviour = globalOptions.RateLimitingBehaviour ?? options.Socket.RateLimitingBehaviour;
                    options.Rest.CachingEnabled = globalOptions.CachingEnabled ?? options.Rest.CachingEnabled;
                    exchangeDelegate?.Invoke(options);
                };

                return restDelegate;
            }

            Action<TOptions> SetGlobalOptions<TOptions, TRestOptions, TSocketOptions, TCredentials, TEnvironment>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TCredentials? credentials, TEnvironment environment)
                where TOptions : LibraryOptions<TRestOptions, TSocketOptions, TCredentials, TEnvironment>
                where TRestOptions : RestExchangeOptions<TEnvironment, TCredentials>, new()
                where TSocketOptions : SocketExchangeOptions<TEnvironment, TCredentials>, new()
                where TCredentials : ApiCredentials
                where TEnvironment : TradeEnvironment
            {
                var restDelegate = (TOptions options) =>
                {
                    SetGlobalOptionsBase<TOptions, TRestOptions, TSocketOptions, TEnvironment>(globalOptions, exchangeDelegate, environment);
                    options.ApiCredentials = credentials;
                    
                    exchangeDelegate?.Invoke(options);
                };

                return restDelegate;
            }

            if (globalOptions != null)
            {
                var global = new GlobalExchangeOptions();
                globalOptions.Invoke(global);
                enabledExchanges = global.EnabledExchanges;

                ExchangeCredentials? credentials = global.ApiCredentials;
                Dictionary<string, string?>? environments = global.ApiEnvironments;
                asterOptions = SetGlobalOptions<AsterOptions, AsterRestOptions, AsterSocketOptions, AsterCredentials, AsterEnvironment>(global, asterOptions, credentials?.Aster, environments?.TryGetValue(Exchange.Aster, out var asterEnvName) == true ? AsterEnvironment.GetEnvironmentByName(asterEnvName)! : AsterEnvironment.Live);
                binanceOptions = SetGlobalOptions<BinanceOptions, BinanceRestOptions, BinanceSocketOptions, BinanceCredentials, BinanceEnvironment>(global, binanceOptions, credentials?.Binance, environments?.TryGetValue(Exchange.Binance, out var binanceEnvName) == true ? BinanceEnvironment.GetEnvironmentByName(binanceEnvName)! : BinanceEnvironment.Live);
                bingxOptions = SetGlobalOptions<BingXOptions, BingXRestOptions, BingXSocketOptions, BingXCredentials, BingXEnvironment>(global, bingxOptions, credentials?.BingX, environments?.TryGetValue(Exchange.BingX, out var bingXEnvName) == true ? BingXEnvironment.GetEnvironmentByName(bingXEnvName)! : BingXEnvironment.Live);
                bitfinexOptions = SetGlobalOptions<BitfinexOptions, BitfinexRestOptions, BitfinexSocketOptions, BitfinexCredentials, BitfinexEnvironment>(global, bitfinexOptions, credentials?.Bitfinex, environments?.TryGetValue(Exchange.Bitfinex, out var bitfinexEnvName) == true ? BitfinexEnvironment.GetEnvironmentByName(bitfinexEnvName)! : BitfinexEnvironment.Live);
                bitgetOptions = SetGlobalOptions<BitgetOptions, BitgetRestOptions, BitgetSocketOptions, BitgetCredentials, BitgetEnvironment>(global, bitgetOptions, credentials?.Bitget, environments?.TryGetValue(Exchange.Bitget, out var bitgetEnvName) == true ? BitgetEnvironment.GetEnvironmentByName(bitgetEnvName)! : BitgetEnvironment.Live);
                bitMartOptions = SetGlobalOptions<BitMartOptions, BitMartRestOptions, BitMartSocketOptions, BitMartCredentials, BitMartEnvironment>(global, bitMartOptions, credentials?.BitMart, environments?.TryGetValue(Exchange.BitMart, out var bitMartEnvName) == true ? BitMartEnvironment.GetEnvironmentByName(bitMartEnvName)! : BitMartEnvironment.Live);
                bitMEXOptions = SetGlobalOptions<BitMEXOptions, BitMEXRestOptions, BitMEXSocketOptions, BitMEXCredentials, BitMEXEnvironment>(global, bitMEXOptions, credentials?.BitMEX, environments?.TryGetValue(Exchange.BitMEX, out var bitMEXEnvName) == true ? BitMEXEnvironment.GetEnvironmentByName(bitMEXEnvName)! : BitMEXEnvironment.Live);
                bitstampOptions = SetGlobalOptions<BitstampOptions, BitstampRestOptions, BitstampSocketOptions, BitstampCredentials, BitstampEnvironment>(global, bitstampOptions, credentials?.Bitstamp, environments?.TryGetValue(Exchange.Bitstamp, out var bitstampEnvName) == true ? BitstampEnvironment.GetEnvironmentByName(bitstampEnvName)! : BitstampEnvironment.Live);
                bloFinOptions = SetGlobalOptions<BloFinOptions, BloFinRestOptions, BloFinSocketOptions, BloFinCredentials, BloFinEnvironment>(global, bloFinOptions, credentials?.BloFin, environments?.TryGetValue(Exchange.BloFin, out var bloFinEnvName) == true ? BloFinEnvironment.GetEnvironmentByName(bloFinEnvName)! : BloFinEnvironment.Live);
                bybitOptions = SetGlobalOptions<BybitOptions, BybitRestOptions, BybitSocketOptions, BybitCredentials, BybitEnvironment>(global, bybitOptions, credentials?.Bybit, environments?.TryGetValue(Exchange.Bybit, out var bybitEnvName) == true ? BybitEnvironment.GetEnvironmentByName(bybitEnvName)! : BybitEnvironment.Live);
                coinbaseOptions = SetGlobalOptions<CoinbaseOptions, CoinbaseRestOptions, CoinbaseSocketOptions, CoinbaseCredentials, CoinbaseEnvironment>(global, coinbaseOptions, credentials?.Coinbase, environments?.TryGetValue(Exchange.Coinbase, out var coinbaseEnvName) == true ? CoinbaseEnvironment.GetEnvironmentByName(coinbaseEnvName)! : CoinbaseEnvironment.Live);
                coinExOptions = SetGlobalOptions<CoinExOptions, CoinExRestOptions, CoinExSocketOptions, CoinExCredentials, CoinExEnvironment>(global, coinExOptions, credentials?.CoinEx, environments?.TryGetValue(Exchange.CoinEx, out var coinExEnvName) == true ? CoinExEnvironment.GetEnvironmentByName(coinExEnvName)! : CoinExEnvironment.Live);
                coinWOptions = SetGlobalOptions<CoinWOptions, CoinWRestOptions, CoinWSocketOptions, CoinWCredentials, CoinWEnvironment>(global, coinWOptions, credentials?.CoinW, environments?.TryGetValue(Exchange.CoinW, out var coinWEnvName) == true ? CoinWEnvironment.GetEnvironmentByName(coinWEnvName)! : CoinWEnvironment.Live);
                cryptoComOptions = SetGlobalOptions<CryptoComOptions, CryptoComRestOptions, CryptoComSocketOptions, CryptoComCredentials, CryptoComEnvironment>(global, cryptoComOptions, credentials?.CryptoCom, environments?.TryGetValue(Exchange.CryptoCom, out var cryptoComEnvName) == true ? CryptoComEnvironment.GetEnvironmentByName(cryptoComEnvName)! : CryptoComEnvironment.Live);
                deepCoinOptions = SetGlobalOptions<DeepCoinOptions, DeepCoinRestOptions, DeepCoinSocketOptions, DeepCoinCredentials, DeepCoinEnvironment>(global, deepCoinOptions, credentials?.DeepCoin, environments?.TryGetValue(Exchange.DeepCoin, out var deepCoinEnvName) == true ? DeepCoinEnvironment.GetEnvironmentByName(deepCoinEnvName)! : DeepCoinEnvironment.Live);
                gateIoOptions = SetGlobalOptions<GateIoOptions, GateIoRestOptions, GateIoSocketOptions, GateIoCredentials, GateIoEnvironment>(global, gateIoOptions, credentials?.GateIo, environments?.TryGetValue(Exchange.GateIo, out var gateIoEnvName) == true ? GateIoEnvironment.GetEnvironmentByName(gateIoEnvName)! : GateIoEnvironment.Live);
                htxOptions = SetGlobalOptions<HTXOptions, HTXRestOptions, HTXSocketOptions, HTXCredentials, HTXEnvironment>(global, htxOptions, credentials?.HTX, environments?.TryGetValue(Exchange.HTX, out var htxEnvName) == true ? HTXEnvironment.GetEnvironmentByName(htxEnvName)! : HTXEnvironment.Live);
                hyperLiquidOptions = SetGlobalOptions<HyperLiquidOptions, HyperLiquidRestOptions, HyperLiquidSocketOptions, HyperLiquidCredentials, HyperLiquidEnvironment>(global, hyperLiquidOptions, credentials?.HyperLiquid, environments?.TryGetValue(Exchange.HyperLiquid, out var hyperLiquidEnvName) == true ? HyperLiquidEnvironment.GetEnvironmentByName(hyperLiquidEnvName)! : HyperLiquidEnvironment.Live);
                krakenOptions = SetGlobalOptions<KrakenOptions, KrakenRestOptions, KrakenSocketOptions, KrakenCredentials, KrakenEnvironment>(global, krakenOptions, credentials?.Kraken, environments?.TryGetValue(Exchange.Kraken, out var krakenEnvName) == true ? KrakenEnvironment.GetEnvironmentByName(krakenEnvName)! : KrakenEnvironment.Live);
                kucoinOptions = SetGlobalOptions<KucoinOptions, KucoinRestOptions, KucoinSocketOptions, KucoinCredentials, KucoinEnvironment>(global, kucoinOptions, credentials?.Kucoin, environments?.TryGetValue(Exchange.Kucoin, out var kucoinEnvName) == true ? KucoinEnvironment.GetEnvironmentByName(kucoinEnvName)! : KucoinEnvironment.Live);
                lBankOptions = SetGlobalOptions<LBankOptions, LBankRestOptions, LBankSocketOptions, LBankCredentials, LBankEnvironment>(global, lBankOptions, credentials?.LBank, environments?.TryGetValue(Exchange.LBank, out var lBankEnvName) == true ? LBankEnvironment.GetEnvironmentByName(lBankEnvName)! : LBankEnvironment.Live);
                lighterOptions = SetGlobalOptions<LighterOptions, LighterRestOptions, LighterSocketOptions, LighterCredentials, LighterEnvironment>(global, lighterOptions, credentials?.Lighter, environments?.TryGetValue(Exchange.Lighter, out var lighterEnvName) == true ? LighterEnvironment.GetEnvironmentByName(lighterEnvName)! : LighterEnvironment.Live);
                mexcOptions = SetGlobalOptions<MexcOptions, MexcRestOptions, MexcSocketOptions, MexcCredentials, MexcEnvironment>(global, mexcOptions, credentials?.Mexc, environments?.TryGetValue(Exchange.Mexc, out var mexcEnvName) == true ? MexcEnvironment.GetEnvironmentByName(mexcEnvName)! : MexcEnvironment.Live);
                okxOptions = SetGlobalOptions<OKXOptions, OKXRestOptions, OKXSocketOptions, OKXCredentials, OKXEnvironment>(global, okxOptions, credentials?.OKX, environments?.TryGetValue(Exchange.OKX, out var okxEnvName) == true ? OKXEnvironment.GetEnvironmentByName(okxEnvName)! : OKXEnvironment.Live);
                pionexOptions = SetGlobalOptions<PionexOptions, PionexRestOptions, PionexSocketOptions, PionexCredentials, PionexEnvironment>(global, pionexOptions, credentials?.Pionex, environments?.TryGetValue(Exchange.Pionex, out var pionexEnvName) == true ? PionexEnvironment.GetEnvironmentByName(pionexEnvName)! : PionexEnvironment.Live);
                polymarketOptions = SetGlobalOptions<PolymarketOptions, PolymarketRestOptions, PolymarketSocketOptions, PolymarketCredentials, PolymarketEnvironment>(global, polymarketOptions, credentials?.Polymarket, environments?.TryGetValue(Platform.Polymarket, out var polymarketEnvName) == true ? PolymarketEnvironment.GetEnvironmentByName(polymarketEnvName)! : PolymarketEnvironment.Live);
                toobitOptions = SetGlobalOptions<ToobitOptions, ToobitRestOptions, ToobitSocketOptions, ToobitCredentials, ToobitEnvironment>(global, toobitOptions, credentials?.Toobit, environments?.TryGetValue(Exchange.Toobit, out var toobitEnvName) == true ? ToobitEnvironment.GetEnvironmentByName(toobitEnvName)! : ToobitEnvironment.Live);
                weexOptions = SetGlobalOptions<WeexOptions, WeexRestOptions, WeexSocketOptions, WeexCredentials, WeexEnvironment>(global, weexOptions, credentials?.Weex, environments?.TryGetValue(Exchange.Weex, out var weexEnvName) == true ? WeexEnvironment.GetEnvironmentByName(weexEnvName)! : WeexEnvironment.Live);
                whiteBitOptions = SetGlobalOptions<WhiteBitOptions, WhiteBitRestOptions, WhiteBitSocketOptions, WhiteBitCredentials, WhiteBitEnvironment>(global, whiteBitOptions, credentials?.WhiteBit, environments?.TryGetValue(Exchange.WhiteBit, out var whiteBitEnvName) == true ? WhiteBitEnvironment.GetEnvironmentByName(whiteBitEnvName)! : WhiteBitEnvironment.Live);
                xtOptions = SetGlobalOptions<XTOptions, XTRestOptions, XTSocketOptions, XTCredentials, XTEnvironment>(global, xtOptions, credentials?.XT, environments?.TryGetValue(Exchange.XT, out var xtEnvName) == true ? XTEnvironment.GetEnvironmentByName(xtEnvName)! : XTEnvironment.Live);
            }

            InitializeProviders(enabledExchanges,
                () => new AsterUserClientProvider(asterOptions), () => new BinanceUserClientProvider(binanceOptions),
                () => new BingXUserClientProvider(bingxOptions), () => new BitfinexUserClientProvider(bitfinexOptions),
                () => new BitgetUserClientProvider(bitgetOptions), () => new BitMartUserClientProvider(bitMartOptions),
                () => new BitMEXUserClientProvider(bitMEXOptions), () => new BitstampUserClientProvider(bitstampOptions),
                () => new BloFinUserClientProvider(bloFinOptions), () => new BybitUserClientProvider(bybitOptions),
                () => new CoinbaseUserClientProvider(coinbaseOptions), () => new CoinExUserClientProvider(coinExOptions),
                () => new CoinGeckoRestClient(coinGeckoRestOptions), () => new CoinWUserClientProvider(coinWOptions),
                () => new CryptoComUserClientProvider(cryptoComOptions), () => new DeepCoinUserClientProvider(deepCoinOptions),
                () => new GateIoUserClientProvider(gateIoOptions), () => new HTXUserClientProvider(htxOptions),
                () => new HyperLiquidUserClientProvider(hyperLiquidOptions), () => new KrakenUserClientProvider(krakenOptions),
                () => new KucoinUserClientProvider(kucoinOptions), () => new LBankUserClientProvider(lBankOptions),
                () => new LighterUserClientProvider(lighterOptions), () => new MexcUserClientProvider(mexcOptions),
                () => new OKXUserClientProvider(okxOptions), () => new PionexUserClientProvider(pionexOptions),
                () => new PolymarketUserClientProvider(polymarketOptions), () => new ToobitUserClientProvider(toobitOptions),
                () => new UpbitRestClient(upbitRestOptions), () => new UpbitSocketClient(upbitSocketOptions),
                () => new WeexUserClientProvider(weexOptions), () => new WhiteBitUserClientProvider(whiteBitOptions),
                () => new XTUserClientProvider(xtOptions));
        }

        /// <summary>
        /// DI ctor
        /// </summary>
        public ExchangeUserClientProvider(
            IAsterUserClientProvider asterProvider,
            IBinanceUserClientProvider binanceProvider,
            IBingXUserClientProvider bingXProvider,
            IBitfinexUserClientProvider bitfinexProvider,
            IBitgetUserClientProvider bitgetProvider,
            IBitMartUserClientProvider bitMartProvider,
            IBitMEXUserClientProvider bitMEXProvider,
            IBitstampUserClientProvider bitstampProvider,
            IBloFinUserClientProvider bloFinProvider,
            IBybitUserClientProvider bybitProvider,
            ICoinbaseUserClientProvider coinbaseProvider,
            ICoinExUserClientProvider coinExProvider,
            ICoinGeckoRestClient coinGeckoRestClient,
            ICoinWUserClientProvider coinWProvider,
            ICryptoComUserClientProvider cryptoComProvider,
            IDeepCoinUserClientProvider deepCoinProvider,
            IGateIoUserClientProvider gateIoProvider,
            IHTXUserClientProvider htxProvider,
            IHyperLiquidUserClientProvider hyperLiquidProvider,
            IKrakenUserClientProvider krakenProvider,
            IKucoinUserClientProvider kucoinProvider,
            ILBankUserClientProvider lBankProvider,
            ILighterUserClientProvider lighterProvider,
            IMexcUserClientProvider mexcProvider,
            IOKXUserClientProvider okxProvider,
            IPionexUserClientProvider pionexProvider,
            IPolymarketUserClientProvider polymarketProvider,
            IToobitUserClientProvider toobitProvider,
            IUpbitRestClient upbitRestClient,
            IUpbitSocketClient upbitSocketClient,
            IWeexUserClientProvider weexProvider,
            IWhiteBitUserClientProvider whiteBitProvider,
            IXTUserClientProvider xtProvider
            )
        {
            InitializeProviders(null,
                () => asterProvider, () => binanceProvider, () => bingXProvider, () => bitfinexProvider,
                () => bitgetProvider, () => bitMartProvider, () => bitMEXProvider, () => bitstampProvider,
                () => bloFinProvider, () => bybitProvider, () => coinbaseProvider, () => coinExProvider,
                () => coinGeckoRestClient, () => coinWProvider, () => cryptoComProvider, () => deepCoinProvider,
                () => gateIoProvider, () => htxProvider, () => hyperLiquidProvider, () => krakenProvider,
                () => kucoinProvider, () => lBankProvider, () => lighterProvider, () => mexcProvider,
                () => okxProvider, () => pionexProvider, () => polymarketProvider, () => toobitProvider,
                () => upbitRestClient, () => upbitSocketClient, () => weexProvider, () => whiteBitProvider, () => xtProvider);
        }

        internal ExchangeUserClientProvider(IEnumerable<string>? enabledExchanges, IServiceProvider serviceProvider)
        {
            InitializeProviders(enabledExchanges,
                () => serviceProvider.GetRequiredService<IAsterUserClientProvider>(), () => serviceProvider.GetRequiredService<IBinanceUserClientProvider>(),
                () => serviceProvider.GetRequiredService<IBingXUserClientProvider>(), () => serviceProvider.GetRequiredService<IBitfinexUserClientProvider>(),
                () => serviceProvider.GetRequiredService<IBitgetUserClientProvider>(), () => serviceProvider.GetRequiredService<IBitMartUserClientProvider>(),
                () => serviceProvider.GetRequiredService<IBitMEXUserClientProvider>(), () => serviceProvider.GetRequiredService<IBitstampUserClientProvider>(),
                () => serviceProvider.GetRequiredService<IBloFinUserClientProvider>(), () => serviceProvider.GetRequiredService<IBybitUserClientProvider>(),
                () => serviceProvider.GetRequiredService<ICoinbaseUserClientProvider>(), () => serviceProvider.GetRequiredService<ICoinExUserClientProvider>(),
                () => serviceProvider.GetRequiredService<ICoinGeckoRestClient>(), () => serviceProvider.GetRequiredService<ICoinWUserClientProvider>(),
                () => serviceProvider.GetRequiredService<ICryptoComUserClientProvider>(), () => serviceProvider.GetRequiredService<IDeepCoinUserClientProvider>(),
                () => serviceProvider.GetRequiredService<IGateIoUserClientProvider>(), () => serviceProvider.GetRequiredService<IHTXUserClientProvider>(),
                () => serviceProvider.GetRequiredService<IHyperLiquidUserClientProvider>(), () => serviceProvider.GetRequiredService<IKrakenUserClientProvider>(),
                () => serviceProvider.GetRequiredService<IKucoinUserClientProvider>(), () => serviceProvider.GetRequiredService<ILBankUserClientProvider>(),
                () => serviceProvider.GetRequiredService<ILighterUserClientProvider>(), () => serviceProvider.GetRequiredService<IMexcUserClientProvider>(),
                () => serviceProvider.GetRequiredService<IOKXUserClientProvider>(), () => serviceProvider.GetRequiredService<IPionexUserClientProvider>(),
                () => serviceProvider.GetRequiredService<IPolymarketUserClientProvider>(), () => serviceProvider.GetRequiredService<IToobitUserClientProvider>(),
                () => serviceProvider.GetRequiredService<IUpbitRestClient>(), () => serviceProvider.GetRequiredService<IUpbitSocketClient>(),
                () => serviceProvider.GetRequiredService<IWeexUserClientProvider>(), () => serviceProvider.GetRequiredService<IWhiteBitUserClientProvider>(),
                () => serviceProvider.GetRequiredService<IXTUserClientProvider>());
        }

        /// <inheritdoc />
        public void InitializeUserClient(string userIdentifier, ExchangeCredentials credentials, Dictionary<string, string?> environments)
        {
            var restClient = GetRestClient(userIdentifier, credentials, environments);
            var socketClient = GetSocketClient(userIdentifier, credentials, environments);
            foreach (var exchange in (IEnumerable<string>?)_enabledExchanges ?? Platform.All)
            {
                restClient.GetExchangeSharedClients(exchange);
                socketClient.GetExchangeSharedClients(exchange);
            }
        }

        /// <inheritdoc />
        public void ClearUserClients(string userIdentifier, string? exchange = null)
        {
            ClearIfCreated(Exchange.Aster, _asterProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Binance, _binanceProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.BingX, _bingXProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Bitfinex, _bitfinexProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Bitget, _bitgetProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.BitMart, _bitMartProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.BitMEX, _bitMEXProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Bitstamp, _bitstampProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.BloFin, _bloFinProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Bybit, _bybitProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Coinbase, _coinbaseProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.CoinEx, _coinExProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.CoinW, _coinWProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.CryptoCom, _cryptoComProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.DeepCoin, _deepCoinProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.GateIo, _gateIoProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.HTX, _htxProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.HyperLiquid, _hyperLiquidProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Kraken, _krakenProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Kucoin, _kucoinProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.LBank, _lBankProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Lighter, _lighterProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Mexc, _mexcProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.OKX, _okxProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Pionex, _pionexProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Platform.Polymarket, _polymarketProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Toobit, _toobitProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.Weex, _weexProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.WhiteBit, _whiteBitProvider, x => x.ClearUserClients(userIdentifier), exchange);
            ClearIfCreated(Exchange.XT, _xtProvider, x => x.ClearUserClients(userIdentifier), exchange);
        }

        /// <inheritdoc />
        public IExchangeRestClient GetRestClient(string userIdentifier, ExchangeCredentials? credentials = null, Dictionary<string, string?>? environments = null)
        {
            environments ??= new();
            credentials ??= new();

            var client = new ExchangeRestClient(
                _enabledExchanges,
                () => _asterProvider.Value.GetRestClient(userIdentifier, credentials.Aster, environments.TryGetValue(Exchange.Aster, out var asterEnv) ? AsterEnvironment.GetEnvironmentByName(asterEnv) : null),
                () => _binanceProvider.Value.GetRestClient(userIdentifier, credentials.Binance, environments.TryGetValue(Exchange.Binance, out var binanceEnv) ? BinanceEnvironment.GetEnvironmentByName(binanceEnv) : null),
                () => _bingXProvider.Value.GetRestClient(userIdentifier, credentials.BingX, environments.TryGetValue(Exchange.BingX, out var bingxEnv) ? BingXEnvironment.GetEnvironmentByName(bingxEnv) : null),
                () => _bitfinexProvider.Value.GetRestClient(userIdentifier, credentials.Bitfinex, environments.TryGetValue(Exchange.Bitfinex, out var bitfinexEnv) ? BitfinexEnvironment.GetEnvironmentByName(bitfinexEnv) : null),
                () => _bitgetProvider.Value.GetRestClient(userIdentifier, credentials.Bitget, environments.TryGetValue(Exchange.Bitget, out var bitgetEnv) ? BitgetEnvironment.GetEnvironmentByName(bitgetEnv) : null),
                () => _bitMartProvider.Value.GetRestClient(userIdentifier, credentials.BitMart, environments.TryGetValue(Exchange.BitMart, out var bitmartEnv) ? BitMartEnvironment.GetEnvironmentByName(bitmartEnv) : null),
                () => _bitMEXProvider.Value.GetRestClient(userIdentifier, credentials.BitMEX, environments.TryGetValue(Exchange.BitMEX, out var bitMEXEnv) ? BitMEXEnvironment.GetEnvironmentByName(bitMEXEnv) : null),
                () => _bitstampProvider.Value.GetRestClient(userIdentifier, credentials.Bitstamp, environments.TryGetValue(Exchange.Bitstamp, out var bitstampEnv) ? BitstampEnvironment.GetEnvironmentByName(bitstampEnv) : null),
                () => _bloFinProvider.Value.GetRestClient(userIdentifier, credentials.BloFin, environments.TryGetValue(Exchange.BloFin, out var bloFinEnv) ? BloFinEnvironment.GetEnvironmentByName(bloFinEnv) : null),
                () => _bybitProvider.Value.GetRestClient(userIdentifier, credentials.Bybit, environments.TryGetValue(Exchange.Bybit, out var bybitEnv) ? BybitEnvironment.GetEnvironmentByName(bybitEnv) : null),
                () => _coinbaseProvider.Value.GetRestClient(userIdentifier, credentials.Coinbase, environments.TryGetValue(Exchange.Coinbase, out var coinbaseEnv) ? CoinbaseEnvironment.GetEnvironmentByName(coinbaseEnv) : null),
                () => _coinExProvider.Value.GetRestClient(userIdentifier, credentials.CoinEx, environments.TryGetValue(Exchange.CoinEx, out var coinexEnv) ? CoinExEnvironment.GetEnvironmentByName(coinexEnv) : null),
                () => _coinGeckoRestClient.Value,
                () => _coinWProvider.Value.GetRestClient(userIdentifier, credentials.CoinW, environments.TryGetValue(Exchange.CoinW, out var coinWEnv) ? CoinWEnvironment.GetEnvironmentByName(coinWEnv) : null),
                () => _cryptoComProvider.Value.GetRestClient(userIdentifier, credentials.CryptoCom, environments.TryGetValue(Exchange.CryptoCom, out var cryptoComEnv) ? CryptoComEnvironment.GetEnvironmentByName(cryptoComEnv) : null),
                () => _deepCoinProvider.Value.GetRestClient(userIdentifier, credentials.DeepCoin, environments.TryGetValue(Exchange.DeepCoin, out var deepcoinEnv) ? DeepCoinEnvironment.GetEnvironmentByName(deepcoinEnv) : null),
                () => _gateIoProvider.Value.GetRestClient(userIdentifier, credentials.GateIo, environments.TryGetValue(Exchange.GateIo, out var gateIoEnv) ? GateIoEnvironment.GetEnvironmentByName(gateIoEnv) : null),
                () => _htxProvider.Value.GetRestClient(userIdentifier, credentials.HTX, environments.TryGetValue(Exchange.HTX, out var htxEnv) ? HTXEnvironment.GetEnvironmentByName(htxEnv) : null),
                () => _hyperLiquidProvider.Value.GetRestClient(userIdentifier, credentials.HyperLiquid, environments.TryGetValue(Exchange.HyperLiquid, out var hyperliquidEnv) ? HyperLiquidEnvironment.GetEnvironmentByName(hyperliquidEnv) : null),
                () => _krakenProvider.Value.GetRestClient(userIdentifier, credentials.Kraken, environments.TryGetValue(Exchange.Kraken, out var krakenEnv) ? KrakenEnvironment.GetEnvironmentByName(krakenEnv) : null),
                () => _kucoinProvider.Value.GetRestClient(userIdentifier, credentials.Kucoin, environments.TryGetValue(Exchange.Kucoin, out var kucoinEnv) ? KucoinEnvironment.GetEnvironmentByName(kucoinEnv) : null),
                () => _lBankProvider.Value.GetRestClient(userIdentifier, credentials.LBank, environments.TryGetValue(Exchange.LBank, out var lBankEnv) ? LBankEnvironment.GetEnvironmentByName(lBankEnv) : null),
                () => _lighterProvider.Value.GetRestClient(userIdentifier, credentials.Lighter, environments.TryGetValue(Exchange.Lighter, out var lighterEnv) ? LighterEnvironment.GetEnvironmentByName(lighterEnv) : null),
                () => _mexcProvider.Value.GetRestClient(userIdentifier, credentials.Mexc, environments.TryGetValue(Exchange.Mexc, out var mexcEnv) ? MexcEnvironment.GetEnvironmentByName(mexcEnv) : null),
                () => _okxProvider.Value.GetRestClient(userIdentifier, credentials.OKX, environments.TryGetValue(Exchange.OKX, out var okxEnv) ? OKXEnvironment.GetEnvironmentByName(okxEnv) : null),
                () => _pionexProvider.Value.GetRestClient(userIdentifier, credentials.Pionex, environments.TryGetValue(Exchange.Pionex, out var pionexEnv) ? PionexEnvironment.GetEnvironmentByName(pionexEnv) : null),
                () => _polymarketProvider.Value.GetRestClient(userIdentifier, credentials.Polymarket, environments.TryGetValue(Platform.Polymarket, out var polymarketEnv) ? PolymarketEnvironment.GetEnvironmentByName(polymarketEnv) : null),
                () => _toobitProvider.Value.GetRestClient(userIdentifier, credentials.Toobit, environments.TryGetValue(Exchange.Toobit, out var toobitEnv) ? ToobitEnvironment.GetEnvironmentByName(toobitEnv) : null),
                () => _upbitRestClient.Value,
                () => _weexProvider.Value.GetRestClient(userIdentifier, credentials.Weex, environments.TryGetValue(Exchange.Weex, out var weexEnv) ? WeexEnvironment.GetEnvironmentByName(weexEnv) : null),
                () => _whiteBitProvider.Value.GetRestClient(userIdentifier, credentials.WhiteBit, environments.TryGetValue(Exchange.WhiteBit, out var whiteBitEnv) ? WhiteBitEnvironment.GetEnvironmentByName(whiteBitEnv) : null),
                () => _xtProvider.Value.GetRestClient(userIdentifier, credentials.XT, environments.TryGetValue(Exchange.XT, out var xtEnv) ? XTEnvironment.GetEnvironmentByName(xtEnv) : null)
                );

            return client;
        }

        /// <inheritdoc />
        public IExchangeSocketClient GetSocketClient(string userIdentifier, ExchangeCredentials? credentials = null, Dictionary<string, string?>? environments = null)
        {
            environments ??= new();
            credentials ??= new();

            var client = new ExchangeSocketClient(
                _enabledExchanges,
                () => _asterProvider.Value.GetSocketClient(userIdentifier, credentials.Aster, environments.TryGetValue(Exchange.Aster, out var asterEnv) ? AsterEnvironment.GetEnvironmentByName(asterEnv) : null),
                () => _binanceProvider.Value.GetSocketClient(userIdentifier, credentials.Binance, environments.TryGetValue(Exchange.Binance, out var binanceEnv) ? BinanceEnvironment.GetEnvironmentByName(binanceEnv) : null),
                () => _bingXProvider.Value.GetSocketClient(userIdentifier, credentials.BingX, environments.TryGetValue(Exchange.BingX, out var bingxEnv) ? BingXEnvironment.GetEnvironmentByName(bingxEnv) : null),
                () => _bitfinexProvider.Value.GetSocketClient(userIdentifier, credentials.Bitfinex, environments.TryGetValue(Exchange.Bitfinex, out var bitfinexEnv) ? BitfinexEnvironment.GetEnvironmentByName(bitfinexEnv) : null),
                () => _bitgetProvider.Value.GetSocketClient(userIdentifier, credentials.Bitget, environments.TryGetValue(Exchange.Bitget, out var bitgetEnv) ? BitgetEnvironment.GetEnvironmentByName(bitgetEnv) : null),
                () => _bitMartProvider.Value.GetSocketClient(userIdentifier, credentials.BitMart, environments.TryGetValue(Exchange.BitMart, out var bitmartEnv) ? BitMartEnvironment.GetEnvironmentByName(bitmartEnv) : null),
                () => _bitMEXProvider.Value.GetSocketClient(userIdentifier, credentials.BitMEX, environments.TryGetValue(Exchange.BitMEX, out var bitMEXEnv) ? BitMEXEnvironment.GetEnvironmentByName(bitMEXEnv) : null),
                () => _bitstampProvider.Value.GetSocketClient(userIdentifier, credentials.Bitstamp, environments.TryGetValue(Exchange.Bitstamp, out var bitstampEnv) ? BitstampEnvironment.GetEnvironmentByName(bitstampEnv) : null),
                () => _bloFinProvider.Value.GetSocketClient(userIdentifier, credentials.BloFin, environments.TryGetValue(Exchange.BloFin, out var bloFinEnv) ? BloFinEnvironment.GetEnvironmentByName(bloFinEnv) : null),
                () => _bybitProvider.Value.GetSocketClient(userIdentifier, credentials.Bybit, environments.TryGetValue(Exchange.Bybit, out var bybitEnv) ? BybitEnvironment.GetEnvironmentByName(bybitEnv) : null),
                () => _coinbaseProvider.Value.GetSocketClient(userIdentifier, credentials.Coinbase, environments.TryGetValue(Exchange.Coinbase, out var coinbaseEnv) ? CoinbaseEnvironment.GetEnvironmentByName(coinbaseEnv) : null),
                () => _coinExProvider.Value.GetSocketClient(userIdentifier, credentials.CoinEx, environments.TryGetValue(Exchange.CoinEx, out var coinexEnv) ? CoinExEnvironment.GetEnvironmentByName(coinexEnv) : null),
                () => _coinWProvider.Value.GetSocketClient(userIdentifier, credentials.CoinW, environments.TryGetValue(Exchange.CoinW, out var coinWEnv) ? CoinWEnvironment.GetEnvironmentByName(coinWEnv) : null),
                () => _cryptoComProvider.Value.GetSocketClient(userIdentifier, credentials.CryptoCom, environments.TryGetValue(Exchange.CryptoCom, out var cryptoComEnv) ? CryptoComEnvironment.GetEnvironmentByName(cryptoComEnv) : null),
                () => _deepCoinProvider.Value.GetSocketClient(userIdentifier, credentials.DeepCoin, environments.TryGetValue(Exchange.DeepCoin, out var deepcoinEnv) ? DeepCoinEnvironment.GetEnvironmentByName(deepcoinEnv) : null),
                () => _gateIoProvider.Value.GetSocketClient(userIdentifier, credentials.GateIo, environments.TryGetValue(Exchange.GateIo, out var gateIoEnv) ? GateIoEnvironment.GetEnvironmentByName(gateIoEnv) : null),
                () => _htxProvider.Value.GetSocketClient(userIdentifier, credentials.HTX, environments.TryGetValue(Exchange.HTX, out var htxEnv) ? HTXEnvironment.GetEnvironmentByName(htxEnv) : null),
                () => _hyperLiquidProvider.Value.GetSocketClient(userIdentifier, credentials.HyperLiquid, environments.TryGetValue(Exchange.HyperLiquid, out var hyperliquidEnv) ? HyperLiquidEnvironment.GetEnvironmentByName(hyperliquidEnv) : null),
                () => _krakenProvider.Value.GetSocketClient(userIdentifier, credentials.Kraken, environments.TryGetValue(Exchange.Kraken, out var krakenEnv) ? KrakenEnvironment.GetEnvironmentByName(krakenEnv) : null),
                () => _kucoinProvider.Value.GetSocketClient(userIdentifier, credentials.Kucoin, environments.TryGetValue(Exchange.Kucoin, out var kucoinEnv) ? KucoinEnvironment.GetEnvironmentByName(kucoinEnv) : null),
                () => _lBankProvider.Value.GetSocketClient(userIdentifier, credentials.LBank, environments.TryGetValue(Exchange.LBank, out var lBankEnv) ? LBankEnvironment.GetEnvironmentByName(lBankEnv) : null),
                () => _lighterProvider.Value.GetSocketClient(userIdentifier, credentials.Lighter, environments.TryGetValue(Exchange.Lighter, out var lighterEnv) ? LighterEnvironment.GetEnvironmentByName(lighterEnv) : null),
                () => _mexcProvider.Value.GetSocketClient(userIdentifier, credentials.Mexc, environments.TryGetValue(Exchange.Mexc, out var mexcEnv) ? MexcEnvironment.GetEnvironmentByName(mexcEnv) : null),
                () => _okxProvider.Value.GetSocketClient(userIdentifier, credentials.OKX, environments.TryGetValue(Exchange.OKX, out var okxEnv) ? OKXEnvironment.GetEnvironmentByName(okxEnv) : null),
                () => _pionexProvider.Value.GetSocketClient(userIdentifier, credentials.Pionex, environments.TryGetValue(Exchange.Pionex, out var pionexEnv) ? PionexEnvironment.GetEnvironmentByName(pionexEnv) : null),
                () => _polymarketProvider.Value.GetSocketClient(userIdentifier, credentials.Polymarket, environments.TryGetValue(Platform.Polymarket, out var polymarketEnv) ? PolymarketEnvironment.GetEnvironmentByName(polymarketEnv) : null),
                () => _toobitProvider.Value.GetSocketClient(userIdentifier, credentials.Toobit, environments.TryGetValue(Exchange.Toobit, out var toobitEnv) ? ToobitEnvironment.GetEnvironmentByName(toobitEnv) : null),
                () => _upbitSocketClient.Value,
                () => _weexProvider.Value.GetSocketClient(userIdentifier, credentials.Weex, environments.TryGetValue(Exchange.Weex, out var weexEnv) ? WeexEnvironment.GetEnvironmentByName(weexEnv) : null),
                () => _whiteBitProvider.Value.GetSocketClient(userIdentifier, credentials.WhiteBit, environments.TryGetValue(Exchange.WhiteBit, out var whiteBitEnv) ? WhiteBitEnvironment.GetEnvironmentByName(whiteBitEnv) : null),
                () => _xtProvider.Value.GetSocketClient(userIdentifier, credentials.XT, environments.TryGetValue(Exchange.XT, out var xtEnv) ? XTEnvironment.GetEnvironmentByName(xtEnv) : null)
                );

            return client;
        }

        private void InitializeProviders(
            IEnumerable<string>? enabledExchanges,
            Func<IAsterUserClientProvider> aster, Func<IBinanceUserClientProvider> binance, Func<IBingXUserClientProvider> bingX,
            Func<IBitfinexUserClientProvider> bitfinex, Func<IBitgetUserClientProvider> bitget, Func<IBitMartUserClientProvider> bitMart,
            Func<IBitMEXUserClientProvider> bitMEX, Func<IBitstampUserClientProvider> bitstamp, Func<IBloFinUserClientProvider> bloFin,
            Func<IBybitUserClientProvider> bybit, Func<ICoinbaseUserClientProvider> coinbase, Func<ICoinExUserClientProvider> coinEx,
            Func<ICoinGeckoRestClient> coinGecko, Func<ICoinWUserClientProvider> coinW, Func<ICryptoComUserClientProvider> cryptoCom,
            Func<IDeepCoinUserClientProvider> deepCoin, Func<IGateIoUserClientProvider> gateIo, Func<IHTXUserClientProvider> htx,
            Func<IHyperLiquidUserClientProvider> hyperLiquid, Func<IKrakenUserClientProvider> kraken, Func<IKucoinUserClientProvider> kucoin,
            Func<ILBankUserClientProvider> lBank, Func<ILighterUserClientProvider> lighter, Func<IMexcUserClientProvider> mexc,
            Func<IOKXUserClientProvider> okx, Func<IPionexUserClientProvider> pionex, Func<IPolymarketUserClientProvider> polymarket,
            Func<IToobitUserClientProvider> toobit, Func<IUpbitRestClient> upbitRest, Func<IUpbitSocketClient> upbitSocket,
            Func<IWeexUserClientProvider> weex, Func<IWhiteBitUserClientProvider> whiteBit, Func<IXTUserClientProvider> xt)
        {
            _enabledExchanges = enabledExchanges == null ? null : new HashSet<string>(enabledExchanges, StringComparer.OrdinalIgnoreCase);
            _asterProvider = CreateLazy(aster);
            _binanceProvider = CreateLazy(binance);
            _bingXProvider = CreateLazy(bingX);
            _bitfinexProvider = CreateLazy(bitfinex);
            _bitgetProvider = CreateLazy(bitget);
            _bitMartProvider = CreateLazy(bitMart);
            _bitMEXProvider = CreateLazy(bitMEX);
            _bitstampProvider = CreateLazy(bitstamp);
            _bloFinProvider = CreateLazy(bloFin);
            _bybitProvider = CreateLazy(bybit);
            _coinbaseProvider = CreateLazy(coinbase);
            _coinExProvider = CreateLazy(coinEx);
            _coinGeckoRestClient = CreateLazy(coinGecko);
            _coinWProvider = CreateLazy(coinW);
            _cryptoComProvider = CreateLazy(cryptoCom);
            _deepCoinProvider = CreateLazy(deepCoin);
            _gateIoProvider = CreateLazy(gateIo);
            _htxProvider = CreateLazy(htx);
            _hyperLiquidProvider = CreateLazy(hyperLiquid);
            _krakenProvider = CreateLazy(kraken);
            _kucoinProvider = CreateLazy(kucoin);
            _lBankProvider = CreateLazy(lBank);
            _lighterProvider = CreateLazy(lighter);
            _mexcProvider = CreateLazy(mexc);
            _okxProvider = CreateLazy(okx);
            _pionexProvider = CreateLazy(pionex);
            _polymarketProvider = CreateLazy(polymarket);
            _toobitProvider = CreateLazy(toobit);
            _upbitRestClient = CreateLazy(upbitRest);
            _upbitSocketClient = CreateLazy(upbitSocket);
            _weexProvider = CreateLazy(weex);
            _whiteBitProvider = CreateLazy(whiteBit);
            _xtProvider = CreateLazy(xt);
        }

#pragma warning disable IL2091
        private void ClearIfCreated<T>(string name, Lazy<T> provider, Action<T> clearAction, string? exchange)
        {
            if ((exchange == null || string.Equals(exchange, name, StringComparison.OrdinalIgnoreCase))
                && IsEnabled(name)
                && provider.IsValueCreated)
            {
                clearAction(provider.Value);
            }
        }

        private bool IsEnabled(string name) => _enabledExchanges == null || _enabledExchanges.Contains(name);

        private static Lazy<T> CreateLazy<T>(Func<T> factory)
            => new(factory, LazyThreadSafetyMode.ExecutionAndPublication);
#pragma warning restore IL2091
    }
}
