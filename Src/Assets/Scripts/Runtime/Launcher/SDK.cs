//=====================================================
// - FileName:      SDK.cs
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

public class SDK : ILanucherTask
{
    public override string Name
    {
        get => "SDK处理";
    }

    public override TaskType TaskType
    {
        get => TaskType.SDK;
    }

    public override void AddTaskChild()
    {
        throw new System.NotImplementedException();
    }
}