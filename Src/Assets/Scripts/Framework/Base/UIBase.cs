using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType
{
    Root = 29,
    Stack = 30,
    Top = 31,
}

public class UIBase : ObjectBase
{
    [Header("UI显示层级")]
    public UIType ShowType = UIType.Stack;

    public override void Init()
    {
        GameObjectMgr.AddUIInfo(id, this);
    }

    public override void Release()
    {
        GameObjectMgr.RemoveUIInfo(id);
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