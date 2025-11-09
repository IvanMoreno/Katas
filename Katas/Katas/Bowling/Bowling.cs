namespace Katas.Bowling;

public class Bowling
{
    readonly int frames;
    
    int score;
    int rollsDone;

    public bool IsOver => rollsDone == frames * 2;

    Bowling(int frames)
    {
        this.frames = frames;
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
    }

    public static Bowling NewGame(int frames = 10)
    {
        return new Bowling(frames);
    }
}