namespace Katas.RockPaperScissors2;

public class Rock {
    public bool Against(Scissors other) {
        return true;
    }

    public Outcome Against(Rock other) {
        return Outcome.Tie;
    }

    public static Rock Create() {
        return new Rock();
    }
}