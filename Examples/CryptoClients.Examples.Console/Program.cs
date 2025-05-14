using Binance.Net.Clients;
using Binance.Net.SymbolOrderBooks;
using BingX.Net.SymbolOrderBooks;
using Bybit.Net.SymbolOrderBooks;
using CryptoClients.Net;
using CryptoClients.Net.Enums;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using Kucoin.Net.Clients;

// #####################################################################################################################################
// #                                                  CryptoClients.Net examples                                                       #
// #                                                                                                                                   #
// #  Uncomment an example to get started.                                                                                             #
// #  The place order examples will need the API credentials to be set and will try to actually place an order.                        #
// #                                                                                                                                   #
// #  These examples are limited to the Binance, BingX and Bybit exchanges, but the same principles apply to each exchange available   #
// #                                                                                                                                   #
// #####################################################################################################################################

// 1. Request tickers
//await TickerExampleExchangeSpecific();
//await TickerExampleUnified();
//await TickerExampleUnified2();

// 2. Place a new order
//await PlaceOrderExampleExchangeSpecific();
//await PlaceOrderExampleUnified();

// 3. Subscribe to price updates
//await SubscribePriceUpdatesExchangeSpecific();
//await SubscribePriceUpdatesUnified();
//await SubscribePriceUpdatesUnified2();

// 4. Locally synced order books
//await StartOrderBooks();

Console.ReadLine();

async Task TickerExampleExchangeSpecific()
{
    while (true)
    {
        Console.WriteLine("Enter base asset: ");
        var baseAsset = Console.ReadLine();
        Console.WriteLine("Enter quote asset: ");
        var quoteAsset = Console.ReadLine();

        var client = new ExchangeRestClient();
        var resultBinance = client.Binance.SpotApi.ExchangeData.GetTickerAsync(baseAsset + quoteAsset);
        var resultBingX = client.BingX.SpotApi.ExchangeData.GetTickersAsync(baseAsset + "-" + quoteAsset);
        var resultBybit = client.Bybit.V5Api.ExchangeData.GetSpotTickersAsync(baseAsset + quoteAsset);
        await Task.WhenAll(resultBinance, resultBingX, resultBybit);

        Console.WriteLine();
        Console.WriteLine("Exchange prices:");
        Console.WriteLine("Binance:" + (resultBinance.Result.Success ? resultBinance.Result.Data.LastPrice : resultBinance.Result.Error));
        Console.WriteLine("BingX:" + (resultBingX.Result.Success ? resultBingX.Result.Data.Single().LastPrice : resultBingX.Result.Error));
        Console.WriteLine("Bybit:" + (resultBybit.Result.Success ? resultBybit.Result.Data.List.Single().LastPrice : resultBybit.Result.Error));
        Console.WriteLine();
    }
}

async Task TickerExampleUnified()
{
    while (true)
    {
        Console.WriteLine("Enter base asset: ");
        var baseAsset = Console.ReadLine();
        Console.WriteLine("Enter quote asset: ");
        var quoteAsset = Console.ReadLine();

        var client = new ExchangeRestClient();
        var symbol = new SharedSymbol(TradingMode.Spot, baseAsset, quoteAsset);
        var request = new GetTickerRequest(symbol);
        var resultBinance = client.GetSpotTickerAsync(Exchange.Binance, request);
        var resultBingX = client.GetSpotTickerAsync(Exchange.BingX, request);
        var resultBybit = client.GetSpotTickerAsync(Exchange.Bybit, request);
        await Task.WhenAll(resultBinance, resultBingX, resultBybit);

        Console.WriteLine();
        Console.WriteLine("Exchange prices:");
        Console.WriteLine("Binance:" + (resultBinance.Result.Success ? resultBinance.Result.Data.LastPrice : resultBinance.Result.Error));
        Console.WriteLine("BingX:" + (resultBingX.Result.Success ? resultBingX.Result.Data.LastPrice : resultBingX.Result.Error));
        Console.WriteLine("Bybit:" + (resultBybit.Result.Success ? resultBybit.Result.Data.LastPrice : resultBybit.Result.Error));
        Console.WriteLine();
    }
}

async Task TickerExampleUnified2()
{
    while (true)
    {
        Console.WriteLine("Enter base asset: ");
        var baseAsset = Console.ReadLine();
        Console.WriteLine("Enter quote asset: ");
        var quoteAsset = Console.ReadLine();

        var client = new ExchangeRestClient();
        var symbol = new SharedSymbol(TradingMode.Spot, baseAsset, quoteAsset);
        var request = new GetTickerRequest(symbol);

        Console.WriteLine("Exchange prices:");
        await foreach(var result in client.GetSpotTickerAsyncEnumerable(request, [Exchange.Binance, Exchange.BingX, Exchange.Bybit]))
            Console.WriteLine($"{result.Exchange}:" + (result.Success ? result.Data.LastPrice : result.Error));

        Console.WriteLine();
    }
}

async Task PlaceOrderExampleExchangeSpecific()
{
    Console.WriteLine("Enter base asset: ");
    var baseAsset = Console.ReadLine();
    Console.WriteLine("Enter quote asset: ");
    var quoteAsset = Console.ReadLine();
    Console.WriteLine("Enter side (buy/sell): ");
    var side = Console.ReadLine();
    Console.WriteLine("Enter quantity: ");
    var quantity = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Enter price: ");
    var price = decimal.Parse(Console.ReadLine());

    var client = new ExchangeRestClient(binanceRestOptions: (options) =>
    {
        options.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("BinanceKey", "BinanceSecret");
    },
    bingxRestOptions: (options) =>
    {
        options.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("BingXKey", "BingXSecret");
    },
    bybitRestOptions: (options) =>
    {
        options.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("BybitKey", "BybitSecret");
    });

    var resultBinance = client.Binance.SpotApi.Trading.PlaceOrderAsync(baseAsset + quoteAsset, side == "buy"? Binance.Net.Enums.OrderSide.Buy: Binance.Net.Enums.OrderSide.Sell, Binance.Net.Enums.SpotOrderType.Limit, quantity, price: price, timeInForce: Binance.Net.Enums.TimeInForce.GoodTillCanceled);
    var resultBingX = client.BingX.SpotApi.Trading.PlaceOrderAsync(baseAsset + "-" + quoteAsset, side == "buy" ? BingX.Net.Enums.OrderSide.Buy: BingX.Net.Enums.OrderSide.Sell, BingX.Net.Enums.OrderType.Limit, quantity, price);
    var resultBybit = client.Bybit.V5Api.Trading.PlaceOrderAsync(Bybit.Net.Enums.Category.Spot, baseAsset + quoteAsset, side == "buy"? Bybit.Net.Enums.OrderSide.Buy : Bybit.Net.Enums.OrderSide.Sell, Bybit.Net.Enums.NewOrderType.Limit, quantity, price);
    await Task.WhenAll(resultBinance, resultBingX, resultBybit);

    Console.WriteLine("Binance:" + (resultBinance.Result.Success ? resultBinance.Result.Data.Id : resultBinance.Result.Error));
    Console.WriteLine("BingX:" + (resultBingX.Result.Success ? resultBingX.Result.Data.OrderId : resultBingX.Result.Error));
    Console.WriteLine("Bybit:" + (resultBybit.Result.Success ? resultBybit.Result.Data.OrderId : resultBybit.Result.Error));
    Console.ReadLine();
}

async Task PlaceOrderExampleUnified()
{
    Console.WriteLine("Enter base asset: ");
    var baseAsset = Console.ReadLine();
    Console.WriteLine("Enter quote asset: ");
    var quoteAsset = Console.ReadLine();
    Console.WriteLine("Enter side (buy/sell): ");
    var side = Enum.Parse<SharedOrderSide>(Console.ReadLine(), true);
    Console.WriteLine("Enter quantity: ");
    var quantity = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Enter price: ");
    var price = decimal.Parse(Console.ReadLine());

    var client = new ExchangeRestClient(binanceRestOptions: (options) =>
    {
        options.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("BinanceKey", "BinanceSecret");
    },
    bingxRestOptions: (options) =>
    {
        options.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("BingXKey", "BingXSecret");
    },
    bybitRestOptions: (options) =>
    {
        options.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("BybitKey", "BybitSecret");
    });

    var request = new PlaceSpotOrderRequest(
        new SharedSymbol(TradingMode.Spot, baseAsset, quoteAsset),
        side,
        SharedOrderType.Limit,
        SharedQuantity.Base(quantity),
        price: price
        );

    var resultBinance = client.GetSpotOrderClient(Exchange.Binance)!.PlaceSpotOrderAsync(request);
    var resultBingX = client.GetSpotOrderClient(Exchange.BingX)!.PlaceSpotOrderAsync(request);
    var resultBybit = client.GetSpotOrderClient(Exchange.Bybit)!.PlaceSpotOrderAsync(request);
    await Task.WhenAll(resultBinance, resultBingX, resultBybit);

    Console.WriteLine("Binance:" + (resultBinance.Result.Success ? resultBinance.Result.Data.Id : resultBinance.Result.Error));
    Console.WriteLine("BingX:" + (resultBingX.Result.Success ? resultBingX.Result.Data.Id : resultBingX.Result.Error));
    Console.WriteLine("Bybit:" + (resultBybit.Result.Success ? resultBybit.Result.Data.Id : resultBybit.Result.Error));
    Console.ReadLine();
}

async Task SubscribePriceUpdatesExchangeSpecific()
{
    Console.WriteLine("Enter base asset: ");
    var baseAsset = Console.ReadLine();
    Console.WriteLine("Enter quote asset: ");
    var quoteAsset = Console.ReadLine();

    var client = new ExchangeSocketClient();
    var resultBinance = client.Binance.SpotApi.ExchangeData.SubscribeToMiniTickerUpdatesAsync(baseAsset + quoteAsset, update => Console.WriteLine($"Update from Binance: {update.Data.LastPrice}"));
    var resultBingX = client.BingX.SpotApi.SubscribeToPriceUpdatesAsync(baseAsset + "-" + quoteAsset, update => Console.WriteLine($"Update from BingX: {update.Data.Price}"));
    var resultBybit = client.Bybit.V5SpotApi.SubscribeToTickerUpdatesAsync(baseAsset + quoteAsset, update => Console.WriteLine($"Update from Bybit: {update.Data.LastPrice}"));
    await Task.WhenAll(resultBinance, resultBingX, resultBybit);

    Console.WriteLine();

    if (!resultBinance.Result.Success) Console.WriteLine("Binance subscription failed: " + resultBinance.Result.Error);
    if (!resultBingX.Result.Success) Console.WriteLine("BingX subscription failed: " + resultBingX.Result.Error);
    if (!resultBybit.Result.Success) Console.WriteLine("Bybit subscription failed: " + resultBybit.Result.Error);

    Console.ReadLine();
}

async Task SubscribePriceUpdatesUnified()
{
    Console.WriteLine("Enter base asset: ");
    var baseAsset = Console.ReadLine();
    Console.WriteLine("Enter quote asset: ");
    var quoteAsset = Console.ReadLine();

    var client = new ExchangeSocketClient();
    var symbol = new SharedSymbol(TradingMode.Spot, baseAsset, quoteAsset);
    var request = new SubscribeTickerRequest(symbol);
    var resultBinance = client.GetTickerClient(TradingMode.Spot, Exchange.Binance)!.SubscribeToTickerUpdatesAsync(request, update => Console.WriteLine($"Update from {update.Exchange}: {update.Data.LastPrice}"));
    var resultBingX = client.GetTickerClient(TradingMode.Spot, Exchange.BingX)!.SubscribeToTickerUpdatesAsync(request, update => Console.WriteLine($"Update from {update.Exchange}: {update.Data.LastPrice}"));
    var resultBybit = client.GetTickerClient(TradingMode.Spot, Exchange.Bybit)!.SubscribeToTickerUpdatesAsync(request, update => Console.WriteLine($"Update from {update.Exchange}: {update.Data.LastPrice}"));
    await Task.WhenAll(resultBinance, resultBingX, resultBybit);

    Console.WriteLine();

    if (!resultBinance.Result.Success) Console.WriteLine("Binance subscription failed: " + resultBinance.Result.Error);
    if (!resultBingX.Result.Success) Console.WriteLine("BingX subscription failed: " + resultBingX.Result.Error);
    if (!resultBybit.Result.Success) Console.WriteLine("Bybit subscription failed: " + resultBybit.Result.Error);

    Console.ReadLine();
}

async Task SubscribePriceUpdatesUnified2()
{
    Console.WriteLine("Enter base asset: ");
    var baseAsset = Console.ReadLine();
    Console.WriteLine("Enter quote asset: ");
    var quoteAsset = Console.ReadLine();

    var client = new ExchangeSocketClient();
    var symbol = new SharedSymbol(TradingMode.Spot, baseAsset, quoteAsset);
    var request = new SubscribeTickerRequest(symbol);
    var results = await client.SubscribeToTickerUpdatesAsync(request, update => Console.WriteLine($"Update from {update.Exchange}: {update.Data.LastPrice}"), [Exchange.Binance, Exchange.BingX, Exchange.Bybit]);
    
    Console.WriteLine();

    foreach (var result in results)
    {
        if (!result.Success)
            Console.WriteLine($"{result.Exchange} subscription failed: {result.Error}");
    }

    Console.ReadLine();
}

async Task StartOrderBooks()
{
    Console.WriteLine("Enter base asset: ");
    var baseAsset = Console.ReadLine();
    Console.WriteLine("Enter quote asset: ");
    var quoteAsset = Console.ReadLine();

    var bookBinance = new BinanceSpotSymbolOrderBook(baseAsset + quoteAsset);
    var bookBingX = new BingXSpotSymbolOrderBook(baseAsset + "-" + quoteAsset);
    var bookBybit = new BybitSymbolOrderBook(baseAsset + quoteAsset, Bybit.Net.Enums.Category.Spot);

    var resultBinance = bookBinance.StartAsync();
    var resultBingX = bookBingX.StartAsync();
    var resultBybit = bookBybit.StartAsync();
    await Task.WhenAll(resultBinance, resultBingX, resultBybit);

    if (!resultBinance.Result.Success) Console.WriteLine("Binance book start failed: " + resultBinance.Result.Error);
    if (!resultBingX.Result.Success) Console.WriteLine("BingX book start failed: " + resultBingX.Result.Error);
    if (!resultBybit.Result.Success) Console.WriteLine("Bybit book start failed: " + resultBybit.Result.Error);

    while (true)
    {
        Console.Clear();

        Console.WriteLine("Binance");
        Console.WriteLine(bookBinance.ToString(3));
        Console.WriteLine();
        Console.WriteLine("BingX");
        Console.WriteLine(bookBingX.ToString(3));
        Console.WriteLine();
        Console.WriteLine("Bybit");
        Console.WriteLine(bookBybit.ToString(3));

        await Task.Delay(1000);
    }
}