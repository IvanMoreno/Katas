using FluentAssertions;

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
        ManhattanDistance.Between(new Point(1, 1), new Point(1, 1)).Should().Be(0);
    }
    
}