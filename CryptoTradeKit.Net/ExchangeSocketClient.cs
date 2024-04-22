using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using CryptoTradeKit.Net.Interfaces;
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
        /// ctor
        /// </summary>
        public ExchangeSocketClient(IBinanceSocketClient binance, IBingXSocketClient bingx, IKucoinSocketClient kucoin)
        {
            Binance = binance;
            BingX = bingx;
            Kucoin = kucoin;
        }

    }
}
