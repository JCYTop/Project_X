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
    {
        public IState AgentState { get; }
        public IMap<TAction, TGoal> Map { get; }

        public AgentBase()
        {
            DebugMsgBase.Instance = InitDebugMsgBase();
            AgentState = new State();
            Map = InitMap(); 
            AgentState.AddStateChangeListener(UdpateData);
        }

        public void UdpateData()
        {
        }

        public void FrameFun()
        {
        }

        protected abstract DebugMsgBase InitDebugMsgBase();
        protected abstract IMap<TAction, TGoal> InitMap();
    }
}