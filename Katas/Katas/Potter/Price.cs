namespace Katas.Potter;

public struct Price {
    readonly float euro;

    public Price(float euro) {
        this.euro = euro;
    }

    public Price Off(Discount discount) {
        return new Price(discount.AppliedOn(euro));
    }

    public override string ToString() {
        return $"{nameof(euro)}: {euro}";
    }
}