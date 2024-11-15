namespace Katas.Stack;

public class Node<T>
{
    public readonly T Value;
    public Node<T> Child { get; private set; }
    public bool HasChild => Child != null;

    Node(T value) => Value = value;

    public static Node<T> From(T value)
    {
        return new(value);
    }

    public Node<T> FatherOf(Node<T> child)
    {
        Child = child;
        return this;
    }
}