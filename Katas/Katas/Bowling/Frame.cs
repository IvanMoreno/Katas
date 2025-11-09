namespace Katas.Bowling;

public readonly struct Frame
{
    public readonly int AllowedRolls;
    public readonly int Score;
    public bool IsOver => AllowedRolls == 0;

    Frame(int allowedRolls, int score)
    {
        AllowedRolls = allowedRolls;
        Score = score;
    }

    public Frame Rolled(Pins pins)
    {
        if (IsOver)
            throw new InvalidOperationException("Frame is over");
        
        return new Frame(AllowedRolls - 1, Score + pins);
    }

    public static Frame Default() => new(allowedRolls:2, score:0);
}