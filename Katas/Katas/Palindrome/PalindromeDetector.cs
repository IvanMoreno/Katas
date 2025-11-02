public class PalindromeDetector
{
    readonly StringComparison stringComparison;
    PalindromeDetector(StringComparison stringComparison) => this.stringComparison = stringComparison;

    public bool IsPalindrome(PalindromeCandidate word)
    {
        return Compare(word, word.Reverse());
    }

    static bool Compare(PalindromeCandidate wordA, PalindromeCandidate wordB)
    {
        return wordA.WithoutSpaces().Equals(wordB.WithoutSpaces());
    }

    public static PalindromeDetector WithOrdinalComparison() => new(StringComparison.Ordinal);
}