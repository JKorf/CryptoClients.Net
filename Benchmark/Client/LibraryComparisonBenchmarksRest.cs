using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using Binance.Net;
using ccxt;
using CryptoExchange.Net.SharedApis;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace CryptoClients.Net.Benchmark.Client
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [Config(typeof(Config))]
    public class LibraryComparisonBenchmarksRest
    {
        private ExchangeRestClient _cryptoClientsClient;
        private binance _ccxtClient;

        private class Config : ManualConfig
        {
            public Config()
            {
                AddJob(Job.Default
                    .WithRuntime(CoreRuntime.Core10_0)
                    .WithStrategy(RunStrategy.Throughput)
                    .WithWarmupCount(5)
                    .WithIterationCount(25));
            }
        }

        [GlobalSetup]
        public void Setup()
        {
            var env = BinanceEnvironment.CreateCustom(
                "Benchmark",
                "http://localhost:" + Program.ServerPort,
                "ws://localhost:" + Program.ServerPort,
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "");

            _cryptoClientsClient = new ExchangeRestClient(
                binanceRestOptions: options =>
                {
                    options.RateLimiterEnabled = false;
                    options.Environment = env;
                });

            _ccxtClient = CreateRest();
        }

        [Benchmark(Baseline = true), IterationCount(25)]
        public async Task CryptoClientsNet_ServerTime()
        {
            for (var i = 0; i < 1000; i++)
                _ = await _cryptoClientsClient.Binance.SpotApi.ExchangeData.GetServerTimeAsync();
        }

        [Benchmark, IterationCount(25)]
        public async Task CCXT_ServerTime()
        {
            for (var i = 0; i < 1000; i++)
                _ = await _ccxtClient.publicGetTime();
        }

        [Benchmark, IterationCount(25)]
        public async Task CryptoClientsNet_DirectTicker()
        {
            for (var i = 0; i < 1000; i++)
                _ = await _cryptoClientsClient.Binance.SpotApi.ExchangeData.GetTickerAsync("ETHUSDT");
        }

        [Benchmark, IterationCount(25)]
        public async Task CryptoClientsNet_AggregateTicker()
        {
            var request = new GetTickerRequest(new SharedSymbol(TradingMode.Spot, "ETH", "USDT"));
            for (var i = 0; i < 1000; i++)
                _ = await _cryptoClientsClient.GetSpotTickerAsync("Binance", request);
        }

        [Benchmark, IterationCount(25)]
        public async Task CCXT_Ticker()
        {
            var parameters = new Dictionary<string, object>
            {
                ["symbol"] = "ETHUSDT"
            };

            for (var i = 0; i < 1000; i++)
                _ = await _ccxtClient.publicGetTicker24hr(parameters);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
        }

        private static binance CreateRest()
        {
            var client = new binance();
            client.enableRateLimit = false;
            client.newUpdates = true;

            var urls = (Dictionary<string, object>)client.urls;
            var apiUrls = (Dictionary<string, object>)urls["api"];
            apiUrls["public"] = "http://localhost:" + Program.ServerPort + "/api/v3";
            return client;
        }
    }
}
