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

namespace GOAP
{
    public abstract class ActionHandler<TAction> : IActionHandler<TAction>
    {
        protected Action onFinishAction;
        public TAction Label { get; private set; }

        public IAction<TAction> Action { get; private set; }

        /// <summary>
        /// 执行中的状态
        /// </summary>
        public abstract ActionExcuteState ExcuteState { get; }

        public virtual void Init(IAction<TAction> action)
        {
            this.Action = action;
            this.Label = Action.Label;
        }

        public abstract void AddFinishCallBack(Action onFinishAction);
        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}