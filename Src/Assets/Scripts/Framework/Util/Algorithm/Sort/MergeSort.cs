using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 平均时间复杂度：归并排序（o(nlog2n)）；最好情况：归并排序（o(nlog2n)）；最坏情况：归并排序（o(n2)）；辅助空间：归并排序（o(n)）；稳定
/// </summary>
public class MergeSort : SortMethod
{
    public static MergeSort Instance()
    {
        return SingletonProperty<MergeSort>.Instance();
    }

    protected override void SortUp(ref int[] nums)
    {
        nums = CreateSort(nums);
    }

    protected override void SortDown(ref int[] nums)
    {
        nums = CreateSort(nums);
    }

    /// <summary>
    /// 分组
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    private int[] CreateSort(int[] nums)
    {
        if (nums == null || nums.Length <= 1)
        {
            return nums;
        }
        int avg = nums.Length >> 1;//寻找中间值
        int[] left = new int[avg];//生成左边数组
        int[] right = new int[nums.Length - avg];//生成右边数组
        int[] result = new int[nums.Length];//结果数组

        for (int i = 0; i < nums.Length; i++)//分割数组
        {
            if (i < avg)
            {
                left[i] = nums[i];
            }
            else
            {
                right[i - avg] = nums[i];
            }
        }
        left = CreateSort(left);
        right = CreateSort(right);
        switch (sortType)
        {
            case SortType.Up:
                result = Merge_SortUP(left, right);//合并数组
                break;
            case SortType.Down:
                result = Merge_SortDOWN(left, right);//合并数组
                break;
        }
        return result;
    }

    /// <summary>
    /// 合并
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    private int[] Merge_SortUP(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];
        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] < right[j])
            {
                result[k++] = left[i++];
            }
            else
            {
                result[k++] = right[j++];
            }
        }
        while (i < left.Length)
        {
            result[k++] = left[i++];
        }
        while (j < right.Length)
        {
            result[k++] = right[j++];
        }
        return result;//返回合并数组
    }

    /// <summary>
    /// 合并
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    private int[] Merge_SortDOWN(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];
        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] > right[j])
            {
                result[k++] = left[i++];
            }
            else
            {
                result[k++] = right[j++];
            }
        }
        while (i < left.Length)
        {
            result[k++] = left[i++];
        }
        while (j < right.Length)
        {
            result[k++] = right[j++];
        }
        return result;//返回合并数组
    }
}