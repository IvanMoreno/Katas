namespace Katas.Anagram;

public readonly struct Sentence
{
    readonly string content;
    string TrimmedContent => content.Trim();

    public Sentence(string content)
    {
        if (string.IsNullOrEmpty(content))
            throw new ArgumentException("word cannot be empty");
        
        this.content = content;
    }

    public bool IsAnagramOf(Sentence otherSentence) 
        => TrimmedContent
            .Select(AmountOf)
            .SequenceEqual(TrimmedContent.Select(otherSentence.AmountOf));

    int AmountOf(char letter) => content.Count(x => x == letter);
}