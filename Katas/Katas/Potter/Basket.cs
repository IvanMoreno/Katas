namespace Katas.Potter;

public class Basket {
    readonly List<PotterBook> books;

    public Basket(List<PotterBook> books) {
        this.books = books;
    }

    public Price Price() {
        var bundle = new PotterBookBundle(books.Distinct());

        var nonBundledBooksPrice = new Price((books.Count - bundle.Size) * 8);
        
        return bundle.Price + nonBundledBooksPrice;
    }
}

public class PotterBookBundle {
    static readonly Dictionary<int, Discount> bundleSizeToDiscount = new() {
        { 0, new Discount(0) },
        { 1, new Discount(0) },
        { 2, new Discount(5) },
        { 3, new Discount(10) },
        { 4, new Discount(20) },
        { 5, new Discount(25) }
    };
    
    readonly IEnumerable<PotterBook> books;

    public Price Price => new Price(Size * 8).Off(DiscountFor(Size));
    public int Size => books.Count();

    public PotterBookBundle(IEnumerable<PotterBook> books) {
        this.books = books;
    }
    
    static Discount DiscountFor(int bundleSize) {
        return bundleSizeToDiscount[bundleSize];
    }
}