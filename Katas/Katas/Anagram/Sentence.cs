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

    public bool IsAnagramOf(Sentence other) => CountLetters(this).SequenceEqual(other.CountLetters(this));
    IEnumerable<int> CountLetters(Sentence of) => of.content.Select(AmountOf);
    int AmountOf(char letter) => content.Trim().Count(x => x == letter);
}