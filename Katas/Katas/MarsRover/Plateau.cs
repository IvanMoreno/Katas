namespace Katas.MarsRoverKata;

public class Plateau
{
    public int NextX(int from, int towards)
    {
        var nextPosition = from + towards;
        
        if (nextPosition > 10)
            return 0;
        
        if (nextPosition < 0)
            return 10;
        
        return nextPosition;
    }

    public int NextY(int from, int towards)
    {
        var nextPosition = from + towards;
        
        if (nextPosition > 10)
            return 0;
        
        if (nextPosition < 0)
            return 10;
        
        return nextPosition;
    }

    public static Plateau A10x10()
    {
        return new Plateau();
    }
}