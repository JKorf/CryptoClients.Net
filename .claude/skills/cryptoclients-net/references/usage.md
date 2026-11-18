# Usage examples

Install `CryptoClients.Net`. Each C# block is independent and includes its imports. Public examples need no credentials. The trading block defines a function without invoking it; compilation never submits an order. See [API routing](api-surfaces.md) and [operational considerations](safety.md).

## Public V2 fan-out

```csharp
using CryptoClients.Net.Clients;
using CryptoClients.Net.Enums;
using CryptoExchange.Net.SharedApis;

var shared = new ExchangeSharedApiClient();
var exchanges = new[] { Exchange.Binance, Exchange.Bybit, Exchange.OKX };
var matches = shared.GetCapabilities(
    SharedCapabilities.Tickers.GetTicker.Rest, TradingMode.Spot, exchanges);
var missing = exchanges.Except(matches.Select(match => match.Exchange), StringComparer.OrdinalIgnoreCase);
foreach (var exchange in missing)
    Console.WriteLine($"No matching capability: {exchange}");
var request = new GetTickerRequest(new SharedSymbol(TradingMode.Spot, "BTC", "USDT"));
var results = await Task.WhenAll(matches.Select(async match =>
    (Match: match, Result: await match.Capability.GetTickerAsync(request))));
foreach (var item in results)
    Console.WriteLine(item.Result.Success
        ? $"{item.Match.Exchange}: {item.Result.Data.LastPrice}"
        : $"{item.Match.Exchange}: {item.Result.Error}");
```

Use `ExecuteAllAsync(request)` for supported fan-out helpers or `ParallelEnumerateAsync` on task sequences when processing results as they complete. Both still require per-exchange success handling.

## Configuration and native access

```csharp
using CryptoClients.Net;
using CryptoClients.Net.Clients;
using CryptoClients.Net.Enums;

var configuration = new CryptoClientsConfiguration(builder => builder
    .ConfigureGlobal(options =>
    {
        options.EnabledExchanges = new[] { Exchange.Binance };
        options.RequestTimeout = TimeSpan.FromSeconds(15);
    })
    .ConfigureBinance(options => options.Rest.OutputOriginalData = true));
var shared = new ExchangeSharedApiClient(configuration);
var result = await shared.Rest.Binance.SpotApi.ExchangeData.GetTickerAsync("BTCUSDT");
if (!result.Success)
    Console.WriteLine(result.Error);
else
    Console.WriteLine(result.Data.LastPrice);
```

Native access uses the underlying package's types and endpoints. The aggregate `Rest` and `Socket` facades do not expose V1 fan-out methods; those remain on `ExchangeRestClient` and `ExchangeSocketClient`.

## Typed credentials and account reads

```csharp
using Binance.Net;
using CryptoClients.Net;
using CryptoClients.Net.Clients;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Models;
using CryptoExchange.Net.SharedApis;

var key = Environment.GetEnvironmentVariable("BINANCE_API_KEY")
    ?? throw new InvalidOperationException("Missing Binance key");
var secret = Environment.GetEnvironmentVariable("BINANCE_API_SECRET")
    ?? throw new InvalidOperationException("Missing Binance secret");
var configuration = new CryptoClientsConfiguration(builder => builder.ConfigureGlobal(options =>
{
    options.EnabledExchanges = new[] { Exchange.Binance };
    options.ApiCredentials = new ExchangeCredentials
    {
        Binance = new BinanceCredentials(key, secret)
    };
}));
var shared = new ExchangeSharedApiClient(configuration);
var match = shared.GetCapability(Exchange.Binance,
    SharedCapabilities.Balances.GetBalances.Rest, TradingMode.Spot);
if (match is null)
    return;
var result = await match.Capability.GetBalancesAsync(new GetBalancesRequest(TradingMode.Spot));
if (!result.Success)
    Console.WriteLine($"{match.Exchange}: {result.Error}");
else
    Console.WriteLine(result.Data);
```

## Dynamic credential discovery

Discover required fields before mapping runtime input. This example uses OKX's known key/secret/passphrase mapping; other exchanges can have different parameters or return no credential metadata.

```csharp
using CryptoClients.Net;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Models;
using CryptoExchange.Net.SharedApis;

var info = ExchangeCredentials.GetDynamicCredentialInfo(TradingMode.Spot, Exchange.OKX);
if (info is null)
    return;
Console.WriteLine($"{info.KeyDescription}; {info.Param1Description}; {info.Param2Description}");
var key = Environment.GetEnvironmentVariable("OKX_API_KEY")
    ?? throw new InvalidOperationException("Missing OKX key");
var secret = Environment.GetEnvironmentVariable("OKX_API_SECRET")
    ?? throw new InvalidOperationException("Missing OKX secret");
var passphrase = Environment.GetEnvironmentVariable("OKX_API_PASSPHRASE")
    ?? throw new InvalidOperationException("Missing OKX passphrase");
var rest = new ExchangeRestClient();
rest.SetApiCredentials(Exchange.OKX, new DynamicCredentials(
    TradingMode.Spot, key, param1: secret, param2: passphrase));
```

## Explicit spot-order function

This function selects exactly one exchange implementation. The caller supplies configured credentials and validated inputs; it does not execute by being defined.

```csharp
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.SharedApis;

static async Task SubmitSpotLimitAsync(
    IExchangeSharedApiClient shared, string exchange, SharedSymbol symbol,
    decimal baseQuantity, decimal price, CancellationToken ct)
{
    var match = shared.GetCapability(exchange,
        SharedCapabilities.Orders.Spot.PlaceOrder.Rest, TradingMode.Spot);
    if (match is null)
        throw new NotSupportedException($"{exchange}: spot order placement unavailable");
    var request = new PlaceSpotOrderRequest(symbol, SharedOrderSide.Buy,
        SharedOrderType.Limit, SharedQuantity.Base(baseQuantity), price: price);
    var result = await match.Capability.PlaceSpotOrderAsync(request, ct);
    if (!result.Success)
        Console.WriteLine($"{match.Exchange}: {result.Error}");
    else
        Console.WriteLine(result.Data);
}
```

Inspect capability options before invoking account-changing code; parameter support is exchange-specific. An ambiguous result requires reconciliation, not automatic resubmission.

## Symbol filters and catalogs

```csharp
using CryptoClients.Net.Clients;
using CryptoClients.Net.Enums;
using CryptoExchange.Net.SharedApis;

var shared = new ExchangeSharedApiClient();
var match = shared.GetCapability(Exchange.Binance,
    SharedCapabilities.Symbols.GetSpotSymbols.Rest, TradingMode.Spot);
if (match is null)
    return;
var request = new GetSymbolsRequest(
    baseAssetType: SharedAssetType.Crypto,
    quoteAssetType: SharedAssetType.Crypto,
    quoteAssetSubType: SharedAssetSubType.StableCoin);
var result = await match.Capability.GetSpotSymbolsAsync(request);
if (!result.Success)
{
    Console.WriteLine(result.Error);
    return;
}
var catalog = match.Capability.SpotSymbolCatalog;
if (catalog is not null && catalog.Assets.TryGetValue("USDT", out var asset))
    Console.WriteLine($"{asset.Name}: {asset.Type}/{asset.SubType}");
Console.WriteLine($"Filtered markets: {result.Data.Length}");
```

For equity markets, use `TradFi` with subtype `Equity`; commodities use `TradFi` with `Commodity`. Futures catalogs have the same fetch-before-read lifecycle, selected with the intended trading mode and `GetFuturesSymbols` capability.

## V2 subscription fan-out

The aggregate below belongs exclusively to this program, so global cleanup has the intended scope, including partial setup.

```csharp
using CryptoClients.Net.Clients;
using CryptoClients.Net.Enums;
using CryptoExchange.Net.SharedApis;

var shared = new ExchangeSharedApiClient();
using var shutdown = new CancellationTokenSource();
try
{
    var matches = shared.GetCapabilities(SharedCapabilities.Tickers.SubscribeTicker,
        TradingMode.Spot, new[] { Exchange.Binance, Exchange.OKX });
    var request = new SubscribeTickerRequest(new SharedSymbol(TradingMode.Spot, "BTC", "USDT"));
    await foreach (var result in matches.SubscribeAllAsync(request,
        update => Console.WriteLine($"{update.Exchange}: {update.Data.LastPrice}"), shutdown.Token))
    {
        if (!result.Success)
            Console.WriteLine($"{result.Exchange}: {result.Error}");
    }
    await Task.Delay(TimeSpan.FromSeconds(30));
}
finally
{
    shutdown.Cancel();
    await shared.UnsubscribeAllAsync();
}
```

For one successful subscription, use its `Data.CloseAsync()`. Do not call global unsubscribe on a shared application singleton if other workloads still own subscriptions.

## DI, books, and trackers

This program creates but does not start the services. Call `StartAsync`, inspect its result, and call `StopAsync` in `finally` when using them; dispose native book/tracker instances that support disposal.

```csharp
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddCryptoClients(options =>
    options.EnabledExchanges = new[] { Exchange.Binance, Exchange.OKX });
using var provider = services.BuildServiceProvider();
var books = provider.GetRequiredService<IExchangeOrderBookFactory>();
var trackers = provider.GetRequiredService<IExchangeTrackerFactory>();
var symbol = new SharedSymbol(TradingMode.Spot, "BTC", "USDT");
var crossBook = books.CreateCrossExchange(symbol, minimalDepth: 20,
    exchanges: new[] { Exchange.Binance, Exchange.OKX });
Console.WriteLine($"Constituent books: {crossBook.ExchangeBooks.Length}");
if (trackers.CanCreateTradeTracker(Exchange.Binance, symbol))
{
    var tracker = trackers.CreateTradeTracker(Exchange.Binance, symbol, limit: 100);
    Console.WriteLine(tracker is null ? "Tracker unavailable" : "Tracker created");
    if (tracker is not null)
        await tracker.StopAsync();
}
foreach (var book in crossBook.ExchangeBooks)
    await book.StopAsync();
```

Checkout-only: [standalone programs](../../../../Examples/ai-friendly/README.md) and [complete examples](../../../../Examples/ReadMe.md). Build without running to validate usage without exchange operations.
