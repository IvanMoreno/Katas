namespace Katas.FizzBuzz;

public readonly struct Divisors
{
    readonly Dictionary<NaturalNumber, Word> divisorToWord;

    Divisors(Dictionary<NaturalNumber, Word> divisorToWord)
    {
        if (!divisorToWord.Any())
            throw new ArgumentException("Cannot have 0 divisors");
            
        this.divisorToWord = divisorToWord;
    }

    public bool ExistsDivisorFor(NaturalNumber number)
    {
        foreach (var (divisor, _) in divisorToWord)
        {
            if (number.IsDivisibleBy(divisor))
                return true;
        }

        return false;
    }

    public IEnumerable<Word> DivisorWords(NaturalNumber number)
    {
        if (!ExistsDivisorFor(number))
            throw new ArgumentException("Number not divisible");
                
        foreach (var (divisor, word) in divisorToWord)
        {
            if (number.IsDivisibleBy(divisor))
                yield return word;
        }
    }

    public static Divisors FizzBuzz() => new(new Dictionary<NaturalNumber, Word>
    {
        { 3, Word.Fizz },
        { 5, Word.Buzz }
    });
}