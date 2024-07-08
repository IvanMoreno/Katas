using FluentAssertions;

namespace LeapYear;

// https://www.codurance.com/katas/leap-year
// [x] A year is a leap year if divisible by 4
// [x] A year is a leap year if divisible by 400
// [x] A year is not a leap year if not divisible by 4
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

    [Test]
    public void IsLeapYear_IfDivisible_By400()
    {
        new SolarCalendar().IsLeap(year: 400).Should().BeTrue();
        new SolarCalendar().IsLeap(year: 800).Should().BeTrue();
    }

    [Test]
    public void IsNotLeapYear_IfDivisible_By100_ButNotBy400()
    {
        new SolarCalendar().IsLeap(year: 100).Should().BeFalse();
        new SolarCalendar().IsLeap(year: 200).Should().BeFalse();
        new SolarCalendar().IsLeap(year: 300).Should().BeFalse();
    }
    
    [Test]
    public void AcceptanceTest()
    {
        new SolarCalendar().IsLeap(year: 1997).Should().BeFalse();
        new SolarCalendar().IsLeap(year: 1996).Should().BeTrue();
        new SolarCalendar().IsLeap(year: 1600).Should().BeTrue();
        new SolarCalendar().IsLeap(year: 1800).Should().BeFalse();
    }
}

public readonly struct SolarCalendar
{
    public bool IsLeap(int year)
    {
        return year.DivisibleBy(100)
            ? year.DivisibleBy(400)
            : year.DivisibleBy(4) || year.DivisibleBy(400);
    }
}

public static class Mathematics
{
    public static bool DivisibleBy(this int dividend, int divisor)
    {
        return dividend % divisor == 0;
    }
}