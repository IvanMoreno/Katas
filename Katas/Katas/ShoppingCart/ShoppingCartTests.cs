using FluentAssertions;

namespace Katas.ShoppingCart;

public class ShoppingCartTests
{
    [Test]
    public void EmptyShoppingCart_HasNoProducts()
    {
        new ShoppingCartasaf().See().Products.Should().BeEmpty();
        new ShoppingCartasaf().See().TotalProducts.Should().Be(0);
        new ShoppingCartasaf().See().TotalPrice.Should().Be(0);
    }
}

public class ShoppingCartasaf
{
    public Snapshot See()
    {
        return new();
    }

    public struct Snapshot
    {
        public IEnumerable<string> Products => new List<string>();
        public int TotalProducts { get; set; }
        public int TotalPrice { get; set; }
    }
}