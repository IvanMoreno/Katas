using static System.String;

namespace Katas.SmartFridge;

public class Fridge
{
    readonly DateTime today;
    readonly List<Item> allStored = new();

    Fridge(DateTime today) => this.today = today;

    public string Display()
    {
        return Join('\n', allStored.Select(LineFor));
    }

    string LineFor(Item item)
    {
        if (IsExpired(item))
            return "EXPIRED: Lettuce";

        return $"{item.Name}: {DaysUntilExpiration(item)} day(s) remaining";
    }

    bool IsExpired(Item item) => DaysUntilExpiration(item) < 0;
    int DaysUntilExpiration(Item item) => (item.ExpirationDate - today).Days - 1;

    public Fridge Put(Item item)
    {
        allStored.Add(item);
        return this;
    }

    public static Fridge At(DateTime today)
    {
        return new Fridge(today);
    }
}