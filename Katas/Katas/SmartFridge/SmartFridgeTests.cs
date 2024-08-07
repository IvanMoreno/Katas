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
        Fridge.Empty().Display().Should().BeEmpty();
    }

    [Test]
    public void DisplayAnItem_ThatExpires_Tomorrow()
    {
        Fridge.Empty()
            .Put(new Item("Tomato", new DateTime().AddDays(1)))
            .Display().Should()
            .Be("Tomato: 0 day(s) remaining");
    }
}

public class Fridge
{
    Item? stored;

    public string Display()
    {
        return stored == null ? "" : "Tomato: 0 day(s) remaining";
    }

    public Fridge Put(Item item)
    {
        stored = item;
        return this;
    }

    public static Fridge Empty()
    {
        return new Fridge();
    }
}

public record Item(string Name, DateTime ExpirationDate)
{
    
}