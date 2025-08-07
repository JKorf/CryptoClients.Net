using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CryptoClients.Net.UnitTests
{
    public class SharedRestIntegrationTests
    {
        private static readonly SharedSymbol _testSpotExchangeSymbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");
        private static readonly SharedSymbol _testFuturesExchangeSymbol = new SharedSymbol(TradingMode.PerpetualLinear, "ETH", "USDT");
        private static readonly Dictionary<string, SharedSymbol> _testSpotExchangeSymbolOverrides = new Dictionary<string, SharedSymbol>
        {
            { Exchange.HyperLiquid, new SharedSymbol(TradingMode.Spot, "ETH", "USDC") }
        };
        private static readonly Dictionary<string, SharedSymbol> _testFuturesExchangeSymbolOverrides = new Dictionary<string, SharedSymbol>
        {
            { Exchange.HyperLiquid, new SharedSymbol(TradingMode.PerpetualLinear, "ETH", "USDC") },
            { Exchange.CryptoCom, new SharedSymbol(TradingMode.PerpetualLinear, "ETH", "USD") },
            { Exchange.Kraken, new SharedSymbol(TradingMode.PerpetualLinear, "ETH", "USD") },
        };

        private IExchangeRestClient GetRestClient()
        {
            var collection = new ServiceCollection();
            collection.AddCryptoClients(x => x.OutputOriginalData = true);
            collection.AddLogging(x =>
            {
                x.SetMinimumLevel(LogLevel.Trace);
                x.AddProvider(new TraceLoggerProvider());
            });
            var sp = collection.BuildServiceProvider();

            ExchangeParameters.SetStaticParameter(Exchange.Bitget, "ProductType", Bitget.Net.Enums.BitgetProductTypeV2.UsdtFutures);
            ExchangeParameters.SetStaticParameter(Exchange.GateIo, "SettleAsset", "usdt");

            return sp.GetRequiredService<IExchangeRestClient>();
        }

        private Dictionary<SharedSymbol, List<string>> GetSpotSymbols(IEnumerable<string> exchanges)
        {
            return exchanges.Select(x => _testSpotExchangeSymbolOverrides.TryGetValue(x, out var ov) ? (ov, x) : (_testSpotExchangeSymbol, x))
                .GroupBy(x => x.Item1)
                .ToDictionary(x => x.Key, x => x.Select(x => x.x).ToList());
        }

        private Dictionary<SharedSymbol, List<string>> GetFuturesSymbols(IEnumerable<string> exchanges)
        {
            return exchanges.Select(x => _testFuturesExchangeSymbolOverrides.TryGetValue(x, out var ov) ? (ov, x) : (_testFuturesExchangeSymbol, x))
                .GroupBy(x => x.Item1)
                .ToDictionary(x => x.Key, x => x.Select(x => x.x).ToList());
        }

        private Dictionary<SharedSymbol, List<string>> GetSpotAndFuturesSymbols(IEnumerable<string> spotExchanges, IEnumerable<string> futuresExchanges)
        {
            var spotSymbols = GetSpotSymbols(spotExchanges);
            var futuresSymbols = GetFuturesSymbols(futuresExchanges);
            foreach (var item in futuresSymbols)
                spotSymbols.Add(item.Key, item.Value);
            return spotSymbols;
        }

        private bool ManualRun { get; } = false;

        private bool ShouldRun()
        {
            var integrationTests = Environment.GetEnvironmentVariable("INTEGRATION");
            if (!ManualRun && integrationTests != "1")
                return false;

            return true;
        }

        [Test]
        public async Task TestBookTickersRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetSpotAndFuturesSymbols(Exchange.All.Except([Exchange.HyperLiquid, Exchange.Coinbase, Exchange.GateIo]), Exchange.All.Except([Exchange.Coinbase]));

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetBookTickerClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetBookTickerOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetBookTickerAsync(new GetBookTickerRequest(group.Key)));
                var results = await Task.WhenAll(tasks);
                foreach(var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.BestAskPrice == null)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestFeeRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetSpotAndFuturesSymbols(Exchange.All.Except([Exchange.BitMart]), Exchange.All.Except([Exchange.BitMart]));

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetFeeClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetFeeOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetFeesAsync(new GetFeeRequest(group.Key)));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.MakerFee == null)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestKlineRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetSpotAndFuturesSymbols(Exchange.All, Exchange.All.Except([Exchange.BitMart]));

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetKlineClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetKlinesOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetKlinesAsync(new GetKlinesRequest(group.Key, SharedKlineInterval.FiveMinutes)));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.Any() != true)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestOrderBookRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetSpotAndFuturesSymbols(Exchange.All, Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetOrderBookClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetOrderBookOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetOrderBookAsync(new GetOrderBookRequest(group.Key)));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.Asks.Any() != true)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestRecentTradesRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetSpotAndFuturesSymbols(Exchange.All, Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetRecentTradesClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetRecentTradesOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetRecentTradesAsync(new GetRecentTradesRequest(group.Key)));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.Any() != true)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestTradeHistoryRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetSpotAndFuturesSymbols(Exchange.All.Except([Exchange.BitMEX]), Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetTradeHistoryClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetTradeHistoryOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetTradeHistoryAsync(new GetTradeHistoryRequest(group.Key, DateTime.UtcNow.AddMinutes(-5), DateTime.UtcNow)));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.Any() != true)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestSpotSymbolRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetSpotSymbols(Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetSpotSymbolClients()
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetSpotSymbolsOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetSpotSymbolsAsync(new GetSymbolsRequest()));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.Any() != true)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestSpotTickersRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetSpotSymbols(Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetSpotTickerClients()
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetSpotTickersOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetSpotTickersAsync(new GetTickersRequest()));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.Any() != true)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestSpotTickerRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetSpotSymbols(Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetSpotTickerClients()
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetSpotTickerOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetSpotTickerAsync(new GetTickerRequest(group.Key)));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.LastPrice == null)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestFundingRateRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetFuturesSymbols(Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetFundingRateClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetFundingRateHistoryOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetFundingRateHistoryAsync(new GetFundingRateHistoryRequest(group.Key)));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.Any() != true)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestFuturesSymbolRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetFuturesSymbols(Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetFuturesSymbolClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetFuturesSymbolsOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetFuturesSymbolsAsync(new GetSymbolsRequest()));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.Any() != true)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestFuturesTickerRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetFuturesSymbols(Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetFuturesTickerClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetFuturesTickerOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetFuturesTickerAsync(new GetTickerRequest(group.Key)));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.LastPrice == null)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestFuturesTickersRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetFuturesSymbols(Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetFuturesTickerClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetFuturesTickersOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetFuturesTickersAsync(new GetTickersRequest()));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.Any() != true)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestIndexPriceKlineRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetFuturesSymbols(Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetIndexPriceKlineClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetIndexPriceKlinesOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetIndexPriceKlinesAsync(new GetKlinesRequest(group.Key, SharedKlineInterval.FiveMinutes)));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.Any() != true)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestMarkPriceKlineRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetFuturesSymbols(Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetMarkPriceKlineClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetMarkPriceKlinesOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetMarkPriceKlinesAsync(new GetKlinesRequest(group.Key, SharedKlineInterval.FiveMinutes)));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.Any() != true)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }

        [Test]
        public async Task TestOpenInterestRequests()
        {
            if (!ShouldRun())
                return;

            var client = GetRestClient();
            var exchangeSymbolsGroups = GetFuturesSymbols(Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var clients = client.GetOpenInterestClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.GetOpenInterestOptions.NeedsAuthentication);
                var tasks = clients.Select(x => x.GetOpenInterestAsync(new GetOpenInterestRequest(group.Key)));
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                {
                    if (!result.Success)
                        throw new Exception($"Failed for {result.Exchange}: {result.Error}");

                    if (result.Data?.OpenInterest == null)
                        throw new Exception($"No data for {result.Exchange}");
                }
            }
        }
    }
}
