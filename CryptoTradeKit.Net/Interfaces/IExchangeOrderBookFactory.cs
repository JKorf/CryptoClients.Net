using Binance.Net.Interfaces;
using BingX.Net.Interfaces;
using Kucoin.Net.Interfaces;

namespace CryptoTradeKit.Net.Interfaces
{
    /// <summary>
    /// Factory for creating SymbolOrderBook instances; locally synced order books.
    /// </summary>
    public interface IExchangeOrderBookFactory
    {
        /// <summary>
        /// Binance factory
        /// </summary>
        IBinanceOrderBookFactory Binance { get; }
        /// <summary>
        /// BingX factory
        /// </summary>
        IBingXOrderBookFactory BingX { get; }
        /// <summary>
        /// Kucoin factory
        /// </summary>
        IKucoinOrderBookFactory Kucoin { get; }
    }
}
