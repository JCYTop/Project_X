//=====================================================
// - FileName:      CheckLoadMode.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:32:14
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLoadMode : ILanucherTask
{
    public override string Name
    {
        get => "检查登陆模式";
    }

    public override TaskType TaskType
    {
        get => TaskType.CheckLoadMode;
    }

    public override void AddTaskChild()
    {
        LogUtil.Log(string.Format(Name), LogType.TaskLog);
        CalcTaskCount();
    }
}