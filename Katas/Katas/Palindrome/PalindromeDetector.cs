public class PalindromeDetector
{
    readonly StringComparison stringComparison;
    readonly Func<PalindromeCandidate, PalindromeCandidate> cleaned;
    
    PalindromeDetector(StringComparison stringComparison)
    {
        this.stringComparison = stringComparison;
        cleaned = word => word.WithoutPunctuation().WithoutSpaces();
    }

    public bool IsPalindrome(PalindromeCandidate word) => cleaned(word).Equals(cleaned(word.Reversed()), stringComparison);

    public static PalindromeDetector WithOrdinalComparison() => With(StringComparison.Ordinal);
    public static PalindromeDetector With(StringComparison comparison) => new(comparison);
}