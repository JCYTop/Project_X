using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType
{
    Left = 0,
    Right = 1,
    Root = 2,
}

public class BinarySearchTree<T> : Iteratable<T> where T : IBinarySearchTree
{
    private Node<T> headNode;
    public delegate void DataVisitor(T data);

    #region 公共方法

    #region 插入
    public void Insert(T[] dataArray)
    {
        if (dataArray == null)
        {
            throw new NullReferenceException("搜索二叉树需要数据插入");
        }
        for (int i = 0; i < dataArray.Length; ++i)
        {
            Insert(dataArray[i]);
        }
    }

    public void Insert(T data)
    {
        if (data == null)
        {
            throw new NullReferenceException("搜索二叉树需要数据插入");
        }
        if (headNode == null)
        {
            headNode = new Node<T>(data);
            headNode.SetParent(null, NodeType.Root);
            return;
        }
        Node<T> newNode = new Node<T>(data);
        float score = newNode.SortScore;
        Node<T> preNode = null;
        Node<T> currentNode = headNode;//中间变量
        while (currentNode != null)//判断
        {
            preNode = currentNode;
            if (score < currentNode.SortScore)
            {
                currentNode = currentNode.LeftChild;
                if (currentNode == null)
                {
                    newNode.SetParent(preNode, NodeType.Left);
                    preNode.LeftChild = newNode;
                    break;
                }
            }
            else
            {
                currentNode = currentNode.RightChild;
                if (currentNode == null)
                {
                    newNode.SetParent(preNode, NodeType.Right);
                    preNode.RightChild = newNode;
                    break;
                }
            }
        }
    }
    #endregion

    #region 查找
    public Node<T> Find(Node<T> head, T data)
    {
        if (data == null)
        {
            return null;
        }
        float score = data.SortScore;
        Node<T> currentNode = head;
        while (currentNode != null)
        {
            if (data.Equals(currentNode.Data))
            {
                break;
            }
            if (score < currentNode.SortScore)
            {
                currentNode = currentNode.LeftChild;
            }
            else
            {
                currentNode = currentNode.RightChild;
            }
        }
        return currentNode;
    }
    #endregion

    #region 删除
    public void Remove(T data)
    {
        if (data == null)
        {
            return;
        }
        Node<T> currentNode = Find(headNode, data);
        if (currentNode == null)
        {
            throw new NullReferenceException("Not Find DeleteNode");
        }

        #region 左右子树都空直接删除
        if (currentNode.LeftChild == null && currentNode.RightChild == null)
        {
            switch (currentNode.NodeType)
            {
                case NodeType.Left:
                    currentNode.Parent.LeftChild = null;
                    break;
                case NodeType.Right:
                    currentNode.Parent.RightChild = null;
                    break;
                case NodeType.Root:
                    headNode = null;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 右子树不空，接入原父节点的父节点，并绑定原子节点
        if (currentNode.RightChild != null)
        {
            Node<T> rightChild = currentNode.RightChild;
            switch (currentNode.NodeType)
            {
                case NodeType.Left:
                    currentNode.Parent.LeftChild = rightChild;
                    rightChild.SetParent(currentNode.Parent, NodeType.Left);
                    break;
                case NodeType.Right:
                    currentNode.Parent.RightChild = rightChild;
                    rightChild.SetParent(currentNode.Parent, NodeType.Right);
                    break;
                case NodeType.Root:
                    headNode = rightChild;
                    rightChild.SetParent(null, NodeType.Root);
                    break;
                default:
                    break;
            }
            //左子树的根节点是右子树的最左节点
            Node<T> minLeftNode = GetMinNode(rightChild);
            if (currentNode.LeftChild != null)
            {
                minLeftNode.LeftChild = currentNode.LeftChild;
                currentNode.LeftChild.SetParent(minLeftNode, NodeType.Left);
            }
            return;
        }
        #endregion

        #region 左子树不空，接入原父节点的父节点
        if (currentNode.LeftChild != null)
        {
            var leftNode = currentNode.LeftChild;
            switch (currentNode.NodeType)
            {
                case NodeType.Left:
                    currentNode.Parent.LeftChild = leftNode;
                    leftNode.SetParent(currentNode.Parent, NodeType.Left);
                    break;
                case NodeType.Right:
                    currentNode.Parent.RightChild = leftNode;
                    leftNode.SetParent(currentNode.Parent, NodeType.Right);
                    break;
                case NodeType.Root:
                    headNode = leftNode;
                    leftNode.SetParent(null, NodeType.Root);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
    #endregion

    #region 遍历&访问&迭代器
    public void Accept(DataVisitor visitor)
    {
        if (headNode == null)
        {
            throw new NullReferenceException("搜索树中没有数据");
        }
        Stack<Node<T>> stack = new Stack<Node<T>>();
        Node<T> current = headNode;
        while (current != null || stack.Count != 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.LeftChild;
            }
            if (stack.Count != 0)
            {
                current = stack.Pop();
                visitor(current.Data);
                current = current.RightChild;
            }
        }
    }

    public Iterator<T> Iterator()
    {
        return new BinarySearchTreeIterator<T>(headNode);
    }
    #endregion

    #endregion

    private Node<T> GetMinNode(Node<T> head)
    {
        Node<T> current = head;
        while (current.LeftChild != null)
        {
            current = current.LeftChild;
        }
        return current;
    }
}

/// <summary>
/// 搜索二叉树的节点类
/// </summary>
/// <typeparam name="T"></typeparam>
public class Node<T> where T : IBinarySearchTree
{
    public Node<T> LeftChild;
    public Node<T> RightChild;
    private Node<T> parent;
    private NodeType nodeType;
    private T data;

    public Node(T data)
    {
        this.data = data;
    }

    public float SortScore
    {
        get { return data.SortScore; }
    }

    public T Data
    {
        get { return data; }
    }

    public Node<T> Parent
    {
        get { return parent; }
    }

    public NodeType NodeType
    {
        get { return nodeType; }
    }

    public bool IsLeaf()
    {
        if (LeftChild != null && RightChild != null)
        {
            return true;
        }
        return false;
    }

    public void SetParent(Node<T> parent, NodeType nodeType)
    {
        this.parent = parent;
        this.nodeType = nodeType;
    }
}

public class BinarySearchTreeIterator<T> : Iterator<T> where T : IBinarySearchTree
{
    private Node<T> headNode;
    private Node<T> current;
    private Stack<Node<T>> stack = new Stack<Node<T>>();

    public BinarySearchTreeIterator(Node<T> headNode)
    {
        this.headNode = headNode;
        current = this.headNode;
    }

    public bool HasNext
    {
        get
        {
            if (current != null || stack.Count != 0)
            {
                return true;
            }
            return false;
        }
    }

    public T Next
    {
        get
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.LeftChild;
            }

            if (stack.Count != 0)
            {
                current = stack.Pop();
                T result = current.Data;
                current = current.RightChild;
                return result;
            }
            return default(T);
        }
    }
}