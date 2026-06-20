namespace Katas.Potter;

public readonly struct Discount {
    readonly float percent;

    public Discount(int percent) {
        if (percent < 1 || percent > 100)
            throw new ArgumentException("Discount must be between 1 and 100");
        
        this.percent = percent * 0.01f;
    }

    public float AppliedOn(float euro) => euro - euro * percent;
}