using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Extensions.Configuration;
using Soenneker.Shopify.GraphQlClient;
using Soenneker.Utils.AsyncSingleton;
using Soenneker.Shopify.GraphQlClientUtil.Abstract;
using Soenneker.Shopify.HttpClients.Abstract;

namespace Soenneker.Shopify.GraphQlClientUtil;

///<inheritdoc cref="IShopifyGraphQlClientUtil"/>
public sealed class ShopifyGraphQlClientUtil : IShopifyGraphQlClientUtil
{
    private readonly AsyncSingleton<ShopifyGraphQlClient> _client;

    public ShopifyGraphQlClientUtil(IShopifyGraphQlHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<ShopifyGraphQlClient>(async (token) =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token);

            var apiKey = configuration.GetValueStrict<string>("Shopify:ApiKey");

            return new ShopifyGraphQlClient(new GraphQlHttpClient(httpClient));
        });
    }

    public ValueTask<ShopifyGraphQlClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}