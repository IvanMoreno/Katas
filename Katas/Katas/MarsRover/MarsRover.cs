namespace Katas.MarsRoverKata;

public class MarsRover
{
    const string East = "E";
    const string South = "S";
    const string West = "W";
    const string North = "N";

    public const string MoveCommand = "M";
    const string RotateRightCommand = "R";
    const string RotateLeftCommand = "L";
    
    int x;
    int y;
    string orientation = North;

    public string Execute(string command)
    {
        InterpretCommand(command);
        return $"{x}:{y}:{orientation}";
    }

    void InterpretCommand(string command)
    {
        foreach (var instruction in command)
        {
            InterpretCommandInstruction(instruction.ToString());
        }
    }

    void InterpretCommandInstruction(string instruction)
    {
        if (instruction.Equals(MoveCommand))
        {
            Move();
        }
        else
        {
            if (instruction.Equals(RotateRightCommand))
                orientation = RotateRight();
            else
                orientation = RotateLeft();
        }
    }

    string RotateRight() =>
        orientation switch
        {
            North => East,
            East => South,
            South => West,
            West => North,
            _ => throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null)
        };

    string RotateLeft() =>
        orientation switch
        {
            North => West,
            West => South,
            South => East,
            East => North,
            _ => throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null)
        };

    void Move()
    {
        if (orientation == North)
            y += 1;
        else if (orientation == East)
            x += 1;
        else if (orientation == South)
            y -= 1;
        else
            x -= 1;
    }

    static string Rotate(string command, string currentOrientation)
    {
        if (command == RotateRightCommand)
        {
            return currentOrientation switch
            {
                North => East,
                East => South,
                South => West,
                West => North,
                _ => throw new ArgumentOutOfRangeException(nameof(currentOrientation), currentOrientation, null)
            };
        }

        return currentOrientation switch
        {
            North => West,
            West => South,
            South => East,
            East => North,
            _ => throw new ArgumentOutOfRangeException(nameof(currentOrientation), currentOrientation, null)
        };
    }

    public static MarsRover LandedAt(int x, int y)
    {
        return new MarsRover { x = x, y = y };
    }
}