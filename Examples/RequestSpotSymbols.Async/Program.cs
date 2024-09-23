
using CryptoClients.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.SharedApis.Models.Rest;
using System.Diagnostics;

var client = new ExchangeRestClient();
var symbols = await client.GetSpotSymbolsAsync(new GetSymbolsRequest());
foreach (var result in symbols)
{
    Console.WriteLine($"{result.Exchange} - first 3 symbols");
    foreach(var symbol in result.Data.Take(3))
        Console.WriteLine($"  {symbol.BaseAsset} {symbol.QuoteAsset} -> {symbol.Name}");
    Console.WriteLine();
}

Console.ReadLine();
