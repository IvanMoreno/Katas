public readonly struct Word
{
    readonly string content;

    Word(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Cannot be empty");
        
        this.content = content;
    }

    public static implicit operator string(Word word) => word.content;
    public static implicit operator Word(string word) => new(word);

    public static Word Fizz => "Fizz";
    public static Word Buzz => "Buzz";
}