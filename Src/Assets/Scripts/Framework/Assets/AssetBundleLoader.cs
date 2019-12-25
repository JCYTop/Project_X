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

namespace Framework.Assets
{
    /// <summary>
    /// AB加载器
    /// </summary>
    public class AssetBundleLoader : MonoEventEmitter
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
            return GlobalDefine.LoadResRootPath + fileName;
        }

        public void LoadAssetAsync(string bundleName, string assetName, Action<object> action)
        {
            StartCoroutine(OnLoadAssetAsync(bundleName, assetName, action));
        }

        private IEnumerator OnLoadAssetAsync(string assetBundleName, string assetName, Action<UnityEngine.Object> callback)
        {
            var request = AssetBundleManager.Instance().LoadAssetAsync(assetBundleName, assetName, typeof(UnityEngine.Object));
            if (request == null)
                yield break;
            yield return StartCoroutine(request);
            var obj = request.GetAsset<UnityEngine.Object>();
            if (callback != null) callback(obj);
        }

        public void LoadAllAsset(string assetBundleName, string assetName, Action<UnityEngine.Object[]> callback)
        {
            StartCoroutine(OnLoadAllAsset(assetBundleName, assetName, callback));
        }

        private IEnumerator OnLoadAllAsset(string assetBundleName, string assetName, Action<UnityEngine.Object[]> callback)
        {
            var request = AssetBundleManager.Instance().LoadAssetAsync(assetBundleName, assetName, typeof(UnityEngine.Object), false);
            if (request == null)
                yield break;
            yield return StartCoroutine(request);
            var obj = request.GetAllAsset<UnityEngine.Object>();
            //Debug.Log(assetName + (obj == null ? " isn't" : " is") + " loaded successfully at frame " + Time.frameCount);
            if (callback != null) callback(obj);
        }

        public void LoadLevelAsset(string name, Action fn = null)
        {
            var bundle = GlobalDefine.AssetsConfig.ScencePath + "/" + name;
            StartCoroutine(LoadLevel(bundle.ToLower(), name, fn));
        }

        protected IEnumerator LoadLevel(string assetBundleName, string levelName, Action callback)
        {
            var request = AssetBundleManager.Instance().LoadLevelAsync(assetBundleName, levelName, false);
            if (request != null)
            {
                yield return StartCoroutine(request);
            }

            if (callback != null) callback();
        }
    }
}