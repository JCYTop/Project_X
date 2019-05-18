using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActionBase : MonoEventEmitter
{
    /// <summary>
    /// 初始化
    /// </summary>
    public virtual void Init()
    {

    }

    /// <summary>
    /// 刷新
    /// </summary>
    /// <param name="args"></param>
    public virtual void Refresh(params object[] args)
    {

    }

    /// <summary>
    /// 释放=Destroy
    /// </summary>
    public virtual void Release()
    {

    }
}