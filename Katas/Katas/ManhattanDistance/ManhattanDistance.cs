namespace Katas.ManhattanDistance;

public class ManhattanDistance
{
    public static int Between(Point a, Point b) => Math.Abs(a.ElementSum() - b.ElementSum());
}