//=====================================================
// - FileName:      CheckMemory.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:31:32
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMemory : ILanucherTask
{
    public override string Name
    {
        get => "检查内存";
    }

    public override TaskType TaskType
    {
        get => TaskType.CheckMemory;
    }

    public override void AddTaskChild()
    {
        throw new System.NotImplementedException();
    }
}