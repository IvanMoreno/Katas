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

    public bool IsAnagramOf(Sentence other) => SortedLetters.SequenceEqual(other.SortedLetters);
    IEnumerable<char> SortedLetters => content.Replace(" ", string.Empty).OrderBy(x => x);
}