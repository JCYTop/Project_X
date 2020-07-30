//=====================================================
// - FileName:      FileUtils.cs
// - Created:       @JCY
// - CreateTime:    2019/03/17 00:39:32
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileUtils
{
    /// <summary>
    /// 读取Json文件
    /// </summary>
    /// <typeparam name="T">返回对象类型</typeparam>
    /// <param name="path">文件路径</param>
    /// <returns>返回模型对象</returns>
    public static T JsonFile<T>(string path, JSonUtilType jSonUtilType = JSonUtilType.JsonUtility)
    {
        return JSonIO.Instance(jSonUtilType).Read<T>(path);
    }

    /// <summary>
    /// 读取Json文件
    /// </summary>
    /// <typeparam name="T">返回对象类型</typeparam>
    /// <param name="data">文件数据</param>
    /// <returns>返回模型对象</returns>
    public static T ReadJsonData<T>(string data, JSonUtilType jSonUtilType = JSonUtilType.JsonUtility)
    {
        return JSonIO.Instance(jSonUtilType).ReadData<T>(data);
    }

    public static T JsonWrite<T>(T data, string path, bool isPrint = true)
    {
        return JSonIO.Instance().Write<T>(data, path);
    }
}