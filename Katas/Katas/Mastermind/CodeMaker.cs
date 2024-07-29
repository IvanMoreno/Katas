namespace Katas.Mastermind;

public class CodeMaker(params Color[] secret)
{
    public GuessResult Guess(IEnumerable<Color> guess)
    {
        if (guess.Count() != secret.Length)
            throw new ArgumentException("Guess must have same length than secret");
        
        return new GuessResult(correctGuesses: WellPlacedFrom(guess), 1);
    }

    int WellPlacedFrom(IEnumerable<Color> guess)
    {
        return secret.Zip(guess).Count(x => x.First == x.Second);
    }
}