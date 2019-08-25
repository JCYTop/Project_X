/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Define
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/19 20:51:37
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using UnityEngine;

/// <summary>
/// 全局声明,基础配置序列化文件
/// </summary>
public class Define
{
    #region 字段

    private static AssetsConfig assetsConfig;
    private static AuthorInfo authorInfo;
    private static FrameworkDefine frameworkDefine;
    private static LogConfig logConfig;
    private static ABInfo abInfo;

    #endregion

    #region 属性

    public static AssetsConfig AssetsConfig
    {
        get
        {
            if (assetsConfig == null)
            {
                assetsConfig = Resources.Load<AssetsConfig>("Configuation/AssetsConfig");
            }

            return assetsConfig;
        }
    }

    public static AuthorInfo AuthorInfo
    {
        get
        {
            if (authorInfo == null)
            {
                authorInfo = Resources.Load<AuthorInfo>(AssetsConfig.AuthorInfoPath);
            }

            return authorInfo;
        }
    }

    public static FrameworkDefine FrameworkDefine
    {
        get
        {
            if (frameworkDefine == null)
            {
                frameworkDefine = Resources.Load<FrameworkDefine>(AssetsConfig.FrameworkDefinePath);
            }

            return frameworkDefine;
        }
    }

    public static LogConfig LogConfig
    {
        get
        {
            if (logConfig == null)
            {
                logConfig = Resources.Load<LogConfig>(AssetsConfig.LogConfigPath);
            }

            return logConfig;
        }
    }

    public static ABInfo ABInfo
    {
        get
        {
            abInfo = Resources.Load<ABInfo>(AssetsConfig.ABInfoPath);
            return abInfo;
        }
    }

    #endregion

    /// <summary>
    /// 加载资源根目录
    /// </summary>
    public static string LoadResRootPath
    {
        get
        {
#if UNITY_IPHONE && !UNITY_EDITOR
            return Application.persistentDataPath + "/AssetBundle/";
#elif UNITY_ANDROID && !UNITY_EDITOR
            return Application.persistentDataPath + "/AssetBundle/";
#elif UNITY_STANDALONE_WIN && !UNITY_EDITOR
            return Application.dataPath + "/StreamingAssets/AssetBundle/";
#endif
            return Application.dataPath + "/ABRes/";
        }
    }
}