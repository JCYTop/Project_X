using System;
using System.Collections;
using System.Collections.Generic;

namespace Base.BinaryTree
{
    public class BinaryTree<T> : ICollection<T> where T : IComparable<T>
    {
        /// <summary>
        /// 头节点
        /// </summary>
        private BinaryTreeNode<T> head;

        /// <summary>
        /// 遍历策略
        /// </summary>
        private ITraversalStrategy<T> traversalStrategy;

        /// <summary>
        /// 当前数量
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 设定容量
        /// </summary>
        public int Capacity { get; }

        /// <summary>
        /// 获取一个值，该值指示 Array 是否具有固定大小。
        /// </summary>
        public bool IsFixedSize { get; }

        /// <summary>
        /// 是否为只读
        /// </summary>
        public bool IsReadOnly => false;

        private IEnumerable<T> Collection { get; }

        public ITraversalStrategy<T> TraversalStrategy
        {
            get => traversalStrategy ?? (traversalStrategy = new InOrderTraversal<T>());
            set => traversalStrategy = value ?? throw new ArgumentNullException(nameof(value));
        }

        public BinaryTree()
        {
        }

        public BinaryTree(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException("数组设定需要大于0！！！");
            }

            IsFixedSize = true;
            Capacity = capacity;
        }

        public BinaryTree(ITraversalStrategy<T> traversalStrategy)
        {
            traversalStrategy = traversalStrategy ?? throw new ArgumentNullException(nameof(traversalStrategy));
        }

        /// <summary>GetEnumerator
        /// 构建二叉查找树
        /// </summary>
        /// <param name="collection"></param>
        public BinaryTree(IEnumerable<T> collection)
        {
            Collection = collection;
            AddRange(collection);
        }

        private void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Add(enumerator.Current);
                }
            }
        }

        public void Add(T value)
        {
            if (IsFixedSize && Count >= Capacity)
            {
                throw new NotSupportedException($"The BinaryTree has a fixed size. Can not add more than {Capacity} items");
            }

            if (head == null)
            {
                head = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(head, value);
            }

            Count++;
        }

        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    //递归到下一层存放
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    //递归到下一层存放
                    AddTo(node.Right, value);
                }
            }
        }

        /// <summary>
        /// 获取迭代器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return TraversalStrategy.Traversal(head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            head = null;
            Count = 0;
        }

        public bool Contains(T value)
        {
            return FindWithParent(value, out var _) != null;
        }

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            var current = head;
            parent = null;
            while (current != null)
            {
                var result = current.CompareTo(value);
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.GetLowerBound(0) != 0)
            {
                throw new ArgumentException("Non zero lower bound");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException();
            }

            //深度,广度遍历产生数组
            var items = TraversalStrategy.Traversal(head);
            while (items.MoveNext())
            {
                array[arrayIndex++] = items.Current;
            }
        }

        public bool Remove(T value)
        {
            var current = FindWithParent(value, out var parent);
            if (current == null)
            {
                return false;
            }

            Count--;
            if (current.Right == null) //当前节点无右边的树
            {
                if (parent == null) //当前节点无右边的树,父节点为Null,删除的根节点
                {
                    head = current.Left;
                }
                else
                {
                    var result = parent.CompareTo(current.Value); //不会有相等的情况。
                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null) //当前节点的右节点的左节点为空
            {
                current.Right.Left = current.Left;
                if (parent == null) //当前节点的右节点的左节点为空,父节点为Null,删除的根节点
                {
                    head = current.Right;
                }
                else
                {
                    var result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                var leftMost = current.Right.Left;
                var leftMostParent = current.Right;
                //直到干道NUll
                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                //leftMost和当前接节点交换位置
                leftMostParent.Left = leftMost.Right; //如果有补充一下
                leftMost.Left = current.Left; //leftMost点一定比current.Right小，也就比其他的小，所以可以交换
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    head = leftMost;
                }
                else
                {
                    var result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = leftMost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftMost;
                    }
                }
            }

            return true;
        }

        public void PrintTo()
        {
            foreach (var item in Collection)
            {
                Console.Write($"{item} ");
            }
        }
    }
}