using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Binance.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;

namespace CryptoClients.Net.Benchmark.Client
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [SimpleJob(RuntimeMoniker.Net10_0)]
    public class LibraryComparisonBenchmarksSocket
    {
        private const int SocketUpdateReceiveTarget = 100_000;

        private ExchangeSocketClient _cryptoClientsClient;
        private ccxt.pro.binance _ccxtClient;

        [GlobalSetup]
        public async Task Setup()
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

            _cryptoClientsClient = new ExchangeSocketClient(
                binanceSocketOptions: options =>
                {
                    options.ReconnectPolicy = ReconnectPolicy.Disabled;
                    options.RateLimiterEnabled = false;
                    options.Environment = env;
                });

            _ccxtClient = CreateWs();
            await _ccxtClient.LoadMarkets();
        }

        [Benchmark(Baseline = true), IterationCount(25)]
        public async Task CryptoClientsNet_DirectTrades()
        {
            var waitEvent = new AsyncResetEvent(false, false);
            var received = 0;
            var result = await _cryptoClientsClient.Binance.SpotApi.ExchangeData.SubscribeToTradeUpdatesAsync(["ETHUSDT"], update =>
            {
                received++;
                if (received == SocketUpdateReceiveTarget)
                    waitEvent.Set();
            }, CancellationToken.None);

            await waitEvent.WaitAsync();
            await result.Data.CloseAsync();
        }

        [Benchmark, IterationCount(25)]
        public async Task CryptoClientsNet_AggregateTrades()
        {
            var waitEvent = new AsyncResetEvent(false, false);
            var received = 0;
            var request = new SubscribeTradeRequest(new SharedSymbol(TradingMode.Spot, "ETH", "USDT"));
            var result = await _cryptoClientsClient.SubscribeToTradeUpdatesAsync("Binance", request, update =>
            {
                received += update.Data.Length;
                if (received >= SocketUpdateReceiveTarget)
                    waitEvent.Set();
            }, CancellationToken.None);

            await waitEvent.WaitAsync();
            await result.Data.CloseAsync();
        }

        [Benchmark, IterationCount(25)]
        public async Task CCXT_Trades()
        {
            var waitEvent = new AsyncResetEvent(false, false);
            var received = 0;
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    var trades = await _ccxtClient.WatchTrades("ETH/USDT");
                    received += trades.Count;

                    if (received >= SocketUpdateReceiveTarget)
                        break;
                }

                waitEvent.Set();
            });

            await waitEvent.WaitAsync();
            await _ccxtClient.Close();
        }

        [GlobalCleanup]
        public async Task Cleanup()
        {
            if (_cryptoClientsClient != null)
                await _cryptoClientsClient.UnsubscribeAllAsync();
        }

        private static ccxt.pro.binance CreateWs()
        {
            var client = new ccxt.pro.binance();
            client.enableRateLimit = false;
            client.newUpdates = true;

            var urls = (Dictionary<string, object>)client.urls;
            var apiUrls = (Dictionary<string, object>)urls["api"];
            apiUrls["ws"] = new Dictionary<string, object>
            {
                ["spot"] = "ws://localhost:" + Program.ServerPort + "/stream",
            };

            return client;
        }
    }
}
