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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class RefreshConfig : MonoBehaviour
{
    private ABInfo config;

    public static void ResGOConfig()
    {
        //获取编辑器下所有的Tag
        var tags = UnityEditorInternal.InternalEditorUtility.tags;
        var goIndex = 0;
        var abInfo = Define.ABInfo;
        var uiDatas = new Dictionary<long, ABData>();
        var genPath = Application.dataPath + "/ABRes/";
        var filesPath = Directory.GetFiles(genPath, "*.prefab", SearchOption.AllDirectories);
        var info = "";
        for (int i = 0; i < filesPath.Length; i++)
        {
            filesPath[i] = filesPath[i].Substring(filesPath[i].IndexOf("Assets", StringComparison.Ordinal));
            var prefab = AssetDatabase.LoadAssetAtPath(filesPath[i], typeof(GameObject)) as GameObject;
            var progress = (float) i / filesPath.Length;
            EditorUtility.DisplayProgressBar("UI配置刷新进度...", info, progress);
            if (prefab != null)
            {
                var goBase = prefab.GetComponent<ObjectBase>();
                if (goBase != null && !uiDatas.ContainsKey(goBase.ID))
                {
                    var index = 1;
                    foreach (var tag in tags)
                    {
                        if (tag == goBase.ObjectType)
                        {
                            break;
                        }

                        index++;
                    }

                    goBase.ID = index * 100000 + goIndex;
                    AssetDatabase.SaveAssets();
                    string path = filesPath[i];
                    path = filesPath[i].Substring(filesPath[i].IndexOf("ABRes", StringComparison.Ordinal));
                    info = path;
                    int index1 = path.IndexOf("/", StringComparison.Ordinal);
                    int index2 = path.IndexOf(".", StringComparison.Ordinal) - 1;
                    path = path.Substring(index1 + 1, index2 - index1);
                    path = @"ABRes\" + path;
                    uiDatas.Add(goIndex, new ABData()
                    {
                        ID = goBase.ID,
                        Path = path,
                        name = goBase.gameObject.name,
                        Des = goBase.Des,
                        Type = goBase.ObjectType,
                    });
                    goIndex++;
                }
            }
        }

        if (uiDatas.Count != 0)
        {
            abInfo.UIDatas = new List<ABData>(uiDatas.Values);
            EditorUtility.SetDirty(abInfo);
            AssetDatabase.SaveAssets();
        }

        EditorUtility.ClearProgressBar();
        LogUtil.Log(string.Format("共 {0} 个GO", uiDatas.Count));
    }
}