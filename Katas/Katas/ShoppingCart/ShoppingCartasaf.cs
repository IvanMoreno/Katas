namespace Katas.ShoppingCart;

public class ShoppingCartasaf
{
    readonly IEnumerable<Product> addedProducts;

    public ShoppingCartasaf(IEnumerable<Product> addedProducts)
    {
        this.addedProducts = addedProducts;
    }

    public Snapshot See()
    {
        return new(){Products =  addedProducts};
    }

    public ShoppingCartasaf Add(Product product)
    {
        return new(addedProducts.Append(product));
    }

    public static ShoppingCartasaf Empty() => new(Enumerable.Empty<Product>());

    public struct Snapshot
    {
        public IEnumerable<Product> Products { get; init; }
        public int TotalProducts => Products.Count();
        public int TotalPrice { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Snapshot snapshot && snapshot.Products.SequenceEqual(Products);
        }
    }
}