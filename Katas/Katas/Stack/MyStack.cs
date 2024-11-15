namespace Katas.Stack;

public class MyStack<T>
{
    readonly List<T> elements = new();
    public int Length => elements.Count;
    public bool IsEmpty => Length == 0;

    public void Push(T element)
    {
        elements.Add(element);
    }

    public T Pop()
    {
        if (Length == 0)
            throw new InvalidOperationException();
        
        var result = elements.Last();
        elements.RemoveAt(Length - 1);
        return result;
    }

    public T Peek()
    {
        if (Length == 0)
            throw new InvalidOperationException();
        
        return elements.Last();
    }

    public static MyStack<T> Empty() => new();
}