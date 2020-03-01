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
using System.Collections.Generic;
using HutongGames.PlayMaker;
using JetBrains.Annotations;

namespace GOAP
{
    [ActionCategory("AI/Base")]
    public abstract class AIStateBase<T> : FsmStateAction, IState
    {
        private Action onChange;
        public IContext Context { get; }

        /// <summary>
        /// 配置文件ScriptableObject
        /// 需要预先配置并且拖拽
        /// </summary>
        public StateConfig<T> StateConfig;

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
        public abstract void SetData(IState data);
        public abstract IState GetData();

        public void AddStateChangeListener([NotNull] Action callback)
        {
            this.onChange = callback;
        }

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

        public IState InversionValue()
        {
            throw new NotImplementedException();
        }

        public IConfigElementBase GetSingleValue(AIStateConfigElementTag key)
        {
            throw new NotImplementedException();
        }

        public bool CompareKey(AIStateConfigElementTag key)
        {
            throw new NotImplementedException();
        }

        public ICollection<AIStateConfigElementTag> GetKeys()
        {
            throw new NotImplementedException();
        }

        public void Copy(IState otherState)
        {
            throw new NotImplementedException();
        }

        public bool ContainState(IState otherState)
        {
            throw new NotImplementedException();
        }

        public SortedList<AIStateConfigElementTag, Dictionary<IState, IConfigElementBase>> GetSameData(IState otherState)
        {
            throw new NotImplementedException();
        }

        public ICollection<AIStateConfigElementTag> GetValueDifferences(IState otherState)
        {
            throw new NotImplementedException();
        }

        public ICollection<AIStateConfigElementTag> GetNotExistKeys(IState otherState)
        {
            throw new NotImplementedException();
        }
    }
}