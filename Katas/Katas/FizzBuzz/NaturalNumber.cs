public readonly struct NaturalNumber
{
    readonly int value;

    public NaturalNumber(int value)
    {
        if (value < 0)
            throw new ArgumentException("Number cannot be negative");
        
        this.value = value;
    }

    public override string ToString() => value.ToString();
}