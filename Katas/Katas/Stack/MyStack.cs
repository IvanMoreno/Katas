namespace Katas.Stack;

public class MyStack<T>
{
    public int Length { get; set; } = 0;

    public void Push(T i)
    {
        Length++;
    }

    public void Pop()
    {
        Length = 0;
    }

    public static MyStack<T> Empty() => new();
}