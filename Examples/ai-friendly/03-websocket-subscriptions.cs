using CryptoClients.Net.Clients;
using CryptoClients.Net.Enums;
using CryptoExchange.Net.SharedApis;

var shared = new ExchangeSharedApiClient();
using var shutdown = new CancellationTokenSource();
try
{
    var matches = shared.GetCapabilities(SharedCapabilities.Tickers.SubscribeTicker,
        TradingMode.Spot, new[] { Exchange.Binance, Exchange.OKX });
    var request = new SubscribeTickerRequest(new SharedSymbol(TradingMode.Spot, "BTC", "USDT"));
    await foreach (var result in matches.SubscribeAllAsync(request,
        update => Console.WriteLine($"{update.Exchange}: {update.Data.LastPrice}"), shutdown.Token))
    {
        if (!result.Success)
            Console.WriteLine($"{result.Exchange}: {result.Error}");
    }
    await Task.Delay(TimeSpan.FromSeconds(30));
}
finally
{
    shutdown.Cancel();
    await shared.UnsubscribeAllAsync();
}
