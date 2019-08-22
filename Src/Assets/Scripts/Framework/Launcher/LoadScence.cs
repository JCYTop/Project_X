//=====================================================
// - FileName:      LoadScence.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:33:57
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScence : ILanucherTask
{
    public override string Name
    {
        get => "进入游戏场景";
    }

    public override TaskType TaskType
    {
        get => TaskType.LoadScence;
    }

    public override void AddTaskChild()
    {
        LogUtil.Log(string.Format(Name), LogType.TaskLog);
        CalcTaskCount();
    }
}