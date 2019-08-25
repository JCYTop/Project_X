//=====================================================
// - FileName:      GetObjectPath.cs
// - Created:       @JCY
// - CreateTime:    2019/03/19 00:06:39
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
using UnityEngine.UI;

public class GetObjectPath : Editor
{
    private static TextEditor textEditor;

    public static void GetAssetsPath()
    {
        var arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.TopLevel);
        var path = AssetDatabase.GetAssetPath(arr[0])+"/";
        path = path.Replace("AssetsTask/", "");
        SaveToClipBoard(path);
        //下面是绝对路径
        //Debug.LogError(Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')) + "/" + AssetDatabase.GetAssetPath(arr[0]));
    }


    public static void SaveToClipBoard(string content)
    {
        if (textEditor == null)
        {
            textEditor = new TextEditor();
        }

        textEditor.text = content;
        textEditor.OnFocus();
        textEditor.Copy();
    }
}