namespace Katas.Stack;

public class MyStack<T>
{
    public int Length { get; set; } = 0;
    List<T> elements = new();

    public void Push(T element)
    {
        elements.Add(element);
        Length++;
    }

    public T Pop()
    {
        Length = 0;
        return elements.Last();
    }

    public static MyStack<T> Empty() => new();
}