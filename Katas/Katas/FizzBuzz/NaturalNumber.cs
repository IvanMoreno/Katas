public readonly struct NaturalNumber
{
    readonly int value;

    public NaturalNumber(int value)
    {
        if (value < 0)
            throw new ArgumentException("Number cannot be negative");
        
        this.value = value;
    }

    public bool IsDivisibleBy(int divisor) => value % divisor == 0;

    public override string ToString() => value.ToString();
    public static implicit operator int(NaturalNumber number) => number.value;
}