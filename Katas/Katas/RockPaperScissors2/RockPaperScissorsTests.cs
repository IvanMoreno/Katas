using FluentAssertions;

namespace Katas.RockPaperScissors2;

public class RockPaperScissorsTests {
    [Test]
    public void RockBeatsScissors() {
        Movement.Rock().Against(Scissors.Create()).Should().Be(Outcome.Win);
    }

    [Test]
    public void ScissorsLoosesAgainstRock() {
        Scissors.Create().Against(Movement.Rock()).Should().Be(Outcome.Lose);
    }

    [Test]
    public void RockTiesAgainstItself() {
        Movement.Rock().Against(Movement.Rock()).Should().Be(Outcome.Tie);
    }

    [Test]
    public void OutcomeEquality() {
        Outcome.Win.Should().NotBe(Outcome.Lose);
        Outcome.Win.Should().Be(Outcome.Win);
    }
}