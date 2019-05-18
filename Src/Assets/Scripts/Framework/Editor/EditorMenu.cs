//=====================================================
// - FileName:      EditorMenu.cs
// - Created:       @JCY
// - CreateTime:    2019/03/16 23:21:16
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using UnityEditor;
using UnityEngine;

public abstract class EditorMenu<T> : EditorWindow where T : class
{
    public static T EditorWindow;

    public static T Instance()
    {
        return SingletonProperty<T>.Instance();
    }

    public virtual void ShowMenu()
    {
        CreatWindow();
    }

    /// <summary>
    /// 绘制窗口基本信息
    /// </summary>
    [HideInInspector]
    public abstract void CreatWindow();

    /// <summary>
    /// 打开时操作
    /// </summary>
    public abstract void OnEnable();

    /// <summary>
    /// 关闭时操作
    /// </summary>
    public abstract void OnDisable();

    /// <summary>
    /// 绘制界面
    /// </summary>
    public abstract void OnGUI();
}