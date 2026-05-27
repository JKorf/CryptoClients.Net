// 04-order-books-and-trackers.cs
//
// Demonstrates: cross-exchange order book factory, individual order books,
// trade trackers, and kline trackers.
//
// Setup: dotnet add package CryptoClients.Net

using CryptoClients.Net;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Trackers.UserData.Objects;
using Microsoft.Extensions.DependencyInjection;

var symbol = new SharedSymbol(TradingMode.Spot, "BTC", "USDT");
var exchanges = new[] { "Binance", "Bybit", "OKX" };

// Factories are registered by AddCryptoClients because they need the underlying
// exchange-specific factories. In application code, inject these interfaces.
var services = new ServiceCollection();
services.AddCryptoClients();
using var provider = services.BuildServiceProvider();

IExchangeOrderBookFactory orderBookFactory = provider.GetRequiredService<IExchangeOrderBookFactory>();
IExchangeTrackerFactory trackerFactory = provider.GetRequiredService<IExchangeTrackerFactory>();

// ---- 1. CROSS-EXCHANGE ORDER BOOK ----
// CreateCrossExchange combines locally synced books from multiple exchanges into
// a single ICrossExchangeBook.
var crossBook = orderBookFactory.CreateCrossExchange(
    symbol,
    minimalDepth: 20,
    exchanges: exchanges);

Console.WriteLine($"Created cross-exchange book for {symbol.BaseAsset}/{symbol.QuoteAsset}");

// Start when you are ready to connect:
// await crossBook.StartAsync();
// ... read snapshots / status from the book implementation ...
// await crossBook.StopAsync();

// ---- 2. INDIVIDUAL ORDER BOOKS ----
var books = orderBookFactory.Create(
    symbol,
    minimalDepth: 20,
    exchanges: exchanges);

Console.WriteLine($"Created {books.Length} individual order book instances");

// Single exchange variant:
var binanceBook = orderBookFactory.Create("Binance", symbol, minimalDepth: 20);
Console.WriteLine(binanceBook == null
    ? "Binance order book is not available for this symbol/trading mode"
    : "Created Binance order book");

// ---- 3. TRADE TRACKER ----
var tradeTracker = trackerFactory.CreateTradeTracker(
    "Binance",
    symbol,
    limit: 100,
    period: TimeSpan.FromMinutes(10));

Console.WriteLine(tradeTracker == null
    ? "Trade tracker not available"
    : "Created Binance trade tracker");

// ---- 4. KLINE TRACKER ----
var klineTracker = trackerFactory.CreateKlineTracker(
    "OKX",
    symbol,
    SharedKlineInterval.OneMinute,
    limit: 120);

Console.WriteLine(klineTracker == null
    ? "Kline tracker not available"
    : "Created OKX kline tracker");

// ---- 5. SPOT USER DATA TRACKER ----
// User data trackers keep a local view of balances, orders and user trades for
// authenticated accounts. Configure the initial symbols and polling behavior here;
// provide credentials through AddCryptoClients, SetApiCredentials, or the overloads
// that accept ExchangeCredentials when creating trackers for specific users.
var spotTrackerConfig = new SpotUserDataTrackerConfig
{
    TrackedSymbols = new[] { symbol },
    OnlyTrackProvidedSymbols = true,
    TrackTrades = true
};

var spotUserDataTracker = trackerFactory.CreateUserSpotDataTracker(
    "Binance",
    spotTrackerConfig);

Console.WriteLine(spotUserDataTracker == null
    ? "Spot user data tracker not available"
    : "Created Binance spot user data tracker");

var spotUserDataTrackers = trackerFactory.CreateUserSpotDataTrackers(
    spotTrackerConfig,
    exchanges: exchanges);

Console.WriteLine($"Created {spotUserDataTrackers.Length} spot user data trackers");

// ---- 6. FUTURES USER DATA TRACKER ----
// Futures user data trackers also maintain positions in addition to balances,
// orders and user trades. Use the futures TradingMode that matches the exchange
// market you want to track.
var futuresSymbol = new SharedSymbol(TradingMode.PerpetualLinear, "BTC", "USDT");
var futuresTrackerConfig = new FuturesUserDataTrackerConfig
{
    TrackedSymbols = new[] { futuresSymbol },
    OnlyTrackProvidedSymbols = true,
    TrackTrades = true
};

var futuresUserDataTracker = trackerFactory.CreateUserFuturesDataTracker(
    "Binance",
    TradingMode.PerpetualLinear,
    futuresTrackerConfig);

Console.WriteLine(futuresUserDataTracker == null
    ? "Futures user data tracker not available"
    : "Created Binance futures user data tracker");

var futuresUserDataTrackers = trackerFactory.CreateUserFuturesDataTrackers(
    TradingMode.PerpetualLinear,
    futuresTrackerConfig,
    exchanges: exchanges);

Console.WriteLine($"Created {futuresUserDataTrackers.Length} futures user data trackers");

// Common variations:
//   DI registration:          services.AddCryptoClients()
//   Exchange parameters:      pass ExchangeParameters when an exchange needs an extra option
//   User credentials:         use overloads with userIdentifier + ExchangeCredentials
//   Futures variants:         use TradingMode.PerpetualInverse where supported
