/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ScenesCenter
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
using Framework.Base;
using UnityEngine;

/// <summary>
/// 场景实例化出物体的管理
/// </summary>
public static class ScenesCenterMgr
{
    #region 字段

    private static Dictionary<int, ObjectBase> objectDic = new Dictionary<int, ObjectBase>(1 << 8);
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

    public static Camera MainCamera { set; get; }

    public static int GlobalID
    {
        get
        {
            globalIDLibrary--;
            return globalIDLibrary;
        }
    }

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

    #endregion

    /// <summary>
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
            LogTool.LogError(string.Format("发现了重复ID：{0}", globalID));
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
            LogTool.LogError(string.Format("并未发现相对应的ID：{0}", globalID));
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

        LogTool.LogError("没有存在相应的ID");
        return default;
    }

    /// <summary>
    /// 调用注册
    /// </summary>
    /// <param name="regist"></param>
    private static void RegiestID<T>(int globalID, int selectEnum, bool isAdd) where T : Enum
    {
        var strSet = Util.GetEnumStringSet<T>(selectEnum);
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