using FluentAssertions;
using static Katas.ShoppingCartasdfasdf.Supermarket;

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
            .Add(AProduct)
            .See().Should().Be(CashMachine.PrintFor(AProduct));
    }

    [Test]
    public void ApplyDiscountOf10()
    {
        ShoppingCart.Empty()
            .ApplyDiscount(10)
            .See().Should().Be(CashMachine.PrintFor().With(new Discount(10)));
    }

    [Test]
    public void ApplyInvalidCoupon()
    {
        ShoppingCart.Empty()
            .ApplyCoupon("sfdvsdvfdf")
            .See().Should().Be(CashMachine.PrintFor());
    }

    [Test]
    public void ApplyValidCoupon()
    {
        ShoppingCart.Empty()
            .ApplyCoupon("PROMO_10")
            .See().Should().Be(
                CashMachine.PrintFor().With(new Discount(10)));

        ShoppingCart.Empty()
            .ApplyCoupon("PROMO_5")
            .See().Should().Be(
                CashMachine.PrintFor().With(new Discount(5)));
    }

    [Test]
    public void ProductQuantity()
    {
        CashMachine.PrintFor(AProduct)
            .QuantityOf(AProduct)
            .Should().Be(1);

        CashMachine.PrintFor(AProduct, AProduct)
            .QuantityOf(AProduct)
            .Should().Be(2);

        CashMachine.PrintFor(AProduct, AnotherProduct)
            .QuantityOf(AProduct)
            .Should().Be(1);

        CashMachine.PrintFor(CreateProduct(cost: 5, name: "Other"), CreateProduct(cost: 5, name: "AProduct"))
            .QuantityOf(CreateProduct(cost: 5, name: "Other"))
            .Should().Be(1);
    }

    [Test]
    public void ReceiptIncludesProductTotalPrice()
    {
        CashMachine.PrintFor(ProductWithRaw(cost: 10))
            .TotalPrice
            .Should().Be(10);
    }

    [Test]
    public void ReceiptIncludesProductTotalProduct()
    {
        CashMachine.PrintFor(AProduct)
            .TotalProducts
            .Should().Be(1);
    }

    [Test]
    public void ReceiptAppliesDiscount()
    {
        CashMachine.PrintFor(ProductWithRaw(cost: 8))
            .With(new Discount(50))
            .TotalPrice
            .Should().Be(8 / 2);
    }

    [Test]
    public void DiscountCanBeApplied()
    {
        new Discount(discount: 15).ApplyIn(100).Should().Be(85);
    }

    [Test]
    public void CompareProducts()
    {
        ProductWithRaw(cost: 1).Should().Be(ProductWithRaw(cost: 1));
        ProductWithRaw(cost: 1).Should().NotBe(ProductWithRaw(cost: 2));
    }

    [Test]
    public void FinalPrice_IsItsCost_WhenApplyNoRevenue_NorTaxes()
    {
        ProductWithRaw(cost: 1).FinalPrice.Should().Be(1);
    }

    [Test]
    public void FinalPrice_WithoutTaxes_IsJustPricePerUnit()
    {
        CreateProduct(cost: 1, revenuePercentage: 100).FinalPrice.Should().Be(2);
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
        CreateProduct(cost: 1.55f, revenuePercentage: 15).FinalPrice.Should().Be(1.79f);
    }

    [Test]
    public void ApplyVAT_ToProduct()
    {
        CreateProduct(cost: 1, vat: 100).FinalPrice.Should().Be(2);
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

public static class Supermarket
{
    public static Product AProduct => CreateProduct(cost: 10);
    public static Product AnotherProduct => CreateProduct(cost: 5);
    public static Product ProductWithRaw(float cost) => CreateProduct(cost);

    public static Product CreateProduct(float cost, int revenuePercentage = 0, int vat = 0, string name = "TestProduct")
        => new Product(name, cost, revenuePercentage, vat);
}