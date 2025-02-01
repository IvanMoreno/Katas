namespace Katas.MarsRoverKata;

public class MarsRover
{
    public const string MoveCommand = "M";
    const string RotateRightCommand = "R";
    const string RotateLeftCommand = "L";
    
    int x;
    int y;
    readonly Compass compass = Compass.FacingNorth();

    public string Execute(string command)
    {
        InterpretCommand(command);
        return $"{x}:{y}:{compass.Orientation}";
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
                compass.RotateRight();
            else
                compass.RotateLeft();
        }
    }

    void Move()
    {
        if (compass.Orientation == Compass.North)
            y += 1;
        else if (compass.Orientation == Compass.East)
            x += 1;
        else if (compass.Orientation == Compass.South)
            y -= 1;
        else
            x -= 1;
    }

    public static MarsRover LandedAt(int x, int y)
    {
        return new MarsRover { x = x, y = y };
    }
}