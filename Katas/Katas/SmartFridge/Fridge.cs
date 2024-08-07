namespace Katas.SmartFridge;

public class Fridge
{
    Item? stored;

    public string Display()
    {
        return stored == null
            ? ""
            : $"Tomato: {DaysUntilExpiration(stored)} day(s) remaining";
    }

    int DaysUntilExpiration(Item item)
    {
        return (item.ExpirationDate - new DateTime()).Days - 1;
    }

    public Fridge Put(Item item)
    {
        stored = item;
        return this;
    }

    public static Fridge Empty()
    {
        return new Fridge();
    }
}