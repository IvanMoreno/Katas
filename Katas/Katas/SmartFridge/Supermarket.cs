namespace Katas.SmartFridge;

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