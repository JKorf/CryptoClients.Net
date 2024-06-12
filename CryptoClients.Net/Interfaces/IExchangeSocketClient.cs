using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients;
using CoinEx.Net.Interfaces.Clients;
using GateIo.Net.Interfaces.Clients;
using Huobi.Net.Interfaces.Clients;
using Kraken.Net.Interfaces.Clients;
using Kucoin.Net.Interfaces.Clients;
using Mexc.Net.Interfaces.Clients;
using OKX.Net.Interfaces.Clients;
using System.Threading.Tasks;

namespace CryptoClients.Net.Interfaces
{
    /// <summary>
    /// Client for accessing the exchange Websocket API's.
    /// </summary>
    public interface IExchangeSocketClient
    {
        /// <summary>
        /// Binance Websocket API
        /// </summary>
        IBinanceSocketClient Binance { get; }
        /// <summary>
        /// BingX Websocket API
        /// </summary>
        IBingXSocketClient BingX { get; }
        /// <summary>
        /// Bitfinex Websocket API
        /// </summary>
        IBitfinexSocketClient Bitfinex { get; }
        /// <summary>
        /// Bitget Websocket API
        /// </summary>
        IBitgetSocketClient Bitget { get; }
        /// <summary>
        /// Bybit Websocket API
        /// </summary>
        IBybitSocketClient Bybit { get; }
        /// <summary>
        /// CoinEx Websocket API
        /// </summary>
        ICoinExSocketClient CoinEx { get; }
        /// <summary>
        /// Gate.io Websocket API
        /// </summary>
        IGateIoSocketClient GateIo { get; }
        /// <summary>
        /// Huobi Websocket API
        /// </summary>
        IHuobiSocketClient Huobi { get; }
        /// <summary>
        /// Kraken Websocket API
        /// </summary>
        IKrakenSocketClient Kraken { get; }
        /// <summary>
        /// Kucoin Websocket API
        /// </summary>
        IKucoinSocketClient Kucoin { get; }
        /// <summary>
        /// Mexc Websocket API
        /// </summary>
        IMexcSocketClient Mexc { get; }
        /// <summary>
        /// OKX Websocket API
        /// </summary>
        IOKXSocketClient OKX { get; }

        /// <summary>
        /// Unsubscribe and close every connection
        /// </summary>
        /// <returns></returns>
        Task UnsubscribeAllAsync();
    }
}
