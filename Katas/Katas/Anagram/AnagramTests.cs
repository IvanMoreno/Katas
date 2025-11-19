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
    }
}

public readonly struct Word
{
    readonly string content;

    public Word(string content)
    {
        if (string.IsNullOrEmpty(content))
            throw new ArgumentException("word cannot be empty");
        
        this.content = content;
    }

    public bool IsAnagramOf(Word otherWord)
    {
        if (content.Length != otherWord.content.Length)
            return false;
        
        return true;
    }
}