using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SortMethod : ISort
{
    protected SortType sortType;

    public void Sort(ref int[] nums, SortType sortType = SortType.UP)
    {
        switch (sortType)
        {
            case SortType.UP:
                this.sortType = sortType;
                SortUP(ref nums);
                break;
            case SortType.DOWN:
                this.sortType = sortType;
                SortDOWN(ref nums);
                break;
        }
    }

    protected abstract void SortUP(ref int[] nums);
    protected abstract void SortDOWN(ref int[] nums);
}