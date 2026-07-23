# ![CryptoClients.Net](https://github.com/JKorf/CryptoClients.Net/blob/a1b8acedaabeb8366372180384a286dd3dc63a09/CryptoClients.Net/Icon/icon.png) CryptoClients.Net

[![.NET](https://img.shields.io/github/actions/workflow/status/JKorf/CryptoClients.Net/dotnet.yml?style=for-the-badge)](https://github.com/JKorf/CryptoClients.Net/actions/workflows/dotnet.yml)
[![NuGet version](https://img.shields.io/nuget/v/CryptoClients.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net)
[![NuGet downloads](https://img.shields.io/nuget/dt/CryptoClients.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net)
![License](https://img.shields.io/github/license/JKorf/CryptoClients.Net?style=for-the-badge)

`CryptoClients.Net` provides unified access to cryptocurrency trading APIs in C#.

It combines:
- direct access to exchange-specific REST and WebSocket clients
- shared cross-exchange interfaces from [CryptoExchange.Net](https://jkorf.github.io/CryptoExchange.Net/)
- dynamic multi-exchange requests and subscriptions
- client-side helpers such as rate limiting, order books, trackers, and user client management

The library currently supports **28 exchanges** and additional platform integrations such as **CoinGecko** and **Polymarket**.

## Features

- Full access to exchange-specific APIs through `ExchangeRestClient` and `ExchangeSocketClient`
- Shared exchange-agnostic interfaces for spot and futures functionality
- Request data from a single exchange or many exchanges in one call
- Subscribe to one or many data streams on multiple exchanges through a single API
- Strongly typed models and enum mappings
- Automatic WebSocket (re)connection management
- Client-side rate limiting
- Client-side order book support, including `(I)CrossExchangeBook` for aggregated books across exchanges
- Multi-user client management
- Support for multiple API environments
- Dynamic credential management

## Benchmark
Performance is a core focus. For a benchmark comparing CryptoClients.Net performance to CCXT, see [docs/crypto-clients-net-benchmark.md](docs/crypto-clients-net-benchmark.md).

## Quick example

    var client = new ExchangeRestClient();
    var symbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");

    var results = await client.GetSpotTickerAsync(
        new GetTickerRequest(symbol),
        ["Binance", "Bybit", "HyperLiquid", "OKX"]);

    foreach (var result in results)
    {
        if (!result.Success)
            Console.WriteLine($"{result.Exchange} error: {result.Error}");
        else
            Console.WriteLine($"{result.Exchange} price: {result.Data.LastPrice}");
    }

For more examples, see the [documentation](https://cryptoexchange.jkorf.dev/crypto-clients) or the full demo application:  
https://github.com/JKorf/CryptoManager.Net

## Installation

### NuGet

    dotnet add package CryptoClients.Net

### GitHub Packages

`CryptoClients.Net` is also available on [GitHub Packages](https://github.com/JKorf/CryptoClients.Net/pkgs/nuget/CryptoClients.Net).

Add the following NuGet source:

    https://nuget.pkg.github.com/JKorf/index.json

### Download release

Latest releases are available here:  
https://github.com/JKorf/CryptoClients.Net/releases

## Getting started

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

    builder.Services.AddCryptoClients(globalOptions =>
    {
        globalOptions.OutputOriginalData = true;
        globalOptions.ApiCredentials = new ExchangeCredentials
        {
            Binance = new BinanceCredentials("BinanceKey", "BinanceSecret"),
            Kucoin = new KucoinCredentials("KucoinKey", "KucoinSecret", "KucoinPassphrase"),
            OKX = new OKXCredentials("OKXKey", "OKXSecret", "OKXPassphrase")
        };
    },
    bybitRestOptions: bybitOptions =>
    {
        bybitOptions.Environment = Bybit.Net.BybitEnvironment.Eu;
        bybitOptions.ApiCredentials = new BybitCredentials("BybitKey", "BybitSecret");
    });

Environment selection can also be configured through `GlobalExchangeOptions.ApiEnvironments`.

More configuration details are available in the documentation:  
https://cryptoexchange.jkorf.dev/crypto-clients/options

## Usage patterns

### 1. Exchange-specific clients

Use the exchange libraries directly when full exchange-specific functionality is needed.

    var kucoinClient = new KucoinRestClient();
    var binanceClient = new BinanceRestClient();

    var binanceTicker = await binanceClient.SpotApi.ExchangeData.GetTickerAsync("ETHUSDT");
    var kucoinTicker = await kucoinClient.SpotApi.ExchangeData.GetTickerAsync("ETH-USDT");

### 2. Exchange clients through the main client

Use `ExchangeRestClient` or `ExchangeSocketClient` as a single entry point.

    var client = new ExchangeRestClient();

    var binanceTicker = await client.Binance.SpotApi.ExchangeData.GetTickerAsync("ETHUSDT");
    var kucoinTicker = await client.Kucoin.SpotApi.ExchangeData.GetTickerAsync("ETH-USDT");

### 3. Shared client interfaces

Use shared interfaces for exchange-agnostic logic.

    async Task<HttpResult<SharedSpotTicker>> GetTickerAsync(ISpotTickerRestClient client, SharedSymbol symbol)
        => await client.GetSpotTickerAsync(new GetTickerRequest(symbol));

    var client = new ExchangeRestClient();
    var symbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");

    var binanceResult = await GetTickerAsync(client.Binance.SpotApi.SharedClient, symbol);
    var kucoinResult = await GetTickerAsync(client.Kucoin.SpotApi.SharedClient, symbol);

### 4. Multi-exchange requests

Request the same data from multiple exchanges in one call.

    var client = new ExchangeRestClient();
    var symbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");

    var tickers = await client.GetSpotTickerAsync(
        new GetTickerRequest(symbol),
        [Exchange.Binance, Exchange.Kucoin, Exchange.OKX]);

## WebSocket subscriptions

The socket client also supports single-exchange and multi-exchange subscriptions.

    var socketClient = new ExchangeSocketClient();
    var symbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");

    var subscriptions = await socketClient.SubscribeToTickerUpdatesAsync(
        new SubscribeTickerRequest(symbol),
        data => Console.WriteLine($"{data.Data.Symbol} {data.Data.LastPrice}"),
        [Exchange.Binance, Exchange.OKX]);

## Cross-exchange order books

Use `IExchangeOrderBookFactory.CreateCrossExchange` to create an `(I)CrossExchangeBook` which aggregates locally synced order books for the same symbol across multiple exchanges into a single book.

    var symbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");
    var book = orderBookFactory.CreateCrossExchange(
        symbol,
        exchanges: [Exchange.Binance, Exchange.Bybit, Exchange.OKX]);

    await book.StartAsync();

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

The package targets:

- `.NET Standard 2.0`
- `.NET Standard 2.1`
- `.NET 8.0`
- `.NET 9.0`
- `.NET 10.0`

Compatibility includes:

| .NET implementation | Version support |
|--|--|
| .NET Core | `2.0` and higher |
| .NET Framework | `4.6.1` and higher |
| Mono | `5.4` and higher |
| Xamarin.iOS | `10.14` and higher |
| Xamarin.Android | `8.0` and higher |
| UWP | `10.0.16299` and higher |
| Unity | `2018.1` and higher |

## Supported exchanges

### Centralized exchanges

`Binance`, `BingX`, `Bitfinex`, `Bitget`, `BitMart`, `BitMEX`, `Bitstamp`, `BloFin`, `Bybit`, `Coinbase`, `CoinEx`, `CoinW`, `Crypto.com`, `DeepCoin`, `GateIo`, `HTX`, `Kraken`, `Kucoin`, `Mexc`, `OKX`, `Toobit`, `Upbit`, `Weex`, `WhiteBit`, `XT`

### Decentralized exchanges

`Aster`, `HyperLiquid`

### Additional platform integrations

`CoinGecko`, `Polymarket`

### Referral links

||Exchange|Type|Referral Link|Referral Fee Discount|
|--|--|--|--|--|
|![Aster](https://raw.githubusercontent.com/JKorf/Aster.Net/refs/heads/main/Aster.Net/Icon/icon.png)|Aster|DEX|[Link](https://www.asterdex.com/en/referral/FD2E11)|4%|
|![Binance](https://raw.githubusercontent.com/JKorf/Binance.Net/refs/heads/master/Binance.Net/Icon/icon.png)|Binance|CEX|[Link](https://accounts.binance.com/register?ref=X5K3F2ZG)|20%|
|![BingX](https://raw.githubusercontent.com/JKorf/BingX.Net/refs/heads/main/BingX.Net/Icon/BingX.png)|BingX|CEX|[Link](https://bingx.com/invite/FFHRJKWG/)|20%|
|![Bitfinex](https://raw.githubusercontent.com/JKorf/Bitfinex.Net/refs/heads/master/Bitfinex.Net/Icon/icon.png)|Bitfinex|CEX|-|-|
|![Bitget](https://raw.githubusercontent.com/JKorf/Bitget.Net/refs/heads/main/Bitget.Net/Icon/icon.png)|Bitget|CEX|[Link](https://partner.bitget.com/bg/1qlf6pj1)|20%|
|![BitMart](https://raw.githubusercontent.com/JKorf/BitMart.Net/refs/heads/main/BitMart.Net/Icon/icon.png)|BitMart|CEX|[Link](https://www.bitmart.com/invite/JKorfAPI/en-US)|30%|
|![BitMEX](https://raw.githubusercontent.com/JKorf/BitMEX.Net/refs/heads/main/BitMEX.Net/Icon/icon.png)|BitMEX|CEX|[Link](https://www.bitmex.com/app/register/94f98e)|30%|
|![Bitstamp](https://raw.githubusercontent.com/JKorf/Bitstamp.Net/refs/heads/main/Bitstamp.Net/Icon/icon.png)|Bitstamp|CEX|-|-|
|![BloFin](https://raw.githubusercontent.com/JKorf/BloFin.Net/refs/heads/main/BloFin.Net/Icon/icon.png)|BloFin|CEX|-|-|
|![Bybit](https://raw.githubusercontent.com/JKorf/Bybit.Net/refs/heads/main/ByBit.Net/Icon/icon.png)|Bybit|CEX|[Link](https://partner.bybit.com/b/jkorf)|-|
|![Coinbase](https://raw.githubusercontent.com/JKorf/Coinbase.Net/refs/heads/main/Coinbase.Net/Icon/icon.png)|Coinbase|CEX|[Link](https://advanced.coinbase.com/join/T6H54H8)|-|
|![CoinEx](https://raw.githubusercontent.com/JKorf/CoinEx.Net/refs/heads/master/CoinEx.Net/Icon/icon.png)|CoinEx|CEX|[Link](https://www.coinex.com/register?rc=rbtnp)|20%|
|![CoinW](https://raw.githubusercontent.com/JKorf/CoinW.Net/refs/heads/main/CoinW.Net/Icon/icon.png)|CoinW|CEX|[Link](https://www.coinw.com/en_US/register?r=3912706)|-|
|![CoinGecko](https://raw.githubusercontent.com/JKorf/CoinGecko.Net/refs/heads/main/CoinGecko.Net/Icon/icon.png)|CoinGecko|-|-|-|
|![Crypto.com](https://raw.githubusercontent.com/JKorf/CryptoCom.Net/refs/heads/main/CryptoCom.Net/Icon/icon.png)|Crypto.com|CEX|[Link](https://crypto.com/exch/26ge92xbkn)|-|
|![DeepCoin](https://raw.githubusercontent.com/JKorf/DeepCoin.Net/refs/heads/main/DeepCoin.Net/Icon/icon.png)|DeepCoin|CEX|[Link](https://s.deepcoin.com/jddhfca)|-|
|![Gate.io](https://raw.githubusercontent.com/JKorf/GateIo.Net/refs/heads/main/GateIo.Net/Icon/icon.png)|Gate.io|CEX|[Link](https://www.gate.io/share/JKorf)|20%|
|![HTX](https://raw.githubusercontent.com/JKorf/HTX.Net/refs/heads/master/HTX.Net/Icon/icon.png)|HTX|CEX|[Link](https://www.htx.com/invite/en-us/1f?invite_code=ekek5223)|30%|
|![HyperLiquid](https://raw.githubusercontent.com/JKorf/HyperLiquid.Net/refs/heads/main/HyperLiquid.Net/Icon/icon.png)|HyperLiquid|DEX|[Link](https://app.hyperliquid.xyz/join/JKORF)|4%|
|![Kraken](https://raw.githubusercontent.com/JKorf/Kraken.Net/refs/heads/master/Kraken.Net/Icon/icon.png)|Kraken|CEX|-|-|
|![Kucoin](https://raw.githubusercontent.com/JKorf/Kucoin.Net/refs/heads/master/Kucoin.Net/Icon/icon.png)|Kucoin|CEX|[Link](https://www.kucoin.com/r/rf/QBS4FPED)|-|
|![Mexc](https://raw.githubusercontent.com/JKorf/Mexc.Net/refs/heads/main/Mexc.Net/Icon/icon.png)|Mexc|CEX|-|-|
|![OKX](https://raw.githubusercontent.com/JKorf/OKX.Net/refs/heads/main/OKX.Net/Icon/icon.png)|OKX|CEX|[Link](https://www.okx.com/join/14592495)|20%|
|![Toobit](https://raw.githubusercontent.com/JKorf/Toobit.Net/refs/heads/main/Toobit.Net/Icon/icon.png)|Toobit|CEX|[Link](https://www.toobit.com/en-US/register?invite_code=zsV19h)|-|
|![Upbit](https://raw.githubusercontent.com/JKorf/Upbit.Net/refs/heads/main/Upbit.Net/Icon/icon.png)|Upbit|CEX|-|-|
|![Weex](https://raw.githubusercontent.com/JKorf/Weex.Net/refs/heads/main/Weex.Net/Icon/icon.png)|Weex|CEX|-|-|
|![WhiteBit](https://raw.githubusercontent.com/JKorf/WhiteBit.Net/refs/heads/main/WhiteBit.Net/Icon/icon.png)|WhiteBit|CEX|[Link](https://whitebit.com/referral/a8e59b59-186c-4662-824c-3095248e0edf)|-|
|![XT](https://raw.githubusercontent.com/JKorf/XT.Net/refs/heads/main/XT.Net/Icon/icon.png)|XT|CEX|[Link](https://www.xt.com/ru/accounts/register?ref=CZG39C)|25%|

### Metadata and discovery

Use:
- `Exchanges.All` for supported exchanges
- `Platforms.All` for supported exchanges and additional platforms

## Example API

The following minimal API exposes a cross-exchange ticker endpoint:

    using CryptoClients.Net.Interfaces;
    using CryptoExchange.Net.Objects;
    using CryptoExchange.Net.SharedApis;
    using Microsoft.AspNetCore.Mvc;

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddCryptoClients();

    var app = builder.Build();

    app.MapGet("Ticker/{exchange}/{baseAsset}/{quoteAsset}",
        async ([FromServices] IExchangeRestClient client, string exchange, string baseAsset, string quoteAsset) =>
        {
            var spotClient = client.GetSpotTickerClient(exchange)!;
            var result = await spotClient.GetSpotTickerAsync(
                new GetTickerRequest(new SharedSymbol(TradingMode.Spot, baseAsset, quoteAsset)));

            return result.Data;
        });

    app.Run();

Example requests:
- `GET /Ticker/Kraken/ETH/BTC`
- `GET /Ticker/Kucoin/BTC/USDT`

## Documentation and examples

- Documentation: https://cryptoexchange.jkorf.dev/crypto-clients
- Benchmark results: [docs/crypto-clients-net-benchmark.md](docs/crypto-clients-net-benchmark.md)
- Configuration options: https://cryptoexchange.jkorf.dev/crypto-clients/options
- Example configuration: https://github.com/JKorf/CryptoClients.Net/tree/main/Examples/example-config.json
- Examples: https://github.com/JKorf/CryptoClients.Net/tree/main/Examples
- Base library examples: https://github.com/JKorf/CryptoExchange.Net/tree/master/Examples
- Demo application: https://github.com/JKorf/CryptoManager.Net

## AI / LLM documentation

CryptoClients.Net includes AI-oriented documentation and examples for code generation tools:

|File|Purpose|
|--|--|
|[`AGENTS.md`](AGENTS.md)|Assistant skill with core CryptoClients.Net patterns, pitfalls, and examples|
|[`llms.txt`](llms.txt)|Short LLM index with links to docs, examples, and critical usage rules|
|[`llms-full.txt`](llms-full.txt)|Detailed LLM context with aggregate REST, WebSocket, direct-client, credential, order book, and tracker guidance|
|[`docs/ai-api-map.md`](docs/ai-api-map.md)|Table-style intent-to-method map for aggregate/shared APIs, direct exchange access, sockets, credentials, order books, and trackers|
|[`Examples/ai-friendly`](Examples/ai-friendly)|Compilable single-file examples for common aggregate REST, WebSocket, direct-client, order book, tracker, and error handling workflows|

See [cryptoexchange-skills-hub](https://github.com/JKorf/cryptoexchange-skills-hub) for installable skills.

## Support

### Discord

[![Discord](https://img.shields.io/discord/847020490588422145?style=for-the-badge)](https://discord.gg/MSpeEtSY8t)

Join the Discord server for questions and discussion:  
https://discord.gg/MSpeEtSY8t

### Donations

**BTC**: `bc1q277a5n54s2l2mzlu778ef7lpkwhjhyvghuv8qf`  
**ETH**: `0xcb1b63aCF9fef2755eBf4a0506250074496Ad5b7`  
**USDT (TRX)**: `TKigKeJPXZYyMVDgMyXxMf17MWYia92Rjd`

### Sponsorship

https://github.com/sponsors/JKorf

## Release notes
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
