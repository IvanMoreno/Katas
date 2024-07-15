namespace Katas.RomanNumerals;

public class RomanTranslator
{
    public string Translate(int howMuch)
    {
        if (howMuch < 0)
            throw new ArgumentException("The Romans did not use negative numbers");
        if (howMuch == 0)
            throw new ArgumentException("The Romans did not use 0");

        if (howMuch == 1)
            return "I";
        if (howMuch == 4)
            return "IV";
        if (howMuch == 5)
            return "V";
        if (howMuch == 9)
            return "IX";
        if (howMuch < 10)
            return "I" + Translate(howMuch - 1);
        if (howMuch == 10)
            return "X";

        return "X" + Translate(howMuch - 10);
    }
}