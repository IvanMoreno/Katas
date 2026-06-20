namespace Katas.Potter;

public class Basket {
    static readonly Dictionary<int, Discount> differentBooksToDiscounts = new() {
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
        var booksInBundle = books.Distinct().Count();

        var bundlePrice = new Price(booksInBundle * 8).Off(DiscountFor(booksInBundle));
        
        var nonBundledBooksPrice = new Price((books.Count - booksInBundle) * 8);
        
        return bundlePrice + nonBundledBooksPrice;
    }

    static Discount DiscountFor(int differentBooks) {
        return differentBooksToDiscounts[differentBooks];
    }
}