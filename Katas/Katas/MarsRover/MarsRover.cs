namespace Katas.MarsRoverKata;

public class MarsRover
{
    int y;
    
    public string Execute(string command)
    {
        y += command.Length;
        return $"0:{y}:N";
    }
}