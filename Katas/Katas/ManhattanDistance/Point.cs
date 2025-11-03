public readonly struct Point
{
    readonly int x;
    readonly int y;

    Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Point Point2D(int x, int y)
    {
        return new Point(x, y);
    }
}