using FluentAssertions;
using static Katas.Bowling.Pins;

// https://www.codurance.com/katas/bowling
// A game of bowling is made up of ten "frames". In each frame a player has two rolls of a ball to try to knock down all 10 pins.
// The number of pins knocked down in a frame is the score for that frame, and the game score is the total of the scores from each frame.

// If a player knocks down all 10 pins with two rolls in a frame, this is a Spare. The score from their next roll is added to the 10 points for the spare.
// - Spare example - 
// Frame |        1         |    2
// Rolls |      6 - 4       | *5* - 3
// Score | 15 (6 + 4 + *5*) |    8

// If a player knocks down all 10 pins with a single roll, this is a Strike. The frame is over, and the score from their next two rolls is added to the 10 points for the strike.
// - Strike example - 
// Frame |        1         |   2
// Rolls |      10 - -      | 5 - 3
// Score | 18 (10 + 5 + 3)   |   8

// Note: since the true score for a Strike or Spare is dependent on the next ball or two, if a player scores a Strike or a Spare in the final (10th) frame, then they can roll the additional balls required to finish calculating the score.

// Example Games
// [9,0] [9,0] [9,0] [9,0] [9,0] [9,0] [9,0] [9,0] [9,0] [9,0] = 90
// [6,3] [5,2] [8,1] [3,2] [5,1] [5,3] [4,0] [4,3] [2,1] [6,2] = 66
// [10] [10] [10] [10] [10] [10] [10] [10] [10] [10, 10, 10] = 300
// [5,5] [5,5] [5,5] [5,5] [5,5] [5,5] [5,5] [5,5] [5,5] [5,5,5] = 150

// TODO
// [x] No score when no rolls
// [x] Score after one roll is equal to knocked down pins
// [x] Score after one frame (two rolls) is equal to sum of knocked down pins
// [] Game is over after finishing all frames
// [] Doing a spare includes the next roll score to the frame score
// [] Doing a strike includes the next two roll scores to the frame score
// [] Scoring a strike/spare in the final round allows additional rolls.

namespace Katas.Bowling;

public class BowlingTests
{
    [Test]
    public void ScoreIsZeroByDefault()
    {
        Bowling.NewGame().Score().Should().Be(0);
    }

    [Test]
    public void AddKnockedDownPinsToScore()
    {
        var sut = Bowling.NewGame();

        sut.Roll(One);

        sut.Score().Should().Be(1);
    }

    [Test]
    public void ScoreIsSumOfAllRolls()
    {
        var sut = Bowling.NewGame();
        
        sut.Roll(One);
        sut.Roll(One);

        sut.Score().Should().Be(2);
    }

    [Test]
    public void GameIsNotOverByDefault()
    {
        Bowling.NewGame().IsOver.Should().BeFalse();
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void GameIsOverAfterCompletingNecessaryFrames(int frames)
    {
        var sut = Bowling.NewGame(frames: frames);

        sut.CompleteFrames(frames);

        sut.IsOver.Should().BeTrue();
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void GameIsNotOverUntilAllFramesAreCompleted(int frames)
    {
        var sut = Bowling.NewGame(frames: 1);
        
        sut.CompleteFrames(frames - 1);
        sut.Roll(One);

        sut.IsOver.Should().BeFalse();
    }
}