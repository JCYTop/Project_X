using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 平均时间复杂度：堆排序（o(nlog2n)）；最好情况：堆排序（o(nlog2n)）；最坏情况：堆排序（o(nlog2n)）；辅助空间：堆排序（o(1)）；不稳定
/// </summary>
public class HeapSort : SortMethod
{
    public static HeapSort Instance()
    {
        return SingletonProperty<HeapSort>.Instance();
    }

    protected override void SortDOWN(ref int[] nums)
    {

    }

    protected override void SortUP(ref int[] nums)
    {
        Heap_Sort(nums);
    }

    private void Heap_Sort(int[] nums)
    {
        for (int i = nums.Length; i > 0; i--)
        {
            Maxheapify(nums, i);
            int temp = nums[0];//堆顶元素(第一个元素)与Kn交换
            nums[0] = nums[i - 1];
            nums[i - 1] = temp;
        }
    }

    private void Maxheapify(int[] nums, int limit)
    {
        if (nums.Length <= 0 || nums.Length < limit) return;
        int parentIdx = limit / 2;
        for (; parentIdx >= 0; parentIdx--)
        {
            if (parentIdx * 2 >= limit)
            {
                continue;
            }
            int left = parentIdx * 2;//左子节点位置
            int right = (left + 1) >= limit ? left : (left + 1); //右子节点位置，如果没有右节点，默认为左节点位置
            int maxChildId = nums[left] >= nums[right] ? left : right;
            if (nums[maxChildId] > nums[parentIdx])
            {
                //交换父节点与左右子节点中的最大值
                int temp = nums[parentIdx];
                nums[parentIdx] = nums[maxChildId];
                nums[maxChildId] = temp;
            }
        }
    }
}