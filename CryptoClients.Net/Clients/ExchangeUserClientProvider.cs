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
using System;
using System.Collections.Generic;
using WhiteBit.Net;
using WhiteBit.Net.Clients;
using WhiteBit.Net.Interfaces.Clients;
using WhiteBit.Net.Objects.Options;
using XT.Net;
using XT.Net.Clients;
using XT.Net.Interfaces.Clients;
using XT.Net.Objects.Options;

namespace CryptoClients.Net.Clients
{
    /// <inheritdoc />
    public class ExchangeUserClientProvider : IExchangeUserClientProvider
    {
        private IBinanceUserClientProvider _binanceProvider;
        private IBingXUserClientProvider _bingXProvider;
        private IBitfinexUserClientProvider _bitfinexProvider;
        private IBitgetUserClientProvider _bitgetProvider;
        private IBitMartUserClientProvider _bitMartProvider;
        private IBitMEXUserClientProvider _bitMEXProvider;
        private IBybitUserClientProvider _bybitProvider;
        private ICoinbaseUserClientProvider _coinbaseProvider;
        private ICoinExUserClientProvider _coinExProvider;
        private ICoinWUserClientProvider _coinWProvider;
        private ICryptoComUserClientProvider _cryptoComProvider;
        private IDeepCoinUserClientProvider _deepCoinProvider;
        private IGateIoUserClientProvider _gateIoProvider;
        private IHTXUserClientProvider _htxProvider;
        private IHyperLiquidUserClientProvider _hyperLiquidProvider;
        private IKrakenUserClientProvider _krakenProvider;
        private IKucoinUserClientProvider _kucoinProvider;
        private IMexcUserClientProvider _mexcProvider;
        private IOKXUserClientProvider _okxProvider;
        private IToobitUserClientProvider _toobitProvider;
        private IWhiteBitUserClientProvider _whiteBitProvider;
        private IXTUserClientProvider _xtProvider;

        /// <summary>
        /// Create a new ExchangeUserProvider using the specified options
        /// </summary>
        public ExchangeUserClientProvider(Action<GlobalExchangeOptions>? globalOptions = null,
            Action<BinanceOptions>? binanceOptions = null,
            Action<BingXOptions>? bingxOptions = null,
            Action<BitfinexOptions>? bitfinexOptions = null,
            Action<BitgetOptions>? bitgetOptions = null,
            Action<BitMartOptions>? bitMartOptions = null,
            Action<BitMEXOptions>? bitMEXOptions = null,
            Action<BybitOptions>? bybitOptions = null,
            Action<CoinbaseOptions>? coinbaseOptions = null,
            Action<CoinExOptions>? coinExOptions = null,
            Action<CoinWOptions>? coinWOptions = null,
            Action<CryptoComOptions>? cryptoComOptions = null,
            Action<DeepCoinOptions>? deepCoinOptions = null,
            Action<GateIoOptions>? gateIoOptions = null,
            Action<HTXOptions>? htxOptions = null,
            Action<HyperLiquidOptions>? hyperLiquidOptions = null,
            Action<KrakenOptions>? krakenOptions = null,
            Action<KucoinOptions>? kucoinOptions = null,
            Action<MexcOptions>? mexcOptions = null,
            Action<OKXOptions>? okxOptions = null,
            Action<ToobitOptions>? toobitOptions = null,
            Action<WhiteBitOptions>? whiteBitOptions = null,
            Action<XTOptions>? xtOptions = null)
        {
            Action<TOptions> SetGlobalOptions<TOptions, TRestOptions, TSocketOptions, TCredentials, TEnvironment>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TCredentials? credentials, TEnvironment environment)
                where TOptions : LibraryOptions<TRestOptions, TSocketOptions, TCredentials, TEnvironment>
                where TRestOptions : RestExchangeOptions, new()
                where TSocketOptions : SocketExchangeOptions, new()
                where TCredentials : ApiCredentials
                where TEnvironment : TradeEnvironment
            {
                var restDelegate = (TOptions options) =>
                {
                    options.ApiCredentials = credentials;
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

            if (globalOptions != null)
            {
                var global = new GlobalExchangeOptions();
                globalOptions.Invoke(global);

                ExchangeCredentials? credentials = global.ApiCredentials;
                Dictionary<string, string?>? environments = global.ApiEnvironments;
                binanceOptions = SetGlobalOptions<BinanceOptions, BinanceRestOptions, BinanceSocketOptions, ApiCredentials, BinanceEnvironment>(global, binanceOptions, credentials?.Binance, environments?.TryGetValue(Exchange.Binance, out var binanceEnvName) == true ? BinanceEnvironment.GetEnvironmentByName(binanceEnvName)! : BinanceEnvironment.Live);
                bingxOptions = SetGlobalOptions<BingXOptions, BingXRestOptions, BingXSocketOptions, ApiCredentials, BingXEnvironment>(global, bingxOptions, credentials?.BingX, environments?.TryGetValue(Exchange.BingX, out var bingXEnvName) == true ? BingXEnvironment.GetEnvironmentByName(bingXEnvName)! : BingXEnvironment.Live);
                bitfinexOptions = SetGlobalOptions<BitfinexOptions, BitfinexRestOptions, BitfinexSocketOptions, ApiCredentials, BitfinexEnvironment>(global, bitfinexOptions, credentials?.Bitfinex, environments?.TryGetValue(Exchange.Bitfinex, out var bitfinexEnvName) == true ? BitfinexEnvironment.GetEnvironmentByName(bitfinexEnvName)! : BitfinexEnvironment.Live);
                bitgetOptions = SetGlobalOptions<BitgetOptions, BitgetRestOptions, BitgetSocketOptions, ApiCredentials, BitgetEnvironment>(global, bitgetOptions, credentials?.Bitget, environments?.TryGetValue(Exchange.Bitget, out var bitgetEnvName) == true ? BitgetEnvironment.GetEnvironmentByName(bitgetEnvName)! : BitgetEnvironment.Live);
                bitMartOptions = SetGlobalOptions<BitMartOptions, BitMartRestOptions, BitMartSocketOptions, ApiCredentials, BitMartEnvironment>(global, bitMartOptions, credentials?.BitMart, environments?.TryGetValue(Exchange.BitMart, out var bitMartEnvName) == true ? BitMartEnvironment.GetEnvironmentByName(bitMartEnvName)! : BitMartEnvironment.Live);
                bitMEXOptions = SetGlobalOptions<BitMEXOptions, BitMEXRestOptions, BitMEXSocketOptions, ApiCredentials, BitMEXEnvironment>(global, bitMEXOptions, credentials?.BitMEX, environments?.TryGetValue(Exchange.BitMEX, out var bitMEXEnvName) == true ? BitMEXEnvironment.GetEnvironmentByName(bitMEXEnvName)! : BitMEXEnvironment.Live);
                bybitOptions = SetGlobalOptions<BybitOptions, BybitRestOptions, BybitSocketOptions, ApiCredentials, BybitEnvironment>(global, bybitOptions, credentials?.Bybit, environments?.TryGetValue(Exchange.Bybit, out var bybitEnvName) == true ? BybitEnvironment.GetEnvironmentByName(bybitEnvName)! : BybitEnvironment.Live);
                coinbaseOptions = SetGlobalOptions<CoinbaseOptions, CoinbaseRestOptions, CoinbaseSocketOptions, ApiCredentials, CoinbaseEnvironment>(global, coinbaseOptions, credentials?.Coinbase, environments?.TryGetValue(Exchange.Coinbase, out var coinbaseEnvName) == true ? CoinbaseEnvironment.GetEnvironmentByName(coinbaseEnvName)! : CoinbaseEnvironment.Live);
                coinExOptions = SetGlobalOptions<CoinExOptions, CoinExRestOptions, CoinExSocketOptions, ApiCredentials, CoinExEnvironment>(global, coinExOptions, credentials?.CoinEx, environments?.TryGetValue(Exchange.CoinEx, out var coinExEnvName) == true ? CoinExEnvironment.GetEnvironmentByName(coinExEnvName)! : CoinExEnvironment.Live);
                coinWOptions = SetGlobalOptions<CoinWOptions, CoinWRestOptions, CoinWSocketOptions, ApiCredentials, CoinWEnvironment>(global, coinWOptions, credentials?.CoinW, environments?.TryGetValue(Exchange.CoinW, out var coinWEnvName) == true ? CoinWEnvironment.GetEnvironmentByName(coinWEnvName)! : CoinWEnvironment.Live);
                cryptoComOptions = SetGlobalOptions<CryptoComOptions, CryptoComRestOptions, CryptoComSocketOptions, ApiCredentials, CryptoComEnvironment>(global, cryptoComOptions, credentials?.CryptoCom, environments?.TryGetValue(Exchange.CryptoCom, out var cryptoComEnvName) == true ? CryptoComEnvironment.GetEnvironmentByName(cryptoComEnvName)! : CryptoComEnvironment.Live);
                deepCoinOptions = SetGlobalOptions<DeepCoinOptions, DeepCoinRestOptions, DeepCoinSocketOptions, ApiCredentials, DeepCoinEnvironment>(global, deepCoinOptions, credentials?.DeepCoin, environments?.TryGetValue(Exchange.DeepCoin, out var deepCoinEnvName) == true ? DeepCoinEnvironment.GetEnvironmentByName(deepCoinEnvName)! : DeepCoinEnvironment.Live);
                gateIoOptions = SetGlobalOptions<GateIoOptions, GateIoRestOptions, GateIoSocketOptions, ApiCredentials, GateIoEnvironment>(global, gateIoOptions, credentials?.GateIo, environments?.TryGetValue(Exchange.GateIo, out var gateIoEnvName) == true ? GateIoEnvironment.GetEnvironmentByName(gateIoEnvName)! : GateIoEnvironment.Live);
                htxOptions = SetGlobalOptions<HTXOptions, HTXRestOptions, HTXSocketOptions, ApiCredentials, HTXEnvironment>(global, htxOptions, credentials?.HTX, environments?.TryGetValue(Exchange.HTX, out var htxEnvName) == true ? HTXEnvironment.GetEnvironmentByName(htxEnvName)! : HTXEnvironment.Live);
                hyperLiquidOptions = SetGlobalOptions<HyperLiquidOptions, HyperLiquidRestOptions, HyperLiquidSocketOptions, ApiCredentials, HyperLiquidEnvironment>(global, hyperLiquidOptions, credentials?.HyperLiquid, environments?.TryGetValue(Exchange.HyperLiquid, out var hyperLiquidEnvName) == true ? HyperLiquidEnvironment.GetEnvironmentByName(hyperLiquidEnvName)! : HyperLiquidEnvironment.Live);
                krakenOptions = SetGlobalOptions<KrakenOptions, KrakenRestOptions, KrakenSocketOptions, ApiCredentials, KrakenEnvironment>(global, krakenOptions, credentials?.Kraken, environments?.TryGetValue(Exchange.Kraken, out var krakenEnvName) == true ? KrakenEnvironment.GetEnvironmentByName(krakenEnvName)! : KrakenEnvironment.Live);
                kucoinOptions = SetGlobalOptions<KucoinOptions, KucoinRestOptions, KucoinSocketOptions, ApiCredentials, KucoinEnvironment>(global, kucoinOptions, credentials?.Kucoin, environments?.TryGetValue(Exchange.Kucoin, out var kucoinEnvName) == true ? KucoinEnvironment.GetEnvironmentByName(kucoinEnvName)! : KucoinEnvironment.Live);
                mexcOptions = SetGlobalOptions<MexcOptions, MexcRestOptions, MexcSocketOptions, ApiCredentials, MexcEnvironment>(global, mexcOptions, credentials?.Mexc, environments?.TryGetValue(Exchange.Mexc, out var mexcEnvName) == true ? MexcEnvironment.GetEnvironmentByName(mexcEnvName)! : MexcEnvironment.Live);
                okxOptions = SetGlobalOptions<OKXOptions, OKXRestOptions, OKXSocketOptions, ApiCredentials, OKXEnvironment>(global, okxOptions, credentials?.OKX, environments?.TryGetValue(Exchange.OKX, out var okxEnvName) == true ? OKXEnvironment.GetEnvironmentByName(okxEnvName)! : OKXEnvironment.Live);
                toobitOptions = SetGlobalOptions<ToobitOptions, ToobitRestOptions, ToobitSocketOptions, ApiCredentials, ToobitEnvironment>(global, toobitOptions, credentials?.Toobit, environments?.TryGetValue(Exchange.Toobit, out var toobitEnvName) == true ? ToobitEnvironment.GetEnvironmentByName(toobitEnvName)! : ToobitEnvironment.Live);
                whiteBitOptions = SetGlobalOptions<WhiteBitOptions, WhiteBitRestOptions, WhiteBitSocketOptions, ApiCredentials, WhiteBitEnvironment>(global, whiteBitOptions, credentials?.WhiteBit, environments?.TryGetValue(Exchange.WhiteBit, out var whiteBitEnvName) == true ? WhiteBitEnvironment.GetEnvironmentByName(whiteBitEnvName)! : WhiteBitEnvironment.Live);
                xtOptions = SetGlobalOptions<XTOptions, XTRestOptions, XTSocketOptions, ApiCredentials, XTEnvironment>(global, xtOptions, credentials?.XT, environments?.TryGetValue(Exchange.XT, out var xtEnvName) == true ? XTEnvironment.GetEnvironmentByName(xtEnvName)! : XTEnvironment.Live);
            }

            _binanceProvider = new BinanceUserClientProvider(binanceOptions);
            _bingXProvider = new BingXUserClientProvider(bingxOptions);
            _bitfinexProvider = new BitfinexUserClientProvider(bitfinexOptions);
            _bitgetProvider = new BitgetUserClientProvider(bitgetOptions);
            _bitMartProvider = new BitMartUserClientProvider(bitMartOptions);
            _bitMEXProvider = new BitMEXUserClientProvider(bitMEXOptions);
            _bybitProvider = new BybitUserClientProvider(bybitOptions);
            _coinbaseProvider = new CoinbaseUserClientProvider(coinbaseOptions);
            _coinExProvider = new CoinExUserClientProvider(coinExOptions);
            _coinWProvider = new CoinWUserClientProvider(coinWOptions);
            _cryptoComProvider = new CryptoComUserClientProvider(cryptoComOptions);
            _deepCoinProvider = new DeepCoinUserClientProvider(deepCoinOptions);
            _gateIoProvider = new GateIoUserClientProvider(gateIoOptions);
            _htxProvider = new HTXUserClientProvider(htxOptions);
            _hyperLiquidProvider = new HyperLiquidUserClientProvider(hyperLiquidOptions);
            _krakenProvider = new KrakenUserClientProvider(krakenOptions);
            _kucoinProvider = new KucoinUserClientProvider(kucoinOptions);
            _mexcProvider = new MexcUserClientProvider(mexcOptions);
            _okxProvider = new OKXUserClientProvider(okxOptions);
            _toobitProvider = new ToobitUserClientProvider(toobitOptions);
            _whiteBitProvider = new WhiteBitUserClientProvider(whiteBitOptions);
            _xtProvider = new XTUserClientProvider(xtOptions);
        }

        /// <summary>
        /// DI ctor
        /// </summary>
        public ExchangeUserClientProvider(
            IBinanceUserClientProvider binanceProvider,
            IBingXUserClientProvider bingXProvider,
            IBitfinexUserClientProvider bitfinexProvider,
            IBitgetUserClientProvider bitgetProvider,
            IBitMartUserClientProvider bitMartProvider,
            IBitMEXUserClientProvider bitMEXProvider,
            IBybitUserClientProvider bybitProvider,
            ICoinbaseUserClientProvider coinbaseProvider,
            ICoinExUserClientProvider coinExProvider,
            ICoinWUserClientProvider coinWProvider,
            ICryptoComUserClientProvider cryptoComProvider,
            IDeepCoinUserClientProvider deepCoinProvider,
            IGateIoUserClientProvider gateIoProvider,
            IHTXUserClientProvider htxProvider,
            IHyperLiquidUserClientProvider hyperLiquidProvider,
            IKrakenUserClientProvider krakenProvider,
            IKucoinUserClientProvider kucoinProvider,
            IMexcUserClientProvider mexcProvider,
            IOKXUserClientProvider okxProvider,
            IToobitUserClientProvider toobitProvider,
            IWhiteBitUserClientProvider whiteBitProvider,
            IXTUserClientProvider xtProvider
            )
        {
            _binanceProvider = binanceProvider;
            _bingXProvider = bingXProvider;
            _bitfinexProvider = bitfinexProvider;
            _bitgetProvider = bitgetProvider;
            _bitMartProvider = bitMartProvider;
            _bitMEXProvider = bitMEXProvider;
            _bybitProvider = bybitProvider;
            _coinbaseProvider = coinbaseProvider;
            _coinExProvider = coinExProvider;
            _coinWProvider = coinWProvider;
            _cryptoComProvider = cryptoComProvider;
            _deepCoinProvider = deepCoinProvider;
            _gateIoProvider = gateIoProvider;
            _htxProvider = htxProvider;
            _hyperLiquidProvider = hyperLiquidProvider;
            _krakenProvider = krakenProvider;
            _kucoinProvider = kucoinProvider;
            _mexcProvider = mexcProvider;
            _okxProvider = okxProvider;
            _toobitProvider = toobitProvider;
            _whiteBitProvider = whiteBitProvider;
            _xtProvider = xtProvider;
        }

        /// <inheritdoc />
        public void InitializeUserClient(string userIdentifier, ExchangeCredentials credentials, Dictionary<string, string?> environments)
        {
            GetRestClient(userIdentifier, credentials, environments);
            GetSocketClient(userIdentifier, credentials, environments);
        }

        /// <inheritdoc />
        public void ClearUserClients(string userIdentifier, string? exchange = null)
        {
            if (exchange == null || exchange == Exchange.Binance) _binanceProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.BingX) _bingXProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.Bitfinex) _bitfinexProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.Bitget) _bitgetProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.BitMart) _bitMartProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.BitMEX) _bitMEXProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.Bybit) _bybitProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.Coinbase) _coinbaseProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.CoinEx) _coinExProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.CoinW) _coinWProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.CryptoCom) _cryptoComProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.DeepCoin) _deepCoinProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.GateIo) _gateIoProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.HTX) _htxProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.HyperLiquid) _hyperLiquidProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.Kraken) _krakenProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.Kucoin) _kucoinProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.Mexc) _mexcProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.OKX) _okxProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.Toobit) _toobitProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.WhiteBit) _whiteBitProvider.ClearUserClients(userIdentifier);
            if (exchange == null || exchange == Exchange.XT) _xtProvider.ClearUserClients(userIdentifier);
        }

        /// <inheritdoc />
        public IExchangeRestClient GetRestClient(string userIdentifier, ExchangeCredentials? credentials = null, Dictionary<string, string?>? environments = null)
        {
            environments ??= new();
            credentials ??= new();

            var client = new ExchangeRestClient(
                _binanceProvider.GetRestClient(userIdentifier, credentials.Binance, environments.TryGetValue(Exchange.Binance, out var binanceEnv) ? BinanceEnvironment.GetEnvironmentByName(binanceEnv) : null),
                _bingXProvider.GetRestClient(userIdentifier, credentials.BingX, environments.TryGetValue(Exchange.BingX, out var bingxEnv) ? BingXEnvironment.GetEnvironmentByName(bingxEnv) : null),
                _bitfinexProvider.GetRestClient(userIdentifier, credentials.Bitfinex, environments.TryGetValue(Exchange.Bitfinex, out var bitfinexEnv) ? BitfinexEnvironment.GetEnvironmentByName(bitfinexEnv) : null),
                _bitgetProvider.GetRestClient(userIdentifier, credentials.Bitget, environments.TryGetValue(Exchange.Bitget, out var bitgetEnv) ? BitgetEnvironment.GetEnvironmentByName(bitgetEnv) : null),
                _bitMartProvider.GetRestClient(userIdentifier, credentials.BitMart, environments.TryGetValue(Exchange.BitMart, out var bitmartEnv) ? BitMartEnvironment.GetEnvironmentByName(bitmartEnv) : null),
                _bitMEXProvider.GetRestClient(userIdentifier, credentials.BitMEX, environments.TryGetValue(Exchange.BitMEX, out var bitMEXEnv) ? BitMEXEnvironment.GetEnvironmentByName(bitMEXEnv) : null),
                _bybitProvider.GetRestClient(userIdentifier, credentials.Bybit, environments.TryGetValue(Exchange.Bybit, out var bybitEnv) ? BybitEnvironment.GetEnvironmentByName(bybitEnv) : null),
                _coinbaseProvider.GetRestClient(userIdentifier, credentials.Coinbase, environments.TryGetValue(Exchange.Coinbase, out var coinbaseEnv) ? CoinbaseEnvironment.GetEnvironmentByName(coinbaseEnv) : null),
                _coinExProvider.GetRestClient(userIdentifier, credentials.CoinEx, environments.TryGetValue(Exchange.CoinEx, out var coinexEnv) ? CoinExEnvironment.GetEnvironmentByName(coinexEnv) : null),
                _coinWProvider.GetRestClient(userIdentifier, credentials.CoinW, environments.TryGetValue(Exchange.CoinW, out var coinWEnv) ? CoinWEnvironment.GetEnvironmentByName(coinWEnv) : null),
                _cryptoComProvider.GetRestClient(userIdentifier, credentials.CryptoCom, environments.TryGetValue(Exchange.CryptoCom, out var cryptoComEnv) ? CryptoComEnvironment.GetEnvironmentByName(cryptoComEnv) : null),
                _deepCoinProvider.GetRestClient(userIdentifier, credentials.DeepCoin, environments.TryGetValue(Exchange.DeepCoin, out var deepcoinEnv) ? DeepCoinEnvironment.GetEnvironmentByName(deepcoinEnv) : null),
                _gateIoProvider.GetRestClient(userIdentifier, credentials.GateIo, environments.TryGetValue(Exchange.GateIo, out var gateIoEnv) ? GateIoEnvironment.GetEnvironmentByName(gateIoEnv) : null),
                _htxProvider.GetRestClient(userIdentifier, credentials.HTX, environments.TryGetValue(Exchange.HTX, out var htxEnv) ? HTXEnvironment.GetEnvironmentByName(htxEnv) : null),
                _hyperLiquidProvider.GetRestClient(userIdentifier, credentials.HyperLiquid, environments.TryGetValue(Exchange.HyperLiquid, out var hyperliquidEnv) ? HyperLiquidEnvironment.GetEnvironmentByName(hyperliquidEnv) : null),
                _krakenProvider.GetRestClient(userIdentifier, credentials.Kraken, environments.TryGetValue(Exchange.Kraken, out var krakenEnv) ? KrakenEnvironment.GetEnvironmentByName(krakenEnv) : null),
                _kucoinProvider.GetRestClient(userIdentifier, credentials.Kucoin, environments.TryGetValue(Exchange.Kucoin, out var kucoinEnv) ? KucoinEnvironment.GetEnvironmentByName(kucoinEnv) : null),
                _mexcProvider.GetRestClient(userIdentifier, credentials.Mexc, environments.TryGetValue(Exchange.Mexc, out var mexcEnv) ? MexcEnvironment.GetEnvironmentByName(mexcEnv) : null),
                _okxProvider.GetRestClient(userIdentifier, credentials.OKX, environments.TryGetValue(Exchange.OKX, out var okxEnv) ? OKXEnvironment.GetEnvironmentByName(okxEnv) : null),
                _toobitProvider.GetRestClient(userIdentifier, credentials.Toobit, environments.TryGetValue(Exchange.Toobit, out var toobitEnv) ? ToobitEnvironment.GetEnvironmentByName(toobitEnv) : null),
                _whiteBitProvider.GetRestClient(userIdentifier, credentials.WhiteBit, environments.TryGetValue(Exchange.WhiteBit, out var whiteBitEnv) ? WhiteBitEnvironment.GetEnvironmentByName(whiteBitEnv) : null),
                _xtProvider.GetRestClient(userIdentifier, credentials.XT, environments.TryGetValue(Exchange.XT, out var xtEnv) ? XTEnvironment.GetEnvironmentByName(xtEnv) : null)
                );

            return client;
        }

        /// <inheritdoc />
        public IExchangeSocketClient GetSocketClient(string userIdentifier, ExchangeCredentials? credentials = null, Dictionary<string, string?>? environments = null)
        {
            environments ??= new();
            credentials ??= new();

            var client = new ExchangeSocketClient(
                _binanceProvider.GetSocketClient(userIdentifier, credentials.Binance, environments.TryGetValue(Exchange.Binance, out var binanceEnv) ? BinanceEnvironment.GetEnvironmentByName(binanceEnv) : null),
                _bingXProvider.GetSocketClient(userIdentifier, credentials.BingX, environments.TryGetValue(Exchange.BingX, out var bingxEnv) ? BingXEnvironment.GetEnvironmentByName(bingxEnv) : null),
                _bitfinexProvider.GetSocketClient(userIdentifier, credentials.Bitfinex, environments.TryGetValue(Exchange.Bitfinex, out var bitfinexEnv) ? BitfinexEnvironment.GetEnvironmentByName(bitfinexEnv) : null),
                _bitgetProvider.GetSocketClient(userIdentifier, credentials.Bitget, environments.TryGetValue(Exchange.Bitget, out var bitgetEnv) ? BitgetEnvironment.GetEnvironmentByName(bitgetEnv) : null),
                _bitMartProvider.GetSocketClient(userIdentifier, credentials.BitMart, environments.TryGetValue(Exchange.BitMart, out var bitmartEnv) ? BitMartEnvironment.GetEnvironmentByName(bitmartEnv) : null),
                _bitMEXProvider.GetSocketClient(userIdentifier, credentials.BitMEX, environments.TryGetValue(Exchange.BitMEX, out var bitMEXEnv) ? BitMEXEnvironment.GetEnvironmentByName(bitMEXEnv) : null),
                _bybitProvider.GetSocketClient(userIdentifier, credentials.Bybit, environments.TryGetValue(Exchange.Bybit, out var bybitEnv) ? BybitEnvironment.GetEnvironmentByName(bybitEnv) : null),
                _coinbaseProvider.GetSocketClient(userIdentifier, credentials.Coinbase, environments.TryGetValue(Exchange.Coinbase, out var coinbaseEnv) ? CoinbaseEnvironment.GetEnvironmentByName(coinbaseEnv) : null),
                _coinExProvider.GetSocketClient(userIdentifier, credentials.CoinEx, environments.TryGetValue(Exchange.CoinEx, out var coinexEnv) ? CoinExEnvironment.GetEnvironmentByName(coinexEnv) : null),
                _coinWProvider.GetSocketClient(userIdentifier, credentials.CoinW, environments.TryGetValue(Exchange.CoinW, out var coinWEnv) ? CoinWEnvironment.GetEnvironmentByName(coinWEnv) : null),
                _cryptoComProvider.GetSocketClient(userIdentifier, credentials.CryptoCom, environments.TryGetValue(Exchange.CryptoCom, out var cryptoComEnv) ? CryptoComEnvironment.GetEnvironmentByName(cryptoComEnv) : null),
                _deepCoinProvider.GetSocketClient(userIdentifier, credentials.DeepCoin, environments.TryGetValue(Exchange.DeepCoin, out var deepcoinEnv) ? DeepCoinEnvironment.GetEnvironmentByName(deepcoinEnv) : null),
                _gateIoProvider.GetSocketClient(userIdentifier, credentials.GateIo, environments.TryGetValue(Exchange.GateIo, out var gateIoEnv) ? GateIoEnvironment.GetEnvironmentByName(gateIoEnv) : null),
                _htxProvider.GetSocketClient(userIdentifier, credentials.HTX, environments.TryGetValue(Exchange.HTX, out var htxEnv) ? HTXEnvironment.GetEnvironmentByName(htxEnv) : null),
                _hyperLiquidProvider.GetSocketClient(userIdentifier, credentials.HyperLiquid, environments.TryGetValue(Exchange.HyperLiquid, out var hyperliquidEnv) ? HyperLiquidEnvironment.GetEnvironmentByName(hyperliquidEnv) : null),
                _krakenProvider.GetSocketClient(userIdentifier, credentials.Kraken, environments.TryGetValue(Exchange.Kraken, out var krakenEnv) ? KrakenEnvironment.GetEnvironmentByName(krakenEnv) : null),
                _kucoinProvider.GetSocketClient(userIdentifier, credentials.Kucoin, environments.TryGetValue(Exchange.Kucoin, out var kucoinEnv) ? KucoinEnvironment.GetEnvironmentByName(kucoinEnv) : null),
                _mexcProvider.GetSocketClient(userIdentifier, credentials.Mexc, environments.TryGetValue(Exchange.Mexc, out var mexcEnv) ? MexcEnvironment.GetEnvironmentByName(mexcEnv) : null),
                _okxProvider.GetSocketClient(userIdentifier, credentials.OKX, environments.TryGetValue(Exchange.OKX, out var okxEnv) ? OKXEnvironment.GetEnvironmentByName(okxEnv) : null),
                _toobitProvider.GetSocketClient(userIdentifier, credentials.Toobit, environments.TryGetValue(Exchange.Toobit, out var toobitEnv) ? ToobitEnvironment.GetEnvironmentByName(toobitEnv) : null),
                _whiteBitProvider.GetSocketClient(userIdentifier, credentials.WhiteBit, environments.TryGetValue(Exchange.WhiteBit, out var whiteBitEnv) ? WhiteBitEnvironment.GetEnvironmentByName(whiteBitEnv) : null),
                _xtProvider.GetSocketClient(userIdentifier, credentials.XT, environments.TryGetValue(Exchange.XT, out var xtEnv) ? XTEnvironment.GetEnvironmentByName(xtEnv) : null)
                );

            return client;
        }
    }
}
