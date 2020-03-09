/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     FloatAggregation
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/09 15:53:26
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace Framework.GOAP
{
    public class FloatAggregation : ConfigElementBase<float >, IComparable<float>
    {
        public FloatAggregation(float value) : base(value)
        {
        }

        public int CompareTo(float other)
        {
            throw new NotImplementedException();
        }
    }
}