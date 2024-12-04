# ![.CryptoClients.Net](https://github.com/JKorf/CryptoClients.Net/blob/a1b8acedaabeb8366372180384a286dd3dc63a09/CryptoClients.Net/Icon/icon.png) CryptoClients.Net  

[![.NET](https://img.shields.io/github/actions/workflow/status/JKorf/CryptoClients.Net/dotnet.yml?style=for-the-badge)](https://github.com/JKorf/CryptoClients.Net/actions/workflows/dotnet.yml) ![License](https://img.shields.io/github/license/JKorf/CryptoClients.Net?style=for-the-badge)

CryptoClients.Net is a collection of different cryptocurrency exchange client libraries based on the same [base library](https://jkorf.github.io/CryptoExchange.Net/). CryptoClients.Net bundles the different client libraries in a single package and adds some additional tools to make use of them.

## Features
* Direct full access to 16 different exchanges, public and private data
* Client per exchange, or single client for accessing all exchanges
* Response data is mapped to descriptive models
* Input parameters and response values are mapped to discriptive enum values where possible
* Automatic websocket (re)connection management 
* Client side rate limiting 
* Client side order book implementation
* Extensive logging
* Support for different environments

For more information on what CryptoExchange.Net and its client libraries offers see the [Documentation](https://jkorf.github.io/CryptoExchange.Net/).

## Supported Frameworks
The library is targeting both `.NET Standard 2.0` and `.NET Standard 2.1` for optimal compatibility

|.NET implementation|Version Support|
|--|--|
|.NET Core|`2.0` and higher|
|.NET Framework|`4.6.1` and higher|
|Mono|`5.4` and higher|
|Xamarin.iOS|`10.14` and higher|
|Xamarin.Android|`8.0` and higher|
|UWP|`10.0.16299` and higher|
|Unity|`2018.1` and higher|

## Supported Exchanges
The following API's are included in CryptoClients.Net:

|Exchange|Repository|Nuget|
|--|--|--|
|Binance|[JKorf/Binance.Net](https://github.com/JKorf/Binance.Net)|[![Nuget version](https://img.shields.io/nuget/v/Binance.net.svg?style=flat-square)](https://www.nuget.org/packages/Binance.Net)|
|BingX|[JKorf/BingX.Net](https://github.com/JKorf/BingX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.BingX.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.BingX.Net)|
|Bitfinex|[JKorf/Bitfinex.Net](https://github.com/JKorf/Bitfinex.Net)|[![Nuget version](https://img.shields.io/nuget/v/Bitfinex.net.svg?style=flat-square)](https://www.nuget.org/packages/Bitfinex.Net)|
|Bitget|[JKorf/Bitget.Net](https://github.com/JKorf/Bitget.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.Bitget.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.Bitget.Net)|
|BitMart|[JKorf/BitMart.Net](https://github.com/JKorf/BitMart.Net)|[![Nuget version](https://img.shields.io/nuget/v/BitMart.net.svg?style=flat-square)](https://www.nuget.org/packages/BitMart.Net)|
|Bybit|[JKorf/Bybit.Net](https://github.com/JKorf/Bybit.Net)|[![Nuget version](https://img.shields.io/nuget/v/Bybit.net.svg?style=flat-square)](https://www.nuget.org/packages/Bybit.Net)|
|Coinbase|[JKorf/Coinbase.Net](https://github.com/JKorf/Coinbase.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.Coinbase.net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.Coinbase.Net)|
|CoinEx|[JKorf/CoinEx.Net](https://github.com/JKorf/CoinEx.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinEx.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinEx.Net)|
|CoinGecko|[JKorf/CoinGecko.Net](https://github.com/JKorf/CoinGecko.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinGecko.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinGecko.Net)|
|Crypto.com|[JKorf/CryptoCom.Net](https://github.com/JKorf/CryptoCom.Net)|[![Nuget version](https://img.shields.io/nuget/v/CryptoCom.net.svg?style=flat-square)](https://www.nuget.org/packages/CryptoCom.Net)|
|Gate.io|[JKorf/GateIo.Net](https://github.com/JKorf/GateIo.Net)|[![Nuget version](https://img.shields.io/nuget/v/GateIo.net.svg?style=flat-square)](https://www.nuget.org/packages/GateIo.Net)|
|HTX|[JKorf/HTX.Net](https://github.com/JKorf/HTX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.HTX.net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.HTX.Net)|
|Kraken|[JKorf/Kraken.Net](https://github.com/JKorf/Kraken.Net)|[![Nuget version](https://img.shields.io/nuget/v/KrakenExchange.net.svg?style=flat-square)](https://www.nuget.org/packages/KrakenExchange.Net)|
|Kucoin|[JKorf/Kucoin.Net](https://github.com/JKorf/Kucoin.Net)|[![Nuget version](https://img.shields.io/nuget/v/Kucoin.net.svg?style=flat-square)](https://www.nuget.org/packages/Kucoin.Net)|
|Mexc|[JKorf/Mexc.Net](https://github.com/JKorf/Mexc.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.Mexc.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.Mexc.Net)|
|OKX|[JKorf/OKX.Net](https://github.com/JKorf/OKX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.OKX.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.OKX.Net)|
|WhiteBit|[JKorf/WhiteBit.Net](https://github.com/JKorf/WhiteBit.Net)|[![Nuget version](https://img.shields.io/nuget/v/WhiteBit.net.svg?style=flat-square)](https://www.nuget.org/packages/WhiteBit.Net)|
|XT|[JKorf/XT.Net](https://github.com/JKorf/XT.Net)|[![Nuget version](https://img.shields.io/nuget/v/XT.net.svg?style=flat-square)](https://www.nuget.org/packages/XT.Net)|

## Install the library

### NuGet 
[![NuGet version](https://img.shields.io/nuget/v/CryptoClients.net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net)  [![Nuget downloads](https://img.shields.io/nuget/dt/CryptoClients.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net)

	dotnet add package CryptoClients.Net
	
### GitHub packages
CryptoClients.Net is available on [GitHub packages](https://github.com/JKorf/CryptoClients.Net/pkgs/nuget/CryptoClients.Net). You'll need to add `https://nuget.pkg.github.com/JKorf/index.json` as a NuGet package source.

### Download release
[![GitHub Release](https://img.shields.io/github/v/release/JKorf/CryptoClients.Net?style=for-the-badge&label=GitHub)](https://github.com/JKorf/CryptoClients.Net/releases)

The NuGet package files are added along side the source with the latest GitHub release which can found [here](https://github.com/JKorf/CryptoClients.Net/releases).

## How to use  
### Get a client
There are 2 main clients, the `ExchangeRestClient` and `ExchangeSocketClient`, for accessing the REST and Websocket API respectively. All exchange API's are available via these clients.  
Alternatively exchange specific clients can be used, for example `BinanceRestClient` or `KucoinSocketClient`.
Either create new clients directly or use Dotnet dependency injection.

*Dependency injection*
```csharp
// Dependency injection, allows the injection of `IExchangeRestClient`, `IExchangeSocketClient`, `IExchangeOrderBookFactory` and `IExchangeTrackerFactory` interfaces
// as well as for all exchanges the `I[ExchangeName]RestClient`, `I[ExchangeName]SocketClient`, `I[ExchangeName]OrderBookFactory` and `I[ExchangeName]TrackerFactory` types
// During service registration in application startup:

// Configure options from config file
// see https://github.com/JKorf/CryptoClients.Net/tree/main/Examples/example-config.json for an example
builder.Services.AddCryptoClients(builder.Configuration.GetSection("CryptoClients"));
		  
// OR
		  
 builder.Services.AddCryptoClients(options => {
  // Configure options in code
  options.OutputOriginalData = true;
});

// Inject the clients later on:
public class TradingBot
{
	public TradingBot(IExchangeRestClient restClient, IExchangeSocketClient socketClient)
	{}
}
```

*Construction*
```csharp
// Client for accessing all exchanges
IExchangeRestClient restClient = new ExchangeRestClient();
IExchangeSocketClient socketClient = new ExchangeSocketClient();

// Exchange specific clients
IBinanceRestClient binanceRestClient = new BinanceRestClient();
IKucoinSocketClient kucoinSocketClient = new KucoinSocketClient();
```

### Configuration
Clients can be configured during the dependency injection registration, or when constructing the clients. Configuration can be done for all exchanges/clients, can be set per exchange or a combination:
```csharp
builder.Services.AddCryptoClients(globalOptions =>
{
    // Global options apply to each exchange/client
    globalOptions.OutputOriginalData = true;
    // Set credentials for the different exchanges, will be applied to both REST and socket clients
    globalOptions.ApiCredentials = new CryptoClients.Net.Models.ExchangeCredentials
    {
        Binance = new ApiCredentials("BinanceKey", "BinanceSecret"),
        Kucoin = new KucoinApiCredentials("KucoinKey", "KucoinSecret", "KucoinPassphrase"),
        OKX = new OKXApiCredentials("OKXKey", "OKXSecret", "OKXPassphrase")
    };
},
bybitRestOptions: bybitOptions =>
{
    // Specify options specifically for a specific exchange and client, in this case the Bybit REST client
    bybitOptions.Environment = Bybit.Net.BybitEnvironment.Netherlands;
    bybitOptions.ApiCredentials = new ApiCredentials("BybitKey", "BybitSecret");
});
```

More info on options available for each client can be found in the [CryptoExchange.Net documentation](https://jkorf.github.io/CryptoExchange.Net/#idocs_options_def).

### Usage
There are multiple ways to access exchange API's. Options 1 and 2 allow access to the full exchange API while option 3 uses a common interface which allows exchange agnostic requesting, but is therefor limited in functionality.  

<b>Option 1</b>  
Using the exchange specific clients directly. This offers full functionality of the exchange API's.
```csharp
var kucoinClient1 = new KucoinRestClient();
var binanceClient1 = new BinanceRestClient();
var binanceResult1 = await binanceClient1.SpotApi.ExchangeData.GetTickerAsync("ETHUSDT");
var kucoinResult1 = await kucoinClient1.SpotApi.ExchangeData.GetTickerAsync("ETH-USDT");
```

<b>Option 2</b>  
Using the exchange clients via the main client, also allows for full functionality of the exchange API's.
```csharp
var restClient2 = new ExchangeRestClient();
var binanceResult2 = await restClient2.Binance.SpotApi.ExchangeData.GetTickerAsync("ETHUSDT");
var kucoinResult2 = await restClient2.Kucoin.SpotApi.ExchangeData.GetTickerAsync("ETH-USDT");
```

<b>Option 3</b>  
Using the shared client interfaces to access exchanges. This is the most generic and exchange agnostic way, but might not support all functionality the full API offers.
```csharp
// Define functionality based on shared interface
async Task<ExchangeWebResult<SharedSpotTicker>> GetTickerAsync(ISpotTickerRestClient client, SharedSymbol symbol)
    => await client.GetSpotTickerAsync(new GetTickerRequest(symbol));
	
// Execute for multiple exchanges
var symbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");
var binanceResult3 = await GetTickerAsync(restClient3.Binance.SpotApi.SharedClient, symbol);
var kucoinResult3 = await GetTickerAsync(restClient3.Kucoin.SpotApi.SharedClient, symbol);
```

<b>Option 4</b>  
Using the shared client interfaces thought the main client. For this the same limitation applies as option 3.
```csharp
var symbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");
var tickers = await restClient.GetSpotTickerAsync(new GetTickerRequest(symbol), [Exchange.Binance, Exchange.Kucoin]);
```

For information on the specific exchange clients, dependency injection, response processing and more see the [CryptoExchange.Net documentation](https://jkorf.github.io/CryptoExchange.Net) or have a look at the examples [here](https://github.com/JKorf/CryptoClients.Net/tree/main/Examples). See the [CryptoExchange.Net examples](https://github.com/JKorf/CryptoExchange.Net/tree/master/Examples) for client examples which also apply to CryptoClients.Net

### Example
An API allowing the requesting of any ticker on any (supported) exchange in 14 lines;  
For example `GET /Ticker/Kraken/ETH/BTC` or `GET /Ticker/Kucoin/BTC/USDT`
```csharp
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Objects;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCryptoClients();
var app = builder.Build();

app.MapGet("Ticker/{exchange}/{baseAsset}/{quoteAsset}", async ([FromServices] IExchangeRestClient client, string exchange, string baseAsset, string quoteAsset) =>
{
    var spotClient = client.GetSpotTickerClient(exchange)!;
    var result = await spotClient.GetSpotTickerAsync(new GetTickerRequest(new SharedSymbol(TradingMode.Spot, baseAsset, quoteAsset)));
    return result.Data;
});

app.Run();
```

## Discord
[![Nuget version](https://img.shields.io/discord/847020490588422145?style=for-the-badge)](https://discord.gg/MSpeEtSY8t)  
A Discord server is available [here](https://discord.gg/MSpeEtSY8t). Feel free to join for discussion and/or questions around the CryptoExchange.Net and implementation libraries.

## Support the project
Any support is greatly appreciated.

### Donate
Make a one time donation in a crypto currency of your choice. If you prefer to donate a currency not listed here please contact me.

**Btc**:  bc1q277a5n54s2l2mzlu778ef7lpkwhjhyvghuv8qf  
**Eth**:  0xcb1b63aCF9fef2755eBf4a0506250074496Ad5b7   
**USDT (TRX)**  TKigKeJPXZYyMVDgMyXxMf17MWYia92Rjd

### Sponsor
Alternatively, sponsor me on Github using [Github Sponsors](https://github.com/sponsors/JKorf). 

## Release notes
* Version 2.7.0 - 04 Dec 2024
  * Added XT.Net 1.0.0
  * Added DisplayName and ImageUrl to ExchangeInfo model
  * Added GetFeeClients methods on ExchangeRestClient
  * Added GetFeesAsync and GetFeesAsyncEnumerable methods on ExchangeRestClient
  * Added AddCryptoClients DI extension to support for loading settings from IConfiguration
  * Added dynamic SetApiCredentials method on ExchangeRestClient and ExchangeSocketClient
  * Refactored AddCryptoClients method to specify options in code to use a single callback per exchange
  * Updated reference CryptoExchange.Net version from 8.2.0 to 8.4.3
    * Added support for IOptions injection, allowing options to be read from IConfiguration
    * Added handling of Infinity values in decimal converter
    * Added rate limit update event
    * Added GetFeesAsync Shared REST client support
    * Added LibraryOptions base class
    * Added CommaSplitEnumConverter System.Text.Json converter
    * Added TimePeriodFilterSupport and MaxLimit properties to PaginatedEndpointOptions
    * Added JsonConverterCtorAttribute to allow specifying a custom JsonConverter with constructor parameters on properties
    * Added ReplaceConverter System.Text.Json converter
    * Added LibraryHelpers class for internal helper methods
    * Updated package dependency versions
    * Small refactor on client options internals
    * Fixed concurrency issue when unsubscribing websocket subscription during reconnection
    * Fixed KlineTracker update handling
  * Updated Binance.Net from version 10.9.2 to version 10.13.0
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to BinanceExchange class  
    * Added WithdrawInternalMin to restClient.SpotApi.Account.GetUserAssetsAsync response model
    * Added EnableFixApiTrade and EnableFixReadOnly to restClient.SpotApi.Account.GetAPIKeyPermissionsAsync response model
    * Added IsOptionsEnabled and IsPortfolioMarginRetailEnabled to restClient.SpotApi.Account.GetAccountVipLevelAndStatusAsync response model
    * Added listClientOrderId parameter to restClient.SpotApi.Trading.PlaceOcoOrderListAsync
    * Added GetFeesAsync Shared REST client implementations
    * Added AllowAppendingClientOrderId option
    * Updated BinanceOptions to LibraryOptions implementation
    * Updated client constructors to accept IOptions from DI
    * Updated test and analyzer package versions
    * Updated client order id logic
    * Removed BrokerId option
    * Removed redundant BinanceSocketClient constructor
    * Removed restClient.SpotApi.Account.GetAutoConvertStableCoinConfigAsync, SetAutoConvertStableCoinConfigAsync and ConvertBusdAsync as theyre deprecated
    * Fixed inverted order side for Shared trades
    * Fixed ListenKey property not set on spot websocket account data updates
    * Fixed restClient.GeneralApi.SimpleEarn.GetLockedProductPositionsAsync deserialization
    * Fixed orderbook creation via BinanceOrderBookFactory
  * Updated BingX.Net from version 1.15.1 to version 1.18.1
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to BingXExchange class
    * Added restClient.PerpetualFuturesApi.Account.ApplyForVSTAssetsAsync
    * Added restClient.PerpetualFuturesApi.Account.SetMultiAssetModeAsync
    * Added restClient.PerpetualFuturesApi.Account.GetMultiAssetModeAsync
    * Added restClient.PerpetualFuturesApi.Account.GetMultiAssetRulesAsync
    * Added restClient.PerpetualFuturesApi.Account.GetMultiAssetsMarginAsync
    * Added restClient.PerpetualFuturesApi.Trading.GetOrdersAsync
    * Added restClient.PerpetualFuturesApi.Trading.PlaceTwapOrderAsync
    * Added restClient.PerpetualFuturesApi.Trading.GetOpenTwapOrdersAsync
    * Added restClient.PerpetualFuturesApi.Trading.GetTwapOrderAsync
    * Added restClient.PerpetualFuturesApi.Trading.GetClosedTwapOrdersAsync
    * Added restClient.PerpetualFuturesApi.Trading.CancelTwapOrderAsync
    * Added Demo BingXEnvironment
    * Added websocket connection limit perpetual futures
    * Added GetFeesAsync Shared REST client implementations
    * Updated client constructors to accept IOptions from DI
    * Updated BingXOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Removed redundant BingXSocketClient constructor
    * Fixed inverted order side for Shared trades
    * Fixed orderbook creation via BingXOrderBookFactory
  * Updated Bitfinex.Net from version 7.10.0 to version 7.12.1
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to BitfinexExchange class
    * Added GetFeesAsync Shared REST client implementations
    * Updated BitfinexOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Updated client constructors to accept IOptions from DI
    * Removed redundant BitfinexSocketClient constructor
    * Fixed orderbook creation via BitfinexOrderBookFactory
  * Updated Bitget.Net from version 1.15.1 to version 1.18.1
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to BitgetExchange class
    * Updated client constructors to accept IOptions from DI
    * Added restClient.SpotApiV2.Account.TransferSubAccountAsync endpoint
    * Added restClient.SpotApiV2.Account.GetSubAccountBalancesAsync endpoint
    * Added restClient.SpotApiV2.Account.GetSubAccountTransferHistoryAsync endpoint
    * Added restClient.SpotApiV2.Account.GetSubAccountDepositAddressAsync endpoint
    * Added restClient.SpotApiV2.Account.GetSubAccountDepositHistoryAsync endpoint
    * Added websocket rate limiting rules
    * Added GetFeesAsync Shared REST client implementations
    * Updated BitgetOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Changed restClient.FuturesApiV2.Account.GetLedgerAsync idLessThan parameter to long type to match response model id type
    * Removed redundant BitgetSocketClient constructor
    * Fixed restClient.SetApiCredentials having incorrect ApiCredentials type
    * Fixed orderbook creation via BitgetOrderBookFactory
  * Updated BitMart.Net from version 1.7.0 to version 1.10.0
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to BitMartExchange class  
    * Added socketClient.UsdFuturesApi.SubscribeToFundingRateUpdatesAsync stream
    * Added Approval enum mapping for Status property on socketClient.UsdFuturesApi.SubscribeToOrderUpdatesAsync update model
    * Added GetFeesAsync Shared REST client implementations
    * Updated client constructors to accept IOptions from DI
    * Updated PlaceMarginOrderAsync ratelimit from 1 per second per key to 20
    * Updated BitMartOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Removed clientOrderId parameter from restCLient.UsdFuturesApi.Trading.EditTpSlOrderAsync
    * Removed redundant BitMartSocketClient constructor
    * Fixed orderbook creation via BitMartOrderBookFactory
  * Updated Bybit.Net from version 3.16.0 to version 3.18.1
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to BybitExchange class
    * Added GetFeesAsync Shared REST client implementations
    * Added startTime/endTime params to restClient.V5Api.ExchangeData.GetLongShortRatioAsync endpoint
    * Added SpecialTreatmentLabel to restClient.V5Api.ExchangeData.GetSpotSymbolsAsync response model
    * Updated client constructors to accept IOptions from DI
    * Updated UnifiedMarginStatus enum values
    * Updated BybitOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Removed redundant BybitSocketClient constructor
    * Fixed orderbook creation via BybitOrderBookFactory
  * Updated Coinbase.Net from version 1.4.0 to version 1.6.1
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to CoinbaseExchange class
    * Added Platform property to restClient.AdvancedTradeApi.Account.GetAccountsAsync and GetAccountAsync response model
    * Added GetFeesAsync Shared REST client implementations
    * Updated CoinbaseOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Updated client constructors to accept IOptions from DI
    * Removed redundant CoinbaseSocketClient constructor
    * Fixed deserialization error in SubscribeToBatchedTickerUpdatesAsync subscription when there is no trade price
    * Fixed orderbook creation via CoinbaseBookFactory
  * Updated CoinEx.Net from version 7.9.0 to version 7.12.0
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to CoinExExchange class
    * Added AllowAppendingClientOrderId option
    * Added GetFeesAsync Shared REST client implementations
    * Updated client constructors to accept IOptions from DI
    * Updated CoinExOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Updated client order id logic for client reference
    * Removed redundant CoinExSocketClient constructor
    * Fix for orderbook creation via CoinExOrderBookFactory
  * Updated CoinGecko.Net from version 3.0.0 to version 3.2.0
    * Added support for loading client settings from IConfiguration
    * Updated client constructors to accept IOptions from DI
    * Updated test and analyzer package versions
  * Updated CryptoCom.Net from version 1.2.1 to version 1.4.1
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to CryptoComExchange class
    * Added GetFeesAsync Shared REST client implementations
    * Updated client constructors to accept IOptions from DI
    * Updated CryptoComOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Removed redundant CryptoComSocketClient constructor
    * Fixed orderbook creation via CryptoComBookFactory
  * Updated GateIo.Net from version 1.12.1 to version 1.15.0
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to GateIoExchange class
    * Added GetFeesAsync Shared REST client implementations
    * Added restClient.SpotApi.Account.GetTransferStatusAsync endpoint
    * Added UpdateId to Position model
    * Updated client constructors to accept IOptions from DI
    * Updated GateIoExchange.ExchangeName value from Gate.io to GateIo
    * Updated GateIoOptions to LibraryOptions implementation
    * Updated UpdatePositionModeAsync response model
    * Updated test and analyzer package versions
    * Removed redundant GateIoSocketClient constructor
    * Removed socketClient.SpotApi.SubscribeToOrderBookUpdatesAsync updateMs parameter
    * Removed socketClient.PerpetualFuturesApi.SubscribeToOrderBookUpdatesAsync 1000ms updateMs and 5 and 10 depth valid parameter values
    * Fixed orderbook creation via GateIoBookFactory
  * Updated HTX.Net from version 6.4.1 to version 6.7.1
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to HTXExchange class
    * Added GetFeesAsync Shared REST client implementations
    * Added AllowAppendingClientOrderId option
    * Updated client constructors to accept IOptions from DI
    * Updated HTXOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Updated client order id logic for client reference for the Spot API
    * Removed redundant HTXSocketClient constructor
    * Fix for orderbook creation via HTXOrderBookFactory
  * Updated Kraken.Net from version 5.2.0 to version 5.4.1
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to KrakenExchange class
    * Added newAssetNameResponse parameter to restClient.SpotApi.ExchangeData.GetSymbolsAsync and restClient.SpotApi.ExchangeData.GetAssetsAsync
    * Added GetFeesAsync Shared REST client implementations
    * Updated client constructors to accept IOptions from DI
    * Updated BinanceOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Removed redundant KrakenSocketClient constructor
    * Fixed restClient.FuturesApi.Account.GetFeeScheduleVolumeAsync deserialization
    * Fixed orderbook creation via KrakenOrderBookFactory
  * Updated Kucoin.Net from version 5.18.0 to version 5.22.0
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to KucoinExchange class
    * Added restClient.SpotApi.SubAccount.EnableMarginPermissionsAsync and EnableFuturesPermissionsAsync endpoints
    * Added symbol parameter to restClient.FuturesApi.Trading.CancelMultipleOrdersAsync endpoint
    * Added tradeTypes parameter to restClient.FuturesApi.Trading.GetUserTradesAsync endpoint
    * Added Option enum values for account types
    * Added quantityInBaseAsset and quantityInQuoteAsset to futures orders endpoints
    * Added GetFeesAsync Shared REST client implementations
    * Updated websocket connections limit from 50 to 150 for spot
    * Updated some futures response models
    * Updated KucoinOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Updated client constructors to accept IOptions from DI
    * Removed redundant KucoinSocketClient constructor
    * Fixed orderbook creation via KucoinOrderBookFactory
  * Updated Mexc.Net from version 1.11.0 to version 1.13.1
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to MexcExchange class
    * Added GetFeesAsync Shared REST client implementations
    * Updated MexcOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Updated client constructors to accept IOptions from DI
    * Removed redundant MexcSocketClient constructor
    * Fixed some deserialization issues on decimal larger than Decimal.MaxValue on websocket streams
    * Fixed orderbook creation via MexcOrderBookFactory
  * Updated OKX.Net from version 2.8.0 to version 2.12.0
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to OKXExchange class
    * Added Chase Algo order support
    * Added AccountType property to restClient.UnifiedApi.Account.GetAccountConfigurationAsync response model
    * Added GetFeesAsync Shared REST client implementations
    * Added AllowAppendingClientOrderId option
    * Added Cash value to MarginMode Enum
    * Updated restClient.UnifiedApi.Account.GetAssetsAsync response model
    * Updated restClient.UnifiedApi.Account.GetMaximumLoanAmountAsync parameters
    * Updated OKXOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Updated client constructors to accept IOptions from DI
    * Updated client order id logic
    * Removed redundant OKXSocketClient constructor
    * Removed BrokerId option
    * Fixed deserialization issue in okxRestClient.UnifiedApi.ExchangeData.GetDiscountInfoAsync
    * Fixed orderbook creation via OKXOrderBookFactory
  * Updated WhiteBit.Net from version 1.0.0 to version 1.2.1
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to WhiteBitExchange class
    * Added GetFeesAsync Shared REST client implementations
    * Updated WhiteBitOptions to LibraryOptions implementation
    * Updated test and analyzer package versions
    * Updated client constructors to accept IOptions from DI
    * Removed redundant WhiteBitSocketClient constructor
    * Fixed orderbook creation via WhiteBitOrderBookFactory


* Version 2.6.0 - 19 Nov 2024
  * Updated Binance.Net to version 10.9.2
    * Added page parameter to restClient.UsdFuturesApi.Account.GetIncomeHistoryAsync endpoint
  * Updated BingX.Net to version 1.15.1
    * Added initial SubAccount API implementation
    * Fixed available balance response on shared futures implementation
    * Removed symbol parameters from GetPositionModeAsync and SetPositionModeAsync endpoints
  * Updated Bitget.Net to version 1.15.1
    * Split and corrected futures trigger plan type parameters
    * Added status filter to restClient.FuturesApiV2.Trading.GetClosedTriggerOrdersAsync
    * Added missing futures trigger order statuses
    * Updated restClient.FuturesApiV2.Account.GetLedgerAsync response model
  * Updated CoinGecko to version 3.0.0
    * Switched json (de)serialization from Newtonsoft.Json to System.Text.Json
    * Added support for setting API key
    * Added error parsing implementation
    * Added pro API endpoint to CoinGeckoEnvironment
    * Added GetMarketsAsync endpoint
    * Added GetCompanyHoldingsAsync endpoint
    * Added GetExchangeDerivativesDetailsAsync endpoint
    * Added GetApiUsageAsync endpoint
    * Added precision parameter to GetMarketChartAsync, GetOhlcAsync
    * Updated response models
    * Updated API doc references
    * Removed includeTickers parameter from GetDerivativesAsync endpoint
    * Removed assetPlatformId parameter from GetNftsAsync endpoint
  * Updated CryptoCom.Net to version 1.2.1
    * Fixed deserialization issue in restClient.ExchangeApi.ExchangeData.GetTickerAsync
  * Updated GateIo.Net to version 1.12.1
    * Fixed restClient.PerpetualFuturesApi.Trading.PlaceTriggerOrderAsync parameter serialization
  * Updated HTX.Net to version 6.4.1
    * Fixed deserialization issue in restClient.UsdtFuturesApi.ExchangeData.GetTickersAsync endpoint

* Version 2.5.0 - 07 Nov 2024
  * Added support for the WhiteBit exchange with WhiteBit.Net 1.0.0
  * Updated reference CryptoExchange version to 8.2.0
    * Added support for not allowing duplicate subscription topics on the same websocket connection
    * Added PerAccount SharedLeverageSettingMode enum value, changed Side on SharedUserTrade to nullable
    * Added support for object deserialization in SystemTextJsonMessageAccessor.GetValue<T>
    * Changed SocketApiClient GetAuthenticationRequest to GetAuthenticationRequestAsync to allow for requesting token
    * Fixed socket connections trying to authenticated connection when it's marked as dedicated request connection even when no authentication is needed
    * Fixed System.Text.Json ArrayConverter not passing serializer options to nested deserialization
    * Fixed System.Text.Json ArrayConverter creating new serializer options each time a JsonConverter attribute is encountered
  * Updated Binance.Net to version 10.9.0
    * Added restClient.CoinFuturesApi.Account.GetDownloadIdForOrderHistoryAsync endpoint
    * Added restClient.CoinFuturesApi.Account.GetDownloadLinkForOrderHistoryAsync endpoint
    * Added restClient.CoinFuturesApi.Account.GetDownloadIdForTradeHistoryAsync endpoint
    * Added restClient.CoinFuturesApi.Account.GetDownloadLinkForTradeHistoryAsync endpoint
  * Updated BingX.Net to version 1.14.0
    * Added restClient.PerpetualFuturesApi.Account.GetIsolatedMarginChangeHistoryAsync endpoint
    * Added settleAsset parameter to FuturesApi.Trading endpoints
  * Updated Bitfinex.Net to version 7.10.0
  * Updated Bitget.Net to version 1.13.0
    * Added Cross and Isolated Margin API implementation
    * Fixed V1 API GET request authentication for requests without parameters
    * Fixed warning log when subscribing multiple symbols at the same time
  * Updated BitMart.Net to version 1.7.0
    * Added socketClient.UsdFuturesApi.SubscribeToOrderBookSnapshotUpdatesAsync subscription
    * Added socketClient.UsdFuturesApi.SubscribeToOrderBookIncrementalUpdatesAsync subscription
    * Added IOrderBookSocketClient to UsdFuturesApi Shared socket implementations
    * Added MaxMarketOrderQuantity to BitMartContract response model
  * Updated Bybit.Net to version 3.16.0
    * Added OtherBorrowAmount to restClient.V5Api.Account.GetCollateralInfoAsync response model
    * Added Kazakhstan environment urls
    * Added restClient.V5Api.Account.GetClassicContractTransactionHistoryAsync endpoint
  * Updated Coinbase.Net to version 1.4.0
    * Updated restClient.AdvancedTradeApi.Account.WithdrawCryptoAsync parameters
    * Removed restClient.AdvancedTradeApi.Account.TransferAsync as it's no longer supported
  * Updated CoinEx.Net to version 7.9.0
  * Updated CoinGecko.Net to version 2.8.0
  * Updated CryptoCom.Net to version 1.2.0
  * Updated GateIo.Net to version 1.12.0
    * Added restClient.SpotApi.Account.GetUnifiedLeverageConfigsAsync endpoint
    * Added restClient.SpotApi.Account.GetUnifiedLeverageAsync endpoint
    * Added restClient.SpotApi.Account.SetUnifiedLeverageAsync endpoint
    * Added Id property to restClient.PerpetualFuturesApi.Account.GetLedgerAsync response model
    * Added Leverage property to restClient.SpotApi.ExchangeData.GetDiscountTiersAsync response model
    * Added BestAskQuantity, BestBidQuantity properties to restClient.SpotApi.ExchangeData.GetTickersAsync response model
  * Updated HTX.Net to version 6.4.0
  * Updated Kraken.Net to version 5.2.0
    * Fixed exception during websocket reconnection when using websocket requests
  * Updated Kucoin.Net to version 5.18.0
    * Added restClient.SpotApi.Account.GetApiKeyInfoAsync endpoint
  * Updated Mexc.Net to version 1.11.0
  * Updated OKX.Net to version 2.8.0
    * Added AuctionEndTime property to restClient.UnifiedApi.ExchangeData.GetSymbolsAsync and socketClient.UnifiedApi.ExchangeData.SubscribeToSymbolUpdatesAsync models

* Version 2.4.0 - 28 Oct 2024
  * Simplified ExchangeOrderBookFactory.Create implementation
  * Added ExchangeTrackerFactory for creating Kline/Trade trackers
  * Updated reference CryptoExchange version to 8.1.0
    * Added KlineTracker and TradeTracker implementation
    * Added Side to SharedTrade model
    * Added overload for Create method in OrderBookFactory using SharedSymbol
    * Added ValidateMessage method to websocket Query object to filter messages even though it is matched to the query based on the  ListenIdentifier
    * Added DoHandleReset method for websocket subscriptions
    * Added ConnectionId to RequestDefinition to correctly handle connection and path rate limiting configuration
    * Added System.Text.Json ArrayConverter Write implementation
    * Updated SharedFuturesTicker LastPrice, HighPrice and LowPrice properties to be nullable
    * Updated SetApiCredentials method to also updated the credentials on the client specific options to prevent unknown client credentials in some situations
  * Updated Binance.Net to version 10.8.0
    * Moved FormatSymbol to BinanceExchange class
    * Added support Side setting on SharedTrade model
    * Added BinanceTrackerFactory for creating trackers
    * Added overload to Create method on BinanceOrderBookFactory support SharedSymbol parameter
    * Fixed Shared rest GetTradeHistoryAsync pagination
    * Added catch around HttpClientHandler.AutomaticDecompression setting as it's not support on Blazor WASM
  * Updated BingX.Net to version 1.12.0
    * Moved FormatSymbol to BingXExchange class
    * Added support Side setting on SharedTrade model
    * Added BingXTrackerFactory for creating trackers
    * Added overload to Create method on BingXOrderBookFactory support SharedSymbol parameter
    * Added Shared websocket kline subscription implementation for futures and spot APIs
  * Updated Bitfinex.Net to version 7.9.0
    * Moved FormatSymbol to BitfinexExchange class
    * Added support Side setting on SharedTrade model
    * Added BitfinexTrackerFactory for creating trackers
    * Added overload to Create method on BitfinexOrderBookFactory support SharedSymbol parameter
    * Added filtering of TradeUpdate messages in Shared rest trade socket subscription (Trade execution messages are still processed)
  * Updated Bitget.Net to version 1.11.0
    * Moved FormatSymbol to BitgetExchange class
    * Added support Side setting on SharedTrade model
    * Added BitgetTrackerFactory for creating trackers
    * Added overload to Create method on BitgetOrderBookFactory support SharedSymbol parameter
  * Updated BitMart.Net to version 1.5.0
    * Moved FormatSymbol to BitMartExchange class
    * Added support Side setting on SharedTrade model
    * Added BitMartTrackerFactory for creating trackers
    * Added overload to Create method on BitMartOrderBookFactory support SharedSymbol parameter
  * Updated Bybit.Net to version 3.15.0
    * Moved FormatSymbol to BybitExchange class
    * Added support Side setting on SharedTrade model
    * Added BybitTrackerFactory for creating trackers
    * Added overload to Create method on BybitOrderBookFactory support SharedSymbol parameter
    * Added websocket stream URI for Turkey users
  * Updated Coinbase.Net to version 1.2.0
    * Moved FormatSymbol to CoinbaseExchange class
    * Added support Side setting on SharedTrade model
    * Added CoinbaseTrackerFactory for creating trackers
    * Added overload to Create method on CoinbaseOrderBookFactory support SharedSymbol parameter
    * Added GetKlinesAsync to Shared rest client
    * Fixed exception on restClient.AdvancedTradingAi.Trading.CancelOrderAynsc when order not found
    * Fixed exception on restClient.AdvancedTradingAi.Trading.CancelOrdersAynsc when request fails
    * Fixed restClient.AdvancedTradingAi.ExchangeData.GetKlinesAsync time filter
    * Fixed issue with concurrent websocket subscription acknowledgements
    * Removed incorrect rate limit of 100 message per second per ip for websockets
  * Updated CoinEx.Net to version 7.8.0
    * Moved FormatSymbol to CoinExExchange class
    * Added support Side setting on SharedTrade model
    * Added CoinExTrackerFactory for creating trackers
    * Added overload to Create method on CoinExOrderBookFactory support SharedSymbol parameter
  * Updated CoinGecko.Net to version 2.7.0
  * Updated CryptoCom.Net to version 1.1.0
    * Moved FormatSymbol to CryptoComExchange class
    * Added support Side setting on SharedTrade model
    * Added CryptoComTrackerFactory for creating trackers
    * Added overload to Create method on CryptoComOrderBookFactory support SharedSymbol parameter
    * Renamed CreateExchange method on CryptoComOrderBookFactory to Create
  * Updated GateIo.Net to version 1.10.0
    * Moved FormatSymbol to GateIoExchange class
    * Added support Side setting on SharedTrade model
    * Added GateIoTrackerFactory for creating trackers
    * Added overload to Create method on GateIoOrderBookFactory support SharedSymbol parameter
  * Updated HTX.Net to version 6.3.0
    * Moved FormatSymbol to HTXExchange class
    * Added support Side setting on SharedTrade model
    * Added HTXTrackerFactory for creating trackers
    * Added overload to Create method on HTXOrderBookFactory support SharedSymbol parameter
    * Fixed rate limiting incorrectly applied to websocket market data connections
  * Updated Kraken.Net to version 5.1.0
    * Moved FormatSymbol to KrakenExchange class
    * Added support Side setting on SharedTrade model
    * Added KrakenTrackerFactory for creating trackers
    * Added overload to Create method on KrakenOrderBookFactory support SharedSymbol parameter
    * Fixed websocket Unsubscribe for orderbook subscriptions
  * Updated Kucoin.Net to version 5.17.0
    * Moved FormatSymbol to KucoinExchange class
    * Added support Side setting on SharedTrade model
    * Added KucoinTrackerFactory for creating trackers
    * Added overload to Create method on KucoinOrderBookFactory support SharedSymbol parameter
  * Updated Mexc.Net to version 1.10.0
    * Moved FormatSymbol to MexcExchange class
    * Added support Side setting on SharedTrade model
    * Added MexcTrackerFactory for creating trackers
    * Added overload to Create method on MexcOrderBookFactory support SharedSymbol parameter
  * Updated OKX.Net to version 2.7.0
    * Moved FormatSymbol to OKXExchange class
    * Added support Side setting on SharedTrade model
    * Added OKXTrackerFactory for creating trackers
    * Added overload to Create method on OKXOrderBookFactory support SharedSymbol parameter
    * Added support for different order book levels in OKXSymbolOrderBook

* Version 2.3.0 - 23 Oct 2024
  * Added Crypto.com support with CryptoCom.Net to version 1.0.1
  * Added minimalDepth parameter to ExchangeOrderBookFactory Create method
  * Updated Binance.Net to version 10.7.0
    * Added SelfTradePreventionMode and PriceMatch parameters and responses for Coin-M Futures API
    * Added returnPermissionSets and symbolStatus parameters to restClient.SpotApi.ExchangeData.GetExchangeInfoAsync endpoint
    * Fixed issues with restClient.GeneralApi.AutoInvest.GetSubscriptionTransactionHistoryAsync
    * Fixed deserialization issue subaccount transfer
  * Updated BingX.Net to version 1.11.2
    * Added Tier property to restClient.PerpetualFuturesApi.Trading.GetPositionAndMarginInfoAsync response model
    * Added ReduceOnly property to socketClient.PerpetualFuturesApi.SubscribeToUserDataUpdatesAsync order update model
  * Updated Bitget.Net to version 1.10.4
    * Fixed V1 GET request signing without parameters
    * Fixed request signing V2 with special characters
    * Fixed restClient.SpotApi.Trading.GetOrderAsync exception when order not found
  * Updated BitMart.Net to version 1.4.0
    * Added restClient.UsdFuturesApi.Account.GetSymbolTradeFeeAsync endpoint
    * Added TakerFeeRateD and MakerFeeRateD properties to restClient.SpotApi.Account.GetBaseTradeFeesAsync response model
    * Added FundingIntervalHours to restClient.UsdFuturesApi.ExchangeData.GetContractsAsync response model
  * Updated Coinbase.Net to version 1.1.2
    * Updated ExchangeData endpoints to use the Products endpoint instead of Public endpoint if API credentials are provided
    * Added restClient.AdvancedTradeApi.ExchangeData.GetBookTickersAsync and GetBookTickerAsync endpoints
    * Fixed websocket market data subscriptions for "USDT-USDC" and "EURC-USDC" symbols
    * Fixed deserialization issue on websocket ticker updates
  * Updated GateIo.Net to version 1.9.0
    * Added restClient.SpotApi.Account.GetRateLimitsAsync endpoint
    * Added support for clientOrderId to restClient.PerpetualFuturesApi.Trading.GetOrderAsync, CancelOrderAsync and EditOrderAsync endpoints
  * Updated Kraken.Net to version 5.0.2
    * Fixed socketClient.SpotApi.SubscribeToAggregatedOrderBookUpdatesAsync and SubscribeToInvidualOrderBookUpdatesAsync not passing the depth parameter to the server
    * Fixed userReference parameter incorrectly set at restClient.SpotApi.Trading.PlaceOrderAsync
    * Fixed timestamp serialization for socketClient.SpotApi queries
    * Fixed websocket subscription request revitalization throwing an exception
  * Updated Kucoin.Net to version 5.16.0
    * Added restClient.FuturesApi.Trading.CancelMultipleOrdersAsync endpoint
    * Added restClient.SpotApi.Account.GetIsHfAccountAsync endpoint
    * Added restClient.SpotApi.ExchangeData.GetAnnouncementsAsync endpoint
    * Added AveragePrice to Futures order response model
    * Added AveragePrice setting to Shared IFuturesOrderRestClient responses
    * Updated restClient.SpotApi.Account.WithdrawAsync to V3 endpoint
    * Updated KucoinAssetNetwork response model
    * Fixed CancelAfter parameter type for restClient.SpotApi.Trading.PlaceBulkOrderAsync endpoint
    * Fixed Shared IBalanceRestClient implementation to only return spot balances
  * Updated Mexc.Net to version 1.9.0
    * Added mexcRestClient.SpotApi.Account.GetKycStatusAsync endpoint
    * Added ListenkeyRenewed event to socketClient.SpotApi client so users can react to updated listenkeys for keep-alive caused by reconnecting
  * Updated OKX.Net to version 2.6.0
    * Added restClient.UnifiedApi.Account.ManualBorrowRepayAsync, SetAutoRepayAsync and GetBorrowRepayHistoryAsync endpoints
    * Added EasyConvertDustAsync, GetEasyConvertDustAssetsAsync and GetEasyConvertDustHistoryAsync endpoints
    * Added BurningFeeRate property to restClient.UnifiedApi.Account.GetAssetsAsync response model
    * Updated AccountBillSubType and AccountSubType Enum values
    * Refactored restClient.UnifiedApi.Trading.PlaceOrderAsync take profit / stop loss parameters to support the full functionality offered by the API
    * Fixed restClient.UnifiedApi.Trading.CancelMultipleOrdersAsync order canceled event processing
    * Removed restClient.UnifiedApi.Account.ConvertDustAsync deprecated endpoint

* Version 2.2.1 - 14 Oct 2024
  * Updated library client versions
  * Fixed TypeLoadException during initialization

* Version 2.2.0 - 14 Oct 2024
  * Updated reference CryptoExchange version to 8.0.3
    * Updated dependency versions, including System.Text.Json from 8.0.4 to 8.0.5 containing a vulnerability fix
    * Added support for duplicate array indexes in System.Text.Json ArrayConverter
    * Added fallback for unparsable value in System.Text.Json NumberStringConverter
    * Added Authenticated property on base client and shared client
    * Added GetValues System.Text.Json implementation in message accessor
  * Updated Binance.Net to version 10.6.0
    * Added USD-M Futures web socket order API
    * Fixed pagination for shared closed orders USD futures
  * Updated BitMart.Net to version 1.3.1
    * Fixed symbol formatting order book factory
    * Fixed IBitMartOrderBookFactory DI lifetime
  * Updated Bybit.Net to version 3.14.2
    * Fixed restClient.V5Api.Account.GetBalancesAsync deserialization in demo environment without any transactions
    * Added missing TrailingProfit value to StopOrderType Enum
  * Updated CoinEx.Net to version 7.7.1
    * Fixed Shared interface REST spot order quantity parsing
    * Fixed Shared interface REST spot order status parsing
  * Updated GateIo.Net to version 1.8.0
    * Fixed ICoinbaseOrderBookFactory DI lifetime
    * Added clientOrderId parameter to restClient.SpotApi.Trading.EditOrderAsync
    * Added clientOrderId parameter to socketClient.SpotApi.EditOrderAsync
  * Updated HTX.Net to version 6.1.2
    * Fixed cancellation token not being passed to subscribe method in Shared client
  * Updated Kraken.Net to version 5.0.0
    * Updated the library to use System.Text.Json for (de)serialization instead of Json.Net
    * Updated Spot websocket implementation from V1 to V2
      * Moved requesting of WebSocket token for private endpoints from user endpoint to internal
      * Removed automatic mapping of BTC to XBT (V2 API used BTC as symbol instead of the previous XBT)
      * Respone models have been updated to V2
      * Spread subscription has been removed, part of Ticker stream now
      * Added individual order book subscription
      * Added instrument subscription
      * Added user balances subscription
      * UserTrade subscription has been removed, part of Order stream now
      * Added socketClient.SpotApi.PlaceMultipleOrdersAsync endpoint
      * Added socketClient.SpotApi.EditOrderAsync endpoint
    * Added socketClient.SpotApi.ReplaceOrderAsync endpoint
    * Added Shared implementation for Futures WebSocket and REST APIs
    * Extended Shared implementation for Spot WebSocket API
    * Added restClient.SpotApi.Trading.CancelAllOrdersAfterAsync endpoint
    * Added restClient.FuturesApi.ExchangeData.GetTickerAsync endpoint
    * Added restClient.FuturesApi.Trading.GetOrdrAync endpoint
    * Renamed clientOrderId to userReference parameters in Spot orders as it was implemented with the `userref` field
    * Added new clientOrderId parameter to Spot orders using the correct `cl_ord_id` field
    * Updated Shared Spot REST implementation to use new clientOrderId property
    * Updated restClient.FuturesApi.GetBalancesAsync response so it's more discoverable
    * Updated AssetStatus Enum values
    * Updated SymbolStatus Enum values
    * Fixed deserialization issue FuturesApi.Trading.GetOpenPositionsAsync

* Version 2.1.0 - 08 Oct 2024
  * Added Coinbase support with Coinbase.Net 1.0.0
  * Updated reference CryptoExchange version to 8.0.1
    * Added cached library version properties on base client
    * Added support for derserializing 0001-01-01 as datetime null value
    * Added ToRfc3339String extension method for DateTime type
  * Updated Bitfinex.Net to version 7.8.1
    * Limit shared interface GetBalancesAsync result to Exchange balances to prevent duplicate asset balances
  * Updated Bitget.Net to version 1.10.1
    * Added BitgetSymbolStatus.Halt Enum value
    * Added converting to uppercase for CancelAllOrdersAsync marginAsset parameter
    * Fixed FutureApiV2.Trading.CancelTriggerOrdersAsync endpoint
  * Updated BitMart.Net to version 1.3.0
    * Added UsdFuturesApi.Trading.PlaceTpSlOrderAsync endpoint
    * Added UsdFuturesApi.Trading.EditTpSlOrderAsync endpoint
    * Added UsdFuturesApi.Trading.EditTriggerOrderAsync endpoint
    * Added UsdFuturesApi.Trading.EditPresetTriggerOrderAsync endpoint
    * Added clientOrderId parameter to CancelOrderAsync and CancelTriggerOrderAsync endpoints
    * Added planType parameter to GetTriggerOrdersAsync endpoint
  * Updated Bybit.Net to version 3.14.1
    * Added ClosedPnl property to BybitOrderUpdate model
    * Added Pnl property to BybitUserTradeUpdate model
  * Updated GateIo.Net to version 1.7.0
    * Added SpotApi.Account.GetTransferHistoryAsync endpoint
    * Added SpotApi.Account.TransferToAccountAsync endpoint
    * Added PerpetualFuturesApi.Trading.EditMultipleOrdersAsync endpoint
    * Added BestBidQuantity/BestAskQuantity properties to GateIoPerpTicker response model
    * Added startTime/endTime parameters to PerpetualFuturesApi.ExchangeData.GetFundingRateHistoryAsync and updated shared implementation to support pagination
    * Added support for clientOrderId to SpotApi.Trading.GetOrderAsync endpoint
    * Fixed some serialization issues in batch endpoints
  * Updated HTX.Net to version 6.1.1
    * Fixed LastPrice value on SpotTicker Shared implementation
  * Updated Kucoin.Net to version 5.15.0
    * Added FuturesApi.Account.GetMarginModeAsync endpoint
    * Added FuturesApi.Account.SetMarginModeAsync endpoint
    * Added FuturesApi.Account.GetCrossMarginLeverageAsync endpoint
    * Added FuturesApi.Account.SetCrossMarginLeverageAsync endpoint
    * Added marginMode parameter to FuturesApi.Trading.PlaceOrderAsync and PlaceMultipleOrdersAsync endpoints
    * Added onWalletUpdate update handler to FuturesApi.SubscribeToBalanceUpdatesAsync stream
    * Added FuturesApi.SubscribeToMarginModeUpdatesAsync stream
    * Added FuturesApi.SubscribeToCrossMarginLeverageUpdatesAsync stream
    * Updated various order and trade response/update models with margin mode properties
    * Update position models with MarginMode, PositionSide, Leverage and PositionFunding properties
    * Fixed cancellation token not getting passed in shared ticker subscriptions
  * Updated OKX.Net to version 2.5.0
    * Added ExchangeData.GetAnnouncementsAsync and GetAnnouncementTypesAsync endpoints
    * Added asset parameter to Account.GetLeverageAsync endpoint
    * Added IsTradeBorrowMode property to Algo order response model
    * Updated OKXAccountConfiguration response model
    * Updated OKXDiscountInfo response model

* Version 2.0.0 - 27 Sep 2024
    * Added support for ISharedClient interface usage
    * Added support for requesting various data from all or specific exchanges in a single call to the rest client
    * Added support for subscribing data streams of all or specific exchanges in a single call to the socket client
    * Changed the Exchange type from Enum to string
    * Marked ISpotClient usage as deprecated
    * Updated reference CryptoExchange version to 8.0.0
        * Added new cross exchange interfaces implementation
            * Supports REST, WebSocket, Spot and Futures API's
            * Added various client interfaces for specific functionality
            * Added SharedSymbol type, taking care of symbol formatting for different exchanges
            * Added dynamic pagination support for shared functionality
            * Added various shared Enum definitions
            * Added ExchangeWebResult and ExchangeEvent, exchange specific versions of WebCallResult and DataEvent
            * See https://jkorf.github.io/CryptoExchange.Net/index.html#idocs_shared for more info
        * Added tradingMode and deliverData parameters to BaseApiClient FormatSymbol method
        * Added ExecutePages method to ExchangeHelpers static class
        * Added ApplySymbolRules method to ExchangeHelpers static class
        * Added ResubscribingFailed event for websocket connections
        * Added handling of http result 429 (ratelimited) during websocket connection
        * Added Websocket dispose before creating new connection when reconnecting
        * Updated Sourcelink package version
        * Improved closing logic websockets
        * Fixed issues when ratelimiting is canceled using the provided cancellation token
        * Marked ISpotClient and IFuturesClient references as deprecated
    * Updated Binance.Net to version 10.5.0
        * Added Shared client interfaces implementation for Spot, USD-M Futures, Coin-M Futures Rest and Socket clients
        * Added GeneralApi.AutoInvest endpoints
        * Added UsdFuturesApi convert endpoints
        * Added onTradeUpdate callback for UsdFuturesApi.SubscribeToUserDataUpdatesAsync
        * Fixed SubAccountId property deserialization in deposit history
        * Updated some request weights for ratelimiting
        * Updated Id property from `string?` to `string` on BinanceWithdrawalPlaced model
        * Updated Sourcelink package version
        * Changed CrossUnrealizedPnl field in futures balances to support testnet response
        * Fix for UsdFuturesApi.Trading.EditMultipleOrdersAsync order id serialization
        * Fix for GeneralApi.AutoInvest.GetPlansAsync deserialization
        * Fixed incorrect api docs reference for CoinFuturesApi.ExchangeData.GetFundingRatesAsync
        * Marked ISpotClient and IFuturesClient references as deprecated
    * Updated BingX.Net to version 1.11.0
        * Added RealizedPnl property to PerpetualFuturesApi websocket position update
        * Added TimeOffline, TimeMaintenance properties to SpotApi symbol model
        * Added BrokerProhibited property to PerpetualFuturesApi contract response model
        * Added SpotApi Oco endpoints
        * Added Shared client interfaces implementation for Spot and Perpetual Futures Rest and Socket clients
        * Added check for api credentials in rest user stream operations
        * Added PerpetualFuturesApi.Trading.GetUserTradesAsync endpoint
        * Added timeInForce parameter to SpotApi.Trading.PlaceOrderAsync endpoint
        * Updated fromId parameter on SpotApi.Trading.GetuserTradesAsync from int? to long?
        * Updated KlineInterval Enum values to match number of seconds
        * Updated Sourcelink package version
        * Fixed Boolean parameter serialization on PerpetualFuturesApi.Trading order endpoints
        * Fixed enum type on OrderType property on socket perpetual futures order update
        * Fixed request signing for requests with special characters
        * Marked ISpotClient references as deprecated    
    * Updated Bitfinex.Net to version 7.8.0
        * Added Shared client interfaces implementation for Spot Rest and Socket clients
        * Added SpotApi.Account.WithdrawV2Async endpoint
        * Updated SpotApi.ExchangeData.GetTradeHistoryAsync limit parameter max value from 5000 to 10000
        * Updated Sourcelink package version
        * Marked ISpotClient references as deprecated
    * Updated Bitget.Net to version 1.10.0
        * Added missing Price property on SpotApi websocket order update model
        * Added Shared client interfaces implementation for Spot Rest and Socket clients
        * Added oneWaySide parameter to FuturesV2.Trading.PlaceTpSlOrderAsync and renamed positionSide parameter to hedgeModePositionSide
        * Updated QuoteQuantityFilled property name to QuoteQuantity on BitgetFuturesOrderUpdate
        * Updated LastTradeId property type from decimal to string? on BitgetFuturesOrderUpdate
        * Updated LastTradeQuantity, AveragePrice, LastTradeFillPrice and LastTradeFillTime property types from decimal to decimal? on BitgetFuturesOrderUpdate
        * Updated BitgetStreamKlineIntervalV2 Enum values to match number of seconds
        * Updated QuantityDecimals and PriceDecimals property types from decimal to int on BitgetContract model
        * Updated Sourcelink package version
        * Fixed deserialization issue in FuturesApiV2.Account.SetLeverageAsync and SetMarginModeAsync response
        * Fixed UsdcPerpetualSimulated Enum value serialization
        * Fixed ClientOrderId websocket order update deserialization
        * Fixed FuturesV2.ExchangeData.GetNextFundingTimeAsync potentially throwing InvalidOperationException
        * Fixed various endpoints on FuturesV2.Trading returning null data instead of empty collection
        * Fixed typo in IsolatedMarginProfitAndLoss property on BitgetFuturesBalance model
        * Fixed websocket message identification on subscriptions without symbol parameter
        * Marked ISpotClient references as deprecated
    * Updated BitMart.Net to version 1.2.0
        * Added websocket connection ratelimiter
        * Added Shared client interfaces implementation for Spot and Usd Futures Rest and Socket clients
        * Added SpotApi.Account.GetDepositHistoryAsync endpoint
        * Added SpotApi.Account.GetwithdrawalHistoryAsync endpoint
        * Updated Sourcelink package version
        * Updated FuturesKlineInterval, FuturesStreamKlineInterval and KlineStreamInterval Enum values to match number of seconds
        * Updated TradeStatus property type from string to SymbolStatus? Enum on BitMartSymbol model
        * Fixed SpotApi Websocket error response parsing
        * Fixed UsdFuturesApi.Trading.GetClosedOrdersAsync and GetUserTradesAsync startTime/endTime filter
        * Marked ISpotClient references as deprecated
    * Updated Bybit.Net to version 3.14.0
        * Added Shared client interfaces implementation for V5 Rest and Socket clients
        * Updated Sourcelink package version
        * Marked ISpotClient references as deprecated
    * Updated CoinEx.Net to version 7.7.0
        * Added SpotApiV2.Account.GetTransactionHistoryAsync endpoint
        * Added Shared client interfaces implementation for Spot and Futures Rest and Socket clients
        * Added memo parameter to SpotApi.Account.WithdrawAsync
        * Added Role property to CoinExUserTrade model
        * Updated Sourcelink package version
        * Updated QuantityPrecision and PricePrecision property types from decimal to int on CoinExFuturesSymbol
        * Fixed Quantity property type from long to decimal in CoinExDeposit model
        * Fixed QuantityCredited property type from long to decimal? in CoinExDepositModel
        * Fixed FuturesApi.SubscribeToTickerUpdatesAsync subscription
        * Marked ISpotClient references as deprecated
    * Updated CoinGecko.Net to version 2.6.0
        * Updated Sourcelink package version
    * Updated GateIo.Net to version 1.6.0
        * Added startTime and endTime filter to SpotApi.Account.GetUnifiedAccountInterestHistoryAsync endpoint
        * Added options to SpotApi.Account.SetUnifiedAccountModeAsync and GetUnifiedAccountModeAsync endpoints
        * Added BlockNumber field to SpotApi.Account.GetWithdrawalsAsync response
        * Added Shared client interfaces implementation for Spot and Perpetual Futures Rest and Socket clients
        * Added api credentials check for Spot user subscriptions
        * Added InitialMargin and MaintenanceMargin properties to GateIoPosition model
        * Added FeeAsset property to GateIoUserTradeUpdate model
        * Updated Sourcelink package version
        * Updated KlineInterval Enum values to match number of seconds
        * Fixed PerpetualFutures.Account.UpdatePositionModeAsync endpoint
        * Fixed SpotApi.ExchangeData.GetTradesAsync reverse parameter
        * Marked ISpotClient references as deprecated
    * Updated HTX.Net to version 6.1.0
        * Added Shared client interfaces implementation for Spot and UsdtFuturesApi Rest and Socket clients
        * Added QuoteQuantity property to HTXOrderUpdate model
        * Updated from parameter type from int? to long? on SpotApi.Account.GetWithdrawalDepositHistoryAsync
        * Updated Status property type from string to SymbolStatus on HTXSymbolConfig model
        * Updated OrderSide property type from string to OrderSide on HTXUsdtMarginSwapOrderUpdate
        * Updated Sourcelink package version
        * Fixed UsdtFuturesApi.Account.SetIsolatedMarginPositionModeAsync, SetCrossmarginPositionModeAsync, GetIsolatedMarginPositionModeAsync and GetCrossMarginPositionMode response deserialization
        * Marked ISpotClient references as deprecated
    * Updated Kraken.Net to version 4.12.0
        * Added partial Shared client interfaces implementation for Spot and FuturesApi Rest and Socket clients
        * Added SpotApi.Account.GetDepositHistoryAsync endpoint
        * Added SpotApi.Account.GetWithdrawalHistoryAsync endpoint
        * Added trades parameter to SpotApi.Trading.GetOrderAsync and GetOrdersAsync endpoints
        * Added Maker property on KrakenUserTrade model
        * Renamed Decimals to PriceDecimals on KrakenSymbol model
        * Updated Status property type from string? to SymbolStatus on KrakenSymbol model
        * Updated Sourcelink package version
        * Marked ISpotClient references as deprecated
    * Updated Kucoin.Net to version 5.14.0
        * Added Shared client interfaces implementation for Spot and FuturesApi Rest and Socket clients
        * Added QuoteQuantityRemaining property on KucoinStreamOrderUpdate model
        * Added SpotApi.ExchangeData.GetSymbolAsync endpoint
        * Added FuturesApi.Trading.PlaceTpSlOrderAsync endpoint, added ClientOrderId property to futures order placement response
        * Added sub account endpoints under SpotApi.SubAccount.*
        * Updated Status property type from string to OrderStatus on KucoinFuturesOrder model
        * Updated FuturesKlineInterval Enum values to match number of seconds
        * Updated Sourcelink package version
        * Moved SpotApi.Account.GetSubUserInfoAsync to new SubAccount topic
        * Fixed various endpoints returning null instead of empty collection in SpotApi.HfTrading
        * Fixed futures kline deserialization issue
        * Marked ISpotClient and IFuturesClient references as deprecated
    * Updated Mexc to version 1.8.0
        * Added Shared client interfaces implementation for Spot Rest and Socket clients
        * Added QuoteQuantity property to MexcOrder model
        * Updated KlineInterval Enum values to match number of seconds
        * Updated Sourcelink package version
        * Marked ISpotClient references as deprecated
    * Updated OKX.Net to version 2.4.0
        * Added Spot fields to Balance response models
        * Added OpenInterestUsd field to ExchangeData.GetOpenInterestAsync response model
        * Added RuleType parameter and response field to Account.GetFeeRatesAsync
        * Added Attachment field to Account.GetDepositAddressAsync response model
        * Added Shared client interfaces implementation for Unified Rest and Socket clients
        * Updated Sourcelink package version
        * Fixed UnifiedApi.ExchangeData.GetOpenInterestsAsync request for Swap instruments
        * Marked ISpotClient references as deprecated

* Version 1.11.0 - 19 Aug 2024
    * Updated Binance.Net to version 10.2.1
        * Fixed walletType serialization on SpotApi.Trading.ConvertQuoteRequestAsync endpoint
        * Re-added the UsdFuturesApi.Account.GetAccountInfoV2Async endpoint as the V3 endpoint is missing data
        * Renamend UsdFuturesApi.Account.GetAccountInfoAsync to GetAccountInfoV3Async
        * Fixed SpotApi.ExchangeData.GetProductsAsync deserialization
    * Updated BingX.Net to version 1.9.0
        * Added PerpetualFuturesApi.Trading.GetPositionHistoryAsync endpoint
        * Updated PerpetualFuturesApi.Account.GetBalancesAsync to V3, returning both USDT and USDC balances
        * Added sync parameter to SpotApi.Trading.PlaceMultipleOrderAsync endpoint
    * Updated Bitget.Net to 1.9.1
        * Added PositionId to FuturesApiV2.Trading.GetPositionHistoryAsync response model
        * Updated some endpoint ratelimits
    * Updated Bybit.Net to version 3.13.1
        * Added addOrReduce parameter to V5Api.Account.RequestDemoFundsAsync endpoint
        * Added referer to V5Api.Account.GetConvertQuoteAsync endpoint
    * Updated CoinEx.Net to version 7.6.0
        * Added futures API batch endpoints:FuturesApi.Trading.PlaceMultipleOrdersAsync, PlaceMultipleStopOrdersAsync, CancelOrdersAsync and CancelStopOrdersAsync
        * Added spot API batch endpoints: SpotApiV2.Trading.PlaceMultipleOrdersAsync, PlaceMultipleStopOrdersAsync, CancelOrdersAsync and CancelStopOrdersAsync
        * Added stpMode parameters to spot and futures PlaceOrderAsync and PlaceStopOrderAsync endpoints
    * Updated HTX.Net to version 6.0.2
        * Fix deserialization undocumented canceled-source field value
        * Fixed websocket SpotApi queries (GetXX methods)
    * Updated Kucoin.Net to version 5.12.0
        * Added FuturesApi.SubscribeToKlineUpdatesAsync subscription
        * Added FuturesApi.ExchangeData.GetTickersAsync endpoint
        * Added FuturesApi.Trading.GetMaxOpenPositionSizeAsync endpoint
        * Added migration endpoints SpotApi.Account.GetHfMigrationStatusAsync and MigrateHfAccountAsync

* Version 1.10.0 - 09 Aug 2024
    * Updated reference CryptoExchange version to 7.11.0
        * Added ParseString static method on EnumConverter for parsing strings manually
        * Added support for decimal values in System.Text.Json NumberStringConverter 
        * Added support for `null` string values in System.Text.Json DecimalConverter
        * Added support for number deserialization when requesting string in System.Text.Json MessageAccessor.GetValue<T>
        * Added deserialization handling of json values too big to fit decimal value
        * Decreased some memory allocations during rest request authentication
        * Fixed subscriptions trying to send unsubscribe request when the socket connection will be closed anyway
        * Removed SecureString usage in credentials; it's not recommended to be used
        * Removed some extension methods no longer relevant
        * Improved testing checks
    * Updated Binance.Net to version 10.1.1
        * Updated XML code comments
        * Fixed BinanceFuturesAccountAsset MaintMargin deserialization
        * Fixed BinancePosition MaintMargin deserialization
        * Fixed BinancePosition UnrealizedProfit deserialization for Coin-M futures
    * Updated BingX.Net to version 1.8.0
        * Updated XML code comments
        * Fixed PerpetualFuturesApi.Account.SetMarginModeAsync endpoint
    * Updated Bitfinex.Net to version 7.7.0
        * Updated XML code comments
        * Fixed BitfinexPosition model Type enum being nullable
    * Updated Bitget.Net to version 1.9.0
        * Updated XML code comments
        * Fixed order status and order type deserialization futures models
    * Updated BitMart.Net to version 1.1.1
        * Updated XML code comments
        * Added SpotApi.Trading.CancelAllOrdersAsync endpoint
        * Fixed SpotApi.GetSymbolName not being implemented
    * Updated Bybit.Net to version 3.13.0
        * Updated XML code comments
        * Added IsMaker to socketClient.V5Api.SubscribeToMinimalUserTradeUpdatesAsync update model
    * Updated CoinEx.Net to version 7.5.0
        * Updated XML code comments
        * Added deprecation notice to V1 Spot API
    * Updated CoinGecko.Net to version 2.5.0
    * Updated GateIo.Net to version 1.5.0
        * Updated XML code comments
	* Removed Huobi.Net
	* Added HTX.Net, the Huobi.Net package renamed and fully updated
        * Renamed library from Huobi.Net to HTX.Net, following the renaming of the exchange
        * Renamed all models and references from Huobi... to HTX...
        * Renamed UsdtMarginSwapApi to UsdtFuturesApi
        * Renamed some endpoints to match standardized endpoint names
        * Split Margin and SubAccount endpoints into separate topics in the rest SpotApi
        * Split SubAccount endpoints into separate topics in the rest FuturesApi
        * Added UsdtFuturesSymbolOrderBook implementation
        * Added client side ratelimiting
        * Added various missing endpoints
        * Added Usdt Futures API account websocket streams
        * Updated from Newtonsoft.Json to System.Text.Json for json handling
        * Updated code xml comments
        * Updated API documentation references
        * Fixed a large number of bugs
    * Updated Kraken.Net to version 4.11.0
        * Updated XML code comments
    * Updated Kucoin.Net to version 5.11.0
        * Updated XML code comments
        * Add caching for passphrase authentication sign
        * Renamed SpotApi.SubscribeToBestOfferUpdatesAsync to SubscribeToBookTickerUpdatesAsync 
        * Fixed KucoinOrder and KucoinUserTrade model Stop property being nullable Enum
    * Updated Mexc.Net to version 1.7.2
        * Updated XML code comments
        * Fixed deserialization errors due to too large numbers
    * Updated OKX.Net to version 2.3.0
        * Updated CryptoExchange.Net to version 7.11.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.11.0
        * Updated XML code comments
        * Added UnifiedApi.Trading.CheckOrderAsync endpoint
        * Added PositionSide property to UnifiedApi.Account.GetPositionHistoryAsync response model
        * Updated property nullability for OKXInterestAccrued.MarginMode and OKXAlgoOrder.PositionSide properties

* Version 1.9.0 - 02 Aug 2024
    * Added BitMart.Net support

* Version 1.8.0 - 28 Jul 2024
    * Updated CryptoExchange.Net referenced version to 7.10.0
        * Added System.Text.Json NumberStringConverter
        * Added integration testing base class
        * Added AddSecondsString and AddOptionalSecondsString to ParameterCollection
        * Added Decompress method for ReadOnlyMemory using non-GZip deflate
        * Added SocketConnection parameter to SocketConnection PreprocessStreamMessage
        * Fixed websocket reconnect/unsubscribe timing bug
        * Fixed issue in System.Text.Json array object deserialization skipping property when skipping an index
        * Fixed order book logging bug
        * Fixed bug in ParameterCollection AddEnumAsInt
    * Updated Binance to version 10.0.0
        * Switch from Newtonsoft.Json implementation to System.Text.Json for (de)serialization
        * Refactored from old per type enum converter to EnumConverter usage
        * Added SpotApi.Account.GetCommissionRatesAsync endpoint
        * Added UsdFuturesApi.Account.GetSymbolConfigurationAsync endpoint
        * Added UsdFuturesApi.Account.GetAccountConfigurationAsync endpoint
        * Added UsdFuturesApi.Trading.GetPositionsAsync endpoint
        * Added PermissionSets property to SpotApi.ExchangeData.GetExchangeInfoAsync symbol response
        * Updated UsdFuturesApi.Account.GetBalancesAsync to V3
        * Updated UsdFuturesApi.Account.GetAccountInfoAsync to V3
    * Updated BingX to version 1.7.0**
    * Updated Bitfinex to version 7.6.0**
        * Fixed stats endpoints last stats by splitting endpoints into Last and History variants
    * Updated Bitget to version 1.8.0**
        * Fixed body serialization FuturesV2, fixing PlaceMultipleOrders and CancelMultipleOrdersAsync endpoints
        * Fixed futures plan type parameters
        * Fixed spot GetHistoricalKlinesAsync endTime parameter being required
        * Fixed BitgetFuturesOrder response mapping
    * Updated Bybit to version 3.12.0**
        * Added V5Api.Account.GetSpotMarginInterestRateHistoryAsync endpoint
    * Updated CoinEx to version 7.4.0**
    * Updated CoinGecko to version 2.4.0**
    * Updated GateIo to version 1.4.0**
        * Fixed FuturesApi.Trading.GetOrdersAsync status parameter being required
    * Updated Huobi to version 5.6.0**
    * Updated Kraken to version 4.10.0**
    * Updated Kucoin to version 5.10.0**
        * Added SpotApi.Margin.GetMarginMarkPricesAsync endpoint
        * Updated KC-API-KEY-VERSION header from '2' to '3' (V2 keys will still work)
    * Updated Mexc to version 1.6.0**
    * Updated OKX to version 2.2.0**
        * Added RuleType property on UnifiedApi.ExchangeData.GetSymbolsAsync response model
        * Fixed marginMode serialization in multiple endpoints


* Version 1.7.0 - 16 Jul 2024
    * Updated CryptoExchange.Net referenced version to 7.9.0
        * Added some checks in websocket connection handling
        * Added As<T> and AsError<T> methods on untyped WebCallResult
        * Updated System.Text.Json package to version 8.0.4 to fix vulnerability
        * Updated websocket subscription response handling to remove the thread blocking ManualResetEvent usage
        * Updated static logging classes access modifier from internal to public so they can be called in overriden methods
        * Updated some testing object implementations
        * Fixed authentication error when reconnecting an unauthenticated connection which was marked as dedicated query connection
        * Small improvements in SystemTextJsonMessageAccessor
        * Fixed System.Text.Json ArrayConverter implementation nullable value types handling
    * Updated Binance.Net to version 9.12.0
        * Updated internal classes to internal access modifier
        * Updated WebSocket rate limit rule to prevent triggering disconnect
    * Updated Bybit.Net to version 3.11.0
        * Updated internal classes to internal access modifier
        * Added V5Api.Account.GetConvertAssetsAsync
        * Added V5Api.Account.GetConvertQuoteAsync
        * Added V5Api.Account.ConvertConfirmQuoteAsync
        * Added V5Api.Account.GetConvertStatusAsync
        * Added V5Api.Account.GetConvertHistoryAsync
        * Added Convert property to V5Api.Account.GetBrokerAccountInfoAsync and GetBrokerEarningsAsync response models
    * Updated CoinEx.Net to version 7.3.0
        * Updated internal classes to internal access modifier
        * Added SpotApiV2.ExchangeData.GetAssetsAsync endpoint
    * Updated CoinGecko.Net to version 2.3.0
    * Updated GateIo.Net to version 1.3.0
        * Updated internal classes to internal access modifier
        * Added BorrowType property to SpotApi.Account.GetUnifiedAccountLoanHistoryAsync response model
        * Added AccumelatedSize to FuturesApi.Trading.GetPositionCloseHistoryAsync response model
    * Updated Huobi.Net to version 5.5.0
        * Updated internal classes to internal access modifier
    * Updated BingX.Net to version 1.6.0
        * Updated internal classes to internal access modifier
        * Added PerpetualFuturesApi.ExchangeData.GetTickersAsync endpoint
        * Added PerpetualFuturesApi.ExchangeData.GetLastTradePricesAsync endpoint
        * Added PerpetualFuturesApi.ExchangeData.GetFundingRatesAsync endpoint
        * Added SpotApi.ExchangeData.GetLastTradesAsync endpoint
        * Added SpotApi.Account.GetUserIdAsync endpoint
        * Added SpotApi.Account.GetApiKeyPermissionsAsync endpoint
        * Added sync parameter to SpotApi.Trading.PlaceMultipleOrdersAsync
        * Updated API endpoint docs references
        * Fixed Spot and Futures KeepAliveUserStreamAsync endpoint
        * Fixed clientOrderId deserialization in websocket order updates
    * Updated Bitget.Net to version 1.7.0
        * Updated internal classes to internal access modifier
        * Fixed deserialization error on BitgetPosition model
        * Fixed positionSide parameter on FuturesApiV2.Trading.PlaceOrderAsync endpoint
        * Fixed websocket error response identification
        * Fixed CreateTime and UpdateTime deserialization on FuturesApiV2.Trading.GetPositionHistoryAsync
    * Updated Mexc.Net to version 1.5.0
        * Updated internal classes to internal access modifier
        * Fixed StartTime and EndTime mapping on MexcStreamKline model
    * Updated OKX.Net to version 2.1.0
        * Fixed error during parsing of error response
        * Fixed exception during CancelOrderAsync error response
        * Updated internal classes to internal access modifier
    * Updated Kraken.Net to version 4.9.0
    * Updated Kucoin.Net to version 5.9.0
        * Updated internal classes to internal access modifier

* Version 1.6.0 - 03 Jul 2024
    * Updated CryptoExchange.Net referenced version to 7.8.0
        * Updated single endpoint limit configuration
        * Added LongConverter for nullable longs
        * Updated SystemTextJsonComparer logic
        * Fixed request ids not matching in logging
        * Added nullable int converter for System.Text.Json
        * Small fixes in tests
    * Updated Binance to 9.11.1
        * Updated ratelimiting for per-endpoint limits 
    * Updated BingX to 1.5.0
        * Added TakeProfit/StopLoss parameters to perpetual futures order endpoints
        * Added rate limiting ratelimiting implementation
        * Updated BingXPosition model
    * Updated Bitfinex to 7.4.3
        * Fixed SpotApi.Account.GetMovementsDetailsAsync deserialization
        * Fixed SpotApi.SubscribeToDerivativesUpdatesAsync subscription
        * Fixed funding info subscription
    * Updated Bitget to 1.6.1
        * Updated ratelimiting for per-endpoint limits
        * Fixed V1 socket subscriptions
        * Fixed FuturesApiV2.Trading.GetOpenOrdersAsync deserialization
        * Updated V2 websocket kline interval Enum values
    * Updated Bybit to 3.10.3
        * Added Turkey environment
        * Added prelisting properties to V5 linear/inverse tickers and symbols response models
        * Fixed OrderBook model deserialization when updateId is too large for integer
    * Updated CoinEx to 7.2.1
        * Added FuturesApi.ExchangeData.GetPremiumIndexPriceHistoryAsync endpoint
    * Updated CoinGecko to 2.2.10
    * Updated GateIo to 1.2.1
        * Updated ratelimiting for per-endpoint limits
    * Updated Huobi to 5.4.1
    * Updated Kraken to 4.8.1
        * Updated KrakenAllocatedAmount model
    * Updated Kucoin to 5.8.3
        * Fixed incorrect response mapping SpotApi.HfTrading.PlaceMultipleOrdersAsync
        * Fixed CancelAfter parameter on SpotApi.HfTrading.PlaceMultipleOrdersAsync endpoint
        * Removed symbol base parameter from SpotApi.HfTrading.PlaceMultipleOrdersAsync as its not needed
    * Updated Mexc to 1.4.1
    * Updated OKX to 2.0.0
        * Added client side rate limiting
        * Added Trading.CancelAllAfterAsync endpoint
        * Updated json serializer from Newtonsoft.Json to System.Text.Json
        * Updated request sending to new CryptoExchange.Net implementation
        * Updated all enum conversions to use new EnumConverter
        * Updated websocket kline subscriptions models to IEnumerable
        * Updated AccountBillSubType enum values
        * Updated AccountBillType enum values
        * Updated FundingBillType enum values
        * Updated InstrumentAlias enum values
        * Updated various response models
        * Updated response checking from every endpoint to central method
        * Renamed all enums, OKX prefix removed. For example OKXOrderSide is now OrderSide
        * Renamed OrderType.MarketOrder to OrderType.Market
        * Renamed OrderType.LimitOrder to OrderType.Limit
        * Renamed Candlestick references to Kline
        * Renamed OKXPeriod to KlineInterval
        * Renamed Account.GetAccountPositionsAsync to GetPositionsAsync
        * Renamed Account.GetAccountPositionHistoryAsync to GetPositionHistoryAsync
        * Renamed Account.GetAccountPositionRiskAsync to GetPositionRiskAsync
        * Renamed Account.SetAccountPositionModeAsync to SetPositionModeAsync
        * Renamed Account.GetAccountLeverageAsync to GetLeverageAsync
        * Renamed Account.SetAccountLeverageAsync to SetLeverageAsync
        * Renamed Account.GetLightningWithdrawalsAsync to GetLightningWithdrawalAsync
        * Renamed ExchangeData.GetRubik* to GetTradeStats*
        * Cleanup unnused types

* Version 1.5.0 - 25 Jun 2024
    * Updated CryptoExchange.Net referenced version to 7.7.2
        * Caching support
            * Caching is supported for GET requests within a certain time frame
            * Enable caching by setting CachingEnabled to true in the client options
            * Added DataSource to CallResult object
        * Dedicated websocket connection
            * Added functionality for always having a connection open which can then be used for order operations
            * This eliminates the initial connection time for the first request
            * WebSocket connection can be prepared by calling PrepareConnectionsAsync on the Api client, for example `await binanceSocketClient.SpotApi.PrepareConnectionsAsync()`. This is only needed initially; it will be reconnected when connection is lost.
        * Added CancellationToken support for websocket queries
        * Added SocketConnection parameter to SocketApiClient.GetAuthenticationRequest method
        * Added ObjectStringConverter base converter for deserializing nested json strings
        * Fixed websocket issue with ratelimiting and reconnecting interaction
        * Fixed rate limiting issue with sub-millisecond delays
        * Fixed websocket connection will now close if authentication fails because of not set credentials
		* Fixed ratelimiting issue possibly creating negative delays
        * Updated websocket reconnection handling and options, added backoff policy
        * Removed check for confirmed subscription as data often is pushed before the subscription is confirmed
	
	* Updated Binance to 9.11.0
	    * Added dedicated connection configuration; a websocket connection can now be established before making the first request by calling `binanceSocketClient.SpotApi.PrepareConnectionsAsync();`
        * Added CancellationToken optional parameter to websocket requests
        * Updated response models from classes to records
	* Updated BingX to 1.3.2
	* Updated Bitfinex to 7.4.1
	    * Updated response models from classes to records
        * Fixed exception during order status parsing
        * Fixed SpotApi.ExchangeData.GetLiquidationsAsync deserializations
    * Updated Bitget to 1.5.1
        * Added V2 SpotApi and V2 Futures API implementation
	* Updated Bybit to 3.10.1
	    * Added V5 websocket order placement API
        * Updated response models from classes to records
        * Added and updated DCP endpoints end subscription
        * Added dedicated connection configuration; a websocket connection can now be established before making the first request by calling `bybitSocketClient.V5PrivateApi.PrepareConnectionsAsync();`
        * Fixed deserialization issue BybitPosition model
    * Updated CoinEx to 7.2.0
        * Updated response models from classes to records
    * Updated CoinGecko to 2.2.9
    * Updated GateIo to 1.2.0
        * Added dedicated connection configuration; a websocket connection can now be established before making the first request by calling `gateIoSocketClient.SpotApi.PrepareConnectionsAsync();`
        * Added SpotApi.Account.GetGTDeductionStatusAsync endpoint
        * Added SpotApi.Account.SetGTDeductionStatusAsync endpoint
	* Updated Huobi to 5.4.0
        * Updated response models from classes to records
    * Updated Kraken to 4.8.0
        * Updated response models from classes to records
        * Added CancellationToken optional parameter to websocket requests
    * Updated Kucoin to 5.8.0
	    * Added missing HF/ProAccount endpoints
        * Renamed ProAccount SpotApi topic to HFTrading
        * Added FuturesApi.Account.GetPositionHistoryAsync endpoint Added FuturesApi.Account.GetTradingFeeAsync endpoint
        * Added SpotApi.SubscribeToIsolatedMarginPositionUpdatesAsync subscription
    	* Added SpotApi.Margin.GetCrossMarginSymbolsAsync endpoint
        * Added SpotApi.Margin.SetLeverageMultiplierAsync
        * Added SpotApi.HfTrading.GetMarginSymbolsWithOpenOrdersAsync endpoint
        * Updated response models from classes to records
    * Updated Mexc to 1.4.0
    	* Added websocket connection ratelimit
        * Updated SpotApi.Account.WithdrawAsync parameters and SpotApi.Account.GetUserAssetsAsync response
        * Updated response models from classes to records
    * Updated OKX to 1.11.1
	    * Added CancellationToken optional parameter to websocket requests
        * Added dedicated connection configuration; a websocket connection can now be established before making the first request by calling `okxSocketClient.UnifiedApi.PrepareConnectionsAsync();`
        * Fixed deserialization issue in OkxTicker
        * Fixed deserialization issue in SetLeverage
	
* Version 1.3.1 - 17 Jun 2024
    * Updated GateIo to 1.0.1
		* Fixed startTime/endTime filtering on multiple endpoints
	* Updated BingX to 1.3.1
		* Fixed bingXClient.PerpetualFuturesApi.ExchangeData.GetContractsAsync response parsing by updating Status mapping
	* Updated OKX to 1.10.1
		* Fixed deserialization issue in market sell websocket order updates

* Version 1.3.0 - 12 Jun 2024
    * Added Gate.io implementation
	* Updated CryptoExchange.Net referenced version to 7.6.0
		* Added support for specifying seperate uri and body parameters
		* Added support for different message and handling generic types on socket queries
		* Added support for PATCH http method requests
		* Added support for setting http request body to a specific type directly
		* Split DataEvent.Topic into StreamId and Symbol properties
		* Added support for negative time values parsing
		* Added some helper methods for converting DataEvent to CallResult
		* Added support for GZip/Deflate automatic decompressing in the default HttpClient
		* Updated some testing methods
    * Updated Binance to 9.10.0
		* Added new SpotApi.Trading.PlaceOtoOrderListAsync and SpotApi.Trading.PlaceOtocoOrderListAsync endpoints
		* Fixed GetProductsAsync endpoints by allowing automatic decompression
    * Updated Bitfinex to 7.3.0
	* Updated BingX to 1.3.0
	* Updated Bitget to 1.4.0
	* Updated Bybit to 3.9.0
		* Added socketClient.V5PrivateApi.SubscribeToMinimalUserTradeUpdatesAsync private subscription
	* Updated CoinEx to 7.1.0
	* Updated CoinGecko to 2.2.8
	* Updated Huobi to 5.3.0
	* Updated Kraken to 4.7.0
		* Fix Asset not set on response model in SpotApi.Account.GetAvailableBalancesAsync
	* Updated Kucoin to 5.6.0
	* Updated OKX to 1.10.0

* Version 1.2.0 - 02 Jun 2024
	* Added missing Huobi API to IExchangeRestClient interface
	* Updated Binance to 9.9.8
		* Added SpotApi.Account.GetAccountVipLevelAndStatusAsync endpoint
		* Added UsdFuturesApi.Account.GetBnbBurnStatusAsync and UsdFuturesApi.Account.SetBnbBurnStatusAsync endpoints
		* Added missing GoodTillDate TimeInForce conversion
	* Updated BingX to 1.2.0
		* Added PerpetualFuturesApi.SubscribeToPartialOrderBookUpdatesAsync, PerpetualFuturesApi.SubscribeToKlineUpdatesAsync and PerpetualFuturesApi.SubscribeToTickerUpdatesAsync subscriptions for all symbols
		* Added PerpetualFuturesApi.Trading.GetPositionAndMarginInfoAsync endpoint
		* Added optional symbol parameter PerpetualFuturesApi.ExchangeData.GetContractsAsync
		* Updated BingXWithdrawal response model
		* Updated BingXPosition response model
	* Updated Bitget to 1.3.8
		* Added simulated product types to BitgetInstrumentType enum
	* Updated Bybit to 3.8.9
		* Added missing StopLossTakeProfitMode enum value
		* Added Status property to V5Api.Account.CreateUniversalTransfer response model
		* Added cursor parameter to V5Api.ExchangeData.GetRiskLimitAsync
	* Updated Kraken to 4.6.6
		* Added margin parameter to websocket SpotApi.PlaceOrderAsync
		* Added countryCode parameter to SpotApi.ExchangeData.GetSymbolsAsync
	* Updated Mexc to 1.2.5
		* Added SpotApi.Account.GetTradeFeeAsync endpoint
	* Updated OKX to 1.9.0
		* Added UnifiedApi.Account.GetAssetValuationAsync endpoint
		* Renamed BestAskSize to BestAskQuantity in OKXTicker model
		* Fixed OKXSocketOptions not using OKXApiCredentials

* Version 1.1.0
    * Added support for GlobalExchangeOptions when constructing clients without dependency injection
	* Updated CryptoExchange.Net to 7.5.2
        * Added testing implementations
        * Small refactor AuthenticationProvider to allow better testing
        * Change result of MessageAccessor.Read methods to CallResult so error can be returned
        * Moved some DateTimeConverter logic to seperate methods to allow access from outside converters
		* Fixed SetApiCredentials not correctly being used by rate limiter causing exception
	* Updated Binance to 9.9.7
	    * Updated multiple response models
        * Fixed multiple bugs after new, more thorough unit testing implementation
        * Removed duplicate SpotApi.Trading.ConvertTransferAsync and GetConvertTransferHistoryAsync endpoints
        * Updated CoinFuturesApi.Account.GetBracketsAsync to V2 endpoint
        * Updated CoinFuturesApi.Trading.PlaceMultipleOrdersAsync orders parameter from array to IEnumerable
	* Updated BingX to 1.1.1
        * Removed need for API credentials in certain ExchangeData calls
        * Renamed PerpetualFutures.Trading.GetClosedOrderAsync to GetClosedOrdersAsync
        * Changed PerpetualFutures.SubscribeToUserDataUpdatesAsync handlers to be nullable
        * Fixed SpotApi.SubscribeToBalanceUpdatesAsync update handling
        * Various small fixes
	* Updated Bitfinex to 7.2.8
	* Updated Bitget to 1.3.7
	* Updated Bybit to 3.8.8
	    * Split PurchaseLeverageTokenAsync and RedeemLeverageTokenAsync response models
        * Updated various response models
        * Fixed PurchaseLeverageTokenAsync, RedeemLeverageTokenAsync and GetLeverageTokenOrderHistoryAsync request path
	* Updated CoinEx to 7.0.5
	* Updated CoinGecko to 2.2.7
	* Updated Huobi to 5.2.8
	* Updated Kraken to 4.6.5
        * Updated various models
        * Fixed deserialization issue in SpotApi.ExchangeData.GetSymbolsAsync endpoint
	* Updated Kucoin to 5.5.5
        * Added SpotApi.Trading.GetOcoOrderByClientOrderIdAsync to interface
		* Fixed universal transfer endpoint
        * Fixed FuturesApi.SubscribeToStopOrderUpdatesAsync deserialization
        * Updated various response models
	* Updated Mexc to 1.2.4
	* Updated OKX to 1.8.4

* Version 1.0.0 - 28 Apr 2024
    * Initial version