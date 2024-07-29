namespace Katas.RockPaperScissors;

public static class Match
{
    public static string ResultOf(Move theOne, Move theOther)
        => IsDraw(theOne, theOther)
            ? "Draw"
            : Winner(theOne, theOther);

    static bool IsDraw(Move theOne, Move theOther) 
        => theOne.Equals(theOther);

    static string Winner(Move theOne, Move theOther)
        => theOne.Beats(theOther)
            ? theOne.Figure
            : theOther.Figure;
}