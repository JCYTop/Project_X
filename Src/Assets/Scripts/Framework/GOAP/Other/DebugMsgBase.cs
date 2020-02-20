/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     DebugMsgBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/20 23:14:54
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    public abstract class DebugMsgBase
    {
        public static DebugMsgBase Instance { get; set; }

        public abstract void Log(string msg);

        public abstract void LogWarning(string msg);

        public abstract void LogError(string msg);
    }
}