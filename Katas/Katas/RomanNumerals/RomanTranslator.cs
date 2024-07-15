namespace Katas.RomanNumerals;

public class RomanTranslator
{
    readonly Dictionary<int, string> symbols = new()
    {
        { 1, "I" },
        { 4, "IV" },
        { 5, "V" },
        { 9, "IX" },
        { 10, "X" },
        { 40, "XL" },
        { 50, "L" },
    };

    public string Translate(int howMuch)
    {
        if (howMuch < 0)
            throw new ArgumentException("The Romans did not use negative numbers");
        if (howMuch == 0)
            throw new ArgumentException("The Romans did not use 0");

        if (symbols.TryGetValue(howMuch, out var translate))
            return translate;

        var firstSmaller = symbols.Keys.OrderDescending().First(symbol => howMuch > symbol);
        return Translate(firstSmaller) + Translate(howMuch - firstSmaller);
    }
}