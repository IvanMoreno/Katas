namespace Katas.Bowling;

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

    public static Pins One => 1;
    public static Pins Five => 5;
}