namespace Katas.ShoppingCartasdfasdf;

public record Product
{
    readonly string name;
    readonly float cost;
    readonly Percentage revenue;
    readonly Percentage vat;
    public float FinalPrice => RoundLastTwo(PricePerUnit) + vat.Of(RoundLastTwo(PricePerUnit));
    float PricePerUnit => cost + revenue.Of(cost);

    public Product(string name, float cost, Percentage revenue, Percentage vat)
    {
        if (cost <= 0)
            throw new ArgumentException();
        
        this.name = name;
        this.cost = cost;
        this.revenue = revenue;
        this.vat = vat;
    }

    public static float RoundLastTwo(float toBeRounded)
    {
        double multiplier = Math.Pow(10, Convert.ToDouble(2));
        return (float)(Math.Ceiling(toBeRounded * multiplier) / multiplier);
    }
}