//=====================================================
// - FileName:      GameObjectPool.cs
// - Created:       @JCY
// - CreateTime:    2019/04/01 22:34:24
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool<T> : GameObjectPoolBase where T : new()
{
    protected override GameObject CreateGameObject()
    {
        var obj = new T();
        IPoolable poolable = null;
        if (obj is IPoolable)
        {
            poolable = obj as IPoolable;
            poolable.Pool = this;
        }

        return poolable.obj as GameObject;
    }
}