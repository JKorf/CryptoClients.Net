
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using System.Collections.Concurrent;

namespace CryptoClients.Examples.Api
{
    public class PriceService : IHostedService
    {
        private IExchangeSocketClient _socketClient;
        private ConcurrentDictionary<string, decimal> _prices;
        private CancellationTokenSource _cancellationTokenSource;

        public PriceService(IExchangeSocketClient socketClient)
        {
            _socketClient = socketClient;
            _prices = new ConcurrentDictionary<string, decimal>();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public decimal GetPrice(string exchange) => _prices[exchange];

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var binanceTask = SubscribeClient(_socketClient.Binance.SpotApi.SharedClient);
            var bingXTask = SubscribeClient(_socketClient.BingX.SpotApi.SharedClient);
            var bybitTask = SubscribeClient(_socketClient.Bybit.V5SpotApi.SharedClient);
            await Task.WhenAll(binanceTask, bingXTask, bybitTask);
        }

        private async Task SubscribeClient(ITickerSocketClient client)
        {
            await client.SubscribeToTickerUpdatesAsync(new SubscribeTickerRequest(new SharedSymbol(TradingMode.Spot, "ETH", "USDT")), x => _prices[Exchange.Binance] = x.Data.LastPrice ?? 0, _cancellationTokenSource.Token);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.Cancel();
            return Task.CompletedTask;
        }
    }
}
