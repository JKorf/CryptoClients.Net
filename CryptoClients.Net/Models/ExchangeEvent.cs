using CryptoClients.Net.Enums;
using CryptoExchange.Net.Objects.Sockets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoClients.Net.Models
{
    public class ExchangeEvent<T> : DataEvent<T>
    {
        /// <summary>
        /// The exchange
        /// </summary>
        public Exchange Exchange { get; }

        public ExchangeEvent(Exchange exchange, DataEvent<T> evnt):
            base(evnt.Data,
                evnt.StreamId,
                evnt.Symbol,
                evnt.OriginalData,
                evnt.Timestamp,
                evnt.UpdateType)
        {
            Exchange = exchange;
        }

        /// <inheritdoc />
        public override string ToString() => $"{Exchange} - " + base.ToString();
    }
}
