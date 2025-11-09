using System.Collections.Immutable;

namespace Katas.Bowling;

public class Bowling
{
    readonly int frames;
    readonly List<Frame> frames2;
    
    int score;
    int rollsDone;
    int currentFrame;

    public bool IsOver => rollsDone == frames * 2;

    Bowling(int frames)
    {
        this.frames = frames;
        
        frames2 = new List<Frame>();
        for (var i = 0; i < frames; i++)
        {
            frames2.Add(Frame.Default());
        }
    }

    public int Score()
    {
        return score;
    }

    public void Roll(Pins pins)
    {
        if (IsOver)
            throw new InvalidOperationException("Game is Over");
        
        score += pins;
        rollsDone++;

        frames2[currentFrame] = frames2[currentFrame].Rolled(pins);
        if (frames2[currentFrame].IsOver)
            currentFrame++;
    }

    public static Bowling NewGame(int frames = 10)
    {
        return new Bowling(frames);
    }
}