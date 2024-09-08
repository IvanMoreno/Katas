namespace Katas.ShoppingCartasdfasdf;

public class ShoppingCart
{
    readonly IEnumerable<Product> addedProducts;

    public ShoppingCart(IEnumerable<Product> addedProducts)
    {
        this.addedProducts = addedProducts;
    }

    public Receipt See()
    {
        return new(){Products =  addedProducts};
    }

    public ShoppingCart Add(Product product)
    {
        return new(addedProducts.Append(product));
    }

    public static ShoppingCart Empty() => new(Enumerable.Empty<Product>());

    public record Receipt
    {
        public IEnumerable<Product> Products { get; init; }
        public int TotalProducts => Products.Count();
        public float TotalPrice =>Discount.ApplyIn(PriceBeforeDiscount);
        float PriceBeforeDiscount => Products.Sum(x => x.FinalPrice);
        public Discount Discount { get; init; } = new(0);
        public virtual bool Equals(Receipt? other) => other.Products.SequenceEqual(Products);
    }
}