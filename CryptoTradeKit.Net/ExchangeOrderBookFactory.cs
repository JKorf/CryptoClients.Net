using Binance.Net.Interfaces;
using BingX.Net.Interfaces;
using CryptoTradeKit.Net.Interfaces;
using Kucoin.Net.Interfaces;

namespace CryptoTradeKit.Net
{
    /// <inheritdoc />
    public class ExchangeOrderBookFactory : IExchangeOrderBookFactory
    {
        /// <inheritdoc />
        public IBinanceOrderBookFactory Binance { get; }
        /// <inheritdoc />
        public IBingXOrderBookFactory BingX { get; }
        /// <inheritdoc />
        public IKucoinOrderBookFactory Kucoin { get; }

        /// <summary>
        /// DI constructor
        /// </summary>
        public ExchangeOrderBookFactory(IBinanceOrderBookFactory binance, IBingXOrderBookFactory bingx, IKucoinOrderBookFactory kucoin)
        {
            Binance = binance;
            BingX = bingx;
            Kucoin = kucoin;
        }

    }
}
