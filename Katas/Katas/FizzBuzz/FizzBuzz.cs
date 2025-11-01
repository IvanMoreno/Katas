public class FizzBuzz   
{
    public FizzBuzzWord Of(NaturalNumber number)
    {
        if (number.IsDivisibleBy(3))
            return FizzBuzzWord.Fizz;

        if (number.IsDivisibleBy(5))
            return "Buzz";
        
        return number.ToString();
    }
}