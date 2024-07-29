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
        Scissors.Beats(Rock).Should().BeFalse();
    }
}

public record Figure(string name)
{
    public bool Beats(Figure rival)
    {
        return rival == Scissors;
    }

    public static Figure Rock => new("Rock");
    public static Figure Scissors => new("Scissors");
}