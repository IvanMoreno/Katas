namespace Katas.RockPaperScissors2;

public class Movement {
    protected object winsAgainst;
    
    public Movement(object winsAgainst) {
        this.winsAgainst = winsAgainst;
    }

    public Outcome Against(object other) {
        return winsAgainst.GetType() == other.GetType() ? Outcome.Win 
            : other.GetType() == GetType() ? Outcome.Tie 
            : Outcome.Lose;
    }
    
    public static Movement Rock() {
        return new Movement(winsAgainst: new Scissors(default));
    }
}

public class Rock { }