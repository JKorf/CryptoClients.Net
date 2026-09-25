# Copilot Instructions for CryptoClients.Net

This repository is **CryptoClients.Net**, a C#/.NET aggregate client library for multiple cryptocurrency exchange APIs. It is part of the CryptoExchange.Net ecosystem.

When generating code that consumes CryptoClients.Net, follow these conventions.

## Use CryptoClients.Net for multi-exchange workflows

Do not generate raw `HttpClient` calls to exchange endpoints. Prefer Shared API V2 through `ExchangeSharedApiClient` for new exchange-agnostic code. Use the V1 aggregate clients or direct exchange clients where appropriate.

## Client setup

```csharp
using CryptoClients.Net;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.SharedApis;

IExchangeSharedApiClient sharedClient = new ExchangeSharedApiClient();
IExchangeRestClient restClient = new ExchangeRestClient();
IExchangeSocketClient socketClient = new ExchangeSocketClient();
```

For services, prefer `services.AddCryptoClients(...)` and inject `IExchangeSharedApiClient`, `IExchangeRestClient`, `IExchangeSocketClient`, `IExchangeOrderBookFactory`, `IExchangeTrackerFactory`, or `IExchangeUserClientProvider`. For direct construction with shared settings, pass a `CryptoClientsConfiguration` to the clients.

## Result handling

Capability lookup returns `null` when an operation is unsupported. REST and subscription operations return per-exchange results. Always check `.Success` before reading `.Data`, and handle aggregate failures independently.

## API structure

- `sharedClient.GetCapability<T>(exchange, tradingMode)` resolves one preferred V2 capability for one exchange.
- `sharedClient.GetCapabilities<T>(...)` resolves one preferred implementation per exchange; use `ExecuteAllAsync` or `SubscribeAllAsync` to run them in parallel.
- `sharedClient.GetImplementations<T>(...)` returns every matching transport/API-surface implementation and can return multiple entries per exchange.
- `sharedClient.Binance.SpotRest`, etc. provide compile-time V2 capability discovery for one exchange.
- `ExchangeRestClient` and `ExchangeSocketClient` retain the V1 aggregate APIs and expose full direct clients through `.Binance`, `.Kucoin`, `.OKX`, etc.

## Shared symbols

Use `SharedSymbol`, not hardcoded exchange symbol formats, when using aggregate or shared API methods:

```csharp
var symbol = new SharedSymbol(TradingMode.Spot, "BTC", SharedSymbol.UsdOrStable);
var tickerCapability = sharedClient.GetCapability<IGetTicker>("Binance", TradingMode.Spot);
if (tickerCapability is null) return;
var ticker = await tickerCapability.Capability.GetTickerAsync(new GetTickerRequest(symbol));
```

For cross-exchange USD/stable quote routing, prefer `SharedSymbol.UsdOrStable` instead of hardcoding `USDT` when USDC/USD variants are acceptable.

## Credentials

Use `ExchangeCredentials` for typed configuration, or `SetApiCredentials(exchange, DynamicCredentials)` for runtime-driven credentials. Do not assume every exchange uses only API key and API secret.

## WebSocket pattern

For V2 subscriptions, check every result and pass a cancellation token. Close one successful subscription with `subscription.Data.CloseAsync()` or all shared-client subscriptions with `sharedClient.UnsubscribeAllAsync()`. Direct exchange socket clients use `UnsubscribeAsync(subscription.Data)`.

## Avoid

- Raw exchange HTTP calls.
- Synchronous `.Result` or `.Wait()`.
- Instantiating clients per request.
- Reading `.Data` before checking `.Success`.
- Assuming every exchange supports every shared interface.
- Confusing `GetCapabilities` (one preferred match per exchange) with `GetImplementations` (all matches).
- Guessing credential fields or symbol formats.

## Reference

For detailed patterns and pitfalls see `AGENTS.md`, `llms.txt`, and `llms-full.txt` in the repository root, plus `docs/ai-api-map.md` and `Examples/ai-friendly/`.
