//=====================================================
// - FileName:      CoroutineMgr.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 01:27:49
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineMgr
{
    private static CoroutineBehavior Task = CoroutineBehavior.Instance();

    public static Coroutine Start_Coroutine(IEnumerator coroutine)
    {
        return Task.StartCoroutine(coroutine);
    }
}