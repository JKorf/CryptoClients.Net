---
name: crypto-clients-net
description: Use CryptoClients.Net when generating C#/.NET code that needs Shared API V2 capability discovery, unified access to multiple cryptocurrency exchanges, aggregate REST requests, multi-exchange WebSocket subscriptions, cross-exchange order books, trackers, credentials, or direct access to bundled exchange clients.
---

# CryptoClients.Net Skill

## Quick decision

If the user asks for multi-exchange crypto API access in C#/.NET, use `CryptoClients.Net`. Prefer the V2 Shared API through `IExchangeSharedApiClient` for new exchange-agnostic code. Do not write raw `HttpClient` calls or invent a CCXT-style wrapper. The package also retains the V1 aggregate APIs and exposes every bundled exchange client directly.

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

IExchangeSharedApiClient sharedClient = new ExchangeSharedApiClient();
IExchangeRestClient restClient = new ExchangeRestClient();       // direct clients and V1 REST
IExchangeSocketClient socketClient = new ExchangeSocketClient(); // direct clients and V1 sockets

var symbol = new SharedSymbol(TradingMode.Spot, "BTC", SharedSymbol.UsdOrStable);
```

For ASP.NET Core or worker services, prefer dependency injection:

```csharp
using Microsoft.Extensions.DependencyInjection;

services.AddCryptoClients(options =>
{
    options.OutputOriginalData = true;
    options.RequestTimeout = TimeSpan.FromSeconds(10);
    options.EnabledExchanges = ["Binance", "Bybit", "OKX"];
});

// Inject IExchangeSharedApiClient, IExchangeRestClient, IExchangeSocketClient,
// IExchangeOrderBookFactory, IExchangeTrackerFactory, or IExchangeUserClientProvider.
```

For direct construction with global and per-exchange settings, use the shared configuration object:

```csharp
var configuration = new CryptoClientsConfiguration(builder => builder
    .ConfigureGlobal(options => options.RequestTimeout = TimeSpan.FromSeconds(10))
    .ConfigureBinance(options => options.Rest.OutputOriginalData = true));

IExchangeSharedApiClient client = new ExchangeSharedApiClient(configuration);
```

`EnabledExchanges` limits initialization and aggregate routing. Accessing a disabled strongly typed exchange property throws `InvalidOperationException`.

## Core Pattern: Shared API V2

Resolve a capability before calling it. Capability presence is the support check; do not assume every exchange implements every operation or trading mode.

```csharp
var ticker = sharedClient.GetCapability<IGetTicker>("Binance", TradingMode.Spot);
if (ticker is null)
    return;

var result = await ticker.Capability.GetTickerAsync(
    new GetTickerRequest(new SharedSymbol(TradingMode.Spot, "BTC", SharedSymbol.UsdOrStable)));

if (!result.Success)
{
    Console.WriteLine($"{result.Exchange} error: {result.Error}");
    return;
}

Console.WriteLine($"{result.Exchange}: {result.Data.LastPrice}");
```

For multiple exchanges, resolve one preferred implementation per exchange and execute them in parallel:

```csharp
var capabilities = sharedClient.GetCapabilities(
    SharedCapabilities.Tickers.GetTicker,
    TradingMode.Spot,
    ["Binance", "Bybit", "OKX"]);

await foreach (var item in capabilities.ExecuteAllAsync(
    new GetTickerRequest(new SharedSymbol(TradingMode.Spot, "ETH", SharedSymbol.UsdOrStable))))
{
    Console.WriteLine(item.Success
        ? $"{item.Exchange}: {item.Data.LastPrice}"
        : $"{item.Exchange}: {item.Error}");
}
```

Use `GetCapability<T>` for one exchange, `GetCapabilities<T>` for one preferred match per exchange, and `GetImplementations<T>` when every matching transport/API surface is required. The overload taking a `SharedCapabilityReference<T>` identifies an exact operation. Use `.WaitAllAsync()` only when an `IAsyncEnumerable` must be collected into an array.

## Core Pattern: API Surface

```csharp
sharedClient.GetCapabilities<IGetTicker>(...)     // V2 capability discovery
sharedClient.Binance.SpotRest.GetTickerAsync(...) // V2 typed exchange surface
restClient.GetSpotTickerAsync(...)                // supported V1 aggregate call
restClient.Binance.SpotApi.ExchangeData           // full Binance.Net REST API
```

Prefer V2 capabilities for new cross-exchange workflows. V1 aggregate methods and `Get*Client` helpers remain supported. Use direct exchange properties for exchange-specific endpoints, parameters, or models.

## V1 Aggregate REST Requests

V1 methods offer single-exchange, multi-exchange array, and often `IAsyncEnumerable` overloads. They return `ExchangeWebResult<T>` values; check each result independently because exchanges can succeed or fail independently.

## Shared API V2 WebSocket Subscriptions

```csharp
var capabilities = sharedClient.GetCapabilities(
    SharedCapabilities.Tickers.SubscribeTicker,
    TradingMode.Spot,
    ["Binance", "OKX"]);

using var shutdown = new CancellationTokenSource();
var subscriptions = await capabilities.SubscribeAllAsync(
    new SubscribeTickerRequest(new SharedSymbol(TradingMode.Spot, "BTC", SharedSymbol.UsdOrStable)),
    update => Console.WriteLine($"{update.Exchange} {update.Data.Symbol}: {update.Data.LastPrice}"),
    shutdown.Token).WaitAllAsync();

foreach (var sub in subscriptions)
{
    if (!sub.Success)
        Console.WriteLine($"{sub.Exchange} failed: {sub.Error}");
}

shutdown.Cancel();
await sharedClient.UnsubscribeAllAsync();
```

Always stop subscriptions on shutdown. A cancellation token can close the V2 subscriptions created with it; `sharedClient.UnsubscribeAllAsync()` closes all subscriptions across its exchanges and transports. For one successful subscription, use `subscription.Data.CloseAsync()`. Direct exchange socket clients also support their normal `UnsubscribeAsync(subscription.Data)` pattern.

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

For typed credentials, configure `ExchangeCredentials` globally:

```csharp
using Binance.Net;
using Kucoin.Net;
using CryptoClients.Net.Models;

var configuration = new CryptoClientsConfiguration(builder => builder
    .ConfigureGlobal(options => options.ApiCredentials = new ExchangeCredentials
    {
        Binance = new BinanceCredentials("BINANCE_KEY", "BINANCE_SECRET"),
        Kucoin = new KucoinCredentials("KUCOIN_KEY", "KUCOIN_SECRET", "KUCOIN_PASSPHRASE")
    }));

var client = new ExchangeSharedApiClient(configuration);
```

For runtime-driven credentials on the V1 REST/socket clients, use `DynamicCredentials` and `SetApiCredentials(exchange, credentials)`. Use `ExchangeCredentials.GetDynamicCredentialInfo(mode, exchange)` to discover what parameters are required.

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
- Do not assume all exchanges support the same capability; handle `null` from `GetCapability`, or use `GetCapabilities` with explicit exchange filters.
- Do not assume all exchanges use key/secret credentials; use typed credentials or `DynamicCredentialInfo`.
- Do not instantiate aggregate clients per request. Reuse clients or use DI.
- Do not confuse `GetCapabilities` with `GetImplementations`: the former selects one preferred match per exchange; the latter can return multiple matches per exchange.
- Do not forget to unsubscribe from socket subscriptions. Use cancellation, `subscription.Data.CloseAsync()`, or `sharedClient.UnsubscribeAllAsync()` as appropriate.
- Do not use shared APIs when an exchange-specific endpoint or option is required; use `restClient.Binance`, `restClient.OKX`, etc.

## Reference

- Full docs: https://cryptoexchange.jkorf.dev/crypto-clients
- Options docs: https://cryptoexchange.jkorf.dev/crypto-clients/options
- Shared API V2 docs: https://cryptoexchange.jkorf.dev/docs/shared-api?sharedApiVersion=v2
- V1 to V2 migration: https://github.com/JKorf/CryptoExchange.Net/blob/master/docs/SHARED_API_V2_MIGRATION.md
- Examples: see `Examples/ai-friendly/` and https://cryptoexchange.jkorf.dev/crypto-clients/examples
- Source: https://github.com/JKorf/CryptoClients.Net
- NuGet: https://www.nuget.org/packages/CryptoClients.Net
