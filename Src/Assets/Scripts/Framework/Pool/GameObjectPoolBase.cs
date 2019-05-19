//=====================================================
// - FileName:      GameObjectPoolBase.cs
// - Created:       @JCY
// - CreateTime:    2019/03/31 23:20:54
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameObject池子基础类
/// </summary>
public abstract class GameObjectPoolBase : MonoEventEmitter, IPool
{
    protected Stack<IPoolable> gameObjectsPool = new Stack<IPoolable>();

    /// <summary>
    /// 池子存放最大值
    /// </summary>
    public int Count { get; set; }

    public PoolLifeCycle PoolLifeCycle { get; set; }

    public void ChangePoolLifeCycle(PoolLifeCycle poolLifeCycle)
    {
        PoolLifeCycle = poolLifeCycle;
    }

    public void ClearPool()
    {
        gameObjectsPool.Clear();
    }

    /// <summary>
    /// 调用删除池子
    /// </summary>
    public void OnDestory()
    {
        //TODO 可以由全局GC管理进行
    }

    /// <summary>
    /// 获取一个要使用的GO
    /// </summary>
    /// <returns></returns>
    public GameObject GetGameObject()
    {
        if (gameObjectsPool.Count > 0)
        {
            return gameObjectsPool.Pop().obj as GameObject;
        }

        return CreateGameObject();
    }

    /// <summary>
    /// 回收对象
    /// </summary>
    /// <returns>返回对象是否被回收成功</returns>
    public bool Recycle(IPoolable go)
    {
        if (gameObjectsPool.Count < Count)
        {
            if (go is IPoolable)
            {
                go.Restore();
            }

            gameObjectsPool.Push(go);
            return true;
        }

        return false;
    }

    protected abstract GameObject CreateGameObject();
}