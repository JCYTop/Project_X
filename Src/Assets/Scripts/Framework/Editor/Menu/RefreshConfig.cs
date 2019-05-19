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

public class ObjectIndex
{
    private int None = 100000;
    private int UI = 110000;
    private int Character = 120000;
    private int Camera = 130000;
    private int Trigger = 140000;
    private int GameObject = 150000;
    private int DevTool = 160000;
    private int Manager = 170000;
    private int Component = 180000;
    private int Canvas = 190000;

    public int GetIndex(ObjectTag objectTag)
    {
        int returnIndex = 0;
        switch (objectTag)
        {
            case ObjectTag.UI:
                returnIndex = UI;
                UI++;
                break;
            case ObjectTag.Character:
                returnIndex = Character;
                Character++;
                break;
            case ObjectTag.Camera:
                returnIndex = Camera;
                Camera++;
                break;
            case ObjectTag.Trigger:
                returnIndex = Trigger;
                Trigger++;
                break;
            case ObjectTag.GameObject:
                returnIndex = GameObject;
                GameObject++;
                break;
            case ObjectTag.DevTool:
                returnIndex = DevTool;
                DevTool++;
                break;
            case ObjectTag.Manager:
                returnIndex = Manager;
                Manager++;
                break;
            case ObjectTag.Canvas:
                returnIndex = Canvas;
                Canvas++;
                break;
            default:
                returnIndex = None;
                None++;
                break;
        }

        return returnIndex;
    }
}

public class RefreshConfig : MonoBehaviour
{
//    private GOConfig config;
//
//    public static void ResGOConfig()
//    {
//        ObjectIndex goindex = new ObjectIndex();
//        GOConfig uiConfig = AssetDatabase.LoadAssetAtPath<GOConfig>("Assets/ABRes/Data/GOConfig.asset");
//        Dictionary<long, GOData> uiDatas = new Dictionary<long, GOData>();
//        string genPath = Application.dataPath + "/ABRes/";
//        string[] filesPath = Directory.GetFiles(genPath, "*.prefab", SearchOption.AllDirectories);
//        string info = "";
//        for (int i = 0; i < filesPath.Length; i++)
//        {
//            filesPath[i] = filesPath[i].Substring(filesPath[i].IndexOf("Assets", StringComparison.Ordinal));
//            GameObject prefab = AssetDatabase.LoadAssetAtPath(filesPath[i], typeof(GameObject)) as GameObject;
//            var progress = (float) i / filesPath.Length;
//            EditorUtility.DisplayProgressBar("UI配置刷新进度", info, progress);
//            if (prefab != null)
//            {
//                ObjectBase goBase = prefab.GetComponent<ObjectBase>();
//                if (goBase != null && !uiDatas.ContainsKey(goBase.ID))
//                {
//                    long tmpIndex = goindex.GetIndex(goBase.ObjectType);
//                    goBase.ID = tmpIndex;
//                    AssetDatabase.SaveAssets();
//                    string path = filesPath[i];
//                    path = filesPath[i].Substring(filesPath[i].IndexOf("ABRes", StringComparison.Ordinal));
//                    info = path;
//                    int index1 = path.IndexOf("/", StringComparison.Ordinal);
//                    int index2 = path.IndexOf(".", StringComparison.Ordinal) - 1;
//                    path = path.Substring(index1 + 1, index2 - index1);
//                    path = @"ABRes\" + path;
//                    uiDatas.Add(tmpIndex, new GOData()
//                    {
//                        ID = tmpIndex,
//                        Path = path,
//                        name = goBase.gameObject.name,
//                        Des = goBase.Des,
//                    });
//                }
//            }
//        }
//
//        if (uiDatas.Count != 0)
//        {
//            uiConfig.UIDatas = new List<GOData>(uiDatas.Values);
//            EditorUtility.SetDirty(uiConfig);
//            AssetDatabase.SaveAssets();
//        }
//
//        EditorUtility.ClearProgressBar();
//        Debug.Log(string.Format("共 {0} 个GO", uiDatas.Count));
//    }
}