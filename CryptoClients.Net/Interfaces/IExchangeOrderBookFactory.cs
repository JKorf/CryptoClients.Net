using Binance.Net.Interfaces;
using BingX.Net.Interfaces;
using Bitfinex.Net.Interfaces;
using Bitget.Net.Interfaces;
using Bybit.Net.Interfaces;
using CoinEx.Net.Interfaces;
using Kraken.Net.Interfaces;
using Kucoin.Net.Interfaces;
using Mexc.Net.Interfaces;
using OKX.Net.Interfaces;

namespace CryptoClients.Net.Interfaces
{
    /// <summary>
    /// Factory for creating SymbolOrderBook instances; locally synced order books.
    /// </summary>
    public interface IExchangeOrderBookFactory
    {
        /// <summary>
        /// Binance order book factory
        /// </summary>
        IBinanceOrderBookFactory Binance { get; }
        /// <summary>
        /// BingX order book factory
        /// </summary>
        IBingXOrderBookFactory BingX { get; }
        /// <summary>
        /// Bitfinex order book factory
        /// </summary>
        IBitfinexOrderBookFactory Bitfinex { get; }
        /// <summary>
        /// Bitget order book factory
        /// </summary>
        IBitgetOrderBookFactory Bitget { get; }
        /// <summary>
        /// Bybit order book factory
        /// </summary>
        IBybitOrderBookFactory Bybit { get; }
        /// <summary>
        /// CoinEx order book factory
        /// </summary>
        ICoinExOrderBookFactory CoinEx { get; }
        /// <summary>
        /// Kraken order book factory
        /// </summary>
        IKrakenOrderBookFactory Kraken { get; }
        /// <summary>
        /// Kucoin order book factory
        /// </summary>
        IKucoinOrderBookFactory Kucoin { get; }
        /// <summary>
        /// Mexc order book factory
        /// </summary>
        IMexcOrderBookFactory Mexc { get; }
        /// <summary>
        /// OKX order book factory
        /// </summary>
        IOKXOrderBookFactory OKX { get; }
    }
}
