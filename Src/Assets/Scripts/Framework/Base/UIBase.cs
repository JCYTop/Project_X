using System;
using NaughtyAttributes;
using UnityEngine;

public class UIBase : ObjectBase
{
    [BoxGroup("UI属性设置")] [Header("UI显示层级")]
    public UIType ShowType = UIType.Stack;

    public override void Init()
    {
        GameObjectMgr.AddUIInfo(id, this);
    }

    public override void Enable()
    {
        base.Enable();
        UIRootMgr.Instance().OpenUIBase(this);
    }

    public override void Disable()
    {
        base.Disable();
        UIRootMgr.Instance().CloseUIBase(this);
    }

    public override void Release()
    {
        UIActionBase[] actions = GetComponentsInChildren<UIActionBase>();
        foreach (var action in actions)
        {
            try
            {
                action.Release();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //LRU策略自动清理
        GameObjectMgr.RemoveUIInfo(id);
    }

    public override void Refresh(params object[] args)
    {
        UIActionBase[] actions = GetComponentsInChildren<UIActionBase>();
        foreach (var action in actions)
        {
            try
            {
                action.Refresh();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}