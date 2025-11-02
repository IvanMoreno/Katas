using FluentAssertions;
using static System.StringComparison;
using static PalindromeCandidate;

// https://hackmd.io/@evalverde/B1ITM1-GJe
// [x] Return true when an input is a palindrome
// [x] Handle both strings and numbers
// [x] Ignore spaces
// [x] Ignore punctuation
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
        FromWord("ac").Reversed().Should().Be(FromWord("ca"));
    }

    [Test]
    public void ReverseNumber()
    {
        FromNumber(12).Reversed().Should().Be(FromNumber(21));
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
        PalindromeDetector.With(OrdinalIgnoreCase).IsPalindrome("A man a plan a canal Panama").Should().BeTrue();
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

    [Test]
    public void IgnorePunctuationWhenComparingPalindromes()
    {
        PalindromeDetector.WithOrdinalComparison().IsPalindrome("a ,ca").Should().BeTrue();
    }

    [Test]
    public void AcceptanceTest()
    {
        PalindromeDetector.With(InvariantCultureIgnoreCase).IsPalindrome("abc123321cba").Should().BeTrue();
        PalindromeDetector.With(InvariantCultureIgnoreCase).IsPalindrome("Madam, in Eden, I'm Adam").Should().BeTrue();
        PalindromeDetector.With(InvariantCultureIgnoreCase).IsPalindrome("Eva, can I see bees in a cave?").Should().BeTrue();
        PalindromeDetector.With(InvariantCultureIgnoreCase).IsPalindrome("Palindrome? Not really!").Should().BeFalse();
    }
}