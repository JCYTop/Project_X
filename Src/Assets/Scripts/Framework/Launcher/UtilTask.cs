//=====================================================
// - FileName:      LoadScenceTask.cs
// - Created:       @JCY
// - CreateTime:    2019/08/22 22:56:57
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using UnityEngine;

public class UtilTask : ILanucherTask
{
    private GameObject langSetting;

    public override string Name
    {
        get => "载入工具类";
    }

    public override TaskType TaskType
    {
        get => TaskType.UtilTask;
    }

    public override void AddTaskChild()
    {
        LogUtil.Log(string.Format(Name), LogType.TaskLog);
        StartChildTask1();
    }

    private void StartChildTask1()
    {
        AssetsManager.Instance().GetPrefabAsync("LangSetting", (prefab) =>
        {
            if (prefab != null)
            {
                langSetting = EntityUtil.InstantiateGo(prefab, true);
            }

            CalcTaskCount();
        });
    }
}