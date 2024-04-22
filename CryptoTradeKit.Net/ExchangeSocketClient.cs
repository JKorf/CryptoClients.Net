using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using BingX.Net.Clients;
using BingX.Net.Interfaces.Clients;
using CryptoTradeKit.Net.Interfaces;
using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces.Clients;

namespace CryptoTradeKit.Net
{
    /// <inheritdoc />
    public class ExchangeSocketClient : IExchangeSocketClient
    {
        /// <inheritdoc />
        public IBinanceSocketClient Binance { get; }
        /// <inheritdoc />
        public IBingXSocketClient BingX { get; }
        /// <inheritdoc />
        public IKucoinSocketClient Kucoin { get; }

        /// <summary>
        /// Create a new ExchangeSocketClient instance. Client instances will be created with default options.
        /// </summary>
        public ExchangeSocketClient()
        {
            Binance = new BinanceSocketClient();
            BingX = new BingXSocketClient();
            Kucoin = new KucoinSocketClient();
        }

        /// <summary>
        /// DI constructor
        /// </summary>
        public ExchangeSocketClient(IBinanceSocketClient binance, IBingXSocketClient bingx, IKucoinSocketClient kucoin)
        {
            Binance = binance;
            BingX = bingx;
            Kucoin = kucoin;
        }

    }
}
