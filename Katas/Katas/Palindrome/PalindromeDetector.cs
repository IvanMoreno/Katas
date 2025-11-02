public class PalindromeDetector
{
    public bool IsPalindrome(PalindromeCandidate word)
    {
        return Compare(word, word.Reverse());
    }

    static bool Compare(string wordA, string wordB)
    {
        return wordA.Replace(" ", "").Equals(wordB.Replace(" ", ""));
    }
}