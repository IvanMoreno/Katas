using FluentAssertions;

namespace Katas.Mastermind;

// https://codingdojo.org/kata/Mastermind/
// [x] Return the number of correct colors placed in the correct position
//   [x] In order for this to happen, there must exist a secret code
//   [x] It is necessary to know where a color is placed
//   [x] A secret code is the relation of a color with its position (we could use the index of the array for the moment)
// [] Return the number of correct but misplaced colors

public class MastermindTests
{
    [Test]
    public void RevealAmountOf_OneCorrectGuess()
    {
        new CodeMaker(secret: Color.Red)
            .Guess(new[] { Color.Red })
            .CorrectGuesses.Should().Be(1);
    }

    [Test]
    public void FailGuess_OnlyOneColor()
    {
        new CodeMaker(secret: Color.Green)
            .Guess(new[] { Color.Red })
            .CorrectGuesses.Should().Be(0);
    }

    [Test]
    public void FailGuess_TwoColors()
    {
        new CodeMaker(Color.Red, Color.Green)
            .Guess(new[] { Color.Green, Color.Red })
            .CorrectGuesses.Should().Be(0);
    }

    [Test]
    public void Guess_TwoCorrectColors()
    {
        new CodeMaker(Color.Red, Color.Green)
            .Guess(new[] { Color.Red, Color.Green })
            .CorrectGuesses.Should().Be(2);
    }
    
    [Test]
    public void GuessOneColor_FailTheOther()
    {
        new CodeMaker(Color.Red, Color.Yellow)
            .Guess(new[] { Color.Red, Color.Green })
            .CorrectGuesses.Should().Be(1);
    }
}