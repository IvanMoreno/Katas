namespace Katas.RockPaperScissors2;

public class Scissors {
    public bool Beats(Rock other) {
        return false;
    }

    public static Scissors Create() {
        return new Scissors();
    }
}