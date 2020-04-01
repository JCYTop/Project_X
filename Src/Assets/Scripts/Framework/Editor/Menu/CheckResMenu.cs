//=====================================================
// - FileName:      CheckResMenu.cs
// - Created:       @JCY
// - CreateTime:    2019/03/16 23:44:00
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Framework.Editor
{
    public class CheckResMenu : EditorMenu<CheckResMenu>
    {
        private int go_count = 0;
        private int components_count = 0;
        private int missing_count = 0;
        private List<string> mResources = new List<string>();
        private List<string> mEffectResources = new List<string>();

        public override void CreatWindow()
        {
        }

        public override void OnDisable()
        {
        }

        public override void OnEnable()
        {
        }

        public override void OnGUI()
        {
        }

        /// <summary>
        /// 找到相关的脚本引用
        /// </summary>
        public void FindMissScriptInResource()
        {
            go_count = 0;
            components_count = 0;
            missing_count = 0;
            //获取所有资源路径       
            mResources.Clear();
            //Resource资源路径
            string resourcePath = Application.dataPath + "/AssetBundleRes/";
            string[] files = Directory.GetFiles(resourcePath, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string suffix = GetFileSuffix(file);
                if (suffix == "meta")
                    continue;
                //查找预制件件
                if (suffix == "prefab")
                {
                    string realFile = file.Replace("\\", "/");
                    realFile = realFile.Replace(Application.dataPath, "Assets");
                    mResources.Add(realFile);
                }
            }

            //查找所有miss文件
            foreach (string assetPath in mResources)
            {
                GameObject asset = AssetDatabase.LoadMainAssetAtPath(assetPath) as GameObject;
                FindInGO(asset);
            }

            LogTool.Log(string.Format("Searched {0} GameObjects, {1} components, found {2} missing", go_count, components_count, missing_count),
                LogEnum.Editor);
        }

        private string GetFileSuffix(string filePath)
        {
            int index = filePath.LastIndexOf(".");
            if (-1 == index)
                throw new System.Exception("can not find Suffix!!! the filePath is : " + filePath);
            return filePath.Substring(index + 1, filePath.Length - index - 1);
        }

        private void FindInGO(GameObject g)
        {
            go_count++;
            Component[] components = g.GetComponents<Component>();
            for (int i = 0; i < components.Length; i++)
            {
                components_count++;
                if (components[i] == null)
                {
                    missing_count++;
                    string s = g.name;
                    Transform t = g.transform;
                    while (t.parent != null)
                    {
                        s = t.parent.name + "/" + s;
                        t = t.parent;
                    }

                    LogTool.Log(string.Format("{0} has an empty script attached in position: {1} {2}", s, i, g), LogEnum.Editor);
                }
            }

            // LocalNow recurse through each child GO (if there are any):
            foreach (Transform childT in g.transform)
            {
                FindInGO(childT.gameObject);
            }
        }

        /// <summary>
        /// 检查材质引用
        /// </summary>
        public void CheckMaterialReference()
        {
            Object[] objects = Selection.objects;
            if (objects.Length != 1)
            {
                EditorUtility.DisplayDialog("Error", "you should select one items", "ok");
                return;
            }

            Object obj = objects[0];
            Material mat = obj as Material;
            if (mat == null)
            {
                EditorUtility.DisplayDialog("Error", "you should select material", "ok");
                return;
            }

            string matPath = AssetDatabase.GetAssetPath(mat);
            //获取所有资源路径       
            mResources.Clear();
            //Resource资源路径
            string resourcePath = Application.dataPath + "/Resources/";
            string[] files = Directory.GetFiles(resourcePath, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string suffix = GetFileSuffix(file);
                if (suffix == "meta")
                    continue;
                //查找预制件件
                if (suffix == "prefab")
                {
                    string realFile = file.Replace("\\", "/");
                    realFile = realFile.Replace(Application.dataPath, "Assets");
                    mResources.Add(realFile);
                }
            }

            //查找所有引用该Material的文件
            foreach (string assetPath in mResources)
            {
                //获取包含的所有依赖
                string[] depencies = AssetDatabase.GetDependencies(new string[] {assetPath});
                foreach (string dep in depencies)
                {
                    //如果是材质
                    if (dep.EndsWith(".mat") && matPath == dep)
                    {
                        LogTool.Log(string.Format("{0} is referenced by {1}", mat.name, assetPath));
                    }
                }
            }
        }

        /// <summary>
        /// 检测Resource资源中的Effect是否有效
        /// </summary>
        public void CheckEffectInResource()
        {
            //获取所有资源路径       
            mEffectResources.Clear();
            //Resource资源路径
            string resourcePath = Application.dataPath + "/Resources/effect";
            string[] files = Directory.GetFiles(resourcePath, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string suffix = GetFileSuffix(file);
                if (suffix == "meta")
                    continue;
                //查找预制件件
                if (suffix == "prefab")
                {
                    string realFile = file.Replace("\\", "/");
                    realFile = realFile.Replace(Application.dataPath, "Assets");
                    mEffectResources.Add(realFile);
                }
            }

            LogTool.Log(string.Format("Check finised!"), LogEnum.NormalLog);
        }
    }
}