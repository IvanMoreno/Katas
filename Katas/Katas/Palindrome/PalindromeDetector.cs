public class PalindromeDetector
{
    readonly StringComparison stringComparison;
    readonly Func<PalindromeCandidate, PalindromeCandidate> clean;
    
    PalindromeDetector(StringComparison stringComparison)
    {
        this.stringComparison = stringComparison;
        clean = word => word.WithoutPunctuation().WithoutSpaces();
    }

    public bool IsPalindrome(PalindromeCandidate word) => Compare(clean(word), clean(word.Reversed()));
    bool Compare(PalindromeCandidate wordA, PalindromeCandidate wordB) => wordA.Compare(wordB, stringComparison);

    public static PalindromeDetector WithOrdinalComparison() => With(StringComparison.Ordinal);
    public static PalindromeDetector With(StringComparison comparison) => new(comparison);
}