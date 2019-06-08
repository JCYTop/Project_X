//=====================================================
// - FileName:      GameLanucher.cs
// - Created:       @JCY
// - CreateTime:    2019/03/23 23:33:58
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

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
        appLanucher.AddTask<CheckMemory>();
        appLanucher.AddTask<Assets>();
        appLanucher.AddTask<Manager>();
        appLanucher.AddTask<LoadBase>();
        appLanucher.AddTask<CheckLoadMode>();
        appLanucher.AddTask<SDK>();
        appLanucher.AddTask<Update>();
        appLanucher.AddTask<Preloading>();
        appLanucher.AddTask<LoadScence>();
        appLanucher.StartTask();
    }

    private void OnStart()
    {
        GlobalMediator.TaskIsFinish = false;
        isShowLog = true;
    }

    private void OnFinish()
    {
        GlobalMediator.TaskIsFinish = true;
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