/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     TimeUtil
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/08/25 18:56:01
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

public static class TimeUtil
{
    private static DateTime originalTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

    /// <summary>
    /// 本地时间
    /// </summary>
    public static DateTime LocalNow
    {
        get => DateTime.Now;
    }

    /// <summary>
    /// 打印时间信息
    /// </summary>
    /// <param name="tick"></param>
    /// <param name="type"></param>
    public static string GetTime(long tick)
    {
        return new DateTime(tick).ToString("yyyy-MM-dd HH:mm:ss");
    }

    /// <summary>
    /// 获取时间信息
    /// </summary>
    /// <param name="tick">毫秒</param>
    public static string GetMilliseconds(long tick)
    {
        return originalTime.AddMilliseconds(tick).ToString("yyyy-MM-dd HH:mm:ss");
    }

    /// <summary>
    /// 计算tick加上xxx分钟后的值
    /// </summary>
    /// <param name="tick"></param>
    /// <param name="miniutes"></param>
    /// <returns>计算之后的值</returns>
    public static long AddTimeMiniutes(long tick, float miniutes)
    {
        var tmp = new DateTime(tick);
        tmp = tmp.AddMinutes(miniutes);
        return tmp.Ticks;
    }

    /// <summary>
    /// 计算tick加上xxx分钟后的值
    /// </summary>
    /// <param name="tick"></param>
    /// <param name="seconds"></param>
    /// <returns>计算之后的值</returns>
    public static long AddTimeSeconds(long tick, float seconds)
    {
        var tmp = new DateTime(tick);
        tmp = tmp.AddSeconds(seconds);
        return tmp.Ticks;
    }

    public static long AddTimeDays(long tick, float days)
    {
        var tmp = new DateTime(tick);
        tmp = tmp.AddDays(days);
        return tmp.Ticks;
    }

    /// <summary>
    /// tick1-tick2
    /// </summary>
    /// <param name="tick1"></param>
    /// <param name="tick2"></param>
    /// <returns></returns>
    public static TimeSpan CalTimeDiff(long tick1, long tick2)
    {
        return new DateTime(tick1) - new DateTime(tick2);
    }

    /// <summary>
    /// 毫秒时间戳
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public static long GetUnixTime(DateTime time)
    {
        var unixTime = (time.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        return unixTime > 0 ? unixTime : 0;
    }

    /// <summary>
    /// 秒时间戳
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public static long GetSecondUnixTime(DateTime time)
    {
        var unixTime = (time.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        return unixTime > 0 ? unixTime : 0;
    }

    /// <summary>
    /// 计算得到倒计时时间 
    /// </summary>
    /// <param name="restTime">倒计时时差</param>
    /// <returns></returns>
    public static string GetountDown(long restTime)
    {
        var time = restTime / 1000;
        var day = "0";
        if (time / (60 * 60 * 24) > 0)
        {
            day = (time / (60 * 60 * 24)).ToString();
            time = time - (int.Parse(day) * 24 * 60 * 60);
        }

        var hour = "0";
        if (time / (60 * 60) > 0)
        {
            hour = (time / (60 * 60)).ToString();
            time = time - (int.Parse(hour) * 60 * 60);
        }

        var min = "0";
        if (time / (60) > 0)
        {
            min = (time / (60)).ToString();
            time = time - (int.Parse(min) * 60);
        }

        var sec = "0";
        sec = time.ToString();
        return string.Format("{0}:{1}:{2}:{3}", day, hour, min, sec);
    }

    /// <summary>
    /// 计算得到倒计时时间 
    /// </summary>
    /// <param name="restTime">倒计时时差</param>
    /// <returns></returns>
    public static string GetountDown(double restTime, string format)
    {
        var time = restTime;
        var day = "0";
        if (time / (60 * 60 * 24) > 0)
        {
            day = (time / (60 * 60 * 24)).ToString();
            time = time - (int.Parse(day) * 24 * 60 * 60);
        }

        var hour = "0";
        if (time / (60 * 60) > 0)
        {
            hour = (time / (60 * 60)).ToString();
            time = time - (int.Parse(hour) * 60 * 60);
        }

        var min = "0";
        if (time / (60) > 0)
        {
            min = (time / (60)).ToString();
            time = time - (int.Parse(min) * 60);
        }

        var sec = "0";
        sec = time.ToString();
        return string.Format(format, day, hour, min, sec);
    }

    /// <summary>
    /// 将Unix时间转换为Utc时间
    /// </summary>
    /// <param name="timestamp"></param>
    /// <returns></returns>
    public static DateTime ConvertUnixTimeToUtc(long timestamp)
    {
        var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var date = start.AddMilliseconds(timestamp).ToUniversalTime();
        return date;
    }

    /// <summary>
    /// 将Unix时间转换为本地时间
    /// </summary>
    /// <param name="timestamp"></param>
    /// <returns></returns>
    public static DateTime ConvertUnixTimeToNow(long timestamp)
    {
        var start = new DateTime(1970, 1, 1, 0, 0, 0);
        var date = start.AddMilliseconds(timestamp);
        return date;
    }

    /// <summary>
    ///将Unix时间转换为本地时间
    /// </summary>
    /// <param name="timestamp"></param>
    /// <returns></returns>
    public static DateTime ConvertUnixTimeToLocalNow(long timestamp)
    {
        var start = new DateTime(1970, 1, 1, 0, 0, 0);
        var date = start.AddMilliseconds(timestamp);
        return date.ToLocalTime();
    }

    /// <summary>
    /// 将Unix时间转换为本地时间戳
    /// </summary>
    /// <param name="timestamp"></param>
    /// <returns></returns>
    public static long ConvertUnixTimeToLocal(DateTime timestamp)
    {
        var ts = timestamp - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        var time = Convert.ToInt64(ts.TotalMilliseconds);
        return time;
    }
}