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
    /// <summary>
    /// Dictionary 聚合类
    /// </summary>
    public class DictionaryAggregation<Tkey, TValue> : ConfigElementBase<Dictionary<Tkey, TValue>>
    {
        public DictionaryAggregation(Dictionary<Tkey, TValue> value) : base(value)
        {
        }
    }
}