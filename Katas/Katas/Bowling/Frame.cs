namespace Katas.Bowling;

public class Frame
{
    readonly int allowedRolls;
    readonly List<int> rolls = new();

    public int Score => rolls.Sum();
    public bool IsOver => rolls.Count == allowedRolls || Score == Pins.All;
    bool IsSpare => rolls.Count == allowedRolls && Score == Pins.All;
    bool IsStrike => rolls.First() == Pins.All;

    Frame(int allowedRolls)
    {
        this.allowedRolls = allowedRolls;
    }

    public void Roll(Pins pins)
    {
        if (IsOver)
            throw new InvalidOperationException("Frame is over");

        rolls.Add(pins);
    }

    public void NotifyRoll(Pins pins)
    {
        if (!IsSpare && !IsStrike)
            return;
        
        rolls.Add(pins);
    }

    public static Frame Default() => new(allowedRolls:2);
}