using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 平均时间复杂度：选择排序（o(n2)）；最好情况：选择排序（o(n2)）；最坏情况：选择排序（o(n2)）；辅助空间：选择排序（o(1)）；不稳定
/// </summary>
public class SelectionSort : SortMethod
{
    public static SelectionSort Instance()
    {
        return SingletonProperty<SelectionSort>.Instance();
    }

    protected override void SortUP(ref int[] nums)
    {
        int tmp, minVal, minIndex = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            minVal = nums[i];
            minIndex = i;
            for (int j = i + 1; j < nums.Length; j++)//在未排序的序列中进行选择
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

    protected override void SortDOWN(ref int[] nums)
    {
        int tmp, minVal, minIndex = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            minVal = nums[i];
            minIndex = i;
            for (int j = i + 1; j < nums.Length; j++)//在未排序的序列中进行选择
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