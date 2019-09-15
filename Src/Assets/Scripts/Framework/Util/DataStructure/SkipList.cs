/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     SkipList
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/08/25 23:06:50
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;

/// <summary>
/// C#实现跳表
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class SkipList<T> : IComparer<T>
{
    private int maxLevel = 1 << 5;

    /// <summary>
    /// 带头链表
    /// </summary>
    private SkipNode<T> head = new SkipNode<T>();

    /// <summary>
    /// 高度
    /// </summary>
    private int levelCount = 1;

    public SkipNode<T> Find(T value)
    {
        var p = head;
        for (int i = levelCount - 1; i >= 0; i--)
        {
            while (p.Forwards[i] != null && Compare(p.Forwards[i].Data, value) == -1) //小于
            {
                p = p.Forwards[i];
            }
        }

        if (p.Forwards[0] != null && Compare(p.Forwards[0].Data, value) == 0) //等于
        {
            return p.Forwards[0];
        }
        else
        {
            return null;
        }
    }

    public void Insert(T value)
    {
        var level = RandomLevel();
        var newNode = new SkipNode<T>();
        newNode.Data = value;
        newNode.MaxLevel = level;
        var update = new SkipNode<T>[level];
        for (int i = 0; i < level; i++)
        {
            update[i] = head;
        }

        //找到与目标节点最小最相邻的节点
        var ptr = head;
        for (int i = level - 1; i >= 0; i--)
        {
            while (ptr.Forwards[i] != null && Compare(ptr.Forwards[i].Data, value) == -1)
            {
                ptr = ptr.Forwards[i];
            }

            update[i] = ptr; //这里替换了初始化节点
        }

        //链接上之后的节点,链表常规操作
        for (int i = 0; i < level; i++)
        {
            newNode.Forwards[i] = update[i].Forwards[i];
            update[i].Forwards[i] = newNode;
        }

        if (levelCount < level) levelCount = level;
    }

    /// <summary>
    /// 删除节点
    /// </summary>
    /// <param name="value"></param>
    public void Delete(T value)
    {
        var update = new SkipNode<T> [levelCount];
        var ptr = head;
        for (int i = levelCount - 1; i >= 0; i--)
        {
            while (ptr.Forwards[i] != null && Compare(ptr.Forwards[i].Data, value) == -1)
            {
                ptr = ptr.Forwards[i];
            }

            update[i] = ptr; //这里替换了初始化节点
        }

        if (ptr.Forwards[0] != null && Compare(ptr.Forwards[0].Data, value) == 0)
        {
            for (int i = levelCount - 1; i >= 0; --i)
            {
                if (update[i].Forwards[i] != null && Compare(ptr.Forwards[0].Data, value) == 0)
                {
                    update[i].Forwards[i] = update[i].Forwards[i].Forwards[i];
                }
            }
        }
    }

    public void PrintAll()
    {
        var ptr = head;
        while (ptr.Forwards[0] != null)
        {
            LogUtil.Log(ptr.Forwards[0].Data + " ");
            ptr = ptr.Forwards[0];
        }
    }

    private int RandomLevel()
    {
        var random = new Random();
        var level = 1;
        for (int i = 1; i < maxLevel; ++i)
        {
            if (random.Next() % 2 == 1)
            {
                level++;
            }
        }

        return level;
    }

    public abstract int Compare(T x, T y);
}

public class SkipNode<T>
{
    public T Data;
    public int MaxLevel = 0;

    /// <summary>
    /// 与高度结合使用
    /// 不同的index
    /// 代表不同的层之后的引用关联
    /// </summary>
    public SkipNode<T>[] Forwards = new SkipNode<T>[1 << 5];
}