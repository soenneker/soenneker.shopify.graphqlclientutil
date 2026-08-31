using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Shopify.GraphQlClientUtil.Abstract;
using Soenneker.Shopify.HttpClients.Registrars;

namespace Soenneker.Shopify.GraphQlClientUtil.Registrars;

/// <summary>
/// Registers the lazily initialized Shopify Admin GraphQL client.
/// </summary>
public static class ShopifyGraphQlClientUtilRegistrar
{
    /// <summary>
    /// Adds the Shopify Admin GraphQL client utility as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddShopifyGraphQlClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddShopifyGraphQlHttpClientAsSingleton()
                .TryAddSingleton<IShopifyGraphQlClientUtil, ShopifyGraphQlClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Shopify Admin GraphQL client utility as a scoped service backed by the singleton HTTP client provider. <para/>
    /// </summary>
    public static IServiceCollection AddShopifyGraphQlClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddShopifyGraphQlHttpClientAsSingleton()
                .TryAddScoped<IShopifyGraphQlClientUtil, ShopifyGraphQlClientUtil>();

        return services;
    }
}
