namespace Katas.Mastermind;

public class CodeMaker(params Color[] secret)
{
    public GuessResult Guess(IEnumerable<Color> guess)
    {
        if (guess.Count() != secret.Length)
            throw new ArgumentException("Guess must have same length than secret");
        
        return new GuessResult(correctGuesses: WellPlacedFrom(guess), misplaced: MisplacedFrom(guess));
    }

    int MisplacedFrom(IEnumerable<Color> guess)
    {
        return secret.Zip(guess).Where(x => x.First != x.Second).Count(y => secret.Contains(y.Second));
    }

    int WellPlacedFrom(IEnumerable<Color> guess)
    {
        return secret.Zip(guess).Count(x => x.First == x.Second);
    }
}