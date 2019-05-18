//=====================================================
// - FileName:      JSonIO.cs
// - Created:       @JCY
// - CreateTime:    2019/03/17 00:35:07
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public enum JSonUtilType
{
    JsonUtility = 0,
    JsonConvert,
}

public class JSonIO : FileIO
{
    private JSonUtilType jSonUtilType;
    private static JSonIO instance;

    public static JSonIO Instance(JSonUtilType jSonUtilType = JSonUtilType.JsonUtility)
    {
        if (instance == null)
        {
            instance = SingletonProperty<JSonIO>.Instance();
            instance.jSonUtilType = jSonUtilType;
        }

        return instance;
    }

    /// <summary>
    /// 读取JSon文件信息
    /// </summary>
    /// <typeparam name="T">需要输出的类型</typeparam>
    /// <param name="data">输入指定的参数</param>
    public override void Read<T>(ref T data, string path)
    {
        ConfigPath = path;
        if (!File.Exists(ConfigPath))
        {
            Debug.LogError("并未读取到" + ConfigPath + "路径");
            return;
        }

        using (StreamReader sr = new StreamReader(ConfigPath))
        {
            string json = sr.ReadToEnd();
            if (json.Length > 0)
            {
                if (jSonUtilType == JSonUtilType.JsonUtility)
                    data = JsonUtility.FromJson<T>(json);
                else
                    data = JsonConvert.DeserializeObject<T>(json);
            }
        }
    }

    /// <summary>
    /// 读取JSon文件信息
    /// </summary>
    /// <typeparam name="T">需要输出的类型</typeparam>
    /// <param name="data">输入指定的参数</param>
    public T Read<T>(string path)
    {
        ConfigPath = path;
        if (!File.Exists(ConfigPath))
        {
            Debug.LogError("并未读取到" + ConfigPath + "路径");
            return default(T);
        }

        using (StreamReader sr = new StreamReader(ConfigPath))
        {
            string json = sr.ReadToEnd();
            if (json.Length > 0)
            {
                if (jSonUtilType == JSonUtilType.JsonUtility)
                    return JsonUtility.FromJson<T>(json);
                else
                    return JsonConvert.DeserializeObject<T>(json);
            }
        }

        return default(T);
    }

    /// <summary>
    /// 读取JSon文件信息
    /// </summary>
    /// <typeparam name="T">需要输出的类型</typeparam>
    /// <param name="data">输入数据</param>
    public T ReadData<T>(string data)
    {
        if (data.Length > 0)
        {
            if (jSonUtilType == JSonUtilType.JsonUtility)
                return JsonUtility.FromJson<T>(data);
            else
                return JsonConvert.DeserializeObject<T>(data);
        }

        return default(T);
    }

    public T ReadsssData<T>(string data)
    {
        return JsonConvert.DeserializeObject<T>(data);
    }

    public override T Write<T>(T data, string path, bool isPrint = true)
    {
        ConfigPath = path;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
        T outInfo = JsonUtility.FromJson<T>(json);
        return outInfo;
    }
}