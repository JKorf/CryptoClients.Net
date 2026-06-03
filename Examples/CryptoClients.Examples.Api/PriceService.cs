
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using System.Collections.Concurrent;

namespace CryptoClients.Examples.Api
{
    public class PriceService : IHostedService
    {
        private readonly IExchangeSocketClient _socketClient;
        private readonly ConcurrentDictionary<string, decimal> _prices;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public PriceService(IExchangeSocketClient socketClient)
        {
            _socketClient = socketClient;
            _prices = new ConcurrentDictionary<string, decimal>();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public bool TryGetPrice(string exchange, out decimal price) => _prices.TryGetValue(exchange, out price);

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var binanceTask = SubscribeClient(Exchange.Binance, _socketClient.Binance.SpotApi.SharedClient);
            var bingXTask = SubscribeClient(Exchange.BingX, _socketClient.BingX.SpotApi.SharedClient);
            var bybitTask = SubscribeClient(Exchange.Bybit, _socketClient.Bybit.V5SpotApi.SharedClient);
            await Task.WhenAll(binanceTask, bingXTask, bybitTask);
        }

        private async Task SubscribeClient(string exchange, ITickerSocketClient client)
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
