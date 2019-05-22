/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AssetBundleLoader
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/19 17:32:30
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AB加载器
/// </summary>
public class AssetBundleLoader : MonoBehaviour
{
    private static AssetBundleLoader instance;

    public static AssetBundleLoader Instance()
    {
        if (instance == null)
        {
            instance = MonoSingletonProperty<AssetBundleLoader>.Instance();
        }

        return instance;
    }

    public string GetBundleUrl(string fileName)
    {
        //TODO 暂时不适合
        //#if UNITY_EDITOR
        //        return Application.dataPath + "/../AssetBundles/" + SysUtil.GetPlatformName() + "/" + fileName;
        //#else
        //      string url = Application.streamingAssetsPath + "/AssetBundles/" + SysUtil.GetPlatformName() + "/" + fileName;
        //if (Define.NeedSyncWithServer)
        //      {
        //          string updateDir = Application.persistentDataPath + "/AssetBundles/" + SysUtil.GetPlatformName() + "/" + fileName;
        //          if (File.Exists(updateDir))
        //          {
        //  url = updateDir;
        //          }
        //      }
        //      return url;
        //#endif
        return Define.LoadResRootPath + fileName;
    }

    public void LoadAssetAsync(string bundleName, string assetName, Action<object> action)
    {
        StartCoroutine(OnLoadAssetAsync(bundleName, assetName, action));
    }

    private IEnumerator OnLoadAssetAsync(string assetBundleName, string assetName, Action<UnityEngine.Object> callback)
    {
        ABLoadAsset request = AssetBundleManager.Instance().LoadAsset(assetBundleName, assetName, typeof(UnityEngine.Object));
        if (request == null)
            yield break;
        yield return StartCoroutine(request);

        UnityEngine.Object obj = request.GetAsset<UnityEngine.Object>();
        if (callback != null) callback(obj);
    }
}