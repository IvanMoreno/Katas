public readonly struct Divisors(Dictionary<NaturalNumber, FizzBuzzWord> divisorToWord)
{
    public bool ExistsDivisorFor(NaturalNumber number)
    {
        foreach (var (divisor, _) in divisorToWord)
        {
            if (number.IsDivisibleBy(divisor))
                return true;
        }

        return false;
    }

    public FizzBuzzWord WordOfDivisorOf(NaturalNumber number)
    {
        if (!ExistsDivisorFor(number))
            throw new ArgumentException("Number not divisible");
                
        foreach (var (divisor, word) in divisorToWord)
        {
            if (number.IsDivisibleBy(divisor))
                return word;
        }

        throw new Exception();
    }

    public static Divisors FizzBuzz() => new(new Dictionary<NaturalNumber, FizzBuzzWord>()
    {
        { 3, FizzBuzzWord.Fizz },
        { 5, FizzBuzzWord.Buzz }
    });
}