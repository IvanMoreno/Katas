namespace Katas.ShoppingCartasdfasdf;

public record Product
{
    readonly string name;
    readonly float cost;
    readonly Percentage revenue;
    readonly Percentage tax;
    public float FinalPrice => PricePerUnit + tax.Of(PricePerUnit);
    float PricePerUnit => RoundLastTwo(cost + revenue.Of(cost));

    public Product(string name, float cost, Percentage revenue, Percentage tax)
    {
        if (cost <= 0)
            throw new ArgumentException();
        
        this.name = name;
        this.cost = cost;
        this.revenue = revenue;
        this.tax = tax;
    }

    public static float RoundLastTwo(float toBeRounded)
    {
        double multiplier = Math.Pow(10, Convert.ToDouble(2));
        return (float)(Math.Ceiling(toBeRounded * multiplier) / multiplier);
    }
}