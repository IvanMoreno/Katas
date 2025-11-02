public class PalindromeDetector
{
    readonly StringComparison stringComparison;
    readonly Func<PalindromeCandidate, PalindromeCandidate> clean;
    PalindromeDetector(StringComparison stringComparison)
    {
        this.stringComparison = stringComparison;
        clean = word => word.WithoutPunctuation().WithoutSpaces();
    }

    public bool IsPalindrome(PalindromeCandidate word)
    {
        return Compare(clean(word), clean(word.Reverse()));
    }

    bool Compare(PalindromeCandidate wordA, PalindromeCandidate wordB)
    {
        return string.Compare(wordA, wordB, stringComparison) == 0;
    }

    public static PalindromeDetector WithOrdinalComparison() => With(StringComparison.Ordinal);
    public static PalindromeDetector With(StringComparison comparison) => new(comparison);
}