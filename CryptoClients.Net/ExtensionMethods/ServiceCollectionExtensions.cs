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
using Bitget.Net.Objects;
using Bitget.Net.Objects.Options;
using BitMart.Net;
using BitMart.Net.Interfaces.Clients;
using BitMart.Net.Objects;
using BitMart.Net.Objects.Options;
using Bybit.Net;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using Coinbase.Net;
using Coinbase.Net.Interfaces.Clients;
using Coinbase.Net.Objects.Options;
using CoinEx.Net;
using CoinEx.Net.Interfaces.Clients;
using CoinEx.Net.Objects.Options;
using CoinGecko.Net.Objects.Options;
using CryptoClients.Net;
using CryptoClients.Net.Interfaces;
using CryptoClients.Net.Models;
using CryptoCom.Net;
using CryptoCom.Net.Interfaces.Clients;
using CryptoCom.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using GateIo.Net;
using GateIo.Net.Interfaces.Clients;
using GateIo.Net.Objects.Options;
using HTX.Net;
using HTX.Net.Interfaces.Clients;
using HTX.Net.Objects.Options;
using Kraken.Net;
using Kraken.Net.Interfaces.Clients;
using Kraken.Net.Objects.Options;
using Kucoin.Net;
using Kucoin.Net.Interfaces.Clients;
using Kucoin.Net.Objects;
using Kucoin.Net.Objects.Options;
using Mexc.Net;
using Mexc.Net.Interfaces.Clients;
using Mexc.Net.Objects.Options;
using Microsoft.Extensions.Configuration;
using OKX.Net;
using OKX.Net.Interfaces.Clients;
using OKX.Net.Objects;
using OKX.Net.Objects.Options;
using System;
using System.Collections.Generic;
using WhiteBit.Net;
using WhiteBit.Net.Interfaces.Clients;
using WhiteBit.Net.Objects.Options;
using XT.Net;
using XT.Net.Interfaces.Clients;
using XT.Net.Objects.Options;

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
        /// <param name="binanceOptions">The options options for the Binance services. Will override options provided in the global options</param>
        /// <param name="bingxOptions">The options options for the BingX services. Will override options provided in the global options</param>
        /// <param name="bitfinexOptions">The options options for the Bitfinex services. Will override options provided in the global options</param>
        /// <param name="bitgetOptions">The options options for the Bitget services. Will override options provided in the global options</param>
        /// <param name="bitMartOptions">The options options for the BitMart services. Will override options provided in the global options</param>
        /// <param name="bybitOptions">The options options for the Bybit services. Will override options provided in the global options</param>
        /// <param name="coinbaseOptions">The options options for the Coinbase services. Will override options provided in the global options</param>
        /// <param name="coinExOptions">The options options for the CoinEx services. Will override options provided in the global options</param>
        /// <param name="coinGeckoOptions">The options options for the CoinGecko services. Will override options provided in the global options</param>
        /// <param name="cryptoComOptions">The options options for the Crypto.com services. Will override options provided in the global options</param>
        /// <param name="gateIoOptions">The options options for the Gate.io services. Will override options provided in the global options</param>
        /// <param name="htxOptions">The options options for the HTX services. Will override options provided in the global options</param>
        /// <param name="krakenOptions">The options options for the Kraken services. Will override options provided in the global options</param>
        /// <param name="kucoinOptions">The options options for the Kucoin services. Will override options provided in the global options</param>
        /// <param name="mexcOptions">The options options for the Mexc services. Will override options provided in the global options</param>
        /// <param name="okxOptions">The options options for the OKX services. Will override options provided in the global options</param>
        /// <param name="whiteBitOptions">The options options for the WhiteBit services. Will override options provided in the global options</param>
        /// <param name="xtOptions">The options options for the XT services. Will override options provided in the global options</param>
        /// <param name="socketClientLifetime">The lifetime for the Socket clients. Defaults to Singleton</param>
        /// <returns></returns>
        public static IServiceCollection AddCryptoClients(
            this IServiceCollection services,
            Action<GlobalExchangeOptions> globalOptions,
            Action<BinanceOptions>? binanceOptions = null,
            Action<BingXOptions>? bingxOptions = null,
            Action<BitfinexOptions>? bitfinexOptions = null,
            Action<BitgetOptions>? bitgetOptions = null,
            Action<BitMartOptions>? bitMartOptions = null,
            Action<BybitOptions>? bybitOptions = null,
            Action<CoinbaseOptions>? coinbaseOptions = null,
            Action<CoinExOptions>? coinExOptions = null,
            Action<CoinGeckoRestOptions>? coinGeckoOptions = null,
            Action<CryptoComOptions>? cryptoComOptions = null,
            Action<GateIoOptions>? gateIoOptions = null,
            Action<HTXOptions>? htxOptions = null,
            Action<KrakenOptions>? krakenOptions = null,
            Action<KucoinOptions>? kucoinOptions = null,
            Action<MexcOptions>? mexcOptions = null,
            Action<OKXOptions>? okxOptions = null,
            Action<WhiteBitOptions>? whiteBitOptions = null,
            Action<XTOptions>? xtOptions = null,
            ServiceLifetime? socketClientLifetime = null)
        {
            Action<TOptions> SetGlobalOptions<TOptions, TRestOptions, TSocketOptions, TCredentials, TEnvironment>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TCredentials? credentials)
                where TOptions : LibraryOptions<TRestOptions, TSocketOptions, TCredentials, TEnvironment> 
                where TCredentials : ApiCredentials
                where TEnvironment : TradeEnvironment
                where TRestOptions : RestExchangeOptions, new()
                where TSocketOptions : SocketExchangeOptions, new()
            {
                var optsDelegate = (TOptions options) =>
                {
                    options.ApiCredentials = credentials;
                    options.SocketClientLifeTime = socketClientLifetime;
                    options.Rest.Proxy = globalOptions.Proxy;
                    options.Socket.Proxy = globalOptions.Proxy;
                    options.Rest.OutputOriginalData = globalOptions.OutputOriginalData;
                    options.Socket.OutputOriginalData = globalOptions.OutputOriginalData;
                    options.Rest.RequestTimeout = globalOptions.RequestTimeout;
                    options.Socket.RequestTimeout = globalOptions.RequestTimeout;
                    options.Rest.RateLimiterEnabled = globalOptions.RateLimiterEnabled;
                    options.Socket.RateLimiterEnabled = globalOptions.RateLimiterEnabled;
                    options.Rest.RateLimitingBehaviour = globalOptions.RateLimitingBehaviour;
                    options.Socket.RateLimitingBehaviour = globalOptions.RateLimitingBehaviour;
                    options.Rest.CachingEnabled = globalOptions.CachingEnabled;
                    options.Socket.ReconnectPolicy = globalOptions.ReconnectPolicy;
                    options.Socket.ReconnectInterval = globalOptions.ReconnectInterval;

                    exchangeDelegate?.Invoke(options);
                };

                return optsDelegate;
            }

            if (globalOptions != null)
            {
                var global = GlobalExchangeOptions.Default;
                globalOptions.Invoke(global);

                ExchangeCredentials? credentials = global.ApiCredentials;
                binanceOptions = SetGlobalOptions<BinanceOptions, BinanceRestOptions, BinanceSocketOptions, ApiCredentials, BinanceEnvironment>(global, binanceOptions, credentials?.Binance);
                bingxOptions = SetGlobalOptions<BingXOptions, BingXRestOptions, BingXSocketOptions, ApiCredentials, BingXEnvironment>(global, bingxOptions, credentials?.BingX);
                bitfinexOptions = SetGlobalOptions<BitfinexOptions, BitfinexRestOptions, BitfinexSocketOptions, ApiCredentials, BitfinexEnvironment>(global, bitfinexOptions, credentials?.Bitfinex);
                bitgetOptions = SetGlobalOptions<BitgetOptions, BitgetRestOptions, BitgetSocketOptions, BitgetApiCredentials, BitgetEnvironment>(global, bitgetOptions, credentials?.Bitget);
                bitMartOptions = SetGlobalOptions<BitMartOptions, BitMartRestOptions, BitMartSocketOptions, BitMartApiCredentials, BitMartEnvironment>(global, bitMartOptions, credentials?.BitMart);
                bybitOptions = SetGlobalOptions<BybitOptions, BybitRestOptions, BybitSocketOptions, ApiCredentials, BybitEnvironment>(global, bybitOptions, credentials?.Bybit);
                coinbaseOptions = SetGlobalOptions<CoinbaseOptions, CoinbaseRestOptions, CoinbaseSocketOptions, ApiCredentials, CoinbaseEnvironment>(global, coinbaseOptions, credentials?.Coinbase);
                coinExOptions = SetGlobalOptions<CoinExOptions, CoinExRestOptions, CoinExSocketOptions, ApiCredentials, CoinExEnvironment>(global, coinExOptions, credentials?.CoinEx);
                cryptoComOptions = SetGlobalOptions<CryptoComOptions, CryptoComRestOptions, CryptoComSocketOptions, ApiCredentials, CryptoComEnvironment>(global, cryptoComOptions, credentials?.CryptoCom);
                gateIoOptions = SetGlobalOptions<GateIoOptions, GateIoRestOptions, GateIoSocketOptions, ApiCredentials, GateIoEnvironment>(global, gateIoOptions, credentials?.GateIo);
                htxOptions = SetGlobalOptions<HTXOptions, HTXRestOptions, HTXSocketOptions, ApiCredentials, HTXEnvironment>(global, htxOptions, credentials?.HTX);
                krakenOptions = SetGlobalOptions<KrakenOptions, KrakenRestOptions, KrakenSocketOptions, ApiCredentials, KrakenEnvironment>(global, krakenOptions, credentials?.Kraken);
                kucoinOptions = SetGlobalOptions<KucoinOptions, KucoinRestOptions, KucoinSocketOptions, KucoinApiCredentials, KucoinEnvironment>(global, kucoinOptions, credentials?.Kucoin);
                mexcOptions = SetGlobalOptions<MexcOptions, MexcRestOptions, MexcSocketOptions, ApiCredentials, MexcEnvironment>(global, mexcOptions, credentials?.Mexc);
                okxOptions = SetGlobalOptions<OKXOptions, OKXRestOptions, OKXSocketOptions, OKXApiCredentials, OKXEnvironment>(global, okxOptions, credentials?.OKX);
                whiteBitOptions = SetGlobalOptions<WhiteBitOptions, WhiteBitRestOptions, WhiteBitSocketOptions, ApiCredentials, WhiteBitEnvironment>(global, whiteBitOptions, credentials?.WhiteBit);
                xtOptions = SetGlobalOptions<XTOptions, XTRestOptions, XTSocketOptions, ApiCredentials, XTEnvironment>(global, xtOptions, credentials?.XT);
            }

            services.AddBinance(binanceOptions);
            services.AddBingX(bingxOptions);
            services.AddBitfinex(bitfinexOptions);
            services.AddBitget(bitgetOptions);
            services.AddBitMart(bitMartOptions);
            services.AddBybit(bybitOptions);
            services.AddCoinbase(coinbaseOptions);
            services.AddCoinEx(coinExOptions);
            services.AddCoinGecko(coinGeckoOptions);
            services.AddCryptoCom(cryptoComOptions);
            services.AddGateIo(gateIoOptions);
            services.AddHTX(htxOptions);
            services.AddKraken(krakenOptions);
            services.AddKucoin(kucoinOptions);
            services.AddMexc(mexcOptions);
            services.AddOKX(okxOptions);
            services.AddWhiteBit(whiteBitOptions);
            services.AddXT(xtOptions);

            services.AddTransient<IExchangeRestClient, ExchangeRestClient>(x =>
            {
                return new ExchangeRestClient(
                    x.GetRequiredService<IBinanceRestClient>(),
                    x.GetRequiredService<IBingXRestClient>(),
                    x.GetRequiredService<IBitfinexRestClient>(),
                    x.GetRequiredService<IBitgetRestClient>(),
                    x.GetRequiredService<IBitMartRestClient>(),
                    x.GetRequiredService<IBybitRestClient>(),
                    x.GetRequiredService<ICoinbaseRestClient>(),
                    x.GetRequiredService<ICoinExRestClient>(),
                    x.GetRequiredService<ICryptoComRestClient>(),
                    x.GetRequiredService<IGateIoRestClient>(),
                    x.GetRequiredService<IHTXRestClient>(),
                    x.GetRequiredService<IKrakenRestClient>(),
                    x.GetRequiredService<IKucoinRestClient>(),
                    x.GetRequiredService<IMexcRestClient>(),
                    x.GetRequiredService<IOKXRestClient>(),
                    x.GetRequiredService<IWhiteBitRestClient>(),
                    x.GetRequiredService<IXTRestClient>(),
                    x.GetRequiredService<IEnumerable<ISpotClient>>()
                    );
            });

            services.Add(new ServiceDescriptor(typeof(IExchangeSocketClient), x =>
            {
                return new ExchangeSocketClient(
                    x.GetRequiredService<IBinanceSocketClient>(),
                    x.GetRequiredService<IBingXSocketClient>(),
                    x.GetRequiredService<IBitfinexSocketClient>(),
                    x.GetRequiredService<IBitgetSocketClient>(),
                    x.GetRequiredService<IBitMartSocketClient>(),
                    x.GetRequiredService<IBybitSocketClient>(),
                    x.GetRequiredService<ICoinbaseSocketClient>(),
                    x.GetRequiredService<ICoinExSocketClient>(),
                    x.GetRequiredService<ICryptoComSocketClient>(),
                    x.GetRequiredService<IGateIoSocketClient>(),
                    x.GetRequiredService<IHTXSocketClient>(),
                    x.GetRequiredService<IKrakenSocketClient>(),
                    x.GetRequiredService<IKucoinSocketClient>(),
                    x.GetRequiredService<IMexcSocketClient>(),
                    x.GetRequiredService<IOKXSocketClient>(),
                    x.GetRequiredService<IWhiteBitSocketClient>(),
                    x.GetRequiredService<IXTSocketClient>()
                    );
            }, socketClientLifetime ?? ServiceLifetime.Singleton));

            services.AddTransient<IExchangeOrderBookFactory, ExchangeOrderBookFactory>();
            services.AddTransient<IExchangeTrackerFactory, ExchangeTrackerFactory>();
            return services;
        }

        /// <summary>
        /// Add all the exchange clients to the service collection as well as the IExchangeRestClient, IExchangeSocketClient and IExchangeOrderBookFactory aggregation interfaces
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="binanceOptions">The options options for the Binance services. Will override options provided in the global options</param>
        /// <param name="bingxOptions">The options options for the BingX services. Will override options provided in the global options</param>
        /// <param name="bitfinexOptions">The options options for the Bitfinex services. Will override options provided in the global options</param>
        /// <param name="bitgetOptions">The options options for the Bitget services. Will override options provided in the global options</param>
        /// <param name="bitMartOptions">The options options for the BitMart services. Will override options provided in the global options</param>
        /// <param name="bybitOptions">The options options for the Bybit services. Will override options provided in the global options</param>
        /// <param name="coinbaseOptions">The options options for the Coinbase services. Will override options provided in the global options</param>
        /// <param name="coinExOptions">The options options for the CoinEx services. Will override options provided in the global options</param>
        /// <param name="coinGeckoOptions">The options options for the CoinGecko services. Will override options provided in the global options</param>
        /// <param name="cryptoComOptions">The options options for the Crypto.com services. Will override options provided in the global options</param>
        /// <param name="gateIoOptions">The options options for the Gate.io services. Will override options provided in the global options</param>
        /// <param name="htxOptions">The options options for the HTX services. Will override options provided in the global options</param>
        /// <param name="krakenOptions">The options options for the Kraken services. Will override options provided in the global options</param>
        /// <param name="kucoinOptions">The options options for the Kucoin services. Will override options provided in the global options</param>
        /// <param name="mexcOptions">The options options for the Mexc services. Will override options provided in the global options</param>
        /// <param name="okxOptions">The options options for the OKX services. Will override options provided in the global options</param>
        /// <param name="whiteBitOptions">The options options for the WhiteBit services. Will override options provided in the global options</param>
        /// <param name="xtOptions">The options options for the XT services. Will override options provided in the global options</param>
        /// <returns></returns>
        public static IServiceCollection AddCryptoClients(
            this IServiceCollection services,
            IConfiguration? binanceOptions = null,
            IConfiguration? bingxOptions = null,
            IConfiguration? bitfinexOptions = null,
            IConfiguration? bitgetOptions = null,
            IConfiguration? bitMartOptions = null,
            IConfiguration? bybitOptions = null,
            IConfiguration? coinbaseOptions = null,
            IConfiguration? coinExOptions = null,
            IConfiguration? coinGeckoOptions = null,
            IConfiguration? cryptoComOptions = null,
            IConfiguration? gateIoOptions = null,
            IConfiguration? htxOptions = null,
            IConfiguration? krakenOptions = null,
            IConfiguration? kucoinOptions = null,
            IConfiguration? mexcOptions = null,
            IConfiguration? okxOptions = null,
            IConfiguration? whiteBitOptions = null,
            IConfiguration? xtOptions = null)
        {
            void Add(IConfiguration? config, Func<IConfiguration, IServiceCollection> funcConfig, Func<IServiceCollection> funcDefault)
            {
                if (config != null)
                    funcConfig(config);
                else
                    funcDefault();
            }

            Add(binanceOptions, services.AddBinance, () => services.AddBinance());
            Add(bingxOptions, services.AddBingX, () => services.AddBingX());
            Add(bitfinexOptions, services.AddBitfinex, () => services.AddBitfinex());
            Add(bitgetOptions, services.AddBitget, () => services.AddBitget());
            Add(bitMartOptions, services.AddBitMart, () => services.AddBitMart());
            Add(bybitOptions, services.AddBybit, () => services.AddBybit());
            Add(coinbaseOptions, services.AddCoinbase, () => services.AddCoinbase());
            Add(coinExOptions, services.AddCoinEx, () => services.AddCoinEx());
            Add(coinGeckoOptions, services.AddCoinGecko, () => services.AddCoinGecko());
            Add(cryptoComOptions, services.AddCryptoCom, () => services.AddCryptoCom());
            Add(gateIoOptions, services.AddGateIo, () => services.AddGateIo());
            Add(htxOptions, services.AddHTX, () => services.AddHTX());
            Add(krakenOptions, services.AddKraken, () => services.AddKraken());
            Add(kucoinOptions, services.AddKucoin, () => services.AddKucoin());
            Add(mexcOptions, services.AddMexc, () => services.AddMexc());
            Add(okxOptions, services.AddOKX, () => services.AddOKX());
            Add(whiteBitOptions, services.AddWhiteBit, () => services.AddWhiteBit());
            Add(xtOptions, services.AddXT, () => services.AddXT());

            services.AddTransient<IExchangeRestClient, ExchangeRestClient>(x =>
            {
                return new ExchangeRestClient(
                    x.GetRequiredService<IBinanceRestClient>(),
                    x.GetRequiredService<IBingXRestClient>(),
                    x.GetRequiredService<IBitfinexRestClient>(),
                    x.GetRequiredService<IBitgetRestClient>(),
                    x.GetRequiredService<IBitMartRestClient>(),
                    x.GetRequiredService<IBybitRestClient>(),
                    x.GetRequiredService<ICoinbaseRestClient>(),
                    x.GetRequiredService<ICoinExRestClient>(),
                    x.GetRequiredService<ICryptoComRestClient>(),
                    x.GetRequiredService<IGateIoRestClient>(),
                    x.GetRequiredService<IHTXRestClient>(),
                    x.GetRequiredService<IKrakenRestClient>(),
                    x.GetRequiredService<IKucoinRestClient>(),
                    x.GetRequiredService<IMexcRestClient>(),
                    x.GetRequiredService<IOKXRestClient>(),
                    x.GetRequiredService<IWhiteBitRestClient>(),
                    x.GetRequiredService<IXTRestClient>(),
                    x.GetRequiredService<IEnumerable<ISpotClient>>()
                    );
            });

            services.Add(new ServiceDescriptor(typeof(IExchangeSocketClient), x =>
            {
                return new ExchangeSocketClient(
                    x.GetRequiredService<IBinanceSocketClient>(),
                    x.GetRequiredService<IBingXSocketClient>(),
                    x.GetRequiredService<IBitfinexSocketClient>(),
                    x.GetRequiredService<IBitgetSocketClient>(),
                    x.GetRequiredService<IBitMartSocketClient>(),
                    x.GetRequiredService<IBybitSocketClient>(),
                    x.GetRequiredService<ICoinbaseSocketClient>(),
                    x.GetRequiredService<ICoinExSocketClient>(),
                    x.GetRequiredService<ICryptoComSocketClient>(),
                    x.GetRequiredService<IGateIoSocketClient>(),
                    x.GetRequiredService<IHTXSocketClient>(),
                    x.GetRequiredService<IKrakenSocketClient>(),
                    x.GetRequiredService<IKucoinSocketClient>(),
                    x.GetRequiredService<IMexcSocketClient>(),
                    x.GetRequiredService<IOKXSocketClient>(),
                    x.GetRequiredService<IWhiteBitSocketClient>(),
                    x.GetRequiredService<IXTSocketClient>()
                    );
            }, ServiceLifetime.Singleton));

            services.AddTransient<IExchangeOrderBookFactory, ExchangeOrderBookFactory>();
            services.AddTransient<IExchangeTrackerFactory, ExchangeTrackerFactory>();
            return services;
        }
    }
}
