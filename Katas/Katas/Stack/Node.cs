namespace Katas.Stack;

public class Node<T>
{
    public readonly T Value;

    Node(T value) => Value = value;

    public static Node<T> From(T value)
    {
        return new(value);
    }
}