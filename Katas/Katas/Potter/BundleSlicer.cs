namespace Katas.Potter;

public class BundleSlicer {
    public List<PotterBookBundle> BundleFrom(List<PotterBook> books) {
        var remainingBooks = new List<PotterBook>(books);
        var bundledBooks = books.Distinct();
        foreach (var book in bundledBooks) {
            remainingBooks.Remove(book);
        }

        return [
            new PotterBookBundle(bundledBooks),
            new PotterBookBundle(remainingBooks)
        ];
    }
}