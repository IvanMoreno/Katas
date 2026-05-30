namespace Katas.RockPaperScissors2;

public readonly struct Movement {
    readonly Figure winsAgainst;
    readonly Figure figure;

    Movement(Figure winsAgainst, Figure figure) {
        this.winsAgainst = winsAgainst;
        this.figure = figure;
    }

    public Outcome Against(Movement other) 
        => winsAgainst.Equals(other.figure) ? Outcome.Win 
         : figure.Equals(other.figure) ? Outcome.Tie 
         : Outcome.Lose;

    public static Movement Rock => new(winsAgainst: Figure.Scissors, figure: Figure.Rock);
    public static Movement Scissors => new(winsAgainst: Figure.Paper, figure: Figure.Scissors);
    public static Movement Paper => new(winsAgainst: Figure.Rock, figure: Figure.Paper);
}