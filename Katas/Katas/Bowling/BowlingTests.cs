using FluentAssertions;
using static Katas.Bowling.Pins;

// https://www.codurance.com/katas/bowling
// [x] No score when no rolls
// [x] Score after one roll is equal to knocked down pins
// [x] Score after one frame (two rolls) is equal to sum of knocked down pins
// [x] Game is over after finishing all frames
// [x] Doing a spare includes the next roll score to the frame score
// [x] Doing a strike includes the next two roll scores to the frame score
// [x] Scoring a strike/spare in the final round allows additional rolls.

namespace Katas.Bowling;

public class BowlingTests
{
    [Test]
    public void ScoreIsZeroByDefault()
    {
        Bowling.NewGame().Score.Should().Be(0);
    }

    [Test]
    public void AddKnockedDownPinsToScore()
    {
        var sut = Bowling.NewGame();

        sut.Roll(One);

        sut.Score.Should().Be(1);
    }

    [Test]
    public void ScoreIsSumOfAllRolls()
    {
        var sut = Bowling.NewGame();
        
        sut.Roll(One);
        sut.Roll(One);

        sut.Score.Should().Be(2);
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
        var sut = Bowling.NewGame(frames: frames);
        
        sut.CompleteFrames(frames - 1);
        sut.Roll(One);

        sut.IsOver.Should().BeFalse();
    }

    [Test]
    public void SpareIncludesNextFrameFirstRollScoreToPreviousFrame()
    {
        var sut = Bowling.NewGame();

        sut.Spare();
        sut.Roll(One);

        sut.Score.Should().Be((10 + 1) + 1);
    }

    [Test]
    public void SpareIncludesOnlyNextFrameFirstRollInItsOwnScore()
    {
        var sut = Bowling.NewGame();
        
        sut.Spare();
        sut.Roll(One);
        sut.Roll(One);

        sut.Score.Should().Be((10 + 1) + 1 + 1);
    }
    
    [Test]
    public void AccumulateSpareRolls()
    {
        var sut = Bowling.NewGame();
        
        sut.Spare();
        sut.Spare();
        sut.Spare();

        sut.Score.Should().Be((5 + 5 + 5) + (5 + 5 + 5) + (5 + 5));
    }

    [Test]
    public void NonSpareFramesDoNotIncludeNextFrameRollToScore()
    {
        var sut = Bowling.NewGame();
        
        sut.Roll(One);
        sut.Roll(One);
        sut.Roll(One);

        sut.Score.Should().Be(1 + 1 + 1);
    }

    [Test]
    public void StrikeEndsTheFrame()
    {
        var sut = Frame.Default();

        sut.Roll(All);

        sut.IsOver.Should().BeTrue();
    }
    
    [Test]
    public void StrikeFrameContainsNextTwoRollsScore()
    {
        var sut = Bowling.NewGame();
        
        sut.Strike();
        sut.Roll(One);
        sut.Roll(One);

        sut.Score.Should().Be((10 + 1 + 1) + 1 + 1);
    }
    
    [Test]
    public void StrikeFrameContainsOnlyNextTwoRollsScore()
    {
        var sut = Bowling.NewGame();
        
        sut.Strike();
        sut.Roll(One);
        sut.Roll(One);
        sut.Roll(One);

        sut.Score.Should().Be((10 + 1 + 1) + 1 + 1 + 1);
    }

    [Test]
    public void StrikeInFinalFrameAllowsMoreRolls()
    {
        var sut = Bowling.NewGame(frames: 1);
        
        sut.Strike();

        sut.IsOver.Should().BeFalse();
    }

    [Test]
    public void SpareInFinalFrameAllowsMoreRolls()
    {
        var sut = Bowling.NewGame(frames: 1);
        
        sut.Spare();

        sut.IsOver.Should().BeFalse();
    }

    [Test]
    public void StrikeInFinalFrameAllowsTwoMoreRolls()
    {
        var sut = Bowling.NewGame(frames: 1);
        
        sut.Strike();
        sut.Roll(One);
        sut.Roll(One);

        sut.IsOver.Should().BeTrue();
        sut.Score.Should().Be(10 + 1 + 1);
    }
    
    [Test]
    public void SpareInFinalFrameAllowsOneMoreRoll()
    {
        var sut = Bowling.NewGame(frames: 1);
        
        sut.Spare();
        sut.Roll(One);

        sut.IsOver.Should().BeTrue();
        sut.Score.Should().Be(10 + 1);
    }
}

public class BowlingAcceptanceTest
{
    [TestCase("[9,0] [9,0] [9,0] [9,0] [9,0] [9,0] [9,0] [9,0] [9,0] [9,0]", 90)]
    [TestCase("[6,3] [5,2] [8,1] [3,2] [5,1] [5,3] [4,0] [4,3] [2,1] [6,2]", 66)]
    [TestCase("[10] [10] [10] [10] [10] [10] [10] [10] [10] [10,10,10]", 300)]
    [TestCase("[5,5] [5,5] [5,5] [5,5] [5,5] [5,5] [5,5] [5,5] [5,5] [5,5,5]", 150)]
    public void AcceptanceTest(string game, int expectedScore)
    {
        var sut = Bowling.NewGame();
        var rolls = game.Replace("[", string.Empty).Replace("]", string.Empty).Replace(" ", ",").Split(',').Select(int.Parse);

        foreach (var roll in rolls)
        {
            sut.Roll(roll);
        }

        sut.Score.Should().Be(expectedScore);
    }
}