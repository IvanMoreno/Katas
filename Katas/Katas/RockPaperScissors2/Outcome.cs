namespace Katas.RockPaperScissors2;

public struct Outcome(string value) {
    public static Outcome Tie => new("Tie");
}