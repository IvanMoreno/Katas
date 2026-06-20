namespace Katas.Potter;

public readonly struct PotterBook {
    public PotterBook(string title) {
        
    }

    public static PotterBook First() {
        return new PotterBook("Vol 1");
    }
}