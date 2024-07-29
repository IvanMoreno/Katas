namespace Katas.Mastermind;

public readonly struct GuessResult(int correctGuesses)
{
    public readonly int CorrectGuesses = correctGuesses;
}