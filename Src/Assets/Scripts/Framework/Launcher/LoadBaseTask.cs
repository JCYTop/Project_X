//=====================================================
// - FileName:      LoadBaseData.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:31:46
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using UnityEngine;

public class LoadBaseTask : ILanucherTask
{
    private GameObject excelDataMgr;
    private GameObject uiRoot;
    private GameObject graphyProfiler;

    public override string Name
    {
        get => "载入配置信息";
    }

    public override TaskType TaskType
    {
        get => TaskType.LoadBaseTask;
    }

    public override void AddTaskChild()
    {
        LogUtil.Log(string.Format(Name), LogType.TaskLog);
        StartChildTask1();
        StartChildTask2();
        StartChildTask3();
    }

    private void StartChildTask1()
    {
        AssetsManager.Instance().GetPrefabAsync("ExcelDataMgr", (prefab) =>
        {
            if (prefab != null)
            {
                excelDataMgr = EntityUtil.InstantiateGo(prefab, true);
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
                uiRoot = EntityUtil.InstantiateGo(prefab, true);
            }

            CalcTaskCount();
        });
    }

    private void StartChildTask3()
    {
        AssetsManager.Instance().GetPrefabAsync("Main Camera", (prefab) =>
        {
            if (prefab != null)
            {
                EntityUtil.InstantiateGo(prefab, false);
            }

            CalcTaskCount();
        });
    }
}