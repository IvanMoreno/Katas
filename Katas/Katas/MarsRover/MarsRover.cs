namespace Katas.MarsRoverKata;

public class MarsRover
{
    int y;
    
    public string Execute(string command)
    {
        var orientation = "N";
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
                "N" => "E",
            };
        }

        return currentOrientation switch
        {
            "N" => "W",
            "W" => "S"
        };
    }
}