using Binance.Net.Objects.Options;
using BingX.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects.Options;
using CryptoTradeKit.Net.Interfaces;
using CryptoTradeKit.Net.Models;
using Kucoin.Net.Objects.Options;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CryptoTradeKit.Net.ExtensionMethods
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
        /// <param name="kucoinRestOptions">The options options for the Kucoin rest client. Will override options provided in the global options</param>
        /// <param name="kucoinSocketOptions">The options options for the Kucoin socket client. Will override options provided in the global options</param>
        /// <returns></returns>
        public static IServiceCollection AddCryptools(
            this IServiceCollection services,
            Action<GlobalExchangeOptions>? globalOptions = null,
            Action<BinanceRestOptions>? binanceRestOptions = null,
            Action<BinanceSocketOptions>? binanceSocketOptions = null,
            Action<BingXRestOptions>? bingxRestOptions = null,
            Action<BingXSocketOptions>? bingxSocketOptions = null,
            Action<KucoinRestOptions>? kucoinRestOptions = null,
            Action<KucoinSocketOptions>? kucoinSocketOptions = null)
        {
            Action<TOptions> SetGlobalRestOptions<TOptions, TCredentials>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TCredentials? credentials) where TOptions : RestExchangeOptions where TCredentials : ApiCredentials
            {
                var restDelegate = (TOptions restOptions) =>
                {
                    restOptions.Proxy = globalOptions.Proxy;
                    restOptions.ApiCredentials = credentials;
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
                kucoinRestOptions = SetGlobalRestOptions(global, kucoinRestOptions, credentials?.Kucoin);
                kucoinSocketOptions = SetGlobalSocketOptions(global, kucoinSocketOptions, credentials?.Kucoin);
            }

            services.AddBinance(binanceRestOptions, binanceSocketOptions);
            services.AddBingX(bingxRestOptions, bingxSocketOptions);
            services.AddBitfinex();
            services.AddBitget();
            services.AddBybit();
            services.AddCoinEx();
            services.AddCoinGecko();
            services.AddHuobi();
            services.AddKraken();
            services.AddKucoin(kucoinRestOptions, kucoinSocketOptions);
            services.AddMexc();
            services.AddOKX();

            services.AddTransient<IExchangeRestClient, ExchangeRestClient>();
            services.AddTransient<IExchangeSocketClient, ExchangeSocketClient>();
            services.AddTransient<IExchangeOrderBookFactory, ExchangeOrderBookFactory>();
            return services;
        }
    }
}
