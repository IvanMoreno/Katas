namespace Katas.RockPaperScissors2;

public class Movement {
    readonly Figure winsAgainst;
    readonly Figure figure;

    Movement(Figure winsAgainst, Figure figure) {
        this.winsAgainst = winsAgainst;
        this.figure = figure;
    }

    public Outcome Against(Movement other) {
        return winsAgainst.Equals(other.figure) ? Outcome.Win 
            : figure.Equals(other.figure) ? Outcome.Tie 
            : Outcome.Lose;
    }
    
    public static Movement Rock() {
        return new Movement(winsAgainst: Figure.Scissors, figure: Figure.Rock);
    }
    
    public static Movement Scissors() {
        return new Movement(winsAgainst: Figure.Scissors, figure: Figure.Scissors);
    }
}