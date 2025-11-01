public class FizzBuzz
{
    readonly Divisors divisors = Divisors.FizzBuzz();

    public FizzBuzzWord Translate(NaturalNumber number)
    {
        if (!divisors.ExistsDivisorFor(number))
            return number.ToString();

        return divisors.WordOfDivisorOf(number);
    }
}