using CryptoClients.Net;
using CryptoExchange.Net.SharedApis;

var client = new ExchangeRestClient();
// Method 1, GetSpotSymbolsAsync will return all results when all requests have finished
var symbols = await client.GetSpotSymbolsAsync(new GetSymbolsRequest());
foreach (var result in symbols)
{
    Console.WriteLine($"{result.Exchange} - first 3 symbols");
    foreach(var symbol in result.Data.Take(3))
        Console.WriteLine($"  {symbol.BaseAsset} {symbol.QuoteAsset} -> {symbol.Name}");
    Console.WriteLine();
}

// Method 2, GetSpotSymbolsAsyncEnumerable will return results whenever a request is finished instead of waiting for all requests
await foreach (var result in client.GetSpotSymbolsAsyncEnumerable(new GetSymbolsRequest()))
{
    Console.WriteLine($"{result.Exchange} - first 3 symbols");
    foreach (var symbol in result.Data.Take(3))
        Console.WriteLine($"  {symbol.BaseAsset} {symbol.QuoteAsset} -> {symbol.Name}");
    Console.WriteLine();
}


Console.ReadLine();
