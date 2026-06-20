namespace Katas.Potter;

public readonly struct Discount {
    readonly float percent;

    public Discount(int percent) {
        this.percent = percent * 0.01f;
    }

    public float AppliedOn(float euro) => euro - euro * percent;
}