namespace Katas.Potter;

public class Basket {
    static readonly Dictionary<int, Discount> bundleSizeToDiscount = new() {
        { 0, new Discount(0) },
        { 1, new Discount(0) },
        { 2, new Discount(5) },
        { 3, new Discount(10) },
        { 4, new Discount(20) },
        { 5, new Discount(25) }
    };
    
    readonly List<PotterBook> books;

    public Basket(List<PotterBook> books) {
        this.books = books;
    }

    public Price Price() {
        var bundleSize = books.Distinct().Count();

        var bundlePrice = new Price(bundleSize * 8).Off(DiscountFor(bundleSize));
        
        var nonBundledBooksPrice = new Price((books.Count - bundleSize) * 8);
        
        return bundlePrice + nonBundledBooksPrice;
    }

    static Discount DiscountFor(int bundleSize) {
        return bundleSizeToDiscount[bundleSize];
    }
}