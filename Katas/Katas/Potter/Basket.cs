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
            var differentBooks = books.Distinct().Count();
            var have10Discount = differentBooks == 3;
            if (have10Discount) {
                var bundlePrice = new Price(3 * 8);
                return bundlePrice.Off(new Discount(10));
            }
            
            var have5Discount = differentBooks == 2;
            if (have5Discount) {
                var bundlePrice = new Price(2 * 8);
                var nonBundledBooksPrice = new Price((books.Count - differentBooks) * 8);
                return bundlePrice.Off(new Discount(5)) + nonBundledBooksPrice;
            }
        }

        return new Price(books.Count * 8);
    }
}