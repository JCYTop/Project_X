//=====================================================
// - FileName:      Assets.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:31:00
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assets : ILanucherTask
{
    public override string Name
    {
        get => "资源管理启动";
    }

    public override TaskType TaskType
    {
        get => TaskType.Assets;
    }

    public override void AddTaskChild()
    {
        TaskChild1();
    }

    private void TaskChild1()
    {
        LogUtil.Log(string.Format("资源加载启动"), LogType.TaskLog);
        AssetsManager.Instance();
        AssetBundleManager.Instance();
        AssetBundleLoader.Instance();
        CalcTaskCount();
    }
}