using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 平均时间复杂度：快速排序（o(nlog2n)）；最好情况：快速排序（o(nlog2n)）；最坏情况：快速排序（o(n2)）；辅助空间：快速排序（o(nlog2n)）；不稳定
/// </summary>
public class QuickSort : SortMethod
{
    public static QuickSort Instance()
    {
        return SingletonProperty<QuickSort>.Instance();
    }

    protected override void SortUP(ref int[] nums)
    {
        QSortUP(nums, 0, nums.Length - 1);
    }

    protected override void SortDOWN(ref int[] nums)
    {
        QSortDOWN(nums, 0, nums.Length - 1);
    }

    private void QSortUP(int[] nums, int low, int high)
    {
        if (low > high)//最低指针必须小于最高位的指针才可以运行下去
        {
            return;
        }
        int first = low;
        int last = high;
        int key = nums[first];
        while (first < last)//主体循环把比key大的放在右边，比他小的放在左边
        {
            //先寻从后往前寻找比key小的数字，找到一个就行
            while (first < last && nums[last] >= key)
            {
                --last;//高位指针减小
            }
            nums[first] = nums[last];//找到一个比nums[first]小的数字进行对换
            //再从前往后寻找比key大的数字，找到一个就行
            while (first < last && nums[first] <= key)
            {
                ++first;//低位指针减小
            }
            nums[last] = nums[first];//找到一个比nums[first]大的数字进行对换
        }
        nums[first] = key;
        QSortUP(nums, low, first - 1);//递归调用
        QSortUP(nums, first + 1, high);//递归调用
    }

    private void QSortDOWN(int[] nums, int low, int high)
    {
        if (low > high)//最低指针必须小于最高位的指针才可以运行下去
        {
            return;
        }
        int first = low;
        int last = high;
        int key = nums[first];
        while (first < last)//主体循环把比key大的放在右边，比他小的放在左边
        {
            while (first < last && nums[last] <= key)
            {
                --last;//高位指针减小
            }
            nums[first] = nums[last];
            while (first < last && nums[first] >= key)
            {
                ++first;//低位指针减小
            }
            nums[last] = nums[first];//找到一个比nums[first]大的数字进行对换
        }
        nums[first] = key;
        QSortDOWN(nums, low, first - 1);//递归调用
        QSortDOWN(nums, first + 1, high);//递归调用
    }
}