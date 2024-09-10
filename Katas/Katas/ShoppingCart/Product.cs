namespace Katas.ShoppingCartasdfasdf;

public readonly struct Percentage
{
    readonly int part;
    Percentage(int part) => this.part = part;

    public float Of(float whole) => whole * (part / 100f);

    public static implicit operator Percentage(int part) => new(part);
}

public record Product
{
    readonly string name;
    readonly float cost;
    readonly Percentage revenue;
    public float FinalPrice => RoundLastTwo(PricePerUnit);
    float PricePerUnit => cost + revenue.Of(cost);

    public Product(string name, float cost, int revenue)
    {
        if (cost <= 0)
            throw new ArgumentException();
        if (revenue < 0)
            throw new ArgumentException();
        
        this.name = name;
        this.cost = cost;
        this.revenue = revenue;
    }

    public static float RoundLastTwo(float toBeRounded)
    {
        double multiplier = Math.Pow(10, Convert.ToDouble(2));
        return (float)(Math.Ceiling(toBeRounded * multiplier) / multiplier);
    }
}