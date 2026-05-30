namespace Katas.RockPaperScissors2;

public class Movement {
    readonly object winsAgainst;
    readonly object figure;

    Movement(object winsAgainst, object figure) {
        this.winsAgainst = winsAgainst;
        this.figure = figure;
    }

    public Outcome Against(Movement other) {
        return winsAgainst.GetType() == other.figure.GetType() ? Outcome.Win 
            : figure.GetType() == other.figure.GetType() ? Outcome.Tie 
            : Outcome.Lose;
    }
    
    public static Movement Rock() {
        return new Movement(winsAgainst: new Scissors(), figure: new Rock());
    }
    
    public static Movement Scissors() {
        return new Movement(winsAgainst: new Scissors(), figure: new Scissors());
    }
}