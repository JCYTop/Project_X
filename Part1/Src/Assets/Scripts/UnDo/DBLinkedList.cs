/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     DBLinkList
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/08 22:05:37
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 双向链表
/// </summary>
public class DBLinkedList<T>
{
    private DBNode<T> head;

    /// <summary>
    /// 记录最小使用值
    /// </summary>
    private int minUseCount = int.MaxValue;

    private DBNode<T> minUseNode = null;

    /// <summary>
    /// 记录最大使用值
    /// </summary>
    private int maxUseCount = int.MinValue;


    private DBNode<T> maxUseNode = null;

    /// <summary>
    /// 容量
    /// </summary>
    private int capacity;

    public DBNode<T> Head
    {
        get { return head; }
        set { head = value; }
    }

    /// <summary>
    /// 返回链表的长度
    /// </summary>
    /// <returns></returns>
    public int Count
    {
        get
        {
            var ptr = Head;
            var length = 0;
            while (ptr != null)
            {
                if (ptr.UseCount > maxUseCount)
                {
                    maxUseCount = ptr.UseCount;
                    maxUseNode = ptr;
                }

                if (ptr.UseCount < minUseCount)
                {
                    minUseCount = ptr.UseCount;
                    minUseNode = ptr;
                }

                length++;
                ptr = ptr.Next;
            }

            return length;
        }
    }

    /// <summary>
    /// LRU根据条件删除
    /// </summary>
    public bool IsLRUbyCapacity
    {
        get
        {
            if (Math.Ceiling(capacity * 1.5f) < Count)
            {
                return true;
            }

            return false;
        }
    }

    /// <summary>
    /// LFU根据条件删除
    /// </summary>
    public bool IsLFUbyCapacity
    {
        get
        {
            if (capacity < Count)
            {
                return true;
            }

            return false;
        }
    }

    #region 构造函数

    public DBLinkedList()
    {
        Head = null;
    }

    public DBLinkedList(DBNode<T> node)
    {
        Head = node;
    }

    public DBLinkedList(DBNode<T> node, int capacity)
    {
        Head = node;
        this.capacity = capacity;
    }

    #endregion

    /// <summary>
    /// 索引器
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public DBNode<T> this[int index]
    {
        get { return GetItemAt(index); }
    }

    private DBNode<T> GetItemAt(int index)
    {
        //判空
        if (IsEmpty())
        {
            LogTool.Log(string.Format("链表为空"), LogEnum.NormalLog);
            return null;
        }

        var ptr = new DBNode<T>();
        ptr = Head;

        // 如果是第一个node
        if (0 == index)
        {
            return ptr;
        }

        var j = 0;
        while (ptr.Next != null && j < index)
        {
            j++;
            ptr = ptr.Next;
            if (j == index)
            {
                return ptr;
            }
        }

        LogTool.Log(string.Format("节点并不存在"), LogEnum.NormalLog);
        return null;
    }

    /// <summary>
    /// 判断双向链表是否为空
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return head == null;
    }

    /// <summary>
    /// 清空双链表
    /// </summary>
    public void Clear()
    {
        Head = null;
    }

    /// <summary>
    /// 在位置i后插入node T
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    public DBNode<T> AddAfter(T item, int index)
    {
        if (IsEmpty() || index < 0)
        {
            LogTool.Log(string.Format("链表为空或者此节点不能进行连接"), LogEnum.NormalLog);
            return default(DBNode<T>);
        }

        DBNode<T> newNode = default(DBNode<T>);
        if (index == 0) //在头之后插入元素
        {
            newNode = new DBNode<T>(item);
            newNode.Next = Head.Next;
            Head.Next.Prev = newNode;
            Head.Next = newNode;
            newNode.Prev = Head;
            return newNode;
        }

        var ptr = Head; //p指向head
        var j = 0;

        while (ptr != null && j < index)
        {
            ptr = ptr.Next;
            j++;
            if (j == index)
            {
                newNode = new DBNode<T>(item);
                newNode.Next = null;
                if (ptr.Next != null)
                {
                    newNode.Next = ptr.Next;
                    ptr.Next.Prev = newNode;
                }

                newNode.Prev = ptr;
                ptr.Next = newNode;
            }
            else
            {
                LogTool.Log(string.Format("此节点不能进行连接"), LogEnum.NormalLog);
            }
        }

        return newNode;
    }

    /// <summary>
    /// 在位置i前插入node T
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    public DBNode<T> AddBefore(T item, int index)
    {
        if (IsEmpty() || index < 0)
        {
            LogTool.Log(string.Format("链表为空或者此节点不能进行连接", LogEnum.NormalLog));
            return default(DBNode<T>);
        }

        DBNode<T> newNode = default(DBNode<T>);
        if (index == 0) //在头之前插入元素
        {
            newNode = new DBNode<T>(item);
            newNode.Next = Head; //把头改成第二个元素
            Head.Prev = newNode;
            Head = newNode; //把新元素设置为头
            return newNode;
        }

        var ptr = Head;
        var d = new DBNode<T>();
        var j = 0;

        while (ptr.Next != null && j < index)
        {
            d = ptr; //把d设置为头
            ptr = ptr.Next;
            j++;
            if (ptr.Next == null) //在最后节点后插入，即AddLast
            {
                newNode = new DBNode<T>(item);
                ptr.Next = newNode;
                newNode.Prev = ptr;
                newNode.Next = null; //尾节点指向空
            }
            else if (j == index) //插到中间
            {
                newNode = new DBNode<T>(item);
                d.Next = newNode;
                newNode.Prev = d;
                newNode.Next = ptr;
                ptr.Prev = newNode;
            }
        }

        return newNode;
    }

    /// <summary>
    /// 在链表最后插入node
    /// </summary>
    /// <param name="item"></param>
    public DBNode<T> AddLast(T item)
    {
        var newNode = new DBNode<T>(item);
        var ptr = new DBNode<T>();

        if (Head == null)
        {
            Head = newNode;
            return newNode;
        }

        ptr = Head; //如果head不为空，head就赋值给第一个节点
        while (ptr.Next != null)
        {
            ptr = ptr.Next;
        }

        ptr.Next = newNode;
        newNode.Prev = ptr;
        return newNode;
    }

    /// <summary>
    /// 移除指定位置的node
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T RemoveAt(int index)
    {
        if (IsEmpty() || index < 0)
        {
            LogTool.Log(string.Format("链表为空或者此节点不能进行连接"), LogEnum.NormalLog);
            return default(T);
        }

        var q = new DBNode<T>();
        if (0 == index)
        {
            q = Head;
            Head.Prev = null; //删除掉了第一个元素
            Head = Head.Next;
            return q.Data;
        }

        var ptr = Head;
        var j = 0;

        while (ptr.Next != null && j < index)
        {
            j++;
            q = ptr;
            ptr = ptr.Next;
        }

        if (index == j)
        {
            if (ptr.Next == null)
            {
                ptr.Prev.Next = null;
                ptr.Prev = null;
                return ptr.Data;
            }
            else
            {
                ptr.Next.Prev = q;
                q.Next = ptr.Next;
                return ptr.Data;
            }
        }
        else
        {
            LogTool.Log(string.Format("此节点不能进行连接"), LogEnum.NormalLog);
            return default(T);
        }
    }

    /// <summary>
    /// 根据元素的值查找索引
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public int IndexOf(T value)
    {
        if (IsEmpty())
        {
            LogTool.Log(string.Format("链表为空"), LogEnum.NormalLog);
            return -1;
        }

        var ptr = new DBNode<T>();
        ptr = Head;
        var index = 0;
        while (ptr.Next != null && !ptr.Data.Equals(value)) //查找value相同的item
        {
            ptr = ptr.Next;
            index++;
        }

        if (ptr.Data.Equals(value))
        {
            return index;
        }
        else
        {
            return -1;
        }
    }

    public bool Contains(T value)
    {
        return IndexOf(value) != -1;
    }

    /// <summary>
    /// 反转链表
    /// </summary>
    public void Reverse()
    {
        var tmpList = new DBLinkedList<T>();
        var ptr = this.Head;
        tmpList.Head = new DBNode<T>(ptr.Data);
        ptr = ptr.Next;

        while (ptr != null)
        {
            tmpList.AddBefore(ptr.Data, 0);
            ptr = ptr.Next;
        }

        this.Head = tmpList.Head;
        tmpList = null;
    }

    /// <summary>
    /// 根据Prev指针从最后一个节点开始倒叙遍历输出
    /// </summary>
    /// <returns></returns>
    public string ReverseByPrev()
    {
        //取得最后一个节点
        var tail = GetNodeAt(Count - 1);
        var sb = new StringBuilder();
        sb.Append(tail.Data.ToString() + ",");
        while (tail.Prev != null)
        {
            sb.Append(tail.Prev.Data + ",");
            tail = tail.Prev;
        }

        return sb.ToString().TrimEnd(',');
    }

    /// <summary>
    /// 根据元素位置得到指定的节点
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private DBNode<T> GetNodeAt(int index)
    {
        if (IsEmpty())
        {
            LogTool.Log(string.Format("链表为空"), LogEnum.NormalLog);
            return null;
        }

        var ptr = new DBNode<T>();
        ptr = this.Head;

        if (0 == index)
        {
            return ptr;
        }

        var j = 0;
        while (ptr.Next != null && j < index)
        {
            j++;
            ptr = ptr.Next;
        }

        if (j == index)
        {
            return ptr;
        }
        else
        {
            LogTool.Log(string.Format("节点并不存在"), LogEnum.NormalLog);
            return null;
        }
    }

    /// <summary>
    /// 最先节点数据
    /// </summary>
    /// <returns></returns>
    public DBNode<T> FirstData()
    {
        return this[0];
    }

    /// <summary>
    /// 最后节点数据
    /// </summary>
    /// <returns></returns>
    public DBNode<T> LastData()
    {
        return this[Count - 1];
    }

    /// <summary>
    /// 打印双向链表的每个元素
    /// </summary>
    public void Print()
    {
        var current = new DBNode<T>();
        current = Head;
        LogTool.Log(string.Format(current.Data + ","), LogEnum.NormalLog);
        while (current.Next != null)
        {
            LogTool.Log(string.Format(current.Next.Data + ","), LogEnum.NormalLog);
            current = current.Next;
        }
    }

    public List<T> ToList()
    {
        var list = new List<T>();
        var current = new DBNode<T>();
        current = Head;
        list.Add(current.Data);
        while (current.Next != null)
        {
            current = current.Next;
            list.Add(current.Data);
        }

        return list;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var ptr = this.Head;
        sb.Append(ptr.Data.ToString() + ",");
        while (ptr.Next != null)
        {
            sb.Append(ptr.Next.Data.ToString() + ",");
            ptr = ptr.Next;
        }

        return sb.ToString().TrimEnd(',');
    }

    /// <summary>
    /// 最近最少使用策略
    /// </summary>
    /// <param name="tmp"></param>
    /// <exception cref="NotImplementedException"></exception>
    public DBNode<T> LRUSort(T value)
    {
        var index = IndexOf(value);
        if (index > 0)
        {
            RemoveAt(index);
            AddBefore(value, 0);
        }
        else if (index == -1)
        {
            AddBefore(value, 0);
        }

        return head;
    }

    /// <summary>
    /// LRU清除多余的链表节点
    /// </summary>
    /// <returns>返回被清除的链表节点</returns>
    public List<T> LRUSortRemove()
    {
        var tmp = new List<T>();
        var node = GetNodeAt(capacity);
        var startNode = node;
        while (node.Next != null)
        {
            tmp.Add(node.Data);
            node = node.Next;
        }

        startNode.Next = null;
        return tmp;
    }

    /// <summary>
    /// 增加使用次数
    /// </summary>
    /// <param name="count"></param>
    private int AddUseCount(DBNode<T> node, int count = 1)
    {
        node.UseCount += 1;
        return node.UseCount;
    }

    /// <summary>
    /// 最近不经常使用(使用次数删除)策略  
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public DBNode<T> LFUSort(T value)
    {
        var index = IndexOf(value);
        if (index > 0)
        {
            var node = this[index];
            AddUseCount(node);
        }
        else if (index == -1)
        {
            if (!IsLFUbyCapacity)
            {
                AddBefore(value, 0);
            }
            else
            {
                //先删除最低引用个数点，在添加最新的点
                index = IndexOf(minUseNode.Data);
                RemoveAt(index);
                AddBefore(value, 0);
            }
        }

        return head;
    }
}

/// <summary>
/// 双向链表的节点
/// </summary>
/// <typeparam name="T">类型</typeparam>
public class DBNode<T>
{
    #region 字段

    private T data;
    private DBNode<T> preData;
    private DBNode<T> nextData;

    /// <summary>
    /// 使用的次数，默认为0开始
    /// </summary>
    private int useCount;

    #endregion

    #region 属性

    public int UseCount
    {
        set => useCount = value;
        get => useCount;
    }

    /// <summary>
    /// 节点的值
    /// </summary>
    public T Data
    {
        get => data;
        set => data = value;
    }

    /// <summary>
    /// 前驱节点
    /// </summary>
    public DBNode<T> Prev
    {
        get => preData;
        set => preData = value;
    }

    /// <summary>
    /// 后继结点
    /// </summary>
    public DBNode<T> Next
    {
        get => nextData;
        set => nextData = value;
    }

    #endregion

    #region 构造函数

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="preData"></param>
    /// <param name="nextData"></param>
    public DBNode(T data, DBNode<T> preData, DBNode<T> nextData)
    {
        this.data = data;
        this.preData = preData;
        this.nextData = nextData;
        useCount = 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="preData"></param>
    public DBNode(T data, DBNode<T> preData)
    {
        this.data = data;
        this.preData = preData;
        this.nextData = null; //结尾处的node
        useCount = 0;
    }

    public DBNode(DBNode<T> nextData)
    {
        //哨兵
        this.data = default(T);
        this.nextData = nextData;
        this.preData = null;
        useCount = 0;
    }

    public DBNode(T data)
    {
        this.data = data;
        this.preData = null;
        this.nextData = null;
        useCount = 0;
    }

    public DBNode()
    {
        //哨兵
        this.data = default(T);
        this.preData = null;
        this.nextData = null;
        useCount = 0;
    }

    #endregion
}