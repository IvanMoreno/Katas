namespace Katas.Potter;

public class Basket {
    readonly List<PotterBook> books;

    public Basket(List<PotterBook> books) {
        this.books = books;
    }

    public Price Price() 
        => PotterBookBundles()
            .Select(bundle => bundle.Price)
            .Aggregate((zero, price) => zero + price);

    List<PotterBookBundle> PotterBookBundles() {
        var bundles = new List<PotterBookBundle>();

        var remainingBooks = new List<PotterBook>(books);
        var bundledBooks = books.Distinct();
        foreach (var book in bundledBooks) {
            remainingBooks.Remove(book);
        }
        
        bundles.Add(new PotterBookBundle(bundledBooks));
        bundles.Add(new PotterBookBundle(remainingBooks));
        return bundles;
    }
}