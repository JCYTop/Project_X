//=====================================================
// - FileName:      IPool.cs
// - Created:       @JCY
// - CreateTime:    2019/03/31 22:40:57
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 池子接口
/// </summary>
public interface IPool : ICount, IOnDestory
{
    PoolLifeCycle PoolLifeCycle { set; get; }

    /// <summary>
    /// 改变池子的生命周期
    /// </summary>
    /// <param name="poolLifeCycle"></param>
    void ChangePoolLifeCycle(PoolLifeCycle poolLifeCycle);

    /// <summary>
    /// 清理池子
    /// </summary>
    void ClearPool();
}

public enum PoolLifeCycle
{
    /// <summary>
    /// 池子中所有的对象都没有Enable即刻清除对象池
    /// </summary>
    AllDisable_Clean,

    /// <summary>
    /// 池子中所有的对象都没有Enable计时清除
    /// </summary>
    AllDisable_Time,

    /// <summary>
    /// 计时清除
    /// </summary>
    Time,

    /// <summary>
    /// 一直存在于本场景
    /// </summary>
    Scence,

    /// <summary>
    /// 在所有场景中存在
    /// </summary>
    AllScence,
}