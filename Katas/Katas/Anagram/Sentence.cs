namespace Katas.Anagram;

public readonly struct Sentence
{
    readonly string content;
    IEnumerable<char> SortedLetters => ContentWithoutWhitespaces.OrderBy(x => x);
    string ContentWithoutWhitespaces => content.Replace(" ", string.Empty);

    public Sentence(string content)
    {
        if (string.IsNullOrEmpty(content))
            throw new ArgumentException("word cannot be empty");
        
        this.content = content;
    }

    public bool IsAnagramOf(Sentence other) => SortedLetters.SequenceEqual(other.SortedLetters);
}