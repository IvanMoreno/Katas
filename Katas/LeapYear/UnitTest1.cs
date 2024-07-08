using FluentAssertions;

namespace LeapYear;

// https://www.codurance.com/katas/leap-year
// [] A year is a leap year if divisible by 4
// [] A year is a leap year if divisible by 400
// [] A year is not a leap year if not divisible by 4
// [] A year is not a leap year if divisible by 100 but not by 400

public class Tests
{
    [Test]
    public void IsLeapYear_IfDivisible_By4()
    {
        new SolarCalendar().IsLeap(year: 4).Should().BeTrue();
        new SolarCalendar().IsLeap(year: 8).Should().BeTrue();
    }

    [Test]
    public void IsNotLeapYear_IfNotDivisible_By4()
    {
        new SolarCalendar().IsLeap(year: 3).Should().BeFalse();
        new SolarCalendar().IsLeap(year: 7).Should().BeFalse();
    }
}

public readonly struct SolarCalendar
{
    public bool IsLeap(int year)
    {
        return year % 4 == 0;
    }
}