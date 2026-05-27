using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClients.Net.OrderBook
{
    /// <summary>
    /// Order book snapshot level, containing price, total quantity and the entries at that price
    /// </summary>
    public class CrossOrderbookSnapshotLevel
    {
        /// <summary>
        /// The price of this level
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// The total quantity at this price level, which is the sum of the quantities of all entries at this price
        /// </summary>
        public decimal TotalQuantity { get; set; }
        /// <summary>
        /// All exchange entries for this price level
        /// </summary>
        public List<CrossOrderBookSnapshotEntry> Entries { get; set; } = new();
    }
}
