namespace Katas.Bowling;

public class Frame
{
    readonly int allowedRolls;
    readonly bool isFinal;
    readonly List<int> rolls = new();

    public int Score => rolls.Sum();
    public bool IsOver => rolls.Count == (isFinal && IsSpare ? allowedRolls + 1 : allowedRolls) || IsStrike && !isFinal;
    int RemainingBonusRolls => IsStrike || IsSpare ? 2 - rolls.Count + 1 : 0;
    bool IsSpare => rolls.Count == allowedRolls && Score == Pins.All;
    bool IsStrike => rolls.FirstOrDefault() == Pins.All;

    Frame(int allowedRolls, bool isFinal)
    {
        this.allowedRolls = allowedRolls;
        this.isFinal = isFinal;
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

    public static Frame Default() => new(allowedRolls: 2, isFinal:false);
    public static Frame Final() => new(allowedRolls:2, isFinal:true);
}