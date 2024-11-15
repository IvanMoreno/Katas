using FluentAssertions;
using static Katas.Stack.NodeFactory;

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
        IntNode(12).Value.Should().Be(12);
    }

    [Test]
    public void HasNoChild_ByDefault()
    {
        IntNode(432).HasChild.Should().BeFalse();
    }

    [Test]
    public void AttachChild()
    {
        StringNode("Father")
            .FatherOf(StringNode("Child"))
            .HasChild.Should().BeTrue();
    }

    [Test]
    public void RetrieveChild()
    {
        StringNode("Father")
            .FatherOf(StringNode("Child"))
            .Child.Value.Should().Be("Child");
    }
}