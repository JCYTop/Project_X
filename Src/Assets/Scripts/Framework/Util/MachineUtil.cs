/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     MachineUtil
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/09/25 23:42:22
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using UnityEngine;

/// <summary>
/// 机器配置设定工具类,一些配置机器相关基础配置
/// </summary>
public static class MachineUtil
{
    public static RenderTexture RenderTexture { set; get; }
    private static int resolutionWidth;
    private static int resolutionHeight;

    #region 属性

    /// <summary>
    /// 实际设备分辨率
    /// </summary>
    public static Vector2 ScreenWH
    {
        get => new Vector2(Screen.width, Screen.height);
    }

    /// <summary>
    /// 基准默认屏幕比例
    /// </summary>
    public static float DefaultProportion
    {
        get => ResolutionWidth * 1f / ResolutionHeight; //1.777
    }

    /// <summary>
    /// 获取设置程序分辨率，游戏设置 直接影响
    /// </summary>
    public static int ResolutionWidth
    {
        set { resolutionWidth = value; }
        get { return resolutionWidth; }
    }

    /// <summary>
    /// 获取设置程序分辨率，游戏设置 直接影响
    /// </summary>
    public static int ResolutionHeight
    {
        set { resolutionHeight = value; }
        get { return resolutionHeight; }
    }

    /// <summary>
    /// 设置帧率
    /// </summary>
    /// <param name="voId"></param>
    public static int RefreshFrameRate
    {
        get { return Application.targetFrameRate; }
        set
        {
            try
            {
                Application.targetFrameRate = value;
            }
            catch (Exception e)
            {
                LogUtil.LogException(e);
            }
        }
    }

    #endregion

    /// <summary>
    /// 设置分辨率
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="fullscreen"></param>
    public static void Resolution(int width, int height, bool fullscreen = true)
    {
        ResolutionWidth = width;
        ResolutionHeight = height;
        var tmp = true;
        UtilMgr.Instance().AddFixedUpdate(() =>
        {
            if (tmp)
            {
                tmp = false;
                Screen.SetResolution(ResolutionWidth, ResolutionHeight, fullscreen);
            }
        });
        RenderTexture = new RenderTexture(ResolutionWidth, ResolutionHeight, 24);
        if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.RGB111110Float))
        {
            RenderTexture.format = RenderTextureFormat.RGB111110Float;
        }
    }

    /// <summary>
    /// 设置分辨率
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="fullscreen"></param>
    /// <param name="frame"></param>
    public static void Resolution(int width, int height, bool fullscreen = true, int frame = 60)
    {
        ResolutionWidth = width;
        ResolutionHeight = height;
        RefreshFrameRate = frame;
        var tmp = true;
        UtilMgr.Instance().AddFixedUpdate(() =>
        {
            if (tmp)
            {
                tmp = false;
                Screen.SetResolution(ResolutionWidth, ResolutionHeight, fullscreen, frame);
            }
        });
        RenderTexture = new RenderTexture(ResolutionWidth, ResolutionHeight, 24);
        if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.RGB111110Float))
        {
            RenderTexture.format = RenderTextureFormat.RGB111110Float;
        }
    }

    /// <summary>
    /// 设置比例
    /// </summary>
    public static Vector2 RawImageScale()
    {
        var screenProportion = new Vector2();
        try
        {
            var proportion = (ScreenWH.x * 1f / ScreenWH.y) / DefaultProportion;
            if (proportion / 1 >= 1)
            {
                screenProportion = new Vector2(1, proportion);
            }
            else
            {
                screenProportion = new Vector2(1f / proportion, 1);
            }

            return screenProportion;
        }
        catch (Exception e)
        {
            LogUtil.LogException(e);
            throw;
        }
    }
}