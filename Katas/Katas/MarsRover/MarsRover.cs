namespace Katas.MarsRoverKata;

public class MarsRover
{
    public const string MoveCommand = "M";
    const string RotateRightCommand = "R";
    const string RotateLeftCommand = "L";

    int x;
    int y;
    readonly Compass compass = Compass.FacingNorth();
    readonly Plateau plateau = Plateau.A10x10();

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
        if (compass.DirectionY != 0)
            y = plateau.NextY(y, compass.DirectionY);
        
        if (compass.DirectionX != 0)
            x = plateau.NextX(x, compass.DirectionX);
    }

    public static MarsRover LandedAt(int x, int y)
    {
        return new MarsRover { x = x, y = y };
    }
}