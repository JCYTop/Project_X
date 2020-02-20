/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/20 23:55:49
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace GOAP
{
    public abstract class ActionBase<TAction> : IAction<TAction>
    {
        public abstract TAction Label { get; }
        public abstract int Cost { get; }
        public abstract int Priority { get; }
        public abstract bool CanInterruptiblePlan { get; }
        public IState Preconditions { get; }
        public IState Effects { get; }

        private IAgent _agent;

        public ActionBase(IAgent agent)
        {
            Preconditions = InitPreconditions();
            Effects = InitEffect();
            _agent = agent;
        }

        protected abstract IState InitEffect();
        protected abstract IState InitPreconditions();

        public bool VerifyPrecondition()
        {
            return _agent.AgentState.ContainState(Preconditions);
        }
    }
}