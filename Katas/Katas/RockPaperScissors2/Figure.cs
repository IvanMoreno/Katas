namespace Katas.RockPaperScissors2;

public readonly struct Figure {
    readonly string shape;
    Figure(string shape) {
        this.shape = shape;
    }

    public static Figure Scissors => new("Scissors");
    public static Figure Rock => new("Rock");
}