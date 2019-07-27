//=====================================================
// - FileName:      LoadBaseData.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:31:46
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBase : ILanucherTask
{
    private GameObject langSetting;
    private GameObject uiRoot;
    private GameObject graphyProfiler;

    public override string Name
    {
        get => "载入配置信息";
    }

    public override TaskType TaskType
    {
        get => TaskType.LoadBase;
    }

    public override void AddTaskChild()
    {
        LogUtil.Log(string.Format(Name), LogType.TaskLog);
        StartChildTask1();
        StartChildTask2();
    }

    private void StartChildTask1()
    {
        AssetsManager.Instance().GetPrefabAsync("LangSetting", (prefab) =>
        {
            if (prefab != null)
            {
                langSetting = GOCommonUtil.InstantiateGo(prefab, true);
            }

            CalcTaskCount();
        });
    }

    private void StartChildTask2()
    {
        AssetsManager.Instance().GetPrefabAsync("UIRoot", (prefab) =>
        {
            if (prefab != null)
            {
                uiRoot = GOCommonUtil.InstantiateGo(prefab, true);
            }

            CalcTaskCount();
        });
    }
}