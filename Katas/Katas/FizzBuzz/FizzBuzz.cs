public class FizzBuzz
{
    readonly Dictionary<NaturalNumber, FizzBuzzWord> divisorToWord = new()
    {
        { 3, FizzBuzzWord.Fizz },
        { 5, FizzBuzzWord.Buzz }
    };

    public FizzBuzzWord Translate(NaturalNumber number)
    {
        foreach (var (divisor, word) in divisorToWord)
        {
            if (number.IsDivisibleBy(divisor))
                return word;
        }

        return number.ToString();
    }
}