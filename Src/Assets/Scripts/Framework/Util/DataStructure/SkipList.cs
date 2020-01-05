/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     SkipList
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/01/05 14:40:57
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections;
using System.Collections.Generic;

public class SkipList<TKey, TValue> : IDictionary<TKey, TValue> where TKey : IComparable
{
    private SkipListNode<TKey, TValue> head;
    private int count;

    public int Count
    {
        get => count;
    }

    public bool IsReadOnly { get; }

    public bool IsReadOnley
    {
        get => false;
    }

    public TValue this[TKey key]
    {
        get => get(key);
        set => Add(key, value);
    }

    public ICollection<TKey> Keys
    {
        get
        {
            var keys = new List<TKey>(count);
            walkEntries(n => keys.Add(n.Key));
            return keys;
        }
    }

    public ICollection<TValue> Values
    {
        get
        {
            var values = new List<TValue>(count);
            walkEntries(n => values.Add(n.Value));
            return values;
        }
    }

    public SkipList()
    {
        this.head = new SkipListNode<TKey, TValue>();
        count = 0;
    }

    public void Add(KeyValuePair<TKey, TValue> keyValue)
    {
        Add(keyValue.Key, keyValue.Value);
    }

    public void Add(TKey key, TValue value)
    {
        var found = Search(key, out var position);
        if (found)
        {
            position.Value = value;
        }
        else
        {
            count++;
            var newEntry = new SkipListNode<TKey, TValue>(key, value);
            //插入节点
            newEntry.Back = position;
            if (position.Forword != null)
            {
                newEntry.Forword = position.Forword;
            }

            position.Forword = newEntry;
            Promote(newEntry);
        }
    }

    public void Clear()
    {
        head = new SkipListNode<TKey, TValue>();
        count = 0;
    }

    public bool ContainsKey(TKey key)
    {
        return Search(key, out var notused);
    }

    public bool Contains(KeyValuePair<TKey, TValue> keyValue)
    {
        return ContainsKey(keyValue.Key);
    }

    public bool Remove(TKey key)
    {
        bool found = Search(key, out var position);
        if (!found)
        {
            return false;
        }
        else
        {
            var old = position;
            do
            {
                old.Back.Forword = old.Forword;
                if (old.Forword != null)
                {
                    old.Forword.Back = old.Back;
                }

                //找一下上面是否进行了删除
                old = old.Up;
            } while (old != null);

            count--;
            while (head.Forword == null)
            {
                head = head.Down;
            }

            return true;
        }
    }

    public bool Remove(KeyValuePair<TKey, TValue> keyValue)
    {
        return Remove(keyValue.Key);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        try
        {
            value = get(key);
            return true;
        }
        catch (KeyNotFoundException)
        {
            value = default(TValue);
            return false;
        }
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
    {
        if (array == null)
            throw new ArgumentNullException("array");
        if (index < 0)
            throw new ArgumentOutOfRangeException("index");
        if (array.IsReadOnly)
            throw new ArgumentException("The array argument is Read Only and new items cannot be added to it.");
        if (array.IsFixedSize && array.Length < count + index)
            throw new ArgumentException("The array argument does not have sufficient space for the SkipList entries.");

        int i = index;
        walkEntries(n => array[i++] = new KeyValuePair<TKey, TValue>(n.Key, n.Value));
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        var position = head;
        while (position.Down != null)
            position = position.Down;
        while (position.Forword != null)
        {
            position = position.Forword;
            yield return new KeyValuePair<TKey, TValue>(position.Key, position.Value);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private TValue get(TKey key)
    {
        var found = Search(key, out var position);
        if (!found)
        {
            throw new KeyNotFoundException("Unable to find entry with key \"" + key.ToString() + "\"");
        }

        return position.Value;
    }

    /// <summary>
    /// 遍历节点
    /// </summary>
    /// <param name="lambda"></param>
    private void walkEntries(Action<SkipListNode<TKey, TValue>> lambda)
    {
        var node = head;
        //下沉到最低层
        while (node.Down != null)
        {
            node = node.Down;
        }

        //遍历最底层
        while (node.Forword != null)
        {
            node = node.Forword;
            lambda(node);
        }
    }

    /// <summary>
    /// 内部搜索
    /// </summary>
    /// <param name="key"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    private bool Search(TKey key, out SkipListNode<TKey, TValue> position)
    {
        if (key == null)
            throw new ArgumentNullException("key");
        SkipListNode<TKey, TValue> current;
        position = current = head;

        while ((current.isFront || key.CompareTo(current.Key) >= 0) && (current.Forword != null || current.Down != null))
        {
            position = current;
            if (key.CompareTo(current.Key) == 0)
            {
                return true;
            }

            if (current.Forword == null || key.CompareTo(current.Forword.Key) < 0)
            {
                //该往下了
                if (current.Down == null)
                {
                    return false;
                }
                else
                {
                    current = current.Down;
                }
            }
            else
            {
                //继续往前
                current = current.Forword;
            }
        }

        //是寻找点或者最近点
        position = current;
        if (key.CompareTo(position.Key) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Promote(SkipListNode<TKey, TValue> node)
    {
        var up = node.Back;
        var last = node;
        //添加了几层
        for (var levels = this.levels(); levels > 0; levels--)
        {
            while (up.Up == null && !up.isFront)
            {
                up = up.Back;
            }

            if (up.isFront && up.Up == null)
            {
                up.Up = new SkipListNode<TKey, TValue>();
                head = up.Up;
            }

            up = up.Up;
            var newNode = new SkipListNode<TKey, TValue>(node.KeyValue);
            newNode.Forword = up.Forword;
            up.Forword = newNode;
            newNode.Down = last;
            newNode.Down.Up = newNode;
            last = newNode;
        }
    }

    /// <summary>
    /// The random number of level to promote a newly added node.
    /// </summary>
    /// <returns>the number of levels of promotion</returns>
    private int levels()
    {
        var generator = new Random();
        int levels = 0;
        while (generator.NextDouble() < 0.5)
            levels++;
        return levels;
    }
}

public class SkipListNode<TKey, TValue>
{
    /// <summary>
    /// 跳表节点指向
    /// </summary>
    public SkipListNode<TKey, TValue> Forword, Back, Up, Down;

    /// <summary>
    /// 节点内容值
    /// </summary>
    public SkipListKVPair<TKey, TValue> KeyValue;

    public bool isFront = false;

    #region 属性

    public TKey Key
    {
        get => KeyValue.Key;
    }

    public TValue Value
    {
        get => KeyValue.Value;
        set => KeyValue.Value = value;
    }

    #endregion

    public SkipListNode()
    {
        this.KeyValue = new SkipListKVPair<TKey, TValue>(default, default);
        this.isFront = true;
    }

    public SkipListNode(SkipListKVPair<TKey, TValue> keyValue)
    {
        this.KeyValue = keyValue;
    }

    public SkipListNode(TKey key, TValue value)
    {
        this.KeyValue = new SkipListKVPair<TKey, TValue>(key, value);
    }
}

/// <summary>
/// 跳表节点内容节点
/// </summary>
/// <typeparam name="Tkey"></typeparam>
/// <typeparam name="TValue"></typeparam>
public class SkipListKVPair<TKey, TValue>
{
    private TKey key;
    private TValue value;

    public TKey Key
    {
        get => key;
    }

    public TValue Value
    {
        get => value;
        set => this.value = value;
    }

    public SkipListKVPair(TKey key, TValue value)
    {
        this.key = key;
        this.value = value;
    }
}