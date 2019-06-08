using System;
using UnityEngine;

public class UIBase : ObjectBase
{
    [Header("UI显示层级")] public UIType ShowType = UIType.Stack;

    public override void Init()
    {
        GameObjectMgr.AddUIInfo(id, this);
        UIRootMgr.Instance().PutUIBase(this);
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