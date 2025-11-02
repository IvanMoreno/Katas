public class PalindromeDetector
{
    readonly StringComparison stringComparison;
    PalindromeDetector(StringComparison stringComparison) => this.stringComparison = stringComparison;

    public bool IsPalindrome(PalindromeCandidate word)
    {
        return Compare(word.WithoutSpaces().WithoutPunctuation(), word.Reverse().WithoutSpaces().WithoutPunctuation());
    }

    bool Compare(PalindromeCandidate wordA, PalindromeCandidate wordB)
    {
        return string.Compare(wordA, wordB, stringComparison) == 0;
    }

    public static PalindromeDetector WithOrdinalComparison() => With(StringComparison.Ordinal);
    public static PalindromeDetector With(StringComparison comparison) => new(comparison);
}