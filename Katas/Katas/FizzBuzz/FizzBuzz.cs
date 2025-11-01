public class FizzBuzz   
{
    public FizzBuzzWord Of(NaturalNumber number)
    {
        if (number % 3 == 0)
            return FizzBuzzWord.Fizz;
        
        return number.ToString();
    }
}