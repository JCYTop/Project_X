/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     CommonUtil
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/19 01:29:59
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonUtil
{
    #region Common

    /// <summary>
    /// 获取T类型的FieldInfo
    /// </summary>
    /// <returns></returns>
    public static int GetFieldCount<T>()
    {
        return typeof(T).GetFields().Length;
    }

    /// <summary>
    /// 获取枚举t类型的所有枚举名字
    /// </summary>
    /// <returns></returns>
    public static Array GetEnumFields(Type t)
    {
        var enums = Enum.GetValues(t);
        return enums;
    }

    #endregion
}