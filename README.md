# ![CryptoClients.Net](https://raw.githubusercontent.com/JKorf/CryptoClients.Net/main/CryptoClients.Net/Icon/icon.png) CryptoClients.Net

[![.NET](https://img.shields.io/github/actions/workflow/status/JKorf/CryptoClients.Net/dotnet.yml?style=for-the-badge)](https://github.com/JKorf/CryptoClients.Net/actions/workflows/dotnet.yml)
[![NuGet version](https://img.shields.io/nuget/v/CryptoClients.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net)
[![NuGet downloads](https://img.shields.io/nuget/dt/CryptoClients.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net)
[![MIT license](https://img.shields.io/github/license/JKorf/CryptoClients.Net?style=for-the-badge)](https://github.com/JKorf/CryptoClients.Net/blob/main/LICENSE)
![Since](https://img.shields.io/badge/since-2024-brightgreen?style=for-the-badge)

CryptoClients.Net is a C# library for consuming cryptocurrency market data, streaming updates, and trading across multiple platforms. Use the **Shared API** to reuse the same code across exchanges, and use **native REST and WebSocket clients** for exchange-specific endpoints and models.

[Quick start](#quick-start) · [Choose a client](#choose-a-client) · [Configuration](#configuration) · [Included platforms](#available-client-libraries) · [Release notes](#release-notes)

## Quick start

Install the package in an existing C# project.

```bash
dotnet add package CryptoClients.Net
```

Paste this into a console project's `Program.cs` to fetch the BTC/USDT spot ticker from Binance, Bybit, and OKX. This example uses public market data and requires no API keys.

```csharp
using System;
using CryptoClients.Net.Clients;
using CryptoClients.Net.Enums;
using CryptoExchange.Net.SharedApis;

var client = new ExchangeSharedApiClient();
var exchanges = new[] { Exchange.Binance, Exchange.Bybit, Exchange.OKX };
var tickers = client.GetCapabilities(
    SharedCapabilities.Tickers.GetTicker.Rest, TradingMode.Spot, exchanges);
var request = new GetTickerRequest(new SharedSymbol(TradingMode.Spot, "BTC", "USDT"));

await foreach (var result in tickers.ExecuteAllAsync(request))
{
    Console.WriteLine(result.Success
        ? $"{result.Exchange}: {result.Data.LastPrice}"
        : $"{result.Exchange}: {result.Error}");
}
```

`GetCapabilities` finds one matching implementation per enabled exchange. `ExecuteAllAsync` sends the requests in parallel and yields each result as it completes. Check each result independently, since one exchange can fail while the others succeed.

Coverage depends on the exchange, operation, and trading mode. Exchanges without a matching capability are skipped, so compare the resolved exchanges with your requested list when you need full coverage. A matching capability still requires a listed market and valid request parameters. See the [supported features](https://cryptoexchange.jkorf.dev/docs/crypto-clients/supported-features).

## Choose a client

| What you need | Entry point |
| --- | --- |
| Run the same operation across exchanges or select an exchange at runtime | `ExchangeSharedApiClient.GetCapabilities(...)` or `GetCapability(...)` |
| Browse a single exchange's Shared API V2 at compile time | A typed surface such as `client.Binance.SpotRest` |
| Call a native REST or WebSocket endpoint | `client.Rest.Binance` or `client.Socket.Binance` |

Use `GetCapability` for a single exchange's preferred implementation and `GetImplementations` to see every matching API surface or transport. Inspect a resolved capability's `Options` for parameter requirements and operation limits.

Native endpoints use the exchange's own symbols and models. For example, using the `client` from the quick start:

```csharp
var ticker = await client.Rest.Binance.SpotApi.ExchangeData.GetTickerAsync("BTCUSDT");
Console.WriteLine(ticker.Success ? ticker.Data.LastPrice.ToString() : ticker.Error?.ToString());
```

An application that only needs one exchange's native API can install its [individual NuGet package](#available-client-libraries).

## Configuration

### Dependency injection

In an ASP.NET Core project with `CryptoClients.Net` installed, add this to `Program.cs`. ASP.NET Core injects `IExchangeSharedApiClient` into the endpoint when you call `GET /btc-price`.

```csharp
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.SharedApis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCryptoClients();

var app = builder.Build();

app.MapGet("/btc-price", async (IExchangeSharedApiClient client, CancellationToken ct) =>
{
    var ticker = client.GetCapability(
        Exchange.Binance, SharedCapabilities.Tickers.GetTicker.Rest, TradingMode.Spot);
    if (ticker is null)
        return Results.NotFound();

    var request = new GetTickerRequest(new SharedSymbol(TradingMode.Spot, "BTC", "USDT"));
    var result = await ticker.Capability.GetTickerAsync(request, ct);
    return result.Success
        ? Results.Ok(result.Data.LastPrice)
        : Results.Problem("The exchange did not return a ticker.", statusCode: StatusCodes.Status502BadGateway);
});

app.Run();
```

### Options

Pass an options callback to `AddCryptoClients` to set values such as `EnabledExchanges` or `RequestTimeout`. For configuration binding, call `builder.Services.AddCryptoClients(builder.Configuration.GetSection("CryptoClients"))`. For standalone clients, pass a `CryptoClientsConfiguration` to `ExchangeSharedApiClient` to apply global and per-exchange options.

By default, all exchanges are enabled. `EnabledExchanges` limits which clients the aggregate can use at runtime. Accessing a disabled typed exchange property throws an `InvalidOperationException`.

Private account and trading calls require exchange-specific credentials. Use `ExchangeCredentials` for typed credentials and load the values from your application's secret store or configuration provider. See the [configuration guide](https://cryptoexchange.jkorf.dev/docs/crypto-clients/options) for credentials, environments, and per-exchange settings.

## Examples

| Task | Example |
| --- | --- |
| Stream ticker updates over WebSockets | [Resolve subscriptions, handle results, and close subscriptions](https://github.com/JKorf/CryptoClients.Net/blob/main/Examples/ai-friendly/03-websocket-subscriptions.cs) |
| Maintain local order books or trackers | [Use the order book and tracker factories](https://github.com/JKorf/CryptoClients.Net/blob/main/Examples/ai-friendly/04-order-books-and-trackers.cs) · [Combine books across exchanges](https://cryptoexchange.jkorf.dev/docs/crypto-clients/cross-exchange-book) |
| Read private account data | [Configure credentials and handle errors](https://github.com/JKorf/CryptoClients.Net/blob/main/Examples/ai-friendly/05-credentials-and-error-handling.cs) |
| Host the clients in an application | [Console, ASP.NET Core, and Blazor projects](https://github.com/JKorf/CryptoClients.Net/blob/main/Examples/ReadMe.md) |

Use `IExchangeUserClientProvider` to cache separate clients by user ID in multi-user applications. Close subscriptions and stop books and trackers when their workload ends. See the [usage guide](https://cryptoexchange.jkorf.dev/docs/crypto-clients/usage) for more patterns.

## Available client libraries

The package bundles 32 client libraries. Polymarket exposes its prediction-market endpoints through native clients and its perpetual futures through Shared API V2 surfaces such as `client.Polymarket.PerpsRest`. CoinGecko is a market-data integration available through the concrete `ExchangeRestClient.CoinGecko` property.

Use `Platform.All` for all bundled platform IDs and `Platforms.All` for their metadata. To determine which platforms can perform an operation, query `GetCapabilities` with the operation and trading mode.

| Logo | Platform | Type | Included client library |
| --- | --- | --- | --- |
| <img src="https://raw.githubusercontent.com/JKorf/Aster.Net/refs/heads/main/Aster.Net/Icon/icon.png" alt="Aster" width="32" /> | Aster | DEX | [Jkorf.Aster.Net](https://www.nuget.org/packages/Jkorf.Aster.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Binance.Net/refs/heads/master/Binance.Net/Icon/icon.png" alt="Binance" width="32" /> | Binance | CEX | [Binance.Net](https://www.nuget.org/packages/Binance.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/BingX.Net/refs/heads/main/BingX.Net/Icon/BingX.png" alt="BingX" width="32" /> | BingX | CEX | [JK.BingX.Net](https://www.nuget.org/packages/JK.BingX.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Bitfinex.Net/refs/heads/master/Bitfinex.Net/Icon/icon.png" alt="Bitfinex" width="32" /> | Bitfinex | CEX | [Bitfinex.Net](https://www.nuget.org/packages/Bitfinex.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Bitget.Net/refs/heads/main/Bitget.Net/Icon/icon.png" alt="Bitget" width="32" /> | Bitget | CEX | [JK.Bitget.Net](https://www.nuget.org/packages/JK.Bitget.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Bitstamp.Net/refs/heads/main/Bitstamp.Net/Icon/icon.png" alt="Bitstamp" width="32" /> | Bitstamp | CEX | [Bitstamp.Net](https://www.nuget.org/packages/Bitstamp.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Bitunix.Net/main/Bitunix.Net/Icon/icon.png" alt="Bitunix" width="32" /> | Bitunix | CEX | [Bitunix.Net](https://www.nuget.org/packages/Bitunix.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Bitvavo.Net/main/Bitvavo.Net/Icon/icon.png" alt="Bitvavo" width="32" /> | Bitvavo | CEX | [Bitvavo.Net](https://www.nuget.org/packages/JKorf.Bitvavo.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/BloFin.Net/refs/heads/main/BloFin.Net/Icon/icon.png" alt="BloFin" width="32" /> | BloFin | CEX | [BloFin.Net](https://www.nuget.org/packages/BloFin.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Bybit.Net/refs/heads/main/ByBit.Net/Icon/icon.png" alt="Bybit" width="32" /> | Bybit | CEX | [Bybit.Net](https://www.nuget.org/packages/Bybit.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Coinbase.Net/refs/heads/main/Coinbase.Net/Icon/icon.png" alt="Coinbase" width="32" /> | Coinbase | CEX | [JKorf.Coinbase.Net](https://www.nuget.org/packages/JKorf.Coinbase.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/CoinGecko.Net/refs/heads/main/CoinGecko.Net/Icon/icon.png" alt="CoinGecko" width="32" /> | CoinGecko | Market data | [CoinGecko.Net](https://www.nuget.org/packages/CoinGecko.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/CoinW.Net/refs/heads/main/CoinW.Net/Icon/icon.png" alt="CoinW" width="32" /> | CoinW | CEX | [CoinW.Net](https://www.nuget.org/packages/CoinW.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/CryptoCom.Net/refs/heads/main/CryptoCom.Net/Icon/icon.png" alt="Crypto.com" width="32" /> | Crypto.com | CEX | [CryptoCom.Net](https://www.nuget.org/packages/CryptoCom.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/DeepCoin.Net/refs/heads/main/DeepCoin.Net/Icon/icon.png" alt="DeepCoin" width="32" /> | DeepCoin | CEX | [DeepCoin.Net](https://www.nuget.org/packages/DeepCoin.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/GateIo.Net/refs/heads/main/GateIo.Net/Icon/icon.png" alt="Gate" width="32" /> | Gate | CEX | [GateIo.Net](https://www.nuget.org/packages/GateIo.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/HTX.Net/refs/heads/master/HTX.Net/Icon/icon.png" alt="HTX" width="32" /> | HTX | CEX | [JKorf.HTX.Net](https://www.nuget.org/packages/JKorf.HTX.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/HyperLiquid.Net/refs/heads/main/HyperLiquid.Net/Icon/icon.png" alt="Hyperliquid" width="32" /> | Hyperliquid | DEX | [HyperLiquid.Net](https://www.nuget.org/packages/HyperLiquid.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Kraken.Net/refs/heads/master/Kraken.Net/Icon/icon.png" alt="Kraken" width="32" /> | Kraken | CEX | [KrakenExchange.Net](https://www.nuget.org/packages/KrakenExchange.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Kucoin.Net/refs/heads/master/Kucoin.Net/Icon/icon.png" alt="KuCoin" width="32" /> | KuCoin | CEX | [Kucoin.Net](https://www.nuget.org/packages/Kucoin.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/LBank.Net/refs/heads/main/LBank.Net/Icon/icon.png" alt="LBank" width="32" /> | LBank | CEX | [LBank.Net](https://www.nuget.org/packages/LBank.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Lighter.Net/refs/heads/main/Lighter.Net/Icon/icon.png" alt="Lighter" width="32" /> | Lighter | DEX | [JKorf.Lighter.Net](https://www.nuget.org/packages/JKorf.Lighter.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Mexc.Net/refs/heads/main/Mexc.Net/Icon/icon.png" alt="MEXC" width="32" /> | MEXC | CEX | [JK.Mexc.Net](https://www.nuget.org/packages/JK.Mexc.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/OKX.Net/refs/heads/main/OKX.Net/Icon/icon.png" alt="OKX" width="32" /> | OKX | CEX | [JK.OKX.Net](https://www.nuget.org/packages/JK.OKX.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Pionex.Net/refs/heads/main/Pionex.Net/Icon/icon.png" alt="Pionex" width="32" /> | Pionex | CEX | [Pionex.Net](https://www.nuget.org/packages/Pionex.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Polymarket.Net/refs/heads/main/Polymarket.Net/Icon/icon.png" alt="Polymarket" width="32" /> | Polymarket | DEX and prediction market | [Polymarket.Net](https://www.nuget.org/packages/Polymarket.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Tapbit.Net/refs/heads/main/Tapbit.Net/Icon/icon.png" alt="Tapbit" width="32" /> | Tapbit | CEX | [Tapbit.Net](https://www.nuget.org/packages/Tapbit.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Toobit.Net/refs/heads/main/Toobit.Net/Icon/icon.png" alt="Toobit" width="32" /> | Toobit | CEX | [Toobit.Net](https://www.nuget.org/packages/Toobit.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Upbit.Net/refs/heads/main/Upbit.Net/Icon/icon.png" alt="Upbit" width="32" /> | Upbit | CEX | [JKorf.Upbit.Net](https://www.nuget.org/packages/JKorf.Upbit.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/Weex.Net/refs/heads/main/Weex.Net/Icon/icon.png" alt="Weex" width="32" /> | Weex | CEX | [Weex.Net](https://www.nuget.org/packages/Weex.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/WhiteBit.Net/refs/heads/main/WhiteBit.Net/Icon/icon.png" alt="WhiteBit" width="32" /> | WhiteBit | CEX | [WhiteBit.Net](https://www.nuget.org/packages/WhiteBit.Net) |
| <img src="https://raw.githubusercontent.com/JKorf/XT.Net/refs/heads/main/XT.Net/Icon/icon.png" alt="XT" width="32" /> | XT | CEX | [XT.Net](https://www.nuget.org/packages/XT.Net) |

## Supported target frameworks

The project targets .NET Standard 2.0 and 2.1, and .NET 8, 9, 10, and 11. See [NuGet](https://www.nuget.org/packages/CryptoClients.Net) for package compatibility.

## Resources

- [CryptoClients.Net documentation](https://cryptoexchange.jkorf.dev/docs/crypto-clients)
- [Shared API documentation](https://cryptoexchange.jkorf.dev/docs/shared-api)
- [CryptoClients.Net versus CCXT benchmark](https://github.com/JKorf/CryptoClients.Net/blob/main/docs/crypto-clients-net-benchmark.md)
- [CryptoManager.Net demo application](https://github.com/JKorf/CryptoManager.Net)

### AI / LLM documentation

See the [AI documentation index](https://github.com/JKorf/CryptoClients.Net/blob/main/llms.txt), [consumer skill](https://github.com/JKorf/CryptoClients.Net/blob/main/.claude/skills/cryptoclients-net/SKILL.md), and [repository development guide](https://github.com/JKorf/CryptoClients.Net/blob/main/AGENTS.md).

## Support

### Discord

[![Discord](https://img.shields.io/discord/847020490588422145?style=for-the-badge)](https://discord.gg/MSpeEtSY8t)

Join the Discord server for questions and discussion:  
https://discord.gg/MSpeEtSY8t

### Referral links

Using these links supports the project and may provide the listed fee discount.

<details>
<summary>Show referral links</summary>

|Exchange|Type|Referral link|Fee discount|
|--|--|--|--|
|Aster|DEX|[Link](https://www.asterdex.com/en/referral/FD2E11)|4%|
|Binance|CEX|[Link](https://accounts.binance.com/register?ref=X5K3F2ZG)|20%|
|BingX|CEX|[Link](https://bingx.com/invite/FFHRJKWG/)|20%|
|Bitget|CEX|[Link](https://partner.bitget.com/bg/1qlf6pj1)|20%|
|Bybit|CEX|[Link](https://partner.bybit.com/b/jkorf)|-|
|Coinbase|CEX|[Link](https://advanced.coinbase.com/join/T6H54H8)|-|
|CoinW|CEX|[Link](https://www.coinw.com/en_US/register?r=3912706)|-|
|Crypto.com|CEX|[Link](https://crypto.com/exch/26ge92xbkn)|-|
|DeepCoin|CEX|[Link](https://s.deepcoin.com/jddhfca)|-|
|Gate.io|CEX|[Link](https://www.gate.io/share/JKorf)|20%|
|HTX|CEX|[Link](https://www.htx.com/invite/en-us/1f?invite_code=ekek5223)|30%|
|HyperLiquid|DEX|[Link](https://app.hyperliquid.xyz/join/JKORF)|4%|
|Kucoin|CEX|[Link](https://www.kucoin.com/r/rf/QBS4FPED)|-|
|OKX|CEX|[Link](https://www.okx.com/join/14592495)|20%|
|Tapbit|CEX|[Link](https://www.tapbit.com/en/invite/SPBGMSK)|-|
|Toobit|CEX|[Link](https://www.toobit.com/en-US/register?invite_code=zsV19h)|-|
|WhiteBit|CEX|[Link](https://whitebit.com/referral/a8e59b59-186c-4662-824c-3095248e0edf)|-|
|XT|CEX|[Link](https://www.xt.com/ru/accounts/register?ref=CZG39C)|25%|

</details>

### Donations
Make a one time donation in a crypto currency of your choice. If you prefer to donate in a different currency or network send me a message.
   
**USDT (TRX)** `TKigKeJPXZYyMVDgMyXxMf17MWYia92Rjd`

### Sponsorship

https://github.com/sponsors/JKorf

## Release notes
* Version 5.12.0 - 27 Nov 2026
    * Updated reference CryptoExchange.Net to v13.4.0
    * Added Bitvavo support with JKorf.Bitvavo.Net 1.1.0
    * Updated client library versions

* Version 5.11.0 - 18 Nov 2026
    * Updated library versions
    * Added Polymarket Perps support
    * Fixed ClearUserClients not clearing when resolved from DI
    * Fixed futures order and trade requests ignoring TradingMode

* Version 5.10.0 - 23 Oct 2026
    * Added Bitunix support with Bitunix.Net 1.0.1
    * Updated client library versions

* Version 5.9.0 - 30 Sep 2026
    * Updated refrence CryptoExchange.Net to v13.1.0
    * Updated client library versions
    * Added Rest and Socket properties to (I)ExchangeSharedApiClient to access full APIs and transport specific APIs
    * Added GetSharedApiClient to (I)ExchangeUserClientProvider
    * Fixed ExchangeSharedApiClient UnsubscribeAll always resolving all subscriptions

* Version 5.8.0 - 25 Sep 2026
    * Updated client library versions
    * Removed BitMEX, BitMart and CoinEx support due to exchange shut down
    * Shared APIs
      * Added SharedApi V2 support
      * Added (I)ExchangeSharedApiClient for accessing V2 Shared APIs
      * See https://cryptoexchange.jkorf.dev/docs/shared-api?sharedApiVersion=v2 for more info about the V2 update and https://github.com/JKorf/CryptoExchange.Net/blob/master/docs/SHARED_API_V2_MIGRATION.md for migrating from V1
      * SharedApi V1 will still be supported 
    * Rate limiting
      * Added rate limit admission callback to client options to allow rate limit admission ruling on request definition
      * Added `WithRateLimitAdmissionAsync` to client to allow rate limit admission ruling on a specific request
      * Update rate limit safety margin logic
      * Fixed some rate limit calculation issues
    * Request coalescing
      * Sending identical public GET requests on the same exchange client at the same time will only send a single request to the server and use the same response
      * Coalescing is enabled by default and can be disabled with the `RequestCoalescingEnabled` client option
    * Added new constructors for ExchangeSocketClient and ExchangeRestClient using CryptoClientsConfiguration

* Version 5.7.1 - 01 Sep 2026
    * Updated client library versions, fixing some bugs

* Version 5.7.0 - 24 Aug 2026
    * Updated client library versions
    * Added Tapbit support with Tapbit.Net 1.0.0
    * Added ISpotOrderManagementSocketClient for placing/canceling Spot orders via Shared websocket implementation
    * Added IFuturesOrderManagementSocketClient for placing/canceling Futures orders via Shared websocket implementation
    * Added PlaceSpotOrderAsync, CancelSpotOrderAsync, PlaceFuturesOrderAsync and CancelFuturesOrderAsync queries to ExchangeSocketClient
    * Added UpperFundingCap, LowerFundingCap to SharedFuturesSymbol model
    * Added UpperPriceLimitPerecentage, LowerPriceLimitPercentage, MakerFeePercentage and TakerFeePercentage to SharedSpotSymbol model
    * Added WithCalculatedQuantities(price, contractSize) to SharedQuantity to retrieve a copy with derived quantities
    * Added Description property to Shared EndpointOptions classes
    * Added QuantityType property to SharedOrderBook
    * Updated SharedId value to be nullable
    * Updated quantity/volumes to SharedOrderQuantity model for SharedBookTicker, SharedOpenInterest, SharedPosition, SharedPositionHistory and SharedUserTrade
    * Updated Shared client info string representation

* Version 5.6.0 - 12 Aug 2026
    * Updated client library versions
    * Added EnabledExchange setting to control which exchanges should be available
    * Added ExchangeRestClient.GetSpotTickersAsync method for single exchange request, marked incorrectly named GetSpotTicker as obsolete
    * Added CanCreateKlineTracker and CanCreateTradeTracker on (I)ExchangeTrackerFactory
    * Updated exchange objects to be lazily loaded instead of constructed directly when parent is constructed for ExchangeRestClient, ExchangeSocketClient, ExchangeTrackerFactory, ExchangeOrderBookFactory, ExchangeUserClientProvider

* Version 5.5.0 - 06 Aug 2026
    * Added LBank support with LBank.Net
    * Some small client library updates

* Version 5.4.0 - 30 Jul 2026
    * Updated client library versions
    * Added calculation of AveragePrice on Shared order models if data is available and AveragePrice is not set
    * Added DebuggerDisplay attributes to Result models
    * Added AveragePrice property to SharedQuantity model
    * Updated SharedFuturesTicker, SharedSpotTicker, SharedTrade and SharedKline to use SharedOrderQuantity for volumes/quantities

* Version 5.3.0 - 23 Jul 2026
    * Added Pionex support with Pionex.Net

* Version 5.2.0 - 22 Jul 2026
    * Updated library versions
    * Added SpotSymbolCatalog to Shared ISpotSymbolRestClient interface
    * Added FuturesSymbolCatalog to Shared IFuturesSymbolRestClient interface
    * Added BaseAssetType, BaseAssetSubType, QuoteAssetType and QuoteAssetSubType to GetSymbolsRequest model
    * Added DisplayName to SharedSpotSymbol and SharedFuturesSymbol models
    * Added BaseAssetType, BaseAssetSubType, QuoteAssetType and QuoteAssetSubType to SharedSpotSymbol and SharedFuturesSymbol models
    * Added IsStableCoin, IsCommodity and IsEquity helper methods to LibraryHelpers
    * Added DebuggerDisplay Attributes to Shared response models
    * Updated Aster registration logic so V3 API is used if V3 credentials are provided
    * Fixed global options not getting applied
    * Fixed socket connection combine calculations

* Version 5.1.0 - 10 Jul 2026
    * Updated library versions

* Version 5.0.2 - 04 Jul 2026
    * Updated Kucoin library version to fix issue in websocket user subscriptions
    * Updated Lighter library version to fix issue with signing libraries not getting copied correctly

* Version 5.0.1 - 03 Jul 2026
    * Updated client library versions, fixing signing issues in Binance and Mexc implementation
    * Fixed Lighter implementation missing library references, added Lighter IFundingRateRestClient implementation

* Version 5.0.0 - 30 Jun 2026
    * Updated client library versions
    * Added support for Lighter DEX with JKorf.Lighter.Net v1.0.0
    * Result types:
      * ExchangeWebResult/ExchangeResult types are replaced by HttpResult and WebSocketResult with the same logic
      * WebSocketResult now returns additional info for websocket operations
      * Updated result types to record type
      * Removed implicit result type conversion to bool, `if (result)` no longer works, instead use `if (result.Success)`
      * Fixed result object nullability hinting, for example Data might be null if Success isn't checked for true
    * Clients:
      * Added ToString overrides on base API types
      * Added Exchange property on BaseApiClient
      * Added ApiCredentials property on Api clients
      * Updated ILogger source from client name to topic specific client name
      * Removed logging from client creation
      * Fixed issue in SocketApiClient.GetSocketConnection causing requests to always wait the full max 10 seconds when there was a reconnecting socket
    * Shared APIs:
      * Added missing dedicated option types
      * Added Discover method on ISharedClient interface, returning info on supported capabilities and operations
      * Added ResetStaticExchangeParameters method on ExchangeParameters
      * Added Status property to SharedWithdrawal model
      * Added TradingModes property to SharedBalance model
      * Updated Shared ExchangeParameters parameter names to be case insensitive
      * Updated code comments
      * Removed TradingMode from the response model, only maintained on models where it makes sense
      * Removed IListenKey support, listen keys now rely on internal management
    * Added async streaming on UserDataTracker items with StreamUpdatesAsync
    * Added cancellation token support to UserDataTracker starting
    * Added SupportedEnvironments property to PlatformInfo
    * Added Clear() method on UserClientProvider to clear all cached clients
    * Various small performance improvements
    * Fixed websocket connection attempts counting towards rate limit even when server could not be reached
    * Removed previously deprecated SetApiCredentials method from ExchangeRestClient and ExchangeSocketClient
