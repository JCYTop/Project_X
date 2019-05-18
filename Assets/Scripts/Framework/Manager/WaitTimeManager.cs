//=====================================================
// - FileName:      WaitTimeManager.cs
// - Created:       @JCY
// - CreateTime:    2019/03/17 23:15:22
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaitTimeManager
{
    private static CoroutineBehavior Task = CoroutineBehavior.Instance();

    public static Coroutine WaitTime(float time, UnityAction callback)
    {
        return Task.StartCoroutine(Coroutine(time, callback));
    }

    public static void CancelWaitWait(ref Coroutine coroutine)
    {
        if (coroutine != null)
        {
            Task.StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    public static IEnumerator Coroutine(float time, UnityAction callback)
    {
        yield return new WaitForSeconds(time);
        if (callback != null)
        {
            callback();
        }
    }
}