
using CryptoClients.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.SharedApis.Models.Rest;
using System.Diagnostics;

var symbols = new[]
{
    // Symbols to retrieve
    new SharedSymbol(TradingMode.Spot, "BTC", "USDT"),
    new SharedSymbol(TradingMode.Spot, "ETH", "USDT"),
    new SharedSymbol(TradingMode.Spot, "XRP", "USDT")
};

var client = new ExchangeRestClient();
foreach (var symbol in symbols)
{
    Console.WriteLine($"{symbol.BaseAsset}/{symbol.QuoteAsset}");
    var sw = Stopwatch.StartNew();
    // For each symbol request the price and wait untill all requests are completed
    var tickers = await client.GetSpotTickerAsync(new GetTickerRequest(symbol));
    foreach (var result in tickers)
        Console.WriteLine($"{result.Exchange}: {result.Data.LastPrice}, result in {sw.ElapsedMilliseconds}ms");
    sw.Stop();
    Console.WriteLine($"All exchanges completed in {sw.ElapsedMilliseconds}ms");
    Console.WriteLine();
}

Console.ReadLine();
