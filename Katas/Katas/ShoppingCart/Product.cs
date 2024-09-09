namespace Katas.ShoppingCartasdfasdf;

public record Product
{
    readonly string name;
    readonly float cost;
    readonly float revenuePercentage;
    public float FinalPrice => RoundLastTwo(PricePerUnit);
    float PricePerUnit => cost + cost * (revenuePercentage / 100);

    public Product(string name, float cost, int revenuePercentage)
    {
        if (cost <= 0)
            throw new ArgumentException();
        if (revenuePercentage < 0)
            throw new ArgumentException();
        
        this.name = name;
        this.cost = cost;
        this.revenuePercentage = revenuePercentage;
    }

    public static float RoundLastTwo(float toBeRounded)
    {
        double multiplier = Math.Pow(10, Convert.ToDouble(2));
        return (float)(Math.Ceiling(toBeRounded * multiplier) / multiplier);
    }
}