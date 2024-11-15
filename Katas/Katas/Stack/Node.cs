namespace Katas.Stack;

public record Node<T>
{
    public readonly T Value;
    public Node<T>? Child { get; private init; }
    public bool HasChild => Child != null;
    public int ChildrenCount => HasChild ? 1 + Child!.ChildrenCount : 0;

    Node(T value) => Value = value;
    public static Node<T> From(T value) => new(value);
    public Node<T> FatherOf(Node<T> child) => this with { Child = child };
}