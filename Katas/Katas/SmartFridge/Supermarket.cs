namespace Katas.SmartFridge;

public static class Supermarket
{
    public static AddedItem Tomato(DateTime expires)
    {
        return new AddedItem("Tomato", expires);
    }

    public static AddedItem Lettuce(DateTime expires)
    {
        return new AddedItem("Lettuce", expires);
    }

    public static AddedItem Opened(this AddedItem item)
    {
        return item with { Opened = true };
    }
}