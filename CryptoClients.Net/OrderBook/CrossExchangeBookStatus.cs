using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClients.Net.OrderBook
{
    /// <summary>
    /// Cross exchange book status
    /// </summary>
    public enum CrossExchangeBookStatus
    {
        /// <summary>
        /// Initial
        /// </summary>
        Initial,
        /// <summary>
        /// Partially synced, not all exchange books are fully synced
        /// </summary>
        PartiallySynced,
        /// <summary>
        /// All exchange books are fully synced
        /// </summary>
        Synced
    }
}
