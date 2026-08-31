[![](https://img.shields.io/nuget/v/soenneker.shopify.graphqlclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.shopify.graphqlclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.shopify.graphqlclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.shopify.graphqlclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.shopify.graphqlclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.shopify.graphqlclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.shopify.graphqlclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.shopify.graphqlclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Shopify.GraphQlClientUtil

Provides a lazily initialized, strongly typed client for Shopify Admin GraphQL mutations across products, orders, customers, fulfillment, discounts, subscriptions, webhooks, and store configuration.

## Installation

```bash
dotnet add package Soenneker.Shopify.GraphQlClientUtil
```

## Configuration

```json
{
  "Shopify": {
    "AccessToken": "your-access-token",
    "StoreName": "your-store",
    "ApiVersion": "2026-07"
  }
}
```

Set `Shopify:ClientBaseUrl` instead when you need to supply the complete GraphQL endpoint.

## Usage

```csharp
using Soenneker.Shopify.GraphQlClient;
using Soenneker.Shopify.GraphQlClientUtil.Abstract;
using Soenneker.Shopify.GraphQlClientUtil.Registrars;

services.AddShopifyGraphQlClientUtilAsSingleton();

public sealed class ShopifyTagger
{
    private readonly IShopifyGraphQlClientUtil _shopify;

    public ShopifyTagger(IShopifyGraphQlClientUtil shopify)
    {
        _shopify = shopify;
    }

    public async Task<TagsAddPayload?> AddTag(
        string productId,
        CancellationToken cancellationToken)
    {
        ShopifyGraphQlClient client = await _shopify.Get(cancellationToken);

        return await client.Tags.Add.GetValue(
            new TagsAddVariables
            {
                Id = productId,
                Tags = ["featured"]
            },
            cancellationToken);
    }
}
```

`GetValue(...)` returns the mutation payload directly; use `Execute(...)` when you also need top-level GraphQL errors. Use `AddShopifyGraphQlClientUtilAsScoped()` for a separate generated wrapper per scope. Both registrations retain the singleton authenticated HTTP client provider.
