using FluentAssertions;
using static Katas.SmartFridge.FridgeMessagesBuilder;
using static Katas.SmartFridge.Supermarket;

namespace Katas.SmartFridge;

// https://www.codurance.com/katas/smart-fridge
// [x] Display the items of the Fridge:
//    [x] Each item have an expiration date
//    [x] Each item can be opened or closed when introduced in the fridge, this cannot be changed
//    [x] An item is expired if its expiration date matches today's date
//    [x] A non expired item will be displayed as 'item.name: n day(s) remaining'
//    [x] An expired item will be displayed as 'EXPIRED: item.name'
//    [x] Expired items are displayed before non expired items
// [x] Add an item to the fridge
// [x] Opening the fridge degrades all items inside the fridge
//    [x] If the item is opened, it is degraded by 5 hours
//    [x] If the item is closed, it is degraded by 1 hour

// Dates are an important part of this kata, every operation performed in the fridge must be tracked.

// What I have learn:
// I left little room for refactoring between steps in this kata, making it more difficult to transition to the
// fully event-sourced solution. I spent 25% of the kata doing that refactoring,
// whereas I think I could have spent less by doing that refactoring bit by bit, as the code evolved.

public class SmartFridgeTests
{
    static DateTime Today => new();
    static DateTime Tomorrow => Today.AddDays(1);
    static DateTime NextWeek => Today.AddDays(7);

    static TimeSpan OneHour => TimeSpan.FromHours(1);
    static TimeSpan FiveHours => TimeSpan.FromHours(5);

    [Test]
    public void DisplayNoItems_WhenFridgeIsEmpty()
    {
        Fridge.At(Today).Display().Should().BeEmpty();
    }

    [Test]
    public void DisplayAnItem_ThatExpires_Tomorrow()
    {
        Fridge.At(Today)
            .Put(Tomato(expires: Today.AddDays(1)))
            .Display()
            .Should().Be("Tomato: 0 day(s) remaining");
    }

    [Test]
    public void DisplayAnItem_ThatExpires_InTwoDays()
    {
        Fridge.At(Today)
            .Put(Tomato(expires: Today.AddDays(2)))
            .Display()
            .Should().Be(ATomato.ExpiringInDays(1));
    }

    [Test]
    public void AFridge_CanBeInitialized_AtAnyDate()
    {
        Fridge.At(Today)
            .Put(Lettuce(expires: NextWeek))
            .Display()
            .Should().Be(ALettuce.ExpiringInDays(6));
    }

    [Test]
    public void DisplayExpiredItem()
    {
        Fridge.At(Today)
            .Put(Lettuce(expires: Today))
            .Display()
            .Should().Be(ALettuce.Expired());
        
        Fridge.At(Today)
            .Put(Tomato(expires: Today))
            .Display()
            .Should().Be(ATomato.Expired());
    }

    [Test]
    public void DisplayTwoItems()
    {
        Fridge.At(Today)
            .Put(Tomato(expires: Tomorrow))
            .Put(Lettuce(expires: Tomorrow))
            .Display()
            .Should().Be(ATomato.ExpiringInDays(0).And(ALettuce).ExpiringInDays(0));
    }

    [Test]
    public void DisplayExpiredItemsFirst()
    {
        Fridge.At(Today)
            .Put(Tomato(expires: Tomorrow))
            .Put(Lettuce(expires: Today))
            .Display()
            .Should().Be(ALettuce.Expired().And(ATomato.ExpiringInDays(0)));
    }

    [Test]
    public void DegradeItem_AfterOpeningDoor()
    {
        Fridge.At(Today)
            .Put(Tomato(expires: Tomorrow))
            .OpenDoor()
            .Display()
            .Should().Be(ATomato.Expired());
    }

    [Test]
    public void PassTime()
    {
        Fridge.At(Today)
            .Put(Tomato(expires: Tomorrow))
            .Pass(OneHour)
            .Display()
            .Should().Be(ATomato.Expired());
    }
    
    [Test]
    public void OpeningAFridge_BeforePuttingItem_DoesNotDegradeIt()
    {
        Fridge.At(Today)
            .OpenDoor()
            .Pass(OneHour)
            .Put(Tomato(expires: Tomorrow + OneHour))
            .Display()
            .Should().NotBe(ATomato.Expired());
    }

    [Test]
    public void CompareDoorOpeningDate_WithItemAdditionDate_ToDegradeExpiration()
    {
        Fridge.At(Today)
            .Put(Lettuce(expires: Tomorrow + OneHour))
            .OpenDoor()
            .Pass(OneHour)
            .Display()
            .Should().Be(ALettuce.Expired());
    }

    [Test]
    public void OpeningDoorTwice_DegradesItemsTwice()
    {
        Fridge.At(Today)
            .Put(Lettuce(expires: Tomorrow + OneHour))
            .OpenDoor()
            .OpenDoor()
            .Display()
            .Should().Be(ALettuce.Expired());
    }

    [Test]
    public void EachOpening_HasItsOwnDate()
    {
        Fridge.At(Today)
            .OpenDoor()
            .Pass(OneHour)
            .Put(Lettuce(expires: Tomorrow + OneHour))
            .OpenDoor()
            .OpenDoor()
            .Display()
            .Should().Be(ALettuce.Expired());
    }

    [Test]
    public void AClosedItemIsDegraded_OnlyOneHour()
    {
        Fridge.At(Today)
            .Put(Lettuce(expires: Tomorrow + OneHour))
            .OpenDoor()
            .Display()
            .Should().NotBe(ALettuce.Expired());
    }

    [Test]
    public void AnOpenedItem_IsDegraded_FiveHours()
    {
        Fridge.At(Today)
            .Put(Lettuce(expires: Tomorrow + OneHour).Opened())
            .OpenDoor()
            .Display()
            .Should().Be(ALettuce.Expired());
        
        Fridge.At(Today)
            .Put(Lettuce(expires: Tomorrow + FiveHours).Opened())
            .OpenDoor()
            .Display()
            .Should().NotBe(ALettuce.Expired());
    }
}