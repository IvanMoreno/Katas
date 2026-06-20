namespace Katas.Potter;

public class BundleSlicer {
    public List<PotterBookBundle> BundleFrom(List<PotterBook> books) {
        if (books.Count == 1)
            return [new PotterBookBundle(books)];
        
        var bundle = books.Distinct();
        var result = new List<PotterBookBundle> {
            new PotterBookBundle(bundle),
        };
        
        var remainingBooks = new List<PotterBook>(books);
        foreach (var book in bundle) {
            remainingBooks.Remove(book);
        }
        
        if (remainingBooks.Count > 0)
            result.AddRange(BundleFrom(remainingBooks));
        
        return result;
    }
}