namespace Katas.Potter;

public class BundleSlicer {
    public List<PotterBookBundle> BundleFrom(List<PotterBook> books) {
        if (books.Count <= 1)
            return [new PotterBookBundle(books)];
        
        var bundle = BestDeals(books);
        var remaining = Remaining(books, bundle);
        return bundle.Concat(BundleFrom(remaining)).ToList();
    }

    static List<PotterBook> Remaining(List<PotterBook> books, List<PotterBookBundle> bundle) {
        var result = new List<PotterBook>(books);
        foreach (var book in bundle.SelectMany(book => book)) {
            result.Remove(book);
        }

        return result;
    }

    static List<PotterBookBundle> BestDeals(List<PotterBook> books) {
        var bundle = books.Distinct();
        var result = new List<PotterBookBundle> {
            new PotterBookBundle(bundle),
        };
        return result;
    }
}