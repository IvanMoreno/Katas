using static System.Linq.Enumerable;
using static System.String;
using static System.TimeSpan;

namespace Katas.SmartFridge;

public class Fridge
{
    readonly DateTime firstDay;
    readonly IEnumerable<Event> allEvents;

    Fridge(DateTime firstDay, IEnumerable<Event> allEvents)
    {
        this.firstDay = firstDay;
        this.allEvents = allEvents;
    }
    
    public Fridge Put(Item item) => new(firstDay, allEvents.Append(item with { AdditionDate = Today() }));
    public Fridge OpenDoor() => new(firstDay, allEvents.Append(new OpenedFridge(Today())));
    public Fridge Pass(TimeSpan howMuchTime) => new(firstDay, allEvents.Append(new PassTime(howMuchTime)));
    
    public string Display() => Join('\n', AllItems());
    IEnumerable<string> AllItems() => allEvents.OfType<Item>().OrderByDescending(IsExpired).Select(LineFor);
    bool IsExpired(Item item) => DaysUntilExpiration(item) < 0;
    int DaysUntilExpiration(Item item) => ExpirationOf(item).Days - 1;
    TimeSpan ExpirationOf(Item item) => item.ExpirationDate - Today() - AirExposureDegradation(item);
    DateTime Today() => TimePassages().Aggregate(firstDay, (current, timePassage) => current + timePassage.HowMuch);
    IEnumerable<PassTime> TimePassages() => allEvents.OfType<PassTime>();
    TimeSpan AirExposureDegradation(Item item) => OpeningsAfter(item) * DegradationTimeFor(item);
    int OpeningsAfter(Item item) => Openings().Count(x => x.When >= item.AdditionDate);
    IEnumerable<OpenedFridge> Openings() => allEvents.OfType<OpenedFridge>();
    static TimeSpan DegradationTimeFor(Item anItem) => anItem.Opened ? FromHours(5) : FromHours(1);

    string LineFor(Item item)
        => IsExpired(item)
            ? $"EXPIRED: {item.Name}"
            : $"{item.Name}: {DaysUntilExpiration(item)} day(s) remaining";
    
    public static Fridge At(DateTime firstDay) => new(firstDay, Empty<Event>());
}