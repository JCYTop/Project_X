/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     SettingDataMgr
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/09/28 16:15:16
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using UnityEngine;

/// <summary>
/// 一些基础数据存储使用
/// </summary>
public class SettingDataMgr : MonoSingleton<SettingDataMgr>
{
    public const string ResolutionWidth = "ResolutionWidth";
    public const string ResolutionHeight = "ResolutionHeight";
    public const string FrameRate = "FrameRate";
    public const string Fullscreen = "Fullscreen";

    #region Func

    public int GetSettingInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public int SetSettingInt(string key, int value)
    {
        var original = GetSettingInt(key);
        if (original != value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        return value;
    }

    public float GetSettingFloat(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }

    public float SetSettingFloat(string key, float value)
    {
        var original = GetSettingFloat(key);
        if (original != value)
        {
            PlayerPrefs.SetFloat(key, value);
        }

        return value;
    }

    public string GetSettingString(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public string SetSettingString(string key, string value)
    {
        var original = GetSettingString(key);
        if (original != value)
        {
            PlayerPrefs.SetString(key, value);
        }

        return value;
    }

    #endregion
}