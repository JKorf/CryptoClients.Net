
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using System.Collections.Concurrent;

namespace CryptoClients.Examples.Api
{
    public class PriceService : IHostedService
    {
        private IExchangeSocketClient _socketClient;
        private ConcurrentDictionary<Exchange, decimal> _prices;
        private CancellationTokenSource _cancellationTokenSource;

        public PriceService(IExchangeSocketClient socketClient)
        {
            _socketClient = socketClient;
            _prices = new ConcurrentDictionary<Exchange, decimal>();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public decimal GetPrice(Exchange exchange) => _prices[exchange];

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var binanceTask = _socketClient.Binance.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync("ETHUSDT", x => _prices[Exchange.Binance] = x.Data.LastPrice, _cancellationTokenSource.Token);
            var bingXTask = _socketClient.BingX.SpotApi.SubscribeToTickerUpdatesAsync("ETH-USDT", x => _prices[Exchange.BingX] = x.Data.LastPrice, _cancellationTokenSource.Token);
            var bybitTask = _socketClient.Bybit.V5SpotApi.SubscribeToTickerUpdatesAsync("ETHUSDT", x => _prices[Exchange.Bybit] = x.Data.LastPrice, _cancellationTokenSource.Token);
            await Task.WhenAll(binanceTask, bingXTask, bybitTask);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.Cancel();
            return Task.CompletedTask;
        }
    }
}
