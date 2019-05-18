using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BinaryHeapSortMode
{
    Min = 0,
    Max = 1,
}

public enum BinaryHeapBuildMode
{
    kNLog = 1,
    kN = 2,
}

public class BinaryHeap<T> where T : IBinaryHeapElement
{
    protected T[] Array;
    protected float GrowthFactor = 1.6f;
    protected int LastChildIndex; //最后子节点的位置
    protected BinaryHeapSortMode SortMode;

    public BinaryHeap(int minSize, BinaryHeapSortMode sortMode = BinaryHeapSortMode.Min)
    {
        SortMode = sortMode;
        Array = new T[minSize];
        LastChildIndex = 0;
    }

    public BinaryHeap(T[] dataArray, BinaryHeapSortMode sortMode = BinaryHeapSortMode.Min)
    {
        SortMode = sortMode;
        int minSize = 10;
        if (dataArray != null)
        {
            minSize = dataArray.Length + 1;
        }
        Array = new T[minSize];
        LastChildIndex = 0;
        Insert(dataArray, BinaryHeapBuildMode.kN);
    }

    #region 公开方法

    #region 清空
    public void Clear()
    {
        Array = new T[10];
        LastChildIndex = 0;
    }
    #endregion

    #region 插入
    public void Insert(T[] dataArray, BinaryHeapBuildMode buildMode)
    {
        if (dataArray == null)
        {
            throw new NullReferenceException("BinaryHeap Not Support Insert Null Object");
        }
        int totalLength = LastChildIndex + dataArray.Length + 1;
        if (Array.Length < totalLength)
        {
            ResizeArray(totalLength);
        }
        if (buildMode == BinaryHeapBuildMode.kNLog)
        {
            //方式1:直接添加，每次添加都会上浮
            for (int i = 0; i < dataArray.Length; ++i)
            {
                Insert(dataArray[i]);
            }
        }
        else
        {
            //方式2:先添加完，然后排序(数量比较大的情况下会快一些)
            for (int i = 0; i < dataArray.Length; ++i)
            {
                Array[++LastChildIndex] = dataArray[i];
            }
            SortAsCurrentMode();
        }
    }

    public void Insert(T element)
    {
        if (element == null)
        {
            throw new NullReferenceException("BinaryHeap Not Support Insert Null Object");
        }
        int index = ++LastChildIndex;
        if (index == Array.Length)
        {
            ResizeArray();
        }
        Array[index] = element;
        ProcolateUp(index);
    }
    #endregion

    #region 弹出
    public T Pop()
    {
        if (LastChildIndex < 1)
        {
            return default(T);
        }
        T result = Array[1];
        Array[1] = Array[LastChildIndex--];
        ProcolateDown(1);
        return result;
    }

    public T GetTop()
    {
        if (LastChildIndex < 1)
        {
            return default(T);
        }
        return Array[1];
    }
    #endregion

    #region 重新排序
    public void Sort(BinaryHeapSortMode sortMode)
    {
        if (SortMode == sortMode)
        {
            return;
        }
        SortMode = sortMode;
        SortAsCurrentMode();
    }

    public void RebuildAtIndex(int index)
    {
        if (index > LastChildIndex)
        {
            return;
        }
        T element = Array[index];
        int parentIndex = index >> 1;
        //首先找父节点，是否比父节点小，如果满足则上浮,不满足下沉
        if (parentIndex > 0)
        {
            if (SortMode == BinaryHeapSortMode.Min)
            {
                if (element.SortScore < Array[parentIndex].SortScore)
                {
                    ProcolateUp(index);
                }
                else
                {
                    ProcolateDown(index);
                }
            }
            else
            {
                if (element.SortScore > Array[parentIndex].SortScore)
                {
                    ProcolateUp(index);
                }
                else
                {
                    ProcolateDown(index);
                }
            }
        }
        else
        {
            ProcolateDown(index);
        }
    }
    #endregion

    #region 指定位置删除
    public void RemoveAt(int index)
    {
        if (index > LastChildIndex || index < 1)
        {
            return;
        }
        if (index == LastChildIndex)
        {
            --LastChildIndex;
            Array[index] = default(T);
            return;
        }
        Array[index] = Array[LastChildIndex--];
        Array[index].HeapIndex = index;
        RebuildAtIndex(index);
    }
    #endregion

    #region 索引查找
    /// <summary>
    /// 这个索引和大小排序之间没有任何关系
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T GetElement(int index)
    {
        if (index > LastChildIndex)
        {
            return default(T);
        }
        return Array[index];
    }
    #endregion

    #region 判定辅助
    public bool HasValue()
    {
        return LastChildIndex > 0;
    }
    #endregion

    #endregion

    private void ResizeArray(int newSize = -1)
    {
        if (newSize < 0)
        {
            newSize = Math.Max(Array.Length + 4, (int)Math.Round(Array.Length * GrowthFactor));
        }
        if (newSize > 1 << 30)
        {
            throw new System.Exception("Binary Heap Size really large (2^18). A heap size this large is probably the cause of pathfinding running in an infinite loop. " + "\nRemove this check (in BinaryHeap.cs) if you are sure that it is not caused by a bug");
        }
        T[] tmp = new T[newSize];
        for (int i = 0; i < Array.Length; i++)
        {
            tmp[i] = Array[i];
        }
        Array = tmp;
    }

    private void SortAsCurrentMode()
    {
        int startChild = LastChildIndex >> 1;
        for (int i = startChild; i > 0; --i)
        {
            ProcolateDown(i);
        }
    }

    #region 排序核心
    /// <summary>
    /// 上浮:空穴思想
    /// </summary>
    /// <param name="index"></param>
    private void ProcolateUp(int index)
    {
        T element = Array[index];
        if (element == null)
        {
            return;
        }
        float sortScore = element.SortScore;
        int parentIndex = index >> 1;
        if (SortMode == BinaryHeapSortMode.Min)
        {
            while (parentIndex >= 1 && sortScore < Array[parentIndex].SortScore)
            {
                Array[index] = Array[parentIndex];
                Array[index].HeapIndex = index;
                index = parentIndex;
                parentIndex = index >> 1;
            }
        }
        else
        {
            while (parentIndex >= 1 && sortScore > Array[parentIndex].SortScore)
            {
                Array[index] = Array[parentIndex];
                Array[index].HeapIndex = index;
                index = parentIndex;
                parentIndex = index >> 1;
            }
        }
        Array[index] = element;
        Array[index].HeapIndex = index;
    }

    /// <summary>
    /// 置顶下沉
    /// </summary>
    /// <param name="index"></param>
    private void ProcolateDown(int index)
    {
        T element = Array[index];
        if (element == null)
        {
            return;
        }
        int childIndex = index << 1;
        if (SortMode == BinaryHeapSortMode.Min)
        {
            while (childIndex <= LastChildIndex)
            {
                if (childIndex != LastChildIndex)
                {
                    if (Array[childIndex + 1].SortScore < Array[childIndex].SortScore)
                    {
                        childIndex = childIndex + 1;
                    }
                }
                if (Array[childIndex].SortScore < element.SortScore)
                {
                    Array[index] = Array[childIndex];
                    Array[index].HeapIndex = index;
                }
                else
                {
                    break;
                }
                index = childIndex;
                childIndex = index << 1;
            }
        }
        else
        {
            while (childIndex <= LastChildIndex)
            {
                if (childIndex != LastChildIndex)
                {
                    if (Array[childIndex + 1].SortScore > Array[childIndex].SortScore)
                    {
                        childIndex = childIndex + 1;
                    }
                }
                if (Array[childIndex].SortScore > element.SortScore)
                {
                    Array[index] = Array[childIndex];
                    Array[index].HeapIndex = index;
                }
                else
                {
                    break;
                }
                index = childIndex;
                childIndex = index << 1;
            }
        }
        Array[index] = element;
        Array[index].HeapIndex = index;
    }
    #endregion
}