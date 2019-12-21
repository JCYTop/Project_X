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

    private AppLanucher appLanucher = new AppLanucher();
    public bool IsFinish { set; get; } = false;

    private void Start()
    {
//        appLanucher.AddStartListener(OnStart);
//        appLanucher.AddFinishListener(OnFinish);
//        appLanucher.AddTask<SystemCheckTask>();
//        appLanucher.AddTask<CheckMemoryTask>();
//        appLanucher.AddTask<AssetsTask>();
//        appLanucher.AddTask<LoadBaseTask>();
//        appLanucher.AddTask<ManagerTask>();
//        appLanucher.AddTask<UtilTask>();
//        appLanucher.AddTask<CheckLoadModeTask>();
//        appLanucher.AddTask<SDKTask>();
//        appLanucher.AddTask<UpdateTask>();
//        appLanucher.AddTask<PreloadingTask>();
//        appLanucher.StartTask();
    }

//    private void OnStart()
//    {
//        IsFinish = false;
//        isShowLog = true;
//    }
//
//    private void OnFinish()
//    {
//        IsFinish = true;
//        isShowLog = false;
//    }
}