using Aster.Net;
using Aster.Net.Interfaces.Clients;
using Aster.Net.Objects.Options;
using Binance.Net;
using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects.Options;
using BingX.Net;
using BingX.Net.Interfaces.Clients;
using BingX.Net.Objects.Options;
using Bitfinex.Net;
using Bitfinex.Net.Interfaces.Clients;
using Bitfinex.Net.Objects.Options;
using Bitget.Net;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using BitMart.Net;
using BitMart.Net.Interfaces.Clients;
using BitMart.Net.Objects.Options;
using BitMEX.Net;
using BitMEX.Net.Interfaces.Clients;
using BitMEX.Net.Objects.Options;
using BloFin.Net;
using BloFin.Net.Interfaces.Clients;
using BloFin.Net.Objects.Options;
using Bybit.Net;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using Coinbase.Net;
using Coinbase.Net.Interfaces.Clients;
using Coinbase.Net.Objects.Options;
using CoinEx.Net;
using CoinEx.Net.Interfaces.Clients;
using CoinEx.Net.Objects.Options;
using CoinW.Net;
using CoinW.Net.Interfaces.Clients;
using CoinW.Net.Objects.Options;
using CoinGecko.Net.Objects.Options;
using CryptoClients.Net;
using CryptoClients.Net.Clients;
using CryptoClients.Net.Interfaces;
using CryptoClients.Net.Models;
using CryptoCom.Net;
using CryptoCom.Net.Interfaces.Clients;
using CryptoCom.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using DeepCoin.Net;
using DeepCoin.Net.Interfaces.Clients;
using DeepCoin.Net.Objects.Options;
using GateIo.Net;
using GateIo.Net.Interfaces.Clients;
using GateIo.Net.Objects.Options;
using HTX.Net;
using HTX.Net.Interfaces.Clients;
using HTX.Net.Objects.Options;
using HyperLiquid.Net;
using HyperLiquid.Net.Interfaces.Clients;
using HyperLiquid.Net.Objects.Options;
using Kraken.Net;
using Kraken.Net.Interfaces.Clients;
using Kraken.Net.Objects.Options;
using Kucoin.Net;
using Kucoin.Net.Interfaces.Clients;
using Kucoin.Net.Objects.Options;
using Mexc.Net;
using Mexc.Net.Interfaces.Clients;
using Mexc.Net.Objects.Options;
using Microsoft.Extensions.Configuration;
using OKX.Net;
using OKX.Net.Interfaces.Clients;
using OKX.Net.Objects.Options;
using Toobit.Net;
using Toobit.Net.Interfaces.Clients;
using Toobit.Net.Objects.Options;
using Upbit.Net;
using Upbit.Net.Interfaces.Clients;
using Upbit.Net.Objects.Options;
using System;
using WhiteBit.Net;
using WhiteBit.Net.Interfaces.Clients;
using WhiteBit.Net.Objects.Options;
using XT.Net;
using XT.Net.Interfaces.Clients;
using XT.Net.Objects.Options;
using CryptoClients.Net.Enums;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions for DI
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add all the exchange clients to the service collection as well as the IExchangeRestClient, IExchangeSocketClient and IExchangeOrderBookFactory aggregation interfaces
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="globalOptions">The options to be applied for each exchange services. Can be overridden by providing exchange specific options.</param>
        /// <param name="asterOptions">The options options for the Aster services. Will override options provided in the global options</param>
        /// <param name="binanceOptions">The options options for the Binance services. Will override options provided in the global options</param>
        /// <param name="bingxOptions">The options options for the BingX services. Will override options provided in the global options</param>
        /// <param name="bitfinexOptions">The options options for the Bitfinex services. Will override options provided in the global options</param>
        /// <param name="bitgetOptions">The options options for the Bitget services. Will override options provided in the global options</param>
        /// <param name="bitMartOptions">The options options for the BitMart services. Will override options provided in the global options</param>
        /// <param name="bitMEXOptions">The options options for the BitMEX services. Will override options provided in the global options</param>
        /// <param name="bloFinOptions">The options options for the BloFin services. Will override options provided in the global options</param>
        /// <param name="bybitOptions">The options options for the Bybit services. Will override options provided in the global options</param>
        /// <param name="coinbaseOptions">The options options for the Coinbase services. Will override options provided in the global options</param>
        /// <param name="coinExOptions">The options options for the CoinEx services. Will override options provided in the global options</param>
        /// <param name="coinWOptions">The options options for the CoinW services. Will override options provided in the global options</param>
        /// <param name="coinGeckoOptions">The options options for the CoinGecko services. Will override options provided in the global options</param>
        /// <param name="cryptoComOptions">The options options for the Crypto.com services. Will override options provided in the global options</param>
        /// <param name="deepCoinOptions">The options options for the DeepCoin services. Will override options provided in the global options</param>
        /// <param name="gateIoOptions">The options options for the Gate.io services. Will override options provided in the global options</param>
        /// <param name="htxOptions">The options options for the HTX services. Will override options provided in the global options</param>
        /// <param name="hyperLiquidOptions">The options options for the HyperLiquid services. Will override options provided in the global options</param>
        /// <param name="krakenOptions">The options options for the Kraken services. Will override options provided in the global options</param>
        /// <param name="kucoinOptions">The options options for the Kucoin services. Will override options provided in the global options</param>
        /// <param name="mexcOptions">The options options for the Mexc services. Will override options provided in the global options</param>
        /// <param name="okxOptions">The options options for the OKX services. Will override options provided in the global options</param>
        /// <param name="toobitOptions">The options options for the Toobit services. Will override options provided in the global options</param>
        /// <param name="upbitOptions">The options options for the Upbit services. Will override options provided in the global options</param>
        /// <param name="whiteBitOptions">The options options for the WhiteBit services. Will override options provided in the global options</param>
        /// <param name="xtOptions">The options options for the XT services. Will override options provided in the global options</param>
        /// <param name="socketClientLifetime">The lifetime for the Socket clients. Defaults to Singleton</param>
        /// <returns></returns>
        public static IServiceCollection AddCryptoClients(
            this IServiceCollection services,
            Action<GlobalExchangeOptions>? globalOptions = null,
            Action<AsterOptions>? asterOptions = null,
            Action<BinanceOptions>? binanceOptions = null,
            Action<BingXOptions>? bingxOptions = null,
            Action<BitfinexOptions>? bitfinexOptions = null,
            Action<BitgetOptions>? bitgetOptions = null,
            Action<BitMartOptions>? bitMartOptions = null,
            Action<BitMEXOptions>? bitMEXOptions = null,
            Action<BloFinOptions>? bloFinOptions = null,
            Action<BybitOptions>? bybitOptions = null,
            Action<CoinbaseOptions>? coinbaseOptions = null,
            Action<CoinExOptions>? coinExOptions = null,
            Action<CoinWOptions>? coinWOptions = null,
            Action<CoinGeckoRestOptions>? coinGeckoOptions = null,
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
            Action<UpbitOptions>? upbitOptions = null,
            Action<WhiteBitOptions>? whiteBitOptions = null,
            Action<XTOptions>? xtOptions = null,
            ServiceLifetime? socketClientLifetime = null)
        {
            Action<TOptions> SetGlobalOptions<TOptions, TRestOptions, TSocketOptions, TCredentials, TEnvironment>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TCredentials? credentials, TEnvironment environment)
                where TOptions : LibraryOptions<TRestOptions, TSocketOptions, TCredentials, TEnvironment> 
                where TCredentials : ApiCredentials
                where TEnvironment : TradeEnvironment
                where TRestOptions : RestExchangeOptions, new()
                where TSocketOptions : SocketExchangeOptions, new()
            {
                var optsDelegate = (TOptions options) =>
                {
                    options.Environment = environment;
                    options.ApiCredentials = credentials;
                    options.SocketClientLifeTime = socketClientLifetime;
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
                    options.Socket.ReconnectPolicy = globalOptions.ReconnectPolicy ?? options.Socket.ReconnectPolicy;
                    options.Socket.ReconnectInterval = globalOptions.ReconnectInterval ?? options.Socket.ReconnectInterval;
                    options.Socket.UseUpdatedDeserialization = globalOptions.UseUpdatedDeserialization ?? options.Socket.UseUpdatedDeserialization;

                    exchangeDelegate?.Invoke(options);
                };

                return optsDelegate;
            }

            if (globalOptions != null)
            {
                var global = new GlobalExchangeOptions();
                globalOptions.Invoke(global);

                ExchangeCredentials? credentials = global.ApiCredentials;
                var environments = global.ApiEnvironments;
                asterOptions = SetGlobalOptions<AsterOptions, AsterRestOptions, AsterSocketOptions, ApiCredentials, AsterEnvironment>(global, asterOptions, credentials?.Aster, environments?.TryGetValue(Exchange.Aster, out var asterEnvName) == true ? AsterEnvironment.GetEnvironmentByName(asterEnvName)! : AsterEnvironment.Live);
                binanceOptions = SetGlobalOptions<BinanceOptions, BinanceRestOptions, BinanceSocketOptions, ApiCredentials, BinanceEnvironment>(global, binanceOptions, credentials?.Binance, environments?.TryGetValue(Exchange.Binance, out var binanceEnvName) == true ? BinanceEnvironment.GetEnvironmentByName(binanceEnvName)! : BinanceEnvironment.Live);
                bingxOptions = SetGlobalOptions<BingXOptions, BingXRestOptions, BingXSocketOptions, ApiCredentials, BingXEnvironment>(global, bingxOptions, credentials?.BingX, environments?.TryGetValue(Exchange.BingX, out var bingxEnvName) == true ? BingXEnvironment.GetEnvironmentByName(bingxEnvName)! : BingXEnvironment.Live);
                bitfinexOptions = SetGlobalOptions<BitfinexOptions, BitfinexRestOptions, BitfinexSocketOptions, ApiCredentials, BitfinexEnvironment>(global, bitfinexOptions, credentials?.Bitfinex, environments?.TryGetValue(Exchange.Bitfinex, out var bitfinexEnvName) == true ? BitfinexEnvironment.GetEnvironmentByName(bitfinexEnvName)! : BitfinexEnvironment.Live);
                bitgetOptions = SetGlobalOptions<BitgetOptions, BitgetRestOptions, BitgetSocketOptions, ApiCredentials, BitgetEnvironment>(global, bitgetOptions, credentials?.Bitget, environments?.TryGetValue(Exchange.Bitget, out var bitgetEnvName) == true ? BitgetEnvironment.GetEnvironmentByName(bitgetEnvName)! : BitgetEnvironment.Live);
                bitMartOptions = SetGlobalOptions<BitMartOptions, BitMartRestOptions, BitMartSocketOptions, ApiCredentials, BitMartEnvironment>(global, bitMartOptions, credentials?.BitMart, environments?.TryGetValue(Exchange.BitMart, out var bitMartEnvName) == true ? BitMartEnvironment.GetEnvironmentByName(bitMartEnvName)! : BitMartEnvironment.Live);
                bitMEXOptions = SetGlobalOptions<BitMEXOptions, BitMEXRestOptions, BitMEXSocketOptions, ApiCredentials, BitMEXEnvironment>(global, bitMEXOptions, credentials?.BitMEX, environments?.TryGetValue(Exchange.BitMEX, out var bitMEXEnvName) == true ? BitMEXEnvironment.GetEnvironmentByName(bitMEXEnvName)! : BitMEXEnvironment.Live);
                bloFinOptions = SetGlobalOptions<BloFinOptions, BloFinRestOptions, BloFinSocketOptions, ApiCredentials, BloFinEnvironment>(global, bloFinOptions, credentials?.BloFin, environments?.TryGetValue(Exchange.BloFin, out var bloFinEnvName) == true ? BloFinEnvironment.GetEnvironmentByName(bloFinEnvName)! : BloFinEnvironment.Live);
                bybitOptions = SetGlobalOptions<BybitOptions, BybitRestOptions, BybitSocketOptions, ApiCredentials, BybitEnvironment>(global, bybitOptions, credentials?.Bybit, environments?.TryGetValue(Exchange.Bybit, out var bybitEnvName) == true ? BybitEnvironment.GetEnvironmentByName(bybitEnvName)! : BybitEnvironment.Live);
                coinbaseOptions = SetGlobalOptions<CoinbaseOptions, CoinbaseRestOptions, CoinbaseSocketOptions, ApiCredentials, CoinbaseEnvironment>(global, coinbaseOptions, credentials?.Coinbase, environments?.TryGetValue(Exchange.Coinbase, out var coinbaseEnvName) == true ? CoinbaseEnvironment.GetEnvironmentByName(coinbaseEnvName)! : CoinbaseEnvironment.Live);
                coinExOptions = SetGlobalOptions<CoinExOptions, CoinExRestOptions, CoinExSocketOptions, ApiCredentials, CoinExEnvironment>(global, coinExOptions, credentials?.CoinEx, environments?.TryGetValue(Exchange.CoinEx, out var coinExEnvName) == true ? CoinExEnvironment.GetEnvironmentByName(coinExEnvName)! : CoinExEnvironment.Live);
                coinWOptions = SetGlobalOptions<CoinWOptions, CoinWRestOptions, CoinWSocketOptions, ApiCredentials, CoinWEnvironment>(global, coinWOptions, credentials?.CoinW, environments?.TryGetValue(Exchange.CoinW, out var coinWEnvName) == true ? CoinWEnvironment.GetEnvironmentByName(coinWEnvName)! : CoinWEnvironment.Live);
                cryptoComOptions = SetGlobalOptions<CryptoComOptions, CryptoComRestOptions, CryptoComSocketOptions, ApiCredentials, CryptoComEnvironment>(global, cryptoComOptions, credentials?.CryptoCom, environments?.TryGetValue(Exchange.CryptoCom, out var cryptoComEnvName) == true ? CryptoComEnvironment.GetEnvironmentByName(cryptoComEnvName)! : CryptoComEnvironment.Live);
                deepCoinOptions = SetGlobalOptions<DeepCoinOptions, DeepCoinRestOptions, DeepCoinSocketOptions, ApiCredentials, DeepCoinEnvironment>(global, deepCoinOptions, credentials?.DeepCoin, environments?.TryGetValue(Exchange.DeepCoin, out var deepCoinEnvName) == true ? DeepCoinEnvironment.GetEnvironmentByName(deepCoinEnvName)! : DeepCoinEnvironment.Live);
                gateIoOptions = SetGlobalOptions<GateIoOptions, GateIoRestOptions, GateIoSocketOptions, ApiCredentials, GateIoEnvironment>(global, gateIoOptions, credentials?.GateIo, environments?.TryGetValue(Exchange.GateIo, out var gateEnvName) == true ? GateIoEnvironment.GetEnvironmentByName(gateEnvName)! : GateIoEnvironment.Live);
                htxOptions = SetGlobalOptions<HTXOptions, HTXRestOptions, HTXSocketOptions, ApiCredentials, HTXEnvironment>(global, htxOptions, credentials?.HTX, environments?.TryGetValue(Exchange.HTX, out var htxEnvName) == true ? HTXEnvironment.GetEnvironmentByName(htxEnvName)! : HTXEnvironment.Live);
                hyperLiquidOptions = SetGlobalOptions<HyperLiquidOptions, HyperLiquidRestOptions, HyperLiquidSocketOptions, ApiCredentials, HyperLiquidEnvironment>(global, hyperLiquidOptions, credentials?.HyperLiquid, environments?.TryGetValue(Exchange.HyperLiquid, out var hyperLiquidEnvName) == true ? HyperLiquidEnvironment.GetEnvironmentByName(hyperLiquidEnvName)! : HyperLiquidEnvironment.Live);
                krakenOptions = SetGlobalOptions<KrakenOptions, KrakenRestOptions, KrakenSocketOptions, ApiCredentials, KrakenEnvironment>(global, krakenOptions, credentials?.Kraken, environments?.TryGetValue(Exchange.Kraken, out var krakenEnvName) == true ? KrakenEnvironment.GetEnvironmentByName(krakenEnvName)! : KrakenEnvironment.Live);
                kucoinOptions = SetGlobalOptions<KucoinOptions, KucoinRestOptions, KucoinSocketOptions, ApiCredentials, KucoinEnvironment>(global, kucoinOptions, credentials?.Kucoin, environments?.TryGetValue(Exchange.Kucoin, out var kucoinEnvName) == true ? KucoinEnvironment.GetEnvironmentByName(kucoinEnvName)! : KucoinEnvironment.Live);
                mexcOptions = SetGlobalOptions<MexcOptions, MexcRestOptions, MexcSocketOptions, ApiCredentials, MexcEnvironment>(global, mexcOptions, credentials?.Mexc, environments?.TryGetValue(Exchange.Mexc, out var mexcEnvName) == true ? MexcEnvironment.GetEnvironmentByName(mexcEnvName)! : MexcEnvironment.Live);
                okxOptions = SetGlobalOptions<OKXOptions, OKXRestOptions, OKXSocketOptions, ApiCredentials, OKXEnvironment>(global, okxOptions, credentials?.OKX, environments?.TryGetValue(Exchange.OKX, out var okxEnvName) == true ? OKXEnvironment.GetEnvironmentByName(okxEnvName)! : OKXEnvironment.Live);
                toobitOptions = SetGlobalOptions<ToobitOptions, ToobitRestOptions, ToobitSocketOptions, ApiCredentials, ToobitEnvironment>(global, toobitOptions, credentials?.Toobit, environments?.TryGetValue(Exchange.Toobit, out var tooBitEnvName) == true ? ToobitEnvironment.GetEnvironmentByName(tooBitEnvName)! : ToobitEnvironment.Live);
                upbitOptions = SetGlobalOptions<UpbitOptions, UpbitRestOptions, UpbitSocketOptions, ApiCredentials, UpbitEnvironment>(global, upbitOptions, credentials?.Upbit, environments?.TryGetValue(Exchange.Upbit, out var upbitEnvName) == true ? UpbitEnvironment.GetEnvironmentByName(upbitEnvName)! : UpbitEnvironment.Live);
                whiteBitOptions = SetGlobalOptions<WhiteBitOptions, WhiteBitRestOptions, WhiteBitSocketOptions, ApiCredentials, WhiteBitEnvironment>(global, whiteBitOptions, credentials?.WhiteBit, environments?.TryGetValue(Exchange.WhiteBit, out var whiteBitEnvName) == true ? WhiteBitEnvironment.GetEnvironmentByName(whiteBitEnvName)! : WhiteBitEnvironment.Live);
                xtOptions = SetGlobalOptions<XTOptions, XTRestOptions, XTSocketOptions, ApiCredentials, XTEnvironment>(global, xtOptions, credentials?.XT, environments?.TryGetValue(Exchange.XT, out var xtEnvName) == true ? XTEnvironment.GetEnvironmentByName(xtEnvName)! : XTEnvironment.Live);
            }

            services.AddAster(asterOptions);
            services.AddBinance(binanceOptions);
            services.AddBingX(bingxOptions);
            services.AddBitfinex(bitfinexOptions);
            services.AddBitget(bitgetOptions);
            services.AddBitMart(bitMartOptions);
            services.AddBitMEX(bitMEXOptions);
            services.AddBloFin(bloFinOptions);
            services.AddBybit(bybitOptions);
            services.AddCoinbase(coinbaseOptions);
            services.AddCoinEx(coinExOptions);
            services.AddCoinW(coinWOptions);
            services.AddCoinGecko(coinGeckoOptions);
            services.AddCryptoCom(cryptoComOptions);
            services.AddDeepCoin(deepCoinOptions);
            services.AddGateIo(gateIoOptions);
            services.AddHTX(htxOptions);
            services.AddHyperLiquid(hyperLiquidOptions);
            services.AddKraken(krakenOptions);
            services.AddKucoin(kucoinOptions);
            services.AddMexc(mexcOptions);
            services.AddOKX(okxOptions);
            services.AddToobit(toobitOptions);
            services.AddUpbit(upbitOptions);
            services.AddWhiteBit(whiteBitOptions);
            services.AddXT(xtOptions);

            services.AddTransient<IExchangeRestClient, ExchangeRestClient>(x =>
            {
                return new ExchangeRestClient(
                    x.GetRequiredService<IAsterRestClient>(),
                    x.GetRequiredService<IBinanceRestClient>(),
                    x.GetRequiredService<IBingXRestClient>(),
                    x.GetRequiredService<IBitfinexRestClient>(),
                    x.GetRequiredService<IBitgetRestClient>(),
                    x.GetRequiredService<IBitMartRestClient>(),
                    x.GetRequiredService<IBitMEXRestClient>(),
                    x.GetRequiredService<IBloFinRestClient>(),
                    x.GetRequiredService<IBybitRestClient>(),
                    x.GetRequiredService<ICoinbaseRestClient>(),
                    x.GetRequiredService<ICoinExRestClient>(),
                    x.GetRequiredService<ICoinWRestClient>(),
                    x.GetRequiredService<ICryptoComRestClient>(),
                    x.GetRequiredService<IDeepCoinRestClient>(),
                    x.GetRequiredService<IGateIoRestClient>(),
                    x.GetRequiredService<IHTXRestClient>(),
                    x.GetRequiredService<IHyperLiquidRestClient>(),
                    x.GetRequiredService<IKrakenRestClient>(),
                    x.GetRequiredService<IKucoinRestClient>(),
                    x.GetRequiredService<IMexcRestClient>(),
                    x.GetRequiredService<IOKXRestClient>(),
                    x.GetRequiredService<IToobitRestClient>(),
                    x.GetRequiredService<IUpbitRestClient>(),
                    x.GetRequiredService<IWhiteBitRestClient>(),
                    x.GetRequiredService<IXTRestClient>()
                    );
            });

            services.Add(new ServiceDescriptor(typeof(IExchangeSocketClient), x =>
            {
                return new ExchangeSocketClient(
                    x.GetRequiredService<IAsterSocketClient>(),
                    x.GetRequiredService<IBinanceSocketClient>(),
                    x.GetRequiredService<IBingXSocketClient>(),
                    x.GetRequiredService<IBitfinexSocketClient>(),
                    x.GetRequiredService<IBitgetSocketClient>(),
                    x.GetRequiredService<IBitMartSocketClient>(),
                    x.GetRequiredService<IBitMEXSocketClient>(),
                    x.GetRequiredService<IBloFinSocketClient>(),
                    x.GetRequiredService<IBybitSocketClient>(),
                    x.GetRequiredService<ICoinbaseSocketClient>(),
                    x.GetRequiredService<ICoinExSocketClient>(),
                    x.GetRequiredService<ICoinWSocketClient>(),
                    x.GetRequiredService<ICryptoComSocketClient>(),
                    x.GetRequiredService<IDeepCoinSocketClient>(),
                    x.GetRequiredService<IGateIoSocketClient>(),
                    x.GetRequiredService<IHTXSocketClient>(),
                    x.GetRequiredService<IHyperLiquidSocketClient>(),
                    x.GetRequiredService<IKrakenSocketClient>(),
                    x.GetRequiredService<IKucoinSocketClient>(),
                    x.GetRequiredService<IMexcSocketClient>(),
                    x.GetRequiredService<IOKXSocketClient>(),
                    x.GetRequiredService<IToobitSocketClient>(),
                    x.GetRequiredService<IUpbitSocketClient>(),
                    x.GetRequiredService<IWhiteBitSocketClient>(),
                    x.GetRequiredService<IXTSocketClient>()
                    );
            }, socketClientLifetime ?? ServiceLifetime.Singleton));

            services.AddTransient<IExchangeOrderBookFactory, ExchangeOrderBookFactory>();
            services.AddTransient<IExchangeTrackerFactory, ExchangeTrackerFactory>();
            services.AddTransient<IExchangeUserClientProvider, ExchangeUserClientProvider>(x => new ExchangeUserClientProvider(
                x.GetRequiredService<IAsterUserClientProvider>(),
                x.GetRequiredService<IBinanceUserClientProvider>(),
                x.GetRequiredService<IBingXUserClientProvider>(),
                x.GetRequiredService<IBitfinexUserClientProvider>(),
                x.GetRequiredService<IBitgetUserClientProvider>(),
                x.GetRequiredService<IBitMartUserClientProvider>(),
                x.GetRequiredService<IBitMEXUserClientProvider>(),
                x.GetRequiredService<IBloFinUserClientProvider>(),
                x.GetRequiredService<IBybitUserClientProvider>(),
                x.GetRequiredService<ICoinbaseUserClientProvider>(),
                x.GetRequiredService<ICoinExUserClientProvider>(),
                x.GetRequiredService<ICoinWUserClientProvider>(),
                x.GetRequiredService<ICryptoComUserClientProvider>(),
                x.GetRequiredService<IDeepCoinUserClientProvider>(),
                x.GetRequiredService<IGateIoUserClientProvider>(),
                x.GetRequiredService<IHTXUserClientProvider>(),
                x.GetRequiredService<IHyperLiquidUserClientProvider>(),
                x.GetRequiredService<IKrakenUserClientProvider>(),
                x.GetRequiredService<IKucoinUserClientProvider>(),
                x.GetRequiredService<IMexcUserClientProvider>(),
                x.GetRequiredService<IOKXUserClientProvider>(),
                x.GetRequiredService<IToobitUserClientProvider>(),
                x.GetRequiredService<IUpbitUserClientProvider>(),
                x.GetRequiredService<IWhiteBitUserClientProvider>(),
                x.GetRequiredService<IXTUserClientProvider>()
                ));
            return services;
        }

        /// <summary>
        /// Add all the exchange clients to the service collection as well as the IExchangeRestClient, IExchangeSocketClient and IExchangeOrderBookFactory aggregation interfaces
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="configuration">The configuration (section) to load configuration from</param>
        /// <param name="socketClientLifetime">The lifetime for the Socket clients. Defaults to Singleton</param>
        /// <returns></returns>
        public static IServiceCollection AddCryptoClients(
            this IServiceCollection services,
            IConfiguration configuration,
            ServiceLifetime? socketClientLifetime = null)
        {
            var globalOptions = new GlobalExchangeOptions();
            configuration.Bind(globalOptions);

            void UpdateIfNotSpecified(string key, string? value)
            {
                if (value == null || !string.IsNullOrEmpty(configuration[key]))
                    return;

                configuration[key] = value;
            }

            void UpdateExchangeOptions(string exchange, GlobalExchangeOptions globalOptions)
            {
                UpdateIfNotSpecified($"{exchange}:Rest:Proxy:Host", globalOptions.Proxy?.Host);
                UpdateIfNotSpecified($"{exchange}:Rest:Proxy:Port", globalOptions.Proxy?.Port.ToString());
                UpdateIfNotSpecified($"{exchange}:Rest:Proxy:Login", globalOptions.Proxy?.Login);
                UpdateIfNotSpecified($"{exchange}:Rest:Proxy:Password", globalOptions.Proxy?.Password);
                UpdateIfNotSpecified($"{exchange}:Socket:Proxy:Host", globalOptions.Proxy?.Host);
                UpdateIfNotSpecified($"{exchange}:Socket:Proxy:Port", globalOptions.Proxy?.Port.ToString());
                UpdateIfNotSpecified($"{exchange}:Socket:Proxy:Login", globalOptions.Proxy?.Login);
                UpdateIfNotSpecified($"{exchange}:Socket:Proxy:Password", globalOptions.Proxy?.Password);
                UpdateIfNotSpecified($"{exchange}:Rest:OutputOriginalData", globalOptions.OutputOriginalData?.ToString().ToLower());
                UpdateIfNotSpecified($"{exchange}:Socket:OutputOriginalData", globalOptions.OutputOriginalData?.ToString().ToLower());
                UpdateIfNotSpecified($"{exchange}:Rest:RequestTimeout", globalOptions.RequestTimeout?.ToString());
                UpdateIfNotSpecified($"{exchange}:Socket:RequestTimeout", globalOptions.RequestTimeout?.ToString());
                UpdateIfNotSpecified($"{exchange}:Rest:RateLimiterEnabled", globalOptions.RateLimiterEnabled?.ToString().ToLower());
                UpdateIfNotSpecified($"{exchange}:Socket:RateLimiterEnabled", globalOptions.RateLimiterEnabled?.ToString().ToLower());
                UpdateIfNotSpecified($"{exchange}:Rest:RateLimitingBehaviour", globalOptions.RateLimitingBehaviour?.ToString());
                UpdateIfNotSpecified($"{exchange}:Socket:RateLimitingBehaviour", globalOptions.RateLimitingBehaviour?.ToString());
                UpdateIfNotSpecified($"{exchange}:Rest:CachingEnabled", globalOptions.CachingEnabled?.ToString().ToLower());
                UpdateIfNotSpecified($"{exchange}:Socket:ReconnectPolicy", globalOptions.ReconnectPolicy?.ToString());
                UpdateIfNotSpecified($"{exchange}:Socket:ReconnectInterval", globalOptions.ReconnectInterval?.ToString());
                UpdateIfNotSpecified($"{exchange}:SocketClientLifeTime", socketClientLifetime?.ToString());
                UpdateIfNotSpecified($"{exchange}:UseUpdatedDeserialization", globalOptions.UseUpdatedDeserialization?.ToString());
            }

            UpdateExchangeOptions("Aster", globalOptions);
            UpdateExchangeOptions("Binance", globalOptions);
            UpdateExchangeOptions("BingX", globalOptions);
            UpdateExchangeOptions("Bitfinex", globalOptions);
            UpdateExchangeOptions("Bitget", globalOptions);
            UpdateExchangeOptions("BitMart", globalOptions);
            UpdateExchangeOptions("BitMEX", globalOptions);
            UpdateExchangeOptions("BloFin", globalOptions);
            UpdateExchangeOptions("Bybit", globalOptions);
            UpdateExchangeOptions("Coinbase", globalOptions);
            UpdateExchangeOptions("CoinEx", globalOptions);
            UpdateExchangeOptions("CoinW", globalOptions);
            UpdateExchangeOptions("CoinGecko", globalOptions);
            UpdateExchangeOptions("CryptoCom", globalOptions);
            UpdateExchangeOptions("DeepCoin", globalOptions);
            UpdateExchangeOptions("GateIo", globalOptions);
            UpdateExchangeOptions("HTX", globalOptions);
            UpdateExchangeOptions("HyperLiquid", globalOptions);
            UpdateExchangeOptions("Kraken", globalOptions);
            UpdateExchangeOptions("Kucoin", globalOptions);
            UpdateExchangeOptions("Mexc", globalOptions);
            UpdateExchangeOptions("OKX", globalOptions);
            UpdateExchangeOptions("Toobit", globalOptions);
            UpdateExchangeOptions("Upbit", globalOptions);
            UpdateExchangeOptions("WhiteBit", globalOptions);
            UpdateExchangeOptions("XT", globalOptions);

            services.AddAster(configuration.GetSection("Aster"));
            services.AddBinance(configuration.GetSection("Binance"));
            services.AddBingX(configuration.GetSection("BingX"));
            services.AddBitfinex(configuration.GetSection("Bitfinex"));
            services.AddBitget(configuration.GetSection("Bitget"));
            services.AddBitMart(configuration.GetSection("BitMart"));
            services.AddBitMEX(configuration.GetSection("BitMEX"));
            services.AddBloFin(configuration.GetSection("BloFin"));
            services.AddBybit(configuration.GetSection("Bybit"));
            services.AddCoinbase(configuration.GetSection("Coinbase"));
            services.AddCoinEx(configuration.GetSection("CoinEx"));
            services.AddCoinW(configuration.GetSection("CoinW"));
            services.AddCoinGecko(configuration.GetSection("CoinGecko"));
            services.AddCryptoCom(configuration.GetSection("CryptoCom"));
            services.AddDeepCoin(configuration.GetSection("DeepCoin"));
            services.AddGateIo(configuration.GetSection("GateIo"));
            services.AddHTX(configuration.GetSection("HTX"));
            services.AddHyperLiquid(configuration.GetSection("HyperLiquid"));
            services.AddKraken(configuration.GetSection("Kraken"));
            services.AddKucoin(configuration.GetSection("Kucoin"));
            services.AddMexc(configuration.GetSection("Mexc"));
            services.AddOKX(configuration.GetSection("OKX"));
            services.AddToobit(configuration.GetSection("Toobit"));
            services.AddUpbit(configuration.GetSection("Upbit"));
            services.AddWhiteBit(configuration.GetSection("WhiteBit"));
            services.AddXT(configuration.GetSection("XT"));

            services.AddTransient<IExchangeRestClient, ExchangeRestClient>(x =>
            {
                return new ExchangeRestClient(
                    x.GetRequiredService<IAsterRestClient>(),
                    x.GetRequiredService<IBinanceRestClient>(),
                    x.GetRequiredService<IBingXRestClient>(),
                    x.GetRequiredService<IBitfinexRestClient>(),
                    x.GetRequiredService<IBitgetRestClient>(),
                    x.GetRequiredService<IBitMartRestClient>(),
                    x.GetRequiredService<IBitMEXRestClient>(),
                    x.GetRequiredService<IBloFinRestClient>(),
                    x.GetRequiredService<IBybitRestClient>(),
                    x.GetRequiredService<ICoinbaseRestClient>(),
                    x.GetRequiredService<ICoinExRestClient>(),
                    x.GetRequiredService<ICoinWRestClient>(),
                    x.GetRequiredService<ICryptoComRestClient>(),
                    x.GetRequiredService<IDeepCoinRestClient>(),
                    x.GetRequiredService<IGateIoRestClient>(),
                    x.GetRequiredService<IHTXRestClient>(),
                    x.GetRequiredService<IHyperLiquidRestClient>(),
                    x.GetRequiredService<IKrakenRestClient>(),
                    x.GetRequiredService<IKucoinRestClient>(),
                    x.GetRequiredService<IMexcRestClient>(),
                    x.GetRequiredService<IOKXRestClient>(),
                    x.GetRequiredService<IToobitRestClient>(),
                    x.GetRequiredService<IUpbitRestClient>(),
                    x.GetRequiredService<IWhiteBitRestClient>(),
                    x.GetRequiredService<IXTRestClient>()
                    );
            });

            services.Add(new ServiceDescriptor(typeof(IExchangeSocketClient), x =>
            {
                return new ExchangeSocketClient(
                    x.GetRequiredService<IAsterSocketClient>(),
                    x.GetRequiredService<IBinanceSocketClient>(),
                    x.GetRequiredService<IBingXSocketClient>(),
                    x.GetRequiredService<IBitfinexSocketClient>(),
                    x.GetRequiredService<IBitgetSocketClient>(),
                    x.GetRequiredService<IBitMartSocketClient>(),
                    x.GetRequiredService<IBitMEXSocketClient>(),
                    x.GetRequiredService<IBloFinSocketClient>(),
                    x.GetRequiredService<IBybitSocketClient>(),
                    x.GetRequiredService<ICoinbaseSocketClient>(),
                    x.GetRequiredService<ICoinExSocketClient>(),
                    x.GetRequiredService<ICoinWSocketClient>(),
                    x.GetRequiredService<ICryptoComSocketClient>(),
                    x.GetRequiredService<IDeepCoinSocketClient>(),
                    x.GetRequiredService<IGateIoSocketClient>(),
                    x.GetRequiredService<IHTXSocketClient>(),
                    x.GetRequiredService<IHyperLiquidSocketClient>(),
                    x.GetRequiredService<IKrakenSocketClient>(),
                    x.GetRequiredService<IKucoinSocketClient>(),
                    x.GetRequiredService<IMexcSocketClient>(),
                    x.GetRequiredService<IOKXSocketClient>(),
                    x.GetRequiredService<IToobitSocketClient>(),
                    x.GetRequiredService<IUpbitSocketClient>(),
                    x.GetRequiredService<IWhiteBitSocketClient>(),
                    x.GetRequiredService<IXTSocketClient>()
                    );
            }, socketClientLifetime ?? ServiceLifetime.Singleton));

            services.AddTransient<IExchangeOrderBookFactory, ExchangeOrderBookFactory>();
            services.AddTransient<IExchangeTrackerFactory, ExchangeTrackerFactory>();
            services.AddTransient<IExchangeUserClientProvider, ExchangeUserClientProvider>(x => new ExchangeUserClientProvider(
                x.GetRequiredService<IAsterUserClientProvider>(),
                x.GetRequiredService<IBinanceUserClientProvider>(),
                x.GetRequiredService<IBingXUserClientProvider>(),
                x.GetRequiredService<IBitfinexUserClientProvider>(),
                x.GetRequiredService<IBitgetUserClientProvider>(),
                x.GetRequiredService<IBitMartUserClientProvider>(),
                x.GetRequiredService<IBitMEXUserClientProvider>(),
                x.GetRequiredService<IBloFinUserClientProvider>(),
                x.GetRequiredService<IBybitUserClientProvider>(),
                x.GetRequiredService<ICoinbaseUserClientProvider>(),
                x.GetRequiredService<ICoinExUserClientProvider>(),
                x.GetRequiredService<ICoinWUserClientProvider>(),
                x.GetRequiredService<ICryptoComUserClientProvider>(),
                x.GetRequiredService<IDeepCoinUserClientProvider>(),
                x.GetRequiredService<IGateIoUserClientProvider>(),
                x.GetRequiredService<IHTXUserClientProvider>(),
                x.GetRequiredService<IHyperLiquidUserClientProvider>(),
                x.GetRequiredService<IKrakenUserClientProvider>(),
                x.GetRequiredService<IKucoinUserClientProvider>(),
                x.GetRequiredService<IMexcUserClientProvider>(),
                x.GetRequiredService<IOKXUserClientProvider>(),
                x.GetRequiredService<IToobitUserClientProvider>(),
                x.GetRequiredService<IUpbitUserClientProvider>(),
                x.GetRequiredService<IWhiteBitUserClientProvider>(),
                x.GetRequiredService<IXTUserClientProvider>()
                ));
            return services;
        }
    }
}
