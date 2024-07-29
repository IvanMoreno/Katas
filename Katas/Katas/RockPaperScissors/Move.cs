namespace Katas.RockPaperScissors;

public record Move
{
    readonly string figure;
    Move(string figure) => this.figure = figure;

    public bool Beats(Move opposed) 
        => figure switch
        {
            "Rock" => opposed == Scissors,
            "Paper" => opposed == Rock,
            "Scissors" => opposed == Paper
        };

    public override string ToString() => figure;
    public static Move Rock => new("Rock");
    public static Move Paper => new("Paper");
    public static Move Scissors => new("Scissors");
}