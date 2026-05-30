using FluentAssertions;
using static Katas.RockPaperScissors___2026.Move;
using static Katas.RockPaperScissors___2026.Outcome;

namespace Katas.RockPaperScissors___2026;

public class RockPaperScissorsTests {
    [Test]
    public void RockBeatsScissors() {
        Rock.Against(Scissors).Should().Be(Win);
    }

    [Test]
    public void ScissorsLosesAgainstRock() {
        Scissors.Against(Rock).Should().Be(Lose);
    }

    [Test]
    public void ScissorsBeatsPaper() {
        Scissors.Against(Paper).Should().Be(Win);
    }

    [Test]
    public void PaperLosesAgainstScissors() {
        Paper.Against(Scissors).Should().Be(Lose);
    }

    [Test]
    public void PaperBeatsRock() {
        Paper.Against(Rock).Should().Be(Win);
    }

    [Test]
    public void RockLosesAgainstPaper() {
        Rock.Against(Paper).Should().Be(Lose);
    }

    [Test]
    public void MovementTie() {
        Rock.Against(Rock).Should().Be(Tie);
        Scissors.Against(Scissors).Should().Be(Tie);
        Paper.Against(Paper).Should().Be(Tie);
    }

    [Test]
    public void OutcomeEquality() {
        Win.Should().NotBe(Lose);
        Win.Should().Be(Win);
    }
}