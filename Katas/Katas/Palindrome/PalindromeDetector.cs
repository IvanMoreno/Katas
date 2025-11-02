public class PalindromeDetector
{
    readonly StringComparison stringComparison;
    PalindromeDetector(StringComparison stringComparison) => this.stringComparison = stringComparison;

    public bool IsPalindrome(PalindromeCandidate word)
    {
        return Compare(word, word.Reverse());
    }

    bool Compare(PalindromeCandidate wordA, PalindromeCandidate wordB)
    {
        return string.Compare(wordA.WithoutSpaces(), wordB.WithoutSpaces(), stringComparison) == 0;
    }

    public static PalindromeDetector WithOrdinalComparison() => With(StringComparison.Ordinal);

    public static PalindromeDetector With(StringComparison comparison) => new(comparison);
}