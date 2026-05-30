using FluentAssertions;

namespace Katas.Anagram;

// https://codingdojo.org/kata/Anagram/
// [x] Detect whether a word is an anagram of another word

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
        new Sentence(wordA).IsAnagramOf(new Sentence(wordB)).Should().Be(shouldBeAnagram);
    }

    [TestCase("astronomer", "moon starer", true)]
    [TestCase("astron omer", "moon starer ", true)]
    public void IsAnagramIgnoresSpaces(string wordA, string wordB, bool shouldBeAnagram)
    {
        new Sentence(wordA).IsAnagramOf(new Sentence(wordB)).Should().Be(shouldBeAnagram);
    }
}

public class RockPaperScissorsTests {
    [Test]
    public void RockBeatsScissors() {
        new Rock().Beats(new Scissors()).Should().BeTrue();
    }
}

public class Scissors { }

public class Rock {
    public bool Beats(Scissors other) {
        return true;
    }
}