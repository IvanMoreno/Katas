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

    public bool IsAnagramOf(Sentence other) => IsAnagramOfTemp(other);
    public bool IsAnagramOfTemp(Sentence other) => HasSameLettersThan(other);

    bool HasSameLettersThan(Sentence other) => SortedLetters.SequenceEqual(other.SortedLetters);
    IEnumerable<char> SortedLetters => content.Replace(" ", string.Empty).OrderBy(x => x);

    IEnumerable<int> CountLetters(Sentence of) => of.content.Select(AmountOf);
    int AmountOf(char letter) => content.Trim().Count(x => x == letter);
}