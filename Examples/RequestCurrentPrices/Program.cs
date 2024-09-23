
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
    // For each symbol async stream the price request result from each exchange
    await foreach (var result in client.GetSpotTickerAsyncEnumerable(new GetTickerRequest(symbol)))
        Console.WriteLine($"{result.Exchange}: {result.Data.LastPrice}, result in {sw.ElapsedMilliseconds}ms");
    sw.Stop();
    Console.WriteLine($"All exchanges completed in {sw.ElapsedMilliseconds}ms");
    Console.WriteLine();
}

Console.ReadLine();
