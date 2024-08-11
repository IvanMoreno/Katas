using static System.Linq.Enumerable;
using static System.String;
using static System.TimeSpan;

namespace Katas.SmartFridge;

public class Fridge
{
    readonly DateTime today;
    readonly List<Item> allStored = new();
    readonly List<DateTime> openings = new();

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

        return openings.Aggregate(Zero, (current, opening) => current + (openings.First() >= item.AdditionDate ? FromHours(1) : FromHours(0)));
    }

    public Fridge Put(Item item)
    {
        allStored.Add(item with { AdditionDate = today });
        return this;
    }

    public static Fridge At(DateTime today)
    {
        return new Fridge(today, Empty<Item>().ToList(), Empty<DateTime>().ToList());
    }

    public Fridge OpenDoor()
    {
        return new(today, allStored, openings.Append(today).ToList());
    }

    public Fridge Pass(TimeSpan howMuchTime)
    {
        return new(today + howMuchTime, allStored, openings);
    }
}