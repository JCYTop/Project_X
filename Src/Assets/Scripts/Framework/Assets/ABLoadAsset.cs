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
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Framework.Assets
{
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
        private object simulatedObject;
        private object[] allObject;
        protected float deltaTime = 0f;

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
            return simulatedObject as T;
        }

        public override T[] GetAllAsset<T>()
        {
            return allObject as T[];
        }

        public override bool Update()
        {
            return false;
        }

        public override bool IsDone()
        {
            if ((Time.realtimeSinceStartup - startTime) < deltaTime)
                return false;
            return true;
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
        protected AssetBundleRequest request;
        protected AssetBundleRequest allRequest;

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

    public abstract class ABLoadBase : ABLoadOperation
    {
        public AsyncOperation sceneRequest;
    }

    public class ABLoadLevelSimulation : ABLoadBase
    {
        public ABLoadLevelSimulation()
        {
        }

        public override bool Update()
        {
            return false;
        }

        public override bool IsDone()
        {
            return true;
        }
    }

    public class ABLoadLevel : ABLoadBase
    {
        protected string assetBundleName;
        protected string levelName;
        protected bool isAdditive;
        protected string downloadingError;

        public ABLoadLevel(string assetBundleName, string levelName, bool isAdditive)
        {
            this.assetBundleName = assetBundleName;
            this.levelName = levelName;
            this.isAdditive = isAdditive;
        }

        public override bool Update()
        {
            if (sceneRequest != null)
                return false;

            LoadedAssetBundle bundle = AssetBundleManager.Instance().GetLoadedAssetBundle(assetBundleName);
            if (bundle != null)
            {
                if (isAdditive)
                    sceneRequest = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
                else
                    sceneRequest = SceneManager.LoadSceneAsync(levelName);
                return false;
            }
            else
                return true;
        }

        public override bool IsDone()
        {
            if (sceneRequest == null && downloadingError != null)
            {
                LogUtil.LogError(downloadingError);
                return true;
            }

            return sceneRequest != null && sceneRequest.isDone;
        }
    }
}