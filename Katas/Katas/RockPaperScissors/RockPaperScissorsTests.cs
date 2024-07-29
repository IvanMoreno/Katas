using FluentAssertions;
using static Katas.RockPaperScissors.Move;

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

    [Test]
    public void SameMoves_ResultsInDraw()
    {
        Scissors.Beats(Scissors).Should().BeFalse();
        Paper.Beats(Paper).Should().BeFalse();
        Rock.Beats(Rock).Should().BeFalse();
    }
}

public record Move(string Figure)
{
    public bool Beats(Move opposed)
    {
        return Figure switch
        {
            "Rock" => opposed == Scissors,
            "Paper" => opposed == Rock,
            "Scissors" => opposed == Paper
        };
    }

    public static Move Rock => new("Rock");
    public static Move Paper => new("Paper");
    public static Move Scissors => new("Scissors");
}