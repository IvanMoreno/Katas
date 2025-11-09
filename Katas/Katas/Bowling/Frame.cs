namespace Katas.Bowling;

public class Frame
{
    readonly int allowedRolls;
    readonly List<int> rolls = new();

    public int Score => rolls.Sum();
    public bool IsOver => rolls.Count == allowedRolls || IsStrike;
    int RemainingBonusRolls => IsStrike ? 2 - rolls.Count + 1 : IsSpare ? 1 - rolls.Count + 2 : 0;
    bool IsSpare => rolls.Count == allowedRolls && Score == Pins.All;
    bool IsStrike => rolls.FirstOrDefault() == Pins.All;

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
        if (RemainingBonusRolls == 0)
            return;
        
        rolls.Add(pins);
    }

    public static Frame Default() => new(allowedRolls:2);
}