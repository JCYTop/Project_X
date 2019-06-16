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
using System.Collections.Generic;

public class CommonUtil
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

    #region 枚举

    /// <summary>
    /// 获得枚举内容并且 得到相应的排序枚举
    /// </summary>
    /// <param name="t">类型</param>
    /// <returns></returns>
    public static Array GetEnumArray(Type type)
    {
        return Enum.GetValues(type);
    }

    /// <summary>
    /// 根据枚举选择判断出哪些进行了选择的Bool数组
    /// </summary>
    /// <returns></returns>
    public static bool[] GetEnumBoolSet<T>(int selectEnum) where T : Enum
    {
        var arry = GetEnumArray(typeof(T));
        var boolList = new bool[arry.Length];
        for (int i = 0; i < arry.Length; i++)
        {
            //进行判断
            var myEnumint = 1 << i;
            var select = myEnumint & selectEnum;
            var isSelect = select == (int) myEnumint;
            boolList[i] = isSelect;
        }

        return boolList;
    }

    /// <summary>
    /// 根据枚举选择判断出哪些进行了选择的字符串数组
    /// </summary>
    /// <returns></returns>
    public static string[] GetEnumStringSet<T>(int selectEnum) where T : Enum
    {
        var arry = GetEnumArray(typeof(T));
        var boolList = new List<string>();
        for (int i = 0; i < arry.Length; i++)
        {
            //进行判断
            var myEnumint = 1 << i;
            var select = myEnumint & selectEnum;
            var isSelect = select == (int) myEnumint;
            if (isSelect)
            {
                boolList.Add(arry.GetValue(i).ToString());
            }
        }

        return boolList.ToArray();
    }

    #endregion
}