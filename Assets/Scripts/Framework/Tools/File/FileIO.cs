//=====================================================
// - FileName:      FileIO.cs
// - Created:       @JCY
// - CreateTime:    2019/03/17 00:32:57
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 读取配置类的基类（主要读取Json和XML）
/// </summary>
public abstract class FileIO 
{
    /// <summary>
    /// 路径文件地址
    /// </summary>
    public string ConfigPath { set; get; }

    /// <summary>
    /// 路径文件读取
    /// </summary>
    public abstract void Read<T>(ref T data, string path = null);

    public abstract T Write<T>(T data, string path = null, bool isPrint = true);
}