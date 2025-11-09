namespace Katas.Bowling;

public class Frame
{
    readonly int allowedRolls;
    readonly List<int> playedRolls = new();

    public int Score => playedRolls.Sum();
    public bool IsOver => playedRolls.Count == allowedRolls;
    bool IsSpare => Score == 10;

    Frame(int allowedRolls)
    {
        this.allowedRolls = allowedRolls;
    }

    public void Roll(Pins pins)
    {
        if (IsOver)
            throw new InvalidOperationException("Frame is over");

        playedRolls.Add(pins);
    }

    public void NotifyRoll(Pins pins)
    {
        if (!IsSpare)
            return;
        
        playedRolls.Add(pins);
    }

    public static Frame Default() => new(allowedRolls:2);
}