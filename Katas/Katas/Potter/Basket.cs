namespace Katas.Potter;

public class Basket {
    readonly List<PotterBook> books;

    public Basket(List<PotterBook> books) {
        this.books = books;
    }

    public Price Price() {
        if (books.Count > 1) {
            var differentBooks = books.Distinct().Count();
            
            var haveThreeBooksDiscount = differentBooks == 3;
            var haveTwoBooksDiscount = differentBooks == 2;

            var bundleDiscount = new Discount(0);
            if (haveThreeBooksDiscount)
                bundleDiscount = new Discount(10);
            else if (haveTwoBooksDiscount)
                bundleDiscount = new Discount(5);
            
            var nonBundledBooksPrice = new Price((books.Count - differentBooks) * 8);
            var bundlePrice = new Price(differentBooks * 8);
            if (haveThreeBooksDiscount) {
                var discountedPrice = bundlePrice.Off(bundleDiscount);
                return discountedPrice + nonBundledBooksPrice;
            }
            
            if (haveTwoBooksDiscount) {
                var discountedPrice = bundlePrice.Off(bundleDiscount);
                return discountedPrice + nonBundledBooksPrice;
            }
        }

        return new Price(books.Count * 8);
    }
}