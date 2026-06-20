namespace Katas.Potter;

public class Basket {
    readonly List<PotterBook> books;
    readonly BundleSlicer bundleSlicer;

    public Basket(List<PotterBook> books) {
        this.books = books;
        bundleSlicer = new BundleSlicer();
    }

    public Price Price()
        => bundleSlicer.BundleFrom(books)
            .Select(bundle => bundle.Price)
            .Aggregate((zero, price) => zero + price);
}