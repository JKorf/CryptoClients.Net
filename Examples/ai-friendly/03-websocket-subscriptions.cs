// 03-websocket-subscriptions.cs
//
// Demonstrates: aggregate WebSocket subscriptions across exchanges and clean teardown.
//
// Setup: dotnet add package CryptoClients.Net

using CryptoClients.Net;
using CryptoExchange.Net.SharedApis;

var socketClient = new ExchangeSocketClient();
var symbol = new SharedSymbol(TradingMode.Spot, "BTC", "USDT");
var exchanges = new[] { "Binance", "Bybit", "OKX" };

// ---- 1. SUBSCRIBE TO TICKER UPDATES ON MULTIPLE EXCHANGES ----
var tickerSubscriptions = await socketClient.SubscribeToTickerUpdatesAsync(
    new SubscribeTickerRequest(symbol),
    update =>
    {
        // Keep handlers fast. Offload heavier work to a queue/channel.
        Console.WriteLine($"{update.Exchange} {update.Data.Symbol}: {update.Data.LastPrice}");
    },
    exchanges);

foreach (var sub in tickerSubscriptions)
{
    if (!sub.Success)
        Console.WriteLine($"{sub.Exchange} ticker subscription failed: {sub.Error}");
}

// ---- 2. SUBSCRIBE TO TRADES ----
var tradeSubscriptions = await socketClient.SubscribeToTradeUpdatesAsync(
    new SubscribeTradeRequest(symbol),
    update => Console.WriteLine($"{update.Exchange} trades received: {update.Data.Length}"),
    exchanges);

foreach (var sub in tradeSubscriptions.Where(x => !x.Success))
    Console.WriteLine($"{sub.Exchange} trade subscription failed: {sub.Error}");

// ---- 3. SUBSCRIBE TO KLINES ----
var klineSubscriptions = await socketClient.SubscribeToKlineUpdatesAsync(
    new SubscribeKlineRequest(symbol, SharedKlineInterval.OneMinute),
    update =>
    {
        Console.WriteLine($"{update.Exchange} 1m kline: O={update.Data.OpenPrice} H={update.Data.HighPrice} L={update.Data.LowPrice} C={update.Data.ClosePrice}");
    },
    exchanges);

foreach (var sub in klineSubscriptions.Where(x => !x.Success))
    Console.WriteLine($"{sub.Exchange} kline subscription failed: {sub.Error}");

// ---- 4. SUBSCRIBE TO ORDER BOOK SNAPSHOTS ----
var orderBookSubscriptions = await socketClient.SubscribeToOrderBookUpdatesAsync(
    new SubscribeOrderBookRequest(symbol),
    update => Console.WriteLine($"{update.Exchange} book: {update.Data.Asks.Length} asks / {update.Data.Bids.Length} bids"),
    exchanges);

foreach (var sub in orderBookSubscriptions.Where(x => !x.Success))
    Console.WriteLine($"{sub.Exchange} order book subscription failed: {sub.Error}");

Console.WriteLine("Subscriptions started. Press Enter to stop...");
Console.ReadLine();

// To stop a single aggregate subscription, pass a successful subscription's Data value.
var firstTickerSubscription = tickerSubscriptions.FirstOrDefault(x => x.Success);
if (firstTickerSubscription != null)
    await firstTickerSubscription.Data.CloseAsync();

// Aggregate client teardown: unsubscribe remaining subscriptions and close every connection managed by this client.
await socketClient.UnsubscribeAllAsync();

// If using a direct exchange socket client instead of the aggregate subscription helpers,
// close a single subscription with that client's UnsubscribeAsync method:
// var directSub = await socketClient.Binance.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync("BTCUSDT", update => { });
// if (directSub.Success)
//     await socketClient.Binance.UnsubscribeAsync(directSub.Data);

// Common variations:
//   All tickers:         SubscribeToAllTickerUpdatesAsync(new SubscribeAllTickersRequest(...), ...)
//   Book ticker:         SubscribeToBookTickerUpdatesAsync(new SubscribeBookTickerRequest(symbol), ...)
//   User balances:       SubscribeToBalanceUpdatesAsync(new SubscribeBalancesRequest(...), ...)
//   User spot orders:    SubscribeToSpotOrderUpdatesAsync(new SubscribeSpotOrderRequest(...), ...)
//   Direct sockets:      socketClient.Binance.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync(...)
