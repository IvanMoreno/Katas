using FluentAssertions;
using static Katas.RockPaperScissors2.Movement;

namespace Katas.RockPaperScissors2;

public class RockPaperScissorsTests {
    [Test]
    public void RockBeatsScissors() {
        Rock().Against(Scissors()).Should().Be(Outcome.Win);
    }

    [Test]
    public void ScissorsLoosesAgainstRock() {
        Scissors().Against(Rock()).Should().Be(Outcome.Lose);
    }

    [Test]
    public void ScissorsBeatsPaper() {
        Scissors().Against(Paper()).Should().Be(Outcome.Win);
    }

    [Test]
    public void PaperLoosesAgainstScissors() {
        Paper().Against(Scissors()).Should().Be(Outcome.Lose);
    }

    [Test]
    public void PaperBeatsRock() {
        Paper().Against(Rock()).Should().Be(Outcome.Win);
    }

    [Test]
    public void MovementTie() {
        Rock().Against(Rock()).Should().Be(Outcome.Tie);
        Scissors().Against(Scissors()).Should().Be(Outcome.Tie);
        Paper().Against(Paper()).Should().Be(Outcome.Tie);
    }

    [Test]
    public void OutcomeEquality() {
        Outcome.Win.Should().NotBe(Outcome.Lose);
        Outcome.Win.Should().Be(Outcome.Win);
    }
}