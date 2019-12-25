/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     LogUtil
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/19 00:51:02
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using Framework.ScriptableObject;
using UnityEngine;

public static class LogUtil
{
    private const string DefaultStr = "[Log...] : ";
    private static LogConfig config = null;

    private static LogConfig Config
    {
        get
        {
            if (config == null)
            {
                config = GlobalDefine.LogConfig;
            }

            return config;
        }
    }

    public static bool IsLogOpen
    {
        get { return Config != null && Config.All; }
    }

    public static string GetLogDesc(LogData data)
    {
        if (data == null || data.LogType == LogType.NormalLog)
        {
            return DefaultStr;
        }

        return data.GetLogColorStr;
    }

    public static void LogException(Exception exception, LogType type = LogType.NormalLog)
    {
        if (Config == null || !Config.All)
        {
            return;
        }

        LogData data = Config == null ? null : Config.LogDatas.Find((d) => d.LogType == type);
        if (data == null)
            return;
        LogStr(GetLogDesc(data) + exception, true);
    }

    public static void Log(string logStr, LogType type = LogType.NormalLog)
    {
        LogData data = Config == null ? null : Config.LogDatas.Find((d) => d.LogType == type);
        if (data == null || !data.Show)
            return;
        LogStr(GetLogDesc(data) + logStr, false);
    }

    public static void LogError(string logStr, LogType type = LogType.NormalLog)
    {
        if (Config == null || !Config.All)
        {
            return;
        }

        LogData data = Config == null ? null : Config.LogDatas.Find((d) => d.LogType == type);
        if (data == null)
            return;
        LogStr(GetLogDesc(data) + logStr, true);
    }

    public static void Log(string logStr, Color color, bool isError = false)
    {
        string c = ColorUtility.ToHtmlStringRGB(color);
        LogStr(string.Format("<color=#{0}>[log...] : {1}</color>", c, logStr), isError);
    }

    private static void LogStr(string str, bool isError)
    {
        if (Config == null || !Config.All)
        {
            return;
        }

        if (isError)
        {
            Debug.LogError((TimeUtil.LocalNow) + "-" + str);
        }
        else
        {
            Debug.Log((TimeUtil.LocalNow) + "-" + str);
        }
    }
}