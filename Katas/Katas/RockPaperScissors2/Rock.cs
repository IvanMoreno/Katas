namespace Katas.RockPaperScissors2;

public class Rock {
    public Outcome Against(Scissors other) {
        return Outcome.Win;
    }

    public Outcome Against(Rock other) {
        return Outcome.Tie;
    }

    public static Rock Create() {
        return new Rock();
    }
}