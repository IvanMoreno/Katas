namespace Katas.Anagram;

public readonly struct Sentence
{
    readonly string content;
    string ContentWithoutWhitespaces => content.Replace(" ", string.Empty);

    public Sentence(string content)
    {
        if (string.IsNullOrEmpty(content))
            throw new ArgumentException("sentence cannot be empty");
        
        this.content = content;
    }

    public bool IsAnagramOf(Sentence other) => SortedLetters().SequenceEqual(other.SortedLetters());
    IEnumerable<char> SortedLetters() => ContentWithoutWhitespaces.OrderBy(x => x);
}