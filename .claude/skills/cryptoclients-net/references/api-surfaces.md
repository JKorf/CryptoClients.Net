# API surfaces

## Entry points and selection

| Intent | Entry point |
| --- | --- |
| Portable V2 aggregate | `ExchangeSharedApiClient` / `IExchangeSharedApiClient` |
| One exchange's V2 surfaces | Typed properties such as `shared.Binance.SpotRest` |
| Runtime exchange aggregate | `shared.GetClient(exchange)`, nullable `ISharedApiClientBase` |
| One exchange's preferred capability | `GetCapability(exchange, descriptor, tradingMode)` |
| One preferred capability per exchange | `GetCapabilities(descriptor, tradingMode, exchanges)` |
| Every eligible surface/transport | `GetImplementations(descriptor, tradingMode, exchanges)` |
| Native REST/socket access from V2 | `shared.Rest.Binance`, `shared.Socket.OKX`, etc. |
| V1 aggregation and native access | `ExchangeRestClient` / `ExchangeSocketClient` |
| Global and exchange-specific construction | `CryptoClientsConfiguration` and `ClientConfigurationBuilder` |
| DI | `services.AddCryptoClients(...)` |

`GetCapability` returns a nullable `SharedCapabilityResolution<T>` containing `Capability`, `Options`, `Exchange`, and `Transport`. Discovery makes no exchange request. Specify `TradingMode.Spot`, `PerpetualLinear`, `PerpetualInverse`, or the appropriate mode. `.Rest`/`.Socket` descriptors restrict transport; generic lookup can use `SharedTransport`. A capability's presence does not guarantee every request parameter is supported: inspect its request/exchange parameter rules, limits, authentication needs, and notes.

`GetCapabilities` returns at most one preferred implementation per exchange; `GetImplementations` can return several for the same exchange. Unsupported/disabled exchanges may be absent instead of generating an error result. Use the resolved set to verify mandatory coverage.

## Configuration and credentials

`CryptoClientsConfiguration(builder => builder.ConfigureGlobal(...).ConfigureBinance(...))` combines global and per-exchange settings. `GlobalExchangeOptions` includes credentials, `ApiEnvironments`, request timeout, proxy, caching, rate limiting, reconnect behavior, and `EnabledExchanges`. Enablement controls routing and lazy initialization; accessing a disabled typed property throws rather than silently enabling it. `SharedSymbol.UsdOrStable` is a quote-selection preference when USD/stable variants are acceptable, not equivalence between assets or proof of a listed market.

`ExchangeCredentials` carries typed credentials per exchange. `DynamicCredentials` carries `TradingMode`, a key, and exchange-dependent parameters. `ExchangeCredentials.GetDynamicCredentialInfo(mode, exchange)` identifies supported fields; handle `null` rather than guessing. Configure `ApiCredentials` globally or use `SetApiCredentials(ExchangeCredentials)` / `SetApiCredentials(exchange, DynamicCredentials)` on REST/socket facades. Avoid the obsolete string-only credential setter: key/secret/passphrase cannot represent every signer/account shape. Upbit has no dynamic credential information because its bundled API is public-only.

## Current exchange coverage

V2 typed exchange aggregates: `Aster`, `Binance`, `BingX`, `Bitfinex`, `Bitget`, `Bitstamp`, `Bitunix`, `Bitvavo`, `BloFin`, `Bybit`, `Coinbase`, `CoinW`, `CryptoCom`, `DeepCoin`, `GateIo`, `HTX`, `HyperLiquid`, `Kraken`, `Kucoin`, `LBank`, `Lighter`, `Mexc`, `OKX`, `Pionex`, `Polymarket`, `Tapbit`, `Toobit`, `Upbit`, `Weex`, `WhiteBit`, `XT`.

Native REST properties: `Aster`, `Binance`, `BingX`, `Bitfinex`, `Bitget`, `Bitstamp`, `Bitunix`, `Bitvavo`, `BloFin`, `Bybit`, `Coinbase`, `CoinW`, `CryptoCom`, `DeepCoin`, `GateIo`, `HTX`, `HyperLiquid`, `Kraken`, `Kucoin`, `LBank`, `Lighter`, `Mexc`, `OKX`, `Pionex`, `Polymarket`, `Tapbit`, `Toobit`, `Upbit`, `Weex`, `WhiteBit`, `XT`. Native sockets expose socket-capable libraries. CoinGecko is REST-only and outside the V2 aggregate; access it through the concrete `ExchangeRestClient.CoinGecko` property, which is not part of the aggregate Rest facade contract. Polymarket is available through both native clients and the current V2 aggregate. Native access retains exchange-specific endpoints, symbols, enums, credentials, and models; do not pass shared requests into native methods.

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

Use `SharedSymbol` and V2 request models. Pass `TradingMode` during discovery where an operation differs between spot, linear futures, inverse futures, or other modes. Inspect `resolution.Options` for supported modes and parameter rules.


## Execution and result shapes

Resolved capabilities can be called directly, fanned out with `Task.WhenAll`, or processed as they complete using `ParallelEnumerateAsync` on task sequences. Capability extension helpers also provide `ExecuteAllAsync(request)` and `SubscribeAllAsync(request, handler, cancellationToken)` where supported by the installed capability. `WaitAllAsync()` collects an async sequence; it is not needed for ordinary awaited calls.

| Operation | Result |
| --- | --- |
| REST capability | `HttpResult<T>` |
| Socket request | `QueryResult<T>` |
| Socket subscription | `WebSocketResult<UpdateSubscription>` |
| Transport-independent operation | `IExchangeCallResult<T>` |
| Capability discovery | `SharedCapabilityResolution<T>` |

Attribute each result to its resolution/exchange and inspect errors individually. V1 compatibility methods remain on `ExchangeRestClient` and `ExchangeSocketClient`, such as `GetSpotTickerAsync` and `GetSpotTickerClient`; use V2 for new portable workflows. Their per-exchange results also require individual success checks.

## Asset Classification And Symbol Catalogs

`SharedSpotSymbol` and `SharedFuturesSymbol` classify both sides of a market with:

- `BaseAssetType` and `QuoteAssetType`: `SharedAssetType.Unspecified`, `Crypto`, `Fiat`, or `TradFi`
- `BaseAssetSubType` and `QuoteAssetSubType`: nullable `SharedAssetSubType.StableCoin`, `Equity`, or `Commodity`

Use `Unspecified` when the exchange or client cannot classify an asset. Valid subtype relationships are:

- `Crypto` + `StableCoin`
- `TradFi` + `Equity`
- `TradFi` + `Commodity`
- `Fiat` without a subtype

`GetSymbolsRequest` accepts `baseAssetType`, `baseAssetSubType`, `quoteAssetType`, and `quoteAssetSubType` filters in addition to `tradingMode` and `exchangeParameters`. The same request works with spot and futures symbol methods. Invalid type/subtype combinations fail request validation.

For cached lookup, retrieve a concrete symbol client:

- `IGetSpotSymbolsRest`; after a successful `GetSpotSymbolsAsync(...)`, read `SpotSymbolCatalog`.
- `IGetFuturesSymbolsRest`; after a successful `GetFuturesSymbolsAsync(...)`, read `FuturesSymbolCatalog`.

Both properties are nullable `SharedSymbolCatalog` instances and are maintained separately. `SharedSymbolCatalog.Exchange` identifies the exchange, `Assets` is keyed by asset name and contains `SharedAssetInfo` (`Name`, `Type`, `SubType`), and `Symbols` is keyed by the exchange symbol name. Do not read either catalog before its corresponding symbol fetch.


## Quantities and subscription ownership

Shared requests use `SharedQuantity.Base`, `.Quote`, or `.Contracts` only where the selected operation supports those units. Responses use `SharedOrderQuantity`, with nullable base/quote/contracts quantities; missing units are not zero. Ticker volumes use `Volumes`, book-ticker quantities use `BestBidQuantities`/`BestAskQuantities`, and order books expose `QuantityType`.

Close a successful subscription with `subscription.Data.CloseAsync()`. `shared.UnsubscribeAllAsync()` closes all subscriptions across the owned aggregate's exchanges/transports. Scope cancellation and cleanup to the workload; do not close a shared application singleton's unrelated subscriptions. Direct native socket clients retain their normal unsubscribe methods. Retain successful handles immediately, including partial setup.

## Books, trackers, and DI

`AddCryptoClients` registers the V2 aggregate, enabled exchange services, native/V1 clients, and factories/providers. Inject the aggregate or explicitly selected capabilities when multiple exchanges share an interface.

`IExchangeOrderBookFactory` offers `Create(exchange, symbol, ...)`, `Create(symbol, ..., exchanges)`, and `CreateCrossExchange(symbol, minimalDepth, exchanges, exchangeParameters)`. Check startup results and stop/dispose books with their workload. `IExchangeTrackerFactory` offers trade, kline, and authenticated spot/futures user-data trackers. `CanCreateTradeTracker` and `CanCreateKlineTracker` check dynamic support; creation can return `null`. `IExchangeUserClientProvider` caches aggregate clients by user identifier; maintain account/credential boundaries when reusing them.

Checkout-only: [public interfaces](../../../../CryptoClients.Net/Interfaces), [aggregate implementation](../../../../CryptoClients.Net/Clients/ExchangeSharedApiClient.cs), and [DI/configuration sources](../../../../CryptoClients.Net/ExtensionMethods).
