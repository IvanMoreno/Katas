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
    [Test]
    public void IsAnagram()
    {
        new Word("ab").IsAnagramOf(new Word("ba")).Should().BeTrue();
        new Word("aba").IsAnagramOf(new Word("ba")).Should().BeFalse();
        new Word("aba").IsAnagramOf(new Word("bab")).Should().BeFalse();
        new Word("abab").IsAnagramOf(new Word("baba")).Should().BeTrue();
    }
}