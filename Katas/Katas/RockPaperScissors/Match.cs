namespace Katas.RockPaperScissors;

public static class Match
{
    public static string ResultOf(Move theOne, Move theOther)
    {
        if (theOne.Equals(theOther)) return "Draw";

        return theOne.Beats(theOther) ? theOne.Figure : theOther.Figure;
    }
}