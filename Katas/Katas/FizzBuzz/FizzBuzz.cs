public class FizzBuzz   
{
    public FizzBuzzWord Of(NaturalNumber number)
    {
        if (number == 3)
            return FizzBuzzWord.Fizz;
        
        return number.ToString();
    }
}