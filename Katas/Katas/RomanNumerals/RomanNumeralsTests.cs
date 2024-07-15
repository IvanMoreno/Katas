using FluentAssertions;

namespace Katas.RomanNumerals;

// https://www.codurance.com/katas/roman-numerals
// [x] 1 --> I
// [x] 2 and 3 --> II and III
// [] 4 --> IV (there cannot exist a sequence of four 'I')
// [] 5 --> V
// [] 6, 7 and 8 --> Append 'I' for each unit after five (VI, VII, VIII)
// [] 9 --> IX an 'I' is also prepended to avoid a sequence of four 'I'
// [] 10 --> X

public class RomanNumeralsTests
{
    [Test]
    public void Translate_1()
    {
        new RomanTranslator().Translate(1).Should().Be("I");
    }

    [Test]
    public void Translate_2()
    {
        new RomanTranslator().Translate(2).Should().Be("II");
    }

    [Test]
    public void Translate_3()
    {
        new RomanTranslator().Translate(3).Should().Be("III");
    }

    [Test]
    public void Translate_10()
    {
        new RomanTranslator().Translate(10).Should().Be("X");
    }

    [Test]
    public void Append_X_ForEvery_10()
    {
        new RomanTranslator().Translate(20).Should().Be("XX");
        new RomanTranslator().Translate(30).Should().Be("XXX");
    }
}