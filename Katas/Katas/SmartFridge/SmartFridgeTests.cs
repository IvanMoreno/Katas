using FluentAssertions;

namespace Katas.SmartFridge;

// https://www.codurance.com/katas/smart-fridge
// [] Display the items of the Fridge:
//    [] Each item have an expiration date
//    [] Each item can be opened or closed when introduced in the fridge, this cannot be changed
//    [] An item is expired if its expiration date matches today's date
//    [] A non expired item will be displayed as 'item.name: n day(s) remaining'
//    [] An expired item will be displayed as 'EXPIRED: item.name'
//    [] Expired items are displayed before non expired items
// [] Add an item to the fridge
// [] Opening the fridge degrades all items inside the fridge
//    [] If the item is opened, it is degraded by 5 hours
//    [] If the item is closed, it is degraded by 1 hour

// Dates are an important part of this kata, every operation performed in the fridge must be tracked.

public class SmartFridgeTests
{
    [Test]
    public void DisplayNoItems_WhenFridgeIsEmpty()
    {
        Fridge.At(new DateTime()).Display().Should().BeEmpty();
    }

    [Test]
    public void DisplayAnItem_ThatExpires_Tomorrow()
    {
        Fridge.At(new DateTime())
            .Put(new Item("Tomato", new DateTime().AddDays(1)))
            .Display()
            .Should().Be("Tomato: 0 day(s) remaining");
    }

    [Test]
    public void DisplayAnItem_ThatExpires_InTwoDays()
    {
        Fridge.At(new DateTime())
            .Put(new Item("Tomato", new DateTime().AddDays(2)))
            .Display()
            .Should().Be("Tomato: 1 day(s) remaining");
    }

    [Test]
    public void AFridge_CanBeInitialized_AtAnyDate()
    {
        var today = new DateTime().AddDays(5);
        Fridge.At(today)
            .Put(new Item("Tomato", today.AddDays(1)))
            .Display()
            .Should().Be("Tomato: 0 day(s) remaining");
    }
}