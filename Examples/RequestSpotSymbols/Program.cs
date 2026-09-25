using CryptoClients.Net;
using CryptoClients.Net.Clients;
using CryptoExchange.Net.SharedApis;

var client = new ExchangeSharedApiClient();
// Method 1, using WaitAllAsync will return all results when all requests have finished
var symbols = await client.GetCapabilities(SharedCapabilities.Symbols.GetSpotSymbols)
    .ExecuteAllAsync(new GetSymbolsRequest())
    .WaitAllAsync();
foreach (var result in symbols)
{
    if (!result.Success)
    {
        Console.WriteLine($"{result.Exchange}: {result.Error}");
        continue;
    }

    Console.WriteLine($"{result.Exchange} - first 3 symbols");
    foreach(var symbol in result.Data.Take(3))
        Console.WriteLine($"  {symbol.BaseAsset} {symbol.QuoteAsset} -> {symbol.Name}");
    Console.WriteLine();
}

// Method 2, without using WaitAllAsync results will be returned whenever a request is finished instead of waiting for all requests
await foreach (var result in client.GetCapabilities(SharedCapabilities.Symbols.GetSpotSymbols)
    .ExecuteAllAsync(new GetSymbolsRequest()))
{
    if (!result.Success)
    {
        Console.WriteLine($"{result.Exchange}: {result.Error}");
        continue;
    }

    Console.WriteLine($"{result.Exchange} - first 3 symbols");
    foreach (var symbol in result.Data.Take(3))
        Console.WriteLine($"  {symbol.BaseAsset} {symbol.QuoteAsset} -> {symbol.Name}");
    Console.WriteLine();
}


Console.ReadLine();
