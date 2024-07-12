namespace LeapYear;

public readonly struct SolarCalendar
{
    public bool IsLeap(int year) 
        => year.DivisibleBy(100)
            ? year.DivisibleBy(400)
            : year.DivisibleBy(4) || year.DivisibleBy(400);
}