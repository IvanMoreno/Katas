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
            orientation = "E";
        return $"0:{y}:{orientation}";
    }
}