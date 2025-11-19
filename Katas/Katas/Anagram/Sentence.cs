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
        if (content.Length != otherSentence.content.Length)
            return false;

        foreach (var letter in content)
        {
            if (!AmountOf(letter).Equals(otherSentence.AmountOf(letter)))
                return false;
        }
        
        return true;
    }

    int AmountOf(char letter) => content.Count(x => x == letter);
}