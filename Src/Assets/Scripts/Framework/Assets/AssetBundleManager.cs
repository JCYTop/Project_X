/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AssetBundleManager
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/19 16:55:59
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;
using Framework.EventDispatcher;
using Framework.Singleton;
using UnityEditor;
using UnityEngine;

namespace Framework.Assets
{
    public class AssetBundleManager : MonoEventEmitter
    {
        #region 字段

        /// <summary>
        /// AB的Manifest信息
        /// </summary>
        public static AssetBundleManifest assetBundleManifest = null;

        /// <summary>
        /// 读取AB包中的一系列相关操作
        /// </summary>
        private List<ABLoadOperation> inProgressOperations = new List<ABLoadOperation>();

        private string[] variants = { };

        /// <summary>
        /// AB资源关联信息
        /// </summary>
        private Dictionary<string, LoadedAssetBundle> loadedAssetBundles = new Dictionary<string, LoadedAssetBundle>();

        /// <summary>
        /// 读取AB时候的相关请求
        /// </summary>
        private Dictionary<string, AssetBundleCreateRequest> loadingRequest = new Dictionary<string, AssetBundleCreateRequest>();

        /// <summary>
        /// 有依赖信息AB包对应自己的依赖表
        /// </summary>
        private Dictionary<string, string[]> dependenciesDic = new Dictionary<string, string[]>();

        private List<string> removeList = new List<string>();

#if UNITY_EDITOR
        /// <summary>
        /// 与打包一起使用
        /// </summary>
        /// <summary>
        /// 是否适用AB包标志位
        /// </summary>
        private static int simulateAssetBundleInEditor = -1; // 0: 读取ab包， // -1:读取prefab

        /// <summary>
        /// 模拟AB资源包
        /// </summary>
        private const string kSimulateAssetBundles = "SimulateAssetBundles";
#endif

        #endregion

        #region 属性

#if UNITY_EDITOR
        public static bool SimulateAssetBundleInEditor
        {
            get
            {
                if (simulateAssetBundleInEditor == -1)
                    simulateAssetBundleInEditor = EditorPrefs.GetBool(kSimulateAssetBundles, true) ? 1 : 0;
                return simulateAssetBundleInEditor != 0;
            }
            set
            {
                int newValue = value ? 1 : 0;
                if (newValue != simulateAssetBundleInEditor)
                {
                    simulateAssetBundleInEditor = newValue;
                    EditorPrefs.SetBool(kSimulateAssetBundles, value);
                }
            }
        }
#endif

        #endregion

        public static AssetBundleManager Instance()
        {
            return MonoSingletonProperty<AssetBundleManager>.Instance();
        }

        #region 内部方法

        /// <summary>
        /// 处理加载依赖关系
        /// </summary>
        /// <param name="assetBundleName"></param>
        /// <param name="isLoadingAssetBundleManifest"></param>
        private void LoadAssetBundle(string assetBundleName, bool isLoadingAssetBundleManifest = false)
        {
#if UNITY_EDITOR
            //如果我们处于编辑器模拟模式，我们不必真正加载AsSeBand及其依赖关系。
            if (SimulateAssetBundleInEditor)
                return;
#endif
            if (!isLoadingAssetBundleManifest)
                assetBundleName = RemapVariantName(assetBundleName);
            //检查AB包是否已被处理。
            //bool isAlreadyProcessed = LoadAssetBundleInternal(assetBundleName, isLoadingAssetBundleManifest);
            LoadAssetBundleInternal(assetBundleName, isLoadingAssetBundleManifest);
            //读取依赖
            //if (!isAlreadyProcessed && !isLoadingAssetBundleManifest)
            if (!isLoadingAssetBundleManifest)
                LoadDependencies(assetBundleName);
        }

        /// <summary>
        /// 读取依赖文件
        /// </summary>
        /// <param name="assetBundleName"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadDependencies(string assetBundleName)
        {
            if (assetBundleManifest == null)
            {
                LogTool.LogError(string.Format("Please initialize AssetBundleManifest by calling AssetBundleManager.Initialize()"), LogEnum.AssetLog);
                return;
            }

            //从Manifest获取依赖信息表
            string[] dependencies = assetBundleManifest.GetAllDependencies(assetBundleName);
            if (dependencies.Length == 0)
                return;
            for (int i = 0; i < dependencies.Length; i++)
                dependencies[i] = RemapVariantName(dependencies[i]);
            // Record and load all dependencies.(因为现在有的assetbundle资源是可选为不释放的)
            if (!dependenciesDic.ContainsKey(assetBundleName))
                dependenciesDic.Add(assetBundleName, dependencies);
            for (int i = 0; i < dependencies.Length; i++)
                LoadAssetBundleInternal(dependencies[i], false);
        }

        /// <summary>
        /// 读取manfist内部资源
        /// </summary>
        /// <param name="assetBundleName"></param>
        /// <param name="isLoadingAssetBundleManifest"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadAssetBundleInternal(string assetBundleName, bool isLoadingAssetBundleManifest = true)
        {
            loadedAssetBundles.TryGetValue(assetBundleName, out var bundle);
            if (bundle != null)
            {
                bundle.ReferencedCount++;
                return;
            }

            if (loadingRequest.ContainsKey(assetBundleName))
            {
                return;
            }

            var url = AssetBundleLoader.Instance().GetBundleUrl(assetBundleName);
            var request = AssetBundle.LoadFromFileAsync(url);
            loadingRequest.Add(assetBundleName, request);
        }

        /// <summary>
        /// 重命名变种文件名称
        /// </summary>
        /// <param name="assetBundleName"></param>
        /// <returns></returns>
        private string RemapVariantName(string assetBundleName)
        {
            var bundlesWithVariant = assetBundleManifest.GetAllAssetBundlesWithVariant();
            //如果资产包没有变体，只需返回。
            if (Array.IndexOf(bundlesWithVariant, assetBundleName) < 0)
                return assetBundleName;
            var split = assetBundleName.Split('.');
            var bestFit = int.MaxValue;
            var bestFitIndex = -1;
            //将所有AB循环以找到最适合的变体AB
            for (int i = 0; i < bundlesWithVariant.Length; i++)
            {
                var curSplit = bundlesWithVariant[i].Split('.');
                if (curSplit[0] != split[0])
                    continue;
                var found = Array.IndexOf(variants, curSplit[1]);
                if (found != -1 && found < bestFit)
                {
                    bestFit = found;
                    bestFitIndex = i;
                }
            }

            if (bestFitIndex != -1)
                return bundlesWithVariant[bestFitIndex];
            else
                return assetBundleName;
        }

        /// <summary>
        /// 卸载AB
        /// </summary>
        /// <param name="assetBundleName"></param>
        /// <param name="unload"></param>
        private void UnloadABInternal(string assetBundleName, bool unload = false)
        {
            var bundle = GetBundle(assetBundleName);
            if (bundle != null && --bundle.ReferencedCount == 0)
            {
                bundle.AssetBundle.Unload(unload);
                loadedAssetBundles.Remove(assetBundleName);
            }
        }

        private LoadedAssetBundle GetBundle(string assetBundleName)
        {
            loadedAssetBundles.TryGetValue(assetBundleName, out var bundle);
            return bundle;
        }

        /// <summary>
        /// 清除AB依赖关系
        /// </summary>
        /// <param name="assetBundleName"></param>
        /// <param name="unload"></param>
        private void UnloadDependencies(string assetBundleName, bool unload = false)
        {
            if (!dependenciesDic.TryGetValue(assetBundleName, out var dependencies))
                return;
            //循环查找所有依赖关系
            foreach (var dependency in dependencies)
            {
                UnloadABInternal(dependency, unload);
            }

            dependenciesDic.Remove(assetBundleName);
        }

        #endregion

        #region 外部调用

        /// <summary>
        /// 从给定的AB包中加载资产,主入口 *****
        /// </summary>
        /// <param name="bundleName"></param>
        /// <param name="assetName"></param>
        /// <param name="type"></param>
        /// <param name="isSingle"></param>
        /// <returns></returns>
        public ABLoadAsset LoadAssetAsync(string bundleName, string assetName, Type type, bool isSingle = true)
        {
            ABLoadAsset operation;
#if UNITY_EDITOR
            if (SimulateAssetBundleInEditor)
            {
                operation = new ABLoadAssetSimulation(bundleName, assetName, isSingle);
            }
            else
#endif
            {
                LoadAssetBundle(bundleName);
                operation = new ABLoadAssetFull(bundleName, assetName, type, isSingle);
                //可能有依赖所以调用
                inProgressOperations.Add(operation);
            }

            return operation;
        }

        /// <summary>
        /// 获取加载的AB,只返回当所有依赖都已经加载成功的有效的物体
        /// </summary>
        /// <param name="assetBundleName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public LoadedAssetBundle GetLoadedAssetBundle(string assetBundleName)
        {
            loadedAssetBundles.TryGetValue(assetBundleName, out var bundle);
            if (bundle == null)
                return null;
            //没有依赖关系只绑定包本身。
            if (!dependenciesDic.TryGetValue(assetBundleName, out var dependencies))
                return bundle;
            //确保加载所有依赖
            foreach (var dependency in dependencies)
            {
                //等待所有依赖的assetsBundle被加载。
                loadedAssetBundles.TryGetValue(dependency, out var dependentBundle);
                if (dependentBundle == null)
                    return null;
            }

            return bundle;
        }

        /// <summary>
        /// 卸载所有的资源和依赖
        /// </summary>
        /// <param name="assetBundleName"></param>
        /// <param name="unload"></param>
        public void UnloadAssetBundle(string assetBundleName, bool unload = false)
        {
#if UNITY_EDITOR
            //如果我们处于编辑器模拟模式，我们不必加载清单assetBundle。
            if (SimulateAssetBundleInEditor)
                return;
#endif
            UnloadABInternal(assetBundleName, unload);
            UnloadDependencies(assetBundleName, unload);
        }

        #endregion

        public ABLoadBase LoadLevelAsync(string assetBundleName, string levelName, bool isAdditive)
        {
            ABLoadBase operation = null;
#if UNITY_EDITOR
            if (SimulateAssetBundleInEditor)
            {
                var levelPaths = AssetDatabase.GetAssetPathsFromAssetBundleAndAssetName(assetBundleName, levelName);
                if (levelPaths.Length == 0)
                {
                    ///@TODO: The error needs to differentiate that an asset bundle name doesn't exist
                    //        from that there right scene does not exist in the asset bundle...
                    LogTool.LogError("There is no scene with name \"" + levelName + "\" in " + assetBundleName);
                    return null;
                }

                ABLoadLevelSimulation temp = new ABLoadLevelSimulation();
                if (isAdditive)
                    temp.sceneRequest = EditorApplication.LoadLevelAdditiveAsyncInPlayMode(levelPaths[0]);
                else
                    temp.sceneRequest = EditorApplication.LoadLevelAsyncInPlayMode(levelPaths[0]);

                operation = temp;
            }
            else
#endif
            {
                LoadAssetBundle(assetBundleName);
                operation = new ABLoadLevel(assetBundleName, levelName, isAdditive);
                inProgressOperations.Add(operation);
            }

            return operation;
        }

        private void Update()
        {
            if (loadingRequest.Count > 0)
            {
                foreach (var keyValue in loadingRequest)
                {
                    var request = keyValue.Value;
                    if (request.isDone && request.assetBundle != null)
                    {
                        if (!loadedAssetBundles.ContainsKey(keyValue.Key))
                            loadedAssetBundles.Add(keyValue.Key, new LoadedAssetBundle(request.assetBundle));
                        else
                        {
                            var ab = loadedAssetBundles[keyValue.Key].AssetBundle;
                            if (ab == null)
                            {
                                loadedAssetBundles[keyValue.Key] = new LoadedAssetBundle(request.assetBundle);
                            }
                        }

                        removeList.Add(keyValue.Key);
                    }
                }

                foreach (var key in removeList)
                {
                    loadingRequest.Remove(key);
                }

                removeList.Clear();
            }

            //更新所有的操作请求
            for (int i = 0; i < inProgressOperations.Count;)
            {
                if (!inProgressOperations[i].Update())
                {
                    inProgressOperations.RemoveAt(i);
                }
                else
                    i++;
            }
        }
    }
}