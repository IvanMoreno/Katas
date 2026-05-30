namespace Katas.RockPaperScissors2;

public class Rock {
    public bool Beats(Scissors other) {
        return true;
    }

    public static Rock Create() {
        return new Rock();
    }
}