public readonly struct Divisors(Dictionary<NaturalNumber, Word> divisorToWord)
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

    public Word WordOfDivisorOf(NaturalNumber number)
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

    public static Divisors FizzBuzz() => new(new Dictionary<NaturalNumber, Word>()
    {
        { 3, Word.Fizz },
        { 5, Word.Buzz }
    });
}