# AI-Friendly Examples

These examples are optimized for AI coding assistants and quick onboarding. Each file is:

- **Compilable** - drop into a console project with `dotnet add package CryptoClients.Net` and it builds.
- **Self-contained** - single file, no shared helpers.
- **Focused on real aggregate APIs** - examples use `ExchangeRestClient`, `ExchangeSocketClient`, shared request models, direct exchange access, order books, and dynamic credentials.
- **Idiomatic** - follows current CryptoClients.Net 4.x and CryptoExchange.Net shared API patterns.

## Files

| File | What it shows |
|---|---|
| `01-aggregate-tickers.cs` | Query one symbol across multiple exchanges, process array and async-enumerable results |
| `02-direct-and-shared-clients.cs` | Use direct exchange clients and shared client discovery from one aggregate client |
| `03-websocket-subscriptions.cs` | Subscribe to ticker, trade, kline, and order book updates across exchanges with teardown |
| `04-order-books-and-trackers.cs` | Create cross-exchange order books, individual order books, trade trackers, and kline trackers |
| `05-credentials-and-error-handling.cs` | Configure typed and dynamic credentials, handle per-exchange failures, retry transient errors |

## Running

```bash
dotnet new console -n MyCryptoClientsApp
cd MyCryptoClientsApp
dotnet add package CryptoClients.Net
# Copy the example .cs file content into Program.cs
dotnet run
```
