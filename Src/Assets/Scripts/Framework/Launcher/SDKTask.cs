//=====================================================
// - FileName:      SDKTask.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:32:48
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDKTask : ILanucherTask
{
    public override string Name
    {
        get => "SDK处理";
    }

    public override TaskType TaskType
    {
        get => TaskType.SDKTask;
    }

    public override void AddTaskChild()
    {
        LogUtil.Log(string.Format(Name), LogType.TaskLog);
        CalcTaskCount();
    }
}