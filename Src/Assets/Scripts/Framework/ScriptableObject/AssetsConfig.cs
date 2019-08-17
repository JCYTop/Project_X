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
using Sirenix.OdinInspector;
using UnityEngine;

public class AssetsConfig : ScriptableObject
{
    [InfoBox("资源根目录")] public string GameResourceRootDir = "ABRes/";
    [InfoBox("AuthorInfo路径")] public string AuthorInfoPath = string.Empty;
    [InfoBox("FrameworkDefine路径")] public string FrameworkDefinePath = string.Empty;
    [InfoBox("LogConfig路径")] public string LogConfigPath = string.Empty;
    [InfoBox("ABInfo路径")] public string ABInfoPath = string.Empty;
    [InfoBox("Scence场景所在文件夹")] public string ScencePath = string.Empty;

    /// <summary>
    /// 添加根目录或者文件夹
    /// </summary>
    [InfoBox("预加载系统资源")] public string[] preloadAssetPath;
}