using System;
using System.Collections;
using System.Collections.Generic;

namespace Base.Heap
{
    /// <summary>
    /// 数组化Heap
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Heap<T> : ICollection<T> where T : IComparable<T>
    {
        public List<T> Data { get; private set; }

        /// <summary>
        /// 当前数量
        /// </summary>
        public int Count
        {
            get { return Data.Count; }
        }

        /// <summary>
        /// 是否为只读
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// 堆的类型,false为大顶堆,true为小顶堆
        /// </summary>
        public bool Type { get; private set; } = true;

        public Heap(bool type = true)
        {
            Data = new List<T>();
            Type = type;
        }

        public Heap(T[] data, bool type = true)
        {
            Type = type;
            Data = new List<T>(data);
            //进行堆化数据
            for (int i = Data.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        public Heap(IEnumerable<T> collection, bool type = true)
        {
            Type = type;
            Data = new List<T>(collection);
            //进行堆化数据
            for (int i = Data.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        public void Add(T item)
        {
            Data.Add(item);
            var i = Count - 1;
            while (i > 0)
            {
                var intOffset = 0;
                if (i % 2 > 0)
                {
                    intOffset = 0;
                }
                else if (i % 2 == 0)
                {
                    intOffset = -1;
                }

                if (Data[i].CompareTo(Data[i / 2 + intOffset]) > 0 == Type)
                {
                    Swap(i, i / 2 + intOffset);
                    i = i / 2 + intOffset;
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 交换Swap
        /// </summary>
        /// <param name="item1">下标index1</param>
        /// <param name="item2">下标index2</param>
        private void Swap(int index1, int index2)
        {
            var tmpData = Data[index1];
            Data[index1] = Data[index2];
            Data[index2] = tmpData;
        }

        /// <summary>
        /// 删除最顶部元素
        /// </summary>
        /// <returns></returns>
        public void RemoveTop()
        {
            if (Count == 0)
            {
                throw new NullReferenceException("Heap中不存才数据");
            }

            //最后一个赋值到第一个数据
            Data[0] = Data[Count - 1];
            Data.Remove(Data[Count - 1]);
            //自顶向下堆化数据
            Heapify(0);
        }

        /// <summary>
        /// 堆关系交换
        /// </summary>
        /// <param name="index"></param>
        private void Heapify(int index)
        {
            while (true)
            {
                var pos = index;
                if (index * 2 + 1 < Count && (Data[index].CompareTo(Data[index * 2 + 1]) < 0) == Type)
                {
                    pos = index * 2 + 1;
                }

                if (index * 2 + 2 < Count && (Data[pos].CompareTo(Data[index * 2 + 2]) < 0) == Type)
                {
                    pos = index * 2 + 2;
                }

                //相等说明没有必要在进行数据交换了
                if (pos == index) break;
                Swap(pos, index);
                index = pos;
            }
        }

        /// <summary>
        /// 删除任意元素
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            if (Count <= 0)
            {
                throw new ArgumentException("没那么多数据");
            }

            var index = -1;
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].CompareTo(item) == 0)
                {
                    index = i;
                }
            }

            if (index >= 0)
            {
                Data[index] = Data[Count - 1];
                Data.RemoveAt(Count - 1);
                Heapify(index);
                return true;
            }

            return false;
        }

        public void Clear()
        {
            Data = null;
            Type = true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Count <= 0) throw new ArgumentException("没有数据进行排序");
            while (Count > 1)
            {
                Swap(0, Count - 1);
                Heapify(0);
            }

            //堆化完成打印
            //根据大顶堆或者小顶堆输出相应的从小到大或者从大到小排序
            for (int i = 0; i < Data.Count; i++)
            {
                yield return Data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T item)
        {
            foreach (var comparable in Data)
            {
                if (item.CompareTo(comparable) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            //TODO 暂时不实现
            throw new NotImplementedException();
        }
    }
}