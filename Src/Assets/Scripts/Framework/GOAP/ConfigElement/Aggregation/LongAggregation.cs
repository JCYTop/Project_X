/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     LongAggregation
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/09 15:53:49
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace GOAP
{
    public class LongAggregation : ConfigElementBase<long>, IComparable<long>
    {
        public LongAggregation(long value) : base(value)
        {
        }

        public int CompareTo(long other)
        {
            throw new NotImplementedException();
        }
    }
}