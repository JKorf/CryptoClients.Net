using Binance.Net;
using Binance.Net.Clients;
using Binance.Net.Interfaces;
using Binance.Net.Interfaces.Clients;
using Binance.Net.SymbolOrderBooks;
using Bybit.Net;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.SymbolOrderBooks;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoClients.Net.UnitTests
{
    public class ExchangeRestClientInitializationTests
    {
        [Test]
        public void ResolvingAggregateClientDoesNotResolveExchangeClients()
        {
            var binanceCreated = 0;
            var bybitCreated = 0;
            var services = new ServiceCollection();
            services.AddCryptoClients(options => options.EnabledExchanges = [Exchange.Binance]);
            services.AddTransient<IBinanceRestClient>(_ =>
            {
                binanceCreated++;
                return new BinanceRestClient();
            });
            services.AddTransient<IBybitRestClient>(_ =>
            {
                bybitCreated++;
                return new BybitRestClient();
            });

            using var provider = services.BuildServiceProvider();
            var client = provider.GetRequiredService<IExchangeRestClient>();

            Assert.That(binanceCreated, Is.Zero);
            Assert.That(bybitCreated, Is.Zero);

            Assert.That(client.Binance, Is.Not.Null);
            Assert.That(client.GetSpotTickerClient(Exchange.Binance), Is.Not.Null);
            Assert.That(binanceCreated, Is.EqualTo(1));
            Assert.That(bybitCreated, Is.Zero);
        }

        [Test]
        public void DisabledExchangeIsExcludedAndDirectAccessThrows()
        {
            var bybitCreated = 0;
            var services = new ServiceCollection();
            services.AddCryptoClients(options => options.EnabledExchanges = [Exchange.Binance]);
            services.AddTransient<IBybitRestClient>(_ =>
            {
                bybitCreated++;
                return new BybitRestClient();
            });

            using var provider = services.BuildServiceProvider();
            var client = provider.GetRequiredService<IExchangeRestClient>();

            Assert.That(client.GetExchangeSharedClients(Exchange.Bybit), Is.Empty);
            var exception = Assert.Throws<InvalidOperationException>(() => _ = client.Bybit);
            Assert.That(exception!.Message, Does.Contain(nameof(Models.GlobalExchangeOptions.EnabledExchanges)));
            Assert.That(bybitCreated, Is.Zero);
        }

        [Test]
        public void ResolvingAggregateSocketClientDoesNotResolveExchangeClients()
        {
            var binanceCreated = 0;
            var bybitCreated = 0;
            var services = new ServiceCollection();
            services.AddCryptoClients(options => options.EnabledExchanges = [Exchange.Binance]);
            services.AddSingleton<IBinanceSocketClient>(_ =>
            {
                binanceCreated++;
                return new BinanceSocketClient();
            });
            services.AddSingleton<IBybitSocketClient>(_ =>
            {
                bybitCreated++;
                return new BybitSocketClient();
            });

            using var provider = services.BuildServiceProvider();
            var client = provider.GetRequiredService<IExchangeSocketClient>();

            Assert.That(binanceCreated, Is.Zero);
            Assert.That(bybitCreated, Is.Zero);

            Assert.That(client.Binance, Is.Not.Null);
            Assert.That(client.GetTickerClient(CryptoExchange.Net.SharedApis.TradingMode.Spot, Exchange.Binance), Is.Not.Null);
            Assert.That(binanceCreated, Is.EqualTo(1));
            Assert.That(bybitCreated, Is.Zero);
        }

        [Test]
        public async Task DisabledSocketExchangeIsExcludedAndDirectAccessThrows()
        {
            var bybitCreated = 0;
            var services = new ServiceCollection();
            services.AddCryptoClients(options => options.EnabledExchanges = [Exchange.Binance]);
            services.AddSingleton<IBybitSocketClient>(_ =>
            {
                bybitCreated++;
                return new BybitSocketClient();
            });

            using var provider = services.BuildServiceProvider();
            var client = provider.GetRequiredService<IExchangeSocketClient>();

            Assert.That(client.GetExchangeSharedClients(Exchange.Bybit), Is.Empty);
            await client.UnsubscribeAllAsync();
            var exception = Assert.Throws<InvalidOperationException>(() => _ = client.Bybit);
            Assert.That(exception!.Message, Does.Contain(nameof(Models.GlobalExchangeOptions.EnabledExchanges)));
            Assert.That(bybitCreated, Is.Zero);
        }

        [Test]
        public void ResolvingOrderBookFactoryDoesNotResolveExchangeFactories()
        {
            var binanceCreated = 0;
            var bybitCreated = 0;
            var services = new ServiceCollection();
            services.AddCryptoClients(options => options.EnabledExchanges = [Exchange.Binance]);
            services.AddTransient<IBinanceOrderBookFactory>(x =>
            {
                binanceCreated++;
                return new BinanceOrderBookFactory(x);
            });
            services.AddTransient<IBybitOrderBookFactory>(x =>
            {
                bybitCreated++;
                return new BybitOrderBookFactory(x);
            });

            using var provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<IExchangeOrderBookFactory>();

            Assert.That(binanceCreated, Is.Zero);
            Assert.That(bybitCreated, Is.Zero);

            var firstFactory = factory.Binance;
            var secondFactory = factory.Binance;
            Assert.That(firstFactory, Is.Not.Null);
            Assert.That(secondFactory, Is.SameAs(firstFactory));
            Assert.That(binanceCreated, Is.EqualTo(1));
            Assert.That(bybitCreated, Is.Zero);
        }

        [Test]
        public void DisabledOrderBookFactoryIsExcludedAndDirectAccessThrows()
        {
            var bybitCreated = 0;
            var services = new ServiceCollection();
            services.AddCryptoClients(options => options.EnabledExchanges = [Exchange.Binance]);
            services.AddTransient<IBybitOrderBookFactory>(x =>
            {
                bybitCreated++;
                return new BybitOrderBookFactory(x);
            });

            using var provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<IExchangeOrderBookFactory>();

            var exception = Assert.Throws<InvalidOperationException>(() => _ = factory.Bybit);
            Assert.That(exception!.Message, Does.Contain(nameof(Models.GlobalExchangeOptions.EnabledExchanges)));
            Assert.That(bybitCreated, Is.Zero);
        }

        [Test]
        public void ResolvingTrackerFactoryDoesNotResolveExchangeFactories()
        {
            var binanceCreated = 0;
            var bybitCreated = 0;
            var services = new ServiceCollection();
            services.AddCryptoClients(options => options.EnabledExchanges = [Exchange.Binance]);
            services.AddTransient<IBinanceTrackerFactory>(x =>
            {
                binanceCreated++;
                return new BinanceTrackerFactory(x);
            });
            services.AddTransient<IBybitTrackerFactory>(x =>
            {
                bybitCreated++;
                return new BybitTrackerFactory(x);
            });

            using var provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<IExchangeTrackerFactory>();

            Assert.That(binanceCreated, Is.Zero);
            Assert.That(bybitCreated, Is.Zero);

            var firstFactory = factory.Binance;
            var secondFactory = factory.Binance;
            Assert.That(firstFactory, Is.Not.Null);
            Assert.That(secondFactory, Is.SameAs(firstFactory));
            Assert.That(binanceCreated, Is.EqualTo(1));
            Assert.That(bybitCreated, Is.Zero);
        }

        [Test]
        public void DisabledTrackerFactoryIsExcludedAndDirectAccessThrows()
        {
            var bybitCreated = 0;
            var services = new ServiceCollection();
            services.AddCryptoClients(options => options.EnabledExchanges = [Exchange.Binance]);
            services.AddTransient<IBybitTrackerFactory>(x =>
            {
                bybitCreated++;
                return new BybitTrackerFactory(x);
            });

            using var provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<IExchangeTrackerFactory>();

            Assert.That(factory.CreateUserSpotDataTracker(Exchange.Bybit), Is.Null);
            var exception = Assert.Throws<InvalidOperationException>(() => _ = factory.Bybit);
            Assert.That(exception!.Message, Does.Contain(nameof(Models.GlobalExchangeOptions.EnabledExchanges)));
            Assert.That(bybitCreated, Is.Zero);
        }

        [Test]
        public void ResolvingUserClientProviderDoesNotResolveExchangeProvidersOrClients()
        {
            var binanceCreated = 0;
            var bybitCreated = 0;
            var services = new ServiceCollection();
            services.AddCryptoClients(options => options.EnabledExchanges = [Exchange.Binance]);
            services.AddTransient<IBinanceUserClientProvider>(_ =>
            {
                binanceCreated++;
                return new BinanceUserClientProvider();
            });
            services.AddTransient<IBybitUserClientProvider>(_ =>
            {
                bybitCreated++;
                return new BybitUserClientProvider();
            });

            using var serviceProvider = services.BuildServiceProvider();
            var provider = serviceProvider.GetRequiredService<IExchangeUserClientProvider>();
            var restClient = provider.GetRestClient("user");
            var socketClient = provider.GetSocketClient("user");

            Assert.That(binanceCreated, Is.Zero);
            Assert.That(bybitCreated, Is.Zero);

            Assert.That(restClient.Binance, Is.Not.Null);
            Assert.That(socketClient.Binance, Is.Not.Null);
            Assert.That(binanceCreated, Is.EqualTo(1));
            Assert.That(bybitCreated, Is.Zero);
        }

        [Test]
        public void DisabledUserClientProviderIsExcludedWithoutBeingResolved()
        {
            var bybitCreated = 0;
            var services = new ServiceCollection();
            services.AddCryptoClients(options => options.EnabledExchanges = [Exchange.Binance]);
            services.AddTransient<IBybitUserClientProvider>(_ =>
            {
                bybitCreated++;
                return new BybitUserClientProvider();
            });

            using var serviceProvider = services.BuildServiceProvider();
            var provider = serviceProvider.GetRequiredService<IExchangeUserClientProvider>();
            var restClient = provider.GetRestClient("user");

            Assert.That(restClient.GetExchangeSharedClients(Exchange.Bybit), Is.Empty);
            provider.ClearUserClients("user", Exchange.Bybit);
            var exception = Assert.Throws<InvalidOperationException>(() => _ = restClient.Bybit);
            Assert.That(exception!.Message, Does.Contain(nameof(Models.GlobalExchangeOptions.EnabledExchanges)));
            Assert.That(bybitCreated, Is.Zero);
        }

    }
}
