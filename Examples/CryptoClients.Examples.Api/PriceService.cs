
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using System.Collections.Concurrent;

namespace CryptoClients.Examples.Api
{
    public class PriceService : IHostedService
    {
        private readonly IExchangeSharedApiClient _client;
        private readonly ConcurrentDictionary<string, decimal> _prices;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public PriceService(IExchangeSharedApiClient client)
        {
            _client = client;
            _prices = new ConcurrentDictionary<string, decimal>();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public bool TryGetPrice(string exchange, out decimal price) => _prices.TryGetValue(exchange, out price);

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var binanceTask = SubscribeClient(Exchange.Binance, _client.Binance.SpotSocket);
            var bingXTask = SubscribeClient(Exchange.BingX, _client.BingX.SpotSocket);
            var bybitTask = SubscribeClient(Exchange.Bybit, _client.Bybit.SpotSocket);
            await Task.WhenAll(binanceTask, bingXTask, bybitTask);
        }

        private async Task SubscribeClient(string exchange, ISubscribeTickerSocket client)
        {
            await client.SubscribeToTickerUpdatesAsync(new SubscribeTickerRequest(new SharedSymbol(TradingMode.Spot, "ETH", "USDT")), x => _prices[exchange] = x.Data.LastPrice ?? 0, _cancellationTokenSource.Token);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.Cancel();
            return Task.CompletedTask;
        }
    }
}
