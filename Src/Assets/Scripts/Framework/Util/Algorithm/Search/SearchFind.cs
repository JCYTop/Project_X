/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Search
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/12/30 22:28:07
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace UtilSet
{
    public class SearthFind
    {
        #region 二分查找

        /// <summary>
        /// 查找第一个值等于给定值的元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <param name="value"></param>
        public static int Binary_1(int[] nums, int n, int value)
        {
            var low = 0;
            var high = n - 1;
            while (low <= high)
            {
                var mid = low + ((high - low) >> 1);
                if (nums[mid] > value)
                {
                    high = mid - 1;
                }
                else if (nums[mid] < value)
                {
                    low = mid + 1;
                }
                else
                {
                    //mid == 0 说明到最开始了
                    if ((mid == 0) || (nums[mid - 1] != value))
                    {
                        return mid;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// 查找最后一个值等于给定值的元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Binary_2(int[] nums, int n, int value)
        {
            var low = 0;
            var high = n - 1;
            while (low <= high)
            {
                var mid = low + ((high - low) >> 1);
                if (nums[mid] > value)
                {
                    high = mid - 1;
                }
                else if (nums[mid] < value)
                {
                    low = mid + 1;
                }
                else
                {
                    //mid==n-1说明到了最后
                    if ((mid == n - 1) || (nums[mid + 1] != value))
                    {
                        return mid;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// 查找第一个大于等于给定值的元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Binary_3(int[] nums, int n, int value)
        {
            int low = 0;
            int high = n - 1;
            while (low <= high)
            {
                var mid = low + ((high - low) >> 1);
                if (nums[mid] >= value)
                {
                    if ((mid == 0 || (nums[mid - 1] < value)))
                    {
                        return mid;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// 查找最后一个小于等于给定值的元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Binary_4(int[] nums, int n, int value)
        {
            int low = 0;
            int high = n - 1;
            while (low <= high)
            {
                var mid = low + ((high - low) >> 1);
                if (nums[mid] <= value)
                {
                    if ((mid == n - 1) || (nums[mid + 1] > value))
                    {
                        return mid;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                else
                {
                    high = mid + 1;
                }
            }

            return -1;
        }

        #endregion
    }
}