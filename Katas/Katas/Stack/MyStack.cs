namespace Katas.Stack;

public class MyStack
{
    public int Length { get; set; } = 0;

    public void Push(int i)
    {
        Length++;
    }

    public static MyStack Empty()
    {
        return new MyStack();
    }
}