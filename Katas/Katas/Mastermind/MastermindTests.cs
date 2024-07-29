using FluentAssertions;

namespace Katas.Mastermind;

// https://codingdojo.org/kata/Mastermind/
// [] Return the number of correct colors placed in the correct position
//   [] In order for this to happen, there must exist a secret code
//   [] It is necessary to know where a color is placed
//   [] A secret code is the relation of a color with its position (we could use the index of the array for the moment)
// [] Return the number of correct but misplaced colors

public class MastermindTests
{
    [Test]
    public void RevealAmountOf_WellPlacedColors()
    {
        new CodeMaker(secret: Color.Red)
            .Guess(new[] { Color.Red })
            .CorrectGuesses.Should().Be(1);
    }
}

public class CodeMaker
{
    public CodeMaker(params Color[] secret)
    {
        
    }

    public GuessResult Guess(IEnumerable<Color> guess)
    {
        return new GuessResult(correctGuesses: 1);
    }
}

public readonly struct GuessResult(int correctGuesses)
{
    public readonly int CorrectGuesses = correctGuesses;
}

public enum Color
{
    Red
}