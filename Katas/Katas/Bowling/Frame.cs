namespace Katas.Bowling;

public readonly struct Frame
{
    public readonly int AllowedRolls;
    public readonly int Score;
    public bool IsOver => AllowedRolls == 0;

    public Frame(int allowedRolls, int score)
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
}