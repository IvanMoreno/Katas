using FluentAssertions;
using static PalindromeCandidate;

// https://hackmd.io/@evalverde/B1ITM1-GJe
// [x] Return true when an input is a palindrome
// [x] Handle both strings and numbers
// [x] Ignore spaces
// [] Ignore punctuation
// [x] Ignore differences in letter case

public class PalindromeTests
{
    static readonly PalindromeCandidate[] palindromes = { "aba", "cac", "opopo", 121, 4334 };
    
    [Test]
    public void SingleLetterIsAlwaysPalindrome()
    {
        PalindromeDetector.WithOrdinalComparison().IsPalindrome("a").Should().BeTrue();
        PalindromeDetector.WithOrdinalComparison().IsPalindrome("b").Should().BeTrue();
        PalindromeDetector.WithOrdinalComparison().IsPalindrome("c").Should().BeTrue();
        PalindromeDetector.WithOrdinalComparison().IsPalindrome(2).Should().BeTrue();
        PalindromeDetector.WithOrdinalComparison().IsPalindrome(8).Should().BeTrue();
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
        PalindromeDetector.WithOrdinalComparison().IsPalindrome("ac").Should().BeFalse();
        PalindromeDetector.WithOrdinalComparison().IsPalindrome("be").Should().BeFalse();
    }

    [TestCaseSource(nameof(palindromes))]
    public void ReturnTrueWhenPalindrome(PalindromeCandidate candidate)
    {
        PalindromeDetector.WithOrdinalComparison().IsPalindrome(candidate).Should().BeTrue();
    }

    [Test]
    public void IgnoreSpacesWhenComparingPalindromes()
    {
        PalindromeDetector.WithOrdinalComparison().IsPalindrome("a ca").Should().BeTrue();
    }

    [Test]
    public void IgnoreCaseWhenComparingPalindromes()
    {
        PalindromeDetector.With(StringComparison.OrdinalIgnoreCase).IsPalindrome("A man a plan a canal Panama").Should().BeTrue();
    }

    [Test]
    public void RemovePunctuationFromWord()
    {
        FromWord(",").WithoutPunctuation().Should().Be(FromWord(string.Empty));
        FromWord(",a").WithoutPunctuation().Should().Be(FromWord("a"));
        FromWord(",a.").WithoutPunctuation().Should().Be(FromWord("a"));
        FromWord(",a?.").WithoutPunctuation().Should().Be(FromWord("a"));
        FromWord(",!a?.").WithoutPunctuation().Should().Be(FromWord("a"));
    }

    [Test, Ignore("Unimplemented")]
    public void IgnorePunctuationWhenComparingPalindromes()
    {
        PalindromeDetector.WithOrdinalComparison().IsPalindrome("a ,ca").Should().BeTrue();
    }
}