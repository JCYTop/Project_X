//=====================================================
// - FileName:      Check.cs
// - Created:       @JCY
// - CreateTime:    2019/03/22 00:20:39
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System;
using System.Text;
using UnityEngine;

public class SystemCheckTask : ILanucherTask
{
    public override string Name
    {
        get => "系统检查";
    }

    public override TaskType TaskType
    {
        get => TaskType.SystemCheckTask;
    }

    public override void AddTaskChild()
    {
        list.Add(GetBaseInfo);
    }

    /// <summary>
    /// 子任务1
    /// </summary>
    private void GetBaseInfo()
    {
        var info = new string[]
        {
            "设备模型 : " + SystemInfo.deviceModel,
            "设备名称 : " + SystemInfo.deviceName,
            "设备类型 : " + SystemInfo.deviceType,
            "系统内存大小MB(int) : " + SystemInfo.systemMemorySize,
            "操作系统(string) : " + SystemInfo.operatingSystem,
            "设备唯一标识符(string) : " + SystemInfo.deviceUniqueIdentifier,
            "显卡ID(int) : " + SystemInfo.graphicsDeviceID,
            "显卡名称(string) : " + SystemInfo.graphicsDeviceName,
            "显卡类型(enum) : " + SystemInfo.graphicsDeviceType,
            "显卡供应商(string) : " + SystemInfo.graphicsDeviceVendor,
            "显卡供应唯一ID(int) : " + SystemInfo.graphicsDeviceVendorID,
            "显卡版本号(int) : " + SystemInfo.graphicsDeviceVersion,
            "显存大小MB(int) : " + SystemInfo.graphicsMemorySize,
            "显卡是否支持多线程渲染(bool) : " + SystemInfo.graphicsMultiThreaded,
            "支持的渲染目标数量(int) : " + SystemInfo.supportedRenderTargetCount,
            "显示器分辨率：" + string.Format("{0} * {1}", Screen.width, Screen.height),
        };
        var sb = new StringBuilder();
        foreach (var data in info)
        {
            sb.Append(data + " || ");
        }

        LogUtil.Log(sb.ToString(), LogType.TaskLog);
        //TODO 后面插件保存，暂时方案，以设备默认分辨率为1 
        try
        {
            var with = SettingDataMgr.Instance().GetSettingInt(SettingDataMgr.ResolutionWidth);
            var height = SettingDataMgr.Instance().GetSettingInt(SettingDataMgr.ResolutionHeight);
            var frame = SettingDataMgr.Instance().GetSettingInt(SettingDataMgr.FrameRate);
            var full = SettingDataMgr.Instance().GetSettingInt(SettingDataMgr.Fullscreen);
            //TODO 根据内置设置设定来
            if (false)
            {
                MachineUtil.Resolution(with, height, Convert.ToBoolean(full), frame);
            }
            else
            {
                MachineUtil.Resolution((int) MachineUtil.ScreenWH.x, (int) MachineUtil.ScreenWH.y, Convert.ToBoolean(full), frame);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        CalcTaskCount();
    }
}