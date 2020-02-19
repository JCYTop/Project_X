//=====================================================
// - FileName:      CheckMemoryTask.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:31:32
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System;
using System.Collections;
using System.Runtime.InteropServices;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("GameLanucherTask")]
public class CheckMemoryTask : GameLanucherTask
{
#if UNITY_EDITOR || UNITY_STANDALONE
    [DllImport("kernel32")]
    public static extern void GlobalMemoryStatus(ref MemoryInfo meminfo);
#endif
    private int memoryDefault = 1200;

    protected override IEnumerator Task()
    {
        LogUtil.Log(string.Format(TaskName.Value), LogType.TaskLog);
        yield return new WaitForFixedUpdate();
        var memory = 0L;
#if UNITY_EDITOR|| UNITY_STANDALONE
        try
        {
            var MemInfo = new MemoryInfo();
            GlobalMemoryStatus(ref MemInfo);
            memory = Convert.ToInt64(MemInfo.AvailPhys.ToString()) / 1024 / 1024;
            LogUtil.Log(string.Format("FreeMemory: {0} MB", Convert.ToString(memory)), LogType.TaskLog);
            if (memory < memoryDefault)
            {
                LogUtil.LogError(string.Format("内存不足！"), LogType.TaskLog);
                //弹出内存警告
            }
            else
            {
                LogUtil.Log(string.Format("可以使用 ^_^"), LogType.TaskLog);
                //自动取消内存警告
                LogUtil.Log(Environment.WorkingSet.ToString(), LogType.TaskLog);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
#elif UNITY_ANDROID
        try
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass unityPluginLoader = new AndroidJavaClass("java类全名");
            float tempMemory = unityPluginLoader.CallStatic<float>("GetMemory", currentActivity);
            memory = (int) tempMemory;
            if (memory < memoryDefault)
            {
                LogUtil.LogError(string.Format("内存不足！"), LogType.TaskLog);
                //弹出内存警告
            }
            else
            {
                LogUtil.Log(string.Format("可以使用 ^_^"), LogType.TaskLog);
                //自动取消内存警告
                LogUtil.Log(Environment.WorkingSet.ToString(), LogType.TaskLog);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("com.moba.unityplugin.AndroidUtile GetMemory: " + e.Message);
            throw;
        }
#elif UNITY_IOS
        try
        {
            //TODO 不知道怎么做
//                task_basic_info_data_t taskInfo;
//                mach_msg_type_number_t infoCount = TASK_BASIC_INFO_COUNT;
//                kern_return_t kernReturn = task_info(mach_task_self(),
//                    TASK_BASIC_INFO,
//                    (task_info_t) & taskInfo,
//                    &infoCount);
//                if (kernReturn == KERN_SUCCESS)
//                {
//                    memory = taskInfo.resident_size / 1024.0 / 1024.0;
//                }
//                if (memory < memoryDefault)
//                {
//                    LogUtil.LogError(string.Format("内存不足！"), LogType.TaskLog);
//                    //弹出内存警告
//                }
//                else
//                {
//                    LogUtil.Log(string.Format("可以使用 ^_^"), LogType.TaskLog);
//                    //自动取消内存警告
//                    LogUtil.Log(Environment.WorkingSet.ToString(), LogType.TaskLog);
//                }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
#endif
        IsFinish = true;
    }

    public struct MemoryInfo
    {
        public uint Length;

        public uint MemoryLoad;

        //系统内存总量
        public ulong TotalPhys;

        //系统可用内存
        public ulong AvailPhys;
        public ulong TotalPageFile;
        public ulong AvailPageFile;
        public ulong TotalVirtual;
        public ulong AvailVirtual;
    }
}