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
        MyStack.Empty().Length.Should().Be(0);
    }

    [Test]
    public void PushElement_IncreasesLength()
    {
        var sut = MyStack.Empty();

        sut.Push(1321);

        sut.Length.Should().Be(1);
    }

    [Test]
    public void PopElement_DecreasesLength()
    {
        var sut = MyStack.Empty();
        
        sut.Push(321);
        sut.Pop();

        sut.Length.Should().Be(0);
    }
}