public readonly struct Word
{
    readonly string content;

    Word(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Cannot be empty");
        
        this.content = content;
    }

    public override string ToString() => content;

    public static implicit operator string(Word word) => word.content;
    public static implicit operator Word(string word) => new(word);
    public static Word operator+(Word left, Word right) => left.content + right.content;
    public static Word operator+(string left, Word right) => left + right.content;

    public static Word Fizz => "Fizz";
    public static Word Buzz => "Buzz";
}