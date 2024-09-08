using FluentAssertions;

namespace Katas.ShoppingCart;

public class ShoppingCartTests
{
    [Test]
    public void EmptyShoppingCart_HasNoProducts()
    {
        new ShoppingCartasaf().See().Products.Should().BeEmpty();
        new ShoppingCartasaf().See().TotalProducts.Should().Be(0);
    }
}

public class ShoppingCartasaf
{
    public asfdasas See()
    {
        return new();
    }
}

public struct asfdasas
{
    public IEnumerable<string> Products => new List<string>();
    public int TotalProducts { get; set; }
}
