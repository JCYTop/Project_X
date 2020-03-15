/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Agent
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/01 22:19:37
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using JetBrains.Annotations;

namespace Framework.GOAP
{
    /// <summary>
    /// 代理基类
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    /// <typeparam name="TGoal"></typeparam>
    public abstract class Agent<TAction, TGoal> : IAgent<TAction, TGoal>
    {
        public IContext Context { get; private set; }
        public abstract bool IsAgentOver { get; set; }
        public IState AgentState { get; }
        public IStateMgr AgentStateMgr { get; protected set; }
        public IActionMgr<TAction> AgentActionMgr { get; protected set; }
        public IGoalMgr<TGoal> AgentGoalMgr { get; protected set; }

        public Agent(IContext context)
        {
            Context = context;
        }

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
            try
            {
                return this as TAgent;
            }
            catch (Exception e)
            {
                LogTool.LogException(e);
                throw;
            }
        }

        /// <summary>
        /// 所有默认都为Idle状态
        /// </summary>
        /// <param name="eventName"></param>
        public abstract void TargetEvent([NotNull] string eventName);
    }
}