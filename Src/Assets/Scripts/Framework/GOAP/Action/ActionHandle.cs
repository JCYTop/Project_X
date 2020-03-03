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
    public abstract class ActionHandle<TAction, TGoal> : IActionHandle
    {
        private IAgent<TAction, TGoal> agent;
        public IAction<TAction> action;

        /// <summary>
        /// 执行中的状态
        /// </summary>
        public ActionExcuteState ExcuteState { get; }

        /// <summary>
        /// 需要手动填写配置
        /// 需要与Action中配置数据相同
        /// </summary>
        public abstract TAction Label { get; }


        /// <summary>
        /// TODO 集成化管理
        /// TODO 手动添加注册信息了！！！
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public ActionHandle<TAction, TGoal> Init(IAgent<TAction, TGoal> agent, IAction<TAction> action)
        {
            this.agent = agent;
            this.action = action;
            return this;
        }

        public abstract void AddFinishCallBack(Action onFinishAction);
        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}