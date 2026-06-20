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