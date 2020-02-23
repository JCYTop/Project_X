/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Agent
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/20 23:44:04
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    public abstract class AgentBase<TAction, TGoal> : IAgent<TAction, TGoal>
        where TAction : struct
        where TGoal : struct
    {
        public IState AgentState { get; }
        public IMap<TAction, TGoal> Map { get; }
        public IActionManager<TAction> ActionManager { get; private set; }
        public IGoalManager<TGoal> GoalManager { get; private set; }

        public AgentBase()
        {
            DebugMsgBase.Instance = InitDebugMsgBase();
            AgentState = new State();
            Map = InitMap();
            AgentState.AddStateChangeListener(UdpateData);
            ActionManager = InitActionManager();
            GoalManager = InitGoalManager();
        }

        public void UdpateData()
        {
        }

        public void FrameFun()
        {
        }

        protected abstract DebugMsgBase InitDebugMsgBase();
        protected abstract IMap<TAction, TGoal> InitMap();
        protected abstract IActionManager<TAction> InitActionManager();
        protected abstract IGoalManager<TGoal> InitGoalManager();
    }
}