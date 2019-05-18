//=====================================================
// - FileName:      ILanucherTask.cs
// - Created:       @JCY
// - CreateTime:    2019/03/22 00:10:57
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ILanucherTask
{
    protected List<Action> list = new List<Action>();

    private int TaskCount = 0;

    /// <summary>
    /// 获取任务名字
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// 任务类型
    /// </summary>
    public abstract TaskType TaskType { get; }

    /// <summary>
    /// 计算任务数回调
    /// </summary>
    protected Action CalcTaskCount { get; set; }

    /// <summary>
    /// 下一个任务
    /// </summary>
    public Action NextTask { get; set; }

    public void StartTask()
    {
        CalcTaskCount = () => { TaskCount -= 1; };
        AddTaskChild();
        TaskCount = list.Count;
        CoroutineMgr.Start_Coroutine(OnProcess());
    }

    public abstract void AddTaskChild();

    /// <summary>
    /// 任务处理处
    /// </summary>
    private IEnumerator OnProcess()
    {
        foreach (var action in list)
        {
            action();
        }

        while (TaskCount > 0)
        {
            yield return new WaitForFixedUpdate();
        }

        NextTask();
    }
}