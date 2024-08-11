using static System.String;
using static System.TimeSpan;

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
        return (item.ExpirationDate - today - DegradationByAirExposure(item)).Days - 1;
    }

    TimeSpan DegradationByAirExposure(Item item)
    {
        return wasOpen ? FromHours(1) : FromHours(0);
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