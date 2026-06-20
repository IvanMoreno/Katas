namespace Katas.Potter;

public struct Price {
    readonly float euro;

    public Price(float euro) {
        if (euro < 0)
            throw new ArgumentException("Price cannot be negative");
        
        this.euro = euro;
    }

    public Price Off(Discount discount) {
        return new Price(discount.AppliedOn(euro));
    }

    public static Price operator +(Price source, Price addend) => new(source.euro + addend.euro);

    public override string ToString() {
        return $"{nameof(euro)}: {euro}";
    }
}