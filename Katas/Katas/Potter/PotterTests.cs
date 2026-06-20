using FluentAssertions;

namespace Katas.Potter;

// [x] empty => 0 EUR
// [x] [book1] => 8 EUR
// [] [book1, book1] => 16 EUR
// [] [book1, book2] => 15.20 EUR
// [] [book1, book2, book3] => 21.6 EUR
// [] [book1, book2, book3, book4] => 25.6 EUR
// [] [book1, book2, book3, book4, book5] => 30 EUR
// [] [book1, book2, book3, book1] => 29.6 EUR (no discount on fourth book)
// [] [book1, book1, book2, book2, book3, book3, book4, book5] => 51.20 EUR
// [] [book1, book2, book1, book3, book2] => 36.8 EUR
// [x] Book Equality

public class PotterTests {
    [Test]
    public void EmptyBasket_CostsNothing() {
        new Basket([]).Price().Should().Be(new Price(0));
    }

    [Test]
    public void OneBook_Costs8Euro() {
        new Basket([PotterBook.First()]).Price().Should().Be(new Price(8));
    }

    [Test]
    public void TwoDifferentBooks_ComeWith_5PercentDiscount() {
        new Basket([PotterBook.First(), PotterBook.Second()]).Price().Should().Be(new Price(15.20f));
    }

    [Test]
    public void BookEqualityTest() {
        PotterBook.First().Should().Be(PotterBook.First());
        PotterBook.First().Should().NotBe(PotterBook.Second());
    }

    [Test]
    public void ApplyDiscountToPrice() {
        new Price(20).Off(new Discount(50)).Should().Be(new Price(10));
        new Price(7).Off(new Discount(50)).Should().Be(new Price(3.5f));
        new Price(10).Off(new Discount(25)).Should().Be(new Price(7.5f));
        new Price(10).Off(new Discount(10)).Should().Be(new Price(9));
    }
}