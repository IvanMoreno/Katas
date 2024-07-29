namespace Katas.Mastermind;

public class CodeMaker(params Color[] secret)
{
    public GuessResult Guess(IEnumerable<Color> guess)
    {
        if (guess.Count() != secret.Length)
            throw new ArgumentException("Guess must have same length than secret");
        
        return new GuessResult(correctGuesses: WellPlacedFrom(guess), misplaced: MisplacedFrom(guess));
    }

    int MisplacedFrom(IEnumerable<Color> guess) => CorrectColorsFrom(guess).Count(Misplaced);
    int WellPlacedFrom(IEnumerable<Color> guess) => CorrectColorsFrom(guess).Count(WellPlaced);
    static bool Misplaced((Color First, Color Second) x) => x.First != x.Second;
    static bool WellPlaced((Color First, Color Second) x) => x.First == x.Second;
    IEnumerable<(Color First, Color Second)> CorrectColorsFrom(IEnumerable<Color> guess) 
        => secret.Zip(guess).Where(secretAndGuess => secret.Contains(secretAndGuess.Second));
}