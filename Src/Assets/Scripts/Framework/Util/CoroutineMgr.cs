//=====================================================
// - FileName:      CoroutineMgr.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 01:27:49
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineMgr : MonoSingleton<CoroutineMgr>
{
    private Dictionary<string, CoroutineTask> ima = new Dictionary<string, CoroutineTask>();

    /// <summary>
    /// 启用一个协程 
    /// </summary>
    /// <param name="coroutine"></param>
    /// <returns></returns>
    public Coroutine StartUpCoroutine(string name, IEnumerator coroutine)
    {
        var task = new CoroutineTask(name, coroutine);
        return StartCoroutine(task.Task);
    }

    /// <summary>
    /// 启用一个协程
    /// </summary>
    /// <param name="coroutine"></param>
    /// <returns></returns>
    public Coroutine StartUpCoroutine(IEnumerator coroutine)
    {
        return StartCoroutine(coroutine);
    }

    /// <summary>
    /// 启用一个协程
    /// </summary>
    /// <param name="ima"></param>
    /// <returns></returns>
    public Coroutine StartUpCoroutine(CoroutineTask task)
    {
        ima.Add(task.Name, task);
        return StartCoroutine(task.Task);
    }

    /// <summary>
    /// 启用一个协程
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Coroutine StartUpCoroutine(string name)
    {
        Coroutine task = null;
        if (ima.ContainsKey(name))
        {
            task = StartCoroutine(ima[name].Task);
        }

        return task;
    }

    /// <summary>
    /// 设置一个时间迭代器
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public IEnumerator CretarTask(float duration, Action callback)
    {
        return CretarTask(duration, false, callback);
    }

    /// <summary>
    /// 时间迭代器具体方法
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="repeat"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public IEnumerator CretarTask(float duration, bool repeat, Action callback)
    {
        do
        {
            yield return new WaitForSeconds(duration);
            if (callback != null)
                callback();
        } while (repeat);
    }

    /// <summary>
    /// 计时有限次运行
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="count"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public IEnumerator CretarTask(float duration, int count, Action callback)
    {
        do
        {
            yield return new WaitForSeconds(duration);
            count--;
            if (callback != null)
                callback();
        } while (count > 0);
    }

    /// <summary>
    /// 等待结束本帧调用
    /// </summary>
    /// <param name="callback"></param>
    /// <returns></returns>
    public IEnumerator CretarTask(Action callback)
    {
        yield return new WaitForEndOfFrame();

        if (callback != null)
            callback();
    }

    /// <summary>
    /// 停止当前的协程
    /// </summary>
    /// <param name="name"></param>
    public bool StopCurrCoroutine(string name)
    {
        if (ima.ContainsKey(name))
        {
            StopCoroutine(ima[name].Task);
            return true;
        }

        return false;
    }

    /// <summary>
    /// 停止所有协程
    /// </summary>
    public void StopAllCoroutine()
    {
        foreach (var task in ima)
        {
            StopCurrCoroutine(task.Key);
        }
    }

    /// <summary>
    /// 删除当前的协程
    /// </summary>
    /// <param name="name"></param>
    public void CleanCurrCoroutine(string name)
    {
        var isRun = StopCurrCoroutine(name);
        if (isRun)
        {
            ima.Remove(name);
        }
    }

    /// <summary>
    /// 清除所有线程
    /// </summary>
    public void CleanAllCoroutine()
    {
        StopAllCoroutine();
        ima.Clear();
    }
}

public class CoroutineTask
{
    public string Name { set; get; }
    public IEnumerator Task { get; }

    public CoroutineTask(string name, IEnumerator task)
    {
        Name = name;
        Task = task;
    }

    public bool StopCurrCoroutine()
    {
        return CoroutineMgr.Instance().StopCurrCoroutine(Name);
    }

    public void Release()
    {
        CoroutineMgr.Instance().CleanCurrCoroutine(Name);
    }
}