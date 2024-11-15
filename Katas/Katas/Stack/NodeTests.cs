using FluentAssertions;

namespace Katas.Stack;

// Extra(Stack): Now without using any kind of collections
// My approach: create my own type Node that can store values and child nodes.
// [x] Retrieve value from Node
// [] Retrieve child from Node
// [] Children count
// [] HasChild

public class NodeTests
{
    [Test]
    public void StoreValue()
    {
        Node<int>.From(12).Value.Should().Be(12);
    }
}