# CryptoClients.Net Benchmark Results

This document summarizes local benchmark results comparing `CryptoClients.Net` with CCXT for REST and WebSocket workloads. The benchmark uses the repository benchmark projects under `Benchmark/Client` and `Benchmark/Server`, with a local Binance-compatible mock server so both libraries parse the same response shapes without external network variance.

## Summary

`CryptoClients.Net` is the more performant solution in these benchmarks, especially for WebSocket trade ingestion and memory efficiency.

For REST, elapsed time is broadly similar to CCXT on simple server-time and ticker calls, but `CryptoClients.Net` allocates far less memory. For WebSocket trade streams, `CryptoClients.Net` is dramatically faster and uses a fraction of the memory.

## REST Results

| Method | Mean | Error | StdDev | Ratio | RatioSD | Gen0 | Allocated | Alloc Ratio |
|---|---:|---:|---:|---:|---:|---:|---:|---:|
| CCXT_ServerTime | 330.1 ms | 2.99 ms | 4.00 ms | 0.97 | 0.01 | 1000.0000 | 13.95 MB | 2.56 |
| CryptoClientsNet_ServerTime | 338.7 ms | 1.50 ms | 2.01 ms | 1.00 | 0.01 | 333.3333 | 5.45 MB | 1.00 |
| CCXT_Ticker | 562.4 ms | 5.16 ms | 6.71 ms | 1.66 | 0.02 | 2000.0000 | 26.38 MB | 4.84 |
| CryptoClientsNet_AggregateTicker | 571.7 ms | 3.68 ms | 4.91 ms | 1.69 | 0.02 | - | 8.28 MB | 1.52 |
| CryptoClientsNet_DirectTicker | 572.3 ms | 2.87 ms | 3.83 ms | 1.69 | 0.01 | - | 6.76 MB | 1.24 |

### REST Analysis

The REST server-time benchmark is close in wall-clock time: CCXT is about 2.5% faster in this run, while `CryptoClients.Net` allocates substantially less memory. `CryptoClientsNet_ServerTime` allocates 5.45 MB versus CCXT's 13.95 MB, or about 61% less allocation.

For ticker requests, elapsed time is effectively comparable between CCXT and `CryptoClients.Net` in this local benchmark. The more meaningful difference is allocation:

- `CryptoClientsNet_DirectTicker`: 6.76 MB allocated
- `CryptoClientsNet_AggregateTicker`: 8.28 MB allocated
- `CCXT_Ticker`: 26.38 MB allocated

That means direct `CryptoClients.Net` ticker access uses about 74% less memory than CCXT, and aggregate `CryptoClients.Net` ticker access uses about 69% less memory than CCXT. The aggregate wrapper adds a modest allocation cost over direct access, but remains much more memory efficient than CCXT while providing exchange-agnostic routing.

## WebSocket Results

| Method | Mean | Error | StdDev | Ratio | RatioSD | Gen0 | Gen1 | Allocated | Alloc Ratio |
|---|---:|---:|---:|---:|---:|---:|---:|---:|---:|
| CryptoClientsNet_DirectTrades | 166.4 ms | 2.36 ms | 3.07 ms | 1.00 | 0.03 | 8000.0000 | - | 99.64 MB | 1.00 |
| CryptoClientsNet_AggregateTrades | 167.9 ms | 3.85 ms | 5.13 ms | 1.01 | 0.04 | 10000.0000 | - | 120.76 MB | 1.21 |
| CCXT_Trades | 1,599.4 ms | 109.07 ms | 145.61 ms | 9.61 | 0.88 | 397000.0000 | 50000.0000 | 4445.36 MB | 44.61 |

### WebSocket Analysis

The WebSocket results strongly favor `CryptoClients.Net`.

`CryptoClientsNet_DirectTrades` completes in 166.4 ms, while `CCXT_Trades` takes 1,599.4 ms. In this benchmark, CCXT is roughly 9.6x slower for trade ingestion.

Memory usage shows an even larger gap:

- `CryptoClientsNet_DirectTrades`: 99.64 MB allocated
- `CryptoClientsNet_AggregateTrades`: 120.76 MB allocated
- `CCXT_Trades`: 4,445.36 MB allocated

CCXT allocates about 44.6x more memory than direct `CryptoClients.Net` for the WebSocket trade benchmark. It also triggers substantially more Gen0 collections and Gen1 collections, while the `CryptoClients.Net` runs do not show Gen1 collections in the reported data.

The aggregate `CryptoClients.Net` WebSocket path is very close to direct access in elapsed time: 167.9 ms versus 166.4 ms. The aggregate path allocates about 21% more than direct access, which is the cost of the exchange-agnostic wrapper, but it still allocates far less than CCXT and maintains nearly identical throughput.

## Benchmark Context

The benchmark compares local REST and WebSocket calls against a mock Binance-compatible server. This keeps the comparison focused on client-side request, response, parsing, dispatch, and WebSocket message handling overhead instead of external exchange latency.

Benchmark numbers can vary by hardware, runtime version, build configuration, and background system load. Run the benchmark projects in Release mode and keep the local server running before starting the client benchmarks for best stability.
