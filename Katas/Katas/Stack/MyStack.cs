namespace Katas.Stack;

public class MyStack<T>
{
    readonly List<T> elements = new();
    Node<T>? head;
    public int Length => elements.Count;
    public bool IsEmpty => Length == 0;

    public void Push(T element)
    {
        head = head == null ? Node<T>.From(element) : Node<T>.From(element).FatherOf(head);
        elements.Add(element);
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException();
        
        var result = elements.Last();
        elements.RemoveAt(Length - 1);
        return result;
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        return head!.Value;
    }

    public static MyStack<T> Empty() => new();
}