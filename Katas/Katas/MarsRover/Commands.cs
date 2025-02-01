namespace Katas.MarsRoverKata;

public static class Commands
{
    public static string Move(int times = 1)
    {
        var result = "";
        for (int i = 0; i < times; i++)
        {
            result += "M";
        }

        return result;
    }
    
    public static string TurnLeft(int times = 1)
    {
        var result = "";
        for (int i = 0; i < times; i++)
        {
            result += "L";
        }

        return result;
    }
    
    public static string TurnRight(int times = 1)
    {
        var result = "";
        for (int i = 0; i < times; i++)
        {
            result += "R";
        }

        return result;
    }

    public static string ThenMove(this string previousCommand, int times = 1)
    {
        return previousCommand + Move(times);
    }
}