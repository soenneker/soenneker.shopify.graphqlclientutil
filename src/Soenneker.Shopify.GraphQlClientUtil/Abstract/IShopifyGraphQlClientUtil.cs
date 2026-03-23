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
    ValueTask<ShopifyGraphQlClient> Get(CancellationToken cancellationToken = default);
}
