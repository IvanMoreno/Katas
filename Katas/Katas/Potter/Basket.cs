namespace Katas.Potter;

public class Basket {
    readonly List<PotterBook> books;

    public Basket(List<PotterBook> books) {
        this.books = books;
    }

    public Price Price() {
        var differentBooks = books.Distinct().Count();
        
        var bundlePrice = new Price(differentBooks * 8);
        var discountedPrice = bundlePrice.Off(DiscountFor(differentBooks));
        
        var nonBundledBooksPrice = new Price((books.Count - differentBooks) * 8);
        
        return discountedPrice + nonBundledBooksPrice;
    }

    static Discount DiscountFor(int differentBooks) {
        if (differentBooks == 4)
            return new Discount(20);
        
        if (differentBooks == 3)
            return new Discount(10);

        if (differentBooks == 2)
            return new Discount(5);

        return new Discount(0);
    }
}