/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GlobalEvent
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/07/27 13:52:31
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

public class GlobalEvent : MonoEventEmitter
{
    /// <summary>
    /// 当程序暂停
    /// </summary>
    /// <param name="focus"></param>
    private void OnApplicationFocus(bool focus)
    {
        Emit(GlobalEventType.OnApplicationFocus, focus);
    }

    /// <summary>
    /// 当程序获得或失去焦点
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        Emit(GlobalEventType.OnApplicationPause, pause);
    }

    /// <summary>
    /// 推出程序
    /// </summary>
    private void OnApplicationQuit()
    {
        Emit(GlobalEventType.OnApplicationQuit);
    }
}