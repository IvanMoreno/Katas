using static System.Linq.Enumerable;
using static System.String;
using static System.TimeSpan;

namespace Katas.SmartFridge;

public class Fridge
{
    readonly DateTime today;
    IEnumerable<Item> AllStored => allEvents.OfType<Item>();
    List<OpenedFridge> Openings => allEvents.OfType<OpenedFridge>().ToList();
    readonly IEnumerable<Event> allEvents;

    Fridge(DateTime today, IEnumerable<Item> allStored, List<OpenedFridge> openings)
    {
        this.today = today;
        allEvents = allStored.Select(x => x as Event).Concat(openings.Select(x => x as Event));
    }

    public string Display()
        => Join('\n', AllStored.OrderByDescending(IsExpired).Select(LineFor));

    string LineFor(Item item)
        => IsExpired(item)
            ? $"EXPIRED: {item.Name}"
            : $"{item.Name}: {DaysUntilExpiration(item)} day(s) remaining";

    bool IsExpired(Item item)
        => DaysUntilExpiration(item) < 0;

    int DaysUntilExpiration(Item item)
        => (item.ExpirationDate - today - DegradationByAirExposure(item)).Days - 1;

    TimeSpan DegradationByAirExposure(Item item)
        => Openings.Aggregate(Zero,
            (totalDegradation, opening) => totalDegradation + HowMuchDegrades(item, opening));

    static TimeSpan HowMuchDegrades(Item anItem, OpenedFridge at)
        => at.When >= anItem.AdditionDate ? DegradationTime(anItem) : FromHours(0);

    static TimeSpan DegradationTime(Item anItem)
        => anItem.Opened ? FromHours(5) : FromHours(1);

    public Fridge Put(Item item)
        => new(today, AllStored.Append(item with { AdditionDate = today }).ToList(), Openings);

    public Fridge OpenDoor()
        => new(today, AllStored, Openings.Append(new OpenedFridge(today)).ToList());

    public Fridge Pass(TimeSpan howMuchTime)
        => new(today + howMuchTime, AllStored, Openings);

    public static Fridge At(DateTime today)
        => new(today, Empty<Item>().ToList(), Empty<OpenedFridge>().ToList());
}