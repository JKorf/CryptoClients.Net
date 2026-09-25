using CryptoClients.Net;
using CryptoClients.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using System.Diagnostics;

var symbols = new[]
{
    // Symbols to retrieve
    new SharedSymbol(TradingMode.Spot, "BTC", "USDT"),
    new SharedSymbol(TradingMode.Spot, "ETH", "USDT"),
    new SharedSymbol(TradingMode.Spot, "XRP", "USDT")
};

var client = new ExchangeSharedApiClient();
foreach (var symbol in symbols)
{
    Console.WriteLine($"{symbol.BaseAsset}/{symbol.QuoteAsset}");

    // Method 1, using WaitAllAsync will return all results when all requests have finished
    var sw = Stopwatch.StartNew();
    var tickers = await client.GetCapabilities(SharedCapabilities.Tickers.GetTicker, TradingMode.Spot)
        .ExecuteAllAsync(new GetTickerRequest(symbol))
        .WaitAllAsync();
    foreach (var result in tickers)
        Console.WriteLine($"{result.Exchange}: {result.Data?.LastPrice}, result in {sw.ElapsedMilliseconds}ms");
    sw.Stop();
    Console.WriteLine();
    Console.WriteLine($"Method 1, All exchanges completed in {sw.ElapsedMilliseconds}ms");
    Console.WriteLine();

    // Method 2, without using WaitAllAsync results will be returned whenever a request is finished instead of waiting for all requests
    sw.Restart();
    await foreach (var result in client.GetCapabilities(SharedCapabilities.Tickers.GetTicker, TradingMode.Spot)
        .ExecuteAllAsync(new GetTickerRequest(symbol)))
    {
        Console.WriteLine($"{result.Exchange}: {result.Data?.LastPrice}, result in {sw.ElapsedMilliseconds}ms");
    }
    sw.Stop();

    Console.WriteLine();
    Console.WriteLine($"Method 2, All exchanges completed in {sw.ElapsedMilliseconds}ms");
    Console.WriteLine();
}

Console.ReadLine();
