namespace Katas.ShoppingCartasdfasdf;

public readonly struct Percentage
{
    readonly int part;
    Percentage(int part) => this.part = part;

    public float Of(float whole) => whole * (part / 100f);

    public static implicit operator Percentage(int part) => new(part);
}