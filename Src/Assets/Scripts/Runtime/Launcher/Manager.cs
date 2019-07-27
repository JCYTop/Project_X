//=====================================================
// - FileName:      Manager.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:31:17
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : ILanucherTask
{
    private GameObject gm;
    private GameObject globalEvent;

    public override string Name
    {
        get => "基础Manager启动";
    }

    public override TaskType TaskType
    {
        get => TaskType.Manager;
    }

    public override void AddTaskChild()
    {
        LogUtil.Log(string.Format(Name), LogType.TaskLog);
        StartChildTask();
    }

    private void StartChildTask()
    {
        gm = GOCommonUtil.CreateGameobject("GM", false);
        gm.AddComponent<GM>();
        globalEvent = GOCommonUtil.CreateGameobject("GlobalEvent", false);
        globalEvent.AddComponent<GlobalEvent>();
    }
}