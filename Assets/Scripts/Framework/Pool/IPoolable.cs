//=====================================================
// - FileName:      IPoolable.cs
// - Created:       @JCY
// - CreateTime:    2019/03/31 23:17:21
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 使用池子接口,Mono继承此接口，实现里面的方法
/// </summary>
public interface IPoolable : IBool
{
    object obj { get; }

    IPool Pool { get; set; }

    void Restore();
}