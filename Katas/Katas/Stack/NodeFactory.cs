namespace Katas.Stack;

public static class NodeFactory
{
    public static Node<string> StringNode(string value) => Node<string>.From(value);
    public static Node<int> IntNode(int value) => Node<int>.From(value);
}