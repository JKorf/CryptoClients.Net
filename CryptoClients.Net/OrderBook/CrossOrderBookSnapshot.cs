using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoClients.Net.OrderBook
{
    /// <summary>
    /// Snapshot of the book
    /// </summary>
    public class CrossOrderBookSnapshot
    {
        /// <summary>
        /// Best ask level
        /// </summary>
        public CrossOrderbookSnapshotLevel BestAsk => Asks.FirstOrDefault().Value;
        /// <summary>
        /// Best bid level
        /// </summary>
        public CrossOrderbookSnapshotLevel BestBid => Bids.FirstOrDefault().Value;

        /// <summary>
        /// Asks
        /// </summary>
        public SortedDictionary<decimal, CrossOrderbookSnapshotLevel> Asks { get; set; } = new();
        /// <summary>
        /// Bids
        /// </summary>
        public SortedDictionary<decimal, CrossOrderbookSnapshotLevel> Bids { get; set; } = new(new DescendingComparer<decimal>());

        class DescendingComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T? x, T? y)
            {
                if (x == null && y == null) return 0;
                if (x == null) return 1;
                if (y == null) return -1;
                return y.CompareTo(x);
            }
        }
    }
}
