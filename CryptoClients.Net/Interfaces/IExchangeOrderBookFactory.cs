using Binance.Net.Interfaces;
using BingX.Net.Interfaces;
using Bitfinex.Net.Interfaces;
using Bitget.Net.Interfaces;
using BitMart.Net.Interfaces;
using BitMEX.Net.Interfaces;
using Bybit.Net.Interfaces;
using Coinbase.Net.Interfaces;
using CoinEx.Net.Interfaces;
using CryptoCom.Net.Interfaces;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using DeepCoin.Net.Interfaces;
using GateIo.Net.Interfaces;
using HTX.Net.Interfaces;
using HyperLiquid.Net.Interfaces;
using Kraken.Net.Interfaces;
using Kucoin.Net.Interfaces;
using Mexc.Net.Interfaces;
using OKX.Net.Interfaces;
using Toobit.Net.Interfaces;
using WhiteBit.Net.Interfaces;
using XT.Net.Interfaces;

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
        /// BitMart order book factory
        /// </summary>
        IBitMartOrderBookFactory BitMart { get; }
        /// <summary>
        /// BitMEX order book factory
        /// </summary>
        IBitMEXOrderBookFactory BitMEX { get; }
        /// <summary>
        /// Bybit order book factory
        /// </summary>
        IBybitOrderBookFactory Bybit { get; }
        /// <summary>
        /// Coinbase order book factory
        /// </summary>
        ICoinbaseOrderBookFactory Coinbase { get; }
        /// <summary>
        /// CoinEx order book factory
        /// </summary>
        ICoinExOrderBookFactory CoinEx { get; }
        /// <summary>
        /// Crypto.com order book factory
        /// </summary>
        ICryptoComOrderBookFactory CryptoCom { get; }
        /// <summary>
        /// DeepCoin order book factory
        /// </summary>
        IDeepCoinOrderBookFactory DeepCoin { get; }
        /// <summary>
        /// Gate.io order book factory
        /// </summary>
        IGateIoOrderBookFactory GateIo { get; }
        /// <summary>
        /// HTX order book factory
        /// </summary>
        IHTXOrderBookFactory HTX { get; }
        /// <summary>
        /// HyperLiquid order book factory
        /// </summary>
        IHyperLiquidOrderBookFactory HyperLiquid { get; }
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
        /// <summary>
        /// Toobit order book factory
        /// </summary>
        IToobitOrderBookFactory Toobit { get; }
        /// <summary>
        /// WhiteBit order book factory
        /// </summary>
        IWhiteBitOrderBookFactory WhiteBit { get; }
        /// <summary>
        /// XT order book factory
        /// </summary>
        IXTOrderBookFactory XT { get; }

        /// <summary>
        /// Create a new ISymbolOrderBook instance for the provided symbol on the provided exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="minimalDepth">Minimal depth of the order book. Order book might be larger depending on what the API supports. Might be smaller if the requested depth is above what the API can support.</param>
        /// <param name="exchangeParameters">Exchange specific parameters</param>
        /// <returns>ISymbolOrderBook implementation</returns>
        ISymbolOrderBook? Create(string exchange, SharedSymbol symbol, int? minimalDepth = null, ExchangeParameters? exchangeParameters = null);
    }
}
