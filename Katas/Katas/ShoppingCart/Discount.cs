namespace Katas.ShoppingCartasdfasdf;

public struct Discount
{
    readonly Percentage discount;

    public Discount(int discount)
    {
        if (discount < 0)
            throw new ArgumentException();
        if (discount > 100)
            throw new ArgumentException();
        
        this.discount = discount;
    }

    public float ApplyIn(float price) 
        => price - discount.Of(price);

    public static Discount None => new Discount(0);
}