/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AgentBase
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/01 22:19:37
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using JetBrains.Annotations;

namespace GOAP
{
    /// <summary>
    /// 代理基类
    /// TODO 觉得很有必要添加一个StateMgr管理状态类
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    /// <typeparam name="TGoal"></typeparam>
    public abstract class AgentBase<TAction, TGoal> : IAgent<TAction, TGoal>
    {
        public IContext Context { get; private set; }
        public abstract bool IsAgentOver { get; set; }
        public IState AgentState { get; }
        public IStateManager AgentStateManager { get; protected set; }
        public IActionManager<TAction> AgentActionManager { get; }
        public IGoalManager<TGoal> AgentGoalManager { get; }

        public AgentBase(IContext context)
        {
            Context = context;
//            AgentState = InitAgentState();
//            ActionManager = InitActionManager();
//            GoalManager = InitGoalManager();
        }

        public abstract IState InitStateManager();
        public abstract IActionManager<TAction> ActionManager();
        public abstract IGoalManager<TGoal> GoalManager();

        public virtual void RegiestEvent()
        {
        }

        public virtual void UnRegiestEvent()
        {
        }

        public virtual void UpdateData()
        {
        }

        public virtual void Update()
        {
        }

        public TAgent GetAgent<TAgent>()
            where TAgent : class, IAgent<TAction, TGoal>
        {
            return this as TAgent;
        }

        /// <summary>
        /// 所有默认都为Idle状态
        /// </summary>
        /// <param name="eventName"></param>
        protected abstract void TargetEvent([NotNull] string eventName);
    }
}