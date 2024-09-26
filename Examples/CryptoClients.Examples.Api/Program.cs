using CryptoClients.Examples.Api;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCryptoClients();
builder.Services.AddSingleton<PriceService>();
builder.Services.AddHostedService(x => x.GetRequiredService<PriceService>());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("priceFromRequest", async (IExchangeRestClient restClient, string exchange, string baseAsset, string quoteAsset) =>
{
    var exchangeClient = restClient.GetSpotTickerClient(exchange);
    if (exchangeClient == null)
        return Results.Problem("Exchange not found");

    var result = await exchangeClient.GetSpotTickerAsync(new GetTickerRequest(new SharedSymbol(TradingMode.Spot, baseAsset, quoteAsset)));
    if (!result)
        return Results.Problem(result.Error!.ToString());

    return Results.Ok(result.Data.LastPrice);
})
.WithName("GetPriceRequest")
.WithOpenApi();

app.MapGet("priceFromSocket", ([FromServices]PriceService service, string exchange) =>
{
    return Results.Ok(service.GetPrice(exchange));
})
.WithName("GetPriceSocket")
.WithOpenApi();

app.Run();