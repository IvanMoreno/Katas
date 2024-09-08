namespace Katas.ShoppingCartasdfasdf;

public class Discount
{
    readonly int percentage;

    public Discount(int percentage)
    {
        this.percentage = percentage;
    }

    public float ApplyIn(float price)
    {
        return price - percentage / 100f * price;
    }
}