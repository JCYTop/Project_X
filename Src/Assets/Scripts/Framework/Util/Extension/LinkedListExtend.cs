using System;
using System.Collections.Generic;
using UnityEngine;

public static class LinkedListExtend
{
    /// <summary>
    /// LRU链表缓存
    /// </summary>
    /// <param name="list"></param>
    /// <param name="node"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static LinkedList<T> LRUSort<T>(this LinkedList<T> list, T node)
    {
        var contains = list.Contains(node);
        if (contains)
        {
            list.Remove(node);
            list.AddFirst(node);
        }
        else
        {
            list.AddFirst(node);
        }

        return list;
    }

    /// <summary>
    /// LRU链表缓存
    /// </summary>
    /// <param name="list"></param>
    /// <param name="node"></param>
    /// <param name="capacity">标准长度</param>
    /// <param name="multiple">长度倍数</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static (LinkedList<T>, List<T>) LRUSort<T>(this LinkedList<T> list, T node, int capacity, float multiple)
    {
        var removeList = new List<T>();
        var contains = list.Contains(node);
        if (contains)
        {
            list.Remove(node);
            list.AddFirst(node);
        }
        else
        {
            list.AddFirst(node);
        }

        var settingCount = (int) (capacity * multiple);
        if (settingCount < list.Count)
        {
            for (int i = 0; i < list.Count - settingCount; i++)
            {
                var lastNode = list.Last;
                removeList.Add(lastNode.Value);
                list.RemoveLast();
            }
        }

        return (list, removeList);
    }

    /// <summary>
    /// LRU链表缓存
    /// </summary>
    /// <param name="list"></param>
    /// <param name="capacity">标准长度</param>
    /// <param name="multiple">长度倍数</param>
    /// <param name="callback">多余数据处理</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static LinkedList<T> LRUSort<T>(this LinkedList<T> list, int capacity, float multiple, Action<List<T>> callback)
    {
        var removeList = new List<T>();
        var settingCount = (int) (capacity * multiple);
        if (settingCount < list.Count)
        {
            for (int i = 0; i < list.Count - settingCount; i++)
            {
                var lastNode = list.Last;
                removeList.Add(lastNode.Value);
                list.RemoveLast();
            }
        }

        callback(removeList);
        return list;
    }
}