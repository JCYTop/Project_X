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
    public abstract class AgentBase : IAgent
    {
        public IState AgentState { get; }

        public AgentBase()
        {
            DebugMsgBase.Instance = InitDebugMsgBase();
            AgentState = new State();
            AgentState.AddStateChangeListener(UdpateData);
        }

        public void UdpateData()
        {
        }

        protected abstract DebugMsgBase InitDebugMsgBase();
    }
}