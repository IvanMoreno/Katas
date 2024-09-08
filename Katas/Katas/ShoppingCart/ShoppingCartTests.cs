using FluentAssertions;

namespace Katas.ShoppingCartasdfasdf;

public class ShoppingCartTests
{
    [Test]
    public void EmptyShoppingCart_HasNoProducts()
    {
        ShoppingCart.Empty().See().Products.Should().BeEmpty();
        ShoppingCart.Empty().See().TotalProducts.Should().Be(0);
        ShoppingCart.Empty().See().TotalPrice.Should().Be(0);
    }

    [Test]
    public void AddProduct()
    {
        ShoppingCart.Empty()
            .Add(new Product(cost: 10))
            .See().Should().Be(CashMachine.PrintFor(new Product(cost: 10)));
    }

    [Test]
    public void ReceiptIncludesProductTotalPrice()
    {
        new ShoppingCart.Receipt() { Products = new[] { new Product(cost: 10) } }
            .TotalPrice
            .Should().Be(10);
    }

    [Test]
    public void ReceiptIncludesProductTotalProduct()
    {
        new ShoppingCart.Receipt() { Products = new[] { new Product(cost: 10) } }
            .TotalProducts
            .Should().Be(1);
    }

    [Test]
    public void ReceiptAppliesDiscount()
    {
        CashMachine.PrintFor(new Product(cost: 8))
            .With(new Discount(50))
            .TotalPrice
            .Should().Be(8 / 2);
    }

    [Test]
    public void DiscountCanBeApplied()
    {
        new Discount(percentage: 15).ApplyIn(100).Should().Be(85);
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

public static class CashMachine
{
    public static ShoppingCart.Receipt PrintFor(params Product[] products)
    {
        return new ShoppingCart.Receipt() { Products = products };
    }

    public static ShoppingCart.Receipt With(
        this ShoppingCart.Receipt receipt,
        Discount discount)
    {
        return receipt with { Discount = discount };
    }
}