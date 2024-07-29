using FluentAssertions;
using static Katas.Mastermind.Color;

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
        new CodeMaker(secret: Red)
            .Guess(new[] { Red })
            .CorrectGuesses.Should().Be(1);
    }

    [Test]
    public void FailGuess_OnlyOneColor()
    {
        new CodeMaker(secret: Green)
            .Guess(new[] { Red })
            .CorrectGuesses.Should().Be(0);
    }

    [Test]
    public void FailGuess_TwoColors()
    {
        new CodeMaker(Red, Green)
            .Guess(new[] { Green, Red })
            .CorrectGuesses.Should().Be(0);
    }

    [Test]
    public void Guess_TwoCorrectColors()
    {
        new CodeMaker(Red, Green)
            .Guess(new[] { Red, Green })
            .CorrectGuesses.Should().Be(2);
    }
    
    [Test]
    public void GuessOneColor_FailTheOther()
    {
        new CodeMaker(Red, Yellow)
            .Guess(new[] { Red, Green })
            .CorrectGuesses.Should().Be(1);
    }

    [Test]
    public void RevealCorrectColor_ButMisplaced()
    {
        new CodeMaker(Red, Yellow)
            .Guess(new[] { Yellow, Green })
            .Misplaced.Should().Be(1);
    }
    
    [Test]
    public void Misplace_TwoColors()
    {
        new CodeMaker(Red, Yellow)
            .Guess(new[] { Yellow, Red })
            .Misplaced.Should().Be(2);
    }

    [Test]
    public void Misplace_OneColor_AndGuess_OneCorrectColor()
    {
        var result = new CodeMaker(Red, Yellow, Blue)
            .Guess(new[] { Blue, Yellow, Green });
        
        result.Misplaced.Should().Be(1);
        result.CorrectGuesses.Should().Be(1);
    }
}