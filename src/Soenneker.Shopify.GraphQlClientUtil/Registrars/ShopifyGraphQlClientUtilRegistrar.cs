using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Shopify.GraphQlClientUtil.Abstract;
using Soenneker.Shopify.HttpClients.Registrars;

namespace Soenneker.Shopify.GraphQlClientUtil.Registrars;

/// <summary>
/// A .NET thread-safe singleton GraphQL client
/// </summary>
public static class ShopifyGraphQlClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ShopifyGraphQlClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddShopifyGraphQlClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddShopifyGraphQlHttpClientAsSingleton()
                .TryAddSingleton<IShopifyGraphQlClientUtil, ShopifyGraphQlClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ShopifyGraphQlClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddShopifyGraphQlClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddShopifyGraphQlHttpClientAsSingleton()
                .TryAddScoped<IShopifyGraphQlClientUtil, ShopifyGraphQlClientUtil>();

        return services;
    }
}