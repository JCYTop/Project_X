using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ClassExtension
{
    /// <summary>
    /// 判断是不是空
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selfObj"></param>
    /// <returns></returns>
    public static bool IsNull<T>(this T selfObj) where T : class
    {
        return null == selfObj;
    }

    /// <summary>
    /// 判断是不是非空
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selfObj"></param>
    /// <returns></returns>
    public static bool IsNotNull<T>(this T selfObj) where T : class
    {
        return null != selfObj;
    }
}