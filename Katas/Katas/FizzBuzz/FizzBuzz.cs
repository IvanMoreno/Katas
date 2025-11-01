public class FizzBuzz
{
    readonly Divisors divisors;
    readonly Func<string, Word, string> wordsMerge = (acc, word) => acc + word;
    
    FizzBuzz(Divisors divisors)
    {
        this.divisors = divisors;
    }

    public Word Translate(NaturalNumber number)
    {
        if (!divisors.ExistsDivisorFor(number))
            return number.ToString();

        return Merge(divisors.DivisorWords(number));
    }

    Word Merge(IEnumerable<Word> words) => words.Aggregate(string.Empty, wordsMerge);

    public static FizzBuzz Classic()
    {
        return new FizzBuzz(Divisors.FizzBuzz());
    }
}