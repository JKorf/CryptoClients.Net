# ![.CryptoClients.Net](https://github.com/JKorf/CryptoClients.Net/blob/a1b8acedaabeb8366372180384a286dd3dc63a09/CryptoClients.Net/Icon/icon.png) CryptoClients.Net  

[![.NET](https://img.shields.io/github/actions/workflow/status/JKorf/CryptoClients.Net/dotnet.yml?style=for-the-badge)](https://github.com/JKorf/CryptoClients.Net/actions/workflows/dotnet.yml) [![Nuget downloads](https://img.shields.io/nuget/dt/CryptoClients.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net) ![License](https://img.shields.io/github/license/JKorf/CryptoClients.Net?style=for-the-badge)

CryptoClients.Net is a collection of different cryptocurrency exchange client libraries based on the same [base library](https://jkorf.github.io/CryptoExchange.Net/). CryptoClients.Net bundles the different client libraries in a single package and adds some additional tools to make use of them. The client libraries offer access to market data, Spot and Futures trading and various other topics depending on the API.

For more information on what CryptoExchange.Net and it's client libraries offers see the [Documentation](https://jkorf.github.io/CryptoExchange.Net/).

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

## Get the library
[![Nuget version](https://img.shields.io/nuget/v/CryptoClients.net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net)  [![Nuget downloads](https://img.shields.io/nuget/dt/CryptoClients.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net)

	dotnet add package CryptoClients.Net
	
## How to use  
### Get a client
There are 2 main clients, the `ExchangeRestClient` and `ExchangeSocketClient`, for accessing the REST and Websocket API respectively. All exchange API's are available via these clients.  
Alternatively exchange specific clients can be used, for example `BinanceRestClient` or `KucoinSocketClient`.
Either create new clients directly or use Dotnet dependency injection:
```csharp
// Construction
var restClient = new ExchangeRestClient();
var socketClient = new ExchangeSocketClient();


// Dependency injection, allows the injection of `IExchangeRestClient`, `IExchangeSocketClient`, `IExchangeOrderBookFactory` and for all exchanges the `I[ExchangeName]RestClient`, `I[ExchangeName]SocketClient` and `I[ExchangeName]OrderBookFactory` types
services.AddCryptoClients();
```

### Configuration
Clients can be configured when doing the dependency injection registration, or when constructing the clients. Configuration can be done for all exchanges/clients, can be set per exchange or a combination:
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

### Using the client
There are multiple options for accessing exchange API's. Options 1 and 2 allow access to the full exchange API while option 3 uses a common interface which allows exchange agnostic requesting, but is therefor limited in functionality.  
Option 3 is currently only supported for the Spot REST API's.
```csharp
// Option 1
// Use exchange clients directly, full functionality
var kucoinClient1 = new KucoinRestClient();
var binanceClient1 = new BinanceRestClient();
var binanceResult1 = await binanceClient1.SpotApi.ExchangeData.GetTickerAsync("ETHUSDT");
var kucoinResult1 = await kucoinClient1.SpotApi.ExchangeData.GetTickerAsync("ETH-USDT");

// Option 2
// Use exchange client via ExchangeRestClient, full functionality
var restClient2 = new ExchangeRestClient();
var baseAsset2 = "ETH";
var quoteAsset2 = "USDT";
var binanceResult2 = await restClient2.Binance.SpotApi.ExchangeData.GetTickerAsync(restClient2.Binance.SpotApi.FormatSymbol(baseAsset2, quoteAsset2));
var kucoinResult2 = await restClient2.Kucoin.SpotApi.ExchangeData.GetTickerAsync(restClient2.Kucoin.SpotApi.FormatSymbol(baseAsset2, quoteAsset2));

// Option 3
// Use unified spot client via GetUnifiedSpotClient, most generic but only supports common functionality
var restClient3 = new ExchangeRestClient();
var baseAsset3 = "ETH";
var quoteAsset3 = "USDT";
var unifiedBinanceClient3 = restClient3.GetUnifiedSpotClient(Exchange.Binance);
var unifiedKucoinClient3 = restClient3.GetUnifiedSpotClient(Exchange.Kucoin);
var binanceResult3 = await unifiedBinanceClient3.GetTickerAsync(unifiedBinanceClient3.GetSymbolName(baseAsset3, quoteAsset3));
var kucoinResult3 = await unifiedKucoinClient3.GetTickerAsync(unifiedKucoinClient3.GetSymbolName(baseAsset3, quoteAsset3));
```

For information on the specific exchange clients, dependency injection, response processing and more see the [CryptoExchange.Net documentation](https://jkorf.github.io/CryptoExchange.Net) or have a look at the examples [here](https://github.com/JKorf/CryptoClients.Net/tree/main/Examples). See the [CryptoExchange.Net examples](https://github.com/JKorf/CryptoExchange.Net/tree/master/Examples) for client examples which also apply to CryptClients.Net

### Supported Exchanges
The following API's are included in CryptoClients.Net:

|Exchange|Repository|Nuget|
|--|--|--|
|Binance|[JKorf/Binance.Net](https://github.com/JKorf/Binance.Net)|[![Nuget version](https://img.shields.io/nuget/v/Binance.net.svg?style=flat-square)](https://www.nuget.org/packages/Binance.Net)|
|BingX|[JKorf/BingX.Net](https://github.com/JKorf/BingX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.BingX.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.BingX.Net)|
|Bitfinex|[JKorf/Bitfinex.Net](https://github.com/JKorf/Bitfinex.Net)|[![Nuget version](https://img.shields.io/nuget/v/Bitfinex.net.svg?style=flat-square)](https://www.nuget.org/packages/Bitfinex.Net)|
|Bitget|[JKorf/Bitget.Net](https://github.com/JKorf/Bitget.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.Bitget.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.Bitget.Net)|
|Bybit|[JKorf/Bybit.Net](https://github.com/JKorf/Bybit.Net)|[![Nuget version](https://img.shields.io/nuget/v/Bybit.net.svg?style=flat-square)](https://www.nuget.org/packages/Bybit.Net)|
|CoinEx|[JKorf/CoinEx.Net](https://github.com/JKorf/CoinEx.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinEx.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinEx.Net)|
|CoinGecko|[JKorf/CoinGecko.Net](https://github.com/JKorf/CoinGecko.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinGecko.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinGecko.Net)|
|Gate.io|[JKorf/GateIo.Net](https://github.com/JKorf/GateIo.Net)|[![Nuget version](https://img.shields.io/nuget/v/GateIo.net.svg?style=flat-square)](https://www.nuget.org/packages/GateIo.Net)|
|Huobi/HTX|[JKorf/Huobi.Net](https://github.com/JKorf/Huobi.Net)|[![Nuget version](https://img.shields.io/nuget/v/Huobi.net.svg?style=flat-square)](https://www.nuget.org/packages/Huobi.Net)|
|Kraken|[JKorf/Kraken.Net](https://github.com/JKorf/Kraken.Net)|[![Nuget version](https://img.shields.io/nuget/v/KrakenExchange.net.svg?style=flat-square)](https://www.nuget.org/packages/KrakenExchange.Net)|
|Kucoin|[JKorf/Kucoin.Net](https://github.com/JKorf/Kucoin.Net)|[![Nuget version](https://img.shields.io/nuget/v/Kucoin.net.svg?style=flat-square)](https://www.nuget.org/packages/Kucoin.Net)|
|Mexc|[JKorf/Mexc.Net](https://github.com/JKorf/Mexc.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.Mexc.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.Mexc.Net)|
|OKX|[JKorf/OKX.Net](https://github.com/JKorf/OKX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.OKX.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.OKX.Net)|

## Discord
[![Nuget version](https://img.shields.io/discord/847020490588422145?style=for-the-badge)](https://discord.gg/MSpeEtSY8t)  
A Discord server is available [here](https://discord.gg/MSpeEtSY8t). Feel free to join for discussion and/or questions around the CryptoExchange.Net and implementation libraries.

## Support the project
I develop and maintain this package on my own for free in my spare time, any support is greatly appreciated.

### Donate
Make a one time donation in a crypto currency of your choice. If you prefer to donate a currency not listed here please contact me.

**Btc**:  bc1q277a5n54s2l2mzlu778ef7lpkwhjhyvghuv8qf  
**Eth**:  0xcb1b63aCF9fef2755eBf4a0506250074496Ad5b7   
**USDT (TRX)**  TKigKeJPXZYyMVDgMyXxMf17MWYia92Rjd

### Sponsor
Alternatively, sponsor me on Github using [Github Sponsors](https://github.com/sponsors/JKorf). 

## Release notes
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