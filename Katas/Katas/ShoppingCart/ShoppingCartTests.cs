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

    [Test]
    public void FinalPrice_IsItsCost_WhenApplyNoRevenue_NorTaxes()
    {
        new Product(cost: 1).FinalPrice.Should().Be(1);
    }

    [Test]
    public void FinalPrice_WithoutTaxes_IsJustPricePerUnit()
    {
        new Product(cost: 1, revenuePercentage: 100).FinalPrice.Should().Be(2);
    }
}

public class Product
{
    readonly float cost;
    readonly float revenuePercentage;
    public float FinalPrice => PricePerUnit;
    float PricePerUnit => cost + cost * (revenuePercentage / 100);

    public Product(float cost, int revenuePercentage = 0)
    {
        this.cost = cost;
        this.revenuePercentage = revenuePercentage;
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