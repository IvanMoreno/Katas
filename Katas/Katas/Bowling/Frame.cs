namespace Katas.Bowling;

public class Frame
{
    const int RollsPerFrame = 2;
    
    readonly List<int> rolls = new();
    readonly Func<Frame, bool> isOver;
    
    public int Score => rolls.Sum();
    public bool IsOver => isOver(this);
    int RemainingBonusRolls => IsStrike || IsSpare ? 3 - rolls.Count : 0;
    bool IsSpare => rolls.Count >= 2 && rolls[0] + rolls[1] == Pins.All;
    bool IsStrike => rolls.FirstOrDefault() == Pins.All;

    Frame(Func<Frame, bool> isOver) => this.isOver = isOver;

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

    public static Frame Default() => new(frame => frame.rolls.Count == RollsPerFrame || frame.IsStrike);
    public static Frame Final() => new(frame => frame.rolls.Count >= RollsPerFrame + frame.RemainingBonusRolls);
}