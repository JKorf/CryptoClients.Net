using Binance.Net;
using CryptoClients.Net;
using CryptoClients.Net.Clients;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Models;
using CryptoExchange.Net.SharedApis;

var key = Environment.GetEnvironmentVariable("BINANCE_API_KEY")
    ?? throw new InvalidOperationException("Missing Binance key");
var secret = Environment.GetEnvironmentVariable("BINANCE_API_SECRET")
    ?? throw new InvalidOperationException("Missing Binance secret");
var configuration = new CryptoClientsConfiguration(builder => builder.ConfigureGlobal(options =>
{
    options.EnabledExchanges = new[] { Exchange.Binance };
    options.ApiCredentials = new ExchangeCredentials
    {
        Binance = new BinanceCredentials(key, secret)
    };
}));
var shared = new ExchangeSharedApiClient(configuration);
var match = shared.GetCapability(Exchange.Binance,
    SharedCapabilities.Balances.GetBalances.Rest, TradingMode.Spot);
if (match is null)
    return;
var result = await match.Capability.GetBalancesAsync(new GetBalancesRequest(TradingMode.Spot));
if (!result.Success)
    Console.WriteLine($"{match.Exchange}: {result.Error}");
else
    Console.WriteLine(result.Data);


// Inspect dynamic requirements independently of the typed account read above.
var info = ExchangeCredentials.GetDynamicCredentialInfo(TradingMode.Spot, Exchange.OKX);
if (info is not null)
    Console.WriteLine($"OKX: {info.KeyDescription}; {info.Param1Description}; {info.Param2Description}");
// A transient error is a retry hint for reads; reconcile orders/transfers before resubmitting writes.
