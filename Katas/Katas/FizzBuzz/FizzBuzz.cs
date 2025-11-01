public class FizzBuzz   
{
    public FizzBuzzWord Translate(NaturalNumber number)
    {
        if (number.IsDivisibleBy(3))
            return FizzBuzzWord.Fizz;

        if (number.IsDivisibleBy(5))
            return FizzBuzzWord.Buzz;
        
        return number.ToString();
    }
}