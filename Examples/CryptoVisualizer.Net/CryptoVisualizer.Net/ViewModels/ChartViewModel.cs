using CommunityToolkit.Mvvm.ComponentModel;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoVisualizer.Net.ViewModels
{
    public partial class ChartViewModel : ViewModelBase
    {
        private IExchangeSocketClient _client;
        private double _minPriceBase = double.MaxValue;
        private double _maxPriceBase = 0;

        private readonly Dictionary<string, ISeries> _serieRefs = new Dictionary<string, ISeries>();
        private bool _pendingScaleUpdate;
        private Task _updateScaleTask;
        private Task _removeOldTask;
        private bool _running = true;

        // The period being shown the chart, lower means it will move faster
        private const int _chartPeriodSeconds = 30;
        // The percentage of price increase/decrease that the chart will show above/below the max/min price on the chart
        private const double _chartScalePercentage = 0.05;

        private AsyncResetEvent _updateScaleWaiter = new AsyncResetEvent(false, true);

        public ObservableCollection<ISeries> Series { get; set; } = [];
        public object Sync { get; } = new object();
        public ObservableCollection<ChartExchangeViewModel> EnabledExchanges { get; set; } = new ObservableCollection<ChartExchangeViewModel>();
        
        // Assets to choose from
        public string[] Assets { get; set; } = ["BTC", "ETH", "XRP", "SOL"];

        // Initially selected asset
        [ObservableProperty]
        public string _selectedAsset = "BTC";
        [ObservableProperty]
        public double _minLimit;
        [ObservableProperty]
        public double _maxLimit;
        [ObservableProperty]
        public double _minPrice;
        [ObservableProperty]
        public double _maxPrice;

        public ChartViewModel()
        {
            _client = App.Current.Services.GetRequiredService<IExchangeSocketClient>();

            PropertyChanged += PropChanged;

            var clients = _client.GetTradeClients(TradingMode.Spot);
            var allExchange = new ChartExchangeViewModel("All");
            allExchange.PropertyChanged += ExchangePropChange;
            EnabledExchanges.Add(allExchange);

            foreach (var client in clients)
            {
                var exchange = new ChartExchangeViewModel(client.Exchange);
                exchange.PropertyChanged += ExchangePropChange;
                EnabledExchanges.Add(exchange);
            }

            _updateScaleTask = UpdateScale();
            _removeOldTask = RemoveOld();
        }

        public async Task UnloadAsync()
        {
            _running = false;
            foreach (var exchange in EnabledExchanges)
            {
                if (exchange.Subscription != null)
                    await exchange.Subscription.CloseAsync();
            }

            await _updateScaleTask;
            await _removeOldTask;
        }

        private void PropChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(SelectedAsset))
                return;

            _ = UpdateAsset();
        }

        private async Task UpdateAsset()
        {
            foreach (var exchange in EnabledExchanges)
            {
                if (exchange.Subscription != null)
                    await exchange.Subscription.CloseAsync();
            }

            foreach (var serie in Series)
                serie.Name = serie.Name!.Split(":")[0];

            lock (Sync)
            {
                foreach (var series in _serieRefs)
                    ((ObservableCollection<DateTimePoint>)series.Value.Values!).Clear();
            }

            _pendingScaleUpdate = true;

            foreach (var exchange in EnabledExchanges)
            {
                if (exchange.Enabled)
                    await SubscribeExchangeAsync(exchange);
            }
        }

        private void ToggleAll(bool enabled)
        {
            foreach (var exchange in EnabledExchanges.Where(x => x.Exchange != "All"))
                exchange.Enabled = enabled;
        }

        private void ExchangePropChange(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(ChartExchangeViewModel.Enabled))
                return;

            var obj = (ChartExchangeViewModel)sender!;
            if (obj.Enabled)
            {
                if (obj.Exchange == "All")
                {
                    ToggleAll(true);
                    return;
                }

                if (!_serieRefs.ContainsKey(obj.Exchange))
                {
                    var newSerie = new StepLineSeries<DateTimePoint>
                    {
                        Name = obj.Exchange,
                        Fill = null,
                        GeometrySize = 5,
                        Values = new ObservableCollection<DateTimePoint>()
                    };
                    Series.Add(newSerie);
                    _serieRefs.Add(obj.Exchange, newSerie);
                }

                _ = SubscribeExchangeAsync(obj);
                return;
            }

            if (obj.Exchange == "All")
            {
                ToggleAll(false);
                return;
            }

            if (obj.Subscription != null)
                _ = obj.Subscription.CloseAsync();

            var serie = Series.SingleOrDefault(x => x.Name!.StartsWith(obj.Exchange));
            if (serie != null)
            {
                _serieRefs.Remove(obj.Exchange);
                Series.Remove(serie);
            }
        }

        private async Task SubscribeExchangeAsync(ChartExchangeViewModel exchange)
        {
            var symbol2 = new SharedSymbol(TradingMode.Spot, SelectedAsset, SharedSymbol.UsdOrStable);
            var result = await _client.SubscribeToTradeUpdatesAsync(exchange.Exchange, new SubscribeTradeRequest(symbol2, new ExchangeParameters(
                new ExchangeParameter("Binance", "Aggregated", true)
                )), ProcessUpdate);

            if (result.Success)
                exchange.Subscription = result.Data;
        }

        private void ProcessUpdate(DataEvent<SharedTrade[]> upd)
        {
            if (!_serieRefs.TryGetValue(upd.Exchange, out var serie))
                return;

            lock (Sync)
                serie.Name = upd.Exchange + ": " + Round(upd.Data.Last().Price);

            var values = ((ObservableCollection<DateTimePoint>)serie.Values!);
            foreach (var item in upd.Data)
            {
                var price = (double)item.Price;

                lock (Sync)                
                    values.Add(new DateTimePoint(item.Timestamp, price));

                if (price < _minPriceBase) 
                    _minPriceBase = price;
                
                if (price > _maxPriceBase) 
                    _maxPriceBase = price;
                

                if (_pendingScaleUpdate)
                {
                    _pendingScaleUpdate = false;
                    _updateScaleWaiter.Set();
                }
            }            
        }

        private async Task UpdateScale()
        {
            while (_running)
            {
                lock (Sync)
                {
                    var time = DateTime.UtcNow.AddSeconds(1);
                    MinLimit = time.AddSeconds(-_chartPeriodSeconds).Ticks;
                    MaxLimit = time.Ticks;

                    MinPrice = _minPriceBase * (1 - (_chartScalePercentage / 100));
                    MaxPrice = _maxPriceBase * (1 + (_chartScalePercentage / 100));
                }

                await Task.Delay(100);
            }
        }

        private async Task RemoveOld()
        {
            while (_running)
            {
                await _updateScaleWaiter.WaitAsync(TimeSpan.FromSeconds(5));

                lock (Sync)
                {
                    foreach (var serie in Series)
                    {
                        var toRemove = new List<DateTimePoint>();
                        var values = ((ObservableCollection<DateTimePoint>)serie.Values!);
                        foreach (DateTimePoint item in values.OrderBy(x => x.DateTime))
                        {
                            if (DateTime.UtcNow - item.DateTime < TimeSpan.FromSeconds(_chartPeriodSeconds * 2))
                                break;

                            toRemove.Add(item);
                        }

                        foreach(var item in toRemove)
                            values.Remove(item);
                    }

                    var seriesWithPoints = Series.SelectMany(x => ((ObservableCollection<DateTimePoint>)x.Values!)
                                                 .Where(x => DateTime.UtcNow - x.DateTime <= TimeSpan.FromSeconds(_chartPeriodSeconds)));
                    if (seriesWithPoints.Any())
                    {
                        _minPriceBase = seriesWithPoints.Min(x => x.Value!.Value);
                        _maxPriceBase = seriesWithPoints.Max(x => x.Value!.Value);
                    }
                }
            }
        }

        private string Round(decimal value)
        {
            if (value > 1000)
                return value.ToString("F2");

            if (value > 10)
                return value.ToString("F3");

            if (value > 0.1m)
                return value.ToString("F5");

            return value.ToString("F8");
        }

        public Func<DateTime, string> Formatter { get; set; } =
            date => date.ToString("HH:mm:ss");
    }
}
