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
    }
}