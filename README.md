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

The library currently supports **26 exchanges** and additional platform integrations such as **CoinGecko** and **Polymarket**.

## Features

- Full access to exchange-specific APIs through `ExchangeRestClient` and `ExchangeSocketClient`
- Shared exchange-agnostic interfaces for spot and futures functionality
- Request data from a single exchange or many exchanges in one call
- Subscribe to one or many data streams on multiple exchanges through a single API
- Strongly typed models and enum mappings
- Automatic WebSocket (re)connection management
- Client-side rate limiting
- Client-side order book support
- Multi-user client management
- Support for multiple API environments
- Dynamic credential management

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

    async Task<ExchangeWebResult<SharedSpotTicker>> GetTickerAsync(ISpotTickerRestClient client, SharedSymbol symbol)
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

`Binance`, `BingX`, `Bitfinex`, `Bitget`, `BitMart`, `BitMEX`, `Bitstamp`, `BloFin`, `Bybit`, `Coinbase`, `CoinEx`, `CoinW`, `Crypto.com`, `DeepCoin`, `GateIo`, `HTX`, `Kraken`, `Kucoin`, `Mexc`, `OKX`, `Toobit`, `Upbit`, `WhiteBit`, `XT`

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
- Configuration options: https://cryptoexchange.jkorf.dev/crypto-clients/options
- Example configuration: https://github.com/JKorf/CryptoClients.Net/tree/main/Examples/example-config.json
- Examples: https://github.com/JKorf/CryptoClients.Net/tree/main/Examples
- Base library examples: https://github.com/JKorf/CryptoExchange.Net/tree/master/Examples
- Demo application: https://github.com/JKorf/CryptoManager.Net

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
* Version 4.7.0 - 25 Mar 2026
    * Added CoinGecko to ExchangeRestClient
    * Added coinGeckoRestOptions parameter to ExchangeUserClientProvider constructor
    * Added SetApiCredentials(string, DynamicCredentials) on ExchangeRestClient
    * Added SetApiCredentials(string, DynamicCredentials) on ExchangeSocketClient
    * Split upbitOptions parameter in ExchangeUserClientProvider constructor into upbitRestOptions and upbitSocketOptions
    * Added SetApiCredentials(string, DynamicCredentials) to ExchangeRestClient
    * Added SetApiCredentials(string, DynamicCredentials) to ExchangeSocketClient
    * Marked SetApiCredentials(string exchange, string apiKey, string apiSecret, string? apiPass = null) as obsolete on ExchangeRestClient
    * Marked SetApiCredentials(string exchange, string apiKey, string apiSecret, string? apiPass = null) as obsolete on ExchangeSocketClient
    * Updated ExchangeCredentials to reflect exchange specific ApiCredential types needed in client libraries
    * Removed Dictionary<string, ApiCredentials> constructor overload from ExchangeCredentials
    * Removed Upbit from ExchangeCredentials since authentication is not supported
    * Added ExchangeCredentials.GetDynamicCredentialInfo(TradingMode, string)
    * Added ExchangeCredentials.CreateCredentialsForExchange(string, DynamicCredentials)
    * Added ExchangeCredentials.CreateFrom(Dictionary<string, ApiCredentials>)
    * Added ExchangeCredentials.CreateFrom(string, ApiCredentials)
    * Added DynamicCredentialInfo to ExchangeInfo to retrieve info for an exchange to dynamically create credentials

    * Notes for updating:
        * `ExchangeCredentials` no longer has a constructor which accepts `Dictionary<string, ApiCredentials>`. To dynamically create `ExchangeCredentials` use the `ExchangeCredentials.CreateFrom` static method in combination with `ExchangeCredentials.CreateCredentialsForExchange`.

* Version 4.6.0 - 06 Mar 2026
    * Updated client library versions
    * Added Bitstamp support with the Bitstamp.Net library

* Version 4.5.0 - 25 Feb 2026
    * Updated client library versions
    * Added PageRequest parameter to endpoints supporting pagination using single exchange parameter

* Version 4.4.0 - 16 Feb 2026
    * Updated client library versions

* Version 4.3.0 - 10 Feb 2026
    * Updated client library versions
    * Added user data tracker creation method to (I)ExchangeTrackerFactory
    * Added checks to rest client exchange requests to prevent exception when more than one trading mode specific requests are available for an exchange
    * Added additional methods for requesting supported symbols to Shared ISpotSymbolRestClient/IFuturesSymbolRestClient interfaces
    * Removed UseUpdatedDeserialization option

* Version 4.2.0 - 22 Jan 2026
    * Updated client library versions
    * Added Polymarket support with the Polymarket.Net library
    * Added static class Platform listing all supported exchange names plus any non-exchange platform names
    * Added static class Platforms listing all supported exchange metadatas plus any non-exchange platform metadata

* Version 4.1.3 - 19 Jan 2026
    * Updated client library versions, fixing some bugs

* Version 4.1.2 - 14 Jan 2026
    * Updated client library versions fixing some bugs

* Version 4.1.1 - 13 Jan 2026
    * Fixed issue with websocket message sequence checking causing reconnects

* Version 4.1.0 - 13 Jan 2026
    * Updated client library versions
    * Added Create method without exchange parameters to create SymbolOrderBook instance on all supported exchanges
    * Fixed GateIo ExchangeOrderBookFactory Perpetual Futures creation when using SharedSymbol.UsdOrStable

* Version 4.0.4 - 19 Dec 2025
    * Updated client library versions fixing some bugs

* Version 4.0.3 - 19 Dec 2025
    * Updated client library versions fixing some bugs

* Version 4.0.2 - 18 Dec 2025
    * Updated client library versions fixing some bugs

* Version 4.0.1 - 17 Dec 2025
    * Updated library versions fixing some bugs

* Version 4.0.0 - 16 Dec 2025
    * Updated client library versions
    * Added Net10.0 target framework
    * Updated CryptoExchange.Net version to 10.0.0, see https://github.com/JKorf/CryptoExchange.Net/releases/ for full release notes
    * Improved performance across the board, biggest gains in websocket message processing
    * Added UseUpdatedDeserialization socket client options to toggle by new and old message handling
    * Updated Shared API's subscription update types from ExchangeEvent to DataEvent
	