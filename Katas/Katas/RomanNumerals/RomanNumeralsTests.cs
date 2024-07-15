using FluentAssertions;

namespace Katas.RomanNumerals;

// https://www.codurance.com/katas/roman-numerals
// [x] 1 --> I
// [x] 2 and 3 --> II and III
// [x] 4 --> IV (there cannot exist a sequence of four 'I')
// [x] 5 --> V
// [x] 6, 7 and 8 --> Append 'I' for each unit after five (VI, VII, VIII)
// [x] 9 --> IX an 'I' is also prepended to avoid a sequence of four 'I'
// [x] 10 --> X
// [x] 'X' works as 'I'
// [x] 40 --> 'XL'
// [x] 50 --> 'L'
// [x] 100 --> 'C'
// [x] 90 --> 'XC'
// [x] 500 --> 'D'
// [] 490 --> 'XD' would be incorrect, 'CDXC' is correct

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

    [Test]
    public void Append_NearestSymbol_ToRemainingNumber_AfterSubtraction()
    {
        new RomanTranslator().Translate(22).Should().Be("XXII");
        new RomanTranslator().Translate(13).Should().Be("XIII");
    }

    [TestCase(4, "IV")]
    [TestCase(5, "V")]
    [TestCase(9, "IX")]
    [TestCase(40, "XL")]
    [TestCase(50, "L")]
    [TestCase(90, "XC")]
    [TestCase(100, "C")]
    [TestCase(500, "D")]
    public void TranslateNumber_ToItsRomanEquivalent(int number, string expected)
    {
        new RomanTranslator().Translate(number).Should().Be(expected);
    }

    [Test]
    public void Append_I_ForEveryUnit_After5_Until9()
    {
        new RomanTranslator().Translate(6).Should().Be("VI");
        new RomanTranslator().Translate(7).Should().Be("VII");
        new RomanTranslator().Translate(8).Should().Be("VIII");
    }

    [Test]
    public void Subtract_L_ThenAppend_X()
    {
        new RomanTranslator().Translate(60).Should().Be("LX");
        new RomanTranslator().Translate(70).Should().Be("LXX");
        new RomanTranslator().Translate(78).Should().Be("LXXVIII");
    }

    [Test]
    [Ignore("The 400 case is necessary to be implemented before this")]
    public void ASymbol_CannotBePrepended_ToANextDecimalOrder_Symbol()
    {
        new RomanTranslator().Translate(490).Should().Be("CDXC");
    }
}