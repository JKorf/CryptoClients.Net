
using CryptoClients.Net;
using CryptoClients.Net.Enums;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.SharedApis.Models;
using CryptoExchange.Net.SharedApis.Models.Socket;
using CryptoExchange.Net.SharedApis.ResponseModels;

var symbol = new SharedSymbol(TradingMode.PerpetualLinear, "ETH", "USDT");
var socketClient = new ExchangeSocketClient();

// Subscribe to trade updates for the specified exchange
await foreach (var subResult in socketClient.SubscribeToTradeUpdatesAsyncEnumerable(new SubscribeTradeRequest(symbol), LogTrades, [Exchange.Binance, Exchange.HTX, Exchange.OKX]))
    Console.WriteLine($"{subResult.Exchange} subscribe result: {subResult.Success} {subResult.Error}");

Console.ReadLine();

void LogTrades(ExchangeEvent<IEnumerable<SharedTrade>> update)
{
    foreach (var item in update.Data)
        Console.WriteLine($"{update.Exchange.PadRight(10)} | {item.Quantity} @ {item.Price}");    
}