namespace Katas.MarsRoverKata;

public class MarsRover
{
    const string East = "E";
    const string South = "S";
    const string West = "W";
    const string North = "N";

    public const string MoveCommand = "M";
    const string RotateRightCommand = "R";
    
    int x;
    int y;
    string orientation = North;

    public string Execute(string command)
    {
        foreach (var instruction in command)
        {
            if (instruction.ToString().Equals(MoveCommand))
            {
                Move();
            }
            else
            {
                orientation = Rotate(instruction.ToString(), orientation);
            }
        }
        
        return $"{x}:{y}:{orientation}";
    }

    void Move()
    {
        if (orientation == North)
            y += 1;
        else if (orientation == East)
            x += 1;
        else
            y -= 1;
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
                West => North
            };
        }

        return currentOrientation switch
        {
            North => West,
            West => South,
            South => East,
            East => North
        };
    }

    public static MarsRover LandedAt(int x, int y)
    {
        return new MarsRover { x = x, y = y };
    }
}