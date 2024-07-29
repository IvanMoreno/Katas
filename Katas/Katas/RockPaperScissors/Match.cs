namespace Katas.RockPaperScissors;

public class Match
{
    public string ResultOf(Move scissors, Move paper)
    {
        if (scissors == paper) return "Draw";
        
        return scissors.Beats(paper) ? scissors.Figure : paper.Figure;
    }
}