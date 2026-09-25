
using CryptoClients.Net;
using CryptoClients.Net.Clients;
using CryptoClients.Net.Enums;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;

var symbol = new SharedSymbol(TradingMode.PerpetualLinear, "ETH", "USDT");
var socketClient = new ExchangeSharedApiClient();

// Subscribe to trade updates for the specified exchange
foreach (var subResult in await socketClient.GetCapabilities(SharedCapabilities.Trades.SubscribeTrades, TradingMode.PerpetualLinear, [Exchange.Binance, Exchange.HTX, Exchange.OKX])
    .SubscribeAllAsync(new SubscribeTradeRequest(symbol), LogTrades)
    .WaitAllAsync())
{
    Console.WriteLine($"{subResult.Exchange} subscribe result: {subResult.Success} {subResult.Error}");
}

Console.ReadLine();

void LogTrades(DataEvent<SharedTrade[]> update)
{
    foreach (var item in update.Data)
        Console.WriteLine($"{update.Exchange.PadRight(10)} | {item.Quantities.QuantityInBaseAsset ?? item.Quantities.QuantityInContracts} @ {item.Price}");    
}