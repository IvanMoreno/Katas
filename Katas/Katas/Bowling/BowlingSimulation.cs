namespace Katas.Bowling;

public static class BowlingSimulation
{
    public static void CompleteFrames(this Bowling bowling, int frames)
    {
        for (var i = 0; i < frames; i++)
        {
            bowling.Roll(Pins.One);
            bowling.Roll(Pins.One);
        }
    }
}