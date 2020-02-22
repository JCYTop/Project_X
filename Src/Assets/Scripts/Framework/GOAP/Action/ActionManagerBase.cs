/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionManagerBAse
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/22 14:38:51
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace GOAP
{
    public abstract class ActionManagerBase<TAction, TGoal> : IActionManager<TAction>
    {
        private Dictionary<TAction, IActionHandler<TAction>> _handlerDic;
        private List<IActionHandler<TAction>> _InterruptobleHandlers;
        private IFSM<TAction> _fsm;
        private IAgent<TAction, TGoal> _agent;
        private Action _onActionComplete;

        public ActionManagerBase(IAgent<TAction, TGoal> agent)
        {
            IsPerformAction = false;
            _onActionComplete = null;
            _handlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            _InterruptobleHandlers = new List<IActionHandler<TAction>>();
            _fsm = new FSM<TAction>();
            _agent = agent;
            InitActionHandlers();
            InitInterruptobleHandlers();
            InitFSM();
        }

        private void InitFSM()
        {
            foreach (var handler in _handlerDic)
            {
                _fsm.AddState(handler.Key, handler.Value);
            }
        }

        private void InitInterruptobleHandlers()
        {
            foreach (var handler in _handlerDic)
            {
                if (handler.Value.Action.CanInterruptiblePlan)
                {
                    _InterruptobleHandlers.Add(handler.Value);
                }
            }

            _InterruptobleHandlers = _InterruptobleHandlers.OrderByDescending(u => u.Action.Priority).ToList();
        }

        protected abstract void InitActionHandlers();

        public bool IsPerformAction { get; set; }

        public void AddHandler(TAction label)
        {
            var handler = _agent.Map.GetActionHandler(label);
            if (handler != null)
            {
                _handlerDic.Add(label, _agent.Map.GetActionHandler(label));
                handler.AddFinishCallBack(() => { _onActionComplete(); });
            }
            else
            {
                DebugMsg.LogError("映射表中未找到");
            }
        }

        public void RemoveHandle(TAction label)
        {
            _handlerDic.Remove(label);
        }

        public IActionHandler<TAction> GetHandler(TAction label)
        {
            if (_handlerDic.ContainsKey(label))
            {
                return _handlerDic[label];
            }
            else
            {
                DebugMsg.LogError("缓存中未找到对应的Handler");
                return null;
            }
        }

        public void UpdateData()
        {
            foreach (var handler in _InterruptobleHandlers)
            {
                if (handler.CanPerFormAction)
                {
                    //TODO 打断计划的API
                }
            }
        }

        public void FrameFun()
        {
            _fsm.FrameFun();
        }

        public void ChangeCurrentAction(TAction label)
        {
            _fsm.ChangeState(label);
        }

        public void AddActionCompleteListener(Action complete)
        {
            _onActionComplete = complete;
        }
    }
}