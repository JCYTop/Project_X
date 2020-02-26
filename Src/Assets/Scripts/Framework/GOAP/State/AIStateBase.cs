/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AIStateBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/24 23:51:07
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using HutongGames.PlayMaker;

namespace GOAP
{
    [ActionCategory("AI/Base")]
    public abstract class AIStateBase : FsmStateAction, IState
    {
        private Action onChange;
        public IContext Context { get; }
        public StateConfig StateConfig;

        #region FsmStateAction

        public override void Init(FsmState state)
        {
            base.Init(state);
            Init();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Enter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Execute();
        }

        public override void OnExit()
        {
            base.OnExit();
            Exit();
        }

        #endregion

        public abstract void Init();
        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
        public abstract void SetData();
        public abstract StateConfig GetData();

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public void RegiestEvent()
        {
            throw new System.NotImplementedException();
        }

        public void UnRegiestEvent()
        {
            throw new System.NotImplementedException();
        }
    }
}