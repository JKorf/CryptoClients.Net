// 05-credentials-and-error-handling.cs
//
// Demonstrates: typed credentials, dynamic credentials, per-exchange failures,
// and retrying transient aggregate REST errors.
//
// Setup: dotnet add package CryptoClients.Net

using Binance.Net;
using CryptoClients.Net;
using CryptoClients.Net.Models;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using Kucoin.Net;
using OKX.Net;

// ---- 1. TYPED CREDENTIAL CONFIGURATION ----
var client = new ExchangeRestClient(options =>
{
    options.ApiCredentials = new ExchangeCredentials
    {
        Binance = new BinanceCredentials("BINANCE_KEY", "BINANCE_SECRET"),
        Kucoin = new KucoinCredentials("KUCOIN_KEY", "KUCOIN_SECRET", "KUCOIN_PASSPHRASE"),
        OKX = new OKXCredentials("OKX_KEY", "OKX_SECRET", "OKX_PASSPHRASE")
    };
});

// ---- 2. DYNAMIC CREDENTIAL CONFIGURATION ----
// Use dynamic credentials when credentials are user supplied and the exchange is
// not known at compile time. First inspect the required fields.
var credentialInfo = ExchangeCredentials.GetDynamicCredentialInfo(TradingMode.Spot, "OKX");
Console.WriteLine(credentialInfo == null
    ? "OKX dynamic credentials are not available"
    : $"OKX credential param1: {credentialInfo.Param1Description}, param2: {credentialInfo.Param2Description}");

client.SetApiCredentials("OKX", new DynamicCredentials(
    TradingMode.Spot,
    "OKX_KEY",
    param1: "OKX_SECRET",
    param2: "OKX_PASSPHRASE"));

// ---- 3. PER-EXCHANGE RESULT HANDLING ----
var symbol = new SharedSymbol(TradingMode.Spot, "BTC", "USDT");
var request = new GetTickerRequest(symbol);

var results = await client.GetSpotTickerAsync(request, new[] { "Binance", "Kraken", "OKX" });
foreach (var result in results)
{
    if (!result.Success)
    {
        Console.WriteLine($"{result.Exchange} failed");
        Console.WriteLine($"Code:      {result.Error?.Code}");
        Console.WriteLine($"Message:   {result.Error?.Message}");
        Console.WriteLine($"Transient: {result.Error?.IsTransient}");
        continue;
    }

    Console.WriteLine($"{result.Exchange}: {result.Data.LastPrice}");
}

// ---- 4. RETRY TRANSIENT FAILURES ----
async Task<ExchangeWebResult<T>> WithRetry<T>(
    Func<Task<ExchangeWebResult<T>>> call,
    int maxAttempts = 3)
{
    ExchangeWebResult<T> last = default!;

    for (var attempt = 1; attempt <= maxAttempts; attempt++)
    {
        last = await call();
        if (last.Success)
            return last;

        if (last.Error?.IsTransient != true)
            return last;

        await Task.Delay(TimeSpan.FromMilliseconds(250 * Math.Pow(2, attempt)));
    }

    return last;
}

var ticker = await WithRetry(
    () => client.GetSpotTickerAsync("Binance", request));

Console.WriteLine(ticker.Success
    ? $"Retry result: {ticker.Data.LastPrice}"
    : $"Retry failed: {ticker.Error}");

// Common variations:
//   Balances:               client.GetBalancesAsync(new GetBalancesRequest(...), exchanges)
//   Spot order placement:   client.PlaceSpotOrderAsync("Binance", new PlaceSpotOrderRequest(...))
//   Futures leverage:       client.SetLeverageAsync("Bybit", new SetLeverageRequest(...))
//   Listen keys:            client.StartListenKeysAsync(new StartListenKeyRequest(...), exchanges)
