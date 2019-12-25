/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AssetCachePool
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/19 15:26:54
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections;
using System.Collections.Generic;
using Framework.EventDispatcher;
using UnityEngine;

namespace Framework.Assets
{
    public class AssetCachePool : MonoEventEmitter
    {
        private Dictionary<string, ABPrefabInfo> cachePrefabs = new Dictionary<string, ABPrefabInfo>();

        /// <summary>
        /// 异步加载资源
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cb"></param>
        public void LoadAssetList(PreloadFileModel model, CallBackWithPercent cb)
        {
            StartCoroutine(OnLoadAssetList(model, cb));
        }

        private IEnumerator OnLoadAssetList(PreloadFileModel model, CallBackWithPercent cb)
        {
            List<string> list = model.fileList;
            for (int i = 0; i < list.Count; i++)
            {
                string path = list[i];
                string bundleName = path.ToLower();
                string assetName = path + ".prefab";
                ABLoadAsset request = AssetBundleManager.Instance().LoadAssetAsync(bundleName, assetName, typeof(UnityEngine.Object));
                if (request != null)
                {
                    yield return StartCoroutine(request);
                    GameObject obj = request.GetAsset<UnityEngine.GameObject>();
                    cachePrefabs.Add(bundleName, new ABPrefabInfo(obj));
                }
                else
                {
                    LogUtil.LogError(string.Format("bundle ++{0}++ can't loading", bundleName), LogType.AssetLog);
                }

                //回调加载显示信息
                cb(i + 1, list.Count);
            }
        }

        /// <summary>
        /// 获取加载了的预制体
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public GameObject GetPrefab(string path)
        {
            cachePrefabs.TryGetValue(path.ToLower(), out var obj);
            return obj.GetPrefab();
        }

        public void CleanUp()
        {
            foreach (string key in cachePrefabs.Keys)
            {
                AssetBundleManager.Instance().UnloadAssetBundle(key, true);
            }

            cachePrefabs.Clear();
        }

        public void LoadAssetAsync(string path, Action<GameObject> callBack)
        {
            string bundleName = path.ToLower();
            string assetName = path + ".prefab";
            cachePrefabs.TryGetValue(bundleName, out var abInfo);
            if (abInfo != null)
            {
                GameObject prefab = abInfo.GetPrefab();
                if (prefab)
                {
                    //Prefab已被加载
                    callBack(prefab);
                }
                else
                {
                    //Prefab正在加载
                    abInfo.AddListener(callBack);
                }
            }
            else
            {
                //第一加载Prefab
                abInfo = new ABPrefabInfo(callBack);
                cachePrefabs.Add(bundleName, abInfo);
                AssetBundleLoader.Instance().LoadAssetAsync(bundleName, assetName, (assetObj) =>
                {
                    var go = abInfo.LoadedPrefab(assetObj as GameObject);
                    LogUtil.Log(string.Format("首次加载了资源{0}", go.name), LogType.AssetLog);
                });
            }
        }
    }
}