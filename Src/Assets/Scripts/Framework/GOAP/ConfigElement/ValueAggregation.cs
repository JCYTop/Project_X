/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ValueAggregation
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/26 22:49:25
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace GOAP
{
    /// <summary>
    /// 值计数聚合类
    /// 单一存放
    /// 存放简单数值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValueAggregation : ConfigElementBase<int>, IComparable<int>
    {
        public override int Data { get; set; }

        public ValueAggregation(int value) : base(value)
        {
            this.TypeName = typeof(ValueAggregation).ToString();
            this.Data = value;
        }

        public override int GetData()
        {
            return Data;
        }

        public int CompareTo(int other)
        {
            return Data.CompareTo(other);
        }
    }
}