using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景实例化出物体的管理
/// </summary>
public class GameObjectMgr

{
    #region 字段
    private static Dictionary<long, ObjectBase> gameObjectDic = new Dictionary<long, ObjectBase>();
    private static Dictionary<long, UIBase> uiDic = new Dictionary<long, UIBase>();
    #endregion

    #region  GameObject物体 
    public static Dictionary<long, ObjectBase> GameObjectDic
    {
        get => gameObjectDic;
    }

        
    /// <summary>
    /// 包含数量
    /// </summary>
    public static int GameObjectDicCount
    {
        get => gameObjectDic.Count;
    }

    /// <summary>
    /// 添加GO信息
    /// </summary>
    /// <param name="id">ID</param>
    /// <param name="info">信息</param>
    /// <param name="callback">回调</param>
    /// <returns>GO数据</returns>
    public static Dictionary<long, ObjectBase> AddGameObjectInfo(long id, ObjectBase info, Action callback = null)
    {
        if (!gameObjectDic.ContainsKey(id))
        {
            gameObjectDic.Add(id, info);
            callback?.Invoke();
        }
        else
        {
            Debug.LogError(string.Format("发现了重复ID：{0}", id));
        }
        return gameObjectDic;
    }

    /// <summary>
    /// 添加GO信息
    /// </summary>
    /// <param name="info">信息</param>
    /// <param name="callback">回调</param>
    /// <returns>GO数据</returns>
    public static Dictionary<long, ObjectBase> AddGameObjectInfo(ObjectBase info, Action callback = null)
    {
        return AddGameObjectInfo(info.ID, info, callback);
    }

    /// <summary>
    /// 删除GO信息
    /// </summary>
    /// <param name="id">ID</param>
    /// <param name="info">信息</param>
    /// <param name="callback">回调</param>
    /// <returns>删除的GO数据</returns>
    public static (long id, ObjectBase info) RemoveGameObjectInfo(long id, Action callback = null)
    {
        ObjectBase tmp = null;
        if (gameObjectDic.ContainsKey(id))
        {
            gameObjectDic.TryGetValue(id, out tmp);
            gameObjectDic.Remove(id);
            callback?.Invoke();
        }
        else
        {
            Debug.LogWarning(string.Format("并未发现相对应的ID：{0}", id));
        }
        return (id, tmp);
    }

    /// <summary>
    /// 删除GO信息
    /// </summary>
    /// <param name="info">信息</param>
    /// <param name="callback">回调</param>
    /// <returns>删除的GO数据</returns>
    public static (long id, ObjectBase info) RemoveGameObjectInfo(ObjectBase info, Action callback = null)
    {
        return RemoveGameObjectInfo(info.ID, callback);
    }

    /// <summary>
    /// 获取GO信息
    /// </summary>
    /// <param name="id">ID</param>
    /// <returns>具体的GO信息</returns>
    public static ObjectBase GetGOInfo(long id)
    {
        if (gameObjectDic.ContainsKey(id))
        {
            gameObjectDic.TryGetValue(id, out var Info);
            return Info;
        }
        Debug.LogError("没有存在相应的ID");
        return default;
    }

    #endregion

    #region  UI
    public static Dictionary<long, UIBase> UIDic
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
    /// <param name="id">ID</param>
    /// <param name="info">信息</param>
    /// <param name="callback">回调</param>
    /// <returns>UI数据</returns>
    public static Dictionary<long, UIBase> AddUIInfo(long id, UIBase info, Action callback = null)
    {
        if (!uiDic.ContainsKey(id))
        {
            uiDic.Add(id, info);
            callback?.Invoke();
        }
        else
        {
            Debug.LogError(string.Format("发现了重复ID：{0}", id));
        }
        return uiDic;
    }

    /// <summary>
    /// 添加UI信息
    /// </summary>
    /// <param name="info">信息</param>
    /// <param name="callback">回调</param>
    /// <returns>UI数据</returns>
    public static Dictionary<long, UIBase> AddUIInfo(UIBase info, Action callback = null)
    {
        return AddUIInfo(info.ID, info, callback);
    }

    /// <summary>
    /// 删除UI信息
    /// </summary>
    /// <param name="id">ID</param>
    /// <param name="callback">回调</param>
    /// <returns>删除的UI数据</returns>
    public static (long id, UIBase info) RemoveUIInfo(long id, Action callback = null)
    {
        UIBase tmp = null;
        if (uiDic.ContainsKey(id))
        {
            uiDic.TryGetValue(id, out tmp);
            uiDic.Remove(id);
            callback?.Invoke();
        }
        else
        {
            Debug.LogWarning(string.Format("并未发现相对应的ID：{0}", id));
        }
        return (id, tmp);
    }

    /// <summary>
    /// 删除UI信息
    /// </summary>
    /// <param name="callback">回调</param>
    /// <returns>删除的UI数据</returns>
    public static (long id, UIBase info) RemoveUIInfo(UIBase info, Action callback = null)
    {
        return RemoveUIInfo(info.ID, callback);
    }
    
    /// <summary>
    /// 获取UI信息
    /// </summary>
    /// <param name="id">ID</param>
    /// <returns>具体的UI信息</returns>
    public static UIBase GetUIInfo(long id)
    {
        if (uiDic.ContainsKey(id))
        {
            uiDic.TryGetValue(id, out var Info);
            return Info;
        }
        Debug.LogError("没有存在相应的ID");
        return default;
    }

    #endregion
}