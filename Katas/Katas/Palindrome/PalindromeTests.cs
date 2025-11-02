using FluentAssertions;
using static PalindromeCandidate;

// https://hackmd.io/@evalverde/B1ITM1-GJe
// [x] Return true when an input is a palindrome
// [x] Handle both strings and numbers
// [] Ignore spaces
// [] Ignore punctuation
// [] Ignore differences in letter case

public class PalindromeTests
{
    static readonly PalindromeCandidate[] palindromes = { "aba", "cac", "opopo", 121, 4334 };
    
    [Test]
    public void SingleLetterIsAlwaysPalindrome()
    {
        new PalindromeDetector().IsPalindrome("a").Should().BeTrue();
        new PalindromeDetector().IsPalindrome("b").Should().BeTrue();
        new PalindromeDetector().IsPalindrome("c").Should().BeTrue();
        new PalindromeDetector().IsPalindrome(2).Should().BeTrue();
        new PalindromeDetector().IsPalindrome(8).Should().BeTrue();
    }

    [Test]
    public void ReverseWord()
    {
        FromWord("ac").Reverse().Should().Be(FromWord("ca"));
    }

    [Test]
    public void ReverseNumber()
    {
        FromNumber(12).Reverse().Should().Be(FromNumber(21));
    }

    [Test]
    public void ReturnFalseWhenWordIsNotPalindrome()
    {
        new PalindromeDetector().IsPalindrome("ac").Should().BeFalse();
        new PalindromeDetector().IsPalindrome("be").Should().BeFalse();
    }

    [TestCaseSource(nameof(palindromes))]
    public void ReturnTrueWhenPalindrome(PalindromeCandidate candidate)
    {
        new PalindromeDetector().IsPalindrome(candidate).Should().BeTrue();
    }
}