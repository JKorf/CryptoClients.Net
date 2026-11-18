---
name: cryptoclients-net
description: Build multi-exchange C#/.NET integrations with CryptoClients.Net, including Shared API V2 discovery and fan-out, native exchange access, typed/dynamic credentials, configuration, subscriptions, cross-exchange books, and trackers.
---

# CryptoClients.Net

```shell
dotnet add package CryptoClients.Net
```

Use `ExchangeSharedApiClient` from `CryptoClients.Net.Clients` through `IExchangeSharedApiClient` for portable V2 workflows. `ExchangeRestClient` and `ExchangeSocketClient` from `CryptoClients.Net` retain V1 aggregation and direct native clients. The V2 aggregate's `Rest` and `Socket` properties expose native-client facades; typed exchange properties such as `shared.Binance.SpotRest` expose shared surfaces.

Prefer a narrow capability or typed descriptor for new portable code. `GetCapability` selects one exchange's preferred match or returns `null`; `GetCapabilities` selects one preferred match per exchange; `GetImplementations` can return multiple surfaces/transports per exchange. Specify trading mode, inspect options, and handle absent support. Unsupported exchanges can be omitted from discovery results, so compare the resolved set with the requested set when completeness matters.

Use explicit exchange filters when choosing fan-out. `EnabledExchanges` limits available clients and routing; direct access to disabled exchanges throws. Native client roots, credentials, symbols, and support differ by exchange. Use native APIs when exact behavior cannot be expressed by a shared capability; no other skill is required.

Public data needs no credentials. Configure typed `ExchangeCredentials` for known exchanges; discover the required fields with `GetDynamicCredentialInfo` before supplying `DynamicCredentials`. Credentials, environments, and account context must identify the intended exchange and user.

Check each result's `Success` before `Data` and retain its exchange identity. Keep clients for their workload. Successful subscriptions must be closed on partial setup, cancellation, and shutdown. The aggregate client types do not implement `IDisposable`; use their unsubscribe methods and respect ownership of the native clients/services you create.

## References

- [API surfaces](references/api-surfaces.md): configuration, native/shared routing, capability selection, catalogs, quantities, factories, and credential shapes.
- [Usage](references/usage.md): standalone setup, fan-out, account reads, an explicit order function, subscriptions, native access, symbols, and DI.
- [Operational considerations](references/safety.md): partial multi-exchange outcomes, retry decisions, subscriptions, and account-changing calls.

Checkout-only: [repository instructions](../../../AGENTS.md) and [complete examples](../../../Examples/ReadMe.md). The references above remain usable in the packaged skill.
