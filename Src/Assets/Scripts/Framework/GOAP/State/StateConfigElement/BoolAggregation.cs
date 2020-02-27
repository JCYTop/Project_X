/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     BoolAggregation
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/27 23:36:34
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    /// <summary>
    /// Bool 聚合类
    /// 单一存放
    /// 存放简单 Bool
    /// </summary>
    public class BoolAggregation : StateConfigElement<bool>
    {
        public override bool Data { get; set; }

        public BoolAggregation(bool value) : base(value)
        {
            this.TypeName = typeof(BoolAggregation).ToString();
            this.Data = value;
        }

        public override bool GetData()
        {
            return Data;
        }

        public override int CompareTo(bool other)
        {
            return Data.CompareTo(other);
        }
    }
}