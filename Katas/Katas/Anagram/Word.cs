namespace Katas.Anagram;

public struct Word
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

        foreach (var letter in content)
        {
            if (!AmountOf(letter).Equals(otherWord.AmountOf(letter)))
                return false;
        }
        
        return true;
    }

    int AmountOf(char letter) => content.Count(x => x == letter);
}