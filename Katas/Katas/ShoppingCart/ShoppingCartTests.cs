using FluentAssertions;

namespace Katas.ShoppingCart;

public class ShoppingCartTests
{
    [Test]
    public void EmptyShoppingCart_HasNoProducts()
    {
        ShoppingCartasaf.Empty().See().Products.Should().BeEmpty();
        ShoppingCartasaf.Empty().See().TotalProducts.Should().Be(0);
        ShoppingCartasaf.Empty().See().TotalPrice.Should().Be(0);
    }
}

public class ShoppingCartasaf
{
    public static ShoppingCartasaf Empty() => new();

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