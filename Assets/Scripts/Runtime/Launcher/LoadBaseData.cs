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

public class LoadBaseData : ILanucherTask
{
    public override string Name
    {
        get => "载入配置信息";
    }

    public override TaskType TaskType
    {
        get => TaskType.LoadBaseData;
    }

    public override void AddTaskChild()
    {
        throw new System.NotImplementedException();
    }
}