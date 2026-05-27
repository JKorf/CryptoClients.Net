// 02-direct-and-shared-clients.cs
//
// Demonstrates: full exchange-specific access and shared interface discovery from
// the aggregate ExchangeRestClient.
//
// Setup: dotnet add package CryptoClients.Net

using CryptoClients.Net;
using CryptoExchange.Net.SharedApis;

var client = new ExchangeRestClient();
var symbol = new SharedSymbol(TradingMode.Spot, "ETH", "USDT");

// ---- 1. FULL EXCHANGE-SPECIFIC API ACCESS ----
// CryptoClients.Net does not hide the underlying exchange clients. Use these when
// an exchange-specific endpoint, model, enum, or option is needed.
var binanceTicker = await client.Binance.SpotApi.ExchangeData.GetTickerAsync("ETHUSDT");
if (binanceTicker.Success)
    Console.WriteLine($"Binance direct ticker: {binanceTicker.Data.LastPrice}");

var kucoinTicker = await client.Kucoin.SpotApi.ExchangeData.GetTickerAsync("ETH-USDT");
if (kucoinTicker.Success)
    Console.WriteLine($"Kucoin direct ticker: {kucoinTicker.Data.LastPrice}");

// ---- 2. SHARED CLIENT DISCOVERY FOR ONE EXCHANGE ----
// GetSpotTickerClient returns null when the exchange does not expose that shared
// interface. Always null-check before calling it in generic routers.
var sharedTickerClient = client.GetSpotTickerClient("Binance");
if (sharedTickerClient != null)
{
    var sharedTicker = await sharedTickerClient.GetSpotTickerAsync(new GetTickerRequest(symbol));
    if (sharedTicker.Success)
        Console.WriteLine($"{sharedTicker.Exchange} shared ticker: {sharedTicker.Data.LastPrice}");
}

// ---- 3. ENUMERATE ALL CLIENTS SUPPORTING A CAPABILITY ----
foreach (var tickerClient in client.GetSpotTickerClients())
{
    var result = await tickerClient.GetSpotTickerAsync(new GetTickerRequest(symbol));
    Console.WriteLine(result.Success
        ? $"{tickerClient.Exchange}: {result.Data.LastPrice}"
        : $"{tickerClient.Exchange}: {result.Error}");
}

// ---- 4. GET ALL SHARED CLIENTS FOR AN EXCHANGE ----
var sharedClients = client.GetExchangeSharedClients("OKX", TradingMode.Spot).ToArray();
Console.WriteLine($"OKX spot shared interfaces: {sharedClients.Length}");

var spotSymbols = sharedClients.SpotSymbolRestClient();
if (spotSymbols != null)
{
    var symbolResult = await spotSymbols.GetSpotSymbolsAsync(new GetSymbolsRequest());
    Console.WriteLine(symbolResult.Success
        ? $"OKX spot symbols loaded: {symbolResult.Data.Length}"
        : $"OKX spot symbols failed: {symbolResult.Error}");
}

// Common variations:
//   Balances:          client.GetBalancesClient(TradingMode.Spot, "Binance")
//   Futures orders:    client.GetFuturesOrderClient(TradingMode.PerpetualLinear, "Bybit")
//   Funding rates:     client.GetFundingRateClients(TradingMode.PerpetualLinear)
//   Direct full API:   client.OKX, client.Bybit, client.Kraken, etc.
