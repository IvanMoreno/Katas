namespace Katas.Bowling;

public class Frame
{
    readonly int allowedRolls;
    readonly bool isFinal;
    readonly List<int> rolls = new();
    readonly Func<Frame, bool> isOver;
    
    public int Score => rolls.Sum();
    public bool IsOver => isOver(this);
    int RemainingBonusRolls => IsStrike || IsSpare ? 2 - rolls.Count + 1 : 0;
    bool IsSpare => rolls.Count == allowedRolls && Score == Pins.All;
    bool IsStrike => rolls.FirstOrDefault() == Pins.All;

    Frame(int allowedRolls, Func<Frame, bool> isOver)
    {
        this.allowedRolls = allowedRolls;
        this.isOver = isOver;
    }

    public void Roll(Pins pins)
    {
        if (IsOver)
            throw new InvalidOperationException("Frame is over");

        rolls.Add(pins);
    }

    public void BonusRoll(Pins pins)
    {
        if (RemainingBonusRolls == 0)
            return;
        
        rolls.Add(pins);
    }

    public static Frame Default() => new(allowedRolls: 2, frame => frame.rolls.Count == 2 || frame.IsStrike);
    public static Frame Final() => new(allowedRolls:2, frame => frame.rolls.Count == 2 + frame.RemainingBonusRolls);
}