using Soenneker.Shopify.GraphQlClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Shopify.GraphQlClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ShopifyGraphQlClientUtilTests : HostedUnitTest
{
    private readonly IShopifyGraphQlClientUtil _graphqlclientutil;

    public ShopifyGraphQlClientUtilTests(Host host) : base(host)
    {
        _graphqlclientutil = Resolve<IShopifyGraphQlClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
