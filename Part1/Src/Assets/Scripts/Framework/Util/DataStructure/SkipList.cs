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

/// <summary>
/// This is an implementation of skiplists, a data structure concept
/// developed by William Pugh.
/// http://citeseer.ist.psu.edu/viewdoc/summary?doi=10.1.1.15.9072
/// (To aid my understanding I also watched an online lecture which forms the basis for this implementation : http://videolectures.net/mit6046jf05_demaine_lec12/ )
/// copy website : https://github.com/kencausey/SkipList/blob/master/SkipList.cs
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
public class SkipList<TKey, TValue> : IDictionary<TKey, TValue> where TKey : IComparable
{
    private SkipListNode<TKey, TValue> head;
    private int count;

    /// <summary>
    /// A read-only value representing the current number of items in the
    /// map.
    /// </summary>
    public int Count
    {
        get { return count; }
    }

    /// <summary>
    /// Skiplists are always read/write structures in this implementation.
    /// </summary>
    public bool IsReadOnly
    {
        get { return false; }
    }

    /// <summary>
    /// This implementation supports indexed [] reference for both reading
    /// and writing entries of the map.  Note that if you set the value
    /// for an existing key in the map the current value will be
    /// overwritten.
    /// </summary>
    /// <param name="key">The IComparable key reference</param>
    /// <returns>the value</returns>
    public TValue this[TKey key]
    {
        get { return Get(key); }
        set { Add(key, value); }
    }

    /// <summary>
    /// Returns a collection (List) representing all the keys in the map in
    /// key-sorted order.
    /// </summary>
    public ICollection<TKey> Keys
    {
        get
        {
            var keys = new List<TKey>(count);
            WalkEntries(n => keys.Add(n.Key));
            return keys;
        }
    }

    /// <summary>
    /// Returns a collection (List) representing all the value in the map
    /// in key-sorted order.
    /// </summary>
    public ICollection<TValue> Values
    {
        get
        {
            var values = new List<TValue>(count);
            WalkEntries(n => values.Add(n.Value));
            return values;
        }
    }

    private struct SkipListKVPair<TNKey, TNValue>
    {
        private TNKey key;

        public TNKey Key
        {
            get { return key; }
        }

        public TNValue Value;

        public SkipListKVPair(TNKey key, TNValue value)
        {
            this.key = key;
            this.Value = value;
        }
    }

    private class SkipListNode<TNKey, TNValue>
    {
        public SkipListNode<TNKey, TNValue> Forward, Back, Up, Down;
        public SkipListKVPair<TNKey, TNValue> KeyValue;
        public bool IsFront = false;

        public TNKey Key
        {
            get { return KeyValue.Key; }
        }

        public TNValue Value
        {
            get { return KeyValue.Value; }
            set { KeyValue.Value = value; }
        }

        public SkipListNode()
        {
            this.KeyValue = new SkipListKVPair<TNKey, TNValue>(default(TNKey), default(TNValue));
            this.IsFront = true;
        }

        public SkipListNode(SkipListKVPair<TNKey, TNValue> keyValue)
        {
            this.KeyValue = keyValue;
        }

        public SkipListNode(TNKey key, TNValue value)
        {
            this.KeyValue = new SkipListKVPair<TNKey, TNValue>(key, value);
        }
    }

    /// <summary>
    /// Creates and returns a new empty skiplist.
    /// </summary>
    public SkipList()
    {
        this.head = new SkipListNode<TKey, TValue>();
        count = 0;
    }

    /// <summary>
    /// This is an alternative (to indexing) interface to add and modify
    /// existing values in the map.
    /// </summary>
    /// <param name="key">The IComparable key</param>
    /// <param name="value">The new value</param>
    public void Add(TKey key, TValue value)
    {
        // Duh, we have to be able to tell when no key is found from when one is found
        // and if none is found have a reference to the last place searched....  return
        // a bool and use an out value?
        bool found = Search(key, out var position);
        if (found)
            position.Value = value;
        else
        {
            // In this scenario position, rather than the value we searched
            // for is the value immediately previous to where it should be inserted.
            var newEntry = new SkipListNode<TKey, TValue>((TKey) key, value);
            count++;
            newEntry.Back = position;
            if (position.Forward != null)
                newEntry.Forward = position.Forward;
            position.Forward = newEntry;
            Promote(newEntry);
        }
    }

    /// <summary>
    /// Add an entry using a System.Collections.Generic.KeyValuePair<>.
    /// </summary>
    /// <param name="keyValue">The KeyValuePair<> to add.  The key must be
    /// an IComparable.  If a matching entry already exists the value will
    /// be updated to the value specified in the KeyValuePair.</param>
    public void Add(KeyValuePair<TKey, TValue> keyValue)
    {
        Add(keyValue.Key, keyValue.Value);
    }

    /// <summary>
    /// Empty the skiplist.
    /// </summary>
    public void Clear()
    {
        head = new SkipListNode<TKey, TValue>();
        count = 0;
        // Must more be done to ensure that all references are released?
    }

    /// <summary>
    /// Test for the existence of an entry with the given key.
    /// </summary>
    /// <param name="key">The IComparable key to search for.</param>
    /// <returns>a bool indicating whether the map contains an entry with
    /// the specified key</returns>
    public bool ContainsKey(TKey key)
    {
        return Search(key, out var notused);
    }

    /// <summary>
    /// Test for the existence of an entry with a matching key from a
    /// System.Collections.Generic.KeyValuePair<>.  Note that the value from
    /// the KeyValuePair is ignored and only the key is used in this test.
    /// </summary>
    /// <param name="keyValue">The KeyValuePair<> for which to search the
    /// map, note that only the IComparable key is used.</param>
    /// <returns>a bool indicating whether or not a matching entry exists
    /// in the map</returns>
    public bool Contains(KeyValuePair<TKey, TValue> keyValue)
    {
        return ContainsKey(keyValue.Key);
    }

    /// <summary>
    /// Remove an entry in the map matching the specified key.
    /// </summary>
    /// <param name="key">The IComparable key to search for.  If found the
    /// matching entry is removed from the map.</param>
    /// <returns>a bool indicating whether the specified key was found in
    /// the map and the entry removed</returns>
    public bool Remove(TKey key)
    {
        bool found = Search(key, out var position);
        if (!found)
            return false;
        else
        {
            var old = position;
            do
            {
                old.Back.Forward = old.Forward;
                if (old.Forward != null)
                    old.Forward.Back = old.Back;
                old = old.Up;
            } while (old != null);

            count--;
            // Clean up rows with only a head remaining.
            while (head.Forward == null)
            {
                head = head.Down;
            }

            return true;
        }
    }

    /// <summary>
    /// Remove an entry in the map matching the key from the specified
    /// System.Collections.Generic.KeyValuePair<>.  Only the key part of the
    /// KeyValuePair is used in the search.  Note that the value part of
    /// the KeyValuePair is not used.
    /// </summary>
    /// <param name="key">A KeyValuePair<> containing the IComparable key to
    /// search for.  If found the matching entry is removed from the map.</param>
    /// <returns>a bool indicating whether the a matching entry was found
    /// in the map and removed</returns>
    public bool Remove(KeyValuePair<TKey, TValue> keyValue)
    {
        return Remove(keyValue.Key);
    }

    /// <summary>
    /// Allows searching for a matching entry by IComparable key returning
    /// the value, if found as an out value.  Also returns as the standard
    /// return value whether or not a matching entry was found.
    /// </summary>
    /// <param name="key">IComparable key to search for</param>
    /// <param name="value">An out value specifying the value of the entry
    /// if found, otherwise the default is returned.</param>
    /// <returns>a bool indicating whether or not a matching entry was
    /// found</returns>
    public bool TryGetValue(TKey key, out TValue value)
    {
        try
        {
            value = Get(key);
            return true;
        }
        catch (KeyNotFoundException)
        {
            value = default(TValue);
            return false;
        }
    }

    /// <summary>
    /// Copies all entries in the skiplist to the provided System.Array of
    /// System.Collection.Generic.KeyValuePair<>s starting at the given
    /// index.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">Thrown if the array
    /// provided is null.</exception>
    /// <exception cref="System.ArgumentException">Thrown if the array is
    /// read-only, or does not have sufficient space after the specified
    /// index for the entries in the skiplist</exception>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown if the
    /// specified index is less than zero.</exception>
    /// <param name="array">The array of KeyValuePair<>s in which to copy
    /// the skiplist entries.  The array must have sufficient space after
    /// the specified index to hold all entries in the skiplist.</param>
    /// <param name="index">The index of the array at which to start
    /// copying the entries.</param>
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
        var i = index;
        WalkEntries(n => array[i++] = new KeyValuePair<TKey, TValue>(n.Key, n.Value));
    }

    /// <summary>
    /// Provides a System.Collections.Generic.IEnumerator<> interface to a
    /// collection of System.Collection.Generic.KeyValuePair<>s
    /// representing the entries in the map in key-sorted order.
    /// NOTE: The enumerator returned enumerates over internally used
    /// values, modifying the value is fine but do not modify the key
    /// because that would invalidate the internal structural assumptions.
    /// </summary>
    /// <returns>An IEnumerator<> of the map entries in key-sorted order</returns>
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        var position = head;
        while (position.Down != null)
            position = position.Down;
        while (position.Forward != null)
        {
            position = position.Forward;
            yield return new KeyValuePair<TKey, TValue>(position.Key, position.Value);
        }
    }

    /// <summary>
    /// Provides a System.Collections.IEnumerator interface to a collection
    /// of System.Collection.Generic.KeyValuePair<>s representing the
    /// entries in the map in key-sorted order.
    /// NOTE: The enumerator returned enumerates over internally used
    /// values, modifying the value is fine but do not modify the key
    /// because that would invalidate the internal structural assumptions.
    /// </summary>
    /// <returns>An IEnumerator of the map entries in key-sorted order</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator) GetEnumerator();
    }

    /// <summary>
    /// Retrieve the value from the matching entry in the map to the given
    ///   IComparable key.
    /// </summary>
    /// <param name="key">The IComparable key to search for</param>
    /// <returns>The value found</returns>
    /// <exception cref="System.Collections.Generic.KeyNotFoundException">
    /// Thrown if no entry is found with the given key</exception>
    private TValue Get(TKey key)
    {
        bool found = Search(key, out var position);
        if (!found)
            throw new KeyNotFoundException("Unable to find entry with key \"" + key.ToString() + "\"");
        return position.Value;
    }

    /// <summary>
    /// Takes an Action that accepts one argument representing a
    /// SkipListNode in the map and performs the given action on every entry
    /// in the map in key-sorted order.
    /// </summary>
    /// <param name="lambda">A System.Action(T) that accepts one parameter
    /// which will be each unique entry as a SkipListNode</param>
    private void WalkEntries(Action<SkipListNode<TKey, TValue>> lambda)
    {
        var node = head;
        while (node.Down != null)
            node = node.Down;
        while (node.Forward != null)
        {
            node = node.Forward;
            lambda(node);
        }
    }

    /// <summary>
    /// The core search algorithm:  Returns a SkipListPair of SkipListNodes
    /// representing the matching entry with the given IComparable key and
    /// the immediately preceding entry in the map on the fastlane in which
    /// the entry was found.
    /// </summary>
    /// <param name="key">The IComparable key for which to search</param>
    /// <param name="position">Either the matching node if the true is
    /// returned as the return value, or, if false is returned, the value
    /// just before where the new value could be inserted.</param>
    /// <returns>Whether or not the search for value was found.</returns>
    private bool Search(TKey key, out SkipListNode<TKey, TValue> position)
    {
        if (key == null)
            throw new ArgumentNullException("key");
        SkipListNode<TKey, TValue> current;
        position = current = head;
        while ((current.IsFront || key.CompareTo(current.Key) >= 0) && (current.Forward != null || current.Down != null))
        {
            position = current;
            if (key.CompareTo(current.Key) == 0)
                return true;
            if (current.Forward == null || key.CompareTo(current.Forward.Key) < 0)
            {
                if (current.Down == null)
                    return false;
                else
                    current = current.Down;
            }
            else
                current = current.Forward;
        }

        position = current;
        // If the matching value is found in the last position of the last row, we could end up here with a match.
        if (key.CompareTo(position.Key) == 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// This algorithm promotes the newly added node on a probabilistic
    /// basis.
    /// </summary>
    /// <param name="node">The root node (initially added node added to the
    /// bottom, primary, row) to consider promoting.</param>
    private void Promote(SkipListNode<TKey, TValue> node)
    {
        // up represents our search for the value just prior to the newly
        // added value in the next row to which the newly added value
        // should be promoted.
        // last represents the most recently added node, starting with the
        // newly created node.
        var up = node.Back;
        var last = node;
        for (int levels = this.Levels(); levels > 0; levels--)
        {
            // Find the next node back that links to next row up.
            // If we find our way back to the head of the row and there is
            // no link up then that means it is time to create a new row.
            while (up.Up == null && !up.IsFront)
                up = up.Back;
            if (up.IsFront && up.Up == null)
            {
                // As mentioned above is this is the front of the row and
                // there is no link up then we need to start a new row and
                // update the head to ensure it always points to the start
                // of the topmost row.
                up.Up = new SkipListNode<TKey, TValue>();
                head = up.Up;
            }

            up = up.Up;
            // At this point up should represent the value in the next row
            // up immediately prior to where the new node should be
            // promoted.  If this node has been promoted to a previously
            // unreached level, then up will be the head of the new row.
            var newNode = new SkipListNode<TKey, TValue>(node.KeyValue);
            newNode.Forward = up.Forward;
            up.Forward = newNode;
            // Remember last starts as the brand new node but should be
            // updated to always point to the representative node in
            // the previous row.
            newNode.Down = last;
            newNode.Down.Up = newNode;
            last = newNode;
        }
    }

    /// <summary>
    /// The random number of level to promote a newly added node.
    /// </summary>
    /// <returns>the number of levels of promotion</returns>
    private int Levels()
    {
        var generator = new Random();
        var levels = 0;
        while (generator.NextDouble() < 0.5)
            levels++;
        return levels;
    }
}