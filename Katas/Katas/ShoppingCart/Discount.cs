namespace Katas.ShoppingCartasdfasdf;

public struct Discount
{
    readonly int percentage;

    public Discount(int percentage)
    {
        if (percentage < 0)
            throw new ArgumentException();
        if (percentage > 100)
            throw new ArgumentException();
        
        this.percentage = percentage;
    }

    public float ApplyIn(float price)
    {
        return price - percentage / 100f * price;
    }

    public static Discount None => new Discount(0);
}