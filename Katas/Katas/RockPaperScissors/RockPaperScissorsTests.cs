using FluentAssertions;
using static Katas.RockPaperScissors.Figure;

namespace Katas.RockPaperScissors;

// https://hackmd.io/@evalverde/rock-paper-scissors-kata
// [x] Rock beats scissors
// [] Paper beats rock
public class RockPaperScissorsTests
{
    [Test]
    public void RockBeatsScissors()
    {
        Rock.Beats(Scissors).Should().BeTrue();
        Scissors.Beats(Rock).Should().BeFalse();
    }

    [Test]
    public void PaperBeatsRock()
    {
        Paper.Beats(Rock).Should().BeTrue();
        Rock.Beats(Paper).Should().BeFalse();
    }
}

public record Figure(string name)
{
    public bool Beats(Figure rival)
    {
        return name switch
        {
            "Rock" => rival == Scissors,
            "Paper" => rival == Rock,
            "Scissors" => false
        };
    }

    public static Figure Rock => new("Rock");
    public static Figure Paper => new("Paper");
    public static Figure Scissors => new("Scissors");
}