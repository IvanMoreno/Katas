namespace Katas.Bowling;

public class Bowling
{
    int pins;
    
    public int Score()
    {
        return pins;
    }

    public void Roll(int pins)
    {
        this.pins = pins;
    }

    public static Bowling NewGame()
    {
        return new Bowling();
    }
}