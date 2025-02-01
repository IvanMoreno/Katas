namespace Katas.MarsRoverKata;

public class Compass
{
    public const string East = "E";
    public const string South = "S";
    public const string West = "W";
    public const string North = "N";

    public string Orientation { get; private set; }= North;
    public int NextX { get; set; }

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
}