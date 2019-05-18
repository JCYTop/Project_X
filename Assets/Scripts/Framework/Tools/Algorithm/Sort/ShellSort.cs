using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 平均时间复杂度：希尔排序（o(n1.3)）；最好情况：希尔排序（o(n)）；最坏情况：希尔排序（o(n2)）；辅助空间：希尔排序（o(1)）；不稳定
/// </summary>
public class ShellSort : SortMethod
{
    public static ShellSort Instance()
    {
        return SingletonProperty<ShellSort>.Instance();
    }

    protected override void SortUP(ref int[] nums)
    {
        int i, j, temp;
        for (int group = nums.Length / 2; group > 0; group /= 2)//创建增量，nums1长度为8所以会创建出4,2,1的增量因子，并且最小的为1
        {
            for (i = group; i < nums.Length; i++)//根据创建的增量因子来确定数组上的数字。增量因子为4时就对应着数组的8，num1[4]=8。
            {
                for (j = i - group; j >= 0; j -= group)//增量因子确定的数字跟数组位置相差同样增量因子的进行比较
                {
                    if (nums[j] > nums[j + group])//判断是否需要数值交换
                    {
                        temp = nums[j];
                        nums[j] = nums[j + group];
                        nums[j + group] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }

    protected override void SortDOWN(ref int[] nums)
    {
        int i, j, temp;
        for (int group = nums.Length / 2; group > 0; group /= 2)//创建增量，nums1长度为8所以会创建出4,2,1的增量因子，并且最小的为1
        {
            for (i = group; i < nums.Length; i++)//根据创建的增量因子来确定数组上的数字。增量因子为4时就对应着数组的8，num1[4]=8。
            {
                for (j = i - group; j >= 0; j -= group)//增量因子确定的数字跟数组位置相差同样增量因子的进行比较
                {
                    if (nums[j] < nums[j + group])//判断是否需要数值交换
                    {
                        temp = nums[j];
                        nums[j] = nums[j + group];
                        nums[j + group] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
