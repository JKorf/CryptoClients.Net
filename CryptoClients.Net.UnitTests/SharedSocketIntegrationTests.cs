using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CryptoClients.Net.UnitTests
{
    [NonParallelizable]
    public class SharedSocketIntegrationTests
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

        private IExchangeSocketClient GetSocketClient()
        {
            var collection = new ServiceCollection();
            collection.AddCryptoClients(x =>
            {
                //x.OutputOriginalData = true;
            });
            collection.AddLogging(x =>
            {
                x.SetMinimumLevel(LogLevel.Trace);
                x.AddProvider(new TraceLoggerProvider());
            });
            var sp = collection.BuildServiceProvider();

            ExchangeParameters.SetStaticParameter(Exchange.Bitget, "ProductType", Bitget.Net.Enums.BitgetProductTypeV2.UsdtFutures);
            ExchangeParameters.SetStaticParameter(Exchange.GateIo, "SettleAsset", "usdt");

            return sp.GetRequiredService<IExchangeSocketClient>();
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
        public async Task TestBookTickerSubscriptions()
        {
            if (!ShouldRun())
                return;

            // Delay for connection rate limiting
            await Task.Delay(2000);

            var client = GetSocketClient();
            var exchangeSymbolsGroups = GetSpotAndFuturesSymbols(Exchange.All, Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var allClients = client.GetBookTickerClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.SubscribeBookTickerOptions.NeedsAuthentication);

                var clientBatches = Math.Ceiling(allClients.Count() / 5d);
                for (var i = 0; i < clientBatches; i++)
                {
                    var batchClients = allClients.Skip(i * 5).Take(5);
                    var updateReceived = batchClients.ToDictionary(x => x.Exchange, x => false);
                    var waitEvent = new AsyncResetEvent(false, false);
                    var tasks = batchClients.Select(x =>
                    {
                        Task<ExchangeResult<UpdateSubscription>>? sub = null;
                        sub = x.SubscribeToBookTickerUpdatesAsync(new SubscribeBookTickerRequest(group.Key), update =>
                        {
                            // Start a new task so there isn't a deadlock when an update is received during subscription
                            _ = Task.Run(() =>
                            {
                                if (!updateReceived[update.Exchange])
                                {
                                    updateReceived[update.Exchange] = true;
                                    _ = sub!.Result.Data.CloseAsync();
                                    if (updateReceived.All(x => x.Value))
                                        waitEvent.Set();
                                }
                            });
                        });
                        return sub;
                    });

                    var results = await Task.WhenAll(tasks);
                    foreach (var result in results)
                    {
                        if (!result.Success)
                            throw new Exception($"Failed for {result.Exchange}: {result.Error}");
                    }

                    var startTime = DateTime.UtcNow;
                    while (DateTime.UtcNow - startTime < TimeSpan.FromSeconds(20))
                    {
                        await waitEvent.WaitAsync(TimeSpan.FromSeconds(1));

                        if (updateReceived.Where(x => results.Single(t => t.Exchange == x.Key)).All(x => x.Value))
                            break;
                    }

                    if (updateReceived.Any(x => results.Any(y => y.Success && y.Exchange == x.Key) && !x.Value))
                        throw new Exception($"No updates received for {string.Join(", ", updateReceived.Where(x => !x.Value).Select(x => x.Key))}");
                }
            }
        }

        [Test]
        public async Task TestKlineSubscriptions()
        {
            if (!ShouldRun())
                return;

            // Delay for connection rate limiting
            await Task.Delay(2000);

            var client = GetSocketClient();
            var exchangeSymbolsGroups = GetSpotAndFuturesSymbols(Exchange.All.Except([Exchange.DeepCoin]), Exchange.All.Except([Exchange.DeepCoin]));

            foreach (var group in exchangeSymbolsGroups)
            {
                var allClients = client.GetKlineClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.SubscribeKlineOptions.NeedsAuthentication);
                
                var clientBatches = Math.Ceiling(allClients.Count() / 5d);
                for (var i = 0; i < clientBatches; i++)
                {
                    var batchClients = allClients.Skip(i * 5).Take(5);
                    var updateReceived = batchClients.ToDictionary(x => x.Exchange, x => false);
                    var waitEvent = new AsyncResetEvent(false, false);
                    var tasks = batchClients.Select(x =>
                    {
                        Task<ExchangeResult<UpdateSubscription>>? sub = null;
                        sub = x.SubscribeToKlineUpdatesAsync(new SubscribeKlineRequest(group.Key, SharedKlineInterval.FiveMinutes), update =>
                        {
                            // Start a new task so there isn't a deadlock when an update is received during subscription
                            _ = Task.Run(() =>
                            {
                                if (!updateReceived[update.Exchange])
                                {
                                    updateReceived[update.Exchange] = true;
                                    _ = sub!.Result.Data.CloseAsync();
                                    if (updateReceived.All(x => x.Value))
                                        waitEvent.Set();
                                }
                            });
                        });
                        return sub;
                    });

                    var results = await Task.WhenAll(tasks);
                    foreach (var result in results)
                    {
                        if (!result.Success)
                            throw new Exception($"Failed for {result.Exchange}: {result.Error}");
                    }
                }
            }
        }

        [Test]
        public async Task TestOrderBookSubscriptions()
        {
            if (!ShouldRun())
                return;

            // Delay for connection rate limiting
            await Task.Delay(2000);

            var client = GetSocketClient();
            var exchangeSymbolsGroups = GetSpotAndFuturesSymbols(Exchange.All, Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var allClients = client.GetOrderBookClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.SubscribeOrderBookOptions.NeedsAuthentication);
                var clientBatches = Math.Ceiling(allClients.Count() / 5d);
                for (var i = 0; i < clientBatches; i++)
                {
                    var batchClients = allClients.Skip(i * 5).Take(5);
                    var updateReceived = batchClients.ToDictionary(x => x.Exchange, x => false);
                    var waitEvent = new AsyncResetEvent(false, false);
                    var tasks = batchClients.Select(x =>
                    {
                        Task<ExchangeResult<UpdateSubscription>>? sub = null;
                        sub = x.SubscribeToOrderBookUpdatesAsync(new SubscribeOrderBookRequest(group.Key), update =>
                        {
                            // Start a new task so there isn't a deadlock when an update is received during subscription
                            _ = Task.Run(() =>
                            {
                                if (!updateReceived[update.Exchange])
                                {
                                    updateReceived[update.Exchange] = true;
                                    _ = sub!.Result.Data.CloseAsync();
                                    if (updateReceived.All(x => x.Value))
                                        waitEvent.Set();
                                }
                            });
                        });
                        return sub;
                    });

                    var results = await Task.WhenAll(tasks);
                    foreach (var result in results)
                    {
                        if (!result.Success)
                            throw new Exception($"Failed for {result.Exchange}: {result.Error}");
                    }

                    var startTime = DateTime.UtcNow;
                    while (DateTime.UtcNow - startTime < TimeSpan.FromSeconds(20))
                    {
                        await waitEvent.WaitAsync(TimeSpan.FromSeconds(1));

                        if (updateReceived.Where(x => results.Single(t => t.Exchange == x.Key)).All(x => x.Value))
                            break;
                    }

                    if (updateReceived.Any(x => results.Any(y => y.Success && y.Exchange == x.Key) && !x.Value))
                        throw new Exception($"No updates received for {string.Join(", ", updateReceived.Where(x => !x.Value).Select(x => x.Key))}");
                }
            }
        }

        [Test]
        public async Task TestTickerSubscriptions()
        {
            if (!ShouldRun())
                return;

            // Delay for connection rate limiting
            await Task.Delay(2000);

            var client = GetSocketClient();
            var exchangeSymbolsGroups = GetSpotAndFuturesSymbols(Exchange.All.Except([Exchange.Mexc]), Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var allClients = client.GetTickerClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.SubscribeTickerOptions.NeedsAuthentication);
                var clientBatches = Math.Ceiling(allClients.Count() / 5d);
                for (var i = 0; i < clientBatches; i++)
                {
                    var batchClients = allClients.Skip(i * 5).Take(5);
                    var updateReceived = batchClients.ToDictionary(x => x.Exchange, x => false);
                    var waitEvent = new AsyncResetEvent(false, false);
                    var tasks = batchClients.Select(x =>
                    {
                        Task<ExchangeResult<UpdateSubscription>>? sub = null;
                        sub = x.SubscribeToTickerUpdatesAsync(new SubscribeTickerRequest(group.Key), update =>
                        {
                            // Start a new task so there isn't a deadlock when an update is received during subscription
                            _ = Task.Run(() =>
                            {
                                if (!updateReceived[update.Exchange])
                                {
                                    updateReceived[update.Exchange] = true;
                                    _ = sub!.Result.Data.CloseAsync();
                                    if (updateReceived.All(x => x.Value))
                                        waitEvent.Set();
                                }
                            });
                        });
                        return sub;
                    });

                    var results = await Task.WhenAll(tasks);
                    foreach (var result in results)
                    {
                        if (!result.Success)
                            throw new Exception($"Failed for {result.Exchange}: {result.Error}");
                    }
                }
            }
        }

        [Test]
        public async Task TestTickersSubscriptions()
        {
            if (!ShouldRun())
                return;

            // Delay for connection rate limiting
            await Task.Delay(2000);

            var client = GetSocketClient();
            var exchangeSymbolsGroups = GetSpotAndFuturesSymbols(Exchange.All, Exchange.All);

            foreach (var group in exchangeSymbolsGroups)
            {
                var allClients = client.GetTickersClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.SubscribeAllTickersOptions.NeedsAuthentication);
                var clientBatches = Math.Ceiling(allClients.Count() / 5d);
                for (var i = 0; i < clientBatches; i++)
                {
                    var batchClients = allClients.Skip(i * 5).Take(5);
                    var updateReceived = batchClients.ToDictionary(x => x.Exchange, x => false);
                    var waitEvent = new AsyncResetEvent(false, false);
                    var tasks = batchClients.Select(x =>
                    {
                        Task<ExchangeResult<UpdateSubscription>>? sub = null;
                        sub = x.SubscribeToAllTickersUpdatesAsync(new SubscribeAllTickersRequest(), update =>
                        {
                            // Start a new task so there isn't a deadlock when an update is received during subscription
                            _ = Task.Run(() =>
                            {
                                if (!updateReceived[update.Exchange])
                                {
                                    updateReceived[update.Exchange] = true;
                                    _ = sub!.Result.Data.CloseAsync();
                                    if (updateReceived.All(x => x.Value))
                                        waitEvent.Set();
                                }
                            });
                        });
                        return sub;
                    });

                    var results = await Task.WhenAll(tasks);
                    foreach (var result in results)
                    {
                        if (!result.Success)
                            throw new Exception($"Failed for {result.Exchange}: {result.Error}");
                    }

                    var startTime = DateTime.UtcNow;
                    while (DateTime.UtcNow - startTime < TimeSpan.FromSeconds(20))
                    {
                        await waitEvent.WaitAsync(TimeSpan.FromSeconds(1));

                        if (updateReceived.Where(x => results.Single(t => t.Exchange == x.Key)).All(x => x.Value))
                            break;
                    }

                    if (updateReceived.Any(x => results.Any(y => y.Success && y.Exchange == x.Key) && !x.Value))
                        throw new Exception($"No updates received for {string.Join(", ", updateReceived.Where(x => !x.Value).Select(x => x.Key))}");
                }
            }
        }

        [Test]
        public async Task TestTradeSubscriptions()
        {
            if (!ShouldRun())
                return;

            // Delay for connection rate limiting
            await Task.Delay(2000);

            var client = GetSocketClient();
            var exchangeSymbolsGroups = GetSpotAndFuturesSymbols(Exchange.All, Exchange.All);
            //var exchangeSymbolsGroups = GetSpotAndFuturesSymbols([Exchange.DeepCoin], [Exchange.DeepCoin]);

            foreach (var group in exchangeSymbolsGroups)
            {
                var allClients = client.GetTradeClients(group.Key.TradingMode)
                                    .Where(x => group.Value.Contains(x.Exchange))
                                    .Where(x => !x.SubscribeTradeOptions.NeedsAuthentication);
                var clientBatches = Math.Ceiling(allClients.Count() / 5d);
                for (var i = 0; i < clientBatches; i++)
                {
                    var batchClients = allClients.Skip(i * 5).Take(5);
                    var updateReceived = batchClients.ToDictionary(x => x.Exchange, x => false);
                    var waitEvent = new AsyncResetEvent(false, false);
                    var tasks = batchClients.Select(x =>
                    {
                        Task<ExchangeResult<UpdateSubscription>>? sub = null;
                        sub = x.SubscribeToTradeUpdatesAsync(new SubscribeTradeRequest(group.Key), update =>
                        {
                            // Start a new task so there isn't a deadlock when an update is received during subscription
                            _ = Task.Run(() =>
                            {
                                if (!updateReceived[update.Exchange])
                                {
                                    updateReceived[update.Exchange] = true;
                                    _ = sub!.Result.Data.CloseAsync();
                                    if (updateReceived.All(x => x.Value))
                                        waitEvent.Set();
                                }
                            });
                        });
                        return sub;
                    });

                    var results = await Task.WhenAll(tasks);
                    foreach (var result in results)
                    {
                        if (!result.Success)
                            throw new Exception($"Failed for {result.Exchange}: {result.Error}");
                    }
                }
            }
        }
    }
}
