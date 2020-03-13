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
        public ActionExcuteState ExcuteState { get; private set; }

        public virtual void Init(IAction<ActionTag> action)
        {
            this.Action = action;
            ExcuteState = ActionExcuteState.Init;
        }

        public abstract void AddFinishCallBack(Action onFinishAction);

        public virtual void Enter()
        {
            ExcuteState = ActionExcuteState.Enter;
        }

        public virtual void Execute()
        {
            ExcuteState = ActionExcuteState.Excute;
        }

        public virtual void Exit()
        {
            ExcuteState = ActionExcuteState.Exit;
        }
    }
}