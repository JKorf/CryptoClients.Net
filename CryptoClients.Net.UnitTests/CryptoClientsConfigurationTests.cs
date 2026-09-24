using Binance.Net.Objects.Options;
using CryptoClients.Net.Clients;
using CryptoClients.Net.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CryptoClients.Net.UnitTests
{
    public class CryptoClientsConfigurationTests
    {
        [Test]
        public void ConfigurationShouldCreateSingleNormalizedOptionsFamily()
        {
            var configurationSteps = new List<string>();
            var globalTimeout = TimeSpan.FromSeconds(10);
            var aggregateTimeout = TimeSpan.FromSeconds(20);

            var configuration = new CryptoClientsConfiguration(builder => builder
                .ConfigureGlobal(options =>
                {
                    options.EnabledExchanges = [Exchange.Binance];
                    options.RequestTimeout = globalTimeout;
                })
                .ConfigureBinance(options =>
                {
                    configurationSteps.Add("Aggregate");
                    Assert.That(options.Rest.RequestTimeout, Is.EqualTo(globalTimeout));
                    options.Rest.RequestTimeout = aggregateTimeout;
                    Assert.That(options.Socket.RequestTimeout, Is.EqualTo(globalTimeout));
                }));

            using var httpClient = new HttpClient();
            using var loggerFactory = LoggerFactory.Create(_ => { });
            _ = new ExchangeSharedApiClient(configuration, httpClient, loggerFactory);

            Assert.That(configurationSteps, Is.EqualTo(new[] { "Aggregate" }));
        }

        [Test]
        public void ActionDiRegistrationShouldInvokeExchangeConfiguratorOnce()
        {
            var invocationCount = 0;
            var services = new ServiceCollection();

            services.AddCryptoClients(
                globalOptions: options => options.EnabledExchanges = [Exchange.Binance],
                binanceOptions: _ => invocationCount++);

            Assert.That(invocationCount, Is.EqualTo(1));
        }

        [Test]
        public void ConstructorShouldApplyConfiguration()
        {
            var configuration = new CryptoClientsConfiguration(builder =>
                builder.ConfigureGlobal(options =>
                    options.EnabledExchanges = [Exchange.Binance]));

            Assert.That(configuration.GlobalOptions.EnabledExchanges,
                Is.EqualTo(new[] { Exchange.Binance }));
        }
    }
}
