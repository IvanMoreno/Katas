namespace Katas.ShoppingCartasdfasdf;

public class ShoppingCart
{
    readonly IEnumerable<Product> addedProducts;
    readonly Discount appliedDiscount;

    public ShoppingCart(IEnumerable<Product> addedProducts, Discount appliedDiscount)
    {
        this.addedProducts = addedProducts;
        this.appliedDiscount = appliedDiscount;
    }

    public Receipt See()
    {
        return new() { Products = addedProducts, Discount = appliedDiscount };
    }

    public ShoppingCart Add(Product product)
    {
        return new(addedProducts.Append(product), appliedDiscount);
    }

    public static ShoppingCart Empty() => new(Enumerable.Empty<Product>(), new Discount(0));

    public ShoppingCart ApplyDiscount(int percentage)
    {
        return new(addedProducts, new Discount(percentage));
    }

    public record Receipt
    {
        public IEnumerable<Product> Products { get; init; }
        public int TotalProducts => Products.Count();
        public float TotalPrice => Discount.ApplyIn(PriceBeforeDiscount);
        float PriceBeforeDiscount => Products.Sum(x => x.FinalPrice);
        public Discount Discount { get; init; } = new(0);

        public virtual bool Equals(Receipt? other) =>
            other.Products.SequenceEqual(Products) && other.Discount.Equals(Discount);

        public int QuantityOf(Product aProduct) 
            => Products.Count(x => x.Equals(aProduct));
    }

    public ShoppingCart ApplyCoupon(string coupon)
    {
        return new ShoppingCart(addedProducts, Redeem(coupon));
    }

    Discount Redeem(string coupon)
    {
        if (coupon == "PROMO_10")
            return new Discount(10);
        if (coupon == "PROMO_5")
            return new Discount(5);
        
        return Discount.None;
    }
}