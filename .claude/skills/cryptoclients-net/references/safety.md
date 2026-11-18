# Operational considerations

## Multi-exchange outcomes

Fan-out creates independent requests, not a transaction. An order accepted on one exchange is not rolled back when another fails. Preserve successful results and account/exchange identity. Discovery can omit unsupported exchanges, so an empty result sequence does not prove every requested exchange was contacted successfully.

Specify the intended exchanges and trading modes before authenticated operations. `GetImplementations` can yield several implementations on one exchange; executing all matches can duplicate an account-changing operation. Prefer one deliberately selected implementation per intended account/product. Inspect outer and nested batch results where the concrete endpoint supplies per-item outcomes.

## Credentials and trading semantics

Typed credentials, dynamic credential fields, environments, and account identifiers differ by exchange. Keep secrets, signers, passphrases, and account data out of source and logs. Separate user client identity from exchange identity; changing credentials on a shared client can affect concurrent requests.

Shared contracts normalize data without guaranteeing identical account, position-mode, margin, fee, time-in-force, trigger, or reduce-only semantics. Verify capability parameter rules and quantity units. A limit order can execute immediately; rounding does not validate balance, notional, or account settings. Use native APIs when the required behavior is not represented by the shared contract.

## Ambiguous submissions and retries

Timeouts, disconnects, or cancellation after submission can leave an order, transfer, or withdrawal accepted remotely. Query the intended account/exchange and use supported identifiers for correlation before repeating a mutation. Neither `Error.IsTransient` nor a client identifier guarantees safe resubmission. Cancellation can race with fills; reconcile orders, fills, and positions after acknowledgement.

For public reads, bounded retries can use transient-error hints, cancellation, and backoff. Keep aggregate request volume and per-exchange rate limits in mind. Retry the affected exchange rather than replaying successful writes across the whole fan-out.

## Subscriptions, books, and trackers

Close every successful subscription on partial setup and shutdown. `UnsubscribeAllAsync` affects every subscription on that aggregate, so use it only when that scope is intended. A cancellation request does not instantly establish that all callback work has completed.

Starting books or trackers can open multiple sockets and issue snapshots. Check startup outcomes, account for interruption/reconnection, and stop/dispose owned services. A cross-exchange book combines asynchronous sources: prices are not an atomic snapshot and gross spreads exclude fees, executable size, inventory, and transfer constraints. User-data tracker state can lag the exchange and must not replace reconciliation after an ambiguous mutation.
