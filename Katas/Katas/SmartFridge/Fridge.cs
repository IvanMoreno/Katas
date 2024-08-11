using static System.Linq.Enumerable;
using static System.String;
using static System.TimeSpan;

namespace Katas.SmartFridge;

public class Fridge
{
    readonly DateTime today;
    readonly List<Item> allStored;
    readonly List<DateTime> openings;

    Fridge(DateTime today, List<Item> allStored, List<DateTime> openings)
    {
        this.today = today;
        this.allStored = allStored;
        this.openings = openings;
    }

    public string Display()
        => Join('\n', allStored.OrderByDescending(IsExpired).Select(LineFor));

    string LineFor(Item item)
    {
        if (IsExpired(item))
            return $"EXPIRED: {item.Name}";

        return $"{item.Name}: {DaysUntilExpiration(item)} day(s) remaining";
    }

    bool IsExpired(Item item)
        => DaysUntilExpiration(item) < 0;

    int DaysUntilExpiration(Item item)
        => (item.ExpirationDate - today - DegradationByAirExposure(item)).Days - 1;

    TimeSpan DegradationByAirExposure(Item item)
        => openings.Any()
            ? openings.Aggregate(Zero,
                (current, opening) => current + (opening >= item.AdditionDate ? FromHours(1) : FromHours(0)))
            : FromHours(0);

    public Fridge Put(Item item)
        => new(today, allStored.Append(item with { AdditionDate = today }).ToList(), openings);

    public Fridge OpenDoor()
        => new(today, allStored, openings.Append(today).ToList());

    public Fridge Pass(TimeSpan howMuchTime)
        => new(today + howMuchTime, allStored, openings);

    public static Fridge At(DateTime today)
        => new(today, Empty<Item>().ToList(), Empty<DateTime>().ToList());
}