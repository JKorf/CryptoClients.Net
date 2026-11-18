using CryptoClients.Net;
using CryptoClients.Net.Clients;
using CryptoClients.Net.Enums;

var configuration = new CryptoClientsConfiguration(builder => builder
    .ConfigureGlobal(options =>
    {
        options.EnabledExchanges = new[] { Exchange.Binance };
        options.RequestTimeout = TimeSpan.FromSeconds(15);
    })
    .ConfigureBinance(options => options.Rest.OutputOriginalData = true));
var shared = new ExchangeSharedApiClient(configuration);
var result = await shared.Rest.Binance.SpotApi.ExchangeData.GetTickerAsync("BTCUSDT");
if (!result.Success)
    Console.WriteLine(result.Error);
else
    Console.WriteLine(result.Data.LastPrice);


// The typed exchange property exposes V2 surfaces, distinct from the native Rest facade.
var match = shared.GetCapability(CryptoClients.Net.Enums.Exchange.Binance,
    CryptoExchange.Net.SharedApis.SharedCapabilities.Symbols.GetSpotSymbols.Rest,
    CryptoExchange.Net.SharedApis.TradingMode.Spot);
if (match is not null)
{
    var symbols = await match.Capability.GetSpotSymbolsAsync(new CryptoExchange.Net.SharedApis.GetSymbolsRequest());
    if (!symbols.Success)
        Console.WriteLine(symbols.Error);
    else
        Console.WriteLine($"Binance symbols: {symbols.Data.Length}");
}
