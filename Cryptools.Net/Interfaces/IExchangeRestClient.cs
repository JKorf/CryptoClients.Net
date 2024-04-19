using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using CryptoExchange.Net.Interfaces.CommonClients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptools.Net.Interfaces
{
    public interface IExchangeRestClient
    {
        IBinanceRestClient Binance { get; }
        IBingXRestClient BingX { get; }

        ISpotClient GetUnifiedSpotClient(string name);
        IEnumerable<ISpotClient> GetUnifiedSpotClients();
    }
}
