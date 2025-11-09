namespace Katas.Bowling;

public class Bowling
{
    readonly List<Frame> frames;
    
    public bool IsOver => frames.All(x => x.IsOver);

    Bowling(int frames)
    {
        this.frames = new List<Frame>();
        for (var i = 0; i < frames; i++)
        {
            this.frames.Add(Frame.Default());
        }
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
            finishedFrame.NotifyRoll(pins);
        }
        
        frames.First(x => !x.IsOver).Roll(pins);
    }

    public static Bowling NewGame(int frames = 10)
    {
        return new Bowling(frames);
    }
}