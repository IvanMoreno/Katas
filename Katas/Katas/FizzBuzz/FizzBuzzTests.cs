using FluentAssertions;

// https://www.codurance.com/katas/fizzbuzz
// [] If the number is a multiple of three, return the string "Fizz".
// [] If the number is a multiple of five, return the string "Buzz".
// [] If the number is a multiple of both three and five, return the string "FizzBuzz".
// [x] No negative numbers

public class FizzbuzzTests
{
    [Test]
    public void NonMultipleOfThreeOrFiveReturnsSameNumber()
    {
        new FizzBuzz().Of(new(1)).Should().Be((FizzBuzzWord)"1");
    }

    [Test]
    public void MultipleOfThreeReturnsFizz()
    {
        new FizzBuzz().Of(new(3)).Should().Be((FizzBuzzWord)"Fizz");
    }
}