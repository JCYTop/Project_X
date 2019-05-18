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

public class CoroutineBehavior : MonoBehaviour
{
    private static CoroutineBehavior instance;

    public static CoroutineBehavior Instance()
    {
        if (instance == null)
        {
            instance = MonoSingletonProperty<CoroutineBehavior>.Instance();
        }

        return instance;
    }
}