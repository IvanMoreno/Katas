namespace Katas.Potter;

public class PotterBookBundle(IEnumerable<PotterBook> books) {
    static readonly Dictionary<int, Discount> bundleSizeToDiscount = new() {
        { 0, new Discount(0) },
        { 1, new Discount(0) },
        { 2, new Discount(5) },
        { 3, new Discount(10) },
        { 4, new Discount(20) },
        { 5, new Discount(25) }
    };

    public Price Price => new Price(Size * 8).Off(DiscountFor(Size));
    public int Size => books.Count();

    static Discount DiscountFor(int bundleSize) {
        return bundleSizeToDiscount[bundleSize];
    }
}