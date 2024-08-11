using static System.String;
using static System.TimeSpan;

namespace Katas.SmartFridge;

public class Fridge
{
    readonly DateTime today;
    readonly List<Item> allStored = new();
    List<DateTime> openings = new();

    Fridge(DateTime today) => this.today = today;

    Fridge(DateTime today, List<Item> allStored, List<DateTime> openings)
    {
        this.today = today;
        this.allStored = allStored;
        this.openings = openings;
    }

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
        if (!openings.Any()) return FromHours(0);

        var result = TimeSpan.Zero;
        foreach (var opening in openings)
        {
            result += openings.First() >= item.AdditionDate ? FromHours(1) : FromHours(0);
        }

        return result;
    }

    public Fridge Put(Item item)
    {
        allStored.Add(item with { AdditionDate = today });
        return this;
    }

    public static Fridge At(DateTime today)
    {
        return new Fridge(today);
    }

    public Fridge OpenDoor()
    {
        openings.Add(today);
        return this;
    }

    public Fridge Pass(TimeSpan howMuchTime)
    {
        return new(today + howMuchTime, allStored, openings);
    }
}