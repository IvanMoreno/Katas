namespace Katas.RomanNumerals;

public class RomanTranslator
{
    readonly Dictionary<int, string> symbols = new()
    {
        {1, "I"},
        {4, "IV"},
        {5, "V"},
        {9, "IX"},
        {10, "X"},
        {40, "XL"},
        {50, "L"},
    };
    
    public string Translate(int howMuch)
    {
        if (howMuch < 0)
            throw new ArgumentException("The Romans did not use negative numbers");
        if (howMuch == 0)
            throw new ArgumentException("The Romans did not use 0");

        if (symbols.TryGetValue(howMuch, out var translate))
            return translate;

        if (howMuch > 50)
            return "L" + Translate(howMuch - 50);
        if (howMuch < 10)
            return Translate(howMuch - 1) + "I";

        return "X" + Translate(howMuch - 10);
    }
}