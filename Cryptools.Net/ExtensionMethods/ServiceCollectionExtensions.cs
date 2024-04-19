using Binance.Net.Objects.Options;
using BingX.Net.Objects.Options;
using Cryptools.Net;
using Cryptools.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCryptools(
            this IServiceCollection services,
            GlobalExchangeOptions globalOptions)
        {
            services.AddBinance(options =>
            {
                options.Proxy = globalOptions.Proxy;
                options.ApiCredentials = globalOptions.BinanceApiCredentials;
            }, options =>
            {
                options.Proxy = globalOptions.Proxy;
                options.ApiCredentials = globalOptions.BinanceApiCredentials;
            });
            services.AddBingX(options =>
            {
                options.Proxy = globalOptions.Proxy;
                options.ApiCredentials = globalOptions.BingXApiCredentials;
            }, options =>
            {
                options.Proxy = globalOptions.Proxy;
                options.ApiCredentials = globalOptions.BingXApiCredentials;
            });
            services.AddBitfinex();
            services.AddBitget();
            services.AddBybit();
            services.AddCoinEx();
            services.AddCoinGecko();
            services.AddHuobi();
            services.AddKraken();
            services.AddKucoin();
            services.AddMexc();
            services.AddOKX();

            services.AddTransient<IExchangeRestClient, ExchangeRestClient>();
            services.AddTransient<IExchangeSocketClient, ExchangeSocketClient>();
            services.AddTransient<IExchangeOrderBookFactory, ExchangeOrderBookFactory>();
            return services;
        }

        public static IServiceCollection AddCryptools(
            this IServiceCollection services,
            Action<BinanceRestOptions>? binanceRestOptions = null,
            Action<BinanceSocketOptions>? binanceSocketOptions = null,
            Action<BingXRestOptions>? bingxRestOptions = null,
            Action<BingXSocketOptions>? bingxSocketOptions = null)
        {
            services.AddBinance(binanceRestOptions, binanceSocketOptions);
            services.AddBingX(bingxRestOptions, bingxSocketOptions);
            services.AddBitfinex();
            services.AddBitget();
            services.AddBybit();
            services.AddCoinEx();
            services.AddCoinGecko();
            services.AddHuobi();
            services.AddKraken();
            services.AddKucoin();
            services.AddMexc();
            services.AddOKX();

            services.AddTransient<IExchangeRestClient, ExchangeRestClient>();
            services.AddTransient<IExchangeSocketClient, ExchangeSocketClient>();
            services.AddTransient<IExchangeOrderBookFactory, ExchangeOrderBookFactory>();
            return services;
        }
    }
}
