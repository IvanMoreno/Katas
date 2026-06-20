namespace Katas.Potter;

public readonly struct PotterBook {
    readonly string id;

    PotterBook(string id) {
        this.id = id;
    }

    public static PotterBook First() => new("1");
    public static PotterBook Second() => new("2");
    public static PotterBook Third() => new("3");
    public static PotterBook Fourth() => new("4");
    public static PotterBook Fifth() => new("5");
}