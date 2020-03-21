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

using System;
using System.Collections;
using System.Collections.Generic;

public static class ICollectionExtend
{
    #region Dictionary Extend

    /// <summary>
    /// 获取字典值
    /// </summary>
    /// <param name="dic"></param>
    /// <param name="key"></param>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue GetDictionaryValue<Tkey, TValue>(this Dictionary<Tkey, TValue> dic, Tkey key)
    {
        dic.TryGetValue(key, out TValue value);
        if (value == null)
        {
            LogTool.LogError($"没有Key对应的Value", LogEnum.NormalLog);
        }

        return value != null ? value : default(TValue);
    }

    /// <summary>
    /// 直接修改数值
    /// </summary>
    /// <param name="dic"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue SetDictionaryValue<Tkey, TValue>(this Dictionary<Tkey, TValue> dic, Tkey key, TValue value)
    {
        if (!dic.ContainsKey(key))
        {
            LogTool.LogError($"没有Key对应的Value", LogEnum.NormalLog);
        }

        dic[key] = value;
        return dic[key];
    }

    /// <summary>
    /// 移除相对应的Key
    /// </summary>
    /// <param name="dic"></param>
    /// <param name="key"></param>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static bool RemoveDictionaryElements<Tkey, TValue>(this Dictionary<Tkey, TValue> dic, Tkey key)
    {
        if (dic.ContainsKey(key))
        {
            dic.Remove(key);
            return true;
        }
        else
        {
            LogTool.LogError($"不含有相对应的 Key：  {key}");
            return false;
        }
    }

    #endregion

    #region SortList Extend

    /// <summary>
    /// 获取SortList值
    /// </summary>
    /// <param name="sortList"></param>
    /// <param name="key"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue GetSortListValue<TKey, TValue>(this SortedList<TKey, TValue> sortList, TKey key)
    {
        sortList.TryGetValue(key, out TValue value);
        if (value == null)
        {
            LogTool.LogError($"没有Key对应的Value", LogEnum.NormalLog);
        }

        return value != null ? value : default(TValue);
    }

    /// <summary>
    /// 获取SortList值
    /// 根据string转换成enum来处理
    /// </summary>
    /// <param name="sortList"></param>
    /// <param name="key"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue GetSortListValue<TKey, TValue>(this SortedList<TKey, TValue> sortList, string key)
    {
        sortList.TryGetValue((TKey) Enum.Parse(typeof(TKey), key), out TValue value);
        if (value == null)
        {
            LogTool.LogError($"没有Key对应的Value", LogEnum.NormalLog);
        }

        return value != null ? value : default(TValue);
    }

    /// <summary>
    /// 添加SortList元素
    /// </summary>
    /// <param name="sortList"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static SortedList<Tkey, TValue> AddSortListElements<Tkey, TValue>(this SortedList<Tkey, TValue> sortList, Tkey key, TValue value)
    {
        sortList.TryGetValue(key, out TValue tmpvalue);
        if (tmpvalue == null)
            sortList.Add(key, value);
        else
        {
            LogTool.Log($"出现重复！！！", LogEnum.NormalLog);
        }

        return sortList;
    }

    /// <summary>
    /// 移除相对应的Key
    /// </summary>
    /// <param name="sortList"></param>
    /// <param name="key"></param>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static bool RemoveSortListElements<Tkey, TValue>(this SortedList<Tkey, TValue> sortList, Tkey key)
    {
        if (sortList.ContainsKey(key))
        {
            sortList.Remove(key);
            return true;
        }
        else
        {
            LogTool.LogError($"不含有相对应的 Key：  {key}");
            return false;
        }
    }

    /// <summary>
    /// 设置队列中一个元素的数值
    /// </summary>
    /// <param name="sortList"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public static void SetSortListElementsValue<Tkey, TValue>(this SortedList<Tkey, TValue> sortList, Tkey key, TValue value)
    {
        sortList.TryGetValue(key, out TValue tmpvalue);
        if (tmpvalue == null)
        {
            LogTool.Log($"不含有对应 Key：  {key}", LogEnum.NormalLog);
        }
        else
            tmpvalue = value;
    }

    #endregion

    #region List Extend 

    /// <summary>
    /// 添加列表元素
    /// </summary>
    /// <param name="list"></param>
    /// <param name="element"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool AddListElement<T>(this List<T> list, T element)
    {
        if (!list.Contains(element))
        {
            list.Add(element);
            return true;
        }

        return false;
    }

    #endregion

    #region Hashtable

    /// <summary>
    /// 添加元素给Hashtable
    /// </summary>
    /// <param name="table"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void AddHashtableElement(this Hashtable table, object key, object value)
    {
        if (!table.ContainsKey(key))
        {
            table.Add(key, value);
        }
        else
        {
            table[key] = value;
        }
    }

    /// <summary>
    /// 添加元素给Hashtable
    /// </summary>
    /// <param name="table"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static T GetHashtableElement<T>(this Hashtable table, object key)
    {
        try
        {
            if (table.ContainsKey(key))
            {
                return (T) table[key];
            }

            LogTool.Log($"，没有含有对应的Key");
            return default;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
}