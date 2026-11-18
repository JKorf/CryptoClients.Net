// Install CryptoClients.Net. V2 fan-out with per-exchange results and missing-capability reporting.
using CryptoClients.Net.Clients;
using CryptoClients.Net.Enums;
using CryptoExchange.Net.SharedApis;

var shared = new ExchangeSharedApiClient();
var exchanges = new[] { Exchange.Binance, Exchange.Bybit, Exchange.OKX };
var matches = shared.GetCapabilities(
    SharedCapabilities.Tickers.GetTicker.Rest, TradingMode.Spot, exchanges);
var missing = exchanges.Except(matches.Select(match => match.Exchange), StringComparer.OrdinalIgnoreCase);
foreach (var exchange in missing)
    Console.WriteLine($"No matching capability: {exchange}");
var request = new GetTickerRequest(new SharedSymbol(TradingMode.Spot, "BTC", "USDT"));
var results = await Task.WhenAll(matches.Select(async match =>
    (Match: match, Result: await match.Capability.GetTickerAsync(request))));
foreach (var item in results)
    Console.WriteLine(item.Result.Success
        ? $"{item.Match.Exchange}: {item.Result.Data.LastPrice}"
        : $"{item.Match.Exchange}: {item.Result.Error}");
