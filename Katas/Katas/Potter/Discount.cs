namespace Katas.Potter;

public readonly struct Discount {
    public Discount(int percent) {
        
    }

    public float AppliedOn(float euro) {
        return euro / 2;
    }
}