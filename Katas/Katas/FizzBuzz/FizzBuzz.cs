public class FizzBuzz
{
    readonly Divisors divisors;
    readonly Func<string, Word, string> wordsCombination = (acc, word) => acc + word;
    
    FizzBuzz(Divisors divisors)
    {
        this.divisors = divisors;
    }

    public Word Translate(NaturalNumber number)
    {
        if (!divisors.ExistsDivisorFor(number))
            return number.ToString();

        return divisors.DivisorWords(number).Aggregate(string.Empty, wordsCombination);
    }

    public static FizzBuzz Classic()
    {
        return new FizzBuzz(Divisors.FizzBuzz());
    }
}