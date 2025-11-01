public readonly struct FizzBuzzWord
{
    readonly string content;

    FizzBuzzWord(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Cannot be empty");
        
        this.content = content;
    }

    public static implicit operator string(FizzBuzzWord word) => word.content;
    public static implicit operator FizzBuzzWord(string word) => new(word);

    public static FizzBuzzWord Fizz => "Fizz";
    public static FizzBuzzWord Buzz => "Buzz";
}