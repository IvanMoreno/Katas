namespace Katas.MarsRoverKata;

public class Plateau
{
    int sizeX;
    int sizeY;

    public int NextX(int from, int towards)
    {
        return Clamp(from, towards, sizeX);
    }

    public int NextY(int from, int towards)
    {
        return Clamp(from, towards, sizeY);
    }

    int Clamp(int from, int towards, int edgePosition)
    {
        if (Math.Abs(towards) > 1)
            throw new ArgumentException("Direction cannot be greater than 1, must be normalized");
        if (towards == 0)
            throw new ArgumentException("Direction cannot be 0");
        
        var nextPosition = from + towards;

        if (nextPosition > edgePosition)
            return 0;

        if (nextPosition < 0)
            return 10;

        return nextPosition;
    }

    public static Plateau A10x10()
    {
        return new Plateau(){sizeX = 10, sizeY = 10};
    }
}