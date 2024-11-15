using FluentAssertions;

namespace Katas.Stack;

// https://www.codurance.com/katas/stack
// [] Push - Add an element to the top of the stack    
// [] Pop - Remove an element from the top of the stack, returning it
// [] Empty check - Check if the stack is empty or not
// [] Size - Count of the elements in the stack
// [] Peek - Check the top of the stack without popping

public class StackTests
{
    [Test]
    public void IsEmpty_ByDefault()
    {
        new MyStack().Length.Should().Be(0);
    }
}

public class MyStack
{
    public int Length { get; set; } = 0;
}