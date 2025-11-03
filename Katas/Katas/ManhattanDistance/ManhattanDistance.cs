public class ManhattanDistance
{
    public static int Between(Point a, Point b)
    {
        return b.ElementSum() - a.ElementSum();
    }
}