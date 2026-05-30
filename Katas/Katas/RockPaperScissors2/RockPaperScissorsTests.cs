using FluentAssertions;

namespace Katas.RockPaperScissors2;

public class RockPaperScissorsTests {
    [Test]
    public void RockBeatsScissors() {
        Rock.Create().Against(Scissors.Create()).Should().BeTrue();
    }

    [Test]
    public void ScissorsLoosesAgainstRock() {
        Scissors.Create().Against(Rock.Create()).Should().BeFalse();
    }

    [Test]
    public void RockTiesAgainstItself() {
        Rock.Create().Against(Rock.Create()).Should().Be(Outcome.Tie);
    }
}

public struct Outcome(string value) {
    public static Outcome Tie => new("Tie");
}