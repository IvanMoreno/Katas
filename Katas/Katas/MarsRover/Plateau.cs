namespace Katas.MarsRoverKata;

public class Plateau
{
    public static Plateau A10x10()
    {
        return new Plateau();
    }

    public int NextX(int from, int towards)
    {
        var nextPosition = from + towards;
        if (nextPosition > 10)
            return 0;
        
        return nextPosition;
    }
}