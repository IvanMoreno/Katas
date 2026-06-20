namespace Katas.Potter;

public readonly struct PotterBook {
    public PotterBook(string id) {
        
    }

    public static PotterBook First() {
        return new PotterBook("1");
    }

    public static PotterBook Second() {
        return new PotterBook("2");
    }
}