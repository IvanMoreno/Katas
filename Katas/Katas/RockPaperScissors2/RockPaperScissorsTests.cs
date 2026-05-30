using FluentAssertions;

namespace Katas.RockPaperScissors2;

public class RockPaperScissorsTests {
    [Test]
    public void RockBeatsScissors() {
        Rock.Create().Beats(Scissors.Create()).Should().BeTrue();
    }

    [Test]
    public void ScissorsLoosesAgainstRock() {
        Scissors.Create().Beats(Rock.Create()).Should().BeFalse();
    }
}