# CryptoClients.Net AI API Quick Map

Use this file to route common user intents to the correct CryptoClients.Net member. If a method name, request type, or parameter is not listed here, inspect `CryptoClients.Net/Interfaces/**` and the specific exchange package source before generating code.

## Client Roots

| Intent | Use |
|---|---|
| Aggregate REST calls | `new ExchangeRestClient()` |
| Aggregate WebSocket subscriptions | `new ExchangeSocketClient()` |
| Dependency injection | `services.AddCryptoClients(options => { ... })` |
| Global options | `GlobalExchangeOptions` |
| Typed credentials for many exchanges | `new ExchangeCredentials { Binance = ..., OKX = ... }` |
| Runtime credentials | `SetApiCredentials(exchange, DynamicCredentials)` |
| Credential shape discovery | `ExchangeCredentials.GetDynamicCredentialInfo(tradingMode, exchange)` |
| Supported exchange metadata | `Exchanges.All`, `Exchanges.GetByName(exchange)` |
| Supported exchange/platform names | `Exchange.All`, `Platforms.All` |

## Aggregate REST Result Shapes

| Intent | Use |
|---|---|
| Single exchange request | `Task<ExchangeWebResult<T>> MethodAsync(string exchange, Request request, ...)` |
| Multi-exchange request, wait for all | `Task<ExchangeWebResult<T>[]> MethodAsync(Request request, IEnumerable<string>? exchanges = null, ...)` |
| Multi-exchange request, process first responses first | `IAsyncEnumerable<ExchangeWebResult<T>> MethodAsyncEnumerable(Request request, IEnumerable<string>? exchanges = null, ...)` |
| Read response data | Check `result.Success` first, then read `result.Data` |
| Identify source exchange | `result.Exchange` |
| Handle failure | `result.Error`, `result.Error?.IsTransient` |

## Aggregate REST Market Data

| User intent | CryptoClients.Net member |
|---|---|
| Get spot ticker on one exchange | `client.GetSpotTickerAsync(exchange, new GetTickerRequest(symbol))` |
| Get spot ticker on many exchanges | `client.GetSpotTickerAsync(new GetTickerRequest(symbol), exchanges)` |
| Stream spot ticker responses as completed | `client.GetSpotTickerAsyncEnumerable(new GetTickerRequest(symbol), exchanges)` |
| Get all spot tickers | `client.GetSpotTickersAsync(new GetTickersRequest(...), exchanges)` |
| Get futures ticker | `client.GetFuturesTickerAsync(new GetTickerRequest(symbol), exchanges)` |
| Get all futures tickers | `client.GetFuturesTickersAsync(new GetTickersRequest(...), exchanges)` |
| Get book ticker | `client.GetBookTickersAsync(new GetBookTickerRequest(symbol), exchanges)` |
| Get order book snapshot | `client.GetOrderBookAsync(new GetOrderBookRequest(symbol), exchanges)` |
| Get recent trades | `client.GetRecentTradesAsync(new GetRecentTradesRequest(symbol), exchanges)` |
| Get historical trades | `client.GetTradeHistoryAsync(new GetTradeHistoryRequest(symbol), exchanges)` |
| Get klines/candles | `client.GetKlinesAsync(new GetKlinesRequest(symbol, interval), exchanges)` |
| Get mark price klines | `client.GetMarkPriceKlinesAsync(new GetKlinesRequest(symbol, interval), exchanges)` |
| Get index price klines | `client.GetIndexPriceKlinesAsync(new GetKlinesRequest(symbol, interval), exchanges)` |
| Get funding rate history | `client.GetFundingRateHistoryAsync(new GetFundingRateHistoryRequest(symbol), exchanges)` |
| Get open interest | `client.GetOpenInterestAsync(new GetOpenInterestRequest(symbol), exchanges)` |

## Aggregate REST Symbols And Support Discovery

| User intent | CryptoClients.Net member |
|---|---|
| Get spot symbols on one exchange | `client.GetSpotSymbolsAsync(exchange, new GetSymbolsRequest())` |
| Get spot symbols on many exchanges | `client.GetSpotSymbolsAsync(new GetSymbolsRequest(), exchanges)` |
| Get futures symbols | `client.GetFuturesSymbolsAsync(new GetSymbolsRequest(...), exchanges)` |
| Get spot symbols for a base asset | `client.GetSpotSymbolsForBaseAssetAsync(baseAsset)` |
| Get spot symbols for base asset on one exchange | `client.GetSpotSymbolsForBaseAssetAsync(exchange, baseAsset)` |
| Get futures symbols for a base asset | `client.GetFuturesSymbolsForBaseAssetAsync(baseAsset)` |
| Get futures symbols for base asset on one exchange | `client.GetFuturesSymbolsForBaseAssetAsync(exchange, baseAsset)` |
| Get exchanges supporting a spot symbol name | `client.GetExchangesSupportingSpotSymbolAsync(symbolName)` |
| Get exchanges supporting a spot shared symbol | `client.GetExchangesSupportingSpotSymbolAsync(symbol)` |
| Check spot support on one exchange | `client.SupportsSpotSymbolAsync(exchange, symbol)` |
| Get exchanges supporting a futures symbol name | `client.GetExchangesSupportingFuturesSymbolAsync(symbolName)` |
| Get exchanges supporting a futures shared symbol | `client.GetExchangesSupportingFuturesSymbolAsync(symbol)` |
| Check futures support on one exchange | `client.SupportsFuturesSymbolAsync(exchange, symbol)` |
| Convert shared symbol to exchange name | `client.GetSymbolName(exchange, symbol)` |

## Aggregate REST Account, Assets, Funding, And Transfers

| User intent | CryptoClients.Net member |
|---|---|
| Get assets | `client.GetAssetsAsync(new GetAssetsRequest(...), exchanges)` |
| Get one asset | `client.GetAssetAsync(new GetAssetRequest(...), exchanges)` |
| Get balances | `client.GetBalancesAsync(new GetBalancesRequest(...), exchanges)` |
| Get deposits | `client.GetDepositsAsync(new GetDepositsRequest(...), exchanges)` |
| Get withdrawals | `client.GetWithdrawalsAsync(new GetWithdrawalsRequest(...), exchanges)` |
| Withdraw funds | Use `client.GetWithdrawClient(exchange)` then the shared withdraw client method |
| Transfer funds between account types | `client.TransferAsync(exchange, new TransferRequest(...))` |
| Get fees | `client.GetFeesAsync(new GetFeeRequest(...), exchanges)` |
| Start listen keys | `client.StartListenKeysAsync(new StartListenKeyRequest(...), exchanges)` |
| Keep listen keys alive | `client.KeepAliveListenKeysAsync(new KeepAliveListenKeyRequest(...), exchanges)` |
| Stop listen keys | `client.StopListenKeysAsync(new StopListenKeyRequest(...), exchanges)` |

## Aggregate REST Orders And Positions

| User intent | CryptoClients.Net member |
|---|---|
| Place spot order | `client.PlaceSpotOrderAsync(exchange, new PlaceSpotOrderRequest(...))` |
| Get spot order | `client.GetSpotOrderAsync(exchange, new GetOrderRequest(...))` |
| Get spot order by client order id | `client.GetSpotOrderByClientOrderIdAsync(exchange, new GetOrderRequest(...))` |
| Get spot order trades | `client.GetSpotOrderTradesAsync(exchange, new GetOrderTradesRequest(...))` |
| Cancel spot order | `client.CancelSpotOrderAsync(exchange, new CancelOrderRequest(...))` |
| Cancel spot order by client order id | `client.CancelSpotOrderByClientOrderIdAsync(exchange, new CancelOrderRequest(...))` |
| Place spot trigger order | `client.PlaceSpotTriggerOrderAsync(exchange, new PlaceSpotTriggerOrderRequest(...))` |
| Cancel spot trigger order | `client.CancelSpotTriggerOrderAsync(exchange, new CancelOrderRequest(...))` |
| Get spot open orders | `client.GetSpotOpenOrdersAsync(new GetOpenOrdersRequest(...), exchanges)` |
| Get spot closed orders | `client.GetSpotClosedOrdersAsync(new GetClosedOrdersRequest(...), exchanges)` |
| Get spot user trades | `client.GetSpotUserTradesAsync(new GetUserTradesRequest(...), exchanges)` |
| Place futures order | `client.PlaceFuturesOrderAsync(exchange, new PlaceFuturesOrderRequest(...))` |
| Get futures order | `client.GetFuturesOrderAsync(exchange, new GetOrderRequest(...))` |
| Get futures order by client order id | `client.GetFuturesOrderByClientOrderIdAsync(exchange, new GetOrderRequest(...))` |
| Get futures order trades | `client.GetFuturesOrderTradesAsync(exchange, new GetOrderTradesRequest(...))` |
| Cancel futures order | `client.CancelFuturesOrderAsync(exchange, new CancelOrderRequest(...))` |
| Cancel futures order by client order id | `client.CancelFuturesOrderByClientOrderIdAsync(exchange, new CancelOrderRequest(...))` |
| Close futures position | `client.ClosePositionAsync(exchange, new ClosePositionRequest(...))` |
| Place futures trigger order | `client.PlaceFuturesTriggerOrderAsync(exchange, new PlaceFuturesTriggerOrderRequest(...))` |
| Cancel futures trigger order | `client.CancelFuturesTriggerOrderAsync(exchange, new CancelOrderRequest(...))` |
| Set futures TP/SL | `client.SetFuturesTpSlAsync(exchange, new SetTpSlRequest(...))` |
| Cancel futures TP/SL | `client.CancelFuturesTpSlAsync(exchange, new CancelTpSlRequest(...))` |
| Get positions | `client.GetPositionsAsync(new GetPositionsRequest(...), exchanges)` |
| Get position history | `client.GetPositionHistoryAsync(new GetPositionHistoryRequest(...), exchanges)` |
| Get futures open orders | `client.GetFuturesOpenOrdersAsync(new GetOpenOrdersRequest(...), exchanges)` |
| Get futures closed orders | `client.GetFuturesClosedOrdersAsync(new GetClosedOrdersRequest(...), exchanges)` |
| Get futures user trades | `client.GetFuturesUserTradesAsync(new GetUserTradesRequest(...), exchanges)` |
| Get position mode | `client.GetPositionModeAsync(exchange, new GetPositionModeRequest(...))` |
| Set position mode | `client.SetPositionModeAsync(exchange, new SetPositionModeRequest(...))` |
| Get leverage | `client.GetLeverageAsync(exchange, new GetLeverageRequest(...))` |
| Set leverage | `client.SetLeverageAsync(exchange, new SetLeverageRequest(...))` |

## Shared REST Client Discovery

| User intent | CryptoClients.Net member |
|---|---|
| Get all shared clients for an exchange | `client.GetExchangeSharedClients(exchange, tradingMode)` |
| Get assets clients | `client.GetAssetsClients()` / `client.GetAssetClient(exchange)` |
| Get balance clients | `client.GetBalancesClients(...)` / `client.GetBalancesClient(...)` |
| Get deposit client | `client.GetDepositsClient(exchange)` |
| Get kline client | `client.GetKlineClient(tradingMode, exchange)` |
| Get order book client | `client.GetOrderBookClient(tradingMode, exchange)` |
| Get trade clients | `client.GetRecentTradesClient(...)`, `client.GetTradeHistoryClient(...)` |
| Get withdrawal clients | `client.GetWithdrawalsClient(exchange)`, `client.GetWithdrawClient(exchange)` |
| Get spot ticker client | `client.GetSpotTickerClient(exchange)` |
| Get spot symbol client | `client.GetSpotSymbolClient(exchange)` |
| Get spot order client | `client.GetSpotOrderClient(exchange)` |
| Get spot client-order-id client | `client.GetSpotOrderClientIdClient(exchange)` |
| Get spot trigger order client | `client.GetSpotTriggerOrderClient(exchange)` |
| Get futures symbol client | `client.GetFuturesSymbolClient(tradingMode, exchange)` |
| Get futures ticker client | `client.GetFuturesTickerClient(tradingMode, exchange)` |
| Get futures order client | `client.GetFuturesOrderClient(tradingMode, exchange)` |
| Get futures client-order-id client | `client.GetFuturesOrderClientIdClient(tradingMode, exchange)` |
| Get futures trigger order client | `client.GetFuturesTriggerOrderClient(tradingMode, exchange)` |
| Get futures TP/SL client | `client.GetFuturesTpSlClient(tradingMode, exchange)` |
| Get funding rate client | `client.GetFundingRateClient(tradingMode, exchange)` |
| Get leverage client | `client.GetLeverageClient(tradingMode, exchange)` |
| Get position mode/history clients | `client.GetPositionModeClient(...)`, `client.GetPositionHistoryClient(...)` |
| Get listen key client | `client.GetListenKeyClient(tradingMode, exchange)` |
| Get transfer client | `client.GetTransferClient(exchange, fromAccountType, toAccountType)` |

## Aggregate WebSocket

| User intent | CryptoClients.Net member |
|---|---|
| Subscribe all ticker updates on one exchange | `socketClient.SubscribeToAllTickerUpdatesAsync(exchange, request, handler)` |
| Subscribe all ticker updates on many exchanges | `socketClient.SubscribeToAllTickerUpdatesAsync(request, handler, exchanges)` |
| Subscribe ticker updates | `socketClient.SubscribeToTickerUpdatesAsync(new SubscribeTickerRequest(symbol), handler, exchanges)` |
| Subscribe trade updates | `socketClient.SubscribeToTradeUpdatesAsync(new SubscribeTradeRequest(symbol), handler, exchanges)` |
| Subscribe book ticker updates | `socketClient.SubscribeToBookTickerUpdatesAsync(new SubscribeBookTickerRequest(symbol), handler, exchanges)` |
| Subscribe kline updates | `socketClient.SubscribeToKlineUpdatesAsync(new SubscribeKlineRequest(symbol, interval), handler, exchanges)` |
| Subscribe order book updates | `socketClient.SubscribeToOrderBookUpdatesAsync(new SubscribeOrderBookRequest(symbol), handler, exchanges)` |
| Subscribe balance updates | `socketClient.SubscribeToBalanceUpdatesAsync(new SubscribeBalancesRequest(...), handler, exchanges, listenKeys)` |
| Subscribe spot order updates | `socketClient.SubscribeToSpotOrderUpdatesAsync(new SubscribeSpotOrderRequest(...), handler, exchanges, listenKeys)` |
| Subscribe futures order updates | `socketClient.SubscribeToFuturesOrderUpdatesAsync(new SubscribeFuturesOrderRequest(...), handler, exchanges, listenKeys)` |
| Subscribe user trade updates | `socketClient.SubscribeToUserTradeUpdatesAsync(new SubscribeUserTradeRequest(...), handler, exchanges, listenKeys)` |
| Subscribe position updates | `socketClient.SubscribeToPositionUpdatesAsync(new SubscribePositionRequest(...), handler, exchanges, listenKeys)` |
| Stop one successful aggregate subscription | `subscription.Data.CloseAsync()` |
| Stop aggregate socket client | `socketClient.UnsubscribeAllAsync()` |
| Stop one direct exchange socket subscription | `socketClient.Binance.UnsubscribeAsync(subscription.Data)` or the matching direct exchange socket client |

## Shared Socket Client Discovery

| User intent | CryptoClients.Net member |
|---|---|
| Get ticker socket client | `socketClient.GetTickerClient(tradingMode, exchange)` |
| Get all tickers socket client | `socketClient.GetTickersClient(tradingMode, exchange)` |
| Get trade socket client | `socketClient.GetTradeClient(tradingMode, exchange)` |
| Get book ticker socket client | `socketClient.GetBookTickerClient(tradingMode, exchange)` |
| Get kline socket client | `socketClient.GetKlineClient(tradingMode, exchange)` |
| Get order book socket client | `socketClient.GetOrderBookClient(tradingMode, exchange)` |
| Get balance socket client | `socketClient.GetBalanceClient(tradingMode, exchange)` |
| Get spot order socket client | `socketClient.GetSpotOrderClient(exchange)` |
| Get futures order socket client | `socketClient.GetFuturesOrderClient(tradingMode, exchange)` |
| Get user trade socket client | `socketClient.GetUserTradeClient(tradingMode, exchange)` |
| Get position socket client | `socketClient.GetPositionClient(tradingMode, exchange)` |

## Direct Exchange Access

| User intent | Use |
|---|---|
| Full Binance REST API | `restClient.Binance` |
| Full Binance socket API | `socketClient.Binance` |
| Full OKX REST/socket API | `restClient.OKX` / `socketClient.OKX` |
| Full Bybit REST/socket API | `restClient.Bybit` / `socketClient.Bybit` |
| Full Kraken REST/socket API | `restClient.Kraken` / `socketClient.Kraken` |
| Full * REST/socket API | `restClient.*` / `socketClient.*` |
| Any bundled exchange | Check properties on `IExchangeRestClient` and `IExchangeSocketClient` |
| CoinGecko REST platform | `restClient.CoinGecko` |
| Polymarket REST/socket platform | `restClient.Polymarket` / `socketClient.Polymarket` |

Direct properties expose the full API from the corresponding exchange package. Inspect that package before generating endpoint-specific code.

## Order Books And Trackers

| User intent | Use |
|---|---|
| Create cross-exchange order book | `orderBookFactory.CreateCrossExchange(symbol, minimalDepth, exchanges, exchangeParameters)` |
| Create one exchange order book | `orderBookFactory.Create(exchange, symbol, minimalDepth, exchangeParameters)` |
| Create many individual order books | `orderBookFactory.Create(symbol, minimalDepth, exchanges, exchangeParameters)` |
| Create trade tracker | `trackerFactory.CreateTradeTracker(exchange, symbol, limit, period, exchangeParameters)` |
| Create kline tracker | `trackerFactory.CreateKlineTracker(exchange, symbol, interval, limit, period, exchangeParameters)` |
| Create spot user data tracker | `trackerFactory.CreateUserSpotDataTracker(...)` / `CreateUserSpotDataTrackers(...)` |
| Create futures user data tracker | `trackerFactory.CreateUserFuturesDataTracker(...)` / `CreateUserFuturesDataTrackers(...)` |

## Common Routing Pitfalls

| Do not use | Use instead |
|---|---|
| Raw `HttpClient` calls to exchange APIs | `ExchangeRestClient`, direct exchange clients, or shared clients |
| Hardcoded exchange symbols in shared calls | `new SharedSymbol(tradingMode, baseAsset, quoteAsset)`; use `SharedSymbol.UsdOrStable` for cross-exchange USD/stable quote routing when USDC/USD variants are acceptable |
| One global success flag for multi-exchange calls | Check each `ExchangeWebResult<T>.Success` |
| `.Data` without `.Success` check | Branch on `.Success` first |
| Assumed key/secret credentials | `ExchangeCredentials` or `DynamicCredentials` with `GetDynamicCredentialInfo` |
| Aggregate shared call for an exchange-specific endpoint | `restClient.Binance`, `restClient.OKX`, etc. |
| Per-request client construction | Reused singleton/client from DI |
| Leaving aggregate sockets open | `await subscription.Data.CloseAsync()` for one aggregate subscription or `await socketClient.UnsubscribeAllAsync()` for all aggregate subscriptions |
