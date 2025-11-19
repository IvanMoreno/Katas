namespace Katas.Anagram;

public readonly struct Sentence
{
    readonly string content;

    public Sentence(string content)
    {
        if (string.IsNullOrEmpty(content))
            throw new ArgumentException("word cannot be empty");
        
        this.content = content;
    }

    public bool IsAnagramOf(Sentence otherSentence)
    {
        var trimmedContent = content.Replace(" ", string.Empty);
        var otherTrimmedContent = otherSentence.content.Replace(" ", string.Empty);
        if (trimmedContent.Length != otherTrimmedContent.Length)
            return false;

        foreach (var letter in trimmedContent)
        {
            if (!AmountOf(letter).Equals(otherSentence.AmountOf(letter)))
                return false;
        }
        
        return true;
    }

    int AmountOf(char letter) => content.Count(x => x == letter);
}