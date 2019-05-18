using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自写链表
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkedList<T> : ISelfList<T>, Iteratable<T>
{
    /// <summary>
    /// 获取队头
    /// </summary>
    protected LinkedListNode<T> HeadNode { get; private set; }

    /// <summary>
    /// 获取队尾
    /// </summary>
    protected LinkedListNode<T> TailNode
    {
        get
        {
            if (HeadNode == null)
            {
                return null;
            }
            LinkedListNode<T> nextNode = HeadNode;
            while (nextNode.Next != null)
            {
                nextNode = nextNode.Next;
            }

            return nextNode;
        }
    }

    /// <summary>
    /// 该链表的迭代器
    /// </summary>
    /// <returns></returns>
    public Iterator<T> Iterator()
    {
        return new LinkedListIterator(HeadNode);
    }

    #region 公共方法
    #region 插入方法
    /// <summary>
    /// 插入队列头
    /// </summary>
    /// <param name="data"></param>
    public void InsertHead(T data)
    {
        LinkedListNode<T> preHead = HeadNode;
        HeadNode = new LinkedListNode<T>();
        HeadNode.Data = data;
        HeadNode.Next = preHead;
    }

    /// <summary>
    /// 插入队列尾
    /// </summary>
    /// <param name="data"></param>
    public void InsertTail(T data)
    {
        LinkedListNode<T> preTail = TailNode;
        LinkedListNode<T> tail = new LinkedListNode<T>();
        tail.Data = data;
        if (preTail == null)
        {
            HeadNode = tail;
        }
        else
        {
            preTail.Next = tail;
        }
    }
    #endregion
    #region 删除方法
    public void RemoveHead()
    {
        if (HeadNode == null)
            return;
        HeadNode = HeadNode.Next;
    }

    public bool RemoveAt(int index)
    {
        if (HeadNode == null)
            return false;
        LinkedListNode<T> preNode = null;
        LinkedListNode<T> currentNode = HeadNode;
        while (index-- > 0 && currentNode != null)//调出curr
        {
            preNode = currentNode;
            currentNode = preNode.Next;
        }
        //删除尾节点没有数据
        if (currentNode == null)
        {
            return false;
        }
        //删除的是头结点
        if (preNode == null)
        {
            HeadNode = currentNode.Next;
        }
        else
        {
            preNode.Next = currentNode.Next;
        }
        return true;
    }

    public bool Remove(T data)
    {
        if (HeadNode == null)
            return false;
        LinkedListNode<T> preNode = null;
        LinkedListNode<T> currentNode = HeadNode;
        bool hasFind = false;
        while (currentNode != null)
        {
            if (currentNode.Data.Equals(data))
            {
                hasFind = true;
                break;
            }
            preNode = currentNode;
            currentNode = currentNode.Next;
        }
        //删除尾节点没有数据
        if (!hasFind)
            return false;
        //删除的是头结点
        if (preNode == null)
        {
            HeadNode.Next = currentNode.Next;
        }
        else
        {
            preNode.Next = currentNode.Next;
        }
        return true;
    }
    #endregion
    #region 查询方法
    public int Query(T data)
    {
        if (HeadNode == null)
            return -1;
        LinkedListNode<T> currentNode = HeadNode;
        int index = 0;
        while (currentNode != null)
        {
            if (currentNode.Data.Equals(data))
            {
                return index;
            }
            currentNode = currentNode.Next;
            ++index;
        }
        return -1;
    }
    #endregion
    #region 获取对头
    public T HeadData
    {
        get
        {
            if (HeadNode == null)
            {
                return default(T);
            }
            return HeadNode.Data;
        }
    }

    public T TailData
    {
        get
        {
            var tailHead = TailNode;
            if (tailHead == null)
            {
                return default(T);
            }
            return tailHead.Data;
        }
    }

    public bool IsEmpty
    {
        get { return HeadNode == null; }
    }
    #endregion
    #region 访问器遍历
    public void Accept(ISelfListVisitor<T> visitor)
    {
        Iterator<T> it = Iterator();
        while (it.HasNext)
        {
            visitor.Visit(it.Next);
        }
    }

    public void Accept(ListVisitorDelegate<T> visitor)
    {
        Iterator<T> it = Iterator();
        while (it.HasNext)
        {
            visitor(it.Next);
        }
    }
    #endregion
    #region 迭代器实现
    public class LinkedListIterator : Iterator<T>
    {
        private LinkedListNode<T> headNode;
        private LinkedListNode<T> currentNode;

        public LinkedListIterator(LinkedListNode<T> head)
        {
            headNode = head;
            if (headNode != null)
            {
                currentNode = new LinkedListNode<T>();
                currentNode.Next = headNode;
            }
        }

        public bool HasNext
        {
            get
            {
                return currentNode.Next != null;
            }
        }

        public T Next
        {
            get
            {
                T r = currentNode.Next.Data;
                currentNode = currentNode.Next;
                return r;
            }
        }
    }
    #endregion
    #endregion
}