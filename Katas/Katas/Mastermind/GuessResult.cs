namespace Katas.Mastermind;

public readonly struct GuessResult(int correctGuesses, int misplaced)
{
    public readonly int CorrectGuesses = correctGuesses;
    public readonly int Misplaced = misplaced;
}