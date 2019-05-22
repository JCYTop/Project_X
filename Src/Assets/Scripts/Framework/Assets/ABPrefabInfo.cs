/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ABPrefabInfo
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/22 23:35:15
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加载的GO信息集合类
/// </summary>
public class ABPrefabInfo
{
    private GameObject prefab;

    /// <summary>
    /// 事件集合
    /// </summary>
    private event Action<GameObject> loadListener;

    public ABPrefabInfo(Action<GameObject> cb)
    {
        loadListener += cb;
    }

    public ABPrefabInfo(GameObject obj)
    {
        prefab = obj;
    }

    /// <summary>
    /// 添加监听事件
    /// </summary>
    /// <param name="callback">添加的回调</param>
    public void AddListener(Action<GameObject> callback)
    {
        loadListener += callback;
    }

    /// <summary>
    /// 载入预制体
    /// </summary>
    /// <param name="obj"></param>
    public GameObject LoadedPrefab(GameObject obj)
    {
        prefab = obj;
        loadListener(obj);
        return obj;
    }

    /// <summary>
    /// 获取预制体
    /// </summary>
    /// <returns></returns>
    public GameObject GetPrefab()
    {
        return prefab;
    }
}