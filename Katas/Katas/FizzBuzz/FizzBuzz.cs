public class FizzBuzz
{
    readonly Divisors divisors;

    FizzBuzz(Divisors divisors)
    {
        this.divisors = divisors;
    }

    public Word Translate(NaturalNumber number)
    {
        if (!divisors.ExistsDivisorFor(number))
            return number.ToString();

        return divisors.DivisorWords(number).Aggregate(string.Empty, (acc, word) => acc + word);
    }

    public static FizzBuzz Classic()
    {
        return new FizzBuzz(Divisors.FizzBuzz());
    }
}