namespace Katas.SmartFridge;

public record PassTime(TimeSpan HowMuch) : Event
{
}