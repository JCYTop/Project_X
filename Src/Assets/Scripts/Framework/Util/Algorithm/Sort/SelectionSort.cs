/// <summary>
/// 平均时间复杂度：选择排序（o(n2)）；最好情况：选择排序（o(n2)）；最坏情况：选择排序（o(n2)）；辅助空间：选择排序（o(1)）；不稳定
/// </summary>
public static class SelectionSort
{
    public static void SortUp(ref int[] nums)
    {
        int tmp, minVal, minIndex = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            minVal = nums[i];
            minIndex = i;
            for (int j = i + 1; j < nums.Length; j++) //在未排序的序列中进行选择
            {
                if (minVal > nums[j])
                {
                    minVal = nums[j];
                    minIndex = j;
                }
            }

            tmp = nums[i];
            nums[i] = nums[minIndex];
            nums[minIndex] = tmp;
        }
    }

    public static void SortDown(ref int[] nums)
    {
        int tmp, minVal, minIndex = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            minVal = nums[i];
            minIndex = i;
            for (int j = i + 1; j < nums.Length; j++) //在未排序的序列中进行选择
            {
                if (minVal < nums[j])
                {
                    minVal = nums[j];
                    minIndex = j;
                }
            }

            tmp = nums[i];
            nums[i] = nums[minIndex];
            nums[minIndex] = tmp;
        }
    }
}