namespace Katas.Potter;

public readonly struct Discount {
    readonly int percent;

    public Discount(int percent) {
        this.percent = percent;
    }

    public float AppliedOn(float euro) {
        if (percent == 10)
            return euro - euro / (100f / percent);
        
        if (percent == 25)
            return euro - euro / (100f / percent);
        
        return euro - euro / (100f / percent);
    }
}