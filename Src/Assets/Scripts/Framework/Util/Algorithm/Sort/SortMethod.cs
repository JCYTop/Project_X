public abstract class SortMethod : ISort
{
    protected SortType sortType;

    public void Sort(ref int[] nums, SortType sortType = SortType.Up)
    {
        switch (sortType)
        {
            case SortType.Up:
                this.sortType = sortType;
                SortUp(ref nums);
                break;
            case SortType.Down:
                this.sortType = sortType;
                SortDown(ref nums);
                break;
        }
    }

    protected abstract void SortUp(ref int[] nums);
    protected abstract void SortDown(ref int[] nums);
}