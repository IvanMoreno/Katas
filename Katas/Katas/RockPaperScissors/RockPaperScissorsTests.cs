using FluentAssertions;
using static Katas.RockPaperScissors.Move;

namespace Katas.RockPaperScissors;

// https://hackmd.io/@evalverde/rock-paper-scissors-kata
// [x] Rock beats scissors
// [x] Paper beats rock
// [x] Scissors beats paper
// [x] Same move results in draw

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

    [Test]
    public void AnnounceWinningMove()
    {
        new Match().ResultOf(Scissors, Paper)
            .Should()
            .Be("Scissors");
        
        new Match().ResultOf(Rock, Paper)
            .Should()
            .Be("Paper");
    }

    [Test]
    public void AnnounceDraw()
    {
        new Match().ResultOf(Scissors, Scissors)
            .Should()
            .Be("Draw");
    }
}