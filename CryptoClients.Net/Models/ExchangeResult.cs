﻿using CryptoClients.Net.Enums;
using CryptoExchange.Net.Objects;

namespace CryptoClients.Net.Models
{
    /// <summary>
    /// A WebCallResult from an exchange
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExchangeResult<T> : CallResult<T>
    {
        /// <summary>
        /// The exchange
        /// </summary>
        public Exchange Exchange { get; }

        /// <summary>
        /// ctor
        /// </summary>
        public ExchangeResult(
            Exchange exchange,
            CallResult<T> result) : 
            base(
                result.Data,
                result.OriginalData,
                result.Error)
        {
            Exchange = exchange;
        }

        /// <inheritdoc />
        public override string ToString() => $"{Exchange} - " + base.ToString();
    }
}
