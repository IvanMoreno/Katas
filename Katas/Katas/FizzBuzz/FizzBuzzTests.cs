using FluentAssertions;

// https://www.codurance.com/katas/fizzbuzz
// [x] If the number is a multiple of three, return the string "Fizz".
// [x] If the number is a multiple of five, return the string "Buzz".
// [x] If the number is a multiple of both three and five, return the string "FizzBuzz".
// [x] No negative numbers

public class FizzbuzzTests
{
    [Test]
    public void NonMultipleOfThreeOrFiveReturnsSameNumber()
    {
        FizzBuzz.Classic().Translate(1).Should().Be((Word)"1");
    }

    [TestCase(3)]
    [TestCase(6)]
    [TestCase(9)]
    [TestCase(12)]
    public void MultipleOfThreeReturnsFizz(int number)
    {
        FizzBuzz.Classic().Translate(number).Should().Be(Word.Fizz);
    }

    [TestCase(5)]
    [TestCase(10)]
    public void MultipleOfFiveReturnsBuzz(int number)
    {
        FizzBuzz.Classic().Translate(number).Should().Be(Word.Buzz);
    }

    [TestCase(15)]
    [TestCase(30)]
    public void MultipleOfThreeAndFiveReturnsFizzBuzz(int number)
    {
        FizzBuzz.Classic().Translate(number).Should().Be(Word.Fizz + Word.Buzz);
    }
}