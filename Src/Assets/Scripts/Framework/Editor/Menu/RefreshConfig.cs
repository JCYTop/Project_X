//=====================================================
// - FileName:      RefreshConfig.cs
// - Created:       @JCY
// - CreateTime:    2019/03/17 00:01:36
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Framework.Base;
using Framework.ScriptableObject;
using UnityEditor;
using UnityEngine;

namespace Framework.Editor
{
    public class RefreshConfig : MonoBehaviour
    {
        private ABInfo config;

        public static void ResGOConfig()
        {
            //获取编辑器下所有的Tag
            var tags = UnityEditorInternal.InternalEditorUtility.tags;
            var layers = UnityEditorInternal.InternalEditorUtility.layers;
            var abInfo = GlobalDefine.ABInfo;
            var 资源Datas = new Dictionary<long, ABData>();
            var genPath = Application.dataPath + "/Addressable Asset/";
            var filesPath = Directory.GetFiles(genPath, "*.prefab", SearchOption.AllDirectories);
            var info = "";
            var presenceResID = new HashSet<long>();
            var presenceResName = new HashSet<string>();
            for (int i = 0; i < filesPath.Length; i++)
            {
                filesPath[i] = filesPath[i].Substring(filesPath[i].IndexOf("Assets", StringComparison.Ordinal));
                var prefab = AssetDatabase.LoadAssetAtPath(filesPath[i], typeof(GameObject)) as GameObject;
                var progress = (float) i / filesPath.Length;
                EditorUtility.DisplayProgressBar("资源记录已知ResID进度...", info, progress);
                if (prefab != null)
                {
                    var goBase = prefab.GetComponent<ObjectBase>();
                    if (goBase != null)
                    {
                        if (goBase.ResID > 0 && goBase.ResID / 10000000 <= 0)
                        {
                            presenceResID.Add(goBase.ResID);
                        }
                        else
                        {
                            goBase.ResID = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < filesPath.Length; i++)
            {
                var goIndex = 0;
                filesPath[i] = filesPath[i].Substring(filesPath[i].IndexOf("Assets", StringComparison.Ordinal));
                var prefab = AssetDatabase.LoadAssetAtPath(filesPath[i], typeof(GameObject)) as GameObject;
                var progress = (float) i / filesPath.Length;
                EditorUtility.DisplayProgressBar("资源配置刷新进度...", info, progress);
                if (prefab != null)
                {
                    var goBase = prefab.GetComponent<ObjectBase>();
                    if (goBase != null && !资源Datas.ContainsKey(goBase.ResID))
                    {
                        var indexTag = 0;
                        foreach (var tag in tags)
                        {
                            if (tag == goBase.ObjectTag)
                            {
                                break;
                            }

                            indexTag++;
                        }

                        var indexLayer = 0;
                        var tmpLayer = layers[0];
                        for (int j = 0; j < goBase.ObjectLayer; j++)
                        {
                            indexLayer++;
                            tmpLayer = layers[j];
                        }

                        var resID = 0;
                        if (presenceResID.Contains(goBase.ResID))
                        {
                            resID = goBase.ResID;
                        }
                        else
                        {
                            resID = +indexTag * 100000 + goIndex;
                            var reCreateIndex = true;
                            while (reCreateIndex)
                            {
                                if (goIndex > 100000)
                                {
                                    throw new Exception("超过判断");
                                }

                                if (presenceResID.Add(resID))
                                {
                                    reCreateIndex = false;
                                }
                                else
                                {
                                    goIndex++;
                                    resID = +indexTag * 100000 + goIndex;
                                }
                            }
                        }

                        goBase.ResID = resID;
                        goBase.BaseName = goBase.gameObject.name;
                        AssetDatabase.SaveAssets();
                        var path = filesPath[i];
                        path = filesPath[i].Substring(filesPath[i].IndexOf("Addressable Asset", StringComparison.Ordinal));
                        info = path;
                        var index1 = path.IndexOf("/", StringComparison.Ordinal);
                        var index2 = path.IndexOf(".", StringComparison.Ordinal) - 1;
                        path = path.Substring(index1 + 1, index2 - index1);
                        path = @"Assets\Addressable Asset\" + path;
                        资源Datas.Add(goBase.ResID, new ABData()
                        {
                            ID = goBase.ResID,
                            Path = path,
                            name = goBase.BaseName,
                            Des = goBase.Des,
                            Layer = tmpLayer,
                            Tag = goBase.ObjectTag,
                        });
                        goIndex++;
                        if (presenceResName.Contains(goBase.gameObject.name))
                        {
                            EditorUtility.ClearProgressBar();
                            LogTool.LogError(string.Format("资源命名重复:重复名---> {0}", goBase.gameObject.name), LogEnum.AssetLog);
                            return;
                        }
                        else
                        {
                            presenceResName.Add(goBase.gameObject.name);
                        }
                    }
                }
            }

            if (资源Datas.Count != 0)
            {
                abInfo.ABDatas = new List<ABData>(资源Datas.Values);
                abInfo.ABDatas.Sort((x, y) => x.ID.CompareTo(y.ID));
                EditorUtility.SetDirty(abInfo);
                AssetDatabase.SaveAssets();
            }

            EditorUtility.ClearProgressBar();
            LogTool.Log($"共产生 {资源Datas.Count} 个GO", LogEnum.Editor);
        }

        public static void CleanResGOConfig()
        {
            var genPath = Application.dataPath + "/Addressable Asset/";
            var filesPath = Directory.GetFiles(genPath, "*.prefab", SearchOption.AllDirectories);
            var info = "";
            var index = 0;
            for (int i = 0; i < filesPath.Length; i++)
            {
                filesPath[i] = filesPath[i].Substring(filesPath[i].IndexOf("Assets", StringComparison.Ordinal));
                var prefab = AssetDatabase.LoadAssetAtPath(filesPath[i], typeof(GameObject)) as GameObject;
                var progress = (float) i / filesPath.Length;
                EditorUtility.DisplayProgressBar("资源配置清除进度...", info, progress);
                if (prefab != null)
                {
                    var goBase = prefab.GetComponent<ObjectBase>();
                    if (goBase != null)
                    {
                        goBase.ResID = 0;
                        index++;
                    }
                }
            }

            EditorUtility.ClearProgressBar();
            LogTool.Log($"共清除 {index} 个GO", LogEnum.Editor);
        }
    }
}