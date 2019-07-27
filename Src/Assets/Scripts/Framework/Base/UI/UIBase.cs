using System;
using NaughtyAttributes;
using UnityEngine;

public class UIBase : ObjectBase
{
    [BoxGroup("UI属性设置")] [Header("UI显示层级")]
    public UIType ShowType = UIType.UIStack;

    [BoxGroup("UI属性设置")] [Header("是否可以重复")]
    public bool IsRepeat = false;

    public override void Init()
    {
        ScenesMgr.AddUIInfo<UIType>(globalID, (int) ShowType, this);
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

        ScenesMgr.RemoveUIInfo<UIType>(globalID, (int) ShowType);
    }

    public override void Enable()
    {
        base.Enable();
        //LRU策略自动清理
        UIRootMgr.Instance().OpenUIBase(this);
    }

    public override void Disable()
    {
        base.Disable();
        //LRU策略自动清理
        UIRootMgr.Instance().CloseUIBase(this);
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

public enum UIType
{
    UINone,
    UIRoot,
    UIStack,
    UITop,
}