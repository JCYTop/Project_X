using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugExtension
{
    /// <summary>
    /// 带有颜色区别的输出日志
    /// </summary>
    /// <param name="str">输入内容</param>
    /// <param name="logType">颜色类型</param>
    public static void Log(object str, Color logColor)
    {
        string color = ColorUtility.ToHtmlStringRGB(logColor);
        str = "<color=" + "#" + color + ">" + str + "</color>";
        Debug.Log(str);
    }

    /// <summary>
    /// 带有颜色区别的输出警告
    /// </summary>
    /// <param name="str">输入内容</param>
    /// <param name="logType">颜色类型</param>
    public static void LogWarning(object str, Color logColor)
    {
        string color = ColorUtility.ToHtmlStringRGB(logColor);
        str = "<color=" + "#" + color + ">" + str + "</color>";
        Debug.LogWarning(str);
    }

    /// <summary>
    /// 带有颜色区别的输出错误
    /// </summary>
    /// <param name="str">输入内容</param>
    /// <param name="logType">颜色类型</param>
    public static void LogError(object str, Color logColor)
    {
        string color = ColorUtility.ToHtmlStringRGB(logColor);
        str = "<color=" + "#" + color + ">" + str + "</color>";
        Debug.LogError(str);
    }

    /// <summary>
    /// Debug暂停
    /// </summary>
    public static void LogPause(this Debug debug)
    {
        DebugExtension.Log("暂停", Color.yellow);
        Debug.Break();
    }

    /// <summary>
    /// Log屏幕清理
    /// </summary>
    public static void LogClean(this Debug debug)
    {
        Debug.ClearDeveloperConsole();
        DebugExtension.Log("清理日志", Color.yellow);
    }
}