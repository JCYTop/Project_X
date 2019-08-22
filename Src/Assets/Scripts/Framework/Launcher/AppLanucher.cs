//=====================================================
// - FileName:      AppLanucher.cs
// - Created:       @JCY
// - CreateTime:    2019/03/21 23:41:33
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System;
using System.Collections.Generic;

/// <summary>
/// 需要细分插入其中，从0开始依次进行
/// </summary>
public enum TaskType
{
    SystemCheck = 0, //检查程序运行
    CheckMemory, //检查内存是否够用
    Assets, //资源管理启动
    LoadBase, //载入基础信息
    Manager, //基础Manager启动
    Util, //载入工具类
    CheckLoadMode, //检测登陆模式
    SDK, //SDK处理
    Update, //资源更新处理
    Preloading, //预加载资源（一般通用）
    LoadScence, //进入游戏场景
}

/// <summary>
/// 程序启动任务入口，所有的开始（爸爸）
/// </summary>
public class AppLanucher
{
    #region  字段

    /// <summary>
    /// 开始回调
    /// </summary>
    private Action onStart = null;

    /// <summary>
    /// 完成回调
    /// </summary>
    private Action onFinish = null;

    private Queue<ILanucherTask> taskQueue = new Queue<ILanucherTask>();
    private List<ILanucherTask> taskList = new List<ILanucherTask>();

    #endregion

    public void AddTask<T>()
    {
        var type = typeof(T);
        ILanucherTask task = null;
        var constructorInfo = type.GetConstructor(Type.EmptyTypes);
        task = constructorInfo.Invoke(null) as ILanucherTask;
        task.NextTask = NextTask;
        taskList.Add(task);
    }

    public void StartTask()
    {
        if (onStart != null)
        {
            onStart();
        }

        AddQueue();
        NextTask();
    }

    /// <summary>
    /// 添加到任务队列
    /// </summary>
    private void AddQueue()
    {
        if (taskList.Count <= 0) return;
        taskList.Sort((x, y) => { return x.TaskType.CompareTo(y.TaskType); });
        foreach (var task in taskList)
        {
            taskQueue.Enqueue(task);
        }

        taskList.Clear();
    }

    /// <summary>
    /// 开始执行下一个队列
    /// </summary>
    private void NextTask()
    {
        if (taskQueue.Count <= 0)
        {
            if (onFinish != null)
                onFinish();
            return;
        }

        var task = taskQueue.Dequeue();
        task.StartTask();
    }

    /// <summary>
    /// 添加开始事件
    /// </summary>
    /// <param name="onStart"></param>
    public void AddStartListener(Action onStart)
    {
        this.onStart = onStart;
    }

    /// <summary>
    /// 添加结束事件
    /// </summary>
    /// <param name="onFinish"></param>
    public void AddFinishListener(Action onFinish)
    {
        this.onFinish = onFinish;
    }
}