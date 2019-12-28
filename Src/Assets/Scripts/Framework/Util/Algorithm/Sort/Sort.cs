namespace UtilSet
{
    public class Sort
    {
        /// <summary>
        /// 快速排序,填坑法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static void QuickSort_FillThePit(int[] nums, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var mid = _partition(nums, start, end);
            QuickSort_FillThePit(nums, start, mid - 1);
            QuickSort_FillThePit(nums, mid + 1, end);

            int _partition(int[] _nums, int _start, int _end)
            {
                var _ptr = _nums[_start]; //首位参考值
                while (_start < _end)
                {
                    while (_nums[_end] > _ptr && _start < _end)
                    {
                        end--; //大于往下递减
                    }

                    _nums[_start] = _nums[_end];
                    while (_nums[_start] > _ptr && _start < _end)
                    {
                        start++;
                    }

                    _nums[end] = _nums[_start];
                }

                _nums[_start] = _ptr;
                return _start;
            }
        }

        /// <summary>
        /// 快速排序,交换法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void QuickSort_Exchange(int[] nums, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var mid = _partition(nums, start, end);
            QuickSort_Exchange(nums, start, mid - 1);
            QuickSort_Exchange(nums, mid + 1, end);

            int _partition(int[] _nums, int _start, int _end)
            {
                var ptr = _nums[_start];
                var p = _start + 1;
                var q = end;
                while (p <= q)
                {
                    while (_nums[p] < ptr && p <= q)
                    {
                        p++;
                    }

                    while (_nums[q] >= ptr && p <= q)
                    {
                        q--;
                    }

                    if (p < q)
                    {
                        _swap(ref _nums[p], ref _nums[q]);
                    }
                }

                _swap(ref _nums[_start], ref _nums[q]);
                return q;
            }

            //交换数字
            void _swap(ref int a1, ref int a2)
            {
                a1 = a1 ^ a2;
                a2 = a1 ^ a2;
                a1 = a1 ^ a2;
            }
        }

        /// <summary>
        /// 快速排序,顺序遍历法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void QucikSort_Sequence(int[] nums, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int mid = _partition(nums, start, end);
            QucikSort_Sequence(nums, start, mid - 1);
            QucikSort_Sequence(nums, mid + 1, end);

            int _partition(int[] _nums, int _start, int _end)
            {
                var ptr = _nums[_end];
                var storeIndex = _start;
                for (int i = _start; i < _end; i++)
                {
                    if (_nums[i] < ptr)
                    {
                        _swap(ref _nums[storeIndex], ref _nums[i]);
                        storeIndex++;
                    }
                }

                _swap(ref _nums[storeIndex], ref _nums[_end]);
                return storeIndex;
            }

            void _swap(ref int a1, ref int a2)
            {
                a1 = a1 ^ a2;
                a2 = a1 ^ a2;
                a1 = a1 ^ a2;
            }
        }

        /// <summary>
        /// 快速排序,普通法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void QucikSort_Normal(int[] nums, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var ptr = nums[start];
            var p = start;
            var q = end;
            while (true)
            {
                while (nums[p] < ptr) p++;
                while (nums[q] > ptr) q++;
                if (p >= q) break;
                _swap(ref nums[p], ref nums[q]);
                p++;
                q--;
            }

            QucikSort_Normal(nums, start, p - 1);
            QucikSort_Normal(nums, q + 1, end);

            void _swap(ref int a1, ref int a2)
            {
                a1 = a1 ^ a2;
                a2 = a1 ^ a2;
                a1 = a1 ^ a2;
            }
        }

        /// <summary>
        /// 快速排序,三数取中法;https://www.cnblogs.com/chengxiao/p/6262208.htmlv
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void QucikSort_Three(int[] nums, int start, int end)
        {
            if (start < end)
            {
                //获取枢纽值，并将其放在当前待处理序列末尾
                _dealPivot();
                var ptr = end - 1;
                var p = start;
                var q = end - 1;
                while (true)
                {
                    while (nums[p] < nums[ptr])
                    {
                        p++;
                    }

                    while (nums[q] > nums[ptr] && q > p)
                    {
                        q--;
                    }

                    //中间找到进行值的处理 ,之后继续寻找
                    if (p < q)
                    {
                        _swap(ref nums[p], ref nums[q]);
                    }
                    else
                    {
                        //否则本次循环完成结束
                        break;
                    }
                }

                if (p < ptr)
                {
                    _swap(ref nums[p], ref nums[ptr]);
                }

                QucikSort_Three(nums, start, p - 1);
                QucikSort_Three(nums, p + 1, end);
            }


            void _dealPivot()
            {
                var mid = (start + end) / 2;
                if (nums[start] > nums[mid])
                {
                    _swap(ref nums[start], ref nums[mid]);
                }

                if (nums[start] > nums[end])
                {
                    _swap(ref nums[start], ref nums[end]);
                }

                if (nums[mid] > nums[end])
                {
                    _swap(ref nums[mid], ref nums[end]);
                }

                //把中间数放到右边数第二个
                _swap(ref nums[end - 1], ref nums[mid]);
            }

            void _swap(ref int a1, ref int a2)
            {
                a1 = a1 ^ a2;
                a2 = a1 ^ a2;
                a1 = a1 ^ a2;
            }
        }
    }
}