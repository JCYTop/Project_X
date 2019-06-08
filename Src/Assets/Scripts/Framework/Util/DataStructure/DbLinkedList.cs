/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     DbLinkList
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/08 22:05:37
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Text;

/// <summary>
/// 双向链表
/// </summary>
public class DbLinkedList<T>
{
    private DbNode<T> head;

    public DbNode<T> Head
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
                length++;
                ptr = ptr.Next;
            }

            return length;
        }
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    public DbLinkedList()
    {
        Head = null;
    }

    /// <summary>
    /// 索引器
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T this[int index]
    {
        get { return GetItemAt(index); }
    }

    private T GetItemAt(int index)
    {
        //判空
        if (IsEmpty())
        {
            LogUtil.Log(string.Format("链表为空"), LogType.NormalLog);
            return default(T);
        }

        var ptr = new DbNode<T>();
        ptr = Head;

        // 如果是第一个node
        if (0 == index)
        {
            return ptr.Data;
        }

        var j = 0;
        while (ptr.Next != null && j < index)
        {
            j++;
            ptr = ptr.Next;
            if (j == index)
            {
                return ptr.Data;
            }
        }

        LogUtil.Log(string.Format("节点并不存在"), LogType.NormalLog);
        return default(T);
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
    public void AddAfter(T item, int index)
    {
        if (IsEmpty() || index < 0)
        {
            LogUtil.Log(string.Format("链表为空或者此节点不能进行连接"), LogType.NormalLog);
            return;
        }

        if (index == 0) //在头之后插入元素
        {
            var newNode = new DbNode<T>(item);
            newNode.Next = Head.Next;
            Head.Next.Prev = newNode;
            Head.Next = newNode;
            newNode.Prev = Head;
            return;
        }

        var ptr = Head; //p指向head
        var j = 0;

        while (ptr != null && j < index)
        {
            ptr = ptr.Next;
            j++;
            if (j == index)
            {
                var newNode = new DbNode<T>(item);
                newNode.Next = null;
                if (ptr.Next != null)
                {
                    newNode.Next = ptr.Next;
                    ptr.Next.Prev = newNode;
                }

                newNode.Prev = ptr;
                ptr.Next = newNode;
                return;
            }
            else
            {
                LogUtil.Log(string.Format("此节点不能进行连接"), LogType.NormalLog);
                return;
            }
        }
    }

    /// <summary>
    /// 在位置i前插入node T
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    public void AddBefore(T item, int index)
    {
        if (IsEmpty() || index < 0)
        {
            LogUtil.Log(string.Format("链表为空或者此节点不能进行连接", LogType.NormalLog));
            return;
        }

        if (index == 0) //在头之前插入元素
        {
            var newNode = new DbNode<T>(item);
            newNode.Next = Head; //把头改成第二个元素
            Head.Prev = newNode;
            Head = newNode; //把新元素设置为头
            return;
        }

        var ptr = Head;
        var d = new DbNode<T>();
        var j = 0;

        while (ptr.Next != null && j < index)
        {
            d = ptr; //把d设置为头
            ptr = ptr.Next;
            j++;
            if (ptr.Next == null) //在最后节点后插入，即AddLast
            {
                var newNode = new DbNode<T>(item);
                ptr.Next = newNode;
                newNode.Prev = ptr;
                newNode.Next = null; //尾节点指向空
            }
            else if (j == index) //插到中间
            {
                var newNode = new DbNode<T>(item);
                d.Next = newNode;
                newNode.Prev = d;
                newNode.Next = ptr;
                ptr.Prev = newNode;
            }
        }
    }

    /// <summary>
    /// 在链表最后插入node
    /// </summary>
    /// <param name="item"></param>
    public void AddLast(T item)
    {
        var newNode = new DbNode<T>(item);
        var ptr = new DbNode<T>();

        if (Head == null)
        {
            Head = newNode;
            return;
        }

        ptr = Head; //如果head不为空，head就赋值给第一个节点
        while (ptr.Next != null)
        {
            ptr = ptr.Next;
        }

        ptr.Next = newNode;
        newNode.Prev = ptr;
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
            LogUtil.Log(string.Format("链表为空或者此节点不能进行连接"), LogType.NormalLog);
            return default(T);
        }

        var q = new DbNode<T>();
        if (0 == index)
        {
            q = Head;
            Head = Head.Next;
            Head.Prev = null; //删除掉了第一个元素
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
            ptr.Next.Prev = q;
            q.Next = ptr.Next;
            return ptr.Data;
        }
        else
        {
            LogUtil.Log(string.Format("此节点不能进行连接"), LogType.NormalLog);
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
            LogUtil.Log(string.Format("链表为空"), LogType.NormalLog);
            return -1;
        }

        var ptr = new DbNode<T>();
        ptr = Head;
        var index = 0;
        while (ptr.Next != null && !ptr.Data.Equals(value)) //查找value相同的item
        {
            ptr = ptr.Next;
            index++;
        }

        return index;
    }

    /// <summary>
    /// 反转链表
    /// </summary>
    public void Reverse()
    {
        var tmpList = new DbLinkedList<T>();
        var ptr = this.Head;
        tmpList.Head = new DbNode<T>(ptr.Data);
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
    private DbNode<T> GetNodeAt(int index)
    {
        if (IsEmpty())
        {
            LogUtil.Log(string.Format("链表为空"), LogType.NormalLog);
            return null;
        }

        var ptr = new DbNode<T>();
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
            LogUtil.Log(string.Format("节点并不存在"), LogType.NormalLog);
            return null;
        }
    }

    /// <summary>
    /// 最先节点数据
    /// </summary>
    /// <returns></returns>
    public T FirstData()
    {
        return GetItemAt(0);
    }

    /// <summary>
    /// 最后节点数据
    /// </summary>
    /// <returns></returns>
    public T LastData()
    {
        return GetItemAt(Count - 1);
    }

    /// <summary>
    /// 打印双向链表的每个元素
    /// </summary>
    public void Print()
    {
        var current = new DbNode<T>();
        current = this.Head;
        LogUtil.Log(string.Format(current.Data + ","), LogType.NormalLog);
        while (current.Next != null)
        {
            LogUtil.Log(string.Format(current.Next.Data + ","), LogType.NormalLog);
            current = current.Next;
        }
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
}

/// <summary>
/// 双向链表的节点
/// </summary>
/// <typeparam name="T">类型</typeparam>
public class DbNode<T>
{
    #region 字段

    private T data;
    private DbNode<T> preData;
    private DbNode<T> nextData;

    #endregion

    #region 属性

    /// <summary>
    /// 节点的值
    /// </summary>
    public T Data
    {
        get { return data; }
        set { data = value; }
    }

    /// <summary>
    /// 前驱节点
    /// </summary>
    public DbNode<T> Prev
    {
        get { return preData; }
        set { preData = value; }
    }

    /// <summary>
    /// 后继结点
    /// </summary>
    public DbNode<T> Next
    {
        get { return nextData; }
        set { nextData = value; }
    }

    #endregion

    #region 构造函数

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="preData"></param>
    /// <param name="nextData"></param>
    public DbNode(T data, DbNode<T> preData, DbNode<T> nextData)
    {
        this.data = data;
        this.preData = preData;
        this.nextData = nextData;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="preData"></param>
    public DbNode(T data, DbNode<T> preData)
    {
        this.data = data;
        this.preData = preData;
        this.nextData = null; //结尾处的node
    }

    public DbNode(DbNode<T> nextData)
    {
        //哨兵
        this.data = default(T);
        this.nextData = nextData;
        this.preData = null;
    }

    public DbNode(T data)
    {
        this.data = data;
        this.preData = null;
        this.nextData = null;
    }

    public DbNode()
    {
        //哨兵
        this.data = default(T);
        this.preData = null;
        this.nextData = null;
    }

    #endregion
}