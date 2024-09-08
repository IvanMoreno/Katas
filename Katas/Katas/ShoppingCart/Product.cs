namespace Katas.ShoppingCart;

public class Product
{
    readonly float cost;
    readonly float revenuePercentage;
    public float FinalPrice => RoundLastTwo(PricePerUnit);
    float PricePerUnit => cost + cost * (revenuePercentage / 100);

    public Product(float cost, int revenuePercentage = 0)
    {
        this.cost = cost;
        this.revenuePercentage = revenuePercentage;
    }

    public static float RoundLastTwo(float toBeRounded)
    {
        double multiplier = Math.Pow(10, Convert.ToDouble(2));
        return (float)(Math.Ceiling(toBeRounded * multiplier) / multiplier);
    }
}