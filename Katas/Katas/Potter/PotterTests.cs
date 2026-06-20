using FluentAssertions;

namespace Katas.Potter;

// [x] empty => 0 EUR
// [] [book1] => 8 EUR
// [] [book1, book1] => 16 EUR
// [] [book1, book2] => 15.20 EUR
// [] [book1, book2, book3] => 21.6 EUR
// [] [book1, book2, book3, book4] => 25.6 EUR
// [] [book1, book2, book3, book4, book5] => 30 EUR
// [] [book1, book2, book3, book1] => 29.6 EUR (no discount on fourth book)
// [] [book1, book1, book2, book2, book3, book3, book4, book5] => 51.20 EUR
// [] [book1, book2, book1, book3, book2] => 36.8 EUR

public class PotterTests
{
    [Test]
    public void EmptyBasket_CostsNothing() {
        new Basket().Price().Should().Be(new Euro(0));
    }
}