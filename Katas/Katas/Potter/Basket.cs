namespace Katas.Potter;

public class Basket {
    readonly List<PotterBook> books;

    public Basket(List<PotterBook> books) {
        this.books = books;
    }

    public Price Price() {
        if (books.Count > 1) {
            var differentBooks = books.Distinct().Count();
            var bundleDiscount = DiscountFor(differentBooks);

            var nonBundledBooksPrice = new Price((books.Count - differentBooks) * 8);
            var bundlePrice = new Price(differentBooks * 8);
            
            var discountedPrice = bundlePrice.Off(bundleDiscount);
            return discountedPrice + nonBundledBooksPrice;
        }

        return new Price(books.Count * 8);
    }

    static Discount DiscountFor(int differentBooks) {
        var haveThreeBooksDiscount = differentBooks == 3;
        var haveTwoBooksDiscount = differentBooks == 2;

        var result = new Discount(0);
        if (haveThreeBooksDiscount)
            result = new Discount(10);
        else if (haveTwoBooksDiscount)
            result = new Discount(5);
        
        return result;
    }
}