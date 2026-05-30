using FluentAssertions;

namespace Katas.RockPaperScissors2;

public class RockPaperScissorsTests {
    [Test]
    public void RockBeatsScissors() {
        new Rock().Beats(new Scissors()).Should().BeTrue();
    }
}