//=====================================================
// - FileName:      TaskBehavior.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 01:26:59
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBehavior : MonoBehaviour
{
    private static TaskBehavior instance;

    public static TaskBehavior Instance()
    {
        if (instance == null)
        {
            instance = MonoSingletonProperty<TaskBehavior>.Instance();
        }

        return instance;
    }
}