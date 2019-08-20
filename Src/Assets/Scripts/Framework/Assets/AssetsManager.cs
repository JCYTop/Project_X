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
    #region 字段

    private static AssetsManager instance;
    private string gameResourceRootDir;
    private AssetCachePool preloadAssetPool; //常驻资源
    private AssetCachePool shortAssetPool; //暂存资源
    private Dictionary<string, Queue<AssetPoolItem>> objectPoolMap = new Dictionary<string, Queue<AssetPoolItem>>();

    /// <summary>
    /// 以名字检索的AB资源集合
    /// </summary>
    private static Dictionary<string, List<long>> strABInfo;

    /// <summary>
    /// 以ID检索的AB资源集合
    /// </summary>
    private static Dictionary<long, ABData> idABInfo;

    #endregion

    private static Dictionary<string, List<long>> StrABInfo
    {
        get
        {
            if (strABInfo == null)
            {
                strABInfo = new Dictionary<string, List<long>>();
                foreach (var ab in Define.ABInfo.ABDatas)
                {
                    if (!strABInfo.ContainsKey(ab.name))
                    {
                        var tmp = new List<long>();
                        tmp.Add(ab.ID);
                        strABInfo.Add(ab.name, tmp);
                    }
                    else
                    {
                        strABInfo.TryGetValue(ab.name, out var tmp);
                        tmp.Add(ab.ID);
                    }
                }
            }

            return strABInfo;
        }
    }

    private static Dictionary<long, ABData> IDABInfo
    {
        get
        {
            if (idABInfo == null)
            {
                idABInfo = new Dictionary<long, ABData>();
                foreach (var ab in Define.ABInfo.ABDatas)
                {
                    if (!idABInfo.ContainsKey(ab.ID))
                    {
                        idABInfo.Add(ab.ID, ab);
                    }
                    else
                    {
                        LogUtil.LogError(string.Format("发现ABInfo异常数据ID::: {0}", ab.ID), LogType.NormalLog);
                        break;
                    }
                }
            }

            return idABInfo;
        }
    }

    public static AssetsManager Instance()
    {
        if (instance == null)
        {
            instance = MonoSingletonProperty<AssetsManager>.Instance();
        }

        return instance;
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
    private void GetPrefabAsync(string path, Action<GameObject> callback)
    {
        shortAssetPool.LoadAssetAsync(path, callback);
    }

    /// <summary>
    /// 异步获取加载的预制体
    /// </summary>
    /// <param name="name">通过已知文件名字</param>
    /// <param name="callback"></param>
    /// <param name="isImportaLL">文件名字可能会重复，只有ID是唯一的，所以需要确认一个文件名字对应几个ID，当对应多个时候是否选择都加入</param>
    public void GetPrefabAsync(string name, Action<GameObject> callback, bool isImportaLL = true)
    {
        if (StrABInfo.TryGetValue(name, out var list))
        {
            if (isImportaLL)
            {
                foreach (var id in list)
                {
                    GetPrefabAsync(id, callback);
                }
            }
            else
            {
                GetPrefabAsync(list[0], callback);
            }
        }
    }

    /// <summary>
    /// ID加载唯一确定
    /// </summary>
    /// <param name="id"></param>
    /// <param name="callback"></param>
    public void GetPrefabAsync(long id, Action<GameObject> callback)
    {
        if (IDABInfo.TryGetValue(id, out var data))
        {
            GetPrefabAsync(data.Path, callback);
        }
    }

    /// <summary>
    /// 清空资源列表
    /// </summary>
    public void CleanShortAssets()
    {
        shortAssetPool.CleanUp();
    }

    #endregion

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

    /// <summary>
    /// 异步加载精灵
    /// </summary>
    /// <param name="path">贴图路径</param>
    /// <param name="spName">精灵名称</param>
    /// <param name="fn">返回精灵回调</param>
    public void LoadSpriteAsync(string path, string spName, Action<Sprite> fn)
    {
        var bundleName = path.ToLower() + ".img";
        var assetName = path + ".png";
        AssetBundleLoader.Instance().LoadAllAsset(bundleName, assetName,
            (arr) =>
            {
                //返回一个精灵列表
                Sprite sprite = null;
                if (arr != null)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        var obj = arr[i] as Sprite;
                        //遍历寻找目标精灵
                        if (obj != null && obj.name == spName)
                        {
                            sprite = obj;
                            break;
                        }
                    }
                }

                //返回精灵
                fn(sprite);
            });
    }
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