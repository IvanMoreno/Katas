using FluentAssertions;
using static PalindromeCandidate;

// https://hackmd.io/@evalverde/B1ITM1-GJe
// [x] Return true when an input is a palindrome
// [] Handle both strings and numbers
// [] Ignore spaces
// [] Ignore punctuation
// [] Ignore differences in letter case

public class PalindromeTests
{
    [Test]
    public void SingleLetterIsAlwaysPalindrome()
    {
        new PalindromeDetector().IsPalindrome("a").Should().BeTrue();
        new PalindromeDetector().IsPalindrome("b").Should().BeTrue();
        new PalindromeDetector().IsPalindrome("c").Should().BeTrue();
    }

    [Test]
    public void ReverseWord()
    {
        FromWord("ac").Reverse().Should().Be(FromWord("ca"));
    }

    [Test]
    public void ReturnFalseWhenWordIsNotPalindrome()
    {
        new PalindromeDetector().IsPalindrome("ac").Should().BeFalse();
        new PalindromeDetector().IsPalindrome("be").Should().BeFalse();
    }
}