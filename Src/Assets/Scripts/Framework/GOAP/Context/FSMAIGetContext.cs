/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     FSMAIGetContext
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/05 17:31:55
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    /// <summary>
    /// AI从FSM中获取环境Context基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FSMAIGetContext<T> : FsmGetMono<AIContextBase>
    {
    }
}