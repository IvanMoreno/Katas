namespace Katas.Potter;

public class BundleSlicer {
    public List<PotterBookBundle> BundleFrom(List<PotterBook> books) {
        var result = new List<PotterBookBundle>();

        var remainingBooks = new List<PotterBook>(books);
        var bundledBooks = books.Distinct();
        foreach (var book in bundledBooks) {
            remainingBooks.Remove(book);
        }

        result.Add(new PotterBookBundle(bundledBooks));
        result.Add(new PotterBookBundle(remainingBooks));
        return result;
    }
}