/// <summary>
/// 平均时间复杂度：插入排序（o(n2)）；最好情况：插入排序（o(n)）；最坏情况：插入排序（o(n2)）；辅助空间：插入排序（o(1)）；稳定
/// </summary>
public static class InsertionSort
{
    public static void SortUp(ref int[] nums)
    {
        int temp, j = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            temp = nums[i];
            for (j = i; j > 0 && nums[j - 1] > temp; j--)
            {
                nums[j] = nums[j - 1];
                nums[j - 1] = temp;
            }
        }
    }

    public static void SortDown(ref int[] nums)
    {
        int temp, j = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            temp = nums[i];
            for (j = i; j > 0 && nums[j - 1] < temp; j--)
            {
                nums[j] = nums[j - 1];
                nums[j - 1] = temp;
            }
        }
    }
}