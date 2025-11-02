namespace Katas.Palindrome;

public class PalindromeDetector
{
    readonly StringComparison comparison;
    readonly Func<PalindromeCandidate, PalindromeCandidate> cleaned;
    
    PalindromeDetector(StringComparison comparison)
    {
        this.comparison = comparison;
        cleaned = word => word.WithoutPunctuation().WithoutSpaces();
    }

    public bool IsPalindrome(PalindromeCandidate word) => cleaned(word).Equals(cleaned(word.Reversed()), comparison);

    public static PalindromeDetector WithOrdinalComparison() => With(StringComparison.Ordinal);
    public static PalindromeDetector With(StringComparison comparison) => new(comparison);
}