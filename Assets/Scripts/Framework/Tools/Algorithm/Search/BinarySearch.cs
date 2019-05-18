﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearch : Singleton<BinarySearch>, ISearch
{
    public int Search(int[] nums, int target, bool isSort = true)
    {
        if (isSort)
            QuickSort.Instance().Sort(ref nums, SortType.UP);
        int low = 0;
        int high = nums.Length - 1;
        while (low <= high)
        {
            int middle = (low + high) / 2;
            if (target == nums[middle])
            {
                return middle;//如果找到了就直接返回这个元素的索引
            }
            else if (target > nums[middle])
            {
                low = middle + 1;
            }
            else
            {
                high = middle - 1;
            }
        }
        return -1;//如果找不到就返回-1；
    }
}