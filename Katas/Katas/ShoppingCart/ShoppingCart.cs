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

    public struct Receipt
    {
        public IEnumerable<Product> Products { get; init; }
        public int TotalProducts => Products.Count();
        public int TotalPrice { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Receipt snapshot && snapshot.Products.SequenceEqual(Products);
        }
    }
}