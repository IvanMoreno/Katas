namespace Katas.SmartFridge;

public record AddedItem(string Name, DateTime ExpirationDate) : Event
{
    public DateTime AdditionDate { get; init; }
    public bool Opened { get; init; }
}