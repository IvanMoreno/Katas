public readonly struct PalindromeCandidate(string word)
{
    public static implicit operator PalindromeCandidate(string word) => new(word);

    public PalindromeCandidate Reverse() => word.Reverse().Aggregate(string.Empty, (acc, letter) => acc + letter);

    public override string ToString() => word;

    public static PalindromeCandidate FromWord(string word) => word;
    public static PalindromeCandidate FromNumber(int number) => number.ToString();
}