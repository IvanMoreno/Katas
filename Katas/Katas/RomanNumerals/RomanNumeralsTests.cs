using FluentAssertions;

namespace Katas.RomanNumerals;

// https://www.codurance.com/katas/roman-numerals
// [x] 1 --> I
// [] 2 and 3 --> II and III
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
}

public class RomanTranslator
{
    public string Translate(int howMuch)
    {
        if (howMuch < 0)
            throw new ArgumentException("The Romans did not use negative numbers");
        if (howMuch == 0)
            throw new ArgumentException("The Romans did not use 0");
        
        return "I";
    }
}