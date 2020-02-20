/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     DebugMsg
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/20 23:16:23
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    public class DebugMsg
    {
        public static void Log(string msg)
        {
            DebugMsgBase.Instance.Log(msg);
        }

        public static void LogWarning(string msg)
        {
            DebugMsgBase.Instance.LogWarning(msg);
        }

        public static void LogError(string msg)
        {
            DebugMsgBase.Instance.LogError(msg);
        }
    }
}