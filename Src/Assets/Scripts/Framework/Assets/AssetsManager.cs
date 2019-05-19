//=====================================================
// - FileName:      AssetsManager.cs
// - Created:       @JCY
// - CreateTime:    2019/03/31 00:56:12
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void CallBackWithPercent(int done, int total);

public class AssetsManager : MonoEventEmitter
{
    private static AssetsManager instance;
    private string gameResourceRootDir;
    private AssetCachePool preloadAssetPool; //常驻资源
    private AssetCachePool shortAssetPool; //暂存资源

    public static AssetsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = SingletonProperty<AssetsManager>.Instance();
            }

            return instance;
        }
    }

    private void Awake()
    {
        preloadAssetPool = this.gameObject.AddComponent<AssetCachePool>();
        shortAssetPool = this.gameObject.AddComponent<AssetCachePool>();
    }

    void OnDestroy()
    {
        instance = null;
    }

    #region 预加载资源

    /// <summary>
    /// 预加载资源
    /// </summary>
    /// <param name="cb">回调:返回读取进度</param>
    public void PreloadAsset(CallBackWithPercent cb)
    {
        //TODO 修改JSON PreloadAB由手动生成
        PreloadFileModel preloadModel = FileUtils.JsonFile<PreloadFileModel>("Config/PreloadAB.json");
        preloadAssetPool.LoadAssetList(preloadModel, cb);
    }

    /// <summary>
    /// 获取预加载的界面信息
    /// </summary>
    /// <param name="assetName">资源名</param>
    /// <returns>Prefab</returns>
    public GameObject GetPreloadPrefab(string assetName)
    {
        return preloadAssetPool.GetPrefab(string.Format("{0}", assetName));
    }

    #endregion

    #region 临时加载资源

    /// <summary>
    /// 异步获取加载的预制体
    /// </summary>
    /// <param name="path"></param>
    /// <param name="cb"></param>
    public void GetPrefabAsync(string path, Action<GameObject> cb)
    {
        shortAssetPool.LoadAssetAsync(path, cb);
    }

    /// <summary>
    /// 清空资源列表
    /// </summary>
    public void CleanShortAssets()
    {
        shortAssetPool.CleanUp();
    }

    #endregion
}

/// <summary>
/// 预加载的assetbundle的集合
/// </summary>
public class PreloadFileModel
{
    public List<string> fileList = new List<string>();

    public void Add(string file)
    {
        if (!fileList.Contains(file))
        {
            fileList.Add(file);
        }
    }
}