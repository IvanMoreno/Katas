using FluentAssertions;
using static Katas.RockPaperScissors.Figure;

namespace Katas.RockPaperScissors;

// https://hackmd.io/@evalverde/rock-paper-scissors-kata
// [x] Rock beats scissors
// [x] Paper beats rock
// [x] Scissors beats paper
// [] Same move results in draw

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

    [Test]
    public void ScissorBeatsPaper()
    {
        Scissors.Beats(Paper).Should().BeTrue();
        Paper.Beats(Scissors).Should().BeFalse();
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
            "Scissors" => rival == Paper
        };
    }

    public static Figure Rock => new("Rock");
    public static Figure Paper => new("Paper");
    public static Figure Scissors => new("Scissors");
}