namespace Katas.SmartFridge;

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