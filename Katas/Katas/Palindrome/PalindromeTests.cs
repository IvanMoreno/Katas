using FluentAssertions;

// https://hackmd.io/@evalverde/B1ITM1-GJe
// [] Return true when an input is a palindrome
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
}

public class PalindromeDetector
{
    public bool IsPalindrome(string word)
    {
        return true;
    }
}