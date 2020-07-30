/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GPSUtil
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/09/28 18:09:17
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections;
using UnityEngine;

public static class GPSUtil
{
    public static string GPSInfo = ""; //GPS的信息
    private static float latitude = 0.0f;
    private static float longitude = 0.0f;

    public static float GetLatitude
    {
        get => latitude;
    }

    public static float GetLongitude
    {
        get => longitude;
    }

    public static bool GetIsEnabledByUser
    {
        get => Input.location.isEnabledByUser;
    }

    public static void GetGPSInfo()
    {
        // 这里需要启动一个协同程序 
        CoroutineMgr.Instance().StartUpCoroutine("StartGPS", StartGPS());
    }

    static IEnumerator StartGPS()
    {
        if (!Input.location.isEnabledByUser)
        {
            GPSInfo = "isEnabledByUser value is: " + Input.location.isEnabledByUser.ToString() + " Please turn on the GPS";
            yield return false;
        }

        // LocationService.Start() 启动位置服务的更新,最后一个位置坐标会被使用
        Input.location.Start(10.0f, 10.0f);
        var maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            // 暂停协同程序的执行(1秒)  
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            GPSInfo = "Init GPS service time out";
            yield return false;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSInfo = "Unable to determine device location";
            yield return false;
        }
        else
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            GPSInfo = "N:" + Input.location.lastData.latitude + "--- E:" + Input.location.lastData.longitude;
            GPSInfo = GPSInfo + " Time:" + Input.location.lastData.timestamp;
            yield return new WaitForSeconds(100);
        }
    }

    public static void StopGPS()
    {
        Input.location.Stop();
    }
}