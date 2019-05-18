using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 平均时间复杂度：冒泡排序（o(n2)）；最好情况：冒泡排序（o(n)）；最坏情况：冒泡排序（o(n2)）；辅助空间：冒泡排序（o(1)）；稳定
/// </summary>
public class BubbleSort : SortMethod
{
    public static BubbleSort Instance()
    {
        return SingletonProperty<BubbleSort>.Instance();
    }

    protected override void SortUP(ref int[] nums)
    {
        int i, j, temp;
        for (j = 0; j < nums.Length - 1; j++)
        {
            for (i = 0; i < nums.Length - 1 - j; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    temp = nums[i];
                    nums[i] = nums[i + 1];
                    nums[i + 1] = temp;
                }
            }
        }
    }

    protected override void SortDOWN(ref int[] nums)
    {
        int i, j, temp;
        for (j = 0; j < nums.Length - 1; j++)
        {
            for (i = 0; i < nums.Length - 1 - j; i++)
            {
                if (nums[i] < nums[i + 1])
                {
                    temp = nums[i];
                    nums[i] = nums[i + 1];
                    nums[i + 1] = temp;
                }
            }
        }
    }
}