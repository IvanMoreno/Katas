using FluentAssertions;

// https://www.codurance.com/katas/fizzbuzz
// [] If the number is a multiple of three, return the string "Fizz".
// [] If the number is a multiple of five, return the string "Buzz".
// [] If the number is a multiple of both three and five, return the string "FizzBuzz".
// [] No negative numbers

public class FizzbuzzTests
{
    [Test]
    public void NonMultipleOfThreeOrFiveReturnsSameNumber()
    {
        new FizzBuzz().Of(1).Should().Be("1");
    }
}

public class FizzBuzz   
{
    public string Of(int i)
    {
        return i.ToString();
    }
}