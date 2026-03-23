using Soenneker.Shopify.GraphQlClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Shopify.GraphQlClientUtil.Tests;

[Collection("Collection")]
public sealed class ShopifyGraphQlClientUtilTests : FixturedUnitTest
{
    private readonly IShopifyGraphQlClientUtil _graphqlclientutil;

    public ShopifyGraphQlClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _graphqlclientutil = Resolve<IShopifyGraphQlClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
