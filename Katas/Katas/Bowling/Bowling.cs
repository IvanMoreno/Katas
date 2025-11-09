namespace Katas.Bowling;

public class Bowling
{
    int score;
    bool isOver;

    public bool IsOver => isOver;

    public int Score()
    {
        return score;
    }

    public void Roll(Pins pins)
    {
        isOver = true;
        score += pins;
    }

    public static Bowling NewGame(int frames = 10)
    {
        return new Bowling();
    }
}