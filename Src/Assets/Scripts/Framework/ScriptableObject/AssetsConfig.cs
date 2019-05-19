//=====================================================
// - FileName:      AssetsConfig.cs
// - Created:       @JCY
// - CreateTime:    2019/03/31 00:52:02
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsConfig : ScriptableObject
{
    [Header("资源根目录")] public string GameResourceRootDir = "ABRes/";

    /// <summary>
    /// 添加根目录或者文件夹
    /// </summary>
    [Header("预加载系统资源")] public string[] preloadAssetPath;

    [Header("UNITY_IPHONEl资源路径")] public string UNITY_IPHONE = Application.persistentDataPath + "/AssetBundle/";
    [Header("UNITY_ANDROID资源路径")] public string UNITY_ANDROID = Application.persistentDataPath + "/AssetBundle/";
    [Header("UNITY_STANDALONE_WIN资源路径")] public string UNITY_STANDALONE_WIN = Application.dataPath + "/StreamingAssets/AssetBundle/";
    [Header("UNITY_EDITOR资源路径")] public string UNITY_EDITOR = Application.dataPath + "/StreamingAssets/AssetBundle/";
}