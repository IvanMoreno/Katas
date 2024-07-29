namespace Katas.RockPaperScissors;

public record Move
{
    static Dictionary<Move, Move> WinnerOf => new()
    {
        { Rock, Paper },
        { Paper, Scissors },
        { Scissors, Rock }
    };

    readonly string figure;
    Move(string figure) => this.figure = figure;

    public bool Beats(Move opponent) => WinnerOf[opponent] == this;
    public override string ToString() => figure;
    
    public static Move Rock => new("Rock");
    public static Move Paper => new("Paper");
    public static Move Scissors => new("Scissors");
}