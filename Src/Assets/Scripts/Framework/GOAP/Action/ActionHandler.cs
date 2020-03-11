/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionHandleBase
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/01 23:36:04
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace Framework.GOAP
{
    public abstract class ActionHandler : IActionHandler<ActionTag>
    {
        protected Action onFinishAction;

        public IAction<ActionTag> Action { get; private set; }

        /// <summary>
        /// 执行中的状态
        /// </summary>
        public abstract ActionExcuteState ExcuteState { get; }

        public virtual void Init(IAction<ActionTag> action)
        {
            this.Action = action;
        }

        public abstract void AddFinishCallBack(Action onFinishAction);
        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}