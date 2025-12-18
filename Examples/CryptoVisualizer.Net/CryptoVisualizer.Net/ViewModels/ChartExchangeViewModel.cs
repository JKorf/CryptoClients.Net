using CommunityToolkit.Mvvm.ComponentModel;
using CryptoExchange.Net.Objects.Sockets;

namespace CryptoVisualizer.Net.ViewModels
{
    public partial class ChartExchangeViewModel : ObservableObject
    {
        [ObservableProperty]
        public bool _enabled;
        [ObservableProperty]
        public string _exchange;

        public UpdateSubscription? Subscription { get; set; }

        public ChartExchangeViewModel(string exchange)
        {
            _exchange = exchange;
        }
    }
}
