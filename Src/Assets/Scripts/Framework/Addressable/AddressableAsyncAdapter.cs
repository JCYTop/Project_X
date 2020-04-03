/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AddressableAdapter
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
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

/// <summary>
/// 地址化资源加载适配器
/// 简单封装接口
/// </summary>
public static class AddressableAsyncAdapter
{
    #region 获取依赖关系

    /// <summary>
    /// 以资源的“地址”或者标签为参数
    /// 进行依赖项资源的加载
    /// 一般情况下这些资源都是AssetBundle
    /// </summary>
    /// <param name="addressNames"></param>
    /// <param name="percent"></param>
    public static AsyncOperationHandle DownloadDependenciesAsync(string addressNames, Action<float> percent = null)
    {
        var download = Addressables.DownloadDependenciesAsync(addressNames);
        if (percent != null)
            percent(download.PercentComplete);
        return download;
    }

    #endregion

    #region 加载资源

    /// <summary>
    /// 异步实例化本地资源
    /// </summary>
    /// <param name="addressName"></param>
    /// <param name="completed"></param>
    /// <returns></returns>
    public static AsyncOperationHandle<GameObject> InstantiateAsync(string addressName, Action<AsyncOperationHandle<GameObject>> completed = null)
    {
        var handle = Addressables.InstantiateAsync(addressName);
        handle.Completed += completed;
        return handle;
    }

    /// <summary>
    /// 异步实例化资源
    /// </summary>
    /// <param name="addressName"></param>
    /// <param name="completed"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static AsyncOperationHandle<T> LoadAssetAsync<T>(string addressName, Action<AsyncOperationHandle<T>> completed = null)
    {
        var handle = Addressables.LoadAssetAsync<T>(addressName);
        handle.Completed += completed;
        return handle;
    }

    /// <summary>
    /// 异步加载资源集合
    /// </summary>
    /// <param name="label"></param>
    /// <param name="callback"></param>
    /// <param name="completed"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static AsyncOperationHandle<IList<T>> LoadAssetsAsync<T>(AssetLabelReference label, Action<T> callback,
        Action<AsyncOperationHandle<IList<T>>> completed = null)
    {
        var handle = Addressables.LoadAssetsAsync<T>(label, callback);
        handle.Completed += completed;
        return handle;
    }

    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="mode"></param>
    /// <param name="completed"></param>
    /// <returns></returns>
    public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single,
        Action<AsyncOperationHandle<SceneInstance>> completed = null)
    {
        var handle = Addressables.LoadSceneAsync(sceneName, mode);
        handle.Completed += completed;
        return handle;
    }

    #region 扩展

    /// <summary>
    /// 加载
    /// </summary>
    /// <param name="reference"></param>
    /// <returns></returns>
    public static AsyncOperationHandle<GameObject> InstantiateAsync(this AssetReference reference)
    {
//        AssetReferenceTexture
        return reference.InstantiateAsync();
    }

    /// <summary>
    /// 加载
    /// </summary>
    /// <param name="reference"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static AsyncOperationHandle<T> LoadAssetAsync<T>(this AssetReference reference)
    {
        return reference.LoadAssetAsync<T>();
    }

    /// <summary>
    /// 资源完成操作
    /// </summary>
    /// <param name="handle"></param>
    /// <param name="completed"></param>
    /// <typeparam name="T"></typeparam>
    public static void AsyncOperationHandle<T>(this AsyncOperationHandle<T> handle, Action<AsyncOperationHandle<T>> completed = null)
    {
        handle.Completed += completed;
    }

    /// <summary>
    /// 资源完成操作
    /// </summary>
    /// <param name="handle"></param>
    /// <param name="success"></param>
    /// <param name="failed"></param>
    /// <typeparam name="T"></typeparam>
    public static void AsyncOperationHandle<T>(this AsyncOperationHandle<T> handle, Action<T> success, Action failed)
    {
        handle.Completed += complete =>
        {
            switch (complete.Status)
            {
                case AsyncOperationStatus.Succeeded:
                    success(complete.Result);
                    break;
                case AsyncOperationStatus.Failed:
                default:
                    failed();
                    break;
            }
        };
    }

    /// <summary>
    /// 资源完成操作
    /// </summary>
    /// <param name="handle"></param>
    /// <param name="completed"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerator AsyncOperationHandleIEnumerator<T>(this AsyncOperationHandle<T> handle, Action<AsyncOperationHandle<T>> completed)
    {
        yield return handle;
        handle.Completed += completed;
    }

    /// <summary>
    /// 资源完成操作
    /// </summary>
    /// <param name="handle"></param>
    /// <param name="success"></param>
    /// <param name="failed"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerator AsyncOperationHandleIEnumerator<T>(this AsyncOperationHandle<T> handle, Action<T> success, Action failed)
    {
        yield return handle;
        handle.Completed += complete =>
        {
            switch (complete.Status)
            {
                case AsyncOperationStatus.Succeeded:
                    success(complete.Result);
                    break;
                case AsyncOperationStatus.Failed:
                default:
                    failed();
                    break;
            }
        };
    }

    /// <summary>
    /// 资源完成操作
    /// </summary>
    /// <param name="handle"></param>
    /// <param name="completed"></param>
    /// <typeparam name="T"></typeparam>
    public static async void AsyncOperationHandleAwait<T>(this AsyncOperationHandle<T> handle, Action<AsyncOperationHandle<T>> completed)
    {
        await handle.Task;
        handle.Completed += completed;
    }

    /// <summary>
    /// 资源完成操作
    /// </summary>
    /// <param name="handle"></param>
    /// <param name="success"></param>
    /// <param name="failed"></param>
    /// <typeparam name="T"></typeparam>
    public static async void AsyncOperationHandleAwait<T>(this AsyncOperationHandle<T> handle, Action<T> success, Action failed)
    {
        await handle.Task;
        handle.Completed += complete =>
        {
            switch (complete.Status)
            {
                case AsyncOperationStatus.Succeeded:
                    success(complete.Result);
                    break;
                case AsyncOperationStatus.Failed:
                default:
                    failed();
                    break;
            }
        };
    }

    #endregion

    #endregion

    #region 卸载资源

    /// <summary>
    /// 释放资源
    /// </summary>
    /// <param name="obj"></param>
    /// <typeparam name="T"></typeparam>
    public static void Release<T>(T obj)
    {
        Addressables.Release<T>(obj);
    }

    /// <summary>
    /// 卸载场景物体
    /// </summary>
    /// <param name="obj"></param>
    /// <typeparam name="T"></typeparam>
    public static bool ReleaseInstance(GameObject obj)
    {
        return Addressables.ReleaseInstance(obj);
    }

    /// <summary>
    /// 卸载资源
    /// </summary>
    /// <param name="reference"></param>
    public static void ReleaseAsset(this AssetReference reference)
    {
        reference.ReleaseAsset();
    }

    /// <summary>
    /// 卸载场景
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="completed"></param>
    /// <returns></returns>
    public static AsyncOperationHandle<SceneInstance> UnloadSceneAsync(SceneInstance sceneName,
        Action<AsyncOperationHandle<SceneInstance>> completed = null)
    {
        var handle = Addressables.UnloadSceneAsync(sceneName);
        handle.Completed += completed;
        return handle;
    }

    #endregion
}