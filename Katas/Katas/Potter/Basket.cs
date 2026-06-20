namespace Katas.Potter;

public class Basket {
    readonly List<PotterBook> books;

    public Basket(List<PotterBook> books) {
        this.books = books;
    }

    public Price Price() {
        if (books.Count > 1) {
            var bundlePrice = new Price(books.Count * 8);
            
            return books[0].Equals(books[1]) 
                ? bundlePrice 
                : bundlePrice.Off(new Discount(5));
        }

        return new Price(books.Count * 8);
    }
}