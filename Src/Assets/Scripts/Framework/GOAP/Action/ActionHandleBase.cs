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
    /// <summary>
    /// 执行处理Action类
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    /// <typeparam name="TGoal"></typeparam>
    public abstract class ActionHandleBase<TAction, TGoal>
    {
        private IAgent<TAction, TGoal> agent;
        public IAction<TAction> action;

        public TAction Label
        {
            get => action.Label;
        }

        public ActionHandleBase(IAgent<TAction, TGoal> agent, IAction<TAction> action)
        {
            this.agent = agent;
            this.action = action;
        }

        /// <summary>
        /// 添加动作完成回调
        /// </summary>
        /// <param name="onFinishAction"></param>
        public abstract void AddFinishCallBack(Action onFinishAction);

        /// <summary>
        /// 进入动作
        /// 可以由动画事件进入
        /// 也可以由Playable进入设置
        /// Playable可控制
        /// </summary>
        public abstract void Enter();

        /// <summary>
        /// 更新动作
        /// 也可以由Playable进入设置
        /// Playable可控制
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// 退出动作
        /// 可以由动画事件进入
        /// 也可以由Playable进入设置
        /// Playable可控制
        /// </summary>
        public abstract void Exit();
    }
}