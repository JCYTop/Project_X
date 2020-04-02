/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AddressableMgr
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.1f1
 *CreateTime:   2020/04/02 22:37:08
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/


using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public static class AddressableMgr
{
    public static void InstantiateAsync()
    {
    }

    /// <summary>
    /// 异步加载资源集合
    /// </summary>
    /// <param name="label"></param>
    /// <param name="callback"></param>
    /// <param name="completed"></param>
    /// <typeparam name="T"></typeparam>
    public static void LoadAssetsAsync<T>(AssetLabelReference label, Action<T> callback, Action<AsyncOperationHandle<IList<T>>> completed = null)
    {
        Addressables.LoadAssetsAsync<T>(label, callback).Completed += completed;
    }

    /// <summary>
    /// 异步加载场景
    /// </summary>
    public static void LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single,
        Action<AsyncOperationHandle<SceneInstance>> completed = null)
    {
        Addressables.LoadSceneAsync(sceneName, mode).Completed += completed;
    }
}