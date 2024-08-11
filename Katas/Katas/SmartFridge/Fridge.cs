using static System.Linq.Enumerable;
using static System.String;
using static System.TimeSpan;

namespace Katas.SmartFridge;

public class Fridge
{
    readonly DateTime today;
    readonly IEnumerable<Event> allEvents;

    Fridge(DateTime today, IEnumerable<Event> allEvents)
    {
        this.today = today;
        this.allEvents = allEvents;
    }

    public string Display()
        => Join('\n', allEvents.OfType<Item>().OrderByDescending(IsExpired).Select(LineFor));

    string LineFor(Item item)
        => IsExpired(item)
            ? $"EXPIRED: {item.Name}"
            : $"{item.Name}: {DaysUntilExpiration(item)} day(s) remaining";

    bool IsExpired(Item item)
        => DaysUntilExpiration(item) < 0;

    int DaysUntilExpiration(Item item)
        => (item.ExpirationDate - today - DegradationByAirExposure(item)).Days - 1;

    TimeSpan DegradationByAirExposure(Item item)=> OpeningsAfter(item) * DegradationOf(item);
    int OpeningsAfter(Item item) => allEvents.OfType<OpenedFridge>().Count(x => x.When >= item.AdditionDate);
    static TimeSpan DegradationOf(Item anItem) => anItem.Opened ? FromHours(5) : FromHours(1);
    public Fridge Put(Item item) => new(today, allEvents.Append(item with { AdditionDate = today }));
    public Fridge OpenDoor() => new(today, allEvents.Append(new OpenedFridge(today)));
    public Fridge Pass(TimeSpan howMuchTime) => new(today + howMuchTime, allEvents);
    public static Fridge At(DateTime today) => new(today, Empty<Event>());
}