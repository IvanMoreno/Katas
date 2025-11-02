public class PalindromeDetector
{
    readonly StringComparison stringComparison;
    PalindromeDetector(StringComparison stringComparison) => this.stringComparison = stringComparison;

    public bool IsPalindrome(PalindromeCandidate word)
    {
        return Compare(word, word.Reverse());
    }

    static bool Compare(string wordA, string wordB)
    {
        return wordA.Replace(" ", "").Equals(wordB.Replace(" ", ""));
    }

    public static PalindromeDetector WithOrdinalComparison() => new(StringComparison.Ordinal);
}