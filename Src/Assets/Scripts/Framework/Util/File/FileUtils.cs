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

public class FileUtils : MonoBehaviour
{
    /// <summary>
    /// 读取Json文件
    /// </summary>
    /// <typeparam name="T">返回对象类型</typeparam>
    /// <param name="path">文件路径</param>
    /// <returns>返回模型对象</returns>
    public static T JsonFile<T>(string path, JSonUtilType jSonUtilType = JSonUtilType.JsonUtility)
    {
        return JSonIO.Instance(jSonUtilType).Read<T>(ReadTextFromFile(path));
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

    /// <summary>
    /// 从文件中读取文本数据
    /// </summary>
    /// <param name="path">相对路径</param>
    /// <returns></returns>
    public static string ReadTextFromFile(string path)
    {
        string content = "";
        string fullPath = GetFilePath(path);
        try
        {
            content = File.ReadAllText(fullPath);
        }
        catch
        {
            LogUtil.Log(String.Format(" 没有找到文件 {0}", fullPath), LogType.NormalLog);
        }

        return content;
    }

    public static string GetFilePath(string path)
    {
        //TODO 补充
//#if UNITY_EDITOR
//        return Define.streamingPath + "/" + path;
//#else
//        return Define.persistenPath + "/" + path;
//#endif
        return default;
    }
}