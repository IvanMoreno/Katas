namespace Katas.RockPaperScissors;

public record Move(string Figure)
{
    public bool Beats(Move opposed) 
        => Figure switch
        {
            "Rock" => opposed == Scissors,
            "Paper" => opposed == Rock,
            "Scissors" => opposed == Paper
        };

    public static Move Rock => new("Rock");
    public static Move Paper => new("Paper");
    public static Move Scissors => new("Scissors");
}