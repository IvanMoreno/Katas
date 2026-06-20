namespace Katas.Potter;

public struct Price {
    readonly float euro;

    public Price(float euro) {
        this.euro = euro;
    }

    public Price Off(Discount howMuch) {
        return new Price(10);
    }

    public override string ToString() {
        return $"{nameof(euro)}: {euro}";
    }
}