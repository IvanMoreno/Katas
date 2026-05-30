namespace Katas.RockPaperScissors___2026;

public readonly struct Move {
    readonly Figure winsAgainst;
    readonly Figure figure;

    Move(Figure winsAgainst, Figure figure) {
        this.winsAgainst = winsAgainst;
        this.figure = figure;
    }

    public Outcome Against(Move other) 
        => winsAgainst.Equals(other.figure) ? Outcome.Win 
         : figure.Equals(other.figure) ? Outcome.Tie 
         : Outcome.Lose;

    public static Move Rock => new(winsAgainst: Figure.Scissors, figure: Figure.Rock);
    public static Move Scissors => new(winsAgainst: Figure.Paper, figure: Figure.Scissors);
    public static Move Paper => new(winsAgainst: Figure.Rock, figure: Figure.Paper);
}