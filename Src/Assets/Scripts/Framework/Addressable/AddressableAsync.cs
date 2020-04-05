/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AddressableAsync
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
using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

/// <summary>
/// 地址化资源加载适配器
/// 简单封装接口
/// </summary>
public static class AddressableAsync
{
    #region 初始化

    /// <summary>
    /// 初始化操作
    /// </summary>
    /// <param name="complete"></param>
    public static void InitializeAsync([NotNull] Action callBack)
    {
        Addressables.InitializeAsync().Completed += (complete) =>
        {
            if (complete.IsDone)
            {
                callBack();
            }
        };
    }

    #endregion

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
    public static AsyncOperationHandle<GameObject> InstantiateAsync(string addressName, Action<GameObject> completed = null)
    {
        var operation = Addressables.InstantiateAsync(addressName);
        operation.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                if (completed != null)
                    completed(handle.Result);
            }
        };
        return operation;
    }

    /// <summary>
    /// 异步实例化资源
    /// </summary>
    /// <param name="addressName"></param>
    /// <param name="completed"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static AsyncOperationHandle<T> LoadAssetAsync<T>(string addressName, Action<T> completed = null)
    {
        var operation = Addressables.LoadAssetAsync<T>(addressName);
        operation.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                if (completed != null)
                    completed(handle.Result);
            }
        };
        return operation;
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
        var operation = Addressables.LoadAssetsAsync<T>(label, callback);
        operation.Completed += completed;
        return operation;
    }

    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="mode"></param>
    /// <param name="completed"></param>
    /// <returns></returns>
    public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single,
        Action completed = null)
    {
        var operation = Addressables.LoadSceneAsync(sceneName, mode);
        operation.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                if (completed != null)
                    completed();
            }
        };
        return operation;
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
    /// <param name="operation"></param>
    /// <param name="completed"></param>
    /// <typeparam name="T"></typeparam>
    public static void AsyncOperationHandle<T>(this AsyncOperationHandle<T> operation, Action completed = null)
    {
        operation.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                if (completed != null)
                    completed();
            }
        };
    }

    /// <summary>
    /// 资源完成操作
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="success"></param>
    /// <param name="failed"></param>
    /// <typeparam name="T"></typeparam>
    public static void AsyncOperationHandle<T>(this AsyncOperationHandle<T> operation, Action<T> success, Action failed)
    {
        operation.Completed += complete =>
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
    /// <param name="operation"></param>
    /// <param name="completed"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerator AsyncOperationHandleIEnumerator<T>(this AsyncOperationHandle<T> operation, Action completed)
    {
        yield return operation;
        operation.Completed += (handle) =>
        {
            if (completed != null)
                completed();
        };
    }

    /// <summary>
    /// 资源完成操作
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="success"></param>
    /// <param name="failed"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerator AsyncOperationHandleIEnumerator<T>(this AsyncOperationHandle<T> operation, Action<T> success, Action failed)
    {
        yield return operation;
        operation.Completed += complete =>
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
    /// <param name="operation"></param>
    /// <param name="completed"></param>
    /// <typeparam name="T"></typeparam>
    public static async void AsyncOperationHandleAwait<T>(this AsyncOperationHandle<T> operation, Action completed = null)
    {
        await operation.Task;
        operation.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                if (completed != null)
                    completed();
            }
        };
    }

    /// <summary>
    /// 资源完成操作
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="success"></param>
    /// <param name="failed"></param>
    /// <typeparam name="T"></typeparam>
    public static async void AsyncOperationHandleAwait<T>(this AsyncOperationHandle<T> operation, Action<T> success, Action failed)
    {
        await operation.Task;
        operation.Completed += complete =>
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

    public static void Release<T>(AsyncOperationHandle<T> handle)
    {
        Addressables.Release<T>(handle);
    }

    public static void Release(AsyncOperationHandle handle)
    {
        Addressables.Release(handle);
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
        var operation = Addressables.UnloadSceneAsync(sceneName);
        operation.Completed += completed;
        return operation;
    }

    #endregion
}