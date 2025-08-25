using CryptoClients.Net.Models;
using System;
using System.Collections.Generic;

namespace CryptoClients.Net.Interfaces
{
    /// <summary>
    /// Provider for clients with credentials for specific users
    /// </summary>
    public interface IExchangeUserClientProvider
    {
        /// <summary>
        /// Initialize a client for the specified user identifier. This can be used so to initialize a client for a user so ApiCredentials do not need to be passed later.
        /// </summary>
        /// <param name="userIdentifier">The identifier for user</param>
        /// <param name="credentials">The credentials for user</param>
        /// <param name="environments">The environments to use for the clients</param>
        void InitializeUserClient(string userIdentifier, ExchangeCredentials credentials, Dictionary<string, string?> environments);

        /// <summary>
        /// Reset the cached clients for a user. This can be useful when a user changes API credentials.
        /// </summary>
        public void ClearUserClients(string userIdentifier, string? exchange = null);

        /// <summary>
        /// Get the Rest client for a specific user. In case the client does not exist yet it will be created and the <paramref name="credentials"/> should be provided, unless <see cref="InitializeUserClient" /> has been called prior for this user.
        /// </summary>
        /// <param name="userIdentifier">The identifier for user</param>
        /// <param name="credentials">The credentials for the user. Required the first time a client is requested for this user unless <see cref="InitializeUserClient" /> has been called prior for this user.</param>
        /// <param name="environments">The environments to use for the clients</param>
        IExchangeRestClient GetRestClient(string userIdentifier, ExchangeCredentials? credentials = null, Dictionary<string, string?>? environments = null);

        /// <summary>
        /// Get the Socket client for a specific user. In case the client does not exist yet it will be created and the <paramref name="credentials"/> should be provided, unless <see cref="InitializeUserClient" /> has been called prior for this user.
        /// </summary>
        /// <param name="userIdentifier">The identifier for user</param>
        /// <param name="credentials">The credentials for the user. Required the first time a client is requested for this user unless <see cref="InitializeUserClient" /> has been called prior for this user.</param>
        /// <param name="environments">The environments to use for the clients</param>
        IExchangeSocketClient GetSocketClient(string userIdentifier, ExchangeCredentials? credentials = null, Dictionary<string, string?>? environments = null);
    }
}
