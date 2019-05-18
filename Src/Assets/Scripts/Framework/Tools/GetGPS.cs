using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGPS : MonoSingleton<GetGPS>
{
    public string GPSInfo = "";//GPS的信息
    private float latitude = 0.0f;
    private float longitude = 0.0f;

    public float GetLatitude
    {
        get { return latitude; }
    }

    public float GetLongitude
    {
        get { return longitude; }
    }

    public bool GetIsEnabledByUser
    {
        get { return Input.location.isEnabledByUser; }
    }

    public void GetGPSInfo()
    {
        // 这里需要启动一个协同程序  
        StartCoroutine(StartGPS());
    }

    IEnumerator StartGPS()
    {
        if (!Input.location.isEnabledByUser)
        {
            GPSInfo = "isEnabledByUser value is: " + Input.location.isEnabledByUser.ToString() + " Please turn on the GPS";
            yield return false;
        }
        // LocationService.Start() 启动位置服务的更新,最后一个位置坐标会被使用
        Input.location.Start(10.0f, 10.0f);
        int maxWait = 20;
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

    public void StopGPS()
    {
        Input.location.Stop();
    }
}