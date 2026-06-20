namespace Katas.Potter;

public class PotterBookBundle {
    const int BaseBookPrice = 8;

    static readonly Dictionary<int, Discount> BundleSizeToDiscount = new() {
        { 1, new Discount(0) },
        { 2, new Discount(5) },
        { 3, new Discount(10) },
        { 4, new Discount(20) },
        { 5, new Discount(25) }
    };

    readonly IEnumerable<PotterBook> books;

    public Price Price => new Price(Size * BaseBookPrice).Off(BundleSizeToDiscount[Size]);
    public int Size => books.Count();

    public PotterBookBundle(IEnumerable<PotterBook> books) {
        if (!books.Any())
            throw new ArgumentException("Bundle cannot contain zero books");
            
        if (books.Distinct().Count() != books.Count())
            throw new ArgumentException("Bundle cannot contain identical books");
        
        this.books = books;
    }
}