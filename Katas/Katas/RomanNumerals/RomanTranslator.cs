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
        { 90, "XC" },
        { 100, "C" },
        { 400, "CD" },
        { 500, "D" },
    };

    public string Translate(int howMuch)
    {
        if (howMuch < 0)
            throw new ArgumentException("The Romans did not use negative numbers");
        if (howMuch == 0)
            throw new ArgumentException("The Romans did not use 0");

        if (symbols.TryGetValue(howMuch, out var translate))
            return translate;

        return Translate(FirstSmaller(howMuch)) + Translate(howMuch - FirstSmaller(howMuch));
    }

    int FirstSmaller(int than) => symbols.Keys.OrderDescending().First(symbol => than > symbol);
}