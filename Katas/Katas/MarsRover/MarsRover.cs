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
            if (command == "R")
                orientation = "E";
            else if (command.Length == 1)
                orientation = "W";
            else if (command.Length == 2)
                orientation = "S";
        }
        
        return $"0:{y}:{orientation}";
    }
}