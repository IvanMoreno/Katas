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
    
    public Fridge Put(AddedItem item) => new(firstDay, allEvents.Append(item with { AdditionDate = Today() }));
    public Fridge OpenDoor() => new(firstDay, allEvents.Append(new OpenedFridge(Today())));
    public Fridge Pass(TimeSpan howMuchTime) => new(firstDay, allEvents.Append(new PassTime(howMuchTime)));
    
    public string Display() => Join('\n', AllItems());
    IEnumerable<string> AllItems() => allEvents.OfType<AddedItem>().OrderByDescending(IsExpired).Select(LineFor);
    bool IsExpired(AddedItem item) => DaysUntilExpiration(item) < 0;
    int DaysUntilExpiration(AddedItem item) => ExpirationOf(item).Days - 1;
    TimeSpan ExpirationOf(AddedItem item) => item.ExpirationDate - Today() - AirExposureDegradation(item);
    DateTime Today() => TimePassages().Aggregate(firstDay, (current, timePassage) => current + timePassage.HowMuch);
    IEnumerable<PassTime> TimePassages() => allEvents.OfType<PassTime>();
    TimeSpan AirExposureDegradation(AddedItem item) => OpeningsAfter(item) * DegradationTimeFor(item);
    int OpeningsAfter(AddedItem item) => Openings().Count(x => x.When >= item.AdditionDate);
    IEnumerable<OpenedFridge> Openings() => allEvents.OfType<OpenedFridge>();
    static TimeSpan DegradationTimeFor(AddedItem anItem) => anItem.Opened ? FromHours(5) : FromHours(1);

    string LineFor(AddedItem item)
        => IsExpired(item)
            ? $"EXPIRED: {item.Name}"
            : $"{item.Name}: {DaysUntilExpiration(item)} day(s) remaining";
    
    public static Fridge At(DateTime firstDay) => new(firstDay, Empty<Event>());
}