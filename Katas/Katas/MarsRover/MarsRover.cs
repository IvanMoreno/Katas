namespace Katas.MarsRoverKata;

public class MarsRover
{
    int y;
    string orientation = "N";

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
                "N" => "E",
                "E" => "S",
                "S" => "W",
                "W" => "N"
            };
        }

        return currentOrientation switch
        {
            "N" => "W",
            "W" => "S",
            "S" => "E",
            "E" => "N"
        };
    }
}