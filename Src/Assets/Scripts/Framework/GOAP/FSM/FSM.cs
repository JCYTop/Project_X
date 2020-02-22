/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     FSM
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/22 14:20:30
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace GOAP
{
    public class FSM<TLabel> : IFSM<TLabel>
    {
        public TLabel CurrentState
        {
            get => _currentState.Label;
        }

        public TLabel PreviousState
        {
            get => _previousState.Label;
        }

        private IFSMState<TLabel> _currentState;
        private IFSMState<TLabel> _previousState;
        private Dictionary<TLabel, IFSMState<TLabel>> _stateDic;

        public FSM()
        {
            _stateDic = new Dictionary<TLabel, IFSMState<TLabel>>();
        }

        public void AddState(TLabel label, IFSMState<TLabel> state)
        {
            _stateDic.Add(label, state);
        }

        public void ChangeState(TLabel newStates)
        {
            if (!_stateDic.ContainsKey(newStates))
            {
                DebugMsg.LogError("状态机内部不包含此状态对象");
                return;
            }

            _previousState = _currentState;
            _currentState = _stateDic[newStates];
            if (_previousState != null)
            {
                _previousState.Exit();
            }

            if (_currentState != null)
            {
                _currentState.Enter();
            }
        }

        public void FrameFun()
        {
            if (_currentState != null)
                _currentState.Excute();
        }
    }
}