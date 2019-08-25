//=====================================================
// - FileName:      PreloadingTask.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:33:49
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreloadingTask : ILanucherTask
{
    public override string Name
    {
        get => "进行预加载";
    }

    public override TaskType TaskType
    {
        get => TaskType.PreloadingTask;
    }

    public override void AddTaskChild()
    {
        LogUtil.Log(string.Format(Name), LogType.TaskLog);
        CalcTaskCount();
    }
}