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
        var trimmedContent = content.Trim();
        return trimmedContent
            .Select(AmountOf)
            .SequenceEqual(trimmedContent.Select(otherSentence.AmountOf));
    }

    int AmountOf(char letter) => content.Count(x => x == letter);
}