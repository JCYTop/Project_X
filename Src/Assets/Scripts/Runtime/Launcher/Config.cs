//=====================================================
// - FileName:      Config.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:32:31
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : ILanucherTask
{
    public override string Name
    {
        get => "基础配置设置";
    }

    public override TaskType TaskType
    {
        get => TaskType.Config;
    }

    public override void AddTaskChild()
    {
        throw new System.NotImplementedException();
    }
}