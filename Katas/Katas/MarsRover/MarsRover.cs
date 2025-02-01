namespace Katas.MarsRoverKata;

public class MarsRover
{
    const string East = "E";
    const string South = "S";
    const string West = "W";
    const string North = "N";
    
    int y;
    string orientation = North;

    public string Execute(string command)
    {
        if (command.Contains("M"))
            y += command.Length;
        else
        {
            foreach (var instruction in command)
            {
                orientation = Rotate(instruction.ToString(), orientation);
            }
        }
        
        return $"0:{y}:{orientation}";
    }

    static string Rotate(string command, string currentOrientation)
    {
        if (command == "R")
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
}