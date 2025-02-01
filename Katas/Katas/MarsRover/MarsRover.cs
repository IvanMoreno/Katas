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
            orientation = Rotate(command);
        }
        
        return $"0:{y}:{orientation}";
    }

    static string Rotate(string command)
    {
        if (command == "R")
            return "E";
        else if (command.Length == 1)
            return "W";
        else if (command.Length == 2)
            return "S";

        return "";
    }
}