namespace Katas.RockPaperScissors2;

public class Scissors {
    public Outcome Against(Rock other) {
        return Outcome.Lose;
    }

    public static Scissors Create() {
        return new Scissors();
    }
}