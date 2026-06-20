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
            var have10Discount = books.Distinct().Count() == 3;
            if (have10Discount) {
                var bundlePrice = new Price(books.Count * 8);
                return bundlePrice.Off(new Discount(10));
            }
            
            var have5Discount = books.Distinct().Count() == 2;
            if (have5Discount) {
                var bundlePrice = new Price(2 * 8);
                return bundlePrice.Off(new Discount(5)) + new Price(8);
            }
        }

        return new Price(books.Count * 8);
    }
}