/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ICollectionExtend
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/25 22:47:19
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

public static class ICollectionExtend
{
    #region Dictionary

    public static TValue GetDictionaryValue<Tkey, TValue>(this IDictionary<Tkey, TValue> dic, Tkey key)
    {
        dic.TryGetValue(key, out TValue value);
        if (value == null)
        {
            LogTool.LogError($"没有Key对应的Value" , LogEnum.NormalLog);
        }

        return value != null ? value : default(TValue);
    }

    #endregion
}