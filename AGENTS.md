---
name: crypto-clients-net
description: Use CryptoClients.Net when generating C#/.NET code that needs unified access to multiple cryptocurrency exchanges, aggregate REST requests, multi-exchange WebSocket subscriptions, shared CryptoExchange.Net APIs, cross-exchange order books, trackers, dynamic exchange credentials, or direct access to any bundled exchange client.
---

# CryptoClients.Net Skill

## Quick decision

If the user asks for multi-exchange crypto API access in C#/.NET, use `CryptoClients.Net`. Do not write raw `HttpClient` calls or invent a CCXT-style wrapper. `CryptoClients.Net` already combines the exchange-specific clients with the `CryptoExchange.Net.SharedApis` abstraction, shared result handling, client-side rate limiting, WebSocket reconnect logic, order book helpers, trackers, and dynamic credential handling.

Use a standalone exchange package such as `Binance.Net` or `Kucoin.Net` only when the user is targeting one exchange and needs exchange-specific endpoints that are not exposed through shared APIs. `CryptoClients.Net` still exposes those direct clients through `ExchangeRestClient.Binance`, `ExchangeRestClient.Kucoin`, `ExchangeSocketClient.OKX`, etc.

## Installation

```bash
dotnet add package CryptoClients.Net
```

Targets: netstandard2.0, netstandard2.1, net8.0, net9.0, net10.0.

## Core Pattern: Client Setup

```csharp
using CryptoClients.Net;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.SharedApis;

IExchangeRestClient restClient = new ExchangeRestClient();
IExchangeSocketClient socketClient = new ExchangeSocketClient();

var symbol = new SharedSymbol(TradingMode.Spot, "BTC", SharedSymbol.UsdOrStable);
```

For ASP.NET Core or worker services, prefer dependency injection:

```csharp
using Microsoft.Extensions.DependencyInjection;

services.AddCryptoClients(options =>
{
    options.OutputOriginalData = true;
    options.RequestTimeout = TimeSpan.FromSeconds(10);
});

// Inject IExchangeRestClient, IExchangeSocketClient, IExchangeOrderBookFactory,
// IExchangeTrackerFactory, or IExchangeUserClientProvider.
```

## Core Pattern: Result Handling

Aggregate REST methods return `ExchangeWebResult<T>` for a single exchange or arrays of `ExchangeWebResult<T>` for multiple exchanges. Socket subscriptions return `ExchangeResult<UpdateSubscription>` or arrays of `ExchangeResult<UpdateSubscription>`. Always check `.Success` before reading `.Data`.

```csharp
var result = await restClient.GetSpotTickerAsync(
    "Binance",
    new GetTickerRequest(new SharedSymbol(TradingMode.Spot, "BTC", SharedSymbol.UsdOrStable)));

if (!result.Success)
{
    Console.WriteLine($"{result.Exchange} error: {result.Error}");
    return;
}

Console.WriteLine($"{result.Exchange}: {result.Data.LastPrice}");
```

For multi-exchange calls, each exchange can succeed or fail independently:

```csharp
var results = await restClient.GetSpotTickerAsync(
    new GetTickerRequest(new SharedSymbol(TradingMode.Spot, "ETH", SharedSymbol.UsdOrStable)),
    new[] { "Binance", "Bybit", "OKX" });

foreach (var item in results)
{
    if (!item.Success)
        Console.WriteLine($"{item.Exchange} failed: {item.Error}");
    else
        Console.WriteLine($"{item.Exchange}: {item.Data.LastPrice}");
}
```

## Core Pattern: API Surface

The aggregate clients expose three layers:

```csharp
restClient.GetSpotTickerAsync(...)          // aggregate shared call
restClient.GetSpotTickerClient("Binance")   // shared interface for one exchange
restClient.Binance.SpotApi.ExchangeData     // full Binance.Net REST API

socketClient.SubscribeToTickerUpdatesAsync(...) // aggregate shared subscription
socketClient.GetTickerClient(...)               // shared socket interface
socketClient.Binance.SpotApi.ExchangeData       // full Binance.Net socket API
```

Prefer aggregate methods for cross-exchange workflows. Prefer `Get*Client` helpers when building your own routing layer over shared interfaces. Prefer direct exchange properties for exchange-specific endpoints, parameters, or models.

## Aggregate REST Requests

Most aggregate REST methods have these shapes:

```csharp
Task<ExchangeWebResult<T>> MethodAsync(string exchange, Request request, ...);
IAsyncEnumerable<ExchangeWebResult<T>> MethodAsyncEnumerable(Request request, IEnumerable<string>? exchanges = null, ...);
Task<ExchangeWebResult<T>[]> MethodAsync(Request request, IEnumerable<string>? exchanges = null, ...);
```

Use the `AsyncEnumerable` overload when you want to process results as soon as each exchange responds:

```csharp
await foreach (var ticker in restClient.GetSpotTickerAsyncEnumerable(
    new GetTickerRequest(new SharedSymbol(TradingMode.Spot, "BTC", SharedSymbol.UsdOrStable)),
    new[] { "Binance", "Kraken", "Kucoin" }))
{
    Console.WriteLine(ticker.Success
        ? $"{ticker.Exchange}: {ticker.Data.LastPrice}"
        : $"{ticker.Exchange}: {ticker.Error}");
}
```

## Aggregate WebSocket Subscriptions

```csharp
var subscriptions = await socketClient.SubscribeToTickerUpdatesAsync(
    new SubscribeTickerRequest(new SharedSymbol(TradingMode.Spot, "BTC", SharedSymbol.UsdOrStable)),
    update => Console.WriteLine($"{update.Exchange} {update.Data.Symbol}: {update.Data.LastPrice}"),
    new[] { "Binance", "OKX" });

foreach (var sub in subscriptions)
{
    if (!sub.Success)
        Console.WriteLine($"{sub.Exchange} failed: {sub.Error}");
}

// Stop one successful aggregate subscription:
var firstSubscription = subscriptions.FirstOrDefault(x => x.Success);
if (firstSubscription != null)
    await firstSubscription.Data.CloseAsync();

// Or stop every subscription/connection on this aggregate socket client:
await socketClient.UnsubscribeAllAsync();
```

Always stop subscriptions on shutdown. For aggregate `ExchangeSocketClient` subscriptions, use `subscription.Data.CloseAsync()` to close a single subscription, or `UnsubscribeAllAsync()` to close every subscription/connection on the aggregate socket client. For direct exchange socket clients, use that client's `UnsubscribeAsync(subscription.Data)` method when closing a single subscription.

## Direct Exchange Access

`CryptoClients.Net` includes full direct clients for each supported exchange. Use these when shared APIs do not expose the endpoint you need.

```csharp
var client = new ExchangeRestClient();

var binanceTicker = await client.Binance.SpotApi.ExchangeData.GetTickerAsync("BTCUSDT");
var kucoinTicker = await client.Kucoin.SpotApi.ExchangeData.GetTickerAsync("BTC-USDT");
var okxAccounts = client.OKX;
```

Direct access uses the same public surface as the individual exchange packages. Inspect that exchange package source before generating exchange-specific code.

## Credentials

For typed credentials, configure `ExchangeCredentials`:

```csharp
using Binance.Net;
using Kucoin.Net;
using CryptoClients.Net.Models;

var client = new ExchangeRestClient(options =>
{
    options.ApiCredentials = new ExchangeCredentials
    {
        Binance = new BinanceCredentials("BINANCE_KEY", "BINANCE_SECRET"),
        Kucoin = new KucoinCredentials("KUCOIN_KEY", "KUCOIN_SECRET", "KUCOIN_PASSPHRASE")
    };
});
```

For runtime-driven credentials, use `DynamicCredentials` and `SetApiCredentials(exchange, credentials)`. Use `ExchangeCredentials.GetDynamicCredentialInfo(mode, exchange)` to discover what parameters are required.

```csharp
var info = ExchangeCredentials.GetDynamicCredentialInfo(TradingMode.Spot, "OKX");

restClient.SetApiCredentials("OKX", new DynamicCredentials(
    TradingMode.Spot,
    "OKX_KEY",
    param1: "OKX_SECRET",
    param2: "OKX_PASSPHRASE"));
```

Do not assume every exchange uses key/secret only. Several exchanges require a passphrase or chain-specific credential shape, and Upbit returns no dynamic credential info in this library.

After calling `GetSpotSymbolsAsync` or `GetFuturesSymbolsAsync` on a shared symbol client, its `SpotSymbolCatalog` or `FuturesSymbolCatalog` provides the fetched catalog. Do not read a catalog before the corresponding fetch.

## Cross-Exchange Order Books

Use `IExchangeOrderBookFactory.CreateCrossExchange` for a locally synced aggregate book across exchanges:

```csharp
var book = orderBookFactory.CreateCrossExchange(
    new SharedSymbol(TradingMode.Spot, "BTC", SharedSymbol.UsdOrStable),
    minimalDepth: 20,
    exchanges: new[] { "Binance", "Bybit", "OKX" });

await book.StartAsync();
```

Use `Create(exchange, symbol, ...)` or `Create(symbol, ..., exchanges)` for individual `ISymbolOrderBook` instances.

## Trackers

Use `IExchangeTrackerFactory` for trade, kline, and user data trackers:

```csharp
var tradeTracker = trackerFactory.CreateTradeTracker(
    "Binance",
    new SharedSymbol(TradingMode.Spot, "ETH", SharedSymbol.UsdOrStable),
    limit: 100);

var klineTracker = trackerFactory.CreateKlineTracker(
    "OKX",
    new SharedSymbol(TradingMode.Spot, "ETH", SharedSymbol.UsdOrStable),
    SharedKlineInterval.OneMinute);
```

User data trackers require credentials. Use the overloads that accept `ExchangeCredentials`, user identifiers, environments, and optional exchange filters.

## Common Pitfalls - AVOID

- Do not call exchange REST endpoints with raw `HttpClient`; use aggregate methods, shared clients, or direct exchange clients.
- Do not assume one exchange failure means the entire aggregate request failed; inspect each `ExchangeWebResult`.
- Do not read `.Data` before checking `.Success`.
- Do not hardcode symbol formats like `BTCUSDT` for shared APIs; use `SharedSymbol`. For cross-exchange USD/stable quote routing, prefer `SharedSymbol.UsdOrStable` instead of hardcoding `USDT` when USDC/USD variants are acceptable.
- Do not assume all exchanges support the same shared interface; use `Get*Client(...)` and handle `null`, or call aggregate methods with explicit exchange filters.
- Do not assume all exchanges use key/secret credentials; use typed credentials or `DynamicCredentialInfo`.
- Do not instantiate aggregate clients per request. Reuse clients or use DI.
- Do not forget to unsubscribe from socket subscriptions. Use `subscription.Data.CloseAsync()` for one aggregate subscription, direct exchange `UnsubscribeAsync(subscription.Data)` for one direct exchange subscription, or `UnsubscribeAllAsync()` for all aggregate subscriptions.
- Do not use aggregate shared APIs when an exchange-specific endpoint or option is required; use `restClient.Binance`, `restClient.OKX`, etc.

## Reference

- Full docs: https://cryptoexchange.jkorf.dev/crypto-clients
- Options docs: https://cryptoexchange.jkorf.dev/crypto-clients/options
- Shared API docs: https://cryptoexchange.jkorf.dev/client-libs/shared
- Examples: see `Examples/ai-friendly/` and https://cryptoexchange.jkorf.dev/crypto-clients/examples
- Source: https://github.com/JKorf/CryptoClients.Net
- NuGet: https://www.nuget.org/packages/CryptoClients.Net
