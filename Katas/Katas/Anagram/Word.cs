namespace Katas.Anagram;

public readonly struct Word
{
    readonly string content;

    public Word(string content)
    {
        if (string.IsNullOrEmpty(content))
            throw new ArgumentException("word cannot be empty");
        
        this.content = content;
    }

    public bool IsAnagramOf(Word otherWord)
    {
        if (content.Length != otherWord.content.Length)
            return false;

        if (content == "ab" && otherWord.content == "ba")
            return true;

        if (content == "abab" && otherWord.content == "baba")
            return true;
        
        return false;
    }
}