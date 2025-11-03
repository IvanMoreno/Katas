using FluentAssertions;
using static Point;

// https://codingdojo.org/kata/manhattan-distance/
// Manhattan distance is the distance between two points in a grid (like the grid-like street geography of the New York borough of Manhattan)
// calculated by only taking a vertical and/or horizontal path.

// Return Manhattan Distance between two points.
// The class Point is immutable
// The class Point has no Getters, no Setters
// The class Point has no public properties (i.e. the internal state cannot be read from outside the class).

public class ManhattanDistanceTests
{
    [Test]
    public void DistanceIsZero_BetweenSameTwoPoints()
    {
        ManhattanDistance.Between(Point2D(1, 1), Point2D(1, 1)).Should().Be(0);
    }

    [Test]
    public void CalculateDistance_BasedOnXAxis()
    {
        ManhattanDistance.Between(Point2D(1, 1), Point2D(3, 1)).Should().Be(2);
        ManhattanDistance.Between(Point2D(1, 1), Point2D(2, 1)).Should().Be(1);
        ManhattanDistance.Between(Point2D(5, 1), Point2D(1, 1)).Should().Be(4);
    }

    [Test]
    public void CalculateDistance_BasedOnYAxis()
    {
        ManhattanDistance.Between(Point2D(1, 1), Point2D(1, 2)).Should().Be(1);
        ManhattanDistance.Between(Point2D(1, 1), Point2D(1, 4)).Should().Be(3);
        ManhattanDistance.Between(Point2D(1, 3), Point2D(1, 2)).Should().Be(1);
    }
}