//=====================================================
// - FileName:      AssetsManager.cs
// - Created:       @JCY
// - CreateTime:    2019/03/31 00:56:12
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsManager : MonoBehaviour
{
    private static AssetsManager instance;
    private string GameResourceRootDir;
    private string[] LongAssetPath;
    private string[] ShortAssetPath;

    public static AssetsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = SingletonProperty<AssetsManager>.Instance();
            }

            return instance;
        }
    }

    private void Awake()
    {
        //读取资源配置信息
        var assetsConfig = Resources.Load<AssetsConfig>("Configuation/AssetsConfig");
        GameResourceRootDir = assetsConfig.GameResourceRootDir;
        LongAssetPath = assetsConfig.LongAssetPath;
        ShortAssetPath = assetsConfig.ShortAssetPath;
    }
}