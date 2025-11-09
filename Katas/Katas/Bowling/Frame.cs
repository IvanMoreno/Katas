namespace Katas.Bowling;

public class Frame
{
    int allowedRolls;
    public int Score { get; private set; }
    public bool IsOver => allowedRolls == 0;
    bool IsSpare => Score == 10;

    Frame(int allowedRolls)
    {
        this.allowedRolls = allowedRolls;
    }

    public void Roll(Pins pins)
    {
        if (IsOver)
            throw new InvalidOperationException("Frame is over");

        allowedRolls--;
        Score += pins;
    }

    public void NotifyRoll(Pins pins)
    {
        if (!IsSpare)
            return;
        
        Score += pins;
    }

    public static Frame Default() => new(allowedRolls:2);
}