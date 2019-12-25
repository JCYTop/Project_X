/// <summary>
/// 平均时间复杂度：快速排序（o(d(n+r))）；最好情况：快速排序（o(d(n+rd))）；最坏情况：快速排序（o(d(n+r))）；辅助空间：快速排序（o(rd+n)）；稳定
/// </summary>
public static class RadixSort
{
    /// <summary>
    /// 默认长度3
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="d"></param>
    public static void Radix_SortDOWN(int[] nums, int d)
    {
        int k = nums.Length - 1;
        int n = 1;
        int m = 1; //控制键值排序依据在哪一位
        int[,] temp = new int[10, nums.Length]; //数组的第一维表示可能的余数0-9
        int[] order = new int[10]; //数组orderp[i]用来表示该位是i的数的个数
        while (m <= d)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int lsd = ((nums[i] / n) % 10);
                temp[lsd, order[lsd]] = nums[i];
                order[lsd]++;
            }

            for (int i = 0; i < 10; i++)
            {
                if (order[i] != 0)
                    for (int j = 0; j < order[i]; j++)
                    {
                        nums[k] = temp[i, j];
                        k--;
                    }

                order[i] = 0;
            }

            n *= 10;
            k = nums.Length - 1;
            m++;
        }
    }

    /// <summary>
    /// 默认长度3
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="d"></param>
    public static void Radix_SortUP(int[] nums, int d)
    {
        int k = 0;
        int n = 1;
        int m = 1; //控制键值排序依据在哪一位
        int[,] temp = new int[10, nums.Length]; //数组的第一维表示可能的余数0-9
        int[] order = new int[10]; //数组orderp[i]用来表示该位是i的数的个数
        while (m <= d)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int lsd = ((nums[i] / n) % 10);
                temp[lsd, order[lsd]] = nums[i];
                order[lsd]++;
            }

            for (int i = 0; i < 10; i++)
            {
                if (order[i] != 0)
                    for (int j = 0; j < order[i]; j++)
                    {
                        nums[k] = temp[i, j];
                        k++;
                    }

                order[i] = 0;
            }

            n *= 10;
            k = 0;
            m++;
        }
    }
}