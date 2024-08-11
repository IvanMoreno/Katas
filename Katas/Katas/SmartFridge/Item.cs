namespace Katas.SmartFridge;

public record Item(string Name, DateTime ExpirationDate)
{
    public DateTime AdditionDate { get; init; }
    public bool Opened { get; init; }
}