namespace Katas.SmartFridge;

public static class FridgeMessagesBuilder
{
    public static string Expired(this string product) => $"EXPIRED: {product}";
    public static string ExpiringInDays(this string product, int days)
    {
        return $"{product}: {days} day(s) remaining";
    }

    public static string And(this string first, string second) => $"{first}\n{second}";

    public static string ALettuce => Supermarket.Lettuce(new DateTime()).Name;
    public static string ATomato => Supermarket.Tomato(new DateTime()).Name;
}