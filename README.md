# ![CryptoClients.Net](https://raw.githubusercontent.com/JKorf/CryptoClients.Net/main/CryptoClients.Net/Icon/icon.png) CryptoClients.Net

[![.NET](https://img.shields.io/github/actions/workflow/status/JKorf/CryptoClients.Net/dotnet.yml?style=for-the-badge)](https://github.com/JKorf/CryptoClients.Net/actions/workflows/dotnet.yml)
[![NuGet version](https://img.shields.io/nuget/v/CryptoClients.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net)
[![NuGet downloads](https://img.shields.io/nuget/dt/CryptoClients.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net)
![License](https://img.shields.io/github/license/JKorf/CryptoClients.Net?style=for-the-badge)
[![Docs](https://img.shields.io/badge/Docs-CryptoClients.Net-1b7f50?style=for-the-badge)](https://cryptoexchange.jkorf.dev/docs/crypto-clients)

**[Documentation](https://cryptoexchange.jkorf.dev/docs/crypto-clients)** · **[Supported features](https://cryptoexchange.jkorf.dev/docs/crypto-clients/supported-features)** · **[Examples](https://cryptoexchange.jkorf.dev/docs/crypto-clients/examples)** · **[Configuration](https://cryptoexchange.jkorf.dev/docs/crypto-clients/options)** · **[AI / LLM docs](#ai--llm-documentation)** · **[Benchmark](https://github.com/JKorf/CryptoClients.Net/blob/main/docs/crypto-clients-net-benchmark.md)**

`CryptoClients.Net` provides unified access to cryptocurrency trading APIs in C#. Use one shared API for exchange-agnostic code, or access every exchange-specific REST and WebSocket API directly from the same package.

It combines:
- direct access to exchange-specific REST and WebSocket clients
- shared cross-exchange interfaces from [CryptoExchange.Net](https://cryptoexchange.jkorf.dev/docs/base-library)
- dynamic multi-exchange requests and subscriptions
- client-side helpers such as rate limiting, order books, trackers, and user client management

The package includes **32 client libraries**: **30 exchanges** plus **CoinGecko** and **Polymarket**. See the [complete library table](#available-client-libraries).

Choose `CryptoClients.Net` when an application uses multiple exchanges, needs exchange-agnostic code, or selects exchanges at runtime. If an application only targets one exchange and mainly uses exchange-specific endpoints, install that exchange's individual package instead.

> **Important:** Shared API coverage varies by exchange, operation, and trading mode. Aggregate calls run only against compatible implementations. Check the [supported-features documentation](https://cryptoexchange.jkorf.dev/docs/crypto-clients/supported-features) or use the runtime discovery APIs before assuming an operation is universally available.

## Unified API quick start

Install the package:

```bash
dotnet add package CryptoClients.Net
```

Create one aggregate client and request the same ticker from multiple exchanges:

```csharp
using CryptoClients.Net;
using CryptoClients.Net.Enums;
using CryptoExchange.Net.SharedApis;

var client = new ExchangeRestClient();
var symbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");

var results = await client.GetSpotTickerAsync(
    new GetTickerRequest(symbol),
    [Exchange.Binance, Exchange.Bybit, Exchange.HyperLiquid, Exchange.OKX]);

foreach (var result in results)
{
    Console.WriteLine(result.Success
        ? $"{result.Exchange}: {result.Data.LastPrice}"
        : $"{result.Exchange} error: {result.Error}");
}
```

The package exposes three complementary API layers:

|Layer|Use when|Example|
|--|--|--|
|Aggregate unified API|Calling one or many exchanges with the same request|`client.GetSpotTickerAsync(request, exchanges)`|
|Shared client interface|Writing reusable exchange-agnostic components|`client.GetSpotTickerClient(Exchange.Binance)`|
|Direct exchange client|Using exchange-specific endpoints, options, or models|`client.Binance.SpotApi.ExchangeData`|

### Important behavior

- Aggregate calls return one result per compatible exchange. One exchange can fail while the others succeed, so check `Success` before accessing `Data` on every result.
- A call without an explicit exchange list targets all enabled implementations that support that operation and trading mode. Use `Get...Clients()` and `Discover()` to inspect support at runtime.
- Use `SharedSymbol` instead of hard-coded native symbol formats in shared APIs. `SharedSymbol.UsdOrStable` can route across USD and supported stable-coin quote variants; fetched symbol catalogs provide exchange-specific availability.
- Public market-data operations do not require credentials. Private account and trading operations do, and some exchanges require additional values such as a passphrase.
- Reuse aggregate clients or register them with dependency injection. Do not create a new client for every request.
- Close WebSocket subscriptions and stop order books and trackers during shutdown.

## Features

- Full access to exchange-specific APIs through `ExchangeRestClient` and `ExchangeSocketClient`
- Shared exchange-agnostic interfaces for spot and futures functionality
- Request data from a single exchange or many exchanges in one call
- Subscribe to one or many data streams on multiple exchanges through a single API
- Strongly typed models and enum mappings
- Automatic WebSocket (re)connection management
- Client-side rate limiting
- Client-side order book support, including `ICrossExchangeBook` for aggregated books across exchanges
- Multi-user client management
- Support for multiple API environments
- Dynamic credential management

## Client setup

There are two main entry points:

- `ExchangeRestClient` for REST APIs
- `ExchangeSocketClient` for WebSocket APIs

You can also use exchange-specific clients directly, such as `BinanceRestClient` or `KucoinSocketClient`.

### Dependency injection

    // Load options from configuration
    builder.Services.AddCryptoClients(builder.Configuration.GetSection("CryptoClients"));

    // Or configure in code
    builder.Services.AddCryptoClients(options =>
    {
        options.OutputOriginalData = true;
    });

    // Inject later
    public class TradingBot
    {
        public TradingBot(IExchangeRestClient restClient, IExchangeSocketClient socketClient)
        {
        }
    }

### Direct construction

    IExchangeRestClient restClient = new ExchangeRestClient();
    IExchangeSocketClient socketClient = new ExchangeSocketClient();

    IBinanceRestClient binanceRestClient = new BinanceRestClient();
    IKucoinSocketClient kucoinSocketClient = new KucoinSocketClient();

## Configuration

Clients can be configured globally, per exchange, or both.

> The credentials below are placeholders. Never commit real API credentials to source control; load them from a secure secret store or environment-backed configuration.

    builder.Services.AddCryptoClients(globalOptions =>
    {
        globalOptions.OutputOriginalData = true;
        // Specify enabled exchanges when only using a subset to reduce overhead.
        // Leave default to enable all exchanges
        globalOptions.EnabledExchanges = [Exchange.Binance, Exchange.Bybit, Exchange.OKX];
        globalOptions.ApiCredentials = new ExchangeCredentials
        {
            Binance = new BinanceCredentials("BinanceKey", "BinanceSecret"),
            OKX = new OKXCredentials("OKXKey", "OKXSecret", "OKXPassphrase")
        };
    },
    bybitRestOptions: bybitOptions =>
    {
        bybitOptions.Environment = Bybit.Net.BybitEnvironment.Eu;
        bybitOptions.ApiCredentials = new BybitCredentials("BybitKey", "BybitSecret");
    });

Environment selection can also be configured through `GlobalExchangeOptions.ApiEnvironments`.

Exchange clients and related factories are initialized on first use. `EnabledExchanges` limits runtime initialization and aggregate routing; it does not remove the bundled NuGet dependencies. Aggregate operations only include enabled exchanges, and accessing a disabled strongly typed exchange property throws an `InvalidOperationException`.

More configuration details are available in the documentation:  
https://cryptoexchange.jkorf.dev/docs/crypto-clients/options

## WebSocket subscriptions

The socket client supports single-exchange and multi-exchange subscriptions. Each exchange returns its own subscription result; close successful subscriptions during shutdown.

```csharp
var socketClient = new ExchangeSocketClient();
var symbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");

var subscriptions = await socketClient.SubscribeToTickerUpdatesAsync(
    new SubscribeTickerRequest(symbol),
    data => Console.WriteLine($"{data.Exchange} {data.Data.Symbol} {data.Data.LastPrice}"),
    [Exchange.Binance, Exchange.OKX]);

foreach (var subscription in subscriptions)
{
    if (!subscription.Success)
        Console.WriteLine($"{subscription.Exchange} subscription failed: {subscription.Error}");
}

// On shutdown, close every subscription and connection owned by this client.
await socketClient.UnsubscribeAllAsync();
```

## Cross-exchange order books

Use `IExchangeOrderBookFactory.CreateCrossExchange` to create an `ICrossExchangeBook` which aggregates locally synced order books for the same symbol across multiple exchanges into a single book.

```csharp
var symbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");
var book = orderBookFactory.CreateCrossExchange(
    symbol,
    exchanges: [Exchange.Binance, Exchange.Bybit, Exchange.OKX]);

var startResult = await book.StartAsync();
if (!startResult.Success)
    Console.WriteLine($"Failed to start order book: {startResult.Error}");

// On shutdown:
await book.StopAsync();
```

## Multiple users

Use `ExchangeUserClientProvider` when working with multiple users and isolated client instances.

    var provider = new ExchangeUserClientProvider();
    var user1Credentials = new ExchangeCredentials
    {
        Binance = new BinanceCredentials("key", "secret")
    };
    var user2Credentials = new ExchangeCredentials
    {
        Binance = new BinanceCredentials("key", "secret")
    };

    var restClientUser1 = provider.GetRestClient("user-1", user1Credentials);
    var restClientUser2 = provider.GetRestClient("user-2", user2Credentials);
    var socketClientUser1 = provider.GetSocketClient("user-1");

## Supported target frameworks

The package targets `.NET Standard 2.0`, `.NET Standard 2.1`, `.NET 8.0`, `.NET 9.0`, and `.NET 10.0`. See the [NuGet package](https://www.nuget.org/packages/CryptoClients.Net) for computed framework compatibility.

## Available client libraries

Installing `CryptoClients.Net` includes the following 32 client libraries. Every exchange client is available through the strongly typed properties on `ExchangeRestClient` and, where supported, `ExchangeSocketClient`; the unified API can address the 30 exchanges through the `Exchange` identifiers. Inclusion does not mean that every Shared API operation is supported—see [supported features and capability discovery](https://cryptoexchange.jkorf.dev/docs/crypto-clients/supported-features).

||Platform|Type|Included client library|
|--|--|--|--|
|<img src="https://raw.githubusercontent.com/JKorf/Aster.Net/refs/heads/main/Aster.Net/Icon/icon.png" alt="Aster" width="32" />|Aster|DEX|[Jkorf.Aster.Net](https://www.nuget.org/packages/Jkorf.Aster.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Binance.Net/refs/heads/master/Binance.Net/Icon/icon.png" alt="Binance" width="32" />|Binance|CEX|[Binance.Net](https://www.nuget.org/packages/Binance.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/BingX.Net/refs/heads/main/BingX.Net/Icon/BingX.png" alt="BingX" width="32" />|BingX|CEX|[JK.BingX.Net](https://www.nuget.org/packages/JK.BingX.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Bitfinex.Net/refs/heads/master/Bitfinex.Net/Icon/icon.png" alt="Bitfinex" width="32" />|Bitfinex|CEX|[Bitfinex.Net](https://www.nuget.org/packages/Bitfinex.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Bitget.Net/refs/heads/main/Bitget.Net/Icon/icon.png" alt="Bitget" width="32" />|Bitget|CEX|[JK.Bitget.Net](https://www.nuget.org/packages/JK.Bitget.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/BitMart.Net/refs/heads/main/BitMart.Net/Icon/icon.png" alt="BitMart" width="32" />|BitMart|CEX|[BitMart.Net](https://www.nuget.org/packages/BitMart.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/BitMEX.Net/refs/heads/main/BitMEX.Net/Icon/icon.png" alt="BitMEX" width="32" />|BitMEX|CEX|[JKorf.BitMEX.Net](https://www.nuget.org/packages/JKorf.BitMEX.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Bitstamp.Net/refs/heads/main/Bitstamp.Net/Icon/icon.png" alt="Bitstamp" width="32" />|Bitstamp|CEX|[Bitstamp.Net](https://www.nuget.org/packages/Bitstamp.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/BloFin.Net/refs/heads/main/BloFin.Net/Icon/icon.png" alt="BloFin" width="32" />|BloFin|CEX|[BloFin.Net](https://www.nuget.org/packages/BloFin.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Bybit.Net/refs/heads/main/ByBit.Net/Icon/icon.png" alt="Bybit" width="32" />|Bybit|CEX|[Bybit.Net](https://www.nuget.org/packages/Bybit.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Coinbase.Net/refs/heads/main/Coinbase.Net/Icon/icon.png" alt="Coinbase" width="32" />|Coinbase|CEX|[JKorf.Coinbase.Net](https://www.nuget.org/packages/JKorf.Coinbase.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/CoinEx.Net/refs/heads/master/CoinEx.Net/Icon/icon.png" alt="CoinEx" width="32" />|CoinEx|CEX|[CoinEx.Net](https://www.nuget.org/packages/CoinEx.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/CoinGecko.Net/refs/heads/main/CoinGecko.Net/Icon/icon.png" alt="CoinGecko" width="32" />|CoinGecko|Market data|[CoinGecko.Net](https://www.nuget.org/packages/CoinGecko.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/CoinW.Net/refs/heads/main/CoinW.Net/Icon/icon.png" alt="CoinW" width="32" />|CoinW|CEX|[CoinW.Net](https://www.nuget.org/packages/CoinW.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/CryptoCom.Net/refs/heads/main/CryptoCom.Net/Icon/icon.png" alt="Crypto.com" width="32" />|Crypto.com|CEX|[CryptoCom.Net](https://www.nuget.org/packages/CryptoCom.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/DeepCoin.Net/refs/heads/main/DeepCoin.Net/Icon/icon.png" alt="DeepCoin" width="32" />|DeepCoin|CEX|[DeepCoin.Net](https://www.nuget.org/packages/DeepCoin.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/GateIo.Net/refs/heads/main/GateIo.Net/Icon/icon.png" alt="Gate.io" width="32" />|Gate.io|CEX|[GateIo.Net](https://www.nuget.org/packages/GateIo.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/HTX.Net/refs/heads/master/HTX.Net/Icon/icon.png" alt="HTX" width="32" />|HTX|CEX|[JKorf.HTX.Net](https://www.nuget.org/packages/JKorf.HTX.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/HyperLiquid.Net/refs/heads/main/HyperLiquid.Net/Icon/icon.png" alt="HyperLiquid" width="32" />|HyperLiquid|DEX|[HyperLiquid.Net](https://www.nuget.org/packages/HyperLiquid.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Kraken.Net/refs/heads/master/Kraken.Net/Icon/icon.png" alt="Kraken" width="32" />|Kraken|CEX|[KrakenExchange.Net](https://www.nuget.org/packages/KrakenExchange.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Kucoin.Net/refs/heads/master/Kucoin.Net/Icon/icon.png" alt="Kucoin" width="32" />|Kucoin|CEX|[Kucoin.Net](https://www.nuget.org/packages/Kucoin.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/LBank.Net/refs/heads/main/LBank.Net/Icon/icon.png" alt="LBank" width="32" />|LBank|CEX|[LBank.Net](https://www.nuget.org/packages/LBank.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Lighter.Net/refs/heads/main/Lighter.Net/Icon/icon.png" alt="Lighter" width="32" />|Lighter|DEX|[JKorf.Lighter.Net](https://www.nuget.org/packages/JKorf.Lighter.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Mexc.Net/refs/heads/main/Mexc.Net/Icon/icon.png" alt="Mexc" width="32" />|Mexc|CEX|[JK.Mexc.Net](https://www.nuget.org/packages/JK.Mexc.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/OKX.Net/refs/heads/main/OKX.Net/Icon/icon.png" alt="OKX" width="32" />|OKX|CEX|[JK.OKX.Net](https://www.nuget.org/packages/JK.OKX.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Pionex.Net/refs/heads/main/Pionex.Net/Icon/icon.png" alt="Pionex" width="32" />|Pionex|CEX|[Pionex.Net](https://www.nuget.org/packages/Pionex.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Polymarket.Net/refs/heads/main/Polymarket.Net/Icon/icon.png" alt="Polymarket" width="32" />|Polymarket|Prediction market|[Polymarket.Net](https://www.nuget.org/packages/Polymarket.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Toobit.Net/refs/heads/main/Toobit.Net/Icon/icon.png" alt="Toobit" width="32" />|Toobit|CEX|[Toobit.Net](https://www.nuget.org/packages/Toobit.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Upbit.Net/refs/heads/main/Upbit.Net/Icon/icon.png" alt="Upbit" width="32" />|Upbit|CEX|[JKorf.Upbit.Net](https://www.nuget.org/packages/JKorf.Upbit.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/Weex.Net/refs/heads/main/Weex.Net/Icon/icon.png" alt="Weex" width="32" />|Weex|CEX|[Weex.Net](https://www.nuget.org/packages/Weex.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/WhiteBit.Net/refs/heads/main/WhiteBit.Net/Icon/icon.png" alt="WhiteBit" width="32" />|WhiteBit|CEX|[WhiteBit.Net](https://www.nuget.org/packages/WhiteBit.Net)|
|<img src="https://raw.githubusercontent.com/JKorf/XT.Net/refs/heads/main/XT.Net/Icon/icon.png" alt="XT" width="32" />|XT|CEX|[XT.Net](https://www.nuget.org/packages/XT.Net)|

### Metadata and discovery

Use `Exchange.All` for the string identifiers accepted by aggregate operations, `Exchanges.All` for rich exchange metadata, and `Platforms.All` for exchange metadata plus additional integrations such as CoinGecko and Polymarket.

## Example API

The following ASP.NET Core Minimal API exposes a safe single-exchange endpoint backed by the unified ticker interface:

```csharp
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCryptoClients();

var app = builder.Build();

app.MapGet("Ticker/{exchange}/{baseAsset}/{quoteAsset}",
    async (IExchangeRestClient client, string exchange, string baseAsset, string quoteAsset) =>
    {
        var spotClient = client.GetSpotTickerClient(exchange);
        if (spotClient is null || !spotClient.GetSpotTickerOptions.Supported)
            return Results.NotFound($"Spot ticker requests are not supported for '{exchange}'.");

        var result = await spotClient.GetSpotTickerAsync(
            new GetTickerRequest(new SharedSymbol(TradingMode.Spot, baseAsset, quoteAsset)));

        return result.Success
            ? Results.Ok(result.Data)
            : Results.Problem(result.Error?.ToString(), statusCode: StatusCodes.Status502BadGateway);
    });

app.Run();
```

Example requests are `GET /Ticker/Kraken/ETH/BTC` and `GET /Ticker/Kucoin/BTC/USDT`.

## AI / LLM documentation

CryptoClients.Net includes AI-oriented documentation and examples for code generation tools:

|File|Purpose|
|--|--|
|[`AGENTS.md`](https://github.com/JKorf/CryptoClients.Net/blob/main/AGENTS.md)|Assistant skill with core CryptoClients.Net patterns, pitfalls, and examples|
|[`llms.txt`](https://github.com/JKorf/CryptoClients.Net/blob/main/llms.txt)|Short LLM index with links to docs, examples, and critical usage rules|
|[`llms-full.txt`](https://github.com/JKorf/CryptoClients.Net/blob/main/llms-full.txt)|Detailed LLM context with aggregate REST, WebSocket, direct-client, credential, order book, and tracker guidance|
|[`docs/ai-api-map.md`](https://github.com/JKorf/CryptoClients.Net/blob/main/docs/ai-api-map.md)|Table-style intent-to-method map for aggregate/shared APIs, direct exchange access, sockets, credentials, order books, and trackers|
|[`Examples/ai-friendly`](https://github.com/JKorf/CryptoClients.Net/tree/main/Examples/ai-friendly)|Compilable single-file examples for common aggregate REST, WebSocket, direct-client, order book, tracker, and error handling workflows|

See [cryptoexchange-skills-hub](https://github.com/JKorf/cryptoexchange-skills-hub) for installable skills.

## Resources

- [Usage guide](https://cryptoexchange.jkorf.dev/docs/crypto-clients/usage)
- [Configuration and options](https://cryptoexchange.jkorf.dev/docs/crypto-clients/options)
- [Examples](https://cryptoexchange.jkorf.dev/docs/crypto-clients/examples)
- [AI-friendly examples](https://github.com/JKorf/CryptoClients.Net/tree/main/Examples/ai-friendly)
- [Shared API documentation](https://cryptoexchange.jkorf.dev/docs/shared-api)
- [Supported platforms, features, and capability discovery](https://cryptoexchange.jkorf.dev/docs/crypto-clients/supported-features)
- [CryptoClients.Net versus CCXT benchmark](https://github.com/JKorf/CryptoClients.Net/blob/main/docs/crypto-clients-net-benchmark.md)
- [CryptoManager.Net demo application](https://github.com/JKorf/CryptoManager.Net)

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
|BitMart|CEX|[Link](https://www.bitmart.com/invite/JKorfAPI/en-US)|30%|
|BitMEX|CEX|[Link](https://www.bitmex.com/app/register/94f98e)|30%|
|Bybit|CEX|[Link](https://partner.bybit.com/b/jkorf)|-|
|Coinbase|CEX|[Link](https://advanced.coinbase.com/join/T6H54H8)|-|
|CoinEx|CEX|[Link](https://www.coinex.com/register?rc=rbtnp)|20%|
|CoinW|CEX|[Link](https://www.coinw.com/en_US/register?r=3912706)|-|
|Crypto.com|CEX|[Link](https://crypto.com/exch/26ge92xbkn)|-|
|DeepCoin|CEX|[Link](https://s.deepcoin.com/jddhfca)|-|
|Gate.io|CEX|[Link](https://www.gate.io/share/JKorf)|20%|
|HTX|CEX|[Link](https://www.htx.com/invite/en-us/1f?invite_code=ekek5223)|30%|
|HyperLiquid|DEX|[Link](https://app.hyperliquid.xyz/join/JKORF)|4%|
|Kucoin|CEX|[Link](https://www.kucoin.com/r/rf/QBS4FPED)|-|
|OKX|CEX|[Link](https://www.okx.com/join/14592495)|20%|
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
