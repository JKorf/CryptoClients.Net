using CryptoClients.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using System.Collections.Concurrent;

var cache = new ConcurrentDictionary<string, List<ExchangeTicker>>();
var symbols = new[]
{
    // Symbols to track
    new SharedSymbol(TradingMode.Spot, "BTC", "USDT"),
    new SharedSymbol(TradingMode.Spot, "ETH", "USDT"),
    new SharedSymbol(TradingMode.Spot, "XRP", "USDT")
};

var client = new ExchangeSocketClient();
foreach (var symbol in symbols) 
{
    // Subscribe to ticker updates on all exchanges for each symbol
    var result = await client.SubscribeToTickerUpdatesAsync(new SubscribeTickerRequest(symbol), x =>
    {
        if (!cache.ContainsKey(x.Exchange))
            cache[x.Exchange] = new List<ExchangeTicker>();

        var value = cache[x.Exchange].SingleOrDefault(c => c.Symbol == symbol.BaseAsset);
        if (value == null)
            cache[x.Exchange].Add(new ExchangeTicker { Symbol = symbol.BaseAsset });
        else
            value.Price = x.Data.LastPrice;
    });

    // Output any failed subscriptions
    foreach (var failed in result.Where(x => !x.Success))
        Console.WriteLine($"{failed.Exchange}: {failed.Error}");
}

// Small delay to display any failed subscription messages
await Task.Delay(3000);

// Loop continuously
while (true)
{
    Console.Clear();

    foreach (var symbol in symbols)
    {
        Console.WriteLine($"{symbol.BaseAsset}");
        foreach (var exchange in cache) 
        {
            var value = exchange.Value.SingleOrDefault(x => x.Symbol == symbol.BaseAsset)?.Price;
            if (value == null)
                continue;

            Console.WriteLine($"{exchange.Key}: {value}");
        }
        Console.WriteLine();
    }

    await Task.Delay(500);
}


class ExchangeTicker
{
    public string Symbol { get; set; } = string.Empty;
    public decimal? Price { get; set; }
}