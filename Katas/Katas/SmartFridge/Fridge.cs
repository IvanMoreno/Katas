namespace Katas.SmartFridge;

public class Fridge
{
    readonly DateTime today;
    Item? stored;

    Fridge(DateTime today) => this.today = today;

    public string Display()
    {
        return stored == null
            ? ""
            : LineFor(stored);
    }

    string LineFor(Item? item)
    {
        if (IsExpired(item))
            return "EXPIRED: Lettuce";
        
        return $"{item.Name}: {DaysUntilExpiration(item)} day(s) remaining";
    }

    bool IsExpired(Item item)
    {
        return DaysUntilExpiration(item) < 0;
    }

    int DaysUntilExpiration(Item item)
    {
        return (item.ExpirationDate - today).Days - 1;
    }

    public Fridge Put(Item item)
    {
        stored = item;
        return this;
    }

    public static Fridge At(DateTime today)
    {
        return new Fridge(today);
    }
}