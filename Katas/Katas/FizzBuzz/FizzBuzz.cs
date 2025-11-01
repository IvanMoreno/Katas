public class FizzBuzz
{
    readonly Divisors divisors;
    readonly Func<IEnumerable<Word>, Word> wordsMergeAlgorithm;
    
    FizzBuzz(Divisors divisors, Func<IEnumerable<Word>, Word> wordsMergeAlgorithm)
    {
        this.divisors = divisors;
        this.wordsMergeAlgorithm = wordsMergeAlgorithm;
    }

    public Word Translate(NaturalNumber number)
    {
        if (!divisors.ExistsDivisorFor(number))
            return number.ToString();

        return wordsMergeAlgorithm(divisors.DivisorWords(number));
    }

    public static FizzBuzz Classic()
    {
        return new FizzBuzz(Divisors.FizzBuzz(), words => words.Aggregate(string.Empty, (acc, word) => acc + word));
    }

    public static FizzBuzz RepeatLastWord()
    {
        return new FizzBuzz(Divisors.FizzBuzz(), words => words.Aggregate(string.Empty, (acc, word) => acc + word) + words.Last());
    }
}