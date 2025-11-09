using static System.Linq.Enumerable;

namespace Katas.Bowling;

public class Bowling
{
    readonly IEnumerable<Frame> frames;
    
    public bool IsOver => frames.All(x => x.IsOver);
    IEnumerable<Frame> FinishedFrames => frames.Where(x => x.IsOver);
    Frame CurrentFrame => frames.First(x => !x.IsOver);

    Bowling(int frames)
    {
        this.frames = Range(0, frames).Select(_ => Frame.Default()).ToList();
    }

    public int Score() => frames.Sum(x => x.Score);

    public void Roll(Pins pins)
    {
        if (IsOver)
            throw new InvalidOperationException("Game is Over");

        foreach (var finishedFrame in FinishedFrames)
        {
            finishedFrame.BonusRoll(pins);
        }
        
        CurrentFrame.Roll(pins);
    }

    public static Bowling NewGame(int frames = 10)
    {
        return new Bowling(frames);
    }
}