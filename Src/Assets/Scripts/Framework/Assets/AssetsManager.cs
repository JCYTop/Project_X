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
    private Dictionary<string, Queue<AssetPoolItem>> objectPoolMap = new Dictionary<string, Queue<AssetPoolItem>>();

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
    /// <param name="callback">回调:返回读取进度</param>
    public void PreloadAsset(CallBackWithPercent callback)
    {
        //TODO 修改JSON PreloadAB由手动生成
        PreloadFileModel preloadModel = FileUtils.JsonFile<PreloadFileModel>("Config/PreloadAB.json");
        preloadAssetPool.LoadAssetList(preloadModel, callback);
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
    /// <param name="callback"></param>
    public void GetPrefabAsync(string path, Action<GameObject> callback)
    {
        shortAssetPool.LoadAssetAsync(path, callback);
    }

    /// <summary>
    /// 清空资源列表
    /// </summary>
    public void CleanShortAssets()
    {
        shortAssetPool.CleanUp();
    }

    #endregion

    /// <summary>
    /// 获取已加载的游戏实体Prefab
    /// </summary>
    /// <param name="assetName">资源名</param>
    /// <returns>Prefab</returns>
    public GameObject GetGOPrefab(string assetName)
    {
        return preloadAssetPool.GetPrefab(string.Format("{0} ", assetName));
    }

    /// <summary>
    /// 异步获取已加载的游戏实体Prefab
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="callback"></param>
    public void GetGOPrefabAsync(string assetName, Action<GameObject> callback)
    {
        shortAssetPool.LoadAssetAsync(string.Format("{0} ", assetName), callback);
    }

    #region 对象池

    /// <summary>
    /// 从对象池取出一个实体
    /// </summary>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public GameObject GetGoFromPool(string assetName)
    {
        objectPoolMap.TryGetValue(assetName, out var pool);
        GameObject obj;
        if (pool != null && pool.Count > 0)
        {
            AssetPoolItem item = pool.Dequeue();
            obj = item.gameObject;
            obj.SetActive(true);
        }
        else
        {
            GameObject prefab = GetGOPrefab(assetName);
            obj = Instantiate(prefab);
            if (obj != null)
            {
                AssetPoolItem item = obj.GetComponent<AssetPoolItem>();
                if (item != null)
                {
                    item.AssetName = assetName;
                }
                else
                    LogUtil.LogError(string.Format("asset {0} is not a pool item", assetName), LogType.AssetLog);
            }
        }

        return obj;
    }

    /// <summary>
    /// 异步从对象池取出一个实体
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="callback"></param>
    public void GetGoFromPoolAsync(string assetName, Action<GameObject> callback)
    {
        objectPoolMap.TryGetValue(assetName, out var pool);
        GameObject obj;
        if (pool != null && pool.Count > 0)
        {
            AssetPoolItem item = pool.Dequeue();
            obj = item.gameObject;
            obj.SetActive(true);
            callback(obj);
        }
        else
        {
            GetGOPrefabAsync(assetName, (prefab) =>
            {
                obj = Instantiate(prefab);
                if (obj != null)
                {
                    AssetPoolItem item = obj.GetComponent<AssetPoolItem>();
                    if (item != null)
                    {
                        item.AssetName = assetName;
                    }
                    else
                        LogUtil.LogError(string.Format("asset {0} is not a pool item", assetName), LogType.AssetLog);

                    callback(obj);
                }
            });
        }
    }

    /// <summary>
    /// 将资源放回对象池
    /// </summary>
    /// <param name="item"></param>
    public void PutGoToPool(AssetPoolItem item)
    {
        string assetName = item.AssetName;
        objectPoolMap.TryGetValue(assetName, out var pool);
        if (pool == null)
        {
            pool = new Queue<AssetPoolItem>();
            objectPoolMap[assetName] = pool;
        }

        pool.Enqueue(item);
    }

    /// <summary>
    /// 清空对象池
    /// </summary>
    public void CleanEnityPool()
    {
        objectPoolMap.Clear();
    }

    /// <summary>
    /// 获取资源对象池
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, Queue<AssetPoolItem>> GetGoPool()
    {
        return objectPoolMap;
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