namespace Katas.Potter;

public class Basket {
    readonly List<Book> books;

    public Basket(List<Book> books) {
        this.books = books;
    }

    public Price Price() {
        return new Price(books.Count * 8);
    }
}