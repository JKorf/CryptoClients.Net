
using CryptoClients.Net;
using CryptoClients.Net.Enums;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;

var symbol = new SharedSymbol(TradingMode.PerpetualLinear, "ETH", "USDT");
var socketClient = new ExchangeSocketClient();

// Subscribe to trade updates for the specified exchange
foreach (var subResult in await socketClient.SubscribeToTradeUpdatesAsync(new SubscribeTradeRequest(symbol), LogTrades, [Exchange.Binance, Exchange.HTX, Exchange.OKX]))
    Console.WriteLine($"{subResult.Exchange} subscribe result: {subResult.Success} {subResult.Error}");

Console.ReadLine();

void LogTrades(ExchangeEvent<SharedTrade[]> update)
{
    foreach (var item in update.Data)
        Console.WriteLine($"{update.Exchange.PadRight(10)} | {item.Quantity} @ {item.Price}");    
}