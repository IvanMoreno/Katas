namespace Katas.Potter;

public readonly struct PotterBook {
    readonly string id;

    PotterBook(string id) {
        this.id = id;
    }

    public static PotterBook First() {
        return new PotterBook("1");
    }

    public static PotterBook Second() {
        return new PotterBook("2");
    }

    public static PotterBook Third() {
        return new PotterBook("3");
    }
}