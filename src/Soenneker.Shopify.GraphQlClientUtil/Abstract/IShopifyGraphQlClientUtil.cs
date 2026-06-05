using Soenneker.Shopify.GraphQlClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Shopify.GraphQlClientUtil.Abstract;

/// <summary>
/// A .NET thread-safe singleton GraphQL client
/// </summary>
public interface IShopifyGraphQlClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<ShopifyGraphQlClient> Get(CancellationToken cancellationToken = default);
}
