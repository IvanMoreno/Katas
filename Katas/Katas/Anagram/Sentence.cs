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

    public bool IsAnagramOf(Sentence other) 
        => CountLetters(this).SequenceEqual(other.CountLetters(this));

    IEnumerable<int> CountLetters(Sentence of) {
        return of.content.Select(AmountOf);
    }

    int AmountOf(char letter) => content.Count(x => x == letter);
}