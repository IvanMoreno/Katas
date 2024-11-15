namespace Katas.Stack;

public class Node<T>
{
    public readonly T Value;
    public bool HasChild { get; private set; }

    Node(T value) => Value = value;

    public static Node<T> From(T value)
    {
        return new(value);
    }

    public Node<T> FatherOf(Node<T> child)
    {
        HasChild = true;
        return this;
    }
}