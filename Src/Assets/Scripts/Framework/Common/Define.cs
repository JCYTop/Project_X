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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全局声明
/// </summary>
public class Define
{
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