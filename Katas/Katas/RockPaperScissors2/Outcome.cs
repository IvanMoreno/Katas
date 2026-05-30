namespace Katas.RockPaperScissors2;

public struct Outcome(string value) {
    public static Outcome Tie => new("Tie");
    public static Outcome Win => new("Win");
    public static Outcome Lose => new("Lose");
}