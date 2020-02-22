/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionHandle
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/21 00:12:23
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using JetBrains.Annotations;

namespace GOAP
{
    public abstract class ActionHandlerBase<TAction> : IActionHandler<TAction>
    {
        public IAction<TAction> Action { get; }

        public TAction Label
        {
            get => Action.Label;
        }

        public bool IsComplete { get; private set; }
        public bool CanPerFormAction { get; }
        private Action _onFinishAction;
        private IAgent _agent;

        public ActionHandlerBase(IAgent agent, [NotNull] IAction<TAction> action)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
            IsComplete = false;
            CanPerFormAction = false;
            _agent = agent;
        }

        public void AddFinishCallBack(Action onFinishAction)
        {
            this._onFinishAction = onFinishAction;
        }

        protected void OnComplete()
        {
            IsComplete = true;
            if (_onFinishAction != null)
            {
                _onFinishAction();
            }

            SetAgentState(Action.Effects);
            SetAgentState(Action.Preconditions.InversionValue());
        }

        private void SetAgentState(IState state)
        {
            _agent.AgentState.Set(state);
        }


        public virtual void Enter()
        {
            IsComplete = false;
        }

        public virtual void Excute()
        {
            throw new NotImplementedException();
        }

        public virtual void Exit()
        {
            throw new NotImplementedException();
        }
    }
}