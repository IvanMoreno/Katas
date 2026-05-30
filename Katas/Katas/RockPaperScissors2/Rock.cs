namespace Katas.RockPaperScissors2;

public class Movement {
    protected object winsAgainst;

    public Outcome Against(object other) {
        return winsAgainst.GetType() == other.GetType() ? Outcome.Win 
            : other.GetType() == GetType() ? Outcome.Tie 
            : Outcome.Lose;
    }
}

public class Rock : Movement {
    public Rock(object winsAgainst) {
        this.winsAgainst = winsAgainst;
    }

    public static Rock Create() {
        return new Rock(winsAgainst: new Scissors(default));
    }
}