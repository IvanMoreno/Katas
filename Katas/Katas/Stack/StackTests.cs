using FluentAssertions;

namespace Katas.Stack;

// https://www.codurance.com/katas/stack
// [x] Push - Add an element to the top of the stack    
// [x] Pop - Remove an element from the top of the stack, returning it
// [] Empty check - Check if the stack is empty or not
// [x] Size - Count of the elements in the stack
// [x] Peek - Check the top of the stack without popping

public class StackTests
{
    [Test]
    public void IsEmpty_ByDefault()
    {
        MyStack<int>.Empty().Length.Should().Be(0);
    }

    [Test]
    public void PushElement_IncreasesLength()
    {
        var sut = MyStack<int>.Empty();

        sut.Push(1321);
        
        sut.Length.Should().Be(1);
    }

    [Test]
    public void AccumulateElements()
    {
        var sut = MyStack<int>.Empty();

        sut.Push(1321);
        sut.Push(432);
        
        sut.Length.Should().Be(2);
    }

    [Test]
    public void PopElement_DecreasesLength()
    {
        var sut = MyStack<int>.Empty();
        
        sut.Push(321);
        sut.Push(123);

        sut.Pop();
        sut.Length.Should().Be(1);
        sut.Pop();
        sut.Length.Should().Be(0);
    }

    [Test]
    public void PopReturns_LastPushedElement()
    {
        var sut = MyStack<string>.Empty();
        
        sut.Push("Tail");
        sut.Push("Head");
        
        sut.Pop().Should().Be("Head");
        sut.Pop().Should().Be("Tail");
    }

    [Test]
    public void PeekLastPushedElement()
    {
        var sut = MyStack<string>.Empty();
        
        sut.Push("Head");

        sut.Peek().Should().Be("Head");
    }

    [Test]
    public void Peeking_DoesNotRemove_LastPush()
    {
        var sut = MyStack<string>.Empty();
        
        sut.Push("Tail");
        sut.Push("Head");

        sut.Peek().Should().Be("Head");
        sut.Peek().Should().Be("Head");
        sut.Length.Should().Be(2);
    }
}