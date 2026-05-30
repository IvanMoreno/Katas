namespace Katas.RockPaperScissors___2026;

public readonly struct Move {
    readonly Figure depicted;
    readonly Figure beats;

    Move(Figure beats, Figure depicted) {
        this.beats = beats;
        this.depicted = depicted;
    }

    public Outcome Against(Move other) 
        => beats.Equals(other.depicted) ? Outcome.Win 
         : depicted.Equals(other.depicted) ? Outcome.Tie 
         : Outcome.Lose;

    public static Move Rock => new(beats: Figure.Scissors, depicted: Figure.Rock);
    public static Move Scissors => new(beats: Figure.Paper, depicted: Figure.Scissors);
    public static Move Paper => new(beats: Figure.Rock, depicted: Figure.Paper);
}