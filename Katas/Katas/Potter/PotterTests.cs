using FluentAssertions;

namespace Katas.Potter;

// [] Configure discounts
// [] Configure book price

// [] [book1, book2, book1] => [(book1, book2), (book1)]
// [] [book1, book2, book3, book1, book2, book3] => [(book1, book2, book3), (book1, book2, book3)]
// [] [book1, book2, book2, book3, book3, book4, book5] => [(book1, book2, book3, book4, book5), (book2, book3)]
// [] [book1, book1, book2, book2, book3, book3, book4, book5] => [(book1, book2, book3, book4), (book1, book2, book3, book5)]

// [] [book1, book1, book2, book2, book3, book3, book4, book5] => 51.20 EUR
// [] [book1, book2, book1, book3, book2] => 36.8 EUR

// [-] Use Discount API in tests

public class PotterTests {
    [Test]
    public void EmptyBasket_CostsNothing() {
        new Basket([]).Price().Should().Be(new Price(0));
    }

    [Test]
    public void OneBook_Costs8Euro() {
        new Basket([PotterBook.First]).Price().Should().Be(new Price(8));
    }

    [Test]
    public void TwoDifferentBooks_ComeWith_5PercentDiscount() {
        new Basket([PotterBook.First, PotterBook.Second]).Price().Should().Be(new Price(15.20f));
    }

    [Test]
    public void TwoSameBooks_ComeWith_NoDiscount() {
        new Basket([PotterBook.First, PotterBook.First]).Price().Should().Be(new Price(16));
    }

    [Test]
    public void ThreeDifferentBooks_ComeWith_10PercentDiscount() {
        new Basket([PotterBook.First, PotterBook.Second, PotterBook.Third]).Price().Should().Be(new Price(21.60f));
    }

    [Test]
    public void TwoDifferentBooks_AndOneRepeated_ComeWith_5PercentDiscount_OnlyOnTwoBooks() {
        new Basket([PotterBook.First, PotterBook.Second, PotterBook.First]).Price().Should().Be(new Price(23.20f));
        new Basket([PotterBook.First, PotterBook.First, PotterBook.Second]).Price().Should().Be(new Price(23.20f));
    }

    [Test]
    public void FourDifferentBooks_ComeWith_20PercentDiscount() {
        new Basket([PotterBook.First, PotterBook.Second, PotterBook.Third, PotterBook.Fourth])
            .Price()
            .Should().Be(new Price(25.60f));
    }
    
    [Test]
    public void FiveDifferentBooks_ComeWith_25PercentDiscount() {
        new Basket([PotterBook.First, PotterBook.Second, PotterBook.Third, PotterBook.Fourth, PotterBook.Fifth])
            .Price()
            .Should().Be(new Price(30));
    }
    
    [Test]
    public void BookEqualityTest() {
        PotterBook.First.Should().Be(PotterBook.First);
        PotterBook.First.Should().NotBe(PotterBook.Second);
    }

    [Test]
    public void ApplyDiscountToPrice() {
        new Price(20).Off(new Discount(50)).Should().Be(new Price(10));
        new Price(7).Off(new Discount(50)).Should().Be(new Price(3.5f));
        new Price(10).Off(new Discount(25)).Should().Be(new Price(7.5f));
        new Price(10).Off(new Discount(10)).Should().Be(new Price(9));
    }
}