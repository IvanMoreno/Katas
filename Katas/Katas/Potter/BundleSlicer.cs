namespace Katas.Potter;

public class BundleSlicer {
    public List<PotterBookBundle> BundleFrom(List<PotterBook> books) {
        if (books.Count <= 1)
            return [new PotterBookBundle(books)];
        
        var bundle = BundleBestDeals(books);
        var remainingBooks = RemainingBooks(books, bundle);
        return bundle.Concat(BundleFrom(remainingBooks)).ToList();
    }

    static List<PotterBook> RemainingBooks(List<PotterBook> books, List<PotterBookBundle> bundle) {
        var remainingBooks = new List<PotterBook>(books);
        foreach (var book in bundle.SelectMany(book => book)) {
            remainingBooks.Remove(book);
        }

        return remainingBooks;
    }

    static List<PotterBookBundle> BundleBestDeals(List<PotterBook> books) {
        var bundle = books.Distinct();
        var result = new List<PotterBookBundle> {
            new PotterBookBundle(bundle),
        };
        return result;
    }
}