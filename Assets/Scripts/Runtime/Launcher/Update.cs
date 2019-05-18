//=====================================================
// - FileName:      Update.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:33:40
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Update : ILanucherTask
{
    public override string Name
    {
        get => "更新资源";
    }

    public override TaskType TaskType
    {
        get => TaskType.Update;
    }

    public override void AddTaskChild()
    {
        throw new System.NotImplementedException();
    }
}