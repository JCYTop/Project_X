/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ScenesMgr
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/16 17:08:03
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景实例化出物体的管理
/// </summary>
public class ScenesMgr
{
    #region 字段

    private static Dictionary<int, ObjectBase> objectDic = new Dictionary<int, ObjectBase>(1 << 8);
    private static Dictionary<int, UIBase> uiDic = new Dictionary<int, UIBase>(1 << 4);
    private static int globalIDLibrary = int.MaxValue;

    #region 场景数据管理ID***

    /// <summary>
    /// 当前玩家ID，可变化
    /// </summary>
    private static int currPlayer = -1;

    /// <summary>
    /// 玩家ID列表，可变化
    /// </summary>
    private static List<int> playerID = new List<int>(1 << 2);

    /// <summary>
    /// 敌人列表，可变化
    /// </summary>
    private static List<int> enemyID = new List<int>(1 << 4);

    /// <summary>
    /// 敌人列表，可变化
    /// </summary>
    private static List<int> bossID = new List<int>(1 << 2);

    /// <summary>
    /// NPC列表，可变化
    /// </summary>
    private static List<int> npcID = new List<int>(1 << 4);

    #endregion

    #endregion

    #region 属性

    public static int GlobalID
    {
        get
        {
            globalIDLibrary--;
            return globalIDLibrary;
        }
    }

    #endregion

    #region  GameObject物体 

    public static Dictionary<int, ObjectBase> GameObjectDic
    {
        get => objectDic;
    }

    /// <summary>
    /// 包含数量
    /// </summary>
    public static int GameObjectDicCount
    {
        get => objectDic.Count;
    }

    /// <summary>p
    /// 添加GO信息
    /// </summary>
    /// <param name="globalID">ResID</param>
    /// <param name="info">信息</param>
    /// <param name="callback">回调</param>
    /// <returns>GO数据</returns>
    public static Dictionary<int, ObjectBase> AddGameObjectInfo<T>(int globalID, int selectEnum, ObjectBase info) where T : Enum
    {
        if (!objectDic.ContainsKey(globalID))
        {
            objectDic.Add(globalID, info);
            RegiestID<T>(globalID, selectEnum, true);
        }
        else
        {
            LogUtil.LogError(string.Format("发现了重复ID：{0}", globalID));
        }

        return objectDic;
    }

    /// <summary>
    /// 删除GO信息
    /// </summary>
    /// <param name="globalID">ResID</param>
    /// <param name="info">信息</param>
    /// <param name="callback">回调</param>
    /// <returns>删除的GO数据</returns>
    public static (int globalID, ObjectBase info) RemoveGameObjectInfo<T>(int globalID, int selectEnum) where T : Enum
    {
        ObjectBase tmp = null;
        if (objectDic.ContainsKey(globalID))
        {
            objectDic.TryGetValue(globalID, out tmp);
            objectDic.Remove(globalID);
            RegiestID<T>(globalID, selectEnum, false);
        }
        else
        {
            LogUtil.LogError(string.Format("并未发现相对应的ID：{0}", globalID));
        }

        return (globalID, tmp);
    }

    /// <summary>
    /// 获取GO信息
    /// </summary>
    /// <param name="globalID">ResID</param>
    /// <returns>具体的GO信息</returns>
    public static ObjectBase GetGOInfo(int globalID)
    {
        if (objectDic.ContainsKey(globalID))
        {
            objectDic.TryGetValue(globalID, out var Info);
            return Info;
        }

        LogUtil.LogError("没有存在相应的ID");
        return default;
    }

    #endregion

    #region  UI

    public static Dictionary<int, UIBase> UIDic
    {
        get => uiDic;
    }

    /// <summary>
    /// 包含数量
    /// </summary>
    public static int UIDicCount
    {
        get => uiDic.Count;
    }

    /// <summary>
    /// 添加UI信息
    /// </summary>
    /// <param name="globalID">ResID</param>
    /// <param name="info">信息</param>
    /// <param name="callback">回调</param>
    /// <returns>UI数据</returns>
    public static Dictionary<int, UIBase> AddUIInfo<T>(int globalID, int selectEnum, UIBase info) where T : Enum
    {
        if (!uiDic.ContainsKey(globalID))
        {
            uiDic.Add(globalID, info);
            RegiestID<T>(globalID, selectEnum, true);
        }
        else
        {
            LogUtil.LogError(string.Format("发现了重复ID：{0}", globalID));
        }

        return uiDic;
    }

    /// <summary>
    /// 删除UI信息
    /// </summary>
    /// <param name="globalID">ResID</param>
    /// <param name="callback">回调</param>
    /// <returns>删除的UI数据</returns>
    public static (int globalID, UIBase info) RemoveUIInfo<T>(int globalID, int selectEnum) where T : Enum
    {
        UIBase tmp = null;
        if (uiDic.ContainsKey(globalID))
        {
            uiDic.TryGetValue(globalID, out tmp);
            uiDic.Remove(globalID);
            RegiestID<T>(globalID, selectEnum, true);
        }
        else
        {
            LogUtil.LogError(string.Format("并未发现相对应的ID：{0}", globalID));
        }

        return (globalID, tmp);
    }

    /// <summary>
    /// 获取UI信息
    /// </summary>
    /// <param name="globalID">ResID</param>
    /// <returns>具体的UI信息</returns>
    public static UIBase GetUIInfo(int globalID)
    {
        if (uiDic.ContainsKey(globalID))
        {
            uiDic.TryGetValue(globalID, out var Info);
            return Info;
        }

        LogUtil.LogError("没有存在相应的ID");
        return default;
    }

    #endregion

    /// <summary>
    /// 调用注册
    /// </summary>
    /// <param name="regist"></param>
    private static void RegiestID<T>(int globalID, int selectEnum, bool isAdd) where T : Enum
    {
        var strSet = CommonUtil.GetEnumStringSet<T>(selectEnum);
        foreach (var str in strSet)
        {
            switch (str)
            {
                case "Player":
                    currPlayer = globalID;
                    ChangeSceneMgrID(ref playerID, globalID, isAdd);
                    break;
                case "Enemy":
                    ChangeSceneMgrID(ref enemyID, globalID, isAdd);
                    break;
                case "Boss":
                    ChangeSceneMgrID(ref bossID, globalID, isAdd);
                    break;
                case "NPC":
                    ChangeSceneMgrID(ref npcID, globalID, isAdd);
                    break;
            }
        }
    }

    private static void ChangeSceneMgrID(ref List<int> list, int globalID, bool isAdd)
    {
        if (isAdd)
        {
            if (!list.Contains(globalID))
            {
                list.Add(globalID);
            }
        }
        else
        {
            if (list.Contains(globalID))
            {
                list.Remove(globalID);
            }
        }
    }
}