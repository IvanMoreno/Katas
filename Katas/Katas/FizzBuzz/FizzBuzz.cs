namespace Katas.FizzBuzz;

public class FizzBuzz
{
    readonly Divisors divisors;
    readonly WordsMergeAlgorithm wordsMerging;
    
    FizzBuzz(Divisors divisors, WordsMergeAlgorithm wordsMerging)
    {
        this.divisors = divisors;
        this.wordsMerging = wordsMerging;
    }

    public Word Translate(NaturalNumber number)
    {
        if (!divisors.ExistsDivisorFor(number))
            return number.ToString();

        return wordsMerging.Merge(divisors.DivisorWords(number));
    }

    public static FizzBuzz Classic() => new(Divisors.FizzBuzz(), WordsMergeAlgorithm.MergeAllWords());
    public static FizzBuzz RepeatLastWord() => new(Divisors.FizzBuzz(), WordsMergeAlgorithm.MergeAndRepeatLastWord());
}