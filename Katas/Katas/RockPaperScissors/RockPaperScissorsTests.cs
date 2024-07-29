using FluentAssertions;
using static Katas.RockPaperScissors.Figure;

namespace Katas.RockPaperScissors;

// https://hackmd.io/@evalverde/rock-paper-scissors-kata
// Rock beats scissors

public class RockPaperScissorsTests
{
    [Test]
    public void RockBeatsScissors()
    {
        Rock.Beats(Scissors).Should().BeTrue();
    }
}

public class Figure
{
    public bool Beats(object scissors)
    {
        return true;
    }

    public static Figure Rock => new();
    public static Figure Scissors => new();
}