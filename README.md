# ![.CryptoClients.Net](https://github.com/JKorf/CryptoClients.Net/blob/a1b8acedaabeb8366372180384a286dd3dc63a09/CryptoClients.Net/Icon/icon.png) CryptoClients.Net  

[![.NET](https://img.shields.io/github/actions/workflow/status/JKorf/CryptoClients.Net/dotnet.yml?style=for-the-badge)](https://github.com/JKorf/CryptoClients.Net/actions/workflows/dotnet.yml) ![License](https://img.shields.io/github/license/JKorf/CryptoClients.Net?style=for-the-badge)

CryptoClients.Net is a collection of different cryptocurrency exchange client libraries based on the same [base library](https://jkorf.github.io/CryptoExchange.Net/). CryptoClients.Net bundles the different client libraries in a single package and adds some additional tools to make use of them.

## Features
* Direct full access to 12 different exchanges, public and private data
* Client per exchange, or single client for accessing all exchanges
* Response data is mapped to descriptive models
* Input parameters and response values are mapped to discriptive enum values where possible
* Automatic websocket (re)connection management 
* Client side rate limiting 
* Cient side order book implementation
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

## Get the library
[![Nuget version](https://img.shields.io/nuget/v/CryptoClients.net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net)  [![Nuget downloads](https://img.shields.io/nuget/dt/CryptoClients.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/CryptoClients.Net)

	dotnet add package CryptoClients.Net
	
## How to use  
### Get a client
There are 2 main clients, the `ExchangeRestClient` and `ExchangeSocketClient`, for accessing the REST and Websocket API respectively. All exchange API's are available via these clients.  
Alternatively exchange specific clients can be used, for example `BinanceRestClient` or `KucoinSocketClient`.
Either create new clients directly or use Dotnet dependency injection.

*Construction*
```csharp
// Client for accessing all exchanges
IExchangeRestClient restClient = new ExchangeRestClient();
IExchangeSocketClient socketClient = new ExchangeSocketClient();

// Exchange specific clients
IBinanceRestClient binanceRestClient = new BinanceRestClient();
IKucoinSocketClient kucoinSocketClient = new KucoinSocketClient();
```
*Dependency injection*
```csharp
// Dependency injection, allows the injection of `IExchangeRestClient`, `IExchangeSocketClient` and `IExchangeOrderBookFactory` interfaces
// as well as for all exchanges the `I[ExchangeName]RestClient`, `I[ExchangeName]SocketClient` and `I[ExchangeName]OrderBookFactory` types
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