namespace Katas.RockPaperScissors2;

public readonly struct Outcome {
    readonly string value;

    Outcome(string value) => this.value = value;

    public static Outcome Tie => new("Tie");
    public static Outcome Win => new("Win");
    public static Outcome Lose => new("Lose");
}