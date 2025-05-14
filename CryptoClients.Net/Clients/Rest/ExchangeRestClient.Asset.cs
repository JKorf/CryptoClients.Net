using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Objects;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public partial class ExchangeRestClient
	{

		/// <inheritdoc />
		public IEnumerable<IAssetsRestClient> GetAssetsClients() => _sharedClients.OfType<IAssetsRestClient>();
		/// <inheritdoc />
		public IAssetsRestClient? GetAssetClient(string exchange) => GetAssetsClients().SingleOrDefault(s => s.Exchange == exchange);

		#region Get Assets

		/// <inheritdoc />
		public async Task<ExchangeWebResult<SharedAsset[]>> GetAssetsAsync(string exchange, GetAssetsRequest request, CancellationToken ct = default)
		{
			var result = await Task.WhenAll(GetAssetsIntAsync(request, new[] { exchange }, ct)).ConfigureAwait(false);
			return result.SingleOrDefault() ?? new ExchangeWebResult<SharedAsset[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
		}

		/// <inheritdoc />
		public async Task<ExchangeWebResult<SharedAsset[]>[]> GetAssetsAsync(GetAssetsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
		{
			return await Task.WhenAll(GetAssetsIntAsync(request, exchanges, ct)).ConfigureAwait(false);
		}

		/// <inheritdoc />
		public IAsyncEnumerable<ExchangeWebResult<SharedAsset[]>> GetAssetsAsyncEnumerable(GetAssetsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
		{
			return GetAssetsIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
		}

		private IEnumerable<Task<ExchangeWebResult<SharedAsset[]>>> GetAssetsIntAsync(GetAssetsRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
		{
			var clients = GetAssetsClients();
			if (exchanges != null)
				clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

			var tasks = clients.Where(x => x.GetAssetsOptions.Supported).Select(x => x.GetAssetsAsync(request, ct));
			return tasks;
		}

		#endregion

		#region Get Asset

		/// <inheritdoc />
		public async Task<ExchangeWebResult<SharedAsset>> GetAssetAsync(string exchange, GetAssetRequest request, CancellationToken ct = default)
		{
			var result = await Task.WhenAll(GetAssetIntAsync(request, new[] { exchange }, ct)).ConfigureAwait(false);
			return result.SingleOrDefault() ?? new ExchangeWebResult<SharedAsset>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
		}

		/// <inheritdoc />
		public async Task<ExchangeWebResult<SharedAsset>[]> GetAssetAsync(GetAssetRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
		{
			return await Task.WhenAll(GetAssetIntAsync(request, exchanges, ct)).ConfigureAwait(false);
		}

		/// <inheritdoc />
		public IAsyncEnumerable<ExchangeWebResult<SharedAsset>> GetAssetAsyncEnumerable(GetAssetRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
		{
			return GetAssetIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
		}

		private IEnumerable<Task<ExchangeWebResult<SharedAsset>>> GetAssetIntAsync(GetAssetRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
		{
			var clients = GetAssetsClients();
			if (exchanges != null)
				clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

			var tasks = clients.Where(x => x.GetAssetOptions.Supported).Select(x => x.GetAssetAsync(request, ct));
			return tasks;
		}

		#endregion

	}
}
