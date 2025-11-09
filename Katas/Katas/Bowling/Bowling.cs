namespace Katas.Bowling;

public class Bowling
{
    int pins;
    
    public int Score()
    {
        return pins;
    }

    public void Roll(Pins pins)
    {
        this.pins = pins;
    }

    public static Bowling NewGame()
    {
        return new Bowling();
    }
}

public readonly struct Pins
{
    readonly int howMany;

    Pins(int howMany)
    {
        if (howMany > 10)
            throw new ArgumentException("Cannot have more than 10 pins");
        
        this.howMany = howMany;
    }

    public static implicit operator int(Pins pins) => pins.howMany;
    public static implicit operator Pins(int pins) => new(pins);
}