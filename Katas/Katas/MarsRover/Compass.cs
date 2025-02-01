namespace Katas.MarsRoverKata;

public class Compass
{
    public const string East = "E";

    public const string South = "S";

    public const string West = "W";

    public const string North = "N";

    public string Orientation { get; private set; }

    public int NextX => Orientation.Equals(East) ? 1 : Orientation.Equals(East) ? -1 : 0;
    public int NextY => Orientation.Equals(North) ? 1 : Orientation.Equals(South) ? -1 : 0;

    public void RotateRight() =>
        Orientation = Orientation switch
        {
            North => East,
            East => South,
            South => West,
            West => North,
            _ => throw new ArgumentOutOfRangeException()
        };

    public void RotateLeft() =>
        Orientation = Orientation switch
        {
            North => West,
            West => South,
            South => East,
            East => North,
            _ => throw new ArgumentOutOfRangeException()
        };

    public static Compass FacingNorth() => new() {Orientation = North};
}