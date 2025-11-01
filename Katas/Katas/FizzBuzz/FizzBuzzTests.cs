using FluentAssertions;

// https://www.codurance.com/katas/fizzbuzz
// [x] If the number is a multiple of three, return the string "Fizz".
// [x] If the number is a multiple of five, return the string "Buzz".
// [x] If the number is a multiple of both three and five, return the string "FizzBuzz".
// [x] No negative numbers
// [x] One version of the FizzBuzz game in real life adds an extra Fizz or Buzz whenever one of the digits ('3' or '5') appears in the number itself

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

    [Test]
    public void FizzBuzzVariantRepeatsTheLastWordWhenDivisible()
    {
        FizzBuzz.RepeatLastWord().Translate(2).Should().Be((Word)"2");
        FizzBuzz.RepeatLastWord().Translate(3).Should().Be(Word.Fizz + Word.Fizz);
        FizzBuzz.RepeatLastWord().Translate(5).Should().Be(Word.Buzz + Word.Buzz);
        FizzBuzz.RepeatLastWord().Translate(15).Should().Be(Word.Fizz + Word.Buzz + Word.Buzz);
    }
}