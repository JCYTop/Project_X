/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     DictionaryAggregation
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/29 00:18:23
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace GOAP
{
    public abstract class DictionaryAggregation<Tkey, TValue> : StateConfigElement<Dictionary<Tkey, TValue>>
    {
        public override Dictionary<Tkey, TValue> Data { get; set; }

        protected DictionaryAggregation(Dictionary<Tkey, TValue> value) : base(value)
        {
            this.TypeName = typeof(DictionaryAggregation<Tkey, TValue>).ToString();
            this.Data = value;
        }

        public override Dictionary<Tkey, TValue> GetData()
        {
            return Data;
        }
    }
}