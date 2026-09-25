# CryptoClients.Net AI API Quick Map

Use this file to route common intents to the correct CryptoClients.Net surface. Prefer Shared API V2 for new exchange-agnostic code. If a capability, request type, or parameter is unclear, inspect `CryptoExchange.Net.SharedApis` and the specific exchange package source instead of inventing it.

## Client Roots

| Intent | Use |
|---|---|
| V2 shared capability access | `new ExchangeSharedApiClient()` / `IExchangeSharedApiClient` |
| Full exchange REST APIs or V1 aggregate REST | `new ExchangeRestClient()` / `IExchangeRestClient` |
| Full exchange sockets or V1 aggregate sockets | `new ExchangeSocketClient()` / `IExchangeSocketClient` |
| Dependency injection | `services.AddCryptoClients(...)` |
| Direct-construction configuration | `new CryptoClientsConfiguration(builder => ...)` |
| Global configuration | `builder.ConfigureGlobal(...)` |
| Per-exchange configuration | `builder.ConfigureBinance(...)`, `builder.ConfigureOKX(...)`, etc. |
| Typed credentials | `GlobalExchangeOptions.ApiCredentials = new ExchangeCredentials { ... }` |
| Runtime V1 credentials | `restClient.SetApiCredentials(exchange, DynamicCredentials)` |
| Credential shape discovery | `ExchangeCredentials.GetDynamicCredentialInfo(tradingMode, exchange)` |

`EnabledExchanges` limits initialization and aggregate routing. Accessing a disabled strongly typed exchange property throws `InvalidOperationException`.

## Shared API V2 Discovery

| Intent | Use |
|---|---|
| Get the V2 client for an exchange | `sharedClient.GetClient(exchange)` |
| Resolve one preferred operation for one exchange | `sharedClient.GetCapability<T>(exchange, tradingMode)` |
| Resolve one exact operation for one exchange | `sharedClient.GetCapability(exchange, SharedCapabilities...., tradingMode)` |
| Resolve one preferred implementation per exchange | `sharedClient.GetCapabilities<T>(tradingMode, transport, exchanges)` |
| Resolve an exact operation across exchanges | `sharedClient.GetCapabilities(SharedCapabilities...., tradingMode, exchanges)` |
| Resolve every matching transport/API surface | `sharedClient.GetImplementations<T>(...)` |
| Compile-time discovery for one exchange | Strongly typed properties such as `sharedClient.Binance.SpotRest` |

Capability lookup is the support check. Handle `null` from `GetCapability`. `GetCapabilities` returns at most one preferred match per exchange; `GetImplementations` may return multiple matches for an exchange.

## V2 Execution And Results

| Intent | Use |
|---|---|
| Call one resolved capability | `resolution.Capability.OperationAsync(request)` |
| Run an operation across capabilities | `capabilities.ExecuteAllAsync(request)` |
| Process results as they arrive | `await foreach (var result in ...)` |
| Collect an async sequence | `await results.WaitAllAsync()` |
| Identify the exchange | `result.Exchange` or `data.Exchange` |
| Read response data | Check `result.Success`, then use `result.Data` |
| Handle failure | `result.Error` |

Each exchange succeeds or fails independently. Do not treat an aggregate sequence as having one global success state.

## Common V2 Capabilities

| User intent | Capability |
|---|---|
| Get a ticker | `IGetTicker` / `SharedCapabilities.Tickers.GetTicker` |
| Get all tickers | `IGetAllTickers` / `SharedCapabilities.Tickers.GetAllTickers` |
| Get an order book | `IGetOrderBook` / `SharedCapabilities.OrderBooks.GetOrderBook` |
| Get recent trades | `IGetRecentTrades` / `SharedCapabilities.Trades.GetRecentTrades` |
| Get klines | `IGetKlines` / `SharedCapabilities.Klines.GetKlines` |
| Get spot or futures symbols | `IGetSpotSymbols` / `IGetFuturesSymbols` |
| Get balances | `IGetBalances` / `SharedCapabilities.Balances.GetBalances` |
| Get open orders | `IGetOpenSpotOrders` / `IGetOpenFuturesOrders` |
| Place an order | `IPlaceSpotOrder` / `IPlaceFuturesOrder` |
| Cancel an order | `ICancelSpotOrder` / `ICancelFuturesOrder` |
| Get positions | `IGetPositions` / `SharedCapabilities.Positions.GetPositions` |
| Get funding rates | `IGetFundingRateHistory` / `SharedCapabilities.Funding.GetFundingRateHistory` |

Use `SharedSymbol` and V2 request models. Pass `TradingMode` during discovery where an operation differs between spot, linear futures, inverse futures, or other modes. Inspect `resolution.Capability.Options` for supported modes and parameter rules.

## V2 WebSocket

| User intent | Capability or action |
|---|---|
| Subscribe to tickers | `ISubscribeTickerSocket` / `SharedCapabilities.Tickers.SubscribeTicker` |
| Subscribe to trades | `ISubscribeTradesSocket` / `SharedCapabilities.Trades.SubscribeTrades` |
| Subscribe to klines | `ISubscribeKlinesSocket` / `SharedCapabilities.Klines.SubscribeKlines` |
| Subscribe to order books | `ISubscribeOrderBookSocket` / `SharedCapabilities.OrderBooks.SubscribeOrderBook` |
| Subscribe across exchanges | `capabilities.SubscribeAllAsync(request, handler, cancellationToken)` |
| Close one successful subscription | `subscription.Data.CloseAsync()` |
| Close subscriptions created with a token | Cancel that token |
| Close all shared-client subscriptions | `sharedClient.UnsubscribeAllAsync()` |

Always inspect every subscription result. For direct exchange socket clients, use that client's `UnsubscribeAsync(subscription.Data)` method.

## V1 Compatibility Surface

V1 remains supported on `ExchangeRestClient` and `ExchangeSocketClient`.

| Intent | Use |
|---|---|
| V1 aggregate REST | `restClient.GetSpotTickerAsync(...)`, `GetOrderBookAsync(...)`, etc. |
| V1 shared interface discovery | `restClient.GetSpotTickerClient(exchange)`, `socketClient.GetTickerClient(...)`, etc. |
| V1 aggregate socket | `socketClient.SubscribeToTickerUpdatesAsync(...)`, etc. |
| Stop all V1 aggregate sockets | `socketClient.UnsubscribeAllAsync()` |

V1 multi-exchange calls return per-exchange results. Check every `.Success` before reading `.Data`.

## Direct Exchange Access

| User intent | Use |
|---|---|
| Full Binance REST/socket API | `restClient.Binance` / `socketClient.Binance` |
| Full OKX REST/socket API | `restClient.OKX` / `socketClient.OKX` |
| Full exchange-specific API | `restClient.*` / `socketClient.*` |
| CoinGecko REST platform | `restClient.CoinGecko` |
| Polymarket REST/socket platform | `restClient.Polymarket` / `socketClient.Polymarket` |

Direct properties expose the corresponding exchange package. Inspect that package before generating endpoint-specific names, parameters, or models.

## Order Books And Trackers

| User intent | Use |
|---|---|
| Create cross-exchange order book | `orderBookFactory.CreateCrossExchange(symbol, minimalDepth, exchanges, exchangeParameters)` |
| Create one exchange order book | `orderBookFactory.Create(exchange, symbol, minimalDepth, exchangeParameters)` |
| Create many individual order books | `orderBookFactory.Create(symbol, minimalDepth, exchanges, exchangeParameters)` |
| Create trade tracker | `trackerFactory.CreateTradeTracker(exchange, symbol, limit, period, exchangeParameters)` |
| Create kline tracker | `trackerFactory.CreateKlineTracker(exchange, symbol, interval, limit, period, exchangeParameters)` |
| Create spot/futures user tracker | `CreateUserSpotDataTracker(s)` / `CreateUserFuturesDataTracker(s)` |

## Common Routing Pitfalls

| Do not use | Use instead |
|---|---|
| Raw exchange HTTP calls | Shared capabilities or direct exchange clients |
| Hardcoded native symbols in shared calls | `new SharedSymbol(tradingMode, baseAsset, quoteAsset)` |
| Assumed universal support | Capability discovery and `null` handling |
| `.Data` without a success check | Branch on each result's `.Success` |
| `GetImplementations` when one match per exchange is wanted | `GetCapabilities` |
| Assumed key/secret credentials | Typed credentials or dynamic credential discovery |
| Per-request client construction | Reused clients or DI |
| Shared APIs for exchange-specific options | `restClient.Binance`, `restClient.OKX`, etc. |
