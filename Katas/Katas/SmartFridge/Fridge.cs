using static System.String;

namespace Katas.SmartFridge;

public class Fridge
{
    readonly DateTime today;
    readonly List<Item> allStored = new();
    bool wasOpen = false;

    Fridge(DateTime today) => this.today = today;

    public string Display()
    {
        return Join('\n', allStored.OrderByDescending(IsExpired).Select(LineFor));
    }

    string LineFor(Item item)
    {
        if (IsExpired(item))
            return $"EXPIRED: {item.Name}";

        return $"{item.Name}: {DaysUntilExpiration(item)} day(s) remaining";
    }

    bool IsExpired(Item item) => DaysUntilExpiration(item) < 0;
    int DaysUntilExpiration(Item item)
    {
        return (item.ExpirationDate - today - (wasOpen ? TimeSpan.FromHours(1) : TimeSpan.FromHours(0))).Days - 1;
    }

    public Fridge Put(Item item)
    {
        allStored.Add(item);
        return this;
    }

    public static Fridge At(DateTime today)
    {
        return new Fridge(today);
    }

    public Fridge OpenDoor()
    {
        wasOpen = true;
        return this;
    }
}