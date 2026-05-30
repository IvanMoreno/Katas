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
    public void RockTiesAgainstItself() {
        Rock().Against(Rock()).Should().Be(Outcome.Tie);
    }

    [Test]
    public void OutcomeEquality() {
        Outcome.Win.Should().NotBe(Outcome.Lose);
        Outcome.Win.Should().Be(Outcome.Win);
    }
}