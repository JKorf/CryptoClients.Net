// 01-aggregate-tickers.cs
//
// Demonstrates: aggregate REST requests, shared symbols, per-exchange result handling,
// and async-enumerable fan-out processing.
//
// Setup:
//   dotnet new console -n AggregateTickers && cd AggregateTickers
//   dotnet add package CryptoClients.Net
//   Copy this file content into Program.cs
//   dotnet run

using CryptoClients.Net;
using CryptoExchange.Net.SharedApis;

var client = new ExchangeRestClient();

// SharedSymbol describes the market in exchange-neutral terms. Each exchange client
// maps it to its own symbol format, for example BTCUSDT, BTC-USDT, XBTUSDT, etc.
var symbol = new SharedSymbol(TradingMode.Spot, "BTC", "USDT");
var request = new GetTickerRequest(symbol);
var exchanges = new[] { "Binance", "Bybit", "Kraken", "Kucoin", "OKX" };

// ---- 1. Query selected exchanges and wait for all results ----
var results = await client.GetSpotTickerAsync(request, exchanges);

foreach (var result in results)
{
    if (!result.Success)
    {
        Console.WriteLine($"{result.Exchange} failed: {result.Error}");
        continue;
    }

    Console.WriteLine($"{result.Exchange} {result.Data.Symbol}: {result.Data.LastPrice}");
}

// ---- 2. Query a single exchange with the same shared request model ----
var binanceTicker = await client.GetSpotTickerAsync("Binance", request);
if (binanceTicker.Success)
    Console.WriteLine($"Single exchange result: {binanceTicker.Data.LastPrice}");

// ---- 3. Process responses as soon as each exchange answers ----
await foreach (var ticker in client.GetSpotTickerAsyncEnumerable(request, exchanges))
{
    Console.WriteLine(ticker.Success
        ? $"Fast stream {ticker.Exchange}: {ticker.Data.LastPrice}"
        : $"Fast stream {ticker.Exchange}: {ticker.Error}");
}

// Common variations:
//   All tickers on supported exchanges: client.GetSpotTickersAsync(new GetTickersRequest(...), exchanges)
//   Futures ticker:                    client.GetFuturesTickerAsync(new GetTickerRequest(symbol), exchanges)
//   Best bid/ask:                      client.GetBookTickersAsync(new GetBookTickerRequest(symbol), exchanges)
//   Order book snapshot:               client.GetOrderBookAsync(new GetOrderBookRequest(symbol), exchanges)
