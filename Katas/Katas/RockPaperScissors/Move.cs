namespace Katas.RockPaperScissors;

public record Move
{
    readonly string figure;
    Move(string figure) => this.figure = figure;

    public bool Beats(Move opponent) 
        => figure switch
        {
            "Rock" => opponent == Scissors,
            "Paper" => opponent == Rock,
            "Scissors" => opponent == Paper,
            _ => throw new NotImplementedException($"{figure}'s opponent is not implemented")
        };

    public override string ToString() => figure;
    public static Move Rock => new("Rock");
    public static Move Paper => new("Paper");
    public static Move Scissors => new("Scissors");
}