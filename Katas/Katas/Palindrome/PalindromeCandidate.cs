using System.Text.RegularExpressions;

namespace Katas.Palindrome;

public readonly struct PalindromeCandidate(string word)
{
    public static implicit operator PalindromeCandidate(string word) => new(word);
    public static implicit operator PalindromeCandidate(int number) => new(number.ToString());

    public PalindromeCandidate Reversed() => word.Reverse().Aggregate(string.Empty, (acc, letter) => acc + letter);
    public PalindromeCandidate WithoutSpaces() => word.Replace(" ", "");
    public PalindromeCandidate WithoutPunctuation() => Regex.Replace(word, @"[^\w\d\s]","");

    public bool Equals(PalindromeCandidate other, StringComparison stringComparison)
    {
        return string.Compare(word, other.ToString(), stringComparison) == 0;
    }

    public override string ToString() => word;
    public static PalindromeCandidate FromWord(string word) => word;
    public static PalindromeCandidate FromNumber(int number) => number;
}