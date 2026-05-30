namespace Katas.RockPaperScissors2;

public class Scissors {
    readonly object winsAgainst;
    
    public Scissors(object winsAgainst) {
        this.winsAgainst = winsAgainst;
    }

    public Outcome Against(object other) {
        return winsAgainst.GetType() == other.GetType() ? Outcome.Win 
            : other.GetType() == GetType() ? Outcome.Tie 
            : Outcome.Lose;
    }
    
    public static Scissors Create() {
        return new Scissors(new Scissors(default));
    }
}