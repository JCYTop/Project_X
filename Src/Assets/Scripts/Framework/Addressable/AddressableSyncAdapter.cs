/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AddressableSyncAdapter
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.1f1
 *CreateTime:   2020/04/03 19:01:02
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// 同步加载资源
/// </summary>
public static class AddressableSyncAdapter
{
    private static bool initialized = false;

    public static bool IsReady
    {
        get { return initialized; }
    }

    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        Addressables.InitializeAsync().Completed += (complete) => { initialized = true; };
    }

    public static T LoadAsset<T>(object key)
    {
        if (!initialized)
            throw new Exception("Whoa there friend! We haven't init'd yet!");
        var asset = Addressables.LoadAssetAsync<T>(key);
        if (!asset.IsDone)
            throw new Exception("Sync LoadAsset failed to load in a sync way! " + key);
        if (asset.Result == null)
        {
            var message = "Sync LoadAsset has null result " + key;
            if (asset.OperationException != null)
                message += " Exception: " + asset.OperationException;
            throw new Exception(message);
        }

        return asset.Result;
    }

    public static async Task Instantiate(object key, Transform parent = null, bool instantiateInWorldSpace = false)
    {
        if (!initialized)
            throw new Exception("Whoa there friend! We haven't init'd yet!");
        var asset = Addressables.InstantiateAsync(key, parent, instantiateInWorldSpace);
        while (!asset.IsDone)
        {
            await Task.Delay(100);
            Debug.Log("233");
        }

        if (!asset.IsDone)
            throw new Exception("Sync Instantiate failed to finish! " + key);
        if (asset.Result == null)
        {
            var message = "Sync Instantiate has null result " + key;
            if (asset.OperationException != null)
                message += " Exception: " + asset.OperationException;
            throw new Exception(message);
        }
    }
}