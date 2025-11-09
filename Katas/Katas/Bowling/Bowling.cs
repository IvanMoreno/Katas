namespace Katas.Bowling;

public class Bowling
{
    int score;

    public bool IsOver { get; private set; }

    public int Score()
    {
        return score;
    }

    public void Roll(Pins pins)
    {
        score += pins;
        
        if (score > 1)
            IsOver = true;
    }

    public static Bowling NewGame(int frames = 10)
    {
        return new Bowling();
    }
}