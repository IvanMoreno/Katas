using FluentAssertions;
using static Katas.EmployeeReport.Employee;
using static Katas.EmployeeReport.Filter;

namespace Katas.Anagram;

// https://codingdojo.org/kata/Anagram/
// [] Detect whether a word is an anagram of another word
// [] Get all words from a document
// [] Get all two-word combinations given a set of words
// [] Generate all two-word anagrams of a word

public class AnagramTests
{
    [TestCase("ab", "ba", true)]
    [TestCase("aba", "ba", false)]
    [TestCase("aba", "bab", false)]
    [TestCase("abab", "baba", true)]
    [TestCase("listen", "silent", true)]
    [TestCase("listen", "silent", true)]
    public void IsAnagram(string wordA, string wordB, bool shouldBeAnagram)
    {
        new Word(wordA).IsAnagramOf(new Word(wordB)).Should().Be(shouldBeAnagram);
    }
}