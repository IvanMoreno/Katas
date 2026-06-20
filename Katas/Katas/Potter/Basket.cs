namespace Katas.Potter;

public class Basket {
    readonly List<PotterBook> books;

    public Basket(List<PotterBook> books) {
        this.books = books;
    }

    public Price Price() {
        if (books.Count == 0)
            return new Price(0);

        var remainingBooks = new List<PotterBook>(books);
        var bundledBooks = books.Distinct();
        foreach (var book in bundledBooks) {
            remainingBooks.Remove(book);
        }
        
        var bundle = new PotterBookBundle(bundledBooks);
        var remaining = new PotterBookBundle(remainingBooks);
        return bundle.Price + remaining.Price;
    }
}