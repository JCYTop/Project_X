/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ABLoadAsset
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/19 17:00:42
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class ABLoadAsset : ABLoadOperation
{
    public abstract T GetAsset<T>() where T : UnityEngine.Object;
    public abstract T[] GetAllAsset<T>() where T : UnityEngine.Object;
}

/// <summary>
/// AB虚拟加载资源
/// </summary>
public class ABLoadAssetSimulation : ABLoadAsset
{
    protected float startTime;
    private Object simulatedObject;
    private Object[] allObject;

    public ABLoadAssetSimulation(string assetBundleName, string assetName, bool single)
    {
#if UNITY_EDITOR
        startTime = Time.realtimeSinceStartup;
        if (single)
        {
            simulatedObject = AssetDatabase.LoadMainAssetAtPath(assetName);
        }
        else
        {
            allObject = AssetDatabase.LoadAllAssetsAtPath(assetName);
        }
#endif
    }

    public override T GetAsset<T>()
    {
        throw new System.NotImplementedException();
    }

    public override T[] GetAllAsset<T>()
    {
        throw new System.NotImplementedException();
    }

    public override bool Update()
    {
        throw new NotImplementedException();
    }

    public override bool IsDone()
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// AB加载所有资源
/// </summary>
public class ABLoadAssetFull : ABLoadAsset
{
    protected string assetBundleName;
    protected string assetName;
    protected Type type;
    protected bool isSingle = true;
    protected AssetBundleRequest request = null;
    protected AssetBundleRequest allRequest = null;

    public ABLoadAssetFull(string bundleName, string assetName, Type type, bool bSingle)
    {
        this.assetBundleName = bundleName;
        this.assetName = assetName;
        this.type = type;
        this.isSingle = bSingle;
    }

    public override T GetAsset<T>()
    {
        if (request != null && request.isDone)
            return request.asset as T;
        else
            return null;
    }

    public override T[] GetAllAsset<T>()
    {
        if (allRequest != null)
            return allRequest.allAssets as T[];
        else
            return null;
    }

    public override bool Update()
    {
        if (request != null)
            return false;
        LoadedAssetBundle bundle = AssetBundleManager.Instance().GetLoadedAssetBundle(assetBundleName);
        if (bundle != null)
        {
            if (isSingle)
                request = bundle.AssetBundle.LoadAssetAsync(assetName, type);
            else
                allRequest = bundle.AssetBundle.LoadAllAssetsAsync(type);
            return false;
        }
        else
        {
            return true;
        }
    }

    public override bool IsDone()
    {
        if (isSingle)
            return request != null && request.isDone;
        else
            return allRequest != null && allRequest.isDone;
    }
}