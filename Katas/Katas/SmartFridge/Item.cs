namespace Katas.SmartFridge;

public record Item(string Name, DateTime ExpirationDate) : Event
{
    public DateTime AdditionDate { get; init; }
    public bool Opened { get; init; }
}