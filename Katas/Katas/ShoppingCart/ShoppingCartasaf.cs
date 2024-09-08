namespace Katas.ShoppingCart;

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