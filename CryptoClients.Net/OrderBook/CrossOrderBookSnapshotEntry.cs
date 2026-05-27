using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClients.Net.OrderBook
{
    /// <summary>
    /// Exchange order book entry
    /// </summary>
    public class CrossOrderBookSnapshotEntry
    {
        /// <summary>
        /// Exchange name
        /// </summary>
        public string Exchange { get; set; } = string.Empty;
        /// <summary>
        /// Order book entry
        /// </summary>
        public ISymbolOrderBookEntry Entry { get; set; } = null!;
    }
}
