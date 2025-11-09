namespace Katas.Bowling;

public class Bowling
{
    int score;
    
    public int Score()
    {
        return score;
    }

    public void Roll(Pins pins)
    {
        score += pins;
    }

    public static Bowling NewGame()
    {
        return new Bowling();
    }
}