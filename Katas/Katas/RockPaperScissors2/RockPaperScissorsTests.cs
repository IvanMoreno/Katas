using FluentAssertions;

namespace Katas.RockPaperScissors2;

public class RockPaperScissorsTests {
    [Test]
    public void RockBeatsScissors() {
        new Rock().Beats(new Scissors()).Should().BeTrue();
    }

    [Test]
    public void ScissorsLoosesAgainstRock() {
        new Scissors().Beats(new Rock()).Should().BeFalse();
    }
}