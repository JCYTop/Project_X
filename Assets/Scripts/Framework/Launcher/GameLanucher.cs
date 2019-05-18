//=====================================================
// - FileName:      GameLanucher.cs
// - Created:       @JCY
// - CreateTime:    2019/03/23 23:33:58
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLanucher : MonoBehaviour
{
    /// <summary>
    /// 是否显示载入LOG
    /// </summary>
    private bool isShowLog = false;

    private string onGUIStr = string.Empty;
    private AppLanucher appLanucher = new AppLanucher();

    private void Start()
    {
        appLanucher.AddStartListener(OnStart);
        appLanucher.AddFinishListener(OnFinish);
        appLanucher.AddTask<SystemCheck>();
        appLanucher.AddTask<Assets>();
        appLanucher.StartTask();
    }

    private void OnStart()
    {
        isShowLog = true;
    }

    private void OnFinish()
    {
        isShowLog = false;
    }

    private void OnGUI()
    {
        if (isShowLog)
        {
            int width = Screen.width;
            int height = Screen.height;
            GUI.TextField(new Rect(width / 2, height / 2, 800, 200), onGUIStr, new GUIStyle {fontSize = 24});
        }
    }
}