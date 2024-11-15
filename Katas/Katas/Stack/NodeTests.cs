using FluentAssertions;

namespace Katas.Stack;

// Extra(Stack): Now without using any kind of collections
// My approach: create my own type Node that can store values and child nodes.
// [x] Retrieve value from Node
// [] Retrieve child from Node
// [] Children count
// [x] HasChild

public class NodeTests
{
    [Test]
    public void StoreValue()
    {
        Node<int>.From(12).Value.Should().Be(12);
    }

    [Test]
    public void HasNoChild_ByDefault()
    {
        Node<int>.From(432).HasChild.Should().BeFalse();
    }

    [Test]
    public void AttachChild()
    {
        Node<string>.From("Father")
            .FatherOf(Node<string>.From("Child"))
            .HasChild.Should().BeTrue();
    }
}