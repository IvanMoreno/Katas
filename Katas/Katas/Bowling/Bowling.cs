using static System.Linq.Enumerable;

namespace Katas.Bowling;

public class Bowling
{
    readonly IEnumerable<Frame> frames;
    
    public bool IsOver => frames.All(x => x.IsOver);

    Bowling(int frames)
    {
        this.frames = Range(0, frames).Select(_ => Frame.Default()).ToList();
    }

    public int Score()
    {
        return frames.Sum(x => x.Score);
    }

    public void Roll(Pins pins)
    {
        if (IsOver)
            throw new InvalidOperationException("Game is Over");

        foreach (var finishedFrame in frames.Where(x => x.IsOver))
        {
            finishedFrame.RegisterSubsequentFrameRoll(pins);
        }
        
        frames.First(x => !x.IsOver).Roll(pins);
    }

    public static Bowling NewGame(int frames = 10)
    {
        return new Bowling(frames);
    }
}