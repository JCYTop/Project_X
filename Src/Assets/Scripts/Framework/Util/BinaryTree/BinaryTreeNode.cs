using System;

namespace Base.BinaryTree
{
    public class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public TNode Value { get; }
        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }

        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }

        public int CompareNode(BinaryTreeNode<TNode> node)
        {
            return Value.CompareTo(node.Value);
        }

        public int CompareTo(TNode node)
        {
            return Value.CompareTo(node);
        }
    }
}