namespace Katas.Potter;

public readonly struct Discount {
    readonly int percent;

    public Discount(int percent) {
        this.percent = percent;
    }

    public float AppliedOn(float euro) {
        return euro - euro / (100f / percent);
    }
}