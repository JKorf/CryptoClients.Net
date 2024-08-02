using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects.Options;
using BingX.Net.Interfaces.Clients;
using BingX.Net.Objects.Options;
using Bitfinex.Net.Interfaces.Clients;
using Bitfinex.Net.Objects.Options;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using BitMart.Net.Interfaces.Clients;
using BitMart.Net.Objects.Options;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using CoinEx.Net.Interfaces.Clients;
using CoinEx.Net.Objects.Options;
using CoinGecko.Net.Objects.Options;
using CryptoClients.Net;
using CryptoClients.Net.Interfaces;
using CryptoClients.Net.Models;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects.Options;
using GateIo.Net.Interfaces.Clients;
using GateIo.Net.Objects.Options;
using Huobi.Net.Interfaces.Clients;
using Huobi.Net.Objects.Options;
using Kraken.Net.Interfaces.Clients;
using Kraken.Net.Objects.Options;
using Kucoin.Net.Interfaces.Clients;
using Kucoin.Net.Objects.Options;
using Mexc.Net.Interfaces.Clients;
using Mexc.Net.Objects.Options;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OKX.Net.Interfaces.Clients;
using OKX.Net.Objects.Options;
using System;
using System.Collections;
using System.Collections.Generic;

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
        /// <param name="globalOptions">The options to be applied for each exchange client. Can be overridden by providing exchange specific options.</param>
        /// <param name="binanceRestOptions">The options options for the Binance rest client. Will override options provided in the global options</param>
        /// <param name="binanceSocketOptions">The options options for the Binance socket client. Will override options provided in the global options</param>
        /// <param name="bingxRestOptions">The options options for the BingX rest client. Will override options provided in the global options</param>
        /// <param name="bingxSocketOptions">The options options for the BingX socket client. Will override options provided in the global options</param>
        /// <param name="bitfinexRestOptions">The options options for the Bitfinex rest client. Will override options provided in the global options</param>
        /// <param name="bitfinexSocketOptions">The options options for the Bitfinex socket client. Will override options provided in the global options</param>
        /// <param name="bitgetRestOptions">The options options for the Bitget rest client. Will override options provided in the global options</param>
        /// <param name="bitgetSocketOptions">The options options for the Bitget socket client. Will override options provided in the global options</param>
        /// <param name="bitMartRestOptions">The options options for the BitMart rest client. Will override options provided in the global options</param>
        /// <param name="bitMartSocketOptions">The options options for the BitMart socket client. Will override options provided in the global options</param>
        /// <param name="bybitRestOptions">The options options for the Bybit rest client. Will override options provided in the global options</param>
        /// <param name="bybitSocketOptions">The options options for the Bybit socket client. Will override options provided in the global options</param>
        /// <param name="coinExRestOptions">The options options for the CoinEx rest client. Will override options provided in the global options</param>
        /// <param name="coinExSocketOptions">The options options for the CoinEx socket client. Will override options provided in the global options</param>
        /// <param name="coinGeckoRestOptions">The options options for the CoinGecko rest client. Will override options provided in the global options</param>
        /// <param name="gateIoRestOptions">The options options for the Gate.io rest client. Will override options provided in the global options</param>
        /// <param name="gateIoSocketOptions">The options options for the Gate.io socket client. Will override options provided in the global options</param>
        /// <param name="huobiRestOptions">The options options for the Huobi rest client. Will override options provided in the global options</param>
        /// <param name="huobiSocketOptions">The options options for the Huobi socket client. Will override options provided in the global options</param>
        /// <param name="krakenRestOptions">The options options for the Kraken rest client. Will override options provided in the global options</param>
        /// <param name="krakenSocketOptions">The options options for the Kraken socket client. Will override options provided in the global options</param>
        /// <param name="kucoinRestOptions">The options options for the Kucoin rest client. Will override options provided in the global options</param>
        /// <param name="kucoinSocketOptions">The options options for the Kucoin socket client. Will override options provided in the global options</param>
        /// <param name="mexcRestOptions">The options options for the Mexc rest client. Will override options provided in the global options</param>
        /// <param name="mexcSocketOptions">The options options for the Mexc socket client. Will override options provided in the global options</param>
        /// <param name="okxRestOptions">The options options for the OKX rest client. Will override options provided in the global options</param>
        /// <param name="okxSocketOptions">The options options for the OKX socket client. Will override options provided in the global options</param>
        /// <param name="socketClientLifetime">The lifetime for the Socket clients. Defaults to Singleton</param>
        /// <returns></returns>
        public static IServiceCollection AddCryptoClients(
            this IServiceCollection services,
            Action<GlobalExchangeOptions>? globalOptions = null,
            Action<BinanceRestOptions>? binanceRestOptions = null,
            Action<BinanceSocketOptions>? binanceSocketOptions = null,
            Action<BingXRestOptions>? bingxRestOptions = null,
            Action<BingXSocketOptions>? bingxSocketOptions = null,
            Action<BitfinexRestOptions>? bitfinexRestOptions = null,
            Action<BitfinexSocketOptions>? bitfinexSocketOptions = null,
            Action<BitgetRestOptions>? bitgetRestOptions = null,
            Action<BitgetSocketOptions>? bitgetSocketOptions = null,
            Action<BitMartRestOptions>? bitMartRestOptions = null,
            Action<BitMartSocketOptions>? bitMartSocketOptions = null,
            Action<BybitRestOptions>? bybitRestOptions = null,
            Action<BybitSocketOptions>? bybitSocketOptions = null,
            Action<CoinExRestOptions>? coinExRestOptions = null,
            Action<CoinExSocketOptions>? coinExSocketOptions = null,
            Action<CoinGeckoRestOptions>? coinGeckoRestOptions = null,
            Action<GateIoRestOptions>? gateIoRestOptions = null,
            Action<GateIoSocketOptions>? gateIoSocketOptions = null,
            Action<HuobiRestOptions>? huobiRestOptions = null,
            Action<HuobiSocketOptions>? huobiSocketOptions = null,
            Action<KrakenRestOptions>? krakenRestOptions = null,
            Action<KrakenSocketOptions>? krakenSocketOptions = null,
            Action<KucoinRestOptions>? kucoinRestOptions = null,
            Action<KucoinSocketOptions>? kucoinSocketOptions = null,
            Action<MexcRestOptions>? mexcRestOptions = null,
            Action<MexcSocketOptions>? mexcSocketOptions = null,
            Action<OKXRestOptions>? okxRestOptions = null,
            Action<OKXSocketOptions>? okxSocketOptions = null,
            ServiceLifetime? socketClientLifetime = null)
        {
            Action<TOptions> SetGlobalRestOptions<TOptions, TCredentials>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TCredentials? credentials) where TOptions : RestExchangeOptions where TCredentials : ApiCredentials
            {
                var restDelegate = (TOptions restOptions) =>
                {
                    restOptions.Proxy = globalOptions.Proxy;
                    restOptions.ApiCredentials = credentials;
                    restOptions.OutputOriginalData = globalOptions.OutputOriginalData;
                    restOptions.RequestTimeout = globalOptions.RequestTimeout;
                    restOptions.RateLimiterEnabled = globalOptions.RateLimiterEnabled;
                    restOptions.RateLimitingBehaviour = globalOptions.RateLimitingBehaviour;
                    restOptions.CachingEnabled = globalOptions.CachingEnabled;
                    exchangeDelegate?.Invoke(restOptions);
                };

                return restDelegate;
            }

            Action<TOptions> SetGlobalSocketOptions<TOptions, TCredentials>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TCredentials? credentials) where TOptions : SocketExchangeOptions where TCredentials : ApiCredentials
            {
                var socketDelegate = (TOptions socketOptions) =>
                {
                    socketOptions.Proxy = globalOptions.Proxy;
                    socketOptions.ApiCredentials = credentials;
                    socketOptions.OutputOriginalData = globalOptions.OutputOriginalData;
                    socketOptions.RequestTimeout = globalOptions.RequestTimeout;
                    socketOptions.RateLimiterEnabled = globalOptions.RateLimiterEnabled;
                    socketOptions.RateLimitingBehaviour = globalOptions.RateLimitingBehaviour;
                    socketOptions.ReconnectPolicy = globalOptions.ReconnectPolicy;
                    socketOptions.ReconnectInterval = globalOptions.ReconnectInterval;
                    exchangeDelegate?.Invoke(socketOptions);
                };

                return socketDelegate;
            }

            if (globalOptions != null)
            {
                var global = GlobalExchangeOptions.Default;
                globalOptions.Invoke(global);

                ExchangeCredentials? credentials = global.ApiCredentials;
                binanceRestOptions = SetGlobalRestOptions(global, binanceRestOptions, credentials?.Binance);
                binanceSocketOptions = SetGlobalSocketOptions(global, binanceSocketOptions, credentials?.Binance);
                bingxRestOptions = SetGlobalRestOptions(global, bingxRestOptions, credentials?.BingX);
                bingxSocketOptions = SetGlobalSocketOptions(global, bingxSocketOptions, credentials?.BingX);
                bitfinexRestOptions = SetGlobalRestOptions(global, bitfinexRestOptions, credentials?.Bitfinex);
                bitfinexSocketOptions = SetGlobalSocketOptions(global, bitfinexSocketOptions, credentials?.Bitfinex);
                bitgetRestOptions = SetGlobalRestOptions(global, bitgetRestOptions, credentials?.Bitget);
                bitgetSocketOptions = SetGlobalSocketOptions(global, bitgetSocketOptions, credentials?.Bitget);
                bitMartRestOptions = SetGlobalRestOptions(global, bitMartRestOptions, credentials?.BitMart);
                bitMartSocketOptions = SetGlobalSocketOptions(global, bitMartSocketOptions, credentials?.BitMart);
                bybitRestOptions = SetGlobalRestOptions(global, bybitRestOptions, credentials?.Bybit);
                bybitSocketOptions = SetGlobalSocketOptions(global, bybitSocketOptions, credentials?.Bybit);
                coinExRestOptions = SetGlobalRestOptions(global, coinExRestOptions, credentials?.CoinEx);
                coinExSocketOptions = SetGlobalSocketOptions(global, coinExSocketOptions, credentials?.CoinEx);
                coinGeckoRestOptions = SetGlobalRestOptions<CoinGeckoRestOptions, ApiCredentials>(global, coinGeckoRestOptions, default);
                gateIoRestOptions = SetGlobalRestOptions(global, gateIoRestOptions, credentials?.GateIo);
                gateIoSocketOptions = SetGlobalSocketOptions(global, gateIoSocketOptions, credentials?.GateIo);
                huobiRestOptions = SetGlobalRestOptions(global, huobiRestOptions, credentials?.Huobi);
                huobiSocketOptions = SetGlobalSocketOptions(global, huobiSocketOptions, credentials?.Huobi);
                krakenRestOptions = SetGlobalRestOptions(global, krakenRestOptions, credentials?.Kraken);
                krakenSocketOptions = SetGlobalSocketOptions(global, krakenSocketOptions, credentials?.Kraken);
                kucoinRestOptions = SetGlobalRestOptions(global, kucoinRestOptions, credentials?.Kucoin);
                kucoinSocketOptions = SetGlobalSocketOptions(global, kucoinSocketOptions, credentials?.Kucoin);
                mexcRestOptions = SetGlobalRestOptions(global, mexcRestOptions, credentials?.Mexc);
                mexcSocketOptions = SetGlobalSocketOptions(global, mexcSocketOptions, credentials?.Mexc);
                okxRestOptions = SetGlobalRestOptions(global, okxRestOptions, credentials?.OKX);
                okxSocketOptions = SetGlobalSocketOptions(global, okxSocketOptions, credentials?.OKX);
            }

            services.AddBinance(binanceRestOptions, binanceSocketOptions, socketClientLifetime);
            services.AddBingX(bingxRestOptions, bingxSocketOptions, socketClientLifetime);
            services.AddBitfinex(bitfinexRestOptions, bitfinexSocketOptions, socketClientLifetime);
            services.AddBitget(bitgetRestOptions, bitgetSocketOptions, socketClientLifetime);
            services.AddBitMart(bitMartRestOptions, bitMartSocketOptions, socketClientLifetime);
            services.AddBybit(bybitRestOptions, bybitSocketOptions, socketClientLifetime);
            services.AddCoinEx(coinExRestOptions, coinExSocketOptions, socketClientLifetime);
            services.AddCoinGecko(coinGeckoRestOptions);
            services.AddGateIo(gateIoRestOptions, gateIoSocketOptions, socketClientLifetime);
            services.AddHuobi(huobiRestOptions, huobiSocketOptions, socketClientLifetime);
            services.AddKraken(krakenRestOptions, krakenSocketOptions, socketClientLifetime);
            services.AddKucoin(kucoinRestOptions, kucoinSocketOptions, socketClientLifetime);
            services.AddMexc(mexcRestOptions, mexcSocketOptions, socketClientLifetime);
            services.AddOKX(okxRestOptions, okxSocketOptions, socketClientLifetime);

            services.AddTransient<IExchangeRestClient, ExchangeRestClient>(x =>
            {
                return new ExchangeRestClient(
                    x.GetRequiredService<IBinanceRestClient>(),
                    x.GetRequiredService<IBingXRestClient>(),
                    x.GetRequiredService<IBitfinexRestClient>(),
                    x.GetRequiredService<IBitgetRestClient>(),
                    x.GetRequiredService<IBitMartRestClient>(),
                    x.GetRequiredService<IBybitRestClient>(),
                    x.GetRequiredService<ICoinExRestClient>(),
                    x.GetRequiredService<IGateIoRestClient>(),
                    x.GetRequiredService<IHuobiRestClient>(),
                    x.GetRequiredService<IKrakenRestClient>(),
                    x.GetRequiredService<IKucoinRestClient>(),
                    x.GetRequiredService<IMexcRestClient>(),
                    x.GetRequiredService<IOKXRestClient>(),
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
                    x.GetRequiredService<ICoinExSocketClient>(),
                    x.GetRequiredService<IGateIoSocketClient>(),
                    x.GetRequiredService<IHuobiSocketClient>(),
                    x.GetRequiredService<IKrakenSocketClient>(),
                    x.GetRequiredService<IKucoinSocketClient>(),
                    x.GetRequiredService<IMexcSocketClient>(),
                    x.GetRequiredService<IOKXSocketClient>()
                    );
            }, socketClientLifetime ?? ServiceLifetime.Singleton));

            services.AddTransient<IExchangeOrderBookFactory, ExchangeOrderBookFactory>();
            return services;
        }
    }
}
