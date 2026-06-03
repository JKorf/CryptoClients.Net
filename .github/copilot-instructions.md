# Copilot Instructions for CryptoClients.Net

This repository is **CryptoClients.Net**, a C#/.NET aggregate client library for multiple cryptocurrency exchange APIs. It is part of the CryptoExchange.Net ecosystem.

When generating code that consumes CryptoClients.Net, follow these conventions.

## Use CryptoClients.Net for multi-exchange workflows

Do not generate raw `HttpClient` calls to exchange endpoints. Use `ExchangeRestClient`, `ExchangeSocketClient`, shared API interfaces, or the exchange-specific clients exposed from the aggregate clients.

## Client setup

```csharp
using CryptoClients.Net;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.SharedApis;

IExchangeRestClient restClient = new ExchangeRestClient();
IExchangeSocketClient socketClient = new ExchangeSocketClient();
```

For services, prefer `services.AddCryptoClients(...)` and inject `IExchangeRestClient`, `IExchangeSocketClient`, `IExchangeOrderBookFactory`, `IExchangeTrackerFactory`, or `IExchangeUserClientProvider`.

## Result handling

Aggregate REST calls return `ExchangeWebResult<T>` or arrays of them. Socket subscriptions return `ExchangeResult<UpdateSubscription>` or arrays of them. Always check `.Success` before reading `.Data`.

## API structure

- `restClient.GetSpotTickerAsync(...)` and similar aggregate methods query one or more exchanges through shared APIs.
- `restClient.GetSpotTickerClient("Binance")` and similar helpers return a shared client interface for a specific exchange when supported.
- `restClient.Binance`, `restClient.Kucoin`, `restClient.OKX`, etc. expose the full exchange-specific REST clients.
- `socketClient.SubscribeToTickerUpdatesAsync(...)` and similar methods subscribe on one or more exchanges.
- `socketClient.Binance`, `socketClient.Kucoin`, `socketClient.OKX`, etc. expose the full exchange-specific socket clients.

## Shared symbols

Use `SharedSymbol`, not hardcoded exchange symbol formats, when using aggregate or shared API methods:

```csharp
var symbol = new SharedSymbol(TradingMode.Spot, "BTC", SharedSymbol.UsdOrStable);
var ticker = await restClient.GetSpotTickerAsync("Binance", new GetTickerRequest(symbol));
```

For cross-exchange USD/stable quote routing, prefer `SharedSymbol.UsdOrStable` instead of hardcoding `USDT` when USDC/USD variants are acceptable.

## Credentials

Use `ExchangeCredentials` for typed configuration, or `SetApiCredentials(exchange, DynamicCredentials)` for runtime-driven credentials. Do not assume every exchange uses only API key and API secret.

## WebSocket pattern

For aggregate subscriptions, check each returned subscription result. Use `await subscription.Data.CloseAsync()` to close one successful aggregate subscription, or `await socketClient.UnsubscribeAllAsync()` on shutdown to close everything. For direct exchange socket clients, use the direct client's `UnsubscribeAsync(subscription.Data)` method.

## Avoid

- Raw exchange HTTP calls.
- Synchronous `.Result` or `.Wait()`.
- Instantiating clients per request.
- Reading `.Data` before checking `.Success`.
- Assuming every exchange supports every shared interface.
- Guessing credential fields or symbol formats.

## Reference

For detailed patterns and pitfalls see `AGENTS.md`, `llms.txt`, and `llms-full.txt` in the repository root, plus `docs/ai-api-map.md` and `Examples/ai-friendly/`.
