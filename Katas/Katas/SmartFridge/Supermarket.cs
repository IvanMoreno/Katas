using static Katas.SmartFridge.Supermarket;

namespace Katas.SmartFridge;

public static class FridgeMessagesBuilder
{
    public static string Expired(this string product) => $"EXPIRED: {product}";
    public static string ExpiringInDays(this string product, int days)
    {
        return $"{product}: {days} day(s) remaining";
    }

    public static string ALettuce => Lettuce(new DateTime()).Name;
    public static string ATomato => Tomato(new DateTime()).Name;
}

public static class Supermarket
{
    public static Item Tomato(DateTime expires)
    {
        return new Item("Tomato", expires);
    }

    public static Item Lettuce(DateTime expires)
    {
        return new Item("Lettuce", expires);
    }
}