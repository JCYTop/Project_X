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
    /// 一般是一些常用的资源
    /// </summary>
    [Header("常驻系统资源")] public string[] LongAssetPath;
    /// <summary>
    /// 临时加载虽场景变化的
    /// </summary>
    [Header("短柱系统资源")] public string[] ShortAssetPath;
}