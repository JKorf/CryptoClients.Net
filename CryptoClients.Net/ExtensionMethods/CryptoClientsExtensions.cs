using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoClients.Net.ExtensionMethods
{
    internal static class CryptoClientsExtensions
    {
        public static async IAsyncEnumerable<T> ParallelEnumerateAsync<T>(this IEnumerable<Task<T>> tasks)
        {
            var remaining = new List<Task<T>>(tasks);

            while (remaining.Count != 0)
            {
                var task = await Task.WhenAny(remaining);
                remaining.Remove(task);
                yield return (await task);
            }
        }
    }
}
