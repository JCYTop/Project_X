/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     UIActionBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/12/21 22:18:50
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class UIBase : ObjectBase
{
    [BoxGroup("UI属性设置"), EnumPaging, SerializeField, Header("UI所在层级")]
    private UIType showType = UIType.UINone;

    [BoxGroup("UI属性设置"), EnumPaging] private UIState uiState = UIState.None;

    [BoxGroup("UI属性设置"), InfoBox("是否可以重复")]
    public bool IsRepeat = false;

    private UIActionBase[] actions;

    public UIType ShowType
    {
        get => showType;
    }

    public UIState UIState
    {
        get => uiState;
    }

    /// <summary>
    /// 外部处理UI状态显示
    /// </summary>
    /// <param name="state"></param>
    public void HandleUIState(UIState state)
    {
        switch (state)
        {
            case UIState.Init:
                Init();
                break;
            case UIState.Enable:
                Enable();
                break;
            case UIState.Disable:
                Disable();
                break;
            case UIState.Release:
                Release();
                break;
        }
    }

    #region 底层自动调用

    public override void Init()
    {
        actions = GetComponentsInChildren<UIActionBase>();
        uiState = UIState.Init;
        UIRootMgr.Instance().SetUICanvers(this);
        UIRootMgr.Instance().InsertUIBase(this);
        foreach (var action in actions)
        {
            try
            {
                action.Init();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    public override void Enable()
    {
        base.Enable();
        uiState = UIState.Enable;
        foreach (var action in actions)
        {
            try
            {
                action.Enable();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    public override void Disable()
    {
        base.Disable();
        uiState = UIState.Disable;
        foreach (var action in actions)
        {
            try
            {
                action.Disable();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    public override void Refresh(params object[] args)
    {
        foreach (var action in actions)
        {
            try
            {
                action.Refresh(args);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    /// <summary>
    /// 彻底关闭UI
    /// </summary>
    /// <exception cref="Exception"></exception>
    public override void Release()
    {
        Close();
        UIRootMgr.Instance().RemoveCloseUIDic(this);
        uiState = UIState.Release;
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

    /// <summary>
    /// 原则只隐藏不删除
    /// </summary>
    public void Close()
    {
        UIRootMgr.Instance().CloseUIBase(this);
        this.gameObject.SetActive(false);
    }

    #endregion
}

public enum UIType
{
    UINone,
    UIRoot,
    UIStack,
    UITop,
}

public enum UIState
{
    None,
    Init, //初始化
    Enable, //显示
    Disable, //隐藏
    Release, //关闭
}