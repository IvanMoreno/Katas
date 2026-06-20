namespace Katas.Potter;

public class Basket {
    readonly List<PotterBook> books;

    public Basket(List<PotterBook> books) {
        this.books = books;
    }

    public Price Price() {
        if (books.Count == 2) {
            var bundlePrice = new Price(books.Count * 8);
            var haveDiscount = !books[0].Equals(books[1]);
            var discount = new Discount(5);

            return haveDiscount 
                ? bundlePrice.Off(discount) 
                : bundlePrice;
        }
        
        if (books.Count == 3) {
            var bundlePrice = new Price(books.Count * 8);
            var haveDiscount = !books[0].Equals(books[1]);
            var discount = new Discount(10);

            return haveDiscount 
                ? bundlePrice.Off(discount) 
                : bundlePrice;
        }

        return new Price(books.Count * 8);
    }
}