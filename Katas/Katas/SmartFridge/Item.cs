namespace Katas.SmartFridge;

public record Item(string Name, DateTime ExpirationDate)
{
    public DateTime AdditionDate { get; init; }
}