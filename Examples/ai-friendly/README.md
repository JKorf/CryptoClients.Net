# Standalone examples

Each `.cs` file is an independent top-level console program. Copy one into `Program.cs` at a time.

| File | Purpose |
| --- | --- |
| [01-aggregate-tickers.cs](01-aggregate-tickers.cs) | V2 fan-out and independent/missing exchange outcomes |
| [02-direct-and-shared-clients.cs](02-direct-and-shared-clients.cs) | Native facade access and V2 symbol discovery |
| [03-websocket-subscriptions.cs](03-websocket-subscriptions.cs) | V2 subscriptions with partial-setup and shutdown cleanup |
| [04-order-books-and-trackers.cs](04-order-books-and-trackers.cs) | Book/tracker factories; creates services without starting them |
| [05-credentials-and-error-handling.cs](05-credentials-and-error-handling.cs) | Typed account credentials, capability lookup, and dynamic field discovery |

```shell
dotnet new console -n MyCryptoClientsApp
dotnet add MyCryptoClientsApp package CryptoClients.Net
# Copy ONE example into MyCryptoClientsApp/Program.cs
dotnet build MyCryptoClientsApp
```

Compilation does not execute exchange operations. Running market-data/subscription examples contacts live exchanges; the credential example requires `BINANCE_API_KEY` and `BINANCE_API_SECRET` and reads the configured account. The subscription program listens for 30 seconds and then closes its owned aggregate subscriptions.

See the [consumer skill](../../.claude/skills/cryptoclients-net/SKILL.md) and [complete projects](../ReadMe.md).
