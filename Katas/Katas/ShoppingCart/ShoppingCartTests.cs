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
    public void AddProduct()
    {
        ShoppingCartasaf.Empty()
            .Add(new Product(cost: 10))
            .See().TotalProducts.Should().Be(1);
    }

    [Test]
    public void CompareProducts()
    {
        new Product(cost: 1).Should().Be(new Product(cost: 1));
        new Product(cost: 1).Should().NotBe(new Product(cost: 2));
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

    [Test]
    public void RoundUp_TwoDecimals()
    {
        Product.RoundLastTwo(0.6789f).Should().Be(0.68f);
        Product.RoundLastTwo(0.671f).Should().Be(0.68f);
    }
    
    [Test]
    public void RoundUp_PricePerUnit()
    {
        new Product(cost: 1.55f, revenuePercentage: 15).FinalPrice.Should().Be(1.79f);
    }
}