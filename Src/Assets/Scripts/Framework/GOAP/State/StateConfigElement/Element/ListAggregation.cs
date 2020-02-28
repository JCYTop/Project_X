/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ListAggregation
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/29 00:10:08
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace GOAP
{
    public abstract class ListAggregation<T> : StateConfigElement<List<T>>
    {
        public override List<T> Data { get; set; }

        public ListAggregation(List<T> value) : base(value)
        {
            this.TypeName = typeof(ListAggregation<T>).ToString();
            this.Data = value;
        }

        public override List<T> GetData()
        {
            return Data;
        }
    }
}