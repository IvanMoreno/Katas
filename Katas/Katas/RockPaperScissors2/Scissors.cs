namespace Katas.RockPaperScissors2;

public class Scissors {
    public bool Against(Rock other) {
        return false;
    }

    public static Scissors Create() {
        return new Scissors();
    }
}