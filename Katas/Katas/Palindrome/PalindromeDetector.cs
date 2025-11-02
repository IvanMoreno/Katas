public class PalindromeDetector
{
    public bool IsPalindrome(PalindromeCandidate word)
    {
        return word.Reverse().Equals(word);
    }
}