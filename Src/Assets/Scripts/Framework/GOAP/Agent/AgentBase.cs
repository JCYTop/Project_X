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

namespace GOAP
{
    public abstract class AgentBase<TAction, TGoal> : IAgent<TAction, TGoal>
    {
        public IContext Context { get; private set; }
        public abstract bool IsAgentOver { get; set; }
        public IState AgentState { get; }
        public IActionManager<TAction> ActionManager { get; }
        public IGoalManager<TGoal> GoalManager { get; }

        public AgentBase(IContext context)
        {
            Context = context;
            AgentState = InitAgentState();
            ActionManager = InitActionManager();
            GoalManager = InitGoalManager();
        }

        protected abstract IState InitAgentState();
        protected abstract IActionManager<TAction> InitActionManager();
        protected abstract IGoalManager<TGoal> InitGoalManager();

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

        protected abstract void TargetEvent(string eventName);
    }
}