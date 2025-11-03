public class ManhattanDistance
{
    public static int Between(Point a, Point b)
    {
        return Math.Abs(b.ElementSum() - a.ElementSum());
    }
}