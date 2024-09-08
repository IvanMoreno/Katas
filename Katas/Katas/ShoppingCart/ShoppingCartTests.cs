using FluentAssertions;

namespace Katas.ShoppingCart;

public class ShoppingCartTests
{
    [Test]
    public void EmptyShoppingCart_HasNoItems()
    {
        new ShoppingCartasaf().See().Items.Should().BeEmpty();
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
    public IEnumerable<string> Items => new List<string>();
}
