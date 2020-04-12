/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     UIActionBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/12/21 22:20:56
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using Framework.Event;

namespace Framework.Base
{
    /// <summary>
    /// 父物体需要必定有一个UIBase
    /// </summary>
    public abstract class UIActionBase : MonoEventEmitter
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// 显示
        /// </summary>
        public abstract void Enable();

        /// <summary>
        /// 隐藏
        /// </summary>
        public abstract void Disable();

        /// <summary>
        /// 刷新，自判断过滤
        /// </summary>
        /// <param name="args"></param>
        public abstract void Refresh(params object[] args);

        /// <summary>
        /// 释放=Destroy
        /// </summary>
        public abstract void Release();
    }
}