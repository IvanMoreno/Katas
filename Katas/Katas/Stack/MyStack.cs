namespace Katas.Stack;

public class MyStack<T>
{
    Node<T>? head;
    public int Length => 1 + head?.ChildrenCount ?? 0;
    public bool IsEmpty => Length == 0;

    public void Push(T element)
        => head = head == null
            ? Node<T>.From(element)
            : Node<T>.From(element).FatherOf(head);

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        var newResult = head!.Value;
        head = head.Child;
        return newResult;
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        return head!.Value;
    }

    public static MyStack<T> Empty() => new();
}