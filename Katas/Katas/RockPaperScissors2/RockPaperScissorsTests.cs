using FluentAssertions;

namespace Katas.RockPaperScissors2;

public class RockPaperScissorsTests {
    [Test]
    public void RockBeatsScissors() {
        Rock.Create().Against(Scissors.Create()).Should().Be(Outcome.Win);
    }

    [Test]
    public void ScissorsLoosesAgainstRock() {
        Scissors.Create().Against(Rock.Create()).Should().Be(Outcome.Lose);
    }

    [Test]
    public void RockTiesAgainstItself() {
        Rock.Create().Against(Rock.Create()).Should().Be(Outcome.Tie);
    }

    [Test]
    public void OutcomeEquality() {
        Outcome.Win.Should().NotBe(Outcome.Lose);
        Outcome.Win.Should().Be(Outcome.Win);
    }
}