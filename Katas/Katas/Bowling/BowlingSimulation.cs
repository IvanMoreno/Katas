using static Katas.Bowling.Pins;

namespace Katas.Bowling;

public static class BowlingSimulation
{
    public static void CompleteFrames(this Bowling bowling, int frames)
    {
        for (var i = 0; i < frames; i++)
        {
            bowling.Roll(One);
            bowling.Roll(One);
        }
    }

    public static void Spare(this Bowling bowling)
    {
        bowling.Roll(Five);
        bowling.Roll(Five);
    }
    
    public static void Strike(this Bowling bowling)
    {
        bowling.Roll(All);
    }
}